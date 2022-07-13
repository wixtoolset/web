---
wip: 4273
type: Feature
by: Rob Mensching (rob at firegiant.com)
title: WiX Layering Improvements
---

## User stories

* As an WiX extension developer I can develop an extension such that it is clear which APIs I should be using in my extension.

* As a WiX developer I consider the implications of the code I am modifying such that extension developers are not inadvertently impacted.


## Proposal

Currently the `wix.dll` houses all the WiX Toolset's data access objects, extensibility interfaces and processing. The exposed programming surface area is very large and varied. It is difficult to understand what subset of objects are necessary to accomplish a task.

The single `wix.dll` also makes it easier for WiX developers to inadvertently create dependencies between objects that should remain isolated for extensibility purposes.

This proposal suggests breaking the single `wix.dll` into five assemblies to layer the programmatic surface area of the WiX toolset.

* Specialized Processing - WixToolset.Core.Burn.dll & WixToolset.Core.WindowsInstaller.dll
* Common Processing - WixToolset.Core.dll
* Extensibility - WixToolset.Extensibility.dll
* Data - WixToolset.Data.dll

Objects in higher layers may access objects in lower layers but not vice versa. Similarly, objects in the same layer may not access each other. Thus the `WixToolset.Data.dll` must stand alone but `WixToolset.Extensibility.dll` references the data assembly. This will help WiX developers from inadvertently creating improper dependencies up the layers.

Tools, such as `wix.exe`, sit above the specialized processing layer and can access objects in both of these assemblies and those below. WiX extension assemblies, such as `WixToolset.Util.wixext.dll`, sit above the extensibility layer and can access objects in `WixToolset.Data.dll` and `WixToolset.Extensibility.dll` but not `WixToolset.Core.dll` (and above).


## Considerations

The `WixToolset.Data.dll` should provide enough functionality to interpret the WiX toolset output file formats such as .wixobj and .wixpdb. Care must be taken to not introduce any extra dependencies.


## See Also

* [WIXFEAT:4273](http://wixtoolset.org/issues/4273/)
