// Copyright (c) .NET Foundation and contributors. All rights reserved. Licensed under the Microsoft Reciprocal License. See LICENSE.TXT file in the project root for full license information.

namespace WixToolset.Web.Services
{
    using System;
    using System.Threading.Tasks;
    using WixToolset.Web.Models;

    public interface IStorageService
    {
        Task LogErrorAsync(int code, string ip, string page, string referrer, Exception exception);

        Task LogVisitAsync(VisitEntity visit);
    }
}
