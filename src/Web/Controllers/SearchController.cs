// Copyright (c) .NET Foundation and contributors. All rights reserved. Licensed under the Microsoft Reciprocal License. See LICENSE.TXT file in the project root for full license information.

namespace WixToolset.Web.Controllers
{
    using System;
    using System.Net;
    using Microsoft.AspNetCore.Mvc;

    public class SearchController : Controller
    {
        [HttpGet("search")]
        public ActionResult Get(string q)
        {
            var query = String.IsNullOrEmpty(q) ? "WixToolset" : WebUtility.UrlEncode(q);

            var redirect = $"http://www.bing.com/search?q1=site:wixtoolset.org&q={query}";

            return this.Redirect(redirect);
        }
    }
}
