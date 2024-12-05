// Copyright (c) .NET Foundation and contributors. All rights reserved. Licensed under the Microsoft Reciprocal License. See LICENSE.TXT file in the project root for full license information.

namespace WixToolset.Web.Models
{
    using System;
    using Azure;
    using Azure.Data.Tables;

    public class VisitEntity : ITableEntity
    {
        public VisitEntity()
        {
        }

        public VisitEntity(string site, string purpose, string key = null)
        {
            this.PartitionKey = site;
            this.RowKey = key ?? DateTimeOffset.UtcNow.ToString("yyyy-MM-ddTHH-mm-ss-ffff") + "-" + Guid.NewGuid().ToString("N");

            this.Purpose = purpose;
        }

        public string PartitionKey { get; set; }

        public string RowKey { get; set; }

        public ETag ETag { get; set; } = ETag.All;

        public DateTimeOffset? Timestamp { get; set; }

        public string Method { get; set; }

        public string IP { get; set; }

        public string Path { get; set; }

        public string QueryString { get; set; }

        public string Host { get; set; }

        public string UserAgent { get; set; }

        public string Referrer { get; set; }

        public string Purpose { get; set; }

        public string UserId { get; set; }

        public string Data { get; set; }
    }
}
