
namespace WixToolset.Web.Api.Utilities.Oauth
{
    public interface IGithubServiceConfiguration
    {
        string ClientId { get; }

        string ClientSecret { get; }
    }
}
