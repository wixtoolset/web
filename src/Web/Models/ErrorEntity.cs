// Copyright (c) .NET Foundation and contributors. All rights reserved. Licensed under the Microsoft Reciprocal License. See LICENSE.TXT file in the project root for full license information.

namespace WixToolset.Web.Models
{
    using System;
    using Azure;
    using Azure.Data.Tables;

    public class ErrorEntity : ITableEntity
    {
        public ErrorEntity()
        {
        }

        public ErrorEntity(string site, string key = null)
        {
            this.PartitionKey = site;
            this.RowKey = key ?? DateTime.UtcNow.ToString("yyyy-MM-ddTHH-mm-ss-ffff") + "-" + Guid.NewGuid().ToString("N");
        }

        public string PartitionKey { get; set; }

        public string RowKey { get; set; }

        public ETag ETag { get; set; } = ETag.All;

        public DateTimeOffset? Timestamp { get; set; }

        public int StatusCode { get; set; }

        public string IP { get; set; }

        public string ForwardedIP { get; set; }

        public string Url { get; set; }

        public string Referrer { get; set; }

        public string StackTrace { get; set; }

        public string Text { get; set; }
    }
}
