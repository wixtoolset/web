// Copyright (c) .NET Foundation and contributors. All rights reserved. Licensed under the Microsoft Reciprocal License. See LICENSE.TXT file in the project root for full license information.

namespace WixBuildTools.XmlDocToMarkdown;

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
    /// List of files to process.
    /// </summary>
    public List<string> Files { get; private set; } = new List<string>();

    /// <summary>
    /// Output folder.
    /// </summary>
    public string OutputFolder { get; set; }

    /// <summary>
    /// Document title.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Show the help text.
    /// </summary>
    public static void ShowHelp()
    {
        Console.WriteLine("XsdToMarkdown.exe [-?] -out folder -t \"title\" xml1 xml2 ... xmlN");
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
                else if ("o" == arg || "out" == arg)
                {
                    ++i;
                    if (args.Length == i)
                    {
                        Console.Error.WriteLine("Missing file specification for '-out' option.");
                        success = false;
                    }
                    else
                    {
                        var outputPath = Path.GetFullPath(args[i]);
                        commandLine.OutputFolder = outputPath;
                    }
                }
                else if ("t" == arg || "title" == arg)
                {
                    ++i;
                    if (args.Length == i)
                    {
                        Console.Error.WriteLine("Missing title string for '-title' option.");
                        success = false;
                    }
                    else
                    {
                        commandLine.Title = args[i];
                    }
                }
            }
            else
            {
                var paths = args[i].Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var path in paths)
                {
                    var sourcePath = Path.GetFullPath(path);
                    var sourceDir = Path.GetDirectoryName(sourcePath);
                    var wildcard = sourcePath.Substring(sourceDir.Length + 1);
                    var files = Directory.EnumerateFiles(sourceDir, wildcard);
                    if (files.Any())
                    {
                        commandLine.Files.AddRange(files);
                    }
                    else
                    {
                        Console.Error.WriteLine($"Source file '{sourcePath}' could not be found.");
                        success = false;
                    }
                }
            }
        }

        if (0 == commandLine.Files.Count)
        {
            Console.Error.WriteLine("No inputs specified. Specify at least one file.");
            success = false;
        }

        if (String.IsNullOrEmpty(commandLine.OutputFolder))
        {
            Console.Error.WriteLine("Output folder was not specified. Specify an output folder using the '-out' switch.");
            success = false;
        }

        if (String.IsNullOrEmpty(commandLine.Title))
        {
            Console.Error.WriteLine("Title was not specified. Specify a title using the '-title' switch.");
            success = false;
        }

        return success;
    }
}
