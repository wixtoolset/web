---
sidebar_position: 2
---

# WixStandardBootstrapperApplication

WixStandardBootstrapperApplication (WixStdBA) is the "stock" bootstrapper application that comes with WiX. WixStdBA provides a simple, customizable, wizard-like UI and typical BA behavior like install, upgrades, and uninstall. The UI is provided by "theme" files that let you change the appearance (within limits) without needing to change the code of the BA. WixStdBA is written in C++, so has no additional system requirements.


## WixStdBA themes

WixStdBA is included in the WixToolset.Bal.wixext WiX extension NuGet package. You need a reference to that package to use WixStdBA.

WixStdBA includes several themes to choose between RTF and hyperlinks for licenses and small or large dialogs:

- WixStandardBootstrapperApplication.RtfLicense: A small dialog with the RTF license shown in the welcome dialog 
- WixStandardBootstrapperApplication.HyperlinkLicense: A small dialog with an optional hyperlink to the license agreement on the welcome dialog
- WixStandardBootstrapperApplication.HyperlinkSidebarLicense: A large dialog with an optional hyperlink to the license agreement and larger image on the welcome dialog
- WixStandardBootstrapperApplication.RtfLargeLicense: A large dialog with the RTF license and optional version number shown in the welcome dialog
- WixStandardBootstrapperApplication.HyperlinkLargeLicense: A small dialog with an optional hyperlink to the license agreement and optional version number on the welcome dialog

You can specify WixStdBA and a WixStdBA theme using the [`WixStandardBootstrapperApplication` element](../schema/bal/wixstandardbootstrapperapplication.md) under your bundle's [`BootstrapperApplication` element](../schema/wxs/bootstrapperapplication.md):

```xml
<Wix
    xmlns="http://wixtoolset.org/schemas/v4/wxs"
    xmlns:bal="http://wixtoolset.org/schemas/v4/wxs/bal">
    
    <Bundle>

        <BootstrapperApplication>
            <bal:WixStandardBootstrapperApplication
                LicenseUrl=""
                Theme="hyperlinkLicense" />
        </BootstrapperApplication>
```

Here are a few of the more interesting attributes available on the [`WixStandardBootstrapperApplication` element](../schema/bal/wixstandardbootstrapperapplication.md):

| Attribute | Description |
| --------- | ----------- |
| Theme | Controls which WixStdBA theme is selected. |
| LicenseFile | Specifies the source file for an RTF-formatted license in one of the RTF themes. |
| LicenseUrl | Specifies the URL as the target for the license hyperlink in one of the hyperlink themes. |
| LogoFile | Specifies the source file of the theme image. |
| ShowVersion | Specifies whether the bundle version should be shown (in large themes). |


## WixStdBA custom themes

You can completely replace any of the WixStdBA "standard" themes with a theme of your own. Take a look at the [standard theme source files](https://github.com/wixtoolset/wix4/tree/develop/src/ext/Bal/wixstdba/Resources) so you can see examples of theme XML authoring and the pages that WixStdBA expects:

| Page name | Description |
| --------- | ----------- |
| Loading | Shown while the bundle is initializing and running Burn's Detect phase. |
| Help | Shown when the user requests help at the bundle command line. |
| Install | Shown on initial install of the bundle. |
| Modify | Shown after the bundle has been installed, to allow for repair and uninstall. |
| Progress | Shown during installation (and repair) (and uninstall). |
| ProgressPassive | Optional window shown when in passive-UI mode during installation/repair/uninstall). |
| Success | Shown after successful operation. |
| Failure | Shown after failed operation. |


## WixStdBA bundle variables

WixStdBA sets the following bundle variables, which you can use in theme files (such as in conditions to show or hide particular UI controls) and bundle authoring (such as by passing properties to packages in your bundle chain):

| Variable | Description |
| -------- | ----------- |
| WixBundleFileVersion | The file version of the bundle .exe |
| WixStdBALanguageId | The language in effect for the user interface |
| WixStdBARestartRequired | Set to `1` if a reboot is required (after the setup operation is complete). |
| WixStdBAShowVersion | Set to `1` if [`WixStandardBootstrapperApplication/@ShowVersion`](../schema/bal/wixstandardbootstrapperapplication.md) was set to `yes`. |
| WixStdBASuppressOptionsUI | Set to `1` if [`WixStandardBootstrapperApplication/@SuppressOptionsUI`](../schema/bal/wixstandardbootstrapperapplication.md) was set to `yes`. |
| WixStdBAUpdateAvailable | Set to the highest version of an avalable update specified in the feed pointed to by [`Bundle/@UpdateURL`](../schema/wxs/bundle.md). |

