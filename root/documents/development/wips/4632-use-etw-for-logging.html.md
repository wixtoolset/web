---
wip: 4632
type: Feature
author: Heath Stewart (heaths@microsoft.com)
title: Use ETW for Logging
---

## User stories

* As a developer I can use the existing Trace and Exit macros to write events to a trace listener.
* As a developer I can conditionally write computationally expensive events to a trace listener.
* As a developer I can write events to a trace listener without having to link additional string resources.
* As an administrator I can enable and view additional logging details on the local or remote machines.
* As an administrator I can trigger actions on certain events.

## Current design

Our current design is pretty straight forward but relies on compile-time overrides for logging targets. This means that any Trace or Exit macros used in libraries like _dutil.lib_ cannot be redirected to, say, a log file created and written to by burn. Additionally, some logging we have avoided because of the size added by string resources and additional computation required by functions like `PlanDump` in _engine.lib_ only when `#DEBUG` is defined. These log events are often useful for debugging issues with release binaries in the field.

The existing macros as of v3.10 are now variadic, which means they can take any number of arguments without using different macro definitions. This can also make it easy to shoe-horn different functions to call and still use the existing macros that are in heavy use throughout the code.

## Proposal

ETW provides a powerful facility for logging event data that different listeners - including the running executable itself, such as _burn.exe_ - can choose to write to a log file or any other output.

We can create an [event provider][providing events] for each library such as _dutil.lib_ and _engine.lib_ that can be enabled and disabled by administrators as needed, while _burn.exe_ maintains the ability to enable them in-proc and write all events to the burn log. An additional provider (because, it seems, a manifest and its resources cannot be split across providers) can be created for more advanced logging like `PlanDump`, which _engine.lib_ can calculate conditionally if the provider is enabled using `EventProviderEnabled`. The need for this may not be necessary, however, since ETW manifests can contain mappings for enumerations that automatically log the string resource for the passed enumeration value.

Managed code can also use these facilities through the [APIs][System.Diagnostics.Tracing] provided in .NET or the more powerful [Microsoft.Diagnostics.Tracing.EventSource][] NuGet package that enables writing to the Windows Event log by default.

Since we have a great number of string resources already and because ETW appears to support referencing string resources by using the `mc` prefix like in the following example, we can actually keep the _\*.mc_ files we currently compile and link and even add to them later. The major difference will be that toolset developers will have to add an entry to the event manifest as well as the _\*.mc_ file, or use the `string` prefix instead and define them in the manifest (which, when compiled by _mc.exe_, will output a resource DLL anyway).

    <!-- reference a string resource defined in a resource DLL already -->
    <provider name="$(mc.ProviderName)" .../>

    <!-- reference a string resource defined in the manifest -->
    <provider name="$(string.ProviderName)" .../>

For more information, see [localizing message strings][].

## Considerations

The existing Exit and Trace functions - along with the Log functions - should be updated to call `EventWrite` and related functions passing in the variadic `__VA_ARGS__`, though in this case you'll lose IntelliSense help for variable names and types. We could update the build system to generate the headers required for developers to call the specific functions if we care to.

The `mc` localized string resource prefix is also not well-documented, though references to it exist in MSDN. So we should be okay to use it, though some additional prototyping may be necessary to accurately discover whether resources must be embedded or separate.

Most importantly, though, is that ETW is only supported in Windows Vista and newer. Windows XP - which WiX v3 still supports - only supports the older [event logging][] APIs which were rebuilt on top of ETW starting with Windows Vista. If we choose to support Windows XP with WiX v4 we can either,

* Use only [event logging][] APIs, or
* Conditionally use [event tracing][] APIs if on Vista

The drawbacks to using the [event logging][] APIs are a limited feature set, the need to write WMI manifests (_\*.mof_ files), and the lack of conditional logging.

For example, MSDN documentation purports that mappings are not supported by the [event logging][] APIs, though some prototyping has shown that _mc.exe_ does mostly generate _\*.mof_ files with WMI attributes to support mappings - the only thing missing is the friendly string names (which would require further post-processing). The enumeration values are attributed to the corresponding symbols.

## See also

* [WIXFEAT:4632][]
* [Event tracing][]
* [Providing events][]
* [Localizing message strings][]
* [System.Diagnostics.Tracing][]
* [Microsoft.Diagnostics.Tracing.EventSource][]
* [Event logging][]

[WIXFEAT:4632]: http://wixtoolset.org/issues/4632/
[Event tracing]: http://msdn.microsoft.com/en-us/library/windows/desktop/bb968803(v=vs.85).aspx
[Providing events]: http://msdn.microsoft.com/en-us/library/windows/desktop/aa364098(v=vs.85).aspx
[Localizing message strings]: http://msdn.microsoft.com/en-us/library/windows/desktop/dd996927(v=vs.85).aspx
[System.Diagnostics.Tracing]: http://msdn.microsoft.com/en-us/library/system.diagnostics.tracing(v=vs.110).aspx
[Microsoft.Diagnostics.Tracing.EventSource]: https://www.nuget.org/packages/Microsoft.Diagnostics.Tracing.EventSource
[Event logging]: http://msdn.microsoft.com/en-us/library/windows/desktop/aa363652(v=vs.85).aspx
