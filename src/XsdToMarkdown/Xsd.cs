// Copyright (c) .NET Foundation and contributors. All rights reserved. Licensed under the Microsoft Reciprocal License. See LICENSE.TXT file in the project root for full license information.

namespace WixBuildTools.XsdToMarkdown
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Xml.Linq;

    [DebuggerDisplay("SchemaName={SchemaName,nq} TargetNamespace={TargetNamespace,nq}")]
    public class Xsd
    {
        private static readonly XNamespace XmlSchemaNamespace = "http://www.w3.org/2001/XMLSchema";
        private static readonly XNamespace XmlSchemaExtensionNamespace = "http://wixtoolset.org/schemas/XmlSchemaExtension";

        private static readonly XName AnnotationElement = XmlSchemaNamespace + "annotation";
        private static readonly XName DocumentationElement = XmlSchemaNamespace + "documentation";
        private static readonly XName ElementElement = XmlSchemaNamespace + "element";
        private static readonly XName AppInfoElement = XmlSchemaNamespace + "appinfo";
        private static readonly XName ParentElement = XmlSchemaExtensionNamespace + "parent";
        private static readonly XName MsiRefElement = XmlSchemaExtensionNamespace + "msiRef";
        private static readonly XName RemarksElement = XmlSchemaExtensionNamespace + "remarks";
        private static readonly XName SeeAlsoElement = XmlSchemaExtensionNamespace + "seeAlso";
        private static readonly XName ComplexTypeElement = XmlSchemaNamespace + "complexType";
        private static readonly XName AttributeElement = XmlSchemaNamespace + "attribute";
        private static readonly XName AttributeGroupElement = XmlSchemaNamespace + "attributeGroup";
        private static readonly XName SimpleTypeElement = XmlSchemaNamespace + "simpleType";
        private static readonly XName RestrictionElement = XmlSchemaNamespace + "restriction";
        private static readonly XName EnumerationElement = XmlSchemaNamespace + "enumeration";
        private static readonly XName SimpleContentElement = XmlSchemaNamespace + "simpleContent";
        private static readonly XName ExtensionElement = XmlSchemaNamespace + "extension";
        private static readonly XName MainElement = XmlSchemaExtensionNamespace + "main";
        private static readonly XName DeprecatedElement = XmlSchemaExtensionNamespace + "deprecated";

        public XDocument Document { get; private set; }
        public bool IsMainSchema { get; private set; }
        public string TargetNamespace { get; private set; }
        public string SchemaName { get; private set; }
        public string SchemaDocumentation { get; private set; }
        public IDictionary<string, Element> Elements { get; }
        public IEnumerable<Element> RootElements { get; }
        public IDictionary<string, IEnumerable<Attribute>> AttributeGroups { get; private set; }
        public IDictionary<string, Attribute> RootAttributes { get; private set; }
        public IDictionary<string, SimpleType> SimpleTypes { get; }

        public Xsd(XDocument xsd)
        {
            this.Document = xsd;
            this.IsMainSchema = xsd.Root.Element(AnnotationElement)?.Element(AppInfoElement)?.Element(MainElement) != null;
            this.TargetNamespace = xsd.Root.Attribute("targetNamespace").Value;
            this.SchemaName = GetSchemaNameFromNamespace(this.TargetNamespace);
            this.SchemaDocumentation = this.GetSchemaDocumentation();

            var xSimpleTypes = xsd.Root.Elements(SimpleTypeElement);
            this.SimpleTypes = xSimpleTypes.Select(x => ParseSimpleType(x)).ToDictionary(t => t.Name);

            var xAttributes = xsd.Root.Elements(AttributeElement);
            this.RootAttributes = xAttributes?.Select(x => this.ParseAttribute(x)).ToDictionary(a => a.Name);

            this.AttributeGroups = this.ParseAttributeGroups(xsd.Root);

            var xElements = xsd.Root.Elements(ElementElement);
            this.Elements = xElements?.Select(x => this.CreateElement(x)).ToDictionary(el => el.Name);

            // bugbugbug: fix wix.xsd so that parentless elements are actually parentless
            // this.RootElements = xElements.Where(x => x.Element(AnnotationElement)?.Element(AppInfoElement)?.Elements(ParentElement) == null)?.Select(x => this.CreateElement(x));
            this.RootElements = Enumerable.Empty<Element>();
        }

        public static string GetSchemaNameFromNamespace(string targetNamespace)
        {
            var namespaceParts = targetNamespace.Split('/');
            var schemaName = namespaceParts[^1];

            return Capitalize(schemaName);
        }

        private static SimpleType ParseSimpleType(XElement xSimpleType)
        {
            var name = xSimpleType.Attribute("name")?.Value;
            var doc = GetDocumentationFromAnnotation(xSimpleType.Element(AnnotationElement));
            var enumValues = CreateEmuerationValues(xSimpleType);

            return new SimpleType(name, doc, enumValues);
        }

        private static IEnumerable<EnumValue> CreateEmuerationValues(XElement xSimpleType)
        {
            var xRestriction = xSimpleType?.Element(RestrictionElement);
            var enumerations = xRestriction?.Elements(EnumerationElement);
            return enumerations == null
                ? Enumerable.Empty<EnumValue>()
                : enumerations.Select(x => new EnumValue(x.Attribute("value")?.Value, GetDocumentationFromAnnotation(x.Element(AnnotationElement))));
        }

        private Element CreateElement(XElement xElement)
        {
            var name = xElement.Attribute("name")?.Value;
            var xAnnotation = xElement.Element(AnnotationElement);
            var xAppInfo = xAnnotation?.Element(AppInfoElement);
            var xComplexType = xElement.Element(ComplexTypeElement);

            var deprecation = GetDeprecation(xAnnotation, "element");
            var documentation = String.IsNullOrEmpty(deprecation) ? GetDocumentationFromAnnotation(xAnnotation) : deprecation;

            var msiRefs = xAppInfo?.Elements(MsiRefElement).Select(x => CreateMsiRef(x));

            var parents = xAppInfo?.Elements(ParentElement).Select(x => CreateParent(x));

            var children = xComplexType?.Descendants(ElementElement).Select(x => this.CreateChild(x));

            var xRemarks = xAppInfo?.Element(RemarksElement);

            var remarks = ParseInnerText(xRemarks);

            var attributes = this.CreateAttributes(xComplexType);

            var seeAlsos = xAppInfo?.Elements(SeeAlsoElement).SelectMany(x => this.CreateSeeAlsoElement(x));

            return new Element(name, this.TargetNamespace, documentation, remarks, attributes, parents, children, msiRefs, seeAlsos);
        }

        private IEnumerable<Element> CreateSeeAlsoElement(XElement xSeeAlso)
        {
            var element = xSeeAlso.Attribute("ref")?.Value;
            var @namespace = xSeeAlso.Attribute("namespace")?.Value;

            yield return new Element(element, @namespace);
        }

        private IEnumerable<Attribute> CreateAttributes(XElement xComplexType)
        {
            if (xComplexType != null)
            {
                var attributeGroupReferences = xComplexType.Elements(AttributeGroupElement).Select(x => x.Attribute("ref")?.Value);
                var attributeGroupAttributes = attributeGroupReferences.SelectMany(a => this.AttributeGroups[a]);
                var attributes = attributeGroupAttributes.Concat(this.ParseAttributes(xComplexType));

                return attributes.OrderBy(attr => attr.Name);
            }

            return Enumerable.Empty<Attribute>();
        }

        private Child CreateChild(XElement xParent)
        {
            var childElement = xParent.Attribute("ref")?.Value;
            var minOccurs = xParent.Attribute("minOccurs")?.Value ?? xParent.Parent.Attribute("minOccurs")?.Value ?? "1";
            var maxOccurs = xParent.Attribute("maxOccurs")?.Value ?? xParent.Parent.Attribute("maxOccurs")?.Value ?? "1";
            var doc = GetDocumentationFromAnnotation(xParent.Element(AnnotationElement), prefix: ": ");
            var cardinality = Cardinality(minOccurs, maxOccurs);

            return new Child(this.TargetNamespace, childElement, String.IsNullOrEmpty(doc) ? String.Empty : doc, cardinality);

            static string Cardinality(string minOccurs, string maxOccurs)
            {
                var optional = Int32.TryParse(minOccurs, out var min) && min == 0 ? /*"optional" default*/ String.Empty : "required";
                var unbounded = !String.IsNullOrEmpty(maxOccurs) && maxOccurs.Equals("unbounded", StringComparison.OrdinalIgnoreCase);
                var max = unbounded ? /*"unlimited" default*/ String.Empty : $"no more than {maxOccurs}";
                var any = !String.IsNullOrEmpty(optional) || !String.IsNullOrEmpty(max);

                return String.Concat(any ? "(" : null, optional, String.IsNullOrEmpty(optional) ? null : ", ", max, any ? ") " : null);
            }
        }

        private static Parent CreateParent(XElement xParent)
        {
            var parentNamespace = xParent.Attribute("namespace")?.Value;
            var parentElement = xParent.Attribute("ref")?.Value;

            return new Parent(parentNamespace, parentElement);
        }

        private static MsiRef CreateMsiRef(XElement xMsiRef)
        {
            var action = xMsiRef.Attribute("action")?.Value;
            var table = xMsiRef.Attribute("table")?.Value;

            return new MsiRef(action, table);
        }

        private string GetSchemaDocumentation()
        {
            var xAnnotation = this.Document.Root.Element(AnnotationElement);
            var documentation = GetDocumentationFromAnnotation(xAnnotation);
            return documentation;
        }

        private Dictionary<string, IEnumerable<Attribute>> ParseAttributeGroups(XElement root)
        {
            var xAttributeGroups = root.Elements(AttributeGroupElement);

            var result = xAttributeGroups.ToDictionary(
                x => x.Attribute("name")?.Value,
                x => this.ParseAttributes(x));

            return result;
        }

        private IEnumerable<Attribute> ParseAttributes(XElement parent)
        {
            // Use simple content if it exists.
            parent = parent.Element(SimpleContentElement)?.Element(ExtensionElement) ?? parent;

            var xAttributes = parent.Elements(AttributeElement);
            return xAttributes.Select(x => this.ParseAttribute(x));
        }

        private Attribute ParseAttribute(XElement xAttribute)
        {
            var name = xAttribute.Attribute("name")?.Value;
            var required = String.Equals(xAttribute.Attribute("use")?.Value, "required", StringComparison.OrdinalIgnoreCase);
            var type = this.GetAttributeType(xAttribute);
            var typeDocumentation = String.Empty;

            IEnumerable<EnumValue> enumValues = null;
            if (String.IsNullOrEmpty(type))
            {
                var xSimpleType = xAttribute.Element(SimpleTypeElement);
                enumValues = CreateEmuerationValues(xSimpleType);
            }
            else if (this.SimpleTypes.TryGetValue(type, out var simpleType))
            {
                typeDocumentation = simpleType.Documentation;
                enumValues = simpleType.EnumValues;
            }

            var xAnnotation = xAttribute.Element(AnnotationElement);
            var deprecation = GetDeprecation(xAnnotation, "attribute");
            var documentation = deprecation ?? GetDocumentationFromAnnotation(xAnnotation);

            var xAppInfo = xAnnotation?.Element(AppInfoElement);
            var xParents = xAppInfo?.Elements(ParentElement);
            var parents = xParents?.Select(x => CreateParent(x));

            return new Attribute(name, documentation, type, typeDocumentation, required, enumValues, parents);
        }

        private static string Capitalize(string value)
        {
            if (value.Length > 0)
            {
                value = String.Concat(Char.ToUpperInvariant(value[0]), value.Substring(1));
            }

            return value;
        }

        private static string GetDocumentationFromAnnotation(XElement xAnnotation, string prefix = null)
        {
            // TODO: handle embedded HTML
            var doc = xAnnotation?.Element(DocumentationElement)?.Value ?? String.Empty;

            // Join split lines else Markdown tables go crazy.
            var lines = doc.Split('\n');
            doc = String.Join(" ", lines.Select(line => line.Trim())).Trim();

            return String.IsNullOrWhiteSpace(doc) ? String.Empty : (prefix ?? String.Empty) + doc;
        }

        private string GetAttributeType(XElement xAttribute)
        {
            var type = xAttribute.Attribute("type")?.Value;
            return type switch
            {
                "xs:string" => "String",
                "xs:integer" => "Integer",
                _ => type,
            };
        }

        private static string GetDeprecation(XElement xAnnotation, string type)
        {
            string deprecation = null;

            var xDeprecated = xAnnotation?.Element(AppInfoElement)?.Element(DeprecatedElement);
            if (xDeprecated != null)
            {
                deprecation = "Deprecated";

                var replacement = xDeprecated.Attribute("ref")?.Value;
                if (!String.IsNullOrEmpty(replacement))
                {
                    deprecation += $": Use the {replacement} {type} instead.";
                }
            }

            return deprecation;
        }

        private static string ParseInnerText(XElement element)
        {
            if (element == null)
            {
                return null;
            }

            using var reader = element.CreateReader();

            reader.MoveToContent();
            var content = reader.ReadInnerXml();

            if (String.IsNullOrEmpty(content))
            {
                return content;
            }

            content = TrimConsistentLeadingWhitespaceOnLines(content);

            content = content.Replace(" xmlns:html=\"http://www.w3.org/1999/xhtml\"", String.Empty);

            content = content.Replace("html:", String.Empty);

            return content;
        }

        private static string TrimConsistentLeadingWhitespaceOnLines(string content)
        {
            // Chop off a leading line ending, if present.
            //
            var lineEnding = "\r\n";
            if (content.StartsWith("\r\n", StringComparison.Ordinal))
            {
                content = content.Substring(2);
            }
            else if (content.StartsWith("\r", StringComparison.Ordinal) || content.StartsWith("\n", StringComparison.Ordinal))
            {
                lineEnding = content.Substring(0, 1);
                content = content.Substring(1);
            }

            // Count leading spaces of first line.
            //
            var leadingCount = 0;
            for (; leadingCount < content.Length && content[leadingCount] == ' '; ++leadingCount)
            {
            }

            // If there are leading spaces, trim them from each line.
            //
            if (leadingCount > 0)
            {
                var leadingSpaces = new string(' ', leadingCount);
                var lines = content.Split(lineEnding);

                var allLeading = true;

                // First verify that all lines start with the expected
                // amount of leading spaces.
                //
                foreach (var line in lines)
                {
                    if (!String.IsNullOrWhiteSpace(line) && !line.StartsWith(leadingSpaces, StringComparison.Ordinal))
                    {
                        allLeading = false;
                        break;
                    }
                }

                // If all the lines have the expected count of leading spaces, trim them.
                //
                if (allLeading)
                {
                    for (var i = 0; i < lines.Length; ++i)
                    {
                        lines[i] = String.IsNullOrWhiteSpace(lines[i]) ? String.Empty : lines[i].Substring(leadingCount);
                    }
                }

                content = String.Join(lineEnding, lines);
            }

            return content;
        }
    }

    [DebuggerDisplay("Name={Name,nq}")]
    public class Element
    {
        public string Name { get; }
        public string Namespace { get; }
        public string Documentation { get; }
        public string Remarks { get; set; }
        public IEnumerable<MsiRef> MsiRefs { get; set; }
        public IDictionary<string, Parent> Parents { get; set; }
        public IDictionary<string, Child> Children { get; }
        public IDictionary<string, Attribute> Attributes { get; set; }
        public IEnumerable<Element> SeeAlsos { get; set; }

        public Element(string name, string @namespace)
        {
            this.Name = name;
            this.Namespace = @namespace;
        }

        public Element(string name, string @namespace, string documentation, string remarks, IEnumerable<Attribute> attributes, IEnumerable<Parent> parents, IEnumerable<Child> children, IEnumerable<MsiRef> msiRefs, IEnumerable<Element> seeAlsos)
        {
            this.Name = name;
            this.Namespace = @namespace;
            this.Documentation = documentation;
            this.Remarks = remarks;
            this.Attributes = attributes?.ToDictionary(x => x.Name) ?? new Dictionary<string, Attribute>();
            this.Parents = parents?.ToDictionary(x => x.Name) ?? new Dictionary<string, Parent>();
            this.Children = children?.ToDictionary(x => x.Name) ?? new Dictionary<string, Child>();
            this.MsiRefs = msiRefs;
            this.SeeAlsos = seeAlsos;
        }
    }

    [DebuggerDisplay("Name={Name,nq} Type={Type,nq} Required={Required,nq}")]
    public class Attribute
    {
        public string Name { get; }
        public string Description { get; }
        public string Type { get; }
        public string TypeDocumentation { get; }
        public bool Required { get; }
        public IEnumerable<EnumValue> EnumValues { get; set; }
        public IEnumerable<Parent> Parents { get; set; }

        public Attribute(string name, string description, string type, string typeDocumentation, bool required, IEnumerable<EnumValue> enumValues, IEnumerable<Parent> parents)
        {
            this.Name = name;
            this.Description = description;
            this.Type = type;
            this.TypeDocumentation = typeDocumentation;
            this.Required = required;
            this.EnumValues = enumValues;
            this.Parents = parents;
        }
    }

    [DebuggerDisplay("Name={Name,nq}")]
    public class SimpleType
    {
        public string Name { get; }
        public string Documentation { get; }
        public IEnumerable<EnumValue> EnumValues { get; }

        public SimpleType(string name, string documentation, IEnumerable<EnumValue> enumValues)
        {
            this.Name = name;
            this.Documentation = documentation;
            this.EnumValues = enumValues;
        }
    }

    [DebuggerDisplay("Name={Name,nq}")]
    public class EnumValue
    {
        public string Name { get; }
        public string Documentation { get; }

        public EnumValue(string name, string documentation)
        {
            this.Name = name;
            this.Documentation = documentation;
        }
    }

    [DebuggerDisplay("Action={Action,nq} Table={Table,nq}")]
    public class MsiRef
    {
        public string Action { get; }
        public string Table { get; }

        public MsiRef(string action, string table)
        {
            this.Action = action;
            this.Table = table;
        }
    }

    [DebuggerDisplay("Name={Name,nq} Namespace={Namespace,nq}")]
    public class Parent
    {
        public string Namespace { get; }
        public string Name { get; }

        public Parent(string @namespace, string element)
        {
            this.Namespace = @namespace;
            this.Name = element;
        }
    }

    [DebuggerDisplay("Name={Name,nq} '{Cardinality,nq}'")]
    public class Child
    {
        public string Namespace { get; }
        public string Name { get; }
        public string Documentation { get; }
        public string Cardinality { get; }

        public Child(string @namespace, string name, string documentation, string cardinality)
        {
            this.Namespace = @namespace;
            this.Name = name;
            this.Documentation = documentation;
            this.Cardinality = cardinality;
        }
    }
}
