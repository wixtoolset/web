---
under: Development
title: Building WiX
keywords: wix toolset,wix,build
layout: secondary
---

## Building WiX

1. Start a 32-bit command prompt.
2. Change directories to the root of your clone repository.
3. Run `MSBuild.exe`.
	- If you have Visual Studio 2013 or later installed, you must run that version of MSBuild: `"%ProgramFiles%\MSBuild\12.0\Bin\MSBuild.exe"`
	- Otherwise, use the version of MSBuild that came with the .NET Framework: `%windir%\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe` 

### Prerequisites

The WiX build system is smart enough to skip building things for which you don't have the prerequisites. For example, if you don't have Visual Studio 2010 installed, the 2010 versions of the WiX native SDK libraries. However, to build the entire WiX Toolset, you need all versions of the follow prerequisites:  

- To build the core WiX tools, you need Visual Studio 2010, Visual Studio 2012, and/or Visual Studio 2013.
- To build the WiX.chm help file, you need [Microsoft HTML Help Workshop 1.4 or later](http://msdn2.microsoft.com/library/ms670169.aspx). Microsoft HTML Help Workshop is included and installed by Visual Studio 2013; for other versions, you have to download and install it manually.
- To build Votive, the WiX project system for Visual Studio, you need a Professional edition or higher of Visual Studio 2010 SP1. (The Express editions do not support building Votive, nor do they support installing Votive.) You also need the matching [Visual Studio 2010 SP1 SDK](http://www.microsoft.com/en-us/download/details.aspx?id=21835).
- To build the DTF help files, you need:
	- [Sandcastle May 2008 Release](https://sandcastle.codeplex.com/releases/view/13873)
	- [Sandcastle Help File Builder]()         

### Official builds with strong-name signing

To create a build that can be installed on different machines, create a new strong name key pair and point OFFICIAL_WIX_BUILD to it:

	sn -k wix.snk
	sn -p wix.snk wix.pub
	sn -tp wix.pub

Copy the public key and add new InternalsVisibleTo attributes in `src\Votive\votive2010\vssdk\AssemblyInfo.cs`. Then run the build:

	msbuild /p:Configuration=Release /p:OFFICIAL_WIX_BUILD=C:\wix.snk
