namespace WixToolset.Web.Api
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Web;
    using NLog;
    using WixToolset.Web.Api.Models;
    using WixToolset.Web.Api.Utilities;

    public class DownloadsHandler : IHttpHandler
    {
        private static Logger logger = LogManager.GetLogger("dl");
        private static WebUserService UserService = new WebUserService();

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.User = UserService.CreateAnonymousUser(context);

            string[] parsed = context.Request.Path.Split(new char[] { '/' }, 3, StringSplitOptions.RemoveEmptyEntries);
            if (3 != parsed.Length)
            {
                Go(context, "/releases", false);
                return;
            }

            VersionString version;
            string file;
            try
            {
                version = new VersionString(parsed[1]);
                file = parsed[2].Replace("..", String.Empty);
            }
            catch
            {
                Go(context, "/releases", false);
                return;
            }

            // See if there is a version redirect file for the requested release.
            string redirect = null;
            try
            {
                string jsonPath = String.Format(Configuration.ReleasesDataFileFormat, version.PrefixedDashed);
                jsonPath = context.Server.MapPath(jsonPath);

                if (File.Exists(jsonPath))
                {
                    Release release = Release.Load(jsonPath);
                    ReleaseFile releaseFile = release.Files.Where(f => f.Name.Equals(file, StringComparison.OrdinalIgnoreCase)).Single();
                    redirect = releaseFile.Redirect;
                }
            }
            catch
            {
                context.Response.StatusCode = (int)System.Net.HttpStatusCode.NotFound;
                return;
            }

            // If redirect was not found, assume we're looking for a file on the download server.
            if (String.IsNullOrEmpty(redirect))
            {
                Visit.CreateFromHttpContext(context).Log(logger);
                redirect = String.Format(Configuration.DownloadServerFormat, version.Prefixed, file);
            }

            Go(context, redirect, false);
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
    }
}
