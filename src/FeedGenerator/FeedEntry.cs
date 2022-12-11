// Copyright (c) .NET Foundation and contributors. All rights reserved. Licensed under the Microsoft Reciprocal License. See LICENSE.TXT file in the project root for full license information.

namespace WixBuildTools.FeedGenerator
{
    using System;
    using System.Xml.Linq;

    public record FeedEntry(
        string Id,
        string Title,
        string ContentUrl,
        string DownloadUrl,
        string ContentType,
        long Size,
        string Sha256,
        string Version,
        DateTime Updated,
        string EntryType,
        string Code,
        string UpgradeCode,
        bool Prerelease
        )
    {
        private static readonly XNamespace AtomFeed = "http://www.w3.org/2005/Atom";
        private static readonly XNamespace AppSyn = "http://appsyndication.org/2006/appsyn";

        public XElement ToElement()
        {
            var entry = this;

            var xElement = new XElement(AtomFeed + "entry",
                new XElement(AtomFeed + "title", entry.Title),
                new XElement(AtomFeed + "id", entry.Id),
                new XElement(AtomFeed + "link",
                    new XAttribute("rel", "alternate"),
                    new XAttribute("href", entry.ContentUrl)
                    ),
                new XElement(AtomFeed + "link",
                    new XAttribute("rel", "enclosure"),
                    new XAttribute("href", entry.DownloadUrl),
                    new XAttribute("length", entry.Size),
                    new XAttribute("type", entry.ContentType),
                    String.IsNullOrEmpty(entry.Sha256) ? null :
                        new XElement(AppSyn + "digest",
                        new XAttribute("algorithm", "sha256"),
                        entry.Sha256
                        )
                    ),
                new XElement(AppSyn + "application",
                    new XAttribute("type", entry.EntryType),
                    entry.Code
                    ),
                new XElement(AppSyn + "upgrade", entry.UpgradeCode),
                new XElement(AppSyn + "version", entry.Version),
                new XElement(AtomFeed + "updated", entry.Updated.ToString("yyyy-MM-ddTHH:mm:ssZ"))
                );

            return xElement;
        }
    }
}
