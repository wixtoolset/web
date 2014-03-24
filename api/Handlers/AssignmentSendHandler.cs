namespace WixToolset.Web.Api.Handlers
{
    using System;
    using System.Net;
    using TinyWebStack;
    using TinyWebStack.Models;
    using WixToolset.Web.Api.Utilities;
    using WixToolset.Web.Api.Utilities.Oauth;

    [Route("development/assignment-agreement/send")]
    public class AssignmentSendHandler
    {
        public FileTransmission Output { get; private set; }

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

            MailService.SendAssignmentRequest(user.Name, user.Login, user.PrimaryEmail);

            this.Output = new FileTransmission("text/html", "~/development/assignment-agreement/sent_data/index.html");

            return Status.OK;
        }
    }
}
