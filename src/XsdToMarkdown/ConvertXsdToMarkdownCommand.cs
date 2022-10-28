// Copyright (c) .NET Foundation and contributors. All rights reserved. Licensed under the Microsoft Reciprocal License. See LICENSE.TXT file in the project root for full license information.

namespace WixBuildTools.XsdToMarkdown
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    // todo: handle embedded HTML: convert xsd html to markdown?

    public class ConvertXsdToMarkdownCommand
    {
        public Xsd Xsd { get; private set; }

        public static Page WriteReferenceRoot(IEnumerable<Xsd> xsds)
        {
            var content = new List<string>
            {
                "---",
                "sidebar_position: 99",
                "custom_edit_url: null",
                "---",
                "",
                "# Schema reference",
                "",
            };

            foreach (var xsd in xsds)
            {
                content.Add($"- [{xsd.SchemaName} schema]({xsd.SchemaName.ToLowerInvariant()}/)");
            }

            return new Page("index", content);
        }

        public IEnumerable<Page> Convert(int order, Xsd xsd)
        {
            this.Xsd = xsd;

            var inPageOrder = 1;
            var pages = new List<Page>() { this.GenerateSchemaRootPage(order) };
            pages.AddRange(xsd.Elements.Values.OrderBy(el => el.Name).Select(el => this.ElementDocumentation(el, inPageOrder++)));
            pages.AddRange(xsd.SimpleTypes.Values.OrderBy(t => t.Name).Select(t => this.SimpleTypeDocumentation(t, inPageOrder++)));

            return pages;
        }

        private string PageId(PageType type, string name = null)
        {
            return type switch
            {
                PageType.SchemaRoot => $"{this.Xsd.SchemaName}/index".ToLowerInvariant(),
                PageType.Element => $"{this.Xsd.SchemaName}/{name}".ToLowerInvariant(),
                PageType.Type => $"{this.Xsd.SchemaName}/{name}".ToLowerInvariant(),
                _ => throw new ArgumentOutOfRangeException(),
            };
        }

        private Page GenerateSchemaRootPage(int order)
        {
            var content = new List<string>
            {
                "---",
                "custom_edit_url: null",
                $"sidebar_position: {order}",
                "---",
                $"# {this.Xsd.SchemaName} schema",
                this.Xsd.SchemaDocumentation,
                "## Target namespace",
                this.Xsd.TargetNamespace
            };

            if (this.Xsd.RootElements.Any())
            {
                content.Add("## Root elements");
                content.AddRange(this.Xsd.RootElements.OrderBy(el => el.Name).Select(el => $"- [{el.Name}]({this.LinkForElement(PageType.SchemaRoot, el.Namespace, el.Name)})"));
            }

            content.Add("## Elements");
            content.AddRange(this.Xsd.Elements.Values.OrderBy(el => el.Name).Select(el => $"- [{el.Name}]({this.LinkForElement(PageType.SchemaRoot, el.Namespace, el.Name)})"));

            if (this.Xsd.SimpleTypes.Any())
            {
                content.Add("## Types");
                content.AddRange(this.Xsd.SimpleTypes.Values.OrderBy(t => t.Name).Select(t => $"- [{t.Name}]({this.LinkForType(PageType.SchemaRoot, t.Name)})"));
            }

            return new Page(this.PageId(PageType.SchemaRoot), content);
        }

        private Page ElementDocumentation(Element element, int order)
        {
            var title = this.Xsd.IsMainSchema switch
            {
                true => $"{element.Name} element",
                false => $"{element.Name} element ({this.Xsd.SchemaName} extension)",
            };

            var content = new List<string>()
            {
                "---",
                "custom_edit_url: null",
                $"sidebar_position: {order}",
                "---",
                $"# {title}",
                element.Documentation,
            };

            if (!element.MsiRefs.IsNullOrEmpty())
            {
                content.Add(String.Empty);
                content.Add("## Windows Installer references");
                content.Add(String.Join(", ", element.MsiRefs.SelectMany(msiRef => FormatMsiRefElement(msiRef))));
            }

            // todo: how-to refs

            if (!element.Parents.IsNullOrEmpty())
            {
                content.Add(String.Empty);
                content.Add("## Parents");
                content.Add(String.Join(", ", element.Parents.Values.Select(parent => this.FormatParentElement(parent))));
            }

            if (!element.Children.IsNullOrEmpty())
            {
                content.Add(String.Empty);
                content.Add("## Children");
                content.AddRange(element.Children.Values.OrderBy(child => child.Name).Select(child => this.FormatChildElement(child)));
            }

            if (!String.IsNullOrEmpty(element.Remarks))
            {
                content.Add(String.Empty);
                content.Add("## Remarks");
                content.Add(element.Remarks);
            }

            // attributes
            if (element.Attributes.Any())
            {
                content.Add(String.Empty);
                content.Add("## Attributes");

                foreach (var attribute in element.Attributes.Values)
                {
                    var required = attribute.Required ? ", required" : String.Empty /*", optional" default*/;

                    if (attribute.EnumValues?.Any() == true)
                    {
                        content.Add($"**{attribute.Name}** (enumeration{required})");
                        content.Add($"  : {attribute.Description} This attribute's value must be one of the following:");
                        content.AddRange(EnumValuesDocumentation(attribute.EnumValues));
                    }
                    else
                    {
                        if (String.IsNullOrEmpty(attribute.TypeDocumentation))
                        {
                            content.Add($"**{attribute.Name}** ({attribute.Type}{required})");
                        }
                        else
                        {
                            content.Add($"**{attribute.Name}** ([{attribute.Type}]({this.LinkForType(PageType.Element, attribute.Type)} '{attribute.TypeDocumentation}'){required})");
                        }
                        content.Add($"  : {attribute.Description}");
                    }

                    content.Add(String.Empty);
                }
            }

            // see also
            if (!element.SeeAlsos.IsNullOrEmpty())
            {
                content.Add(String.Empty);
                content.Add("## See also");
                content.Add(String.Join(", ", element.SeeAlsos.Select(seeAlso => this.FormatSeeAlsoElement(seeAlso))));
            }

            return new Page(this.PageId(PageType.Element, element.Name), content);
        }

        private Page SimpleTypeDocumentation(SimpleType simpleType, int order)
        {
            var title = this.Xsd.IsMainSchema switch
            {
                true => $"{simpleType.Name} type",
                false => $"{simpleType.Name} type ({this.Xsd.SchemaName} extension)",
            };

            var content = new List<string>()
            {
                "---",
                "custom_edit_url: null",
                $"sidebar_position: {order}",
                "---",
                $"# {title}",
                simpleType.Documentation,
            };

            if (simpleType.EnumValues?.Any() == true)
            {
                content.Add(String.Empty);
                content.Add("## Enumeration values");
                content.AddRange(EnumValuesDocumentation(simpleType.EnumValues));
            }

            return new Page(this.PageId(PageType.Type, simpleType.Name), content);
        }

        private static IEnumerable<string> EnumValuesDocumentation(IEnumerable<EnumValue> enumValues)
        {
            foreach (var enumValue in enumValues)
            {
                if (String.IsNullOrEmpty(enumValue.Documentation))
                {
                    yield return $"- *{enumValue.Name}*";
                }
                else
                {
                    yield return $"- *{enumValue.Name}*: {enumValue.Documentation}";
                }
            }
        }

        private string FormatChildElement(Child child)
        {
            var extension = child.Namespace == this.Xsd.TargetNamespace ? String.Empty : $" ({Xsd.GetSchemaNameFromNamespace(child.Namespace)} extension)";
            return $"* [{child.Name}{extension}]({this.LinkForElement(PageType.Element, child.Namespace, child.Name)}) {child.Cardinality}{child.Documentation}";
        }

        private string FormatParentElement(Parent parent) => $"[{parent.Name}]({this.LinkForElement(PageType.Element, parent.Namespace, parent.Name)})";

        private string FormatSeeAlsoElement(Element seeAlso) => $"[{seeAlso.Name}]({this.LinkForElement(PageType.Element, seeAlso.Namespace, seeAlso.Name)})";

        private static IEnumerable<string> FormatMsiRefElement(MsiRef msiRef)
        {
            if (!String.IsNullOrEmpty(msiRef.Action))
            {
                yield return $"[{msiRef.Action} Action](https://docs.microsoft.com/en-us/windows/win32/msi/{msiRef.Action.ToLowerInvariant()}-action)";
            }

            if (!String.IsNullOrEmpty(msiRef.Table))
            {
                yield return $"[{msiRef.Table} Table](https://docs.microsoft.com/en-us/windows/win32/msi/{msiRef.Table.ToLowerInvariant()}-table)";
            }
        }

        private string RelativeLinkForPage(PageType sourcePageType, PageType destinationPageType, string targetNamespace = null, string name = null)
        {
            var namespaceId = targetNamespace == this.Xsd.TargetNamespace || targetNamespace == null ? null : Xsd.GetSchemaNameFromNamespace(targetNamespace);

            var link = (sourcePageType, destinationPageType, !String.IsNullOrEmpty(namespaceId)) switch
            {
                (PageType.SchemaRoot, PageType.SchemaRoot, true) => $"../{namespaceId}.md",
                (PageType.SchemaRoot, PageType.SchemaRoot, false) => throw new ArgumentOutOfRangeException(),
                (PageType.SchemaRoot, PageType.Element, true) => $"../{namespaceId}/{name}.md",
                (PageType.SchemaRoot, PageType.Element, false) => $"{name}.md",
                (PageType.SchemaRoot, PageType.Type, true) => $"../{namespaceId}/{name}.md",
                (PageType.SchemaRoot, PageType.Type, false) => $"{name}.md",

                (PageType.Element, PageType.SchemaRoot, true) => $"../{namespaceId}.md",
                (PageType.Element, PageType.SchemaRoot, false) => throw new ArgumentOutOfRangeException(),
                (PageType.Element, PageType.Element, true) => $"../{namespaceId}/{name}.md",
                (PageType.Element, PageType.Element, false) => $"{name}.md",
                (PageType.Element, PageType.Type, true) => throw new ArgumentOutOfRangeException(),
                (PageType.Element, PageType.Type, false) => $"{name}.md",

                (PageType.Type, PageType.SchemaRoot, true) => $"../{namespaceId}.md",
                (PageType.Type, PageType.SchemaRoot, false) => throw new ArgumentOutOfRangeException(),
                (PageType.Type, PageType.Element, true) => $"../{namespaceId}/{name}.md",
                (PageType.Type, PageType.Element, false) => $"{name}.md",
                (PageType.Type, PageType.Type, true) => throw new ArgumentOutOfRangeException(),
                (PageType.Type, PageType.Type, false) => $"{name}.md",

                _ => throw new NotImplementedException(),
            };

            return link.ToLowerInvariant();
        }

        private string LinkForElement(PageType sourcePageType, string targetNamespace, string elementName)
        {
            return this.RelativeLinkForPage(sourcePageType, PageType.Element, targetNamespace, elementName);
        }

        private string LinkForType(PageType sourcePageType, string typeName)
        {
            return $"{this.RelativeLinkForPage(sourcePageType, PageType.Type, targetNamespace: null, typeName.EndsWith("TypeUnion") ? typeName.Replace("TypeUnion", "Type") : typeName)}";
        }
    }

    public static class Extensions
    {
        public static bool IsNullOrEmpty<TSource>(this IEnumerable<TSource> enumerable)
        {
            return enumerable == null || !enumerable.Any();
        }
    }
}
