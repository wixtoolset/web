---
sidebar_position: 2
---

# WiX release notes

## WiX v4 {#v4}

> Preview 1 released Friday, 11-November-2022

WiX v4 is a major release of the WiX Toolset, years in the making. [More than 500 issues were closed in WiX v4](https://github.com/wixtoolset/issues/issues?q=is%3Aissue+milestone%3Av4.0+is%3Aclosed)!

If you're familiar with WiX v3, [WiX v4 for WiX v3 users](./fourthree.md) has details about how WiX v4 works.

Here's a high-level look at the fixes and features in WiX v4:

### Platforms
- Arm64 is supported in the core toolset, extensions, and Burn.
- WiX extensions include platform-specific custom actions for the platform of the package being built. For example, an Arm64 package contains only Arm64 custom actions and doesn't rely on x86 emulation.


### Build tools
- WiX v4 doesn't have to be installed on every dev machine and build image like WiX v3. Instead, WiX v4 follows the modern .NET model of using NuGet to deliver tools.
  - WiX v4 MSBuild projects are SDK-style projects; MSBuild and NuGet work together to bring down the WiX v4 MSBuild SDK NuGet package.
  - Both .NET Framework MSBuild and `dotnet build` are supported.
  - To build packages from the command line, WiX v4 is available as a .NET tool, which is also a NuGet package.
  - WiX extensions are delivered as NuGet packages, which are usable from both MSBuild projects via `PackageReference` and the WiX .NET tool.
- For command-line afficionados, most executables have been merged into a single `wix.exe` tool with commands. For example, in WiX v3, you might build by calling Candle.exe one or more times to compile your authoring and then calling Light.exe to link and bind the compiled authoring into an .msi package. In WiX v4 using `wix.exe`, that's one command: `wix build -o product.msi product.wxs`.
- Building patches is much easier (one command!) and can use MSI packages as the source of target and updated files.
- The WiX extensibility model and pipeline integration has been dramatically enhanced.
- The WiX language has been further simplified. For example:
  - [The `Package` element](./reference/schema/wxs/package.md) combines what was two elements in WiX v3.
  - The [`StandardDirectory` element](./reference/schema/wxs/standarddirectory.md) simplifies the use of standard Windows Installer directories.
  - The `Subdirectory` attribute on, for example, [the `Component` element](./reference/schema/wxs/component.md), lets you create subdirectories without nested [`Directory` elements](./reference/schema/wxs/directory.md).
  - WiX supplies a default [`MediaTemplate` element](./reference/schema/wxs/mediatemplate.md) if you don't specify one in your authoring.
- WiX warns when mixing authoring meant for MSI packages in bundles and vice versa.

### Burn, bundles, and bootstrapper applications
- The Burn engine is platform-specific, so you can build an x64 bundle that contains only x64 code and doesn't rely on WoW64.
- .NET 6 and later are supported platforms for writing managed-code bootstrapper applications. .NET Framework is also supported.
- ThmUtil, the native-code UI library used by the WixStdBA bootstrapper application, supports new controls and authored conditions and actions that let themes add functionality without having to write custom C++ code. For details, see [Thmutil schema](./reference/schema/thmutil/index.md).
- ThmUtil (and therefore WixStdBA) supports high DPI display settings.
- The new [`WixInternalUIBootstrapperApplication`](./reference/schema/bal/wixinternaluibootstrapperapplication.md) BA supports showing only the internal or embedded UI of an MSI package.
- Burn support other bundles in the chain via [`BundlePackage`](./reference/schema/wxs/bundlepackage.md) to automatically handle detection and uninstall command lines. Likewise, the [`ArpEntry` element](./reference/schema/wxs/arpentry.md) provides the same functionality for arbitrary executable packages in the chain.
- Burn supports SemVer-style versions.
- WixStdBA supports bundle update feeds as specified in an [`Update` element](./reference/schema/wxs/update.md).
- Burn now upgrades bundles with the same version numbers.
- When a user requires elevation to restart (common on Windows Server machines), Burn handles restart through the elevated engine.
- Custom bootstrapper applications can change the `REINSTALLMODE` used when applying MSI packages.
- The Burn policy registry value `EngineWorkingDirectory` in `HKLM\Software\Policies\Wix\Burn` is a string specifying a working folder root directory for elevated bundles when the default of `C:\Windows\Temp` is blocked by security policy.
- Burn no longer appears in the Apps & Features (ARP) list if a bundle has a pre-req that causes a reboot and the user cancels after the reboot.
- The `/unsafeuninstall` command-line switch lets users attempt to "force" a bundle to uninstall, even if dependency checking would otherwise leave it installed.


### Deprecations and deletions
- Features that were deprecated in WiX v3, including command-line switches deprecated in WiX v3.14, have been removed from WiX v4.
- WixGamingExtension and WixLuxExtension have been removed in WiX v4.
- WixDifxAppExtension is deprecated in Windows 10 and therefore has been deprecated in WiX v4 and will be removed in WiX v5.


### Contributors
[@robmen](https://github.com/wixtoolset/wix4/commits?author=robmen), [@rseanhall](https://github.com/wixtoolset/wix4/commits?author=rseanhall), and [@barnson](https://github.com/wixtoolset/wix4/commits?author=barnson) took their maintainer duties seriously during the development of WiX v4. They were joined by many others, who have our thanks!

- [@cpuwzd](https://github.com/wixtoolset/wix4/commits?author=cpuwzd)
- [@nirbar](https://github.com/wixtoolset/wix4/commits?author=nirbar)
- [@japarson](https://github.com/wixtoolset/wix4/commits?author=japarson)
- [@drolevar](https://github.com/wixtoolset/wix4/commits?author=drolevar)
- [@MarkStega](https://github.com/wixtoolset/wix4/commits?author=MarkStega)
- [@hymccord](https://github.com/wixtoolset/wix4/commits?author=hymccord)
- [@jchoover](https://github.com/wixtoolset/wix4/commits?author=jchoover)
- [@AlexKubiesa](https://github.com/wixtoolset/wix4/commits?author=AlexKubiesa)
- [@wjk](https://github.com/wixtoolset/wix4/commits?author=wjk)
- [@maniglia](https://github.com/wixtoolset/Dtf/commits?author=maniglia)
- [@mcraiha](https://github.com/wixtoolset/wix4/commits?author=mcraiha)
- [@StefanStojanovic](https://github.com/wixtoolset/wix4/commits?author=StefanStojanovic)
- [@ericstj](https://github.com/wixtoolset/wix4/commits?author=ericstj)
- [@pascalpfeil](https://github.com/wixtoolset/wix4/commits?author=pascalpfeil)
- [@danielchalmers](https://github.com/wixtoolset/wix4/commits?author=danielchalmers)
- [@HarmvandenBrand](https://github.com/wixtoolset/wix4/commits?author=HarmvandenBrand)
- [@sgtatham](https://github.com/wixtoolset/wix4/commits?author=sgtatham)
- [@paulomorgado](https://github.com/wixtoolset/wix4/commits?author=paulomorgado)
- [@adnanshaheen](https://github.com/wixtoolset/wix4/commits?author=adnanshaheen)
- [@FroggieFrog](https://github.com/wixtoolset/wix4/commits?author=FroggieFrog)
- [@Herohtar](https://github.com/wixtoolset/wix4/commits?author=Herohtar)
- [@BMurri](https://github.com/wixtoolset/wix4/commits?author=BMurri)
- [@heaths](https://github.com/wixtoolset/wix4/commits?author=heaths)
- [@chrpai](https://github.com/wixtoolset/wix4/commits?author=chrpai)
- [@VolkerGa](https://github.com/wixtoolset/Dtf/commits?author=VolkerGa)
- [@t-johnson](https://github.com/wixtoolset/Harvesters/commits?author=t-johnson)
