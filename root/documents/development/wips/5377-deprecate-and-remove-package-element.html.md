---
draft: false
type: Feature
wip: "5377"
by: "Bob Arnson (bob@firegiant.com)"
title: Deprecate and remove Package element
---

## Proposal

The split between the `Product` and `Package` elements is confusing and mostly
historical. At the same time, the `Package` element contains a number of
obsolete and/or questionably-useful attributes that mostly exist to allow WiX to
generate an arbitrary package. WiX v4.0 should remove the `Package` element,
moving its useful attributes to `Product` and eliminating the rest.

| **Package attribute** | **Disposition**                                                                                                                                                                                                                                                               |
|-----------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| AdminImage            | Eliminate. Its only use is in using WiX to construct an arbitrary database. The name encourages users to use it to try to create a package that elevates.                                                                                                                     |
| Comments              | Eliminate. MSI SDK describes what it “should” say.                                                                                                                                                                                                                            |
| Compressed            | Move to Product/\@Compressed and Module/\@Compressed.                                                                                                                                                                                                                         |
| Description           | ???                                                                                                                                                                                                                                                                           |
| Id                    | Eliminate.                                                                                                                                                                                                                                                                    |
| InstallerVersion      | Move to Product/\@InstallerVersion and Module/\@InstallerVersion.                                                                                                                                                                                                             |
| InstallPrivileges     | Eliminate.                                                                                                                                                                                                                                                                    |
| InstallScope          | Move to Product/\@Scope and Module/\@Scope.                                                                                                                                                                                                                                   |
| Keywords              | ???                                                                                                                                                                                                                                                                           |
| Languages             | Eliminate. Extend Product/\@Language and Module/\@Language instead to set the summary information. (Assumes multilanguage merge modules, if we want to support constructing them, have a way of adding multiple languages to the summary information template summary field.) |
| Manufacturer          | Eliminate. Little need to differentiate between Product/\@Manufacturer and package summary information which “should be” the same anyway.                                                                                                                                     |
| Platform              | Eliminate.                                                                                                                                                                                                                                                                    |
| Platforms             | Eliminate.                                                                                                                                                                                                                                                                    |
| ReadOnly              | Eliminate.                                                                                                                                                                                                                                                                    |
| ShortNames            | ???                                                                                                                                                                                                                                                                           |
| SummaryCodepage       | Eliminate. Extend Product/\@Language and Module/\@Language instead to set the summary information.                                                                                                                                                                            |

## Considerations

WixCop needs to be updated to handle moving attributes as required.

## See Also

* [WIXFEAT:5377](https://github.com/wixtoolset/issues/issues/5377)