namespace WixToolset.Web.Api.Utilities
{
    using System;
    using System.Net;
    using System.Net.Mail;
    using System.Web.Configuration;

    public class MailService
    {
        public static void SendAssignmentRequest(string username, string login, string email)
        {
            string subject = "WiX Toolset assignment agreement for " + username;
            string body = @"Outercurve,

{{username}} ('{{login}}' at Github) would like to sign an assignment agreement for the WiX toolset. Can you please provide the necessary documentation?

Thanks,

   WiX Toolset Team
   led by Rob Mensching and Bob Arnson
".Replace("{{username}}", username).Replace("{{login}}", login);

            Send(email, "contributions@outercurve.org", "assignments@wixtoolset.org", subject, body);
        }

        public static void Send(string from, string to, string cc, string subject, string body)
        {
            using (var message = new MailMessage(from, to))
            {
                if (!String.IsNullOrEmpty(cc))
                {
                    message.CC.Add(cc);
                }
                message.Subject = subject;
                message.Body = body;

                using (var smtp = new SmtpClient(WebConfigurationManager.AppSettings["mail.server"], Convert.ToInt32(WebConfigurationManager.AppSettings["mail.port"])))
                {
                    smtp.EnableSsl = "true".Equals(WebConfigurationManager.AppSettings["mail.ssl"] ?? String.Empty, StringComparison.OrdinalIgnoreCase);
                    smtp.Credentials = new NetworkCredential(WebConfigurationManager.AppSettings["mail.username"], WebConfigurationManager.AppSettings["mail.password"]);

                    smtp.Send(message);
                }
            }
        }
    }
}
