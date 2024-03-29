// Copyright (c) .NET Foundation and contributors. All rights reserved. Licensed under the Microsoft Reciprocal License. See LICENSE.TXT file in the project root for full license information.

namespace WixBuildTools.XmlDocToMarkdown;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

[DebuggerDisplay("{AssemblyName}")]
public class DocXml
{
    public static DocXml Parse(XDocument document, Assembly assembly)
    {
        var docXml = new DocXml(document, assembly);

        docXml.Parse();

        return docXml;
    }

    private XElement Root { get; }
    private Dictionary<string, TypeInfo> AssemblyTypes { get; }
    private Dictionary<string, MethodBase> AssemblyMethods { get; }
    private Dictionary<string, PropertyInfo> AssemblyProperties { get; }
    private Dictionary<string, FieldInfo> AssemblyFields { get; }
    private Dictionary<string, EventInfo> AssemblyEvents { get; }

    public string AssemblyFileName { get; }

    public string AssemblyVersion { get; }

    public IEnumerable<DocType> Types { get; private set; }

    private DocXml()
    {
    }

    private DocXml(XDocument document, Assembly assembly)
    {
        this.AssemblyFileName = Path.GetFileName(assembly.Location);
        this.AssemblyVersion = FileVersionInfo.GetVersionInfo(assembly.Location).ProductVersion;
        this.Root = document.Root;

        // Reflect on the assembly to get all its secrets that we need to bolster the XML doc comments.
        this.AssemblyTypes = assembly.DefinedTypes
            .OrderBy(t => t.FullName)
            .ToDictionary(type => type.FullName);

        var assemblyConstructors = assembly.ExportedTypes.SelectMany(t
            => t.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly));
        var assemblyMethods = assembly.ExportedTypes.SelectMany(t
            => t.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly)
            .Where(m => !m.IsSpecialName && !m.DeclaringType.FullName.StartsWith("System.") && !m.IsPrivate))
            .OrderBy(m => MethodKey(m));
        this.AssemblyMethods = new List<MethodBase>(assemblyConstructors).Concat(assemblyMethods)
            .ToDictionary(m => MethodKey(m));

        var assemblyProperties = assembly.ExportedTypes.SelectMany(t
            => t.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly));
        this.AssemblyProperties = assemblyProperties.ToDictionary(p => PropertyKey(p));

        var assemblyFields = assembly.DefinedTypes.SelectMany(t
            => t.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly));
        this.AssemblyFields = assemblyFields.ToDictionary(f => MemberKey(f));

        var assemblyEvents = assembly.ExportedTypes.SelectMany(t
            => t.GetEvents(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly));
        this.AssemblyEvents = assemblyEvents.ToDictionary(e => MemberKey(e));
    }

    private void Parse()
    {
        var docTypes = new Dictionary<string, DocType>();

        foreach (var xMember in this.Root.Element("members").Elements("member"))
        {
            var memberId = xMember.Attribute("name").Value;
            var memberType = memberId[..2];
            var memberName = memberId[2..];

            switch (memberType)
            {
                case "T:":
                {
                    if (docTypes.TryGetValue(memberName, out var _))
                    {
                        Console.Error.WriteLine($"Duplicate type `{memberName}` encountered. Ignoring.");
                    }
                    else
                    {
                        var summary = GetSummary(xMember);
                        var remarks = GetRemarks(xMember);
                        var seeAlsos = GetSeeAlsos(xMember);
                        var members = new List<Member>();

                        if (this.AssemblyTypes.TryGetValue(memberName, out var type))
                        {
                            if (type.IsVisible)
                            {
                                var flavor = GetTypeFlavor(type);

                                if (flavor == TypeFlavor.Delegate)
                                {
                                    // Delegate Invoke members aren't in the XML doc unless the parameters have doc comments,
                                    // so add the member here so we can at least create a skeletal page.
                                    var invoke = type.GetMethods().Where(m => m.Name == "Invoke").ToArray();
                                    if (invoke.Length == 1)
                                    {
                                        members.Add(GetMethodDoc(xMember, invoke[0]));
                                    }
                                    else
                                    {
                                        Console.Error.WriteLine($"For delegate `{memberName}`, found {invoke.Length} Invoke methods. Need exactly one. Ignoring.");
                                    }
                                }

                                docTypes.Add(memberName, new(flavor, type.Namespace, type.Name, summary, remarks, seeAlsos, members, this.AssemblyFileName, this.AssemblyVersion));

                            }
                            else
                            {
                                this.ReportExcludedMember(type.Namespace, type.Name);
                            }
                        }
                        else
                        {
                            Console.Error.WriteLine($"Couldn't find type `{memberName}`. Ignoring.");
                        }
                    }
                }
                break;

                case "M:":
                {
                    if (this.AssemblyMethods.TryGetValue(memberName, out var method))
                    {
                        if (this.IncludeMember(method))
                        {
                            var type = GetOrCreateType(method);

                            type.Members.Add(GetMethodDoc(xMember, method));
                        }
                    }
                    else
                    {
                        this.ReportMissingAssemblyMember(memberId);
                    }
                }
                break;

                case "P:":
                {
                    if (this.AssemblyProperties.TryGetValue(memberName, out var property))
                    {
                        if (this.IncludeMember(property))
                        {
                            var type = GetOrCreateType(property);
                            var summary = GetSummary(xMember);
                            var remarks = GetRemarks(xMember);
                            var seeAlsos = GetSeeAlsos(xMember);
                            var parameterTypes = property.GetIndexParameters()?.ToDictionary(p => p.Name);
                            var parameters = GetParameters(xMember, parameterTypes);
                            var exceptions = GetExceptions(xMember);

                            type.Members.Add(new Property(DetermineKeywords(property), property.ReflectedType.Namespace, property.ReflectedType.Name, property.Name, property.PropertyType.ToString(), summary, remarks, seeAlsos, parameters, exceptions, property.CanRead, property.CanWrite));
                        }
                    }
                    else
                    {
                        this.ReportMissingAssemblyMember(memberId);
                    }
                }
                break;

                case "F:":
                {
                    if (this.AssemblyFields.TryGetValue(memberName, out var field))
                    {
                        if (this.IncludeMember(field))
                        {
                            var type = GetOrCreateType(field);
                            var summary = GetSummary(xMember);
                            var remarks = GetRemarks(xMember);
                            var seeAlsos = GetSeeAlsos(xMember);

                            type.Members.Add(new Field(DetermineKeywords(field), field.ReflectedType.Namespace, field.ReflectedType.Name, field.Name, field.FieldType.ToString(), summary, remarks, seeAlsos));
                        }
                    }
                    else
                    {
                        this.ReportMissingAssemblyMember(memberId);
                    }
                }
                break;

                case "E:":
                {
                    if (this.AssemblyEvents.TryGetValue(memberName, out var evnt))
                    {
                        if (this.IncludeMember(evnt))
                        {
                            var type = GetOrCreateType(evnt);
                            var summary = GetSummary(xMember);
                            var remarks = GetRemarks(xMember);
                            var seeAlsos = GetSeeAlsos(xMember);

                            type.Members.Add(new Event(DetermineKeywords(evnt), evnt.ReflectedType.Namespace, evnt.ReflectedType.Name, evnt.Name, evnt.EventHandlerType.ToString(), summary, remarks, seeAlsos));
                        }
                    }
                    else
                    {
                        this.ReportMissingAssemblyMember(memberId);
                    }
                }
                break;

                default:
                    throw new Exception($"Don't know how to handle member `{memberId}`!");
            }
        }

        this.Types = docTypes.Values.OrderBy(t => t.Name).ToList();

        DocType GetOrCreateType(MemberInfo member)
        {
            if (!docTypes.TryGetValue(member.ReflectedType.FullName, out var type))
            {
                type = new(GetTypeFlavor(member.ReflectedType), member.ReflectedType.Namespace, member.ReflectedType.Name, String.Empty, String.Empty, Enumerable.Empty<string>(), new List<Member>(), this.AssemblyFileName, this.AssemblyVersion);
                docTypes.Add(member.ReflectedType.FullName, type);
            }

            return type;
        }
    }

    private void ReportExcludedMember(string typeName, string memberName)
    {
        // TODO: Add a command-line switch.
        // Console.Error.WriteLine($"Excluding private or internal assembly member `{typeName}.{memberName}`.");
    }

    private void ReportMissingAssemblyMember(string memberId)
    {
        // TODO: Add a command-line switch.
        // Console.Error.WriteLine($"Couldn't find assembly member `{memberId}`. Ignoring.");
    }

    private static string DetermineKeywords(MemberInfo member)
    {
        var keywords = IsMemberPublic(member) == true ? "public" : "protected";

        if (IsMemberStatic(member) == true)
        {
            keywords += " static";
        }

        return keywords;
    }

    private bool IncludeMember(MemberInfo member)
    {
        if (IsMemberPublic(member) == true || IsMemberProtected(member) == true)
        {
            return true;
        }
        else
        {
            this.ReportExcludedMember(member.ReflectedType.FullName, member.Name);

            return false;
        }
    }

    private static bool? IsMemberPublic(MemberInfo member)
    {
        return member switch
        {
            MethodInfo method => method.IsPublic,
            PropertyInfo property => property.GetMethod?.IsPublic,
            EventInfo evnt => evnt.AddMethod?.IsPublic,
            FieldInfo field => field.IsPublic,
            _ => false,
        };
    }

    private static bool? IsMemberProtected(MemberInfo member)
    {
        return member switch
        {
            MethodInfo method => method.IsFamily,
            PropertyInfo property => property.GetMethod?.IsFamily,
            EventInfo evnt => evnt.AddMethod?.IsFamily,
            FieldInfo field => field.IsFamily,
            _ => false,
        };
    }

    private static bool? IsMemberStatic(MemberInfo member)
    {
        return member switch
        {
            MethodInfo method => method.IsStatic,
            PropertyInfo property => property.GetMethod?.IsStatic,
            EventInfo evnt => evnt.AddMethod?.IsStatic,
            FieldInfo field => field.IsStatic,
            _ => false,
        };
    }

    private static string MemberKey(MemberInfo member)
    {
        var key = $"{member.ReflectedType.FullName}.{member.Name}";

        return key;
    }

    private static string MethodKey(MethodBase method)
    {
        var name = method.Name == ".ctor" ? "#ctor" : method.Name;
        var parameters = String.Join(",", method.GetParameters().Select(p => p.ParameterType));
        var decoratedParameters = String.IsNullOrEmpty(parameters) ? String.Empty : $"({parameters})";
        var key = $"{method.ReflectedType.FullName}.{name}{decoratedParameters}";

        return key;
    }

    private static string PropertyKey(PropertyInfo property)
    {
        var parameters = String.Join(",", property.GetIndexParameters().Select(p => p.ParameterType));
        var decoratedParameters = String.IsNullOrEmpty(parameters) ? String.Empty : $"({parameters})";
        var key = $"{property.GetMethod.ReflectedType.FullName}.{property.Name}{decoratedParameters}";

        return key;
    }

    private static Method GetMethodDoc(XElement xMember, MethodBase method)
    {
        var summary = GetSummary(xMember);
        var remarks = GetRemarks(xMember);
        var seeAlsos = GetSeeAlsos(xMember);
        var returns = GetReturns(xMember);
        var parameterTypes = method.GetParameters()?.ToDictionary(p => p.Name);
        var parameters = GetParameters(xMember, parameterTypes);
        var exceptions = GetExceptions(xMember);

        if (method.Name == ".ctor")
        {
            var signature = GetParametersSignatureForDisplay(method.ReflectedType.Name, parameters);
            return new Constructor(DetermineKeywords(method), method.ReflectedType.Namespace, method.ReflectedType.Name, signature, summary, remarks, seeAlsos, returns, parameters, exceptions);
        }
        else
        {
            var signature = GetParametersSignatureForDisplay(method.Name, parameters);
            var fullMethod = (MethodInfo)method;
            return new Method(DetermineKeywords(method), fullMethod.ReflectedType.Namespace, fullMethod.ReflectedType.Name, fullMethod.Name, signature, fullMethod.ReturnType.ToString(), summary, remarks, seeAlsos, returns, parameters, exceptions);
        }
    }

    private static TypeFlavor GetTypeFlavor(Type type)
    {
        if (type.IsInterface)
        {
            return TypeFlavor.Interface;
        }
        else if (type.BaseType.FullName == "System.Enum")
        {
            return TypeFlavor.Enumeration;
        }
        else if (type.BaseType.FullName == "System.MulticastDelegate")
        {
            return TypeFlavor.Delegate;
        }
        else if (type.IsValueType)
        {
            return TypeFlavor.Struct;
        }
        else
        {
            return TypeFlavor.Class;
        }
    }

    private static string GetParametersSignatureForDisplay(string name, IEnumerable<Parameter> parameters)
    {
        return $"{name}({String.Join(", ", parameters.Select(p => p.Name))})";
    }

    private static string GetSummary(XElement xMember)
    {
        return xMember.Element("summary").GetRichText();
    }

    private static string GetRemarks(XElement xMember)
    {
        return xMember.Element("remarks").GetRichText();
    }

    private static string GetReturns(XElement xMember)
    {
        return xMember.Element("returns").GetRichText();
    }

    private static IEnumerable<Parameter> GetParameters(XElement xMember, Dictionary<string, ParameterInfo> paramatersByName)
    {
        var parameters = new List<Parameter>();

        foreach (var xParam in xMember.Elements("param"))
        {
            var name = xParam.Attribute("name")?.Value;

            if (paramatersByName.TryGetValue(name, out var parameterInfo))
            {
                parameters.Add(new Parameter(parameterInfo.Name, parameterInfo.ParameterType.ToString(), xParam.Value?.ReduceWhitespace(collapseLines: true)));
            }
        }

        return parameters;
    }

    private static IEnumerable<ThrownException> GetExceptions(XElement xMember)
    {
        return xMember.Elements("exception").Select(xException =>
            new ThrownException(xException.Attribute("cref")?.Value, xException.Value)
            );
    }

    private static IEnumerable<string> GetSeeAlsos(XElement xMember)
    {
        return xMember.Elements("seealso").Select(xSeealso =>
            xSeealso.Attribute("cref")?.Value
            );
    }
}
