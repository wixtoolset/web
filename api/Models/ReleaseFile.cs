namespace WixToolset.Web.Api.Models
{
    public class ReleaseFile
    {
        public string Name { get; set; }

        public string ContentType { get; set; }

        public string Redirect { get; set; }

        public bool Promoted { get; set; }

        public bool Protected { get; set; }

        public string Title { get; set; }
    }
}
