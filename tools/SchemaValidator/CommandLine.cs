// Copyright (c) .NET Foundation and contributors. All rights reserved. Licensed under the Microsoft Reciprocal License. See LICENSE.TXT file in the project root for full license information.

namespace WixBuildTools.SchemaValidator;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/// <summary>
/// Command-line parsing.
/// </summary>
public class CommandLine
{
    private CommandLine()
    {
    }

    /// <summary>
    /// List of schema files to process.
    /// </summary>
    public List<string> Schemas { get; private set; } = new List<string>();

    /// <summary>
    /// List of source files to process.
    /// </summary>
    public List<string> Sources { get; private set; } = new List<string>();

    /// <summary>
    /// Show the help text.
    /// </summary>
    public static void ShowHelp()
    {
        Console.WriteLine("SchemaValidator.exe [-?] path/to/*.xsd path/to/*.wx?");
    }

    /// <summary>
    /// Parses the command-line.
    /// </summary>
    /// <param name="args">Arguments from command-line.</param>
    /// <param name="commandLine">Command line object created from command-line arguments</param>
    /// <returns>True if command-line is parsed, false if a failure was occurred.</returns>
    public static bool TryParseArguments(string[] args, out CommandLine commandLine)
    {
        var success = true;

        commandLine = new CommandLine();

        for (var i = 0; i < args.Length; ++i)
        {
            if ('-' == args[i][0] || '/' == args[i][0])
            {
                var arg = args[i].Substring(1).ToLowerInvariant();
                if ("?" == arg || "help" == arg)
                {
                    return false;
                }
            }
            else
            {
                var paths = args[i].Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var path in paths)
                {
                    var sourcePath = Path.GetFullPath(path);
                    var sourceDir = Path.GetDirectoryName(sourcePath);
                    var wildcard = sourcePath.Substring(sourceDir!.Length + 1);
                    var files = Directory.EnumerateFiles(sourceDir, wildcard, SearchOption.AllDirectories);
                    if (files.Any())
                    {
                        commandLine.Schemas.AddRange(files.Where(f => Path.GetExtension(f).Equals(".xsd", StringComparison.OrdinalIgnoreCase)));
                        commandLine.Sources.AddRange(files.Where(f => Path.GetExtension(f).StartsWith(".wx", StringComparison.OrdinalIgnoreCase)));
                    }
                    else
                    {
                        Console.Error.WriteLine($"Source file '{sourcePath}' could not be found.");
                        success = false;
                    }
                }
            }
        }

        if (0 == commandLine.Schemas.Count)
        {
            Console.Error.WriteLine("No schema files specified. Specify at least one file.");
            success = false;
        }

        if (0 == commandLine.Sources.Count)
        {
            Console.Error.WriteLine("No source files specified. Specify at least one file.");
            success = false;
        }

        return success;
    }
}
