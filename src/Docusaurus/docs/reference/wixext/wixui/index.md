---
sidebar_position: 10
---

# WixUI dialog library

:::info
TODO: WiX v4 documentation is under development.
:::

WiX offers a set of built-in Windows Installer-based user interface for installation packages.

## Dialog sets

The WixUI dialog library contains the following built-in dialog sets that provide a familiar wizard-style setup user interface.

| WixUI id | Description |
| -------- | ----------- |
| WixUI_Advanced | The WixUI_Advanced dialog set provides the option of a one-click install like WixUI_Minimal, but it also allows directory and feature selection like other dialog sets if the user chooses to configure advanced options. |
| WixUI_FeatureTree | WixUI_FeatureTree is a simpler version of WixUI_Mondo that omits the setup type dialog. Instead, the wizard proceeds directly from the license agreement dialog to the feature customization dialog. WixUI_FeatureTree is more appropriate than WixUI_Mondo when your product installs all features by default. |
| WixUI_InstallDir | WixUI_InstallDir does not allow the user to choose what features to install, but it adds a dialog to let the user choose a directory where the entire product will be installed. |
| WixUI_Minimal | WixUI_Minimal is the simplest of the built-in WixUI dialog sets. Its sole dialog combines the welcome and license agreement dialogs and omits the feature customization dialog. WixUI_Minimal is appropriate when your product has no optional features and does not support changing the installation directory. |
| WixUI_Mondo | WixUI_Mondo includes a set dialogs that allow granular installation customization options. WixUI_Mondo is appropriate when some product features are not installed by default and there is a meaningful difference between typical and complete installs. Note: WixUI_Mondo uses [SetInstallLevel control events](https://learn.microsoft.com/en-us/windows/win32/msi/setinstalllevel-controlevent) to set the install level when the user chooses *Typical* or *Complete*. For *Typical*, the install level is set to 3; for *Complete*, 1000. For details about feature levels and install levels, see [INSTALLLEVEL Property](https://learn.microsoft.com/en-us/windows/win32/msi/installlevel). |


### Adding a WixUI dialog set to your MSI package

To add a WixUI dialog set to your MSI package:

1. Add a reference to the WixToolset.UI.wixext WiX extension.
2. Add the WixToolset.UI.wixext WiX extension namespace to your WiX authoring.
3. Add the `WixUI` element to your WiX authoring.

For example:

```xml
<Wix xmlns="http://wixtoolset.org/schemas/v4/wxs" xmlns:ui="http://wixtoolset.org/schemas/v4/wxs/ui">
  <Package ...>
      ...
      <ui:WixUI Id="WixUI_InstallDir" InstallDirectory="INSTALLFOLDER" />
  </Package>
</Wix>
```

## Localization

### Translated strings

Translated strings are included in WixToolset.UI.wixext for the following cultures:

- ar-SA
- bg-BG
- ca-ES
- cs-CZ
- da-DK
- de-DE
- el-GR
- en-US
- es-ES
- et-EE
- fi-FI
- fr-FR
- he-IL
- hi-IN
- hr-HR
- hu-HU
- it-IT
- ja-JP
- kk-KZ
- ko-KR
- lt-LT
- lv-LV
- nb-NO
- nl-NL
- pl-PL
- pt-BR
- pt-PT
- ro-RO
- ru-RU
- sk-SK
- sl-SI
- sq-AL
- sr-Latn-RS
- sv-SE
- th-TH
- tr-TR
- uk-UA
- zh-CN
- zh-HK
- zh-TW


### Using translated error and progress text

By default, WixToolset.UI.wixext does not include any translated Error or ProgressText elements in your packages. To include them, reference the WixUI_ErrorProgressText UI element:

```xml
<UIRef Id="WixUI_ErrorProgressText" />
```


### Building localized packages that use WixUI

To build a localized package using the Wix.exe command-line tool:

- Add a `-culture` switch with an argument of the culture you want to build. The localized strings for that culture in WixToolset.UI.wixext (if available) will be used.

To build a localized package using a .wixproj MSBuild project:

- Set the `Cultures` property in the .wixproj to a semicolon-delimited list of cultures. For example:

```xml
<PropertyGroup>
  <Cultures>en-US;ja-JP</Cultures>
</PropertyGroup>
```


## Customizing a dialog set
