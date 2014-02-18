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
                context.Response.Redirect("/releases");
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
                context.Response.Redirect("/releases");
                return;
            }

            Release release;
            ReleaseFile releaseFile;
            try
            {
                string jsonPath = String.Format(Configuration.ReleasesDataFileFormat, version.PrefixedDashed);

                release = Release.Load(context.Server.MapPath(jsonPath));
                releaseFile = release.Files.Where(f => f.Name.Equals(file, StringComparison.OrdinalIgnoreCase)).Single();
            }
            catch
            {
                context.Response.StatusCode = (int)System.Net.HttpStatusCode.NotFound;
                return;
            }

            if (!String.IsNullOrEmpty(releaseFile.Redirect))
            {
                context.Response.Redirect(releaseFile.Redirect);
            }
            else
            {
                string path = Path.Combine(context.Server.MapPath(Configuration.ReleasesRootFolder), version.Nonprefixed, file.Replace("/", "\\"));
                if (File.Exists(path))
                {
                    Visit.CreateFromHttpContext(context).Log(logger);

                    context.Response.ContentType = releaseFile.ContentType;
                    context.Response.TransmitFile(path);
                }
                else
                {
                    context.Response.StatusCode = (int)System.Net.HttpStatusCode.NotFound;
                }
            }
        }
    }
}
