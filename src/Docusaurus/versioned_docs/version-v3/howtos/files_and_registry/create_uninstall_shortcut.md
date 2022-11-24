# How To: Create an Uninstall Shortcut

When installing an application it is a common requirement to place a shortcut on the user&apos;s Start Menu to provide a method of uninstalling the application. This how to demonstrates the steps required to create an uninstall shortcut on the start menu that passes all ICE validation checks.

This how to assumes you are starting with the sample described the [How To: Create a Shortcut on the Start Menu](create_start_menu_shortcut.md) topic.

## Step 1: Add the Uninstall Shortcut
The [Shortcut](../../xsd/wix/shortcut.md) element is used to add the uninstall shortcut to the start menu, and the shortcut points to msiexec.exe (the Windows Installer executable used to actually invoke the uninstall process). Anywhere within the existing ApplicationShortcut component add the following:

```xml
<Shortcut Id="UninstallProduct"
          Name="Uninstall My Application"
          Target="[SystemFolder]msiexec.exe"
          Arguments="/x [ProductCode]"
          Description="Uninstalls My Application" />
```

The Target attribute points to the location of msiexec.exe. The Windows Installer <a target="_blank" href="http://msdn.microsoft.com/en-us/library/aa372055.aspx">SystemFolder</a> property will resolve to the *System32* directory where msiexec.exe resides. The Arguments attribute is used to let msiexec.exe know which product to uninstall by passing in the ProductCode for the install package.

To avoid ICE validation errors at build it is important to couple the Shortcut element with a registry entry and a RemoteFolder element. Both of these are described in more detail in the [How To: Create a Shortcut on the Start Menu](create_start_menu_shortcut.md) topic, and are shown in the complete sample below.

## The Complete Sample
The following is a complete sample that uses the above concepts. This example can be inserted into a WiX project and compiled, or compiled and linked from the command line, to generate an installer.

```xml
<?xml version="1.0" encoding="UTF-8"?>
<Wix xmlns="http://schemas.microsoft.com/wix/2006/wi">
    <Product Id="*" UpgradeCode="PUT-GUID-HERE" Version="1.0.0.0" Language="1033" Name="My Application Name" Manufacturer="My Manufacturer Name">
        <Package InstallerVersion="300" Compressed="yes"/>
        <Media Id="1" Cabinet="myapplication.cab" EmbedCab="yes" />

        <Directory Id="TARGETDIR" Name="SourceDir">
            <Directory Id="ProgramFilesFolder">
                <Directory Id="APPLICATIONROOTDIRECTORY" Name="My Application Name"/>
            </Directory>
            <Directory Id="ProgramMenuFolder">
                <Directory Id="ApplicationProgramsFolder" Name="My Application Name"/>
            </Directory>
        </Directory>

        <DirectoryRef Id="APPLICATIONROOTDIRECTORY">
            <Component Id="myapplication.exe" Guid="PUT-GUID-HERE">
                <File Id="myapplication.exe" Source="MySourceFiles\MyApplication.exe" KeyPath="yes" Checksum="yes"/>
            </Component>
            <Component Id="documentation.html" Guid="PUT-GUID-HERE">
                <File Id="documentation.html" Source="MySourceFiles\documentation.html" KeyPath="yes"/>
            </Component>
        </DirectoryRef>

        <DirectoryRef Id="ApplicationProgramsFolder">
            <Component Id="ApplicationShortcut" Guid="PUT-GUID-HERE">
                <Shortcut Id="ApplicationStartMenuShortcut"
                          Name="My Application Name"
                          Description="My Application Description"
                          Target="[#myapplication.exe]"
                          WorkingDirectory="APPLICATIONROOTDIRECTORY"/>
                <!-- Step 1: Add the uninstall shortcut to your installer package -->
                <Shortcut Id="UninstallProduct"
                          Name="Uninstall My Application"
                          Description="Uninstalls My Application"
                          Target="[System64Folder]msiexec.exe"
                          Arguments="/x [ProductCode]"/>
                <RemoveFolder Id="ApplicationProgramsFolder" On="uninstall"/>
                <RegistryValue Root="HKCU" Key="Software\MyCompany\MyApplicationName" Name="installed" Type="integer" Value="1" KeyPath="yes"/>
            </Component>
        </DirectoryRef>

        <Feature Id="MainApplication" Title="Main Application" Level="1">
            <ComponentRef Id="myapplication.exe" />
            <ComponentRef Id="documentation.html" />
            <ComponentRef Id="ApplicationShortcut" />
        </Feature>
    </Product>
</Wix>
```
