---
title: Customize the WiX Standard Bootstrapper Application Layout
layout: documentation
after: wixstdba_branding
---
# Customize the WiX Standard Bootstrapper Application Layout

The WiX Standard Bootstrapper Application contains a predefined user interface layout. It is possible to customize the layout using the WixStandardBootstrapperApplication element provided by WixBalExtension. The following example uses a "customtheme.xml" file found in the "path\\to" folder relative to the linker bind paths.

```xml
<?xml version="1.0"?>
<Wix xmlns="http://schemas.microsoft.com/wix/2006/wi"
     xmlns:bal="http://schemas.microsoft.com/wix/BalExtension">
  <Bundle>
    <BootstrapperApplicationRef Id="WixStandardBootstrapperApplication.RtfLicense">
      <bal:WixStandardBootstrapperApplication
        LicenseFile="path\to\license.rtf"
        ThemeFile="path\to\customtheme.xml"
        />
    </BootstrapperApplicationRef>

    <Chain>
      ...
    </Chain>
  </Bundle>
</Wix>
```

The progress page of the bootstrapper application can be customized to include Windows Installer ActionData messages by adding a Text control with the name ExecuteProgressActionDataText.

```xml
<Page Name="Progress">
  <Text X="11" Y="80" Width="-11" Height="30" FontId="2" DisablePrefix="yes">#(loc.ProgressHeader)</Text>
  <Text X="11" Y="121" Width="70" Height="17" FontId="3" DisablePrefix="yes">#(loc.ProgressLabel)</Text>
  <Text Name="OverallProgressPackageText" X="85" Y="121" Width="-11" Height="17" FontId="3" DisablePrefix="yes">#(loc.OverallProgressPackageText)</Text>
  <Progressbar Name="OverallCalculatedProgressbar" X="11" Y="143" Width="-11" Height="15" />
  <Text Name="ExecuteProgressActionDataText" X="11" Y="163" Width="-11" Height="17" FontId="3" DisablePrefix="yes" />
  <Button Name="ProgressCancelButton" X="-11" Y="-11" Width="75" Height="23" TabStop="yes" FontId="0">#(loc.ProgressCancelButton)</Button>
</Page>
```

The overall size of the bootstrapper application window can be customized by changing the Width and Height attributes of the Window element within the theme along with modifying the size and/or position of all the controls.

```xml
<Theme xmlns="http://wixtoolset.org/schemas/thmutil/2010">
  <Window Width="485" Height="300" HexStyle="100a0000" FontId="0">#(loc.Caption)</Window>
```

To view a theme file without having to build a bundle, you can use the ThmViewer.exe which is located in %WIX%\\bin\\.
