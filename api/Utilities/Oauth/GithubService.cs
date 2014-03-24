namespace WixToolset.Web.Api.Utilities.Oauth
{
    using System;
    using System.Configuration;
    using System.Linq;
    using System.Text;

    public class GithubService : IGithubService
    {
        public GithubService(IGithubServiceConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        private IGithubServiceConfiguration Configuration { get; set; }

        public GithubAuthorizationInitialized InitiateGitHubAuthorization(string authorizationUrl, string returnUrl, params string[] scopes)
        {
            var uri = new StringBuilder("https://github.com/login/oauth/authorize");
            var state = String.Concat(Guid.NewGuid().ToString("N"), returnUrl);

            uri.AppendFormat("?client_id={0}&state={1}", Configuration.ClientId, state);

            if (scopes.Length > 0)
            {
                uri.AppendFormat("&scope={0}", String.Join(",", scopes));
            }

            if (!String.IsNullOrEmpty(authorizationUrl))
            {
                uri.AppendFormat("&redirect_uri={0}", authorizationUrl);
            }

            return new GithubAuthorizationInitialized() { State = state, Uri = uri.ToString() };
        }

        public bool TryAuthenticate(string code, string state, string verify, out GithubAccessToken token)
        {
            token = null;

            if (!String.Equals(state, verify, StringComparison.Ordinal))
            {
                return false;
            }

            var post = String.Concat("client_id=", Configuration.ClientId, "&client_secret=", Configuration.ClientSecret, "&code=", code);

            try
            {
                var tokenRequest = new JsonWebRequest("https://github.com/login/oauth/access_token") { PostData = post };
                var response = tokenRequest.Request<TokenResponse>();

                token = new GithubAccessToken() { ReturnUrl = state.Length > 32 ? state.Substring(32) : null, Scope = response.scope, Type = response.token_type, Value = response.access_token };
            }
            catch (Exception e)
            {
                var t = e;
            }

            return token != null;
        }

        public GithubUser GetUser(string accessToken)
        {
            var authorization = "Bearer " + accessToken;

            var userRequest = new JsonWebRequest("https://api.github.com/user") { Authorization = authorization };
            var user = userRequest.Request<User>();

            var emailRequest = new JsonWebRequest("https://api.github.com/user/emails") { Accept = "application/vnd.github.v3", Authorization = authorization };
            var emails = emailRequest.Request<UserEmail[]>();

            var primaryEmail = emails.Where(e => e.Primary).Select(e => e.Email).FirstOrDefault();

            return new GithubUser() { Company = user.Company, Login = user.Login, Name = user.Name, PrimaryEmail = primaryEmail };
        }

        private class TokenResponse
        {
            public string access_token { get; set; }

            public string scope { get; set; }

            public string token_type { get; set; }
        }

        private class User
        {
            public string Login { get; set; }

            public string Company { get; set; }

            public string Name { get; set; }
        }

        private class UserEmail
        {
            public string Email { get; set; }

            public bool Verfied { get; set; }

            public bool Primary { get; set; }
        }
    }
}
