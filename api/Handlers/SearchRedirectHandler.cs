namespace WixToolset.Web.Api.Handlers
{
    using System;
    using TinyWebStack;

    [Route("search")]
    public class SearchRedirectHandler : IGet
    {
        public string Q { private get; set; }

        public Status Get()
        {
            var query = String.IsNullOrEmpty(this.Q) ? String.Empty : "+" + this.Q;

            return Status.FoundAt(String.Concat("http://www.bing.com/search?q=site%3Awixtoolset.org", query));
        }
    }
}
