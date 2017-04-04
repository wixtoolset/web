// Copyright (c) .NET Foundation and contributors. All rights reserved. Licensed under the Microsoft Reciprocal License. See LICENSE.TXT file in the project root for full license information.

namespace WixToolset.Web.Models
{
    using System;
    using Microsoft.WindowsAzure.Storage.Table;

    public class ErrorEntity : TableEntity
    {
        public ErrorEntity()
        {
        }

        public ErrorEntity(string site, string key = null)
        {
            this.PartitionKey = site;
            this.RowKey = key ?? DateTime.UtcNow.ToString("yyyy-MM-ddTHH-mm-ss-ffff") + "-" + Guid.NewGuid().ToString("N");
        }

        public int StatusCode { get; set; }

        public string IP { get; set; }

        public string ForwardedIP { get; set; }

        public string Url { get; set; }

        public string Referrer { get; set; }

        public string StackTrace { get; set; }

        public string Text { get; set; }
    }
}