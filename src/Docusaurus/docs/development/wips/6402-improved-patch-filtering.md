---
wip: 6402
type: Feature
by: Rob Mensching (rob at firegiant.com)
title: Improved patch filtering
---

## User stories

* As a setup developer I can use patch families to filter an MSP without placing every Component, Feature, and CustomAction in a separate Fragment.


## Proposal

In WiX v3, filtering in MSPs was dependent on the fragmentation, more technically the sections, of the source code. To include only content from a single
`Component` required the `Component` to be in a standalone `Fragment`. This could lead to _extremely_ fragmented source code that was ugly and difficult
to maintain.

However, later in WiX v3, `melt.exe` added a feature to automatically create sections (aka: fragmentation) from an MSI admin image. Feedback on this
fragmentation process was positive as it aligned with developers expecations for patch filtering behavior.

In WiX v4, with the simplified patch build process, the input MSIs and/or .wixpdbs will always pass through the same automatic fragmentation process
from `melt.exe`. Any sections defined in the .wixpdb are ignored. The end result is a patch filtering that behaves as developers expect rather than
along section boundaries.


## Considerations

* The section-based filtering allowed for complete control over patch filtering. So, while there are no known cases where the automatic fragmentation process
was not equally sufficient, it is possible section-based filtering might be desired by a user. In that case, a WixExtension can use the IWindowsInstallerBackendBinderExtension.FinalizePatchFilterIds
extension point to programmatically modify the automatic fragmentation as needed.


## See Also

* [WIXFEAT:6402](http://wixtoolset.org/issues/6402)
