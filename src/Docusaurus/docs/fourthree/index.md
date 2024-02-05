---
sidebar_position: 55
---

# WiX v4 for WiX v3 users

A lot about WiX has changed between v3 and v4 but the nuts and bolts of authoring .wxs files will appear very similar. Here's a [FAQ discussing changes to packages and bundle](./faqs.md). Here are some higher-level things that have changed:

- WiX v4 doesn't have to be installed on every dev machine and build image like WiX v3. Instead, WiX v4 follows the modern .NET model of using NuGet to deliver tools.
  - WiX v4 MSBuild projects are SDK-style projects; MSBuild and NuGet work together to bring down the WiX v4 MSBuild SDK NuGet package.
  - Both .NET Framework MSBuild and `dotnet build` are supported.
  - To build packages from the command line, WiX v4 is available as a .NET tool, which is also a NuGet package.
  - WiX extensions are delivered as NuGet packages, which are usable from both MSBuild projects via `PackageReference` and the WiX .NET tool.
- For command-line afficionados, most executables have been merged into a single `wix.exe` tool with commands. For example, in WiX v3, you might build by calling Candle.exe one or more times to compile your authoring and then calling Light.exe to link and bind the compiled authoring into an .msi package. In WiX v4 using `wix.exe`, that's one command: `wix build -o product.msi product.wxs`.

The WiX v4 language has some simplifications and uses a new namespace, so WiX v3 authoring needs to be converted. Luckily, there's an app for that.


## Convert WiX authoring from the command line

To convert WiX v3 authoring to WiX v4 from the command line, first install the [WiX .NET tool](intro.md#nettool). Then you can run `wix convert`:

:::tip
By default, `wix convert` converts the files in place, overwriting the original files. You can add the `--dry-run` switch to have `wix convert` report on what changes it would make without actually making them. Of course, your setup source code is in version control, so you can always easily revert the changes `wix convert` makes. I mean, it is in version control, right?!
:::

- To convert an individual WiX source file: `wix convert path\to\file.wxs`.
- To convert all WiX source files in a specified directory: `wix convert path\to\*.wxs`.
- To convert all WiX source, include, and localization files in a specified directory: `wix convert path\to\*.wx?`.
- To convert all WiX source, include, and localization files in a specified directory tree: `wix convert --recurse path\to\*.wx?`.


## Convert WiX projects and authoring from Visual Studio

[FireGiant](https://www.firegiant.com/)'s [HeatWave Community Edition][heatwave] includes support for converting WiX v3 authoring (like using `wix convert`) and converting WiX v3 .wixproj MSBuild projects to SDK-style WiX v4 projects.

![HeatWave converter screenshot](hwconverter.png)

[HeatWave Community Edition is available free of charge.][heatwave]

[heatwave]: https://www.firegiant.com/wix/heatwave/
