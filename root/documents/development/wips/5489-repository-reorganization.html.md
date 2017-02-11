---
wip: 5489
type: Feature
by: Rob Mensching (rob at firegiant.com)
title: Repository Reorganization
---

## User stories

* As a WiX developer I can work on a focused subset of the toolset such
that I am more productive because there is less code and the development
loop is faster.

* As a WiX developer I can work on a focused subset of the toolset such
that I consider the interfaces between independent parts of the toolset.

## Proposal

Today the WiX Toolset is a monolithic repository per major release.
This makes it easy to build everything from a single repository.
The downside is that you build everything and need everything to
build. Since the WiX Toolset functionality spans the breadth of the
Windows ecosystem that means you need a lot of tools to build
(Windows SDKs, multiple versions of Visual Studio, etc).

There are also large portions of the WiX Toolset that do not change
from release to release. That means code is being rebuilt and
redistributed even though there is no change. This not only
wastes developer time and build machine time but customer installation
time.

Finally, NuGet has changed the way that developers share libraries.
There is functionality in the WiX Toolset--such as dutil, wcautil,
and DTF--that would be more accessible if made available via NuGet.

To modernize the WiX developer experience, this proposal recommends
breaking the `wix4` monolithic repository into several smaller
repositories each focused on an independent part of the WiX Toolset.
When considering how to reorgnize the WiX Toolset's repositories
it is important to the layers of functionality in the toolset itself:

1. Libraries - independent functionality the rest of the toolset builds upon.
Examples include: dutil, wcautil, DTF, and WixToolset.Data

2. Burn - the bootstrapper engine and its interfaces

3. Core - the command-line tools, MSBuild integration, Compiler/Linker/Binder

4. Votive - WiX Toolset's Visual Studio Extension

5. WiX Extensions - extensions to the WiX Toolset. Examples include:
WixIisExtension, WixNetfxExtension, WixSqlExtension, and others


### Libraries

First and foremost, the libraries in the WiX Toolset are split on
interface boundaries. Changes made to a library must take into
account the interface and what breaking changes might occur.
Today it is too easy to change a library in the WiX Toolset and "fix up"
the Core without considering dependents outside of the WiX Toolset
itself. With the libraries separated, breaking changes will
be easier to detect.

Second, library repositories must be independent from each other
so a single set of functionality is published by a respository. For
example, dutil and wcautil libraries live in separate respositories
so changes to wcautil do not cause dutil to be published.

Here are the proposed Library repositories:

* Dutil - publishes `dutil.lib` for all supported versions of
Visual Studio via a NuGet package: `WixToolset.Dutil`. Additionally,
`deputil` files will be moved into dutil and there will be no `deputil.lib` in the future.

* Wcautil - publishes `wcautil.lib` for all supported versions
of Visual Studio via a NuGet package: `WixToolset.Wcautil`

* Balutil - publishes `balutil.lib` for all supported versions
of Visual Studio via a NuGet package: `WixToolset.Balutil`

* Dtf.Compression - publishes the Compression assemblies in Dtf
via NuGet packages: `WixToolset.Dtf.Compression`,
`WixToolset.Dtf.Compression.Cab`, `WixToolset.Dtf.Compression.Zip`

* Dtf.Resources - publishes the Resources assembly in Dtf via NuGet
package: `WixToolset.Dtf.Resources`

* Dtf.WindowsInstaller - publishes the WindowsInstaller assemblies
in Dtf via NuGet packages: `WixToolset.Dtf.WindowsInstaller`, `WixToolset.Dtf.WindowsInstaller.Package`

* Data - publishes the WixToolset.Data assembly via NuGet package: `WixToolset.Data`

* Extensibility - publishes the WixToolset.Extensibility assembly
via NuGet package: `WixToolset.Extensibility`


### Burn

The Burn engine and its interfaces (`IBootstrapperEngine` and
`IBootstrapperApplication`) are separated into an independent repository
to be shared by both the `Core`, `Balutil` and the
`WixBalExtension` repositories.

This repository publishes `burnstub.exe` for the `Core` and
the NuGet package: `WixToolset.Bootstrapper.Interfaces`.


### Core

The `Core` is where the bulk of WiX Toolset development takes
place. This repository includes all command-line tools, MSBuild integration
(including DTF's custom action integration) and, of course, wix.dll.

This respository also builds the installation packages and
bundle for the WiX Toolset. The WiX Toolset bundle is the output
from this respository.


### Votive

The WiX Toolset's Visual Studio Extension, `Votive`, is separated from the `Core`
and distributed via the Visual Studio Marketplace. Doing so dramatically improves
the WiX Toolset's installation speed. Additionally, developers can install Votive
without installing the WiX Toolset and .sln's with .wixproj's will load cleanly.

This respository produces a VSIX for each version of Visual Studio supported,
namely: 2010, 2012, 2013, 2015 and 2017.


### WiX Extensions

Separating each WiX Extension into its own repository provides several benefits.
First, WiX Extensions are already very independent and would benefit from a
tight developer loop. Second, developers do not need to be overwhelmed with
the full WiX build process to work on a particular WiX Extension. Finally, a
WiX Extension release schedule would no longer be tied to the `Core` release
schedule.

When the `Core` bundle is created it will include the "last known good" of each
WiX Extension via an MSI package. WiX Extension repositories will also each output
an add-on bundle to the `Core` bundle that installs the WiX Extension's MSI
package. This allows WiX Extensions to upgrade the "last know good" provided
by the `Core`.


## Considerations

* While this reorganization optimizes for working within a focused subset of
the WiX Toolset, it does make fixing cross cutting issues much more difficult.
This is partly the goal (to create friction to changing public interfaces) but
we must recognize that it will be required at times. So work will need to be done
to help

* There are several ways to slice the DTF repositories. For example, all of the
respositories could be in a single `Dtf` repository or the respository could be
broken down further (for example, `Dtf.Compression`, `Dtf.Compression.Cab` and
`Dtf.Compression.Zip`). The current proposal attempts to strike a balance between
respository explosion and complete isolation of functionality.

* It is enticing to break out DTF's custom action host into its own
respository since it *never* changes and the only consumer is the `Core`. Still
considering if that is reasonable.

* The .NET Framework team [recently consolidated their CoreFX repositories into
a single respository][corefx]. That would suggest reorganizing our single repository
into many would be the wrong thing to do. We should keep in mind their "Primary
reasons for the changes" and make sure we do not repeat those mistakes. However,
this proposal focuses on reorganizing the WiX Toolset's repositories based on
layers. Our dependency graph has **never** looked [this bad][corefxgraph].


## See Also

* [WIXFEAT:5489 - Repository Reorganization][5489]

[5489]: https://github.com/wixtoolset/issues/issues/5489
[corefx]: https://github.com/dotnet/corefx/issues/15135
[corefxgraph]: https://cloud.githubusercontent.com/assets/715038/21939565/a232eeaa-d9c0-11e6-8298-e27d641eed3e.png
