namespace WixToolset.Web.Api.Handlers
{
    using System;
    using System.Net;
    using TinyWebStack;
    using WixToolset.Web.Api.Models;
    using WixToolset.Web.Api.Utilities.Oauth;

    [Route("development/assignment-agreement/verify")]
    public class AssignmentSignHandler
    {
        public ReplaceTextInFile Output { get; private set; }

        [Cookie("ghu")]
        public string UserIdCookie { private get; set; }

        public IApplicationState ApplicationState { private get; set; }

        public Status Get()
        {
            GithubUser user;
            if (String.IsNullOrEmpty(this.UserIdCookie) ||
                !this.ApplicationState.TryGet<GithubUser>(this.UserIdCookie + ".user", out user))
            {
                return Status.Unauthorized;
            }

            this.Output = new ReplaceTextInFile("~/development/assignment-agreement/sign_data/index.html");
            this.Output.Replacements.Add("{{company}}", String.IsNullOrEmpty(user.Company) ? "(Unemployed)" : user.Company);
            this.Output.Replacements.Add("{{login}}", user.Login ?? String.Empty);
            this.Output.Replacements.Add("{{name}}", user.Name ?? String.Empty);
            this.Output.Replacements.Add("{{email}}", user.PrimaryEmail ?? String.Empty);

            return Status.OK;
        }
    }
}
