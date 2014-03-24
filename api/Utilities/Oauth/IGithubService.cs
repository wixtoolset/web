
namespace WixToolset.Web.Api.Utilities.Oauth
{
    public interface IGithubService
    {
        GithubAuthorizationInitialized InitiateGitHubAuthorization(string authorizationUrl, string returnUrl, params string[] scopes);

        bool TryAuthenticate(string code, string state, string verify, out GithubAccessToken token);

        GithubUser GetUser(string accessToken);
    }
}
