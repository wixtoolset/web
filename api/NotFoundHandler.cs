namespace WixToolset.Web.Api
{
    using System;
    using System.Web;
    using NLog;

    public class NotFoundHandler : IHttpHandler
    {
        private static Logger Log = LogManager.GetLogger("notfound");

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            Log.Info("url: {0}  referrer: {1}", context.Request.Url.AbsoluteUri, context.Request.UrlReferrer != null ? context.Request.UrlReferrer.AbsoluteUri : String.Empty);

            context.Response.StatusCode = (int)System.Net.HttpStatusCode.NotFound;
            context.Response.TransmitFile("/notfound/index.html");
        }
    }
}
