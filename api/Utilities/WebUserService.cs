namespace WixToolset.Web.Api.Utilities
{
    using System;
    using System.Security.Principal;
    using System.Web;
    using System.Web.Configuration;
    using WixToolset.Web.Api.Models;

    /// <summary>
    /// Creates user's from web data.
    /// </summary>
    public class WebUserService
    {
        private string adminId;
        private string adminUsername;
        private string adminPassword;

        public string AdminId
        {
            get
            {
                if (String.IsNullOrEmpty(this.adminId))
                {
                    Guid guid;
                    if (!Guid.TryParse(WebConfigurationManager.AppSettings["user.admin.id"], out guid))
                    {
                        guid = Guid.NewGuid();
                    }

                    this.adminId = guid.ToString("N");
                }

                return this.adminId;
            }
        }

        public string AdminUsername
        {
            get
            {
                if (String.IsNullOrWhiteSpace(this.adminUsername))
                {
                    this.adminUsername = WebConfigurationManager.AppSettings["user.admin.username"];
                    this.adminUsername = String.IsNullOrWhiteSpace(this.adminUsername) ? "root" : this.adminUsername.Trim();
                }

                return this.adminUsername;
            }
        }

        public string AdminPassword
        {
            get
            {
                if (String.IsNullOrWhiteSpace(this.adminPassword))
                {
                    this.adminPassword = WebConfigurationManager.AppSettings["user.admin.password"];
                    this.adminPassword = String.IsNullOrWhiteSpace(this.adminPassword) ? Guid.NewGuid().ToString("N") : this.adminPassword.Trim();
                }

                return this.adminPassword;
            }
        }

        /// <summary>
        /// Creates an authenticated user based on the principal provided.
        /// </summary>
        /// <param name="principal"><c>IPrincipal</c> for user.</param>
        /// <param name="context"><c>HttpContextBase</c> to populate the user information.</param>
        /// <returns>User object.</returns>
        public User CreateAuthenticatedUser(IPrincipal principal, HttpContext context)
        {
            return this.CreateFromPrincipal(principal, context);
        }

        /// <summary>
        /// Creates an anonymous user.
        /// </summary>
        /// <param name="principal"><c>IPrincipal</c> for user.</param>
        /// <param name="context"><c>HttpContextBase</c> to populate the user information.</param>
        /// <returns>User object.</returns>
        public User CreateAnonymousUser(HttpContext context)
        {
            GenericPrincipal principal = new GenericPrincipal(new GenericIdentity("anonymous", "none"), new string[] { "Anonymous" });
            return this.CreateFromPrincipal(principal, context);
        }

        /// <summary>
        /// Remembers a user's information.
        /// </summary>
        /// <param name="user">User to remember.</param>
        /// <param name="context"><c>HttpContextBase</c> to store the user information.</param>
        public void RememberUser(User user, HttpContext context)
        {
            HttpCookie cookie = new HttpCookie("id", user.Id) { Expires = DateTime.MaxValue, HttpOnly = true };
            context.Response.Cookies.Set(cookie);

            if (!String.IsNullOrEmpty(user.Name))
            {
                cookie = new HttpCookie("n", user.Name) { Expires = DateTime.MaxValue, HttpOnly = true };
                context.Response.Cookies.Set(cookie);
            }

            if (!String.IsNullOrEmpty(user.Email))
            {
                cookie = new HttpCookie("e", user.Email) { Expires = DateTime.MaxValue, HttpOnly = true };
                context.Response.Cookies.Set(cookie);
            }

            if (!String.IsNullOrEmpty(user.Link))
            {
                cookie = new HttpCookie("l", user.Link) { Expires = DateTime.MaxValue, HttpOnly = true };
                context.Response.Cookies.Set(cookie);
            }
        }

        /// <summary>
        /// Creates a principaled user from the HTTP context.
        /// </summary>
        /// <param name="principal"><c>IPrincipal</c> for user.</param>
        /// <param name="context"><c>HttpContextBase</c> to populate the user information.</param>
        /// <returns>User object.</returns>
        private User CreateFromPrincipal(IPrincipal principal, HttpContext context)
        {
            User user = new User(principal);
            HttpCookie cookie;

            // Ensure the user has a unique identifier.
            if (principal.IsInRole("Authenticated"))
            {
                user.Id = this.AdminId;
            }
            else
            {
                Guid guid;

                cookie = context.Request.Cookies["id"];
                if (null != cookie)
                {
                    try
                    {
                        guid = new Guid(cookie.Value);
                    }
                    catch (Exception)
                    {
                        guid = Guid.NewGuid();
                    }

                    if (null != (cookie = context.Request.Cookies["n"]))
                    {
                        user.Name = cookie.Value;
                    }

                    if (null != (cookie = context.Request.Cookies["e"]))
                    {
                        user.Email = cookie.Value;
                    }

                    if (null != (cookie = context.Request.Cookies["l"]))
                    {
                        user.Link = cookie.Value;
                    }
                }
                else
                {
                    guid = Guid.NewGuid();
                }

                user.Id = guid.ToString("N");
            }

            cookie = new HttpCookie("id", user.Id) { Expires = DateTime.MaxValue, HttpOnly = true };
            context.Response.Cookies.Set(cookie);

            // Set whether this user is the admin user.
            if (user.Id == this.AdminId)
            {
                user.Administrator = true;
            }

            // Count the number of times this user has visited the site.
            cookie = context.Request.Cookies["vc"];
            if (cookie != null)
            {
                int visitCount = 0;
                if (Int32.TryParse(cookie.Value, out visitCount))
                {
                    user.Visits = visitCount + 1;
                }
            }

            cookie = new HttpCookie("vc", user.Visits.ToString()) { Expires = DateTime.MaxValue, HttpOnly = true };
            context.Response.Cookies.Set(cookie);

            // Capture other useful information about the user.
            user.IP = context.Request.UserHostAddress;
            user.ReferrerUrl = context.Request.UrlReferrer;
            user.Url = context.Request.Url;
            user.UserAgent = context.Request.UserAgent;

            return user;
        }
    }
}
