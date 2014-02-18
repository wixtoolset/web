namespace WixToolset.Web.Api
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Configuration;
    using Newtonsoft.Json;

    public class RedirectHandler : IHttpHandler
    {
        private static List<Redirect> Redirects;

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            List<Redirect> redirects = RedirectHandler.ReadRedirects(context);
            string req = context.Request.Url.AbsolutePath.TrimEnd('/').ToLowerInvariant();

            Redirect redirect = redirects.Where(r => req.EndsWith(r.From)).FirstOrDefault() ?? Redirect.Default;
            Go(context, redirect.To, req.StartsWith("/redirect/") && !String.IsNullOrEmpty(redirect.From));
        }

        public static List<Redirect> ReadRedirects(HttpContext context)
        {
            if (RedirectHandler.Redirects == null)
            {
                string path = WebConfigurationManager.AppSettings["redirects"] ?? "~/App_Data/redirects.json";
                path = context.Server.MapPath(path);

                List<Redirect> newRedirects = new List<Redirect>();

                using (TextReader file = File.OpenText(path))
                using (JsonTextReader reader = new JsonTextReader(file))
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
                            newRedirects.Add(new Redirect() { From = from, To = ((string)reader.Value).ToLowerInvariant() });
                        }
                    }
                }

                RedirectHandler.Redirects = newRedirects;
            }

            return RedirectHandler.Redirects;
        }

        public static void Go(HttpContext context, string to, bool permanent)
        {
            if (permanent)
            {
                context.Response.RedirectPermanent(to, false);
            }
            else
            {
                context.Response.Redirect(to, false);
            }
            context.ApplicationInstance.CompleteRequest();
        }

        [DebuggerDisplay("From = {From}, To = {To}")]
        public class Redirect
        {
            public static Redirect Default = new Redirect() { To = WebConfigurationManager.AppSettings["redirects.notfound"] ?? "/" };

            public string From { get; set; }
            public string To { get; set; }
        }
    }
}
