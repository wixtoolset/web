namespace WixToolset.Web.Api.Utilities
{
    using System;
    using System.IO;
    using System.Net;
    using System.Text;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// Makes a web request to a JSON resource.
    /// </summary>
    public class JsonWebRequest
    {
        public JsonWebRequest(string uri)
        {
            this.Uri = uri;
        }

        /// <summary>
        /// Optional content type for accepted types. Default is "application/json".
        /// </summary>
        public string Accept { get; set; }

        /// <summary>
        /// Optional authorization information to set in the header.
        /// </summary>
        public string Authorization { get; set; }

        /// <summary>
        /// HTTP request method. Defaults to "POST" if `PostData` is provided otherwise "GET".
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// Optional data to POST to request.
        /// </summary>
        public string PostData { get; set; }

        /// <summary>
        /// URI of resource to request.
        /// </summary>
        public string Uri { get; private set; }

        /// <summary>
        /// Optional user agent for HTTP request.
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// Request JSON object from URI.
        /// </summary>
        /// <typeparam name="T">Type to return from the JSON.</typeparam>
        /// <returns>Deserialized JSON object.</returns>
        public T Request<T>()
        {
            var request = WebRequest.Create(this.Uri) as HttpWebRequest;
            request.UserAgent = this.UserAgent ?? "RobMensching.Oauth.Services.JsonWebRequest";

            if (!String.IsNullOrEmpty(this.Method))
            {
                request.Method = this.Method;
            }
            else if (!String.IsNullOrEmpty(this.PostData))
            {
                request.Method = "POST";
            }

            request.Accept = this.Accept ?? "application/json";

            if (!String.IsNullOrEmpty(this.Authorization))
            {
                request.Headers.Add("Authorization", this.Authorization);
            }

            if (!String.IsNullOrEmpty(this.PostData))
            {
                var data = Encoding.UTF8.GetBytes(this.PostData);

                request.ContentLength = data.Length;
                request.ContentType = "application/x-www-form-urlencoded;charset=utf-8";

                using (var requestStream = request.GetRequestStream())
                {
                    requestStream.Write(data, 0, data.Length);
                }
            }

            using (var response = request.GetResponse() as HttpWebResponse)
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var serializer = JsonSerializer.Create(new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                return (T)serializer.Deserialize(reader, typeof(T));
            }
        }
    }
}
