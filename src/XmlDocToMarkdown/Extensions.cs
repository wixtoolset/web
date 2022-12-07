namespace WixBuildTools.XmlDocToMarkdown;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

public static class Extensions
{
    public static bool IsNullOrEmpty<TSource>(this IEnumerable<TSource> enumerable)
    {
        return enumerable == null || !enumerable.Any();
    }

    public static string SimplifyTypeName(this string value, string namespac = null)
    {
        // Simplify types within the namespace (if specified).
        if (namespac is not null && value.StartsWith(namespac))
        {
            value = value[(namespac.Length + 1)..];
        }

        // Prettify generics.
        var backtick = value.IndexOf('`');

        if (backtick >= 0)
        {
            value = value.Replace('[', '<').Replace(']', '>');
            value = value[..backtick] + value[(backtick + 2)..];

            // TODO: Recursively simplify the type types.
        }

        value = value.Replace("System.Collections.Generic.IEnumerable", "IEnumerable");
        value = value.Replace("System.Collections.Generic.IEnumerator", "IEnumerator");
        value = value.Replace("System.Collections.Generic.IList", "IList");

        return value switch
        {
            "System.Boolean" => "bool",
            "System.Int32" => "int",
            "System.String" => "string",
            "System.Void" => "void",

            "System.ArgumentOutOfRangeException" => "ArgumentOutOfRangeException",
            "System.Exception" => "Exception",
            "System.EventHandler" => "EventHandler",
            "System.EventArgs" => "EventArgs",

            _ => value,
        };
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
}
