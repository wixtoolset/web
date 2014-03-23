namespace WixToolset.Web.Api
{
    using System;
    using System.Web;
    using TinyWebStack;

    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            ContentHandling.RegisterContentTypes();

            Routing.RegisterRoutes();
        }
    }
}
