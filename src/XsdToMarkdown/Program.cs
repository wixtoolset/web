// Copyright (c) .NET Foundation and contributors. All rights reserved. Licensed under the Microsoft Reciprocal License. See LICENSE.TXT file in the project root for full license information.

namespace WixBuildTools.XsdToMarkdown
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    public sealed class Program
    {
        public static int Main(string[] args)
        {
            if (!CommandLine.TryParseArguments(args, out var commandLine))
            {
                CommandLine.ShowHelp();
                return 1;
            }

            // Load 'em up.
            var xsds = commandLine.Files.Select(path => new Xsd(XDocument.Load(path, LoadOptions.SetLineInfo | LoadOptions.PreserveWhitespace), path));
            Console.WriteLine($"XsdToMarkdown: Processing {xsds.Count()} XSDs.");

            // Put 'em together... sorted.
            var finalizedXsds = XsdFinalizer.Finalize(xsds).ToList();

            finalizedXsds.Sort(OrderXsds);

            // Convert 'em to Markdown.
            var converter = new ConvertXsdToMarkdownCommand();
            var pages = finalizedXsds.SelectMany((xsd, order) => converter.Convert(order + 1, xsd)).ToList();
            pages.Add(ConvertXsdToMarkdownCommand.WriteReferenceRoot(finalizedXsds));

            foreach (var page in pages)
            {
                var markdown = String.Join(Environment.NewLine, page.Content);
                var mdPath = Path.Combine(commandLine.OutputFolder, page.Id) + ".md";
                var dir = Path.GetDirectoryName(mdPath);
                Directory.CreateDirectory(dir);
                File.WriteAllText(mdPath, markdown);
            }

            Console.WriteLine($"XsdToMarkdown: Wrote {pages.Count()} Markdown pages.");

            return 0;
        }

        /// <summary>
        /// Order so that all wxs schemas are first, wxl second then evertyhing else alphabetical.
        /// </summary>
        private static int OrderXsds(Xsd x, Xsd y)
        {
            var wxsSchemaX = x.TargetNamespace.EndsWith("/wxs");
            var wxsSchemaY = y.TargetNamespace.EndsWith("/wxs");

            if (wxsSchemaX)
            {
                if (wxsSchemaY)
                {
                    return x.TargetNamespace.CompareTo(y.TargetNamespace);
                }
                else
                {
                    return -1;
                }
            }
            else if (wxsSchemaY)
            {
                return 1;
            }

            var wxlSchemaX = x.TargetNamespace.EndsWith("/wxl");
            var wxlSchemaY = y.TargetNamespace.EndsWith("/wxl");

            if (wxlSchemaX)
            {
                if (wxlSchemaY)
                {
                    return x.TargetNamespace.CompareTo(y.TargetNamespace);
                }
                else
                {
                    return -1;
                }
            }
            else if (wxlSchemaY)
            {
                return 1;
            }

            return x.TargetNamespace.CompareTo(y.TargetNamespace);
        }
    }
}
