// Copyright (c) .NET Foundation and contributors. All rights reserved. Licensed under the Microsoft Reciprocal License. See LICENSE.TXT file in the project root for full license information.

namespace WixToolset.Web
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using WixToolset.Web.Models;
    using WixToolset.Web.Extensions;
    using WixToolset.Web.Services;
    using System.Threading.Tasks;

    public class DownloadsController : Controller
    {
        public DownloadsController(IStorageService storageService)
        {
            this.StorageService = storageService;
        }

        private IStorageService StorageService { get; }

        [Route("releases/{version}/{*file}")]
        [Route("downloads/{version}/{*file}")]
        public async Task<IActionResult> RedirectToDownload(string version, string file)
        {
            if (!VersionString.TryParse(version, out var versionString) || String.IsNullOrEmpty(file))
            {
                return this.Redirect("/releases");
            }

            // The blob.core.windows.net is case sensitive and all files there are lower case.
            var redirect = String.Format("https://wixdl.blob.core.windows.net/releases/{0}/{1}", versionString.Prefixed, file).ToLowerInvariant();

            var visit = await this.HttpContext.CreateVisitEntityAsync("download", $"Version={versionString.Nonprefixed}+File={file}");

            await this.StorageService.LogVisitAsync(visit);

            return this.Redirect(redirect);
        }
    }
}
