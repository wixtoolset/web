---
title: WixUI_InstallDir Dialog Set
layout: documentation
---

# WixUI_InstallDir Dialog Set

WixUI_InstallDir does not allow the user to choose what features to install, but it adds a dialog to let the user choose a directory where the product will be installed.

This dialog set is defined in the file **WixUI_InstallDir.wxs** in the WixUIExtension in the WiX source code.

## Using WixUI_InstallDir

To use WixUI\_InstallDir, you must set a property named WIXUI\_INSTALLDIR with a value of the ID of the directory you want the user to be able to specify the location of. The directory ID must be all uppercase characters because it must be passed from the UI to the execute sequence to take effect. For example:

```xml
<Directory Id="TARGETDIR" Name="SourceDir">
  <Directory Id="ProgramFilesFolder" Name="PFiles">
    <Directory Id="<b>TESTFILEPRODUCTDIR</b>" Name="Test File">
      ...
    </Directory>
   </Directory>
</Directory>
...
<Property Id="WIXUI_INSTALLDIR" Value="<b>TESTFILEPRODUCTDIR</b>" />
<UIRef Id="WixUI_InstallDir" />
```

## WixUI_InstallDir Dialogs

WixUI_InstallDir includes the following dialogs:

* BrowseDlg
* DiskCostDlg
* InstallDirDlg
* InvalidDirDlg
* LicenseAgreementDlg
* WelcomeDlg

In addition, WixUI_InstallDir includes the following common dialogs that appear in all WixUI dialog sets:

* CancelDlg
* ErrorDlg
* ExitDlg
* FatalError
* FilesInUse
* MaintenanceTypeDlg
* MaintenanceWelcomeDlg
* MsiRMFilesInUse
* OutOfDiskDlg
* OutOfRbDiskDlg
* PrepareDlg
* ProgressDlg
* ResumeDlg
* UserExit
* VerifyReadyDlg
* WaitForCostingDlg

See [the WixUI dialog reference](wixui_dialogs.md) for detailed descriptions of each of the above dialogs.
