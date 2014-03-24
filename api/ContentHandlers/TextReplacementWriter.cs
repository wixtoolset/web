namespace WixToolset.Web.Api.ContentHandlers
{
    using System.IO;
    using TinyWebStack;
    using WixToolset.Web.Api.Models;

    public class TextReplacementWriter : IContentTypeWriter
    {
        public TextReplacementWriter(string contentType)
        {
            this.ContentType = contentType;
        }

        public string ContentType { get; private set; }

        public void Write(TextWriter writer, object data)
        {
            ReplaceTextInFile fileReplacements = data as ReplaceTextInFile;

            var path = Container.Current.Resolve<IServerUtility>().MapPath(fileReplacements.Path);

            using (var stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete))
            using (var reader = new StreamReader(stream))
            {
                var contents = reader.ReadToEnd();
                foreach (var kvp in fileReplacements.Replacements)
                {
                    contents = contents.Replace(kvp.Key, kvp.Value);
                }

                writer.Write(contents);
            }
        }
    }
}
