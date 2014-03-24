namespace WixToolset.Web.Api.Models
{
    using System.Collections.Generic;

    public class ReplaceTextInFile
    {
        public ReplaceTextInFile(string path)
        {
            this.Path = path;
            this.Replacements = new Dictionary<string, string>();
        }

        public string Path { get; private set; }

        public IDictionary<string, string> Replacements { get; private set; }
    }
}