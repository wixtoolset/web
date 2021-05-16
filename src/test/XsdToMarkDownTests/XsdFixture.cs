// Copyright (c) .NET Foundation and contributors. All rights reserved. Licensed under the Microsoft Reciprocal License. See LICENSE.TXT file in the project root for full license information.

namespace XsdToMarkDownTests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using Markdig;
    using WixBuildTools.XsdToMarkdown;
    using Xunit;

    public class XsdFixture
    {
        [Fact]
        public void CommandLineParsingFailsOnMissingFile()
        {
            using var fs = new DisposableFileSystem();
            var output = fs.GetFolder(create: true);
            var folder = TestData.Get(@"TestData");
            var args = new[] { "-out", output, Path.Combine(folder, "wix5.xsd") };
            Assert.False(CommandLine.TryParseArguments(args, out var commandLine));
            Assert.Equal(output, commandLine.OutputFolder);
            Assert.Empty(commandLine.Files);
        }

        [Fact]
        public void CommandLineParsingWorksWell()
        {
            using var fs = new DisposableFileSystem();
            var output = fs.GetFolder(create: true);
            var folder = TestData.Get(@"TestData");
            var args = new[] { "-out", output, Path.Combine(folder, "wix.xsd") };
            Assert.True(CommandLine.TryParseArguments(args, out var commandLine));
            Assert.Equal(output, commandLine.OutputFolder);
            Assert.Single(commandLine.Files);
            Assert.Equal(new[] { Path.Combine(folder, "wix.xsd") }, commandLine.Files.OrderBy(s => s));
        }

        [Fact]
        public void CommandLineParsingHandlesWildcards()
        {
            using var fs = new DisposableFileSystem();
            var output = fs.GetFolder(create: true);
            var folder = TestData.Get(@"TestData");
            var args = new[] { "-out", output, Path.Combine(folder, "*.xsd") };
            Assert.True(CommandLine.TryParseArguments(args, out var commandLine));
            Assert.Equal(output, commandLine.OutputFolder);
            Assert.Equal(3, commandLine.Files.Count);
            Assert.Equal(new[] { Path.Combine(folder, "bal.xsd"), Path.Combine(folder, "util.xsd"), Path.Combine(folder, "wix.xsd") }, commandLine.Files.OrderBy(s => s));
        }

        [Fact]
        public void SpotChecksOnXsdAnalysisLookGood()
        {
            var folder = TestData.Get(@"TestData");
            var document = XDocument.Load(Path.Combine(folder, "wix.xsd"));
            var xsd = new Xsd(document);

            Assert.True(xsd.IsMainSchema);
            Assert.Equal("Wxs", xsd.SchemaName);
            Assert.Equal("http://wixtoolset.org/schemas/v4/wxs", xsd.TargetNamespace);
            Assert.Equal(28, xsd.SimpleTypes.Count());
            Assert.Empty(xsd.RootAttributes);
            Assert.Single(xsd.AttributeGroups);

            Assert.Equal(271, xsd.Elements.Count);

            var componentElement = xsd.Elements["Component"];
            Assert.Equal(17, componentElement.Attributes.Count);
            Assert.Equal(31, componentElement.Children.Count);
            Assert.Equal(3, componentElement.MsiRefs.Count());
            Assert.Equal("Component", componentElement.Name);
            Assert.Equal("http://wixtoolset.org/schemas/v4/wxs", componentElement.Namespace);
            Assert.Empty(componentElement.Parents);
            Assert.Equal(2, componentElement.SeeAlsos.Count());
        }

        [Fact]
        public void SimpleXsdConvertsToMarkdown()
        {
            using var fs = new DisposableFileSystem();
            var output = fs.GetFolder(create: true).Replace('\\', '/');

            var finalizedXsds = GetFinalizedXsds();

            var converter = new ConvertXsdToMarkdownCommand();
            var pages = finalizedXsds.SelectMany(xsd => converter.Convert(xsd)).ToList();

            var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();

            foreach (var page in pages)
            {
                var markdown = String.Join(Environment.NewLine, page.Content);
                var html = Markdown.ToHtml(markdown, pipeline);

                var dir = Path.Combine(output, page.Id);
                Directory.CreateDirectory(dir);

                var mdPath = Path.Combine(dir, "index.md");
                File.WriteAllText(mdPath, markdown);

                var htmlPath = Path.Combine(dir, "index.html");
                File.WriteAllText(htmlPath, html);
            }
        }

        [Fact]
        public void FinalizerFinalizes()
        {
            var finalizedXsds = GetFinalizedXsds();

            var xsd = finalizedXsds.Single(x => "Wxs" == x.SchemaName);

            Assert.True(xsd.IsMainSchema);
            Assert.Equal("Wxs", xsd.SchemaName);
            Assert.Equal("http://wixtoolset.org/schemas/v4/wxs", xsd.TargetNamespace);
            Assert.Equal(28, xsd.SimpleTypes.Count());
            Assert.Empty(xsd.RootAttributes);
            Assert.Single(xsd.AttributeGroups);

            Assert.Equal(271, xsd.Elements.Count);

            var componentElement = xsd.Elements["Component"];
            Assert.Equal(17, componentElement.Attributes.Count);
            Assert.Equal(41, componentElement.Children.Count);
            Assert.Equal(3, componentElement.MsiRefs.Count());
            Assert.Equal("Component", componentElement.Name);
            Assert.Equal("http://wixtoolset.org/schemas/v4/wxs", componentElement.Namespace);
            Assert.Equal(2, componentElement.SeeAlsos.Count());
            Assert.Equal(new[]
            {
                "ComponentGroup",
                "Directory",
                "DirectoryRef",
                "Feature",
                "FeatureGroup",
                "FeatureRef",
                "Fragment",
                "Module",
                "Product",
            }, componentElement.Parents.Values.Select(p => p.Name).OrderBy(p => p));
        }

        private static IEnumerable<Xsd> GetFinalizedXsds()
        {
            var folder = TestData.Get(@"TestData");
            var paths = new[]
            {
                Path.Combine(folder, "bal.xsd"),
                Path.Combine(folder, "wix.xsd"),
                Path.Combine(folder, "util.xsd"),
            };

            var xsds = paths.Select(path => new Xsd(XDocument.Load(path))).ToList();
            return XsdFinalizer.Finalize(xsds);
        }
    }
}
