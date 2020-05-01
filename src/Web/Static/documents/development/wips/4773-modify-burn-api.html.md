---
wip: 4773
type: Feature
by: Sean Hall (r sean hall at gmail.com)
title: Modify Burn API
draft: false
---

## User stories

* As a WiX Developer I can add methods (or add parameters to methods) to the Burn API such that WiX Users can continue to compile their custom Bootstrapper Application after upgrading the WiX Toolset without making any changes (adding methods and adding parameters are never breaking changes).

* As a WiX User I can use my compiled custom Bootstrapper Application with any later version of the WiX Toolset with the same major version (the Burn API will maintain binary compatibility).


## Background

The Burn engine works with the Bootstrapper Application to handle the Bundle's installation operations.
The unelevated engine and the BA live in the same process.
There needed to be a way for the engine and the BA to communicate to each other, and it had to be something that unmanaged code could use as well as managed.

In the first version of Burn (WiX v3.x), the engine exposed its functionality through the IBootstrapperEngine COM interface, and called into the BA through the IBootstrapperApplication COM interface.
As newer version were released, methods were added and modified to IBootstrapperApplication.
The first changes were in v3.7, they modified existing methods and added new ones.
Due to the feedback from WiX Users when upgrading, the WiX team tried to leave the interfaces alone.
In v3.9, the WiX team allowed some new methods to be added as well as adding a default parameter to an existing method (maintaining "compile time" compatibility but not binary compatibility).
This brought in multiple bug reports from users where their bundle crashed because of compiling their BA against the wrong version of the toolset.


## Proposal

I propose that Burn offers two options when developing a custom BA: message based or interface based.
Using messages with structs that have a cbSize member is a proven way to maintain an API that can be extended over time.
This also gives the benefit of maintaining binary compatibility between releases.
The interface option would be an abstraction layer provided by the toolset to hide the fact that the engine is sending messages instead of making calls on a COM interface.

