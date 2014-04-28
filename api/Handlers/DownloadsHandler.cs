namespace WixToolset.Web.Api.Handlers
{
    using System;
    using System.IO;
    using System.Linq;
    using NLog;
    using TinyWebStack;
    using WixToolset.Web.Api.Models;
    using WixToolset.Web.Api.Utilities;

    [Route("downloads/{*DownloadPath}")]
    public class DownloadsHandler : IGet
    {
        private static Logger logger = LogManager.GetLogger("dl");
        private static WebUserService UserService = new WebUserService();

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
                string jsonPath = String.Format(Configuration.ReleasesDataFileFormat, version.PrefixedDashed);
                jsonPath = this.ServerUtility.MapPath(jsonPath);

                if (File.Exists(jsonPath))
                {
                    Release release = Release.Load(jsonPath);
                    ReleaseFile releaseFile = release.Files.Where(f => f.Name.Equals(file, StringComparison.OrdinalIgnoreCase)).Single();
                    redirect = releaseFile.Redirect;
                }
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
    }
}
