// Copyright (c) .NET Foundation and contributors. All rights reserved. Licensed under the Microsoft Reciprocal License. See LICENSE.TXT file in the project root for full license information.

namespace WixToolset.Web.Controllers
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Net.Http.Headers;
    using WixToolset.Web.Services;

    public class StatusCodeController : Controller
    {
        private static readonly Regex HighDefinitionFileUrl = new Regex(@"@2x\.(jpg|gif|png)($|\?)", RegexOptions.CultureInvariant | RegexOptions.ExplicitCapture | RegexOptions.Singleline);

        public StatusCodeController(IStorageService storageService)
        {
            this.StorageService = storageService;
        }

        private IStorageService StorageService { get; }

        [Route("statuscode/{code}")]
        public async Task<IActionResult> Get(int code)
        {
            var exceptionFeature = this.HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            var page = exceptionFeature?.Path;

            if (String.IsNullOrEmpty(page))
            {
                var reexecuteFeature = this.HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

                page = reexecuteFeature?.OriginalPath ?? String.Empty;
            }

            if (HighDefinitionFileUrl.IsMatch(page))
            {
                return this.StatusCode(code);
            }

            var ip = this.HttpContext.Connection.RemoteIpAddress?.ToString();

            var referrer = this.Request.Headers[HeaderNames.Referer];

            await this.StorageService.LogErrorAsync(code, ip, page, referrer, exceptionFeature?.Error);

            var file = Path.GetFullPath(code == 404 ? "wwwroot/notfound/index.html" : "wwwroot/error/index.html");

            return this.PhysicalFile(file, "text/html");
        }
    }
}
