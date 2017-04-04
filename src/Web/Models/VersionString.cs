// Copyright (c) .NET Foundation and contributors. All rights reserved. Licensed under the Microsoft Reciprocal License. See LICENSE.TXT file in the project root for full license information.

namespace WixToolset.Web.Models
{
    using System;

    public class VersionString
    {
        public VersionString(Version version)
        {
            this.Prefixed = String.Concat("v", version);
            this.PrefixedDashed = this.Prefixed.Replace('.', '-');
            this.Nonprefixed = version.ToString();
            this.NonprefixedDashed = this.Nonprefixed.Replace('.', '-');
        }

        public string Prefixed { get; }

        public string PrefixedDashed { get; }

        public string Nonprefixed { get; }

        public string NonprefixedDashed { get; }

        public static bool TryParse(string version, out VersionString versionString)
        {
            versionString = null;

            if (String.IsNullOrEmpty(version))
            {
                return false;
            }

            if (version.StartsWith("v", StringComparison.OrdinalIgnoreCase))
            {
                version = version.Substring(1);
            }

            version = version.Replace('-', '.'); // support the dashed form of a version

            if (Version.TryParse(version, out var parsed))
            {
                versionString = new VersionString(parsed);
            }

            return versionString != null;
        }
    }
}