I propose that we swap the guarantees we give today on the interfaces: a BA compiled to the COM interface will be binary compatible to future releases, but the interface can be changed between releases.
Since the COM interfaces will use the messages behind the scenes, binary compatibility is free.
I believe that WiX Users would be willing to accept that upgrading the toolset that the BA is compiled against may require modification of their source code, because they could upgrade the Bundle's toolset independently of the BA's toolset (since they'll probably use Nuget to provide the headers for their BA).

## Native BA

### WiX 3.x

The native BA would link in the `balutil` library and implement `IBootstrapperApplication` by extending from `BalBaseBootstrapperApplication`.
The BA would return this `IBootstrapperApplication` to the engine from `BootstrapperApplicationCreate`.
In the bundle authoring, the BA dll would be used as the `SourceFile` in the `BoostrapperApplication` element.


### WiX 4.x

The native BA links in the `balutil` library from the WixToolset.BalUtil nuget package.
This requires also bringing in the WixToolset.BootstrapperCore.Native nuget package.
The BA gets an `IBootstrapperEngine` instance by passing in the `BOOTSTRAPPER_CREATE_ARGS` to `BalInitializeFromCreateArgs`.
The BA still implements `IBootstrapperApplication` by extending from `BalBaseBootstrapperApplication`.
In `BootstrapperApplicationCreate`, the BA sets `pfnBootstrapperApplicationProc` to `BalBaseBootstrapperApplicationProc` and `pvBootstrapperApplicationProcContext` to their BA.
In the bundle authoring, the BA dll is still used as the `SourceFile` in the `BoostrapperApplication` element.
When implemented this way, upgrading to a new version of WixToolset.BalUtil in the same major version would only potentially be a breaking change if a new parameter is added to an existing method in `IBootstrapperApplication` or `IBootstrapperEngine`.
An example of a real native BA is `wixstdba` in [BalExtension](https://github.com/wixtoolset/Bal.wixext/tree/master/src/wixstdba).

It is technically possible to write a native BA against the message based API instead of the COM API.
This kind of BA would get both "compile-time" compatibility and binary compatibility.
It is expected to be very rare to choose this.

## Managed BA

### WiX 3.x

The toolset only had support for a managed BA written in .NET Framework, not .NET Core.
The BA would reference `BootstrapperCore.dll` and create a subclass of `Microsoft.Tools.WindowsInstallerXml.Bootstrapper.BootstrapperApplication`.
The BA would use this subclass's type in the `Microsoft.Tools.WindowsInstallerXml.Bootstrapper.BootstrapperApplicationAttribute` assembly attribute.
The BA would include this assembly's name and target .NET Framework in a .NET Framework .config file.
In the bundle authoring, the BA dll would be included as a payload in a `BootstrapperApplicationRef` to `ManagedBootstrapperApplicationHost`.
The .config file would also be a payload there, with the required name of `BootstrapperCore.config`.
All of the BA's dependencies were also required as payloads there, with the exception of `BootstrapperCore.dll`.
The BalExtension injected its version of `BootstrapperCore.dll`.

### WiX 4.x

The toolset has support for both .NET Framework and .NET Core.
`BootstrapperCore.dll` has been broken up.
The host specific code has been moved to `WixToolset.Mba.Host.dll` (`WixToolset.Dnc.Host.dll` for .NET Core), and the rest into `WixToolset.Mba.Core.dll`.
`WixToolset.Mba.Core.dll` relies on the new native `mbanative.dll` for the mapping of messages to the COM interfaces.
`WixToolset.Mba.Core.dll` (and `WixToolset.Mba.Host.dll`) targets .NET Framework 2.0 to be able to support managed BAs on all supported .NET platforms.
`WixToolset.Dnc.Host.dll` targets .NET Core 3.0, since that version of the framework added UI frameworks and sufficiently high-level custom hosting APIs.

The BA references `WixToolset.Mba.Core.dll` from the WixToolset.Mba.Core nuget package.
The BA creates a subclass of `WixToolset.Mba.Core.BootstrapperApplication`.
The BA creates a subclass of `WixToolset.Mba.Core.BaseBootstrapperApplicationFactory`.
The BA uses this subclass's type in the `WixToolset.Mba.Core.BaseBootstrapperApplicationFactoryAttribute` assembly attribute.

#### .NET Framework

The BA includes this assembly's name and target .NET Framework in a .NET Framework .config file.
In the bundle authoring, the BA dll is included as a payload in a `BootstrapperApplicationRef` to `ManagedBootstrapperApplicationHost`.
The .config file is also be a payload there, with the required name of `WixToolset.Mba.Host.config`.
All of the BA's dependencies are also required as payloads there, including `WixToolset.Mba.Core.dll` and `mbanative.dll`.
The BalExtension injects its version of `WixToolset.Mba.Host.dll`.

#### .NET Core

The BA project must be an application, not a library (target netcoreapp3.0 or later, not netstandard).
The BA project must be published, not only built.
The BA project must have `EnableDynamicLoading` set to `true` so the SDK generates the .runtimeconfig.json file.
If the BA project has `PublishTrimmed` set to true, it must have <TrimmerRootAssembly Include="System.Runtime.Loader" /> since the host requires it.
In the bundle authoring, the BA dll is included as a payload in a `BootstrapperApplicationRef` to `DotNetCoreBootstrapperApplicationHost` with the attribute `bal:BAFactoryAssembly` set to `yes`.
The .deps.json, .runtimeconfig.json, and all dependencies are also required as payloads there, including `WixToolset.Mba.Core.dll` and `mbanative.dll`.
If published as self-contained, the `SelfContainedDeployment` attribute must be set to `yes` on the `bal:WixDotNetCoreBootstrapperApplication` element.
The BalExtension injects its version of `WixToolset.Dnc.Host.dll`.

#### Both runtimes

When implemented this way, upgrading to new versions of WixToolset.Mba.Core shouldn't be breaking since `BootstrapperApplication` exposes the interface as events.
There are no real managed BA's in v4, but there are examples of .NET Framework 2.0, .NET Framework 4.0, and .NET Core in the [BalExtension tests](https://github.com/wixtoolset/Bal.wixext/tree/master/src/test).

## Considerations


## See Also

[Issue 4773](http://wixtoolset.org/issues/4773/)