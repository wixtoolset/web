namespace WixToolset.Web.Api.Handlers
{
    using System;
    using System.Net;
    using TinyWebStack;
    using WixToolset.Web.Api.Utilities.Oauth;

    [Route("development/assignment-agreement/login")]
    public class AssignmentLoginHandler
    {
        public string Code { get; set; }

        public string State { get; set; }

        public string ReturnUrl { get; set; }

        public GithubUser Output { get; private set; }

        [Cookie("ghu", Expires = 600)]
        public string UserIdCookie { get; set; }

        public IApplicationState ApplicationState { private get; set; }

        public IGithubService Github { private get; set; }

        public IRequest Request { private get; set; }

        public Status Get()
        {
            // If we've not authenticated the user yet, do that and come right back here
            // with the authorization information.
            //
            string stateVerification;
            if (String.IsNullOrEmpty(this.UserIdCookie) ||
                String.IsNullOrEmpty(this.Code) ||
                String.IsNullOrEmpty(this.State) ||
                !this.ApplicationState.TryGet<string>(this.UserIdCookie, out stateVerification))
            {
                return this.Authenticate();
            }

            // We've authenticated now authorize the user (to get their primary email).
            //
            return this.Authorize(stateVerification);
        }

        private Status Authenticate()
        {
            var here = this.Request.Url.GetLeftPart(UriPartial.Path);

            var init = this.Github.InitiateGitHubAuthorization(here, this.ReturnUrl, "user:email");

            this.UserIdCookie = Guid.NewGuid().ToString("N");

            this.ApplicationState.Set(this.UserIdCookie, init.State, DateTime.Now.AddMinutes(30));

            return Status.TemporaryRedirectTo(init.Uri);
        }

        private Status Authorize(string stateVerification)
        {
            var to = this.Request.Url.GetLeftPart(UriPartial.Path);

            GithubAccessToken token;
            if (this.Github.TryAuthenticate(this.Code, this.State, stateVerification, out token))
            {
                try
                {
                    this.Output = this.Github.GetUser(token.Value);

                    this.ApplicationState.Set(this.UserIdCookie + ".user", this.Output, DateTime.Now.AddMinutes(30));

                    // If a return url was provided, go there otherwise go home.
                    to = String.IsNullOrEmpty(token.ReturnUrl) ? "~/" : token.ReturnUrl;

                    return Status.TemporaryRedirectTo(to);
                }
                catch (WebException)
                {
                    // Fallthrough to the error handling below.
                }
            }

            // Clear the user cookie and send the user back through the verification process.
            this.UserIdCookie = null;
            return Status.TemporaryRedirectTo(to);
        }
    }
}
