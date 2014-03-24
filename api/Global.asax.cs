namespace WixToolset.Web.Api
{
    using System;
    using System.Web;
    using System.Web.Configuration;
    using TinyWebStack;
    using WixToolset.Web.Api.Utilities.Oauth;

    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Container.Current.Register<IGithubServiceConfiguration>(c => new GithubServiceConfiguration() { ClientId = WebConfigurationManager.AppSettings["github.clientid"], ClientSecret = WebConfigurationManager.AppSettings["github.clientsecret"] }, Lifetime.Application);

            Container.Current.Register<IGithubService>(c => new GithubService(Container.Current.Resolve<IGithubServiceConfiguration>()), Lifetime.Application);

            ContentHandling.RegisterContentTypes();

            Routing.RegisterRoutes();
        }
    }
}
