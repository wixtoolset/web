---
sidebar_position: 40
---

# Windows information custom actions

The [QueryWindowsDirectories](../../schema/util/querywindowsdirectories.md), [QueryWindowsDriverInfo](../../schema/util/querywindowsdriverinfo.md), [QueryWindowsSuiteInfo](../../schema/util/querywindowssuiteinfo.md), and [QueryWindowsWellKnownSIDs](../../schema/util/querywindowswellknownsids.md) elements in the [Util schema](../../schema/util/index.md) schedule custom actions that query the system and set properties based on those queries.


## QueryWindowsDirectories properties {#querywindowsdirectories}


| Property | Description |
| -------- | ----------- |
| WIX_DIR_ADMINTOOLS | Per-user administrative tools directory. Equivalent to the SHGetFolderPath CSIDL_ADMINTOOLS flag. |
| WIX_DIR_ALTSTARTUP | Per-user nonlocalized Startup program group. Equivalent to the SHGetFolderPath CSIDL_ALTSTARTUP flag. |
| WIX_DIR_CDBURN_AREA | Per-user CD burning staging directory. Equivalent to the SHGetFolderPath CSIDL_CDBURN_AREA flag. |
| WIX_DIR_COMMON_ADMINTOOLS | All-users administrative tools directory. Equivalent to the SHGetFolderPath CSIDL_COMMON_ADMINTOOLS flag. |
| WIX_DIR_COMMON_ALTSTARTUP | All-users nonlocalized Startup program group. Equivalent to the SHGetFolderPath CSIDL_COMMON_ALTSTARTUP flag. |
| WIX_DIR_COMMON_DOCUMENTS | All-users documents directory. Equivalent to the SHGetFolderPath CSIDL_COMMON_DOCUMENTS flag. |
| WIX_DIR_COMMON_FAVORITES | All-users favorite items directory. Equivalent to the SHGetFolderPath CSIDL_COMMON_FAVORITES flag. |
| WIX_DIR_COMMON_MUSIC | All-users music files directory. Equivalent to the SHGetFolderPath CSIDL_COMMON_MUSIC flag. |
| WIX_DIR_COMMON_PICTURES | All-users picture files directory. Equivalent to the SHGetFolderPath CSIDL_COMMON_PICTURES flag. |
| WIX_DIR_COMMON_VIDEO | All-users video files directory. Equivalent to the SHGetFolderPath CSIDL_COMMON_VIDEO flag. |
| WIX_DIR_COOKIES | Per-user Internet Explorer cookies directory. Equivalent to the SHGetFolderPath CSIDL_COOKIES flag. |
| WIX_DIR_DESKTOP | Per-user desktop directory. Equivalent to the SHGetFolderPath CSIDL_DESKTOP flag. |
| WIX_DIR_HISTORY | Per-user Internet Explorer history directory. Equivalent to the SHGetFolderPath CSIDL_HISTORY flag. |
| WIX_DIR_INTERNET_CACHE | Per-user Internet Explorer cache directory. Equivalent to the SHGetFolderPath CSIDL_INTERNET_CACHE flag. |
| WIX_DIR_MYMUSIC | Per-user music files directory. Equivalent to the SHGetFolderPath CSIDL_MYMUSIC flag. |
| WIX_DIR_MYPICTURES | Per-user picture files directory. Equivalent to the SHGetFolderPath CSIDL_MYPICTURES flag. |
| WIX_DIR_MYVIDEO | Per-user video files directory. Equivalent to the SHGetFolderPath CSIDL_MYVIDEO flag. |
| WIX_DIR_NETHOOD | Per-user My Network Places link object directory. Equivalent to the SHGetFolderPath CSIDL_NETHOOD flag. |
| WIX_DIR_PERSONAL | Per-user documents directory. Equivalent to the SHGetFolderPath CSIDL_PERSONAL flag. |
| WIX_DIR_PRINTHOOD | Per-user Printers link object directory. Equivalent to the SHGetFolderPath CSIDL_PRINTHOOD flag. |
| WIX_DIR_PROFILE | Per-user profile directory. Equivalent to the SHGetFolderPath CSIDL_PROFILE flag. |
| WIX_DIR_RECENT | Per-user most recently used documents shortcut directory. Equivalent to the SHGetFolderPath CSIDL_RECENT flag. |
| WIX_DIR_RESOURCES | All-users resource data directory. Equivalent to the SHGetFolderPath CSIDL_RESOURCES flag. |


## QueryWindowsDriverInfo properties {#querywindowsdriverinfo}

| Property | Description |
| -------- | ----------- |
| WIX_WDDM_DRIVER_PRESENT | Set to 1 if the video card driver on the target machine is a WDDM driver. This property is set only on machines running Windows Vista or later. |
| WIX_DWM_COMPOSITION_ENABLED | Set to 1 if the target machine has composition enabled. This property is set only on machines running Windows Vista or later. |


## QueryWindowsSuiteInfo properties {#querywindowssuiteinfo}

QueryWindowsSuiteInfo sets one or more of the following session properties for [the product suites available on the system](https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-osversioninfoexw) or [system metrics](https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getsystemmetrics).

