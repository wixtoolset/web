---
wip: 6401
type: Feature
by: Rob Mensching (rob at firegiant.com)
title: Source patch files from MSIs
---

## User stories

* As a setup developer I can create an MSP using my target MSI and updated MSI files.


## Proposal

In WiX v3, each step of the patch creation process was exposed to the developer. The following is an over simplified set of steps:

1. The Patch source code is written to define the patch baselines.
2. The source code is compiled and linked into an intermediate output.
3. The transform between the target and updated MSI/wixpdb is created. This is repeated for each baseline defined in step 1.
4. The MSP is created from the intermediate output from step 2 and transforms from step 3 (repeated).

This process has several points where files must be referenced just right or the process fails. There are also strict requirements
where for the source files are expected, requiring an MSI admin image or use of bindpaths on all files in the .wixpdb so they can be re-resolved
during patch creation. Additional tooling was provided in later versions of WiX v3, melt.exe, but the patch creation process is very
brittle.

In WiX v4, the patch process is simplified to a single `build` command of Patch source code. Baselines are still defined in the source code but now
directly reference the target and updated MSI/wixpdb files. This allows the `build` command creates the necessary transforms and the MSP in one pass.
To complete the simplification of the patch build process, WiX v4 will not only find files when MSIs admin images and .wixpdb bindpaths but also be
able extract files from an MSI's cabinets even when embedded.

During the `build` process, target and updated files are resolved before the transforms are created. This does require all files to
be available when patching in WiX v4, where careful crafting of the patch inputs could mininize the number of files required to be
present in WiX v3. Additionally, bind paths are only used to locate files when an .wixpdb is used as the baseline's target and/or updated
input. When an MSI is used as the baseline's target and/or updated input, the files must be found relative to the MSI.

## Considerations

* The exposed nature of the patch creation build process in WiX v3, means it was possible to create very intricate processes that may
not directly translate in WiX v4. Future versions of WiX may need to introduce additional options to the patch `build` command to
optimize file handling.


## See Also

* [WIXFEAT:6401](http://wixtoolset.org/issues/6401)
