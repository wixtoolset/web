// Copyright (c) .NET Foundation and contributors. All rights reserved. Licensed under the Microsoft Reciprocal License. See LICENSE.TXT file in the project root for full license information.

namespace WixBuildTools.XmlDocToMarkdown;

using System;
using System.Collections.Generic;
using System.Linq;

public class ConvertDocXmlToMarkdownCommand
{
    private readonly static char PageIdSeparator = '/';

    public ConvertDocXmlToMarkdownCommand(string title, IDictionary<string, ICollection<DocType>> typesByNamespace)
    {
        this.Title = title;
        this.TypesByNamespace = typesByNamespace;
    }

    public string Title { get; }

    public IDictionary<string, ICollection<DocType>> TypesByNamespace { get; }

    public IEnumerable<Page> Convert()
    {
        var pages = new List<Page>();

        // First page: list of all namespaces
        var namespacesPageContent = new List<string>()
        {
            "---",
            "custom_edit_url: null",
            $"sidebar_position: 90",
            "---",
            $"# {this.Title}",
            "## Namespaces",
        };

        namespacesPageContent.AddRange(this.TypesByNamespace.Keys.OrderBy(n => n).Select(namespac => $"### [{namespac}]({PageId(namespac, "index.md")})"));
        pages.Add(new Page("index", namespacesPageContent));

        // The rest: Pages for each namespace, types therein, and members thereof
        foreach (var typesByNamespace in this.TypesByNamespace)
        {
            var namespaceName = typesByNamespace.Key;
            var types = typesByNamespace.Value;

            pages.Add(this.GenerateNamespacePage(namespaceName, types));

            foreach (var type in types)
            {
                pages.AddRange(this.GenerateTypePage(type));
            }
        }

        return pages;
    }

    private static string PageId(string id)
    {
        return id.Replace("()", "_nop").Replace(", ", "_").Replace('(', '_').Replace(")", "").ToLowerInvariant();
    }

    private static string PageId(params string[] parts)
    {
        return PageId(String.Join(PageIdSeparator, parts));
    }

    private static string PageId(Member member)
    {
        var id = member switch
        {
            Constructor ctor => String.Join(PageIdSeparator, ctor.Namespace, ctor.TypeName, ctor.Signature),
            Method method => String.Join(PageIdSeparator, method.Namespace, method.TypeName, method.Signature),
            // todo: encode params?
            Property property => String.Join(PageIdSeparator, property.Namespace, property.TypeName, property.Name),
            Event evnt => String.Join(PageIdSeparator, evnt.Namespace, evnt.TypeName, evnt.Name),
            _ => throw new ArgumentOutOfRangeException(),
        };

        return PageId(id);
    }

    private static string PageLink(DocType type)
    {
        return PageId(type.Name);
    }

    private static string PageLink(string id)
    {
        return PageId(id);
    }

    private Page GenerateNamespacePage(string namespaceName, ICollection<DocType> types)
    {
        var content = new List<string>()
        {
            "---",
            "custom_edit_url: null",
            $"sidebar_position: 1",
            "---",
            $"# {namespaceName} namespace",
        };

        var classes = types.Where(t => t.TypeFlavor == TypeFlavor.Class);
        content.AddRange(TypeContent("Classes", "Class", classes));

        var structs = types.Where(t => t.TypeFlavor == TypeFlavor.Struct);
        content.AddRange(TypeContent("Structures", "Structure", structs));

        var interfaces = types.Where(t => t.TypeFlavor == TypeFlavor.Interface);
        content.AddRange(TypeContent("Interfaces", "Interface", interfaces));

        var enums = types.Where(t => t.TypeFlavor == TypeFlavor.Enumeration);
        content.AddRange(TypeContent("Enumerations", "Enumeration", enums));

        var delegates = types.Where(t => t.TypeFlavor == TypeFlavor.Delegate);
        content.AddRange(TypeContent("Delegates", "Delegate", delegates));

        return new Page(PageId(namespaceName, "index"), content);
    }

    private static IEnumerable<string> TypeContent(string titlePlural, string titleSingular, IEnumerable<DocType> types)
    {
        var content = new List<string>();

        if (!types.IsNullOrEmpty())
        {
            content.Add($"## {titlePlural}");
            content.Add($"| {titleSingular} | Description |");
            content.Add("| -------- | ----------- |");
            foreach (var type in types)
            {
                content.Add($"| [{type.Name}]({PageLink(type)}) | {type.Summary} |");
            }
        }

        return content;
    }

