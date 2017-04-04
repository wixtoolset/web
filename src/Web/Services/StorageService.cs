// Copyright (c) .NET Foundation and contributors. All rights reserved. Licensed under the Microsoft Reciprocal License. See LICENSE.TXT file in the project root for full license information.

namespace WixToolset.Web.Services
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Table;
    using WixToolset.Web.Models;

    public class StorageService : IStorageService
    {
        public StorageService(string connectionString)
        {
            if (String.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            this.Storage = CloudStorageAccount.Parse(connectionString);
        }

        private CloudStorageAccount Storage { get; }

        public async Task LogErrorAsync(int code, string ip, string page, string referrer, Exception exception)
        {
            var error = new ErrorEntity("www.wixtoolset.com")
            {
                StatusCode = code,
                IP = ip,
                Url = page,
                Referrer = referrer,
                Text = exception?.Message,
                StackTrace = exception?.StackTrace,
            };

            await this.WriteToTableStorage("Errors", error);
        }

        public async Task LogVisitAsync(VisitEntity visit)
        {
            await this.WriteToTableStorage("Visits", visit);
        }

        public async Task WriteToTableStorage(string tableName, ITableEntity entity)
        {
            try
            {
                var op = TableOperation.Insert(entity);

                var client = this.Storage.CreateCloudTableClient();

                var table = client.GetTableReference(tableName);

                await table.CreateIfNotExistsAsync();

                await table.ExecuteAsync(op);
            }
            catch (Exception e)
            {
                Trace.TraceError("> Failed to log to table storage, table: {0}, exception: {1}, stacktrace: {2}", tableName, e.Message, e.StackTrace);
            }
        }
    }
}
