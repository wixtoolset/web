---
title: Specifying the WiX Standard Bootstrapper Application License
layout: documentation
---

# Specifying the WiX Standard Bootstrapper Application License

The WiX Standard Bootstrapper Application (WixStdBA) supports displaying a license in RTF format and/or linking to a license file that either exists locally or on the web. The license file is specified in the <bal:WixStandardBootstrapperApplication> element using the LicenseFile or LicenseUrl attribute, depending on which WixStdBA theme is used.

When using a WixStdBA theme that displays the RTF license, it is highly recommended that the license is overridden because the default uses "Lorem ipsum" placeholder text. The following example uses a license.rtf file found in the "path\to" folder relative to the linker bind paths.

```xml
<?xml version="1.0"?>
<Wix xmlns="http://schemas.microsoft.com/wix/2006/wi" xmlns:bal="http://schemas.microsoft.com/wix/BalExtension">
  <Bundle>
    <BootstrapperApplicationRef Id="WixStandardBootstrapperApplication.RtfLicense">
      <bal:WixStandardBootstrapperApplication
        LicenseFile="path\to\license.rtf"
        LogoFile="path\to\customlogo.png"
        />
    </BootstrapperApplicationRef>

    <Chain>
      ...
    </Chain>
  </Bundle>
</Wix>
```

The following example links to a license page on the internet.

```xml
<?xml version="1.0"?>
<Wix xmlns="http://schemas.microsoft.com/wix/2006/wi" xmlns:bal="http://schemas.microsoft.com/wix/BalExtension">
  <Bundle>
    <BootstrapperApplicationRef Id="WixStandardBootstrapperApplication.HyperlinkLicense">
      <bal:WixStandardBootstrapperApplication
        LicenseUrl="http://example.com/license.html"
        LogoFile="path\to\customlogo.png"
        />
    </BootstrapperApplicationRef>

    <Chain>
      ...
    </Chain>
  </Bundle>
</Wix>
```

When using a WixStdBA theme that displays the license as a hyperlink, the license is optional. Provide an empty string for WixStandardBootstrapperApplication/@LicenseUrl---the hyperlink and accept license checkbox are not displayed, providing an "unlicensed" installation experience.

If you get an error indicating `The Windows Installer XML variable !(wix.WixStdbaLicenseUrl) is unknown`, provide a value for WixStandardBootstrapperApplication/@LicenseUrl, even if it's an empty string.
