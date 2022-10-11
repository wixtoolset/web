---
wip: 5184
type: Feature
by: Rob Mensching (rob at firegiant.com)
title: Prevent DLL Hijacking Burn with Clean Room
---

## User stories

* As a WiX User I am confident my bundle executes securely.


## Proposal

To fully protect Burn from [DLL hijacking][hijack], several defenses must be implemented.

1. Randomized working folder - today the working folder is a fixed folder based on the Bundle Id. A randomized working folder is not vulnerable to static attacks against well-known bundles.

2. Delay load dependencies - all DLLs that are not loaded by Windows and not on the [KnownDlls list][knowndlls] must be marked for delay load in Burn to avoid DLL hijacking via the Import Address Table. For example, `cabinet.dll`, `msi.dll`, and `wininet.dll` all must be delay loaded.

3. [::SetDefaultDllDirectories()][setdefaultdll] - this function can remove the application folder and current working directory from the default DLL search order. This function is available on Windows 8+ and available by [patch][KB2533623] for Vista and Windows 7.

   Note: Due to a bug in GDI+, `::SetDefaultDllDirectories()` will not be called when the bundle loads a BA. In other words, `::SetDefaultDllDirectories()` will not be called when running from the clean room (see below) nor from package cache. Or said another way, `::SetDefaultDllDirectories()` will only be called when the process is running from an untrusted folder. See the Considerations below for more details.

4. Explicitly load system DLLs - since `::SetDefaultDllDirectories()` is not available for Windows XP, Burn will explicitly load a fixed set of DLLs from the system folder. Explicit loading is error prone because updates to Windows can change DLL dependencies and render the explicit load order in Burn irrelevant. For this reason, explicit loading will only be used for Windows XP because a) it is a "dead platform" (no updates from Microsoft) thus unchanging and b) there is no other alternative.

   When explicitly loading system DLLs, [::SetDllDirectory()][setdlldirectory] will be also be used to remove the current working directory from the search path.

5. Clean room the Burn engine - when executed from outside the package cache, Burn will copy its engine (the stub and UX container) to an empty working folder--called the "clean room"--and launch the engine again from there. Running the engine in the clean room ensures it is not possible to hijack the unknown set of DLLs a BA may load.

   Note: In WiX v3.11.0 and earlier, the "clean room" can still be DLL hijacked if malicious software is executing on the user's machine watching for a Burn bundle to launch elevated. Burn does not normally launch elevated so this attack requires the user to either manually launch the bundle elevated (i.e. Right click -> "Run as administrator") or some elevated software running as the user to launch the bundle elevated. This is not normal execution for Burn but releases after WiX v3.11.0 resolved this potential attack vector anyway.

6. Prevent naming bundle "setup.exe" - all executables named "setup.exe" are shimmed by Windows application compatibility to load additional DLLs, such as `version.dll`. The DLLs added by the app-compat shim can be hijacked. The only solution is to not name bundles "setup.exe".


## Considerations

1. Unmaintained Vista and Windows 7 machines are vulnerable. The required patch was released mid-2011, so any machine without the patch is likely vulnerable to other issues as well.

2. BAs using `::GetModuleFileName(NULL, ...)` will get a path in the clean room, not the untrusted source process path. To mitigate this, a `WixBundleSourceProcessPath` variable can be set by Burn when running in the clean room.

3. If not for the following Microsoft bugs, it would only be necessary to call `::SetDefaultDllDirectories()` and the complex mitigation steps 4 and 5 would be unnecessary. Unfortunately, Microsoft expressed little interest in fixing the following security vulnerabilities so we implemented the work arounds:

   * The CLR somehow ignores `::SetDefaultDllDirectories()` when loading its system DLLs. As a result, managed BAs are always be vulnerable. The clean room protects against this vulnerability in the CLR.

   * GDI+ fails in some cases when `::SetDefaultDllDirectories()` is used. As a result, a process that uses GDI+ must remain vulnerable to DLL hijacking. For example, BAs that use WinForms always hit the GDI+ bug. Again the clean room protects against the GDI+ vulnerability. However because the clean room process and package cache processes load the BA they *cannot* be protected by `::SetDefaultDllDirectories()`. Fortunately, clean room and package cache packages cannot be DLL hijacked.


## See Also

[Issue 5184](http://wixtoolset.org/issues/5184/)

[hijack]: https://en.wikipedia.org/wiki/Dynamic-link_library#DLL_hijacking

[setdefaultdll]: https://msdn.microsoft.com/en-us/library/windows/desktop/hh310515(v=vs.85).aspx

[setdlldirectory]: https://msdn.microsoft.com/en-us/library/windows/desktop/ms686203(v=vs.85).aspx

[knowndlls]: https://support.microsoft.com/en-us/kb/164501

[KB2533623]: https://support.microsoft.com/en-us/kb/2533623
