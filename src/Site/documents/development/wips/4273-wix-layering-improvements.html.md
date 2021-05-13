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

Currently the `wix.dll` houses all the WiX Toolset's data access objects, extensibility interfaces and processors. The exposed programming surface area is very large and varied. It is difficult to understand what subset of objects are necessary to accomplish a task.

The single `wix.dll` also makes it easier for WiX developers to inadvertently create dependencies between objects that should remain isolated for extensibility purposes.

This proposal suggests breaking the single `wix.dll` into three assemblies and layering the programmatic surface area of the WiX toolset as follows:

* processes - wix.dll
* extensibility - WixToolset.Extensibility.dll
* data - WixToolset.Data.dll

Objects in higher layers may access objects in lower layers but not vice versa. Thus the `WixToolset.Data.dll` must stand alone but `WixToolset.Extensibility.dll` references the data assembly. This will help WiX developers from inadvertently creating improper dependencies up the layers.

Tools, such as candle and light, sit above the processes layer and can access objects in all three assemblies. WiX extension assemblies sit above the extensibility layer and can access objects in WixToolset.Data.dll and WixToolset.Extensibility.dll but not wix.dll.

## Considerations

The `WixToolset.Data.dll` should provide enough functionality to interpret the  WiX toolset output file formats such as .wixobj and .wixpdb. Care must be taken to not introduce any extra dependencies.

## See Also

* [WIXFEAT:4273](http://wixtoolset.org/issues/4273/)
