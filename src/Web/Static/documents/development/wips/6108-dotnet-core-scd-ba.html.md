---
wip: 6108
type: Feature
by: Sean Hall (r sean hall at gmail.com)
title: .NET Core SCD-style BA
draft: false
---

## User stories

* As a Setup developer I can write my Bootstrapper Application in .NET Core and then publish it SCD-style such that I can write my BA in managed code without relying on anything being installed on the runtime machine.


## Proposal

Create a new BA in `BalExtension` named `DotNetCoreBootstrapperApplicationHost`. In this first iteration, the BA must provide the .NET Core runtime so that the .NET Core host doesn't have to have any logic in figuring out the correct runtime to use.


## Considerations

1) The test BA is currently 59MB and 228 files. Some people may want the functionality of `mbahost` where it can load a runtime installed on the machine and fallback to `mbapreq` BA, which allows them to avoid bundling the .NET Core runtime. This may prove to be tricky since the entry point is the WiX provided WixToolset.Mba.Host.dll, which currently is a .NET Framework 2.0 dll.

2) The .NET Core runtime has native dependencies and relies on running on relatively up to date OS's. The bundle will silently fail if it can't load the runtime.

3) `dnchost` relies on the same configuration file as `mbahost` to find the BA assembly, even though .NET Core doesn't have native support for app.config files. Perhaps that should be moved into the WiX authoring and put into the `BoostrapperApplicationData` xml file.

4) .NET Core provides multiple ways to host the runtime. Because this first iteration requires the runtime to be provided with the BA and thus the location of `CoreCLR.dll` is known, `dnchost` uses the `ICLRRuntimeHost4` method to make sure that that runtime is used. Unfortunately, all hosting methods require copying a header file from the .NET Core repo into our repo.


## See Also

[WIXFEAT:6108](https://github.com/wixtoolset/issues/issues/6108)

[.NET Core deployment options](https://docs.microsoft.com/en-us/dotnet/core/deploying/)

[.NET Core runtime native Windows dependencies](https://docs.microsoft.com/en-us/dotnet/core/install/dependencies?pivots=os-windows)

[.NET Core custom host](https://docs.microsoft.com/en-us/dotnet/core/tutorials/netcore-hosting)