    private IEnumerable<Page> GenerateTypePage(DocType type)
    {
        var content = new List<string>()
        {
            "---",
            "custom_edit_url: null",
            $"sidebar_position: 1",
            "---",
            $"# {type.Name} {type.TypeFlavor}",
            type.Summary,
        };

        var constructors = type.Members.OfType<Constructor>().OrderBy(c => c.TypeName);
        var methods = type.Members.OfType<Method>().Except(constructors).OrderBy(m => m.Name);
        var properties = type.Members.OfType<Property>().OrderBy(p => p.Name);
        var fields = type.Members.OfType<Field>().OrderBy(f => f.Name);
        var events = type.Members.OfType<Event>().OrderBy(e => e.Name);

        if (type.TypeFlavor == TypeFlavor.Delegate)
        {
            // Delegates won't have the "other stuff" most types have but 
            // they do have an Invoke method that -- for doc purposes --
            // *is* the type. It's gross, yes.
            var invoke = methods.Where(m => m.Name == "Invoke").SingleOrDefault();
            if (invoke is not null)
            {
                content.AddRange(GenerateMethodDetails(invoke));
            }
        }
        else
        {
            content.AddRange(ListMembers(constructors, "Constructor", "Constructors"));
            content.AddRange(ListMembers(methods, "Method", "Methods"));
            content.AddRange(ListMembers(properties, "Property", "Properties"));
            content.AddRange(ListMembers(events, "Event", "Events"));

            if (type.TypeFlavor == TypeFlavor.Enumeration)
            {
                content.AddRange(ListMembers(fields, "Member", "Members"));
            }
            else
            {
                content.AddRange(ListMembers(fields, "Field", "Fields"));
            }
        }

        content.AddRange(TextContent(type.Remarks, "Remarks"));
        content.AddRange(SeeAlsoContent(type.SeeAlsos));
        content.Add($"`{type.AssemblyFileName}` version `{type.AssemblyVersion}`");

        yield return new Page(PageId(type.Namespace, type.Name, "index"), content);

        foreach (var constructor in constructors)
        {
            yield return new Page(PageId(constructor), GenerateMethodPage(constructor));
        }

        if (type.TypeFlavor != TypeFlavor.Delegate)
        {
            foreach (var method in methods)
            {
                yield return new Page(PageId(method), GenerateMethodPage(method));
            }
        }

        foreach (var property in properties)
        {
            yield return new Page(PageId(property), GeneratePropertyPage(property));
        }

        foreach (var eventDoc in events)
        {
            yield return new Page(PageId(eventDoc), GenerateEventPage(eventDoc));
        }


        static IEnumerable<string> ListMembers(IEnumerable<Member> members, string memberTypeSingular, string memberTypePlural, bool addLinks = false)
        {
            var content = new List<string>();

            if (!members.IsNullOrEmpty())
            {
                content.Add($"## {memberTypePlural}");

                content.Add($"| {memberTypeSingular} | Description |");
                content.Add("| ------ | ----------- |");

                foreach (var member in members)
                {
                    var name = member switch
                    {
                        Method method => method.Signature,
                        _ => member.Name
                    };

                    if (member is Field)
                    {
                        content.Add($"| {name} | {member.Summary} |");
                    }
                    else
                    {
                        content.Add($"| [{name}]({PageLink(name)}) | {member.Summary} |");
                    }
                }
            }

            return content;
        }
    }

    private static IEnumerable<string> GenerateMethodPage(Method method)
    {
        var methodType = method is Constructor ? "Constructor" : "Method";

        var content = new List<string>()
        {
            "---",
            "custom_edit_url: null",
            $"sidebar_position: 1",
            "---",
            $"# {method.Name}({GetParameterNamesForDisplay(method)}) {methodType}",
            method.Summary,
        };

        content.AddRange(GenerateMethodDetails(method));

        return content;
    }

