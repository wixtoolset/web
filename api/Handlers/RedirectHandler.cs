namespace WixToolset.Web.Api.Handlers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Web.Configuration;
    using Newtonsoft.Json;
    using TinyWebStack;

    [Route("bugs")]
    [Route("documentation/tutorial")]
    [Route("documentation/book")]
    [Route("documentation/stackoverflow")]
    [Route("img/{*RedirectPath}")]
    [Route("redirect/{*RedirectPath}")]
    public class RedirectHandler : IGet
    {
        private static List<Redirect> Redirects;

        public string RedirectPath { private get; set; }

        public IRequest Request { private get; set; }

        public IServerUtility ServerUtility { private get; set; }

        public Status Get()
        {
            List<Redirect> redirects = this.ReadRedirects();

            var req = this.Request.Url.AbsolutePath.TrimEnd('/').ToLowerInvariant();

            var redirect = redirects.Where(r => req.EndsWith(r.From)).FirstOrDefault() ?? Redirect.Default;

            var permanent = !String.IsNullOrEmpty(this.RedirectPath) && !String.IsNullOrEmpty(redirect.From);

            return permanent ? Status.MovedPermanentlyTo(redirect.To) : Status.FoundAt(redirect.To);
        }

        private List<Redirect> ReadRedirects()
        {
            if (RedirectHandler.Redirects == null)
            {
                var path = WebConfigurationManager.AppSettings["redirects"] ?? "~/App_Data/redirects.json";

                path = this.ServerUtility.MapPath(path);

                var redirects = new List<Redirect>();

                using (var file = File.OpenText(path))
                using (var reader = new JsonTextReader(file))
                {
                    string from = null;
                    while (reader.Read())
                    {
                        if (reader.TokenType == JsonToken.PropertyName)
                        {
                            from = ((string)reader.Value).ToLowerInvariant();
                        }
                        else if (reader.TokenType == JsonToken.String)
                        {
                            redirects.Add(new Redirect() { From = from, To = ((string)reader.Value).ToLowerInvariant() });
                        }
                    }
                }

                RedirectHandler.Redirects = redirects;
            }

            return RedirectHandler.Redirects;
        }

        [DebuggerDisplay("From = {From}, To = {To}")]
        private class Redirect
        {
            public static Redirect Default = new Redirect() { To = WebConfigurationManager.AppSettings["redirects.notfound"] ?? "/" };

            public string From { get; set; }

            public string To { get; set; }
        }
    }
}
