---
wip: 6108
type: Feature
by: Sean Hall (r sean hall at gmail.com)
title: .NET Core BA
draft: false
---

## User stories

* As a Setup developer I can write my Bootstrapper Application in .NET Core and then publish it SCD-style (Self Contained Deployment) such that I can write my BA in managed code without relying on anything being installed on the runtime machine.

* As a Setup developer I can write my Bootstrapper Application in .NET Core and then publish it FDD-style (Framework Dependent Deployment) such that I can write my BA in managed code on .NET Core and not bloat the bundle with the runtime.


## Proposal

Create a new BA in `BalExtension` named `DotNetCoreBootstrapperApplicationHost`.

Create new element `bal:WixDotNetCoreBootstrapperApplicationHost` based on `WixManagedBootstrapperApplicationHost`.

Add attribute `bal:SelfContainedDeployment` of `YesNoType` to the `WixDotNetCoreBootstrapperApplicationHost` element so the BA knows how to load the .NET Core Runtime. This is required because there is not a single API that can load the runtime from an SCD-style and an FDD-style deployment. If `no` and the runtime fails to load, it will show the `mbapreq`. If `yes` and the runtime fails to load (because it has native dependencies and relies on running on relatively up to date OS's), it will show an error message similarly to `ManagedBootstrapperApplicationHost` running on .NET 4.5.2 on Win7 RTM.

Add attribute `bal:BAFactoryAssembly` of `YesNoType` to the `Payload` element so the BA knows which assembly has the `BootstrapperApplicationFactoryAttribute`.


## Considerations

1) .NET Core provides multiple ways to host the runtime. The method for FDD-style deployments is `nethost` which is a Nuget package and will likely need to be updated regularly. Unfortunately, all hosting methods require copying a header file from the .NET Core repo into our repo.


## See Also

[WIXFEAT:6108](https://github.com/wixtoolset/issues/issues/6108)

[.NET Core deployment options](https://docs.microsoft.com/en-us/dotnet/core/deploying/)

[.NET Core runtime native Windows dependencies](https://docs.microsoft.com/en-us/dotnet/core/install/dependencies?pivots=os-windows)

[.NET Core custom host](https://docs.microsoft.com/en-us/dotnet/core/tutorials/netcore-hosting)
