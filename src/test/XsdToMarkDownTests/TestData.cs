// Copyright (c) .NET Foundation and contributors. All rights reserved. Licensed under the Microsoft Reciprocal License. See LICENSE.TXT file in the project root for full license information.

namespace XsdToMarkDownTests
{
    using System;
    using System.IO;

    public class TestData
    {
        public static string Get(params string[] paths)
        {
            var localPath = Path.GetDirectoryName(new Uri(System.Reflection.Assembly.GetCallingAssembly().Location).LocalPath);
            return Path.Combine(localPath, Path.Combine(paths));
        }
    }
}
