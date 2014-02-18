namespace WixToolset.Web.Api
{
    using System;
    using System.Web;

    public class SearchRedirectHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string query = context.Request.Url.Query ?? String.Empty;

            if (query.StartsWith("?q="))
            {
                query = String.Concat("+", query.Substring(3));
            }
            else
            {
                query = String.Empty;
            }

            context.Response.Redirect(String.Concat("http://www.bing.com/search?q=site%3Awixtoolset.org", query), false);
            context.ApplicationInstance.CompleteRequest();
        }
    }
}
