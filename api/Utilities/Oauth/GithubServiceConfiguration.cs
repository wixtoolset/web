using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WixToolset.Web.Api.Utilities.Oauth
{
    public class GithubServiceConfiguration : IGithubServiceConfiguration
    {
        public string ClientId { get; set; }

        public string ClientSecret { get; set; }
    }
}
