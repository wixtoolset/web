---
wip: 6838
type: Feature
by: Rob Mensching (rob at firegiant.com)
title: Organized obsolescence of Heat in v4
---

## User stories

* As a setup developer I can migration v3 harvesting functionality that works in CI/CD builds with v4.

* As a WiX developer I can isolate Heat from the core tools such that I can deprecate and replace Heat with better code generation technology in a future release.


## Proposal

`heat.exe` and its MSBuild targets (`HeatDirectory`, `HeatFile`, `HeatProject`)--collectively referenced as "Heat" hereafter--are highly desired features by setup developers.
Unfortunately, there are a few issues with Heat. Some of these are long standing and some are new in WiX v4:

1. Heat was designed to be run manually and the generated .wxs code checked in to source control, which is not how the tool is generally used.
2. Heat is built on the WiX CodeModel which is an outdated design choice and obsolete in WiX v4.
3. Some Heat features require the .NET Framework to work.

Given the popularity of code generation at build-time, we need to entirely re-evaluate the current workflow provided by "Heat" and design a better implementation.
However, this re-evaluation work will not be undertaken in WiX v4.
So the existing Heat functionality will need to be preserved to enable migration from v3 to v4.
At the same time, we need to start the process of obsoleting Heat in v4 to telegraph its removal in a future release.

To that end, Heat will be isolated in a separate NuGet package: `WixToolset.Heat`.
A NuGet package is used because it can integrate with MSBuild and `nuget.exe` can deliver the Heat binaries to all Windows-based CI/CD systems.

To integrate the MSBuild targets, a `PackageReference` item to `WixToolset.Heat` in a v4 .wixproj should be all that is necessary for the targets to work.

For use outside of MSBuild, `heat.exe` can be acquired via `nuget.exe install WixToolset.Heat` and the executable will available in the `WixToolset.Heat\tools\<tfm>` folder.


## Considerations

* If an installation package (MSI/Bundle) is provided for WiX v4, then `heat.exe` should also be included with `wix.exe`, `thmviewer.exe`, etc.

* In v4, `wix.exe` absorbed the functionality of all the v3 executables (`candle.exe`, `light.exe`, `smoke.exe`, `pyro.exe`) as commands (or subcommands of commands) except for `heat.exe`. Given this evolution during v4 converting `heat.exe` to a `generate` (or `harvest`) command would be logical. However, given the plant to re-evaluate the code generation process in a future release it is better to isolate a standalone `heat.exe` than give false expectations that code generation will necessarily be a `wix.exe` command.


## See Also

* [WIXFEAT:6838](http://wixtoolset.org/issues/6838)