| Property | Description |
| -------- | ----------- |
| WIX_SUITE_BACKOFFICE | Equivalent to the OSVERSIONINFOEX VER_SUITE_BACKOFFICE flag. |
| WIX_SUITE_BLADE | Equivalent to the OSVERSIONINFOEX VER_SUITE_BLADE flag. |
| WIX_SUITE_COMMUNICATIONS | Equivalent to the OSVERSIONINFOEX VER_SUITE_COMMUNICATIONS flag.|
| WIX_SUITE_COMPUTE_SERVER | Equivalent to the OSVERSIONINFOEX VER_SUITE_COMPUTE_SERVER flag. |
| WIX_SUITE_DATACENTER | Equivalent to the OSVERSIONINFOEX VER_SUITE_DATACENTER flag. |
| WIX_SUITE_EMBEDDEDNT | Equivalent to the OSVERSIONINFOEX VER_SUITE_EMBEDDEDNT flag. |
| WIX_SUITE_EMBEDDED_RESTRICTED | Equivalent to the OSVERSIONINFOEX VER_SUITE_EMBEDDED_RESTRICTED flag. |\
| WIX_SUITE_ENTERPRISE | Equivalent to the OSVERSIONINFOEX VER_SUITE_ENTERPRISE flag. |
| WIX_SUITE_MEDIACENTER | Equivalent to the GetSystemMetrics SM_SERVERR2 flag. |
| WIX_SUITE_PERSONAL | Equivalent to the OSVERSIONINFOEX VER_SUITE_PERSONAL flag. |
| WIX_SUITE_SECURITY_APPLIANCE | Equivalent to the OSVERSIONINFOEX VER_SUITE_SECURITY_APPLIANCE flag. |
| WIX_SUITE_SERVERR2 | Equivalent to the GetSystemMetrics SM_SERVERR2 flag. |
| WIX_SUITE_SINGLEUSERTS | Equivalent to the OSVERSIONINFOEX VER_SUITE_SINGLEUSERTS flag. |
| WIX_SUITE_SMALLBUSINESS | Equivalent to the OSVERSIONINFOEX VER_SUITE_SMALLBUSINESS flag. |
| WIX_SUITE_SMALLBUSINESS_RESTRICTED | Equivalent to the OSVERSIONINFOEX VER_SUITE_SMALLBUSINESS_RESTRICTED flag. |
| WIX_SUITE_STARTER | Equivalent to the GetSystemMetrics SM_STARTER flag. |
| WIX_SUITE_STORAGE_SERVER | Equivalent to the OSVERSIONINFOEX VER_SUITE_STORAGE_SERVER flag. |
| WIX_SUITE_TABLETPC | Equivalent to the GetSystemMetrics SM_TABLETPC flag. |
| WIX_SUITE_TERMINAL | Equivalent to the OSVERSIONINFOEX VER_SUITE_TERMINAL flag. |
| WIX_SUITE_WH_SERVER | Windows Home Server. Equivalent to the OSVERSIONINFOEX VER_SUITE_WH_SERVER flag. |


## QueryWindowsWellKnownSIDs properties {#querywindowswellknownsids}

| Property | Description |
| -------- | ----------- |
| WIX_ACCOUNT_LOCALSYSTEM, WIX_ACCOUNT_LOCALSYSTEM_NODOMAIN | Localized qualified name of the Local System account (WinLocalSystemSid). |
| WIX_ACCOUNT_LOCALSERVICE, WIX_ACCOUNT_LOCALSERVICE_NODOMAIN | Localized qualified name of the Local Service account (WinLocalServiceSid). |
| WIX_ACCOUNT_NETWORKSERVICE, WIX_ACCOUNT_NETWORKSERVICE_NODOMAIN | Localized qualified name of the Network Service account (WinNetworkServiceSid). |
| WIX_ACCOUNT_ADMINISTRATORS, WIX_ACCOUNT_ADMINISTRATORS_NODOMAIN | Localized qualified name of the Administrators group (WinBuiltinAdministratorsSid). |
| WIX_ACCOUNT_USERS, WIX_ACCOUNT_USERS_NODOMAIN | Localized qualified name of the Users group (WinBuiltinUsersSid). |
| WIX_ACCOUNT_GUESTS, WIX_ACCOUNT_GUESTS_NODOMAIN | Localized qualified name of the Users group (WinBuiltinGuestsSid). |
| WIX_ACCOUNT_PERFLOGUSERS, WIX_ACCOUNT_PERFLOGUSERS_NODOMAIN | Localized qualified name of the Performance Log Users group (WinBuiltinPerfLoggingUsersSid). |


## QueryNativeMachine properties {#querynativemachine}

| Property | Description |
| -------- | ----------- |
| WIX_NATIVE_MACHINE | Set to an [Image File Machine value](https://docs.microsoft.com/en-us/windows/win32/sysinfo/image-file-machine-constants) representing the native architecture of the machine. This property is set only on Windows 10 version 1511 (TH2) and later. |