    private static IEnumerable<string> GenerateMethodDetails(Method method)
    {
        var content = new List<string>();

        content.Add("## Declaration");

        var returnType = String.IsNullOrEmpty(method.ReturnType) ? String.Empty : $"{method.ReturnType.SimplifyTypeName(method.Namespace)} ";

        if (method.Parameters.IsNullOrEmpty())
        {
            content.Add("```cs");
            content.Add($"{method.Keywords} {returnType}{method.Name}");
            content.Add("```");
        }
        else
        {
            content.Add("```cs");
            content.Add($"{method.Keywords} {returnType}{method.Name}(");
            content.Add(String.Join("," + Environment.NewLine, method.Parameters.Select(parameter => $"  {parameter.Type.SimplifyTypeName(method.Namespace)} {parameter.Name}")));
            content.Add(")");
            content.Add("```");
            content.AddRange(ParametersContent(method.Parameters, method.Namespace));
        }

        if (!String.IsNullOrWhiteSpace(method.Returns))
        {
            content.Add("## Return value");
            content.Add(method is Constructor ? $"{method.Returns}" : $"`{method.ReturnType.SimplifyTypeName(method.Namespace)}` {method.Returns}");
        }

        content.AddRange(TextContent(method.Remarks, "Remarks"));
        content.AddRange(SeeAlsoContent(method.SeeAlsos));

        if (!method.Exceptions.IsNullOrEmpty())
        {
            content.Add("## Exceptions");
            content.Add("| Exception | Description |");
            content.Add("| --------- | ----------- |");

            foreach (var exception in method.Exceptions)
            {
                content.Add($"| {exception.Type} | {exception.Summary} |");
            }
        }

        return content;
    }

    private static IEnumerable<string> GeneratePropertyPage(Property property)
    {
        var content = new List<string>()
        {
            "---",
            "custom_edit_url: null",
            $"sidebar_position: 1",
            "---",
            $"# {property.Name} Property",
            property.Summary,
            "## Declaration",
        };

        var getter = property.CanRead ? "get;" : String.Empty;
        var setter = property.CanRead ? " set;" : String.Empty;

        if (property.Parameters.IsNullOrEmpty())
        {
            content.Add("```cs");
            content.Add($"{property.Keywords} {property.Type.SimplifyTypeName(property.Namespace)} {property.Name} {{ {getter}{setter} }} ");
            content.Add("```");
        }
        else
        {
            content.Add("```cs");
            content.Add($"{property.Keywords} {property.Type.SimplifyTypeName(property.Namespace)} {property.Name}[");
            content.Add($"  {String.Join(", ", property.Parameters.Select(p => $"{p.Type.SimplifyTypeName()} {p.Name}"))}");
            content.Add($"] {{ {getter}{setter} }} ");
            content.Add("```");
            content.AddRange(ParametersContent(property.Parameters, property.Namespace));
        }

        content.AddRange(TextContent(property.Remarks, "Remarks"));
        content.AddRange(SeeAlsoContent(property.SeeAlsos));

        if (!property.Exceptions.IsNullOrEmpty())
        {
            content.Add("## Exceptions");
            content.Add("| Exception | Description |");
            content.Add("| --------- | ----------- |");

            foreach (var exception in property.Exceptions)
            {
                content.Add($"| {exception.Type} | {exception.Summary} |");
            }
        }

        return content;
    }

    private static IEnumerable<string> GenerateEventPage(Event evnt)
    {
        var content = new List<string>()
        {
            "---",
            "custom_edit_url: null",
            $"sidebar_position: 1",
            "---",
            $"# {evnt.Name} Event",
            evnt.Summary,
            "## Declaration",
            "```cs",
            $"{evnt.Keywords} {evnt.Type.SimplifyTypeName(evnt.Namespace)} {evnt.Name}",
            "```",
            "## Value",
            $"`{evnt.Type.SimplifyTypeName(evnt.Namespace)}`",
        };

        content.AddRange(TextContent(evnt.Remarks, "Remarks"));
        content.AddRange(SeeAlsoContent(evnt.SeeAlsos));

        return content;
    }

    private static string GetParameterNamesForDisplay(Method method)
    {
        return String.Join(", ", method.Parameters.Select(p => p.Name));
    }

    private static IEnumerable<string> ParametersContent(IEnumerable<Parameter> parameters, string namespac)
    {
        var content = new List<string>()
        {
            "## Parameters",
            "| Parameter | Type | Description |",
            "| --------- | ---- | ----------- |",
        };

        foreach (var parameter in parameters)
        {
            content.Add($"| {parameter.Name} | {parameter.Type.SimplifyTypeName(namespac)} | {parameter.Summary} |");
        }

        return content;
    }

    private static IEnumerable<string> TextContent(string text, string title)
    {
        var content = new List<string>();

        if (!String.IsNullOrWhiteSpace(text))
        {
            content.Add($"## {title}");
            content.Add(text);
        }

        return content;
    }

    private static IEnumerable<string> SeeAlsoContent(IEnumerable<string> seeAlsos)
    {
        var content = new List<string>();

        if (!seeAlsos.IsNullOrEmpty())
        {
            content.Add($"## See also");
            // TODO: Make each entry a link.
            content.AddRange(seeAlsos.Select(s => $"- {s}"));
        }

        return content;
    }
}
