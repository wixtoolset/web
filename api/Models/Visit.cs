namespace WixToolset.Web.Api.Models
{
    using System;
    using System.Web;
    using NLog;

    /// <summary>
    /// Data to log for each visit.
    /// </summary>
    public class Visit
    {
        public Visit()
        {
            this.DateTime = DateTime.UtcNow;
        }

        public DateTime DateTime { get; set; }

        public string Method { get; set; }

        public string IP { get; set; }

        public string Path { get; set; }

        public string QueryString { get; set; }

        public string Host { get; set; }

        public string UserAgent { get; set; }

        public string Status { get; set; }

        public string Referrer { get; set; }

        public string UserName { get; set; }

        public string UserId { get; set; }

        public string UserEmail { get; set; }

        public int UserVisits { get; set; }

        public static Visit CreateFromHttpContext()
        {
            HttpContext httpContext = HttpContext.Current;

            Visit visit = new Visit();
            if (httpContext.Request != null)
            {
                visit.IP = httpContext.Request.UserHostAddress;
                visit.Method = httpContext.Request.HttpMethod;
                visit.Referrer = httpContext.Request.UrlReferrer == null ? null : httpContext.Request.UrlReferrer.AbsoluteUri;
                visit.Host = httpContext.Request.Url.Host;
                visit.Path = httpContext.Request.Url.AbsolutePath;
                visit.QueryString = httpContext.Request.Url.Query;
                visit.UserAgent = httpContext.Request.UserAgent;
            }

            if (httpContext.Response != null)
            {
                visit.Status = httpContext.Response.Status;
            }

            User user = httpContext.User as User;
            if (user != null)
            {
                visit.UserName = user.Name;
                visit.UserId = user.Id;
                visit.UserEmail = user.Email;
                visit.UserVisits = user.Visits;
            }
            return visit;
        }

        public Visit Log(Logger logger)
        {
            logger.Info("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\t{11}\t{12}\t{13}",
                        this.DateTime.ToString("yyyy-MM-dd"),
                        this.DateTime.ToString("HH:mm:ss.f"),
                        this.IP ?? "-",
                        this.UserId ?? "-",
                        this.Method ?? "-",
                        this.Host ?? "-",
                        this.Path ?? "-",
                        this.QueryString ?? "-",
                        this.Status ?? "-",
                        this.UserAgent ?? "-",
                        this.Referrer ?? "-",
                        this.UserName ?? "-",
                        this.UserEmail ?? "-",
                        this.UserVisits);
            return this;
        }
    }
}
