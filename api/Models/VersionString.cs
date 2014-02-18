namespace WixToolset.Web.Api.Models
{
    using System;

    public class VersionString
    {
        public VersionString(string versionString)
        {
            if (String.IsNullOrEmpty(versionString))
            {
                throw new FormatException();
            }
            else if (versionString.StartsWith("v", StringComparison.OrdinalIgnoreCase))
            {
                versionString = versionString.Substring(1);
            }

            versionString = versionString.Replace('-', '.'); // support the dashed form of a version

            Version version = new Version(versionString);
            this.Prefixed = String.Concat("v", version);
            this.PrefixedDashed = this.Prefixed.Replace('.', '-');
            this.Nonprefixed = version.ToString();
            this.NonprefixedDashed = this.Nonprefixed.Replace('.', '-');
        }

        public string Prefixed { get; private set; }

        public string PrefixedDashed { get; private set; }

        public string Nonprefixed { get; private set; }

        public string NonprefixedDashed { get; private set; }
    }
}
