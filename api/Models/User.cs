namespace WixToolset.Web.Api.Models
{
    using System;
    using System.Security.Principal;

    /// <summary>
    /// User definition for blog.
    /// </summary>
    public class User : IPrincipal
    {
        private IPrincipal principal;

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="principal">Principal that represents this user.</param>
        public User(IPrincipal principal)
        {
            this.principal = principal;
        }

        /// <summary>
        /// Gets whether the user is the administrator.
        /// </summary>
        public bool Administrator { get; internal set; }

        /// <summary>
        /// Gets the unique identifier for this user.
        /// </summary>
        public string Id { get; internal set; }

        /// <summary>
        /// Gets the identity of the user's principal.
        /// </summary>
        public IIdentity Identity
        {
            get { return this.principal.Identity; }
        }

        /// <summary>
        /// Gets the name provided by the user if present.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Gets the email provided by the user if present.
        /// </summary>
        public string Email { get; internal set; }

        /// <summary>
        /// Gets the url provided by the user if present.
        /// </summary>
        public string Link { get; internal set; }

        /// <summary>
        /// Gets the user IP address.
        /// </summary>
        public string IP { get; internal set; }

        /// <summary>
        /// Gets the URL the user came from.
        /// </summary>
        public Uri ReferrerUrl { get; internal set; }

        /// <summary>
        /// Gets the URL the user was accessing.
        /// </summary>
        public Uri Url { get; internal set; }

        /// <summary>
        /// Gets the user's agent.
        /// </summary>
        public string UserAgent { get; internal set; }

        /// <summary>
        /// Gets the number of times the user has previously visited the site.
        /// </summary>
        public int Visits { get; internal set; }

        /// <summary>
        /// Determines whether this user is a member of a particular role.
        /// </summary>
        /// <param name="role">Name of the role.</param>
        /// <returns>true if the user is a member of the role.</returns>
        public bool IsInRole(string role)
        {
            bool inRole = false;
            switch (role)
            {
                case "administrator":
                    inRole = this.Administrator;
                    break;

                default:
                    inRole = this.principal.IsInRole(role);
                    break;
            }

            return inRole;
        }
    }
}
