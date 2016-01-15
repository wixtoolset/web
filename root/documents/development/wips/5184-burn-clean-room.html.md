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

1. Randomized working folder - today the working folder is a fixed folder based on the Bundle Id. A randomized working folder is not vulnerable to static attacks against well known bundles.

1. Delay load dependencies - all DLLs that are not loaded by Windows and not on the [KnownDlls list] must be marked for delay load in Burn to avoid DLL hijacking via the Import Address Table. For example, `cabinet.dll`, `msi.dll`, and `wininet.dll` all must be delay loaded.

2. [::SetDefaultDllDirectories()][setdefaultdll] - this function can remove the application folder and current working directory from the default DLL search order. This function is available on Windows 8+ and available by [patch][KB2533623] for Vista and Windows 7.

3. Explicitly load system DLLs - since `::SetDefaultDllDirectories()` is not available for Windows XP, Burn will explicitly load a fixed set of DLLs from the system folder. Explicitly loading is error prone because changes to the system can change DLL dependencies and render the fixed order in Burn irrelevant. For this reason, explicitly loading is only be used for Windows XP because it is a "dead platform" (no updates from Microsoft) and thus unchanging and, honestly, because there is no other alternative.

  When explicitly loading system DLLs, [::SetDllDirectory()][setdlldirectory] will be also be used to remove the current working directory from the search path since where supported.

4. Clean room the Burn engine - when launched Burn copies its engine (the stub and UX container) to an empty working folder--called the "clean room"--and launches the engine again from there. The "clean room engine" ensures it is not possible to hijack the unknown set of DLLs a BA may load.


## Considerations

1. Unmaintained Vista and Windows 7 machines are vulnerable. The required patch was released mid-2011, so any machine without the patch is likely vulnerable to other issues as well.

2. BAs using `::GetModuleFileName(NULL, ...)` will get a path in the clean room, not the true source folder. To mitigate this, a `WixBundleSourceProcessPath` variable can be set by Burn when running in the clean room.

3. Random note: when available `::SetDefaultDllDirectories()` should be all that is necessary to protect Burn. Unfortunately, the CLR ignores `::SetDefaultDllDirectories()` when loading its system DLLs so managed BAs would always be vulnerable without the clean room. For that reason, the clean room must always used.


## See Also

[Issue 5184](http://wixtoolset.org/issues/5184/)

[hijack]: https://en.wikipedia.org/wiki/Dynamic-link_library#DLL_hijacking

[setdefaultdll]: https://msdn.microsoft.com/en-us/library/windows/desktop/hh310515(v=vs.85).aspx

[setdlldirectory]: https://msdn.microsoft.com/en-us/library/windows/desktop/ms686203(v=vs.85).aspx

[knowndlls]: https://support.microsoft.com/en-us/kb/164501

[KB2533623]: https://support.microsoft.com/en-us/kb/2533623