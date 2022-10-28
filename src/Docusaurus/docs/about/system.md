---
sidebar_position: 1
---

# System requirements

## Running packages built with WiX

In general, packages you build with WiX will work on Windows 7 or later. Code that you introduce -- for example, custom actions or bootstrapper applications -- can require later versions of Windows.


## Building packages with WiX

To use WiX as a .NET tool or as an MSBuild SDK via `dotnet build`, you must have a .NET 6 SDK installed. [See its system requirements](https://learn.microsoft.com/en-us/dotnet/core/install/windows?tabs=net60#supported-releases) and [download here](https://learn.microsoft.com/en-us/dotnet/core/install/windows?tabs=net60).

To use WiX as an MSBuild SDK via `msbuild`, you must have [.NET Framework 4.7.2 or later installed](https://learn.microsoft.com/en-us/dotnet/framework/get-started/system-requirements). WiX runs on ARM64 systems as ARM64 
