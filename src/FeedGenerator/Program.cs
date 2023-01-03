// Copyright (c) .NET Foundation and contributors. All rights reserved. Licensed under the Microsoft Reciprocal License. See LICENSE.TXT file in the project root for full license information.

namespace WixBuildTools.FeedGenerator
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using Octokit;

    public sealed class Program
    {
        private static readonly XNamespace AtomFeed = "http://www.w3.org/2005/Atom";
        private static readonly XNamespace AppSyn = "http://appsyndication.org/2006/appsyn";

        private static readonly JsonSerializerOptions SerializerOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            WriteIndented = true,
            Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) },
        };

        public async static Task<int> Main(string[] args)
        {
            try
            {
                if (args.Length < 4)
                {
                    Console.WriteLine("Provide <name.metadata.json> <version-prefix> <feed-template> <output-folder>");
                    return -1;
                }

                var metadataAssetName = args[0];
                var versionPrefix = args[1];
                var feedTemplate = args[2];
                var outputFolder = Path.GetFullPath(args[3]);
                var token = args.Length > 4 ? args[4] : String.Empty;

                var feed = XDocument.Load(feedTemplate);

                var updatedElement = feed.Root?.Element(AtomFeed + "updated") ?? throw new InvalidDataException("Failed to find 'updated' element.");

                var entries = await GetFeedEntries("wix4", metadataAssetName, versionPrefix, token);

                var firstEntry = entries.FirstOrDefault();

                if (firstEntry is null)
                {
                    return 0;
                }

                updatedElement.Value = firstEntry.Updated.ToString("yyyy-MM-ddTHH:mm:ssZ");

                var prereleaseFeed = new XDocument(feed);

                foreach (var entry in entries)
                {
                    var xEntry = entry.ToElement();

                    if (!entry.Prerelease)
                    {
                        feed.Root.Add(xEntry);
                    }

                    prereleaseFeed.Root!.Add(xEntry);
                }

                var baseFilename = Path.GetFileNameWithoutExtension(feedTemplate);
                var outputPath = Path.Combine(outputFolder, baseFilename + ".feed");
                var prereleaseOutputPath = Path.Combine(outputFolder, baseFilename + "-prerelease.feed");

                UpdateIdAndLink(feed, outputPath);
                UpdateIdAndLink(prereleaseFeed, prereleaseOutputPath);

                Directory.CreateDirectory(outputFolder);

                feed.Save(outputPath, SaveOptions.OmitDuplicateNamespaces);
                prereleaseFeed.Save(prereleaseOutputPath, SaveOptions.OmitDuplicateNamespaces);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 1;
            }

            return 0;
        }

        private static async Task<List<FeedEntry>> GetFeedEntries(string repo, string metadataNamePrefix, string versionPrefix, string token)
        {
            var entries = new List<FeedEntry>();

            var client = new GitHubClient(new ProductHeaderValue("wix-feedgenerator"));
            if (!String.IsNullOrEmpty(token))
            {
                client.Credentials = new Credentials(token);
            };

            var releases = await client.Repository.Release.GetAll("wixtoolset", repo);
            var map = new Dictionary<string, ReleaseAssetMapping>();

            foreach (var release in releases)
            {
                var assets = await client.Repository.Release.GetAllAssets("wixtoolset", repo, release.Id);

                foreach (var asset in assets)
                {
                    var mapping = new ReleaseAssetMapping(release, asset);

                    map.Add(mapping.Key, mapping);
                }
            }

            var http = new HttpClient();

            foreach (var metadataMapping in map.Values.Where(m => m.IsMetadata && m.Asset.Name.StartsWith(metadataNamePrefix, StringComparison.OrdinalIgnoreCase)))
            {
                var json = await http.GetStringAsync(metadataMapping.Asset.BrowserDownloadUrl);

                var metadata = JsonSerializer.Deserialize<Metadata>(json, SerializerOptions)!;

                var binaryMapping = map[String.Concat(metadataMapping.Release.Id, ":", metadata.File)];

                if (!metadata.Version.StartsWith(versionPrefix, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                var entry = new FeedEntry(
                    binaryMapping.Release.HtmlUrl,
                    String.Concat(metadata.Description, " v", metadata.Version),
                    binaryMapping.Release.HtmlUrl,
                    binaryMapping.Asset.BrowserDownloadUrl,
                    "application/octet-stream",
                    metadata.Size,
                    metadata.Sha256,
                    metadata.Version,
                    DateTime.Parse(metadata.Created),
                    metadata.Type == MetadataType.Burn ? "burn" : "msi",
                    metadata.Type == MetadataType.Burn ? metadata.BundleCode.Trim('{', '}') : metadata.ProductCode.Trim('{', '}'),
                    metadata.UpgradeCode.Trim('{', '}'),
                    !Version.TryParse(metadata.Version, out _)
                    );

                entries.Add(entry);
            }

            return entries.OrderByDescending(e => e.Updated).ToList();
        }

        private static void UpdateIdAndLink(XDocument doc, string outputPath)
        {
            var idElement = doc.Root?.Element(AtomFeed + "id") ?? throw new InvalidDataException("Failed to find 'id' element.");
            var linkHrefElement = doc.Root?.Element(AtomFeed + "link")?.Attribute("href") ?? throw new InvalidDataException("Failed to find 'link' with 'href' element.");

            var uriBuilder = new UriBuilder(idElement.Value);
            uriBuilder.Path = Path.Combine(Path.GetDirectoryName(uriBuilder.Path) ?? String.Empty, Path.GetFileName(outputPath));

            idElement.Value = uriBuilder.Uri.AbsoluteUri;
            linkHrefElement.Value = uriBuilder.Uri.AbsoluteUri;
        }
    }
}
