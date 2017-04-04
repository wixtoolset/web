// Copyright (c) .NET Foundation and contributors. All rights reserved. Licensed under the Microsoft Reciprocal License. See LICENSE.TXT file in the project root for full license information.

namespace WixToolset.Web.Extensions
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Http.Authentication;
    using WixToolset.Web.Models;

    public static class HttpContextExtensions
    {
        public async static Task<VisitEntity> CreateVisitEntityAsync(this HttpContext context, string purpose, string data)
        {
            var userId = await context.EnsureAuthenticatedAsync();

            var ip = context.Connection.RemoteIpAddress;

            var referrer = context.Request.Headers["Referer"].ToString();

            var userAgent = context.Request.Headers["User-Agent"].ToString();

            return new VisitEntity("www.wixtoolset.com", purpose)
            {
                Host = context.Request.Host.Value,
                IP = ip.ToString(),
                Method = context.Request.Method,
                Path = context.Request.Path,
                QueryString = context.Request.QueryString.Value,
                Referrer = referrer,
                UserAgent = userAgent,
                UserId = userId,
                Data = data,
            };
        }

        public async static Task<string> EnsureAuthenticatedAsync(this HttpContext context)
        {
            if (!context.User.Identity.IsAuthenticated)
            {
                var principal = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, Guid.NewGuid().ToString("N")) }, CookieAuthenticationDefaults.AuthenticationScheme));

                await context.Authentication.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = true });
            }

            return context.User.Identity.Name;
        }
    }
}
