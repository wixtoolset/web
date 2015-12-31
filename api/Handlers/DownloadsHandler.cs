namespace WixToolset.Web.Api.Handlers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web.Configuration;
    using NLog;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using TinyWebStack;
    using WixToolset.Web.Api.Models;
    using WixToolset.Web.Api.Utilities;

    [Route("downloads/{*DownloadPath}")]
    public class DownloadsHandler : IGet
    {
        private static Logger logger = LogManager.GetLogger("dl");
        private static WebUserService UserService = new WebUserService();

        private static Dictionary<string, string> ReleaseRedirects;

        public string DownloadPath { private get; set; }

        public IServerUtility ServerUtility { private get; set; }

        public Status Head()
        {
            var status = this.RedirectToDownload();

            return status;
        }

        public Status Get()
        {
            var status = this.RedirectToDownload();

            return status;
        }

        private Status RedirectToDownload()
        {
            UserService.CreateAnonymousUser();

            string[] parsed = this.DownloadPath.Split(new char[] { '/' }, 2, StringSplitOptions.RemoveEmptyEntries);
            if (2 != parsed.Length)
            {
                return Status.FoundAt("~/releases/");
            }

            VersionString version;
            string file;
            try
            {
                version = new VersionString(parsed[0]);
                file = parsed[1].Replace("..", String.Empty);
            }
            catch
            {
                return Status.FoundAt("~/releases/");
            }

            // See if there is a version redirect file for the requested release.
            string redirect = null;
            try
            {
                redirect = this.RedirectedRelease(version.Prefixed, file);
            }
            catch
            {
                return Status.NotFound;
            }

            // If redirect was not found, assume we're looking for a file on the download server.
            if (String.IsNullOrEmpty(redirect))
            {
                Visit.CreateFromHttpContext().Log(logger);

                // New static.wixtoolset.org is case sensitive and all files there are lower case.
                redirect = String.Format(Configuration.DownloadServerFormat, version.Prefixed, file).ToLowerInvariant();
            }

            return Status.FoundAt(redirect);
        }

        private string RedirectedRelease(string version, string file)
        {
            var key = String.Concat(version, "/", file).ToLowerInvariant();

            if (DownloadsHandler.ReleaseRedirects == null)
            {
                var path = WebConfigurationManager.AppSettings["releases"] ?? "~/App_Data/releases.json";

                path = this.ServerUtility.MapPath(path);

                using (var reader = File.OpenText(path))
                using (var json = new JsonTextReader(reader))
                {
                    var serializer = new JsonSerializer();
                    serializer.Converters.Add(new IsoDateTimeConverter());

                    DownloadsHandler.ReleaseRedirects = serializer.Deserialize<Dictionary<string, string>>(json);
                }
            }

            string redirect = null;
            return DownloadsHandler.ReleaseRedirects.TryGetValue(key, out redirect) ? redirect : null;
        }
    }
}
