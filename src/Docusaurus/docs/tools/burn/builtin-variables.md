---
sidebar_position: 1
---

# Burn built-in variables

The Burn engine offers a set of commonly-used variables so you can use them without defining your own. Here is the list of the built-in variable names:

| Variable | Description |
| -------- | ----------- |
| AdminToolsFolder | The well-known folder for CSIDL_ADMINTOOLS. |
| AppDataFolder | The well-known folder for CSIDL_APPDATA. |
| CommonAppDataFolder | The well-known folder for CSIDL_COMMON_APPDATA. |
| CommonFilesFolder | The well-known folder for CSIDL_PROGRAM_FILES_COMMONX86. |
| CommonFiles64Folder | The well-known folder for CSIDL_PROGRAM_FILES_COMMON. |
| CommonFiles6432Folder | The well-known folder for CSIDL_PROGRAM_FILES_COMMON on 64-bit Windows and CSIDL_PROGRAM_FILES_COMMONX86 on 32-bit Windows. |
| CompatibilityMode | Non-zero if the operating system launched the bootstrapper in compatibility mode. |
| ComputerName | Name of the computer as returned by `GetComputerName` function. |
| Date | The current date using the short date format of the current user locale. |
| DesktopFolder | The well-known folder for CSIDL_DESKTOP. |
| FavoritesFolder | The well-known folder for CSIDL_FAVORITES. |
| FontsFolder | The well-known folder for CSIDL_FONTS. |
| InstallerName | The name of the installer engine ("WiX Burn"). |
| InstallerVersion | The version of the installer engine. |
| InstallerInformationalVersion | The informational version (with hash) of the installer engine. |
| LocalAppDataFolder | The well-known folder for CSIDL_LOCAL_APPDATA. |
| LogonUser | The current user name. |
| MyPicturesFolder | The well-known folder for CSIDL_MYPICTURES. |
| NativeMachine | Set to an [Image File Machine value](https://docs.microsoft.com/en-us/windows/win32/sysinfo/image-file-machine-constants) representing the native architecture of the machine. Set only on Windows 10, version 1709 and later. |
| NTProductType | Numeric product type from OS version information. |
| NTSuiteBackOffice | Non-zero if OS version suite is Back Office. |
| NTSuiteDataCenter | Non-zero if OS version suite is Datacenter. |
| NTSuiteEnterprise | Non-zero if OS version suite is Enterprise. |
| NTSuitePersonal | Non-zero if OS version suite is Personal. |
| NTSuiteSmallBusiness | Non-zero if OS version suite is Small Business. |
| NTSuiteSmallBusinessRestricted | Non-zero if OS version suite is Restricted Small Business. |
| NTSuiteWebServer | Non-zero if OS version suite is Web Server. |
| PersonalFolder | The well-known folder for CSIDL_PERSONAL. |
| ProcessorArchitecture | The native SYSTEM_INFO.wProcessorArchitecture. |
| Privileged | Non-zero if the process could run elevated (when UAC is available) or is running as an Administrator. |
| ProgramFilesFolder | The well-known folder for CSIDL_PROGRAM_FILESX86. |
| ProgramFiles64Folder | The well-known folder for CSIDL_PROGRAM_FILES. |
| ProgramFiles6432Folder | The well-known folder for CSIDL_PROGRAM_FILES on 64-bit Windows and CSIDL_PROGRAM_FILESX86 on 32-bit Windows. |
| ProgramMenuFolder | The well-known folder for CSIDL_PROGRAMS. |
| RebootPending | Non-zero if the system requires a reboot. Note that this value will reflect the reboot status of the system when the variable is first requested. |
| SendToFolder | The well-known folder for CSIDL_SENDTO. |
| ServicePackLevel | Numeric value representing the installed OS service pack. |
| StartMenuFolder | The well-known folder for CSIDL_STARTMENU. |
| StartupFolder | The well-known folder for CSIDL_STARTUP. |
| SystemFolder | The well-known folder for CSIDL_SYSTEMX86 on 64-bit Windows and CSIDL_SYSTEM on 32-bit Windows. |
| System64Folder | The well-known folder for CSIDL_SYSTEM on 64-bit Windows and undefined on 32-bit Windows. |
| SystemLanguageID | The language ID for the system locale. |
| TempFolder | The well-known folder for temporary directory. |
| TemplateFolder | The well-known folder for CSIDL_TEMPLATES. |
| TerminalServer | Non-zero if the system is running in application server mode of Remote Desktop Services. |
| UserUILanguageID | The selection language ID for the current user locale. |
| UserLanguageID | The formatting language ID for the current user locale. |
| VersionMsi | Version value representing the Windows Installer engine version. |
| VersionNT | Version value representing the OS version. The result is a version variable (v#.#.#.#) which differs from the Windows Installer property `VersionNT` which is an integer. For example, to use this variable in a Bundle condition, use: `VersionNT > v6.1`.
| VersionNT64 | Version value representing the OS version if 64-bit. Undefined if running a 32-bit operating system. The result is a version variable (v#.#.#.#) which differs from the Windows Installer property `VersionNT64` which is an integer. For example, to use this variable in a Bundle condition try: `VersionNT64 > v6.1`.
| WindowsBuildNumber | The build number of the operating system. |
| WindowsFolder | The well-known folder for CSIDL_WINDOWS. |
| WindowsVolume | The well-known folder for the windows volume. |
| WixBundleAction | Numeric value of BOOTSTRAPPER_ACTION from the command-line and updated during the call to IBootstrapperEngine::Plan. |
| WixBundleDirectoryLayout | The folder provided to the `-layout` switch (default is the directory containing the bundle executable). This variable can also be set by the bootstrapper application to modify where files will be laid out. |
| WixBundleElevated | Non-zero if the bundle was launched elevated and set to `1` once the bundle is elevated. For example, use this variable to show or hide the elevation shield in the bootstrapper application UI. |
| WixBundleExecutePackageCacheFolder | The absolute path to the currently executing package's cache folder. This variable is only available while a package is executing. |
| WixBundleForcedRestartPackage | The ID of the package that caused a force restart during apply. This value is reset on the next call to Apply. |
| WixBundleInstalled | Non-zero if the bundle is already installed. This value is set only when the engine initializes. |
| WixBundleLastUsedSource | The path of the last successful source resolution for a container or payload. |
| WixBundleName | The name of the bundle (from `Bundle/@Name`). This variable can also be set by the bootstrapper application to modify the bundle name at runtime. |
| WixBundleManufacturer | The manufacturer of the bundle (from `Bundle/@Manufacturer`). |
| WixBundleOriginalSource | The source path where the bundle originally ran. |
| WixBundleOriginalSourceFolder | The folder where the bundle originally ran. |
| WixBundleSourceProcessPath | The source path of the bundle where originally executed. Will only be set when bundle is executing in the clean room. (Removed in WiX v5) |
| WixBundleSourceProcessFolder | The source folder of the bundle where originally executed. Will only be set when bundle is executing in the clean room. (Removed in WiX v5) |
| WixBundleProviderKey | The bundle dependency provider key. |
| WixBundleTag | The developer-defined tag string for this bundle (from `Bundle/@Tag`). |
| WixBundleUILevel | The level of the user interface (the BOOTSTRAPPER_DISPLAY enum). |
| WixBundleVersion | The version for this bundle (from `Bundle/@Version`). |
| WixCanRestart | Non-zero if the user running the bundle has the privileges required to restart the machine if the bundle prompts for restart. |
