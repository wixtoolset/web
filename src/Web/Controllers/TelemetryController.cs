// Copyright (c) .NET Foundation and contributors. All rights reserved. Licensed under the Microsoft Reciprocal License. See LICENSE.TXT file in the project root for full license information.

namespace WixToolset.Web.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using WixToolset.Web.Extensions;
    using WixToolset.Web.Services;

    public class TelemetryController : Controller
    {
        public TelemetryController(IStorageService storageService)
        {
            this.StorageService = storageService;
        }

        private IStorageService StorageService { get; }

        [Route("telemetry/{*anything}")]
        public async Task<StatusCodeResult> Get([FromForm] string data = null)
        {
            var visit = await this.HttpContext.CreateVisitEntityAsync("telemetry", data);

            await this.StorageService.LogVisitAsync(visit);

            return this.StatusCode(200);
        }
    }
}
