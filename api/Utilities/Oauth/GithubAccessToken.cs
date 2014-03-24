
namespace WixToolset.Web.Api.Utilities.Oauth
{
    public class GithubAccessToken
    {
        public string ReturnUrl { get; set; }

        public string Scope { get; set; }

        public string Type { get; set; }

        public string Value { get; set; }
    }
}