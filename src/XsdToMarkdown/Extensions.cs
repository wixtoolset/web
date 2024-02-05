// Copyright (c) .NET Foundation and contributors. All rights reserved. Licensed under the Microsoft Reciprocal License. See LICENSE.TXT file in the project root for full license information.

namespace WixBuildTools.XsdToMarkdown;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

public static class Extensions
{
    public static bool IsNullOrEmpty<TSource>(this IEnumerable<TSource> enumerable)
    {
        return enumerable == null || !enumerable.Any();
    }

    public static string GetRichText(this XElement xElement)
    {
        var nodes = xElement?.Nodes()?.ToList();
        if (nodes.IsNullOrEmpty())
        {
            return null;
        }

        var sb = new StringBuilder();

        foreach (var node in nodes)
        {
            switch (node)
            {
                case XText xText:
                    sb.Append(xText.Value.ReduceWhitespace(collapseLines: false));
                    break;

                case XElement xChild:
                {
                    switch (xChild.Name.LocalName)
                    {
                        case "a":
                            // Turn <a> into Markdown links.
                            var href = xChild.Attribute("href")?.Value ?? throw new ArgumentException("Missing @href attribute on <a>.");
                            var text = xChild.Value ?? throw new ArgumentException("Missing inner text on <a>.");
                            sb.Append($" [{text}]({href}) ");
                            break;

                        case "b":
                        case "strong":
                            var bold = xChild.Value ?? throw new ArgumentException("Missing inner text on <b>.");
                            sb.Append($" **{bold}** ");
                            break;

                        case "c":
                        case "code":
                            // Turn <c> and <code> into Markdown code spans.
                            var code = xChild.Value ?? throw new ArgumentException("Missing inner text on <code>.");
                            sb.Append($" `{code}` ");
                            break;

                        case "i":
                            var ital = xChild.Value ?? throw new ArgumentException("Missing inner text on <i>.");
                            sb.Append($" _{ital}_ ");
                            break;

                        case "p":
                        case "para":
                            // Turn <p> into Markdown paragraphs.
                            sb.AppendLine(GetRichText(xChild));
                            sb.AppendLine();
                            break;

                        case "paramref":
                        case "paramRef":
                            // Turn <paramref> into Markdown italics.
                            var param = xChild.Attribute("name")?.Value ?? throw new ArgumentException("Missing @name attribute on <paramref>.");
                            sb.Append($" _{param}_ ");
                            break;

                        case "listheader":
                            // Not doing tables today. Someone who wants table support could add them here.
                            break;

                        case "ol":
                        case "ul":
                        case "list":
                            // <ul> and <list> get a newline and then wrap <li> and <item>.
                            sb.AppendLine();
                            sb.AppendLine(GetRichText(xChild).ReduceWhitespace());
                            break;

                        case "li":
                        case "item":
                            // Turn <li> and <item> into Markdown bullets.
                            sb.AppendLine($"- {GetRichText(xChild)}");
                            break;

                        case "description":
                            // <description> is sometimes used as a child of <item> so
                            // get the text and pass it back up the chain to <item>.
                            sb.Append(GetRichText(xChild).ReduceWhitespace());
                            break;

                        case "term":
                            // <term> is sometimes used as a child of <item> to build tables
                            // so get the text and pass it back up the chain to <item>.
                            sb.Append($"{GetRichText(xChild).ReduceWhitespace()}: ");
                            break;

                        case "see":
                            // We can't create these links at this layer, sadly, so turn them into
                            // easily-parsable strings for ConvertDocXmlToMarkdownCommand (TODO).
                            var cref = xChild.Attribute("cref")?.Value ?? throw new ArgumentException("Missing @cref attribute on <see>.");
                            sb.Append($" «see {cref}» ");
                            break;

                        default:
                            throw new ArgumentException($"Unsupported XML doc child element '{xChild.Name.LocalName}'");
                    }

                    break;
                }

                case XComment:
                    break;

                default:
                    throw new ArgumentException($"Unsupported XML node type '{node.NodeType}'");
            }
        }

        return sb.ToString();
    }

    public static string ReduceWhitespace(this string value, bool collapseLines = false)
    {
        if (value is not null)
        {
            value = value.Trim().ReplaceLineEndings();
            var oldValue = value;

            while (true)
            {
                value = value.Replace("  ", " ");
                value = value.Replace('\t', ' ');

                if (collapseLines)
                {
                    value = value.Replace(Environment.NewLine, " ");
                }

                if (oldValue == value)
                {
                    break;
                }

                oldValue = value;
            }

            value = value.Replace("<", "{'<'}").Replace(">", "{'>'}");
        }

        return value;
    }

    public static string ToNonautohyperlinkingURI(this string uri)
    {
        // Namespace URIs just _look_ like URLs but they really aren't.
        // This prevents MDX autohyperlinking.

        return uri.Replace("://", "&#58;//");
    }
}
