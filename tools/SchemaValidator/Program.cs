// Copyright (c) .NET Foundation and contributors. All rights reserved. Licensed under the Microsoft Reciprocal License. See LICENSE.TXT file in the project root for full license information.

namespace WixBuildTools.SchemaValidator;

using System;
using System.Xml;
using System.Xml.Schema;

public sealed class Program
{
    public static int Main(string[] args)
    {
        if (!CommandLine.TryParseArguments(args, out var commandLine))
        {
            CommandLine.ShowHelp();
            return 1;
        }

        Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: Start run. Validating {commandLine.Sources.Count} source files against {commandLine.Schemas.Count} schemas.");

        var settings = GetReaderSettings(commandLine);

        var errors = 0;

        foreach (var source in commandLine.Sources)
        {
            try
            {
                Validate(source, settings);
            }
            catch (XmlSchemaException xse)
            {
                ++errors;
                Console.WriteLine($"Encountered validation error in {source}({xse.LineNumber},{xse.LinePosition}): {xse.Message}");
            }
        }

        Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: Run complete. Encountered {errors} validation errors from {commandLine.Sources.Count} source files against {commandLine.Schemas.Count} schemas.");

        return 0;
    }

    private static XmlReaderSettings GetReaderSettings(CommandLine commandLine)
    {
        var settings = new XmlReaderSettings
        {
            ValidationType = ValidationType.Schema,
            ValidationFlags =
                        XmlSchemaValidationFlags.ReportValidationWarnings |
                        XmlSchemaValidationFlags.ProcessIdentityConstraints |
                        XmlSchemaValidationFlags.ProcessInlineSchema |
                        XmlSchemaValidationFlags.ProcessSchemaLocation
        };

        foreach (var schema in commandLine.Schemas)
        {
            settings.Schemas.Add(null, schema);
        }

        return settings;
    }

    static void Validate(string xmlFile, XmlReaderSettings settings)
    {
        var document = new XmlDocument();
        var reader = XmlReader.Create(xmlFile, settings);
        document.Load(reader);
        document.Validate(null);
    }
}
