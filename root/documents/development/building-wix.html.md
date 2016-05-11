---
under: Development
title: Building WiX
keywords: wix toolset,wix,build
layout: heronone
sidebarTitle: Additional information
sidebarItems: [
  { uri: "/about/governance/",
    text: "Governance Document" },
  { uri: "/development/assignment-agreement/",
    text: "Contribution License Agreement" }
]
---

## Building WiX

### Before your first build

To perform the one-time configuration the WiX build requires:

1. Start an *elevated* 32-bit command prompt.
2. Change directories to the root of your clone repository.
3. Run `MSBuild tools\OneTimeWixBuildInitialization.proj`. This project registers the WiX assemblies for strong-name verification skipping. Doing so lets you build and run WiX without strong-name signing the WiX assemblies. 

### Everyday builds

1. Start a 32-bit command prompt.
2. Change directories to the root of your clone repository.
3. Run `MSBuild.exe`.
	- If you have Visual Studio 2013 or later installed, you must run that version of MSBuild: `"%ProgramFiles%\MSBuild\12.0\Bin\MSBuild.exe"`
	- Otherwise, use the version of MSBuild that came with the .NET Framework: `%windir%\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe`
	- If you have only Visual Studio 2012 installed, you must pass a property to tell the WiX build to use that version: `%windir%\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe /p:VisualStudioVersion="11.0"`
	- If you use the `VS201X x86 Native Tools Command Prompt` shortcut from your Visual Studio installation, you can just run `MSBuild` without worrying about the path or `VisualStudioVersion` property.

### Building inside Visual Studio

The `src` directory at the root of the WiX repository contains a number of Visual Studio `.sln` files you can use to build different subsets of WiX from inside Visual Studio. Before you can do so, however, first run a full build of WiX from the command line as discussed above.   

### Prerequisites

The WiX build system is smart enough to skip building things for which you don't have the prerequisites. For example, if you don't have Visual Studio 2010 installed, the 2010 versions of the WiX native SDK libraries. However, to build the entire WiX Toolset, you need all versions of the follow prerequisites:  

- To build the core WiX tools, you need Visual Studio 2010, Visual Studio 2012, Visual Studio 2013, and/or Visual Studio 2015.
- To build the WiX.chm help file, you need [Microsoft HTML Help Workshop 1.4 or later](http://msdn2.microsoft.com/library/ms670169.aspx). Microsoft HTML Help Workshop is included and installed by Visual Studio 2013 and later; for other versions, you have to download and install it manually.
- To build Votive, the WiX project system for Visual Studio, you need a Professional edition or higher of Visual Studio 2010 SP1. (The Express editions do not support building Votive, nor do they support installing Votive.) You also need the matching [Visual Studio 2010 SP1 SDK](http://www.microsoft.com/en-us/download/details.aspx?id=21835).

### Official builds with strong-name signing

Strong-name signing a WiX build lets it be used on a machine other than the one used to build WiX. Creating an "official unofficial" WiX build requires all the above prerequisites; you can't skip parts of an official build. In general, it's a lot easier to submit a pull request and get the next interim build of WiX.

To create a build that can be installed on different machines, create a new strong name key pair and point OFFICIAL_WIX_BUILD to it:

	sn -k wix.snk
	sn -p wix.snk wix.pub
	sn -tp wix.pub

Copy the public key and add new InternalsVisibleTo attributes in `src\Votive\votive2010\vssdk\AssemblyInfo.cs`. Then run the build:

	msbuild /p:Configuration=Release /p:OFFICIAL_WIX_BUILD=C:\wix.snk
