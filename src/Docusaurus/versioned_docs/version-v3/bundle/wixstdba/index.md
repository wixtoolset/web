---
title: Working with WiX Standard Bootstrapper Application
layout: documentation
---
# Working with WiX Standard Bootstrapper Application

As described in the introduction to [building installation package bundles](../../bundle/index.md), every bundle requires a bootstrapper application DLL to drive the Burn engine. Custom bootstrapper applications can be created but require the developer to write native or managed code. Therefore, the WiX toolset provides a standard bootstrapper application that developers can use and customize in particular ways.

There are several variants of the WiX Standard Bootstrapper Application.

1. WixStandardBootstrapperApplication.RtfLicense - the first variant displays the license in the welcome dialog similar to the WixUI Advanced.
1. WixStandardBootstrapperApplication.HyperlinkLicense - the second variant provides an optional hyperlink to the license agreement on the welcome dialog, providing a more modern and streamlined look.
1. WixStandardBootstrapperApplication.HyperlinkSidebarLicense - the third variant is based on HyperlinkLicense but provides a larger dialog and larger image on the initial page.
1. WixStandardBootstrapperApplication.RtfLargeLicense - this variant is similar to RtfLicense but is a larger dialog and supports the option of displaying the version number.
1. WixStandardBootstrapperApplication.HyperlinkLargeLicense - this variant is similar to HyperlinkLicense but is a larger dialog and supports the option of displaying the version number.

To use the WiX Standard Bootstrapper Application, a [BootstrapperApplicationRef](../../xsd/wix/bootstrapperapplicationref.md) element must reference one of the above identifiers. The following example uses the bootstrapper application that displays the license:

```xml
<?xml version="1.0"?>
<Wix xmlns="http://schemas.microsoft.com/wix/2006/wi">
  <Bundle>
    <BootstrapperApplicationRef Id="WixStandardBootstrapperApplication.RtfLicense" />
    <Chain>
    </Chain>
  </Bundle>
</Wix>
```

HyperlinkLargeTheme, HyperlinkSidebarTheme, and RtfLargeTheme can optionally display the bundle version on the welcome page:

```xml
<?xml version="1.0"?>
<Wix xmlns="http://schemas.microsoft.com/wix/2006/wi"
     xmlns:bal="http://schemas.microsoft.com/wix/BalExtension">
  <Bundle>
    <BootstrapperApplicationRef Id="WixStandardBootstrapperApplication.RtfLicense">
      <bal:WixStandardBootstrapperApplication
        LicenseFile="path\to\license.rtf"
        ShowVersion="yes"
        />
    </BootstrapperApplicationRef>
    <Chain>
    </Chain>
  </Bundle>
</Wix>
```

When building the bundle, the WixBalExtension must be provided. If the above code was in a file called &quot;example.wxs&quot;, the following steps would create an &quot;example.exe&quot; bundle:

    candle.exe example.wxs -ext WixBalExtension
    light.exe example.wixobj -ext WixBalExtension

The following topics provide information about how to customize the WiX Standard Bootstrapper Application:

*  [Specifying the WiX Standard Bootstrapper Application License](wixstdba_license.md)
*  [Changing the WiX Standard Bootstrapper Application Branding](wixstdba_branding.md)
*  [Customize the WiX Standard Bootstrapper Application Layout](wixstdba_customize.md)
*  [Using WiX Standard Bootstrapper Application Variables](wixstdba_variables.md)
