// Copyright (c) .NET Foundation and contributors. All rights reserved. Licensed under the Microsoft Reciprocal License. See LICENSE.TXT file in the project root for full license information.

namespace WixBuildTools.XmlDocToMarkdown;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using static WixBuildTools.XmlDocToMarkdown.DocXml;

public sealed class Program
{
    public static int Main(string[] args)
    {
        if (!CommandLine.TryParseArguments(args, out var commandLine))
        {
            CommandLine.ShowHelp();
            return 1;
        }

        // TODO
        // - Create links
        //   - Handle `see` inline elements.
        //   - Handle `seealso` elements.
        // - Handle generic types.
        // - Handle nested types.
        // - Handle out/ref parameters.
        // - Handle overloaded operators.
        // - Wrap namespace names.

        // Load 'em up.
        Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: Processing {commandLine.Files.Count} doc files");
        var docs = commandLine.Files.Select(path => DocXml.Parse(XDocument.Load(path), Assembly.LoadFrom(Path.ChangeExtension(path, ".dll")))).ToList();

        // Find 'eir namespaces.
        var allTypes = docs.SelectMany(doc => doc.Types).OrderBy(t => t.Name).ToList();
        var typesByNamespace = GetTypesByNamespace(allTypes);

        // Convert 'em to Markdown.
        Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: Converting to Markdown");
        var converter = new ConvertDocXmlToMarkdownCommand(commandLine.Title ?? "API", typesByNamespace);
        var pages = converter.Convert();

        Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: Writing Markdown files");
        foreach (var page in pages)
        {
            var markdownPath = Path.Combine(commandLine.OutputFolder, page.Id) + ".md";
            Directory.CreateDirectory(Path.GetDirectoryName(markdownPath));

            File.WriteAllLines(markdownPath, page.Content);
        }

        Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: Run complete. Wrote {pages.Count()} Markdown pages");

        return 0;
    }

    private static IDictionary<string, ICollection<DocType>> GetTypesByNamespace(IEnumerable<DocType> types)
    {
        var namespaces = new Dictionary<string, ICollection<DocType>>();
        //var namespaces = new SortedDictionary<string, ICollection<DocType>>();

        foreach (var type in types)
        {
            if (namespaces.TryGetValue(type.Namespace, out var namespaceTypes))
            {
                namespaceTypes.Add(type);
            }
            else
            {
                namespaces.Add(type.Namespace, new List<DocType>() { type });
            }
        }

        return namespaces;
    }
}
