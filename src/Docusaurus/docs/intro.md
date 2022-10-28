---
sidebar_position: 0
---

# Get started with WiX

There are three ways to use WiX v4:

- [Command-line .NET tool](#nettool)
- [MSBuild on the command line and CI/CD build systems](#msbuild)
- [Visual Studio](#vs)


## Command-line .NET tool {#nettool}

WiX v4 is available as a [.NET tool](https://learn.microsoft.com/en-us/dotnet/core/tools/global-tools) for your command-line pleasure.

:::note
The `wix.exe` tool requires the .NET 6 SDK.
:::

Wix.exe supports commands to perform particular operations. For example, the `build` command lets you build MSI packages, bundles, and other package types.

To install the Wix.exe .NET tool:

```sh
dotnet tool install --global wix --version 4.0.0-preview.1
```

To verify Wix.exe was successfully installed:

```sh
wix --version
```

#### See also
- [Wix.exe command-line reference](reference/wixexe.md)

## MSBuild on the command line and CI/CD build systems {#msbuild}

WiX v4 is available as an MSBuild SDK for building from the command line using `dotnet build` from the .NET SDK or the .NET Framework-based `MSBuild` from Visual Studio. SDK-style projects have smart defaults that make for simple .wixproj project authoring. For example, here's a minimal .wixproj that builds an MSI from the .wxs source files in the project directory:

```xml
<Project Sdk="WixToolset.Sdk/4.0.0-preview.1">
</Project>
```


## Visual Studio {#vs}

TODO
