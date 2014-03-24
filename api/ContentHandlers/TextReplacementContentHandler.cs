namespace WixToolset.Web.Api.ContentHandlers
{
    using System;
    using TinyWebStack;
    using WixToolset.Web.Api.Models;

    [ContentType("text/html")]
    public class TextReplacementContentHandler : IContentTypeHandler
    {
        public bool TryGetWriter(string contentType, Type handlerType, Type dataType, out IContentTypeWriter writer)
        {
            writer = dataType == typeof(ReplaceTextInFile) ? new TextReplacementWriter(contentType) : null;

            return writer != null;
        }
    }
}
