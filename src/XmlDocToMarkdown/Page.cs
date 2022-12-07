// Copyright (c) .NET Foundation and contributors. All rights reserved. Licensed under the Microsoft Reciprocal License. See LICENSE.TXT file in the project root for full license information.

namespace WixBuildTools.XmlDocToMarkdown;

using System.Collections.Generic;
using System.Diagnostics;

[DebuggerDisplay("{Id}")]
public class Page
{
    public IEnumerable<string> Content { get; }

    public string Id { get; }

    public Page(string id, IEnumerable<string> content)
    {
        this.Id = id;
        this.Content = content;
    }
}
