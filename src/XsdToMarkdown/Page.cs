// Copyright (c) .NET Foundation and contributors. All rights reserved. Licensed under the Microsoft Reciprocal License. See LICENSE.TXT file in the project root for full license information.

namespace WixBuildTools.XsdToMarkdown
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    enum PageType
    {
        SchemaRoot,
        Element,
        Type
    }

    [DebuggerDisplay("{Id}")]
    public class Page
    {
        public string Id { get; }

        public IEnumerable<string> Content { get; }

        public Page(string id, IEnumerable<string> content)
        {
            this.Id = id;
            this.Content = content;
        }
    }
}
