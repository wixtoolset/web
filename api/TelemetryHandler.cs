namespace WixToolset.Web.Api
{
    using System.Web;
    using NLog;
    using WixToolset.Web.Api.Models;
    using WixToolset.Web.Api.Utilities;

    public class TelemetryHandler : IHttpHandler
    {
        private static Logger Log = LogManager.GetLogger("telemetry");
        private static WebUserService UserService = new WebUserService();

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.User = UserService.CreateAnonymousUser(context);

            Visit.CreateFromHttpContext(context).Log(Log);

            context.Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
        }
    }
}
