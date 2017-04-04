// Copyright (c) .NET Foundation and contributors. All rights reserved. Licensed under the Microsoft Reciprocal License. See LICENSE.TXT file in the project root for full license information.

namespace WixToolset.Web.Controllers
{
    using System.Reflection;
    using Microsoft.AspNetCore.Mvc;

    public class VersionController : Controller
    {
        [HttpGet("version")]
        public object Get()
        {
            var assembly = Assembly.GetEntryAssembly();
            var display = assembly.GetCustomAttribute<AssemblyDescriptionAttribute>();
            var fileVersion = assembly.GetCustomAttribute<AssemblyFileVersionAttribute>();

            return new { Name = display.Description, Version = fileVersion.Version };
        }
    }
}
