---
draft: false
type: Feature
wip: 5377
by: "Bob Arnson (bob@firegiant.com)"
title: Deprecate and remove Package element
---

## Proposal

The split between the `Product` and `Package` elements is confusing and mostly
historical. At the same time, the `Package` element contains a number of
obsolete and/or questionably-useful attributes that mostly exist to allow WiX to
generate an arbitrary package. WiX v4.0 should 

* Rename the `Product` element to `Package` to better reflect the purpose of the element.
* Move common attributes from the old `Package` to the new `Package`.
* Move obscure attributes from the old `Package` to the new `SummaryInformation` element to better reflect its purpose.

| **Old Package attribute** | **Disposition**                                                                                                                                           |
|---------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------|
| AdminImage                | Eliminate. Its only use is in using WiX to construct an arbitrary database. The name encourages users to use it to try to create a package that elevates. |
| Comments                  | Eliminate. MSI SDK describes what it _should_ say.                                                                                                        |
| Compressed                | Move to Package/@Compressed.                                                                                                                              |
| Description               | Move to SummaryInformation.                                                                                                                               |
| Id                        | Move to Module/@Guid.                                                                                                                                     |
| InstallerVersion          | Move to Package/@InstallerVersion and Module/@InstallerVersion.                                                                                           |
| InstallPrivileges         | Eliminate.                                                                                                                                                |
| InstallScope              | Move to Package/@Scope.                                                                                                                                   |
| Keywords                  | Move to SummaryInformation.                                                                                                                               |
| Languages                 | Eliminate. WiX doesn't currently support multi-language merge modules and if that support were added, it would automatically take care of this value.     |
| Manufacturer              | Move to SummaryInformation.                                                                                                                               |
| Platform                  | Eliminate.                                                                                                                                                |
| Platforms                 | Eliminate.                                                                                                                                                |
| ReadOnly                  | Eliminate.                                                                                                                                                |
| ShortNames                | Move to Package/@ShortNames.                                                                                                                              |
| SummaryCodepage           | Move to SummaryInformation/@Codepage.                                                                                                                     |

## Considerations

WixCop needs to be updated to handle moving attributes as required.

## See Also

* [WIXFEAT:5377](https://github.com/wixtoolset/issues/issues/5377)