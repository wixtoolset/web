namespace WixToolset.Web.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class Release
    {
        public string Id { get; set; }

        public DateTime Date { get; set; }

        public bool Downloadable { get; set; }

        public List<ReleaseFile> Files { get; set; }

        public string[] Roots { get; set; }

        public static Release Load(string path)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new IsoDateTimeConverter());

            using (StreamReader reader = new StreamReader(path))
            using (JsonTextReader json = new JsonTextReader(reader))
            {
                Release release = serializer.Deserialize<Release>(json);
                return release;
            }
        }
    }
}
