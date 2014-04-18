using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using TinyWebStack;
using WixToolset.Web.Api.Utilities.Oauth;

[assembly: PreApplicationStartMethod(typeof(WixToolset.Web.Api.WebApplication), "Start")]

namespace WixToolset.Web.Api
{
    public static class WebApplication
    {
        public static void Start()
        {
            Container.Current.Register<IGithubServiceConfiguration>(c => new GithubServiceConfiguration() { ClientId = WebConfigurationManager.AppSettings["github.clientid"], ClientSecret = WebConfigurationManager.AppSettings["github.clientsecret"] }, Lifetime.Application);

            Container.Current.Register<IGithubService>(c => new GithubService(Container.Current.Resolve<IGithubServiceConfiguration>()), Lifetime.Application);

            ContentHandling.RegisterContentTypes();

            Routing.RegisterRoutes();
        }
    }
}