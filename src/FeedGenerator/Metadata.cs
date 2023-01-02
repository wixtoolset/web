// Copyright (c) .NET Foundation and contributors. All rights reserved. Licensed under the Microsoft Reciprocal License. See LICENSE.TXT file in the project root for full license information.

namespace WixBuildTools.FeedGenerator
{
    using System;

    public enum MetadataType
    {
        Unknown,
        Burn,
        Msi,
    }

    public enum ArchitectureType
    {
        Unknown,
        Arm64,
        X64,
        X86,
    }

    public class Metadata
    {
        public string Id { get; set; } = String.Empty;

        public MetadataType Type { get; set; }

        public string Name { get; set; } = String.Empty;

        public string Version { get; set; } = String.Empty;

        public string Locale { get; set; } = String.Empty;

        public string Publisher { get; set; } = String.Empty;

        public string AboutUrl { get; set; } = String.Empty;

        public string SupportUrl { get; set; } = String.Empty;

        public string Description { get; set; } = String.Empty;

        public string License { get; set; } = String.Empty;

        public ArchitectureType Architecture { get; set; }

        public string File { get; set; } = String.Empty;

        public long Size { get; set; }

        public string Sha256 { get; set; } = String.Empty;

        public string Created { get; set; } = String.Empty;

        public string ProductCode { get; set; } = String.Empty;

        public string BundleCode { get; set; } = String.Empty;

        public string UpgradeCode { get; set; } = String.Empty;
    }
}
