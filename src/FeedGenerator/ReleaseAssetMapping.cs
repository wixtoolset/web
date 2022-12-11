// Copyright (c) .NET Foundation and contributors. All rights reserved. Licensed under the Microsoft Reciprocal License. See LICENSE.TXT file in the project root for full license information.

namespace WixBuildTools.FeedGenerator
{
    using System;
    using Octokit;

    public record ReleaseAssetMapping(
        Release Release,
        ReleaseAsset Asset
        )
    {
        public string Key => this.Release.Id + ":" + this.Asset.Name;

        public bool IsMetadata => this.Asset.Name.EndsWith(".metadata.json", StringComparison.OrdinalIgnoreCase);
    }
}
