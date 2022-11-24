# How To: Run the Installed Application After Setup

Often when completing the installation of an application it is desirable to offer the user the option of immediately launching the installed program when setup is complete. This how to describes customizing the default WiX UI experience to include a checkbox and a WiX custom action to launch the application if the checkbox is checked.

This how to assumes you have already created a basic WiX project using the steps outlined in [How To: Add a file to your installer](../../howtos/files_and_registry/add_a_file.md).

## Step 1: Add the extension libraries to your project
This walkthrough requires WiX extensions for UI components and custom actions. These extension libraries must must be added to your project prior to use. If you are using WiX on the command-line you need to add the following to your candle and light command lines:

    -ext WixUIExtension -ext WixUtilExtension

If you are using Visual Studio you can add the extensions using the Add Reference dialog:

1. Right click on your project in Solution Explorer and select Add Reference...
1. Select the **WixUIExtension.dll** assembly from the list and click Add
1. Select the **WixUtilExtension.dll** assembly from the list and click Add
1. Close the Add Reference dialog

## Step 2: Add UI to your installer

The WiX [Minimal UI](../../wixui/wixui_dialog_library.md) sequence includes a basic set of dialogs that includes a finished dialog with optional checkbox. To include the sequence in your project add the following snippet anywhere inside the `Product` element.

```xml
<UI>
  <UIRef Id="WixUI_Minimal" />
</UI>
```

To display the checkbox on the last screen of the installer include the following snippet anywhere inside the `Product` element:

```xml
<Property Id="WIXUI_EXITDIALOGOPTIONALCHECKBOXTEXT" Value="Launch My Application Name" />
```

The WIXUI\_EXITDIALOGOPTIONALCHECKBOXTEXT property is provided by the standard UI sequence that, when set, displays the checkbox and uses the specified value as the checkbox label.

## Step 3: Include the custom action

Custom actions are included in a WiX project using the [CustomAction](../../xsd/wix/customaction.md) element. Running an application is accomplished with the WixShellExecTarget custom action. To tell Windows Installer about the custom action, and to set its properties, include the following in your project anywhere inside the `Product` element:

```xml
<Property Id="WixShellExecTarget" Value="[#myapplication.exe]" />
<CustomAction Id="LaunchApplication" BinaryKey="WixCA" DllEntry="WixShellExec" Impersonate="yes" />
```

The Property element sets the WixShellExecTarget to the location of the installed application. WixShellExecTarget is the property Id the WixShellExec custom action expects will be set to the location of the file to run. The Value property uses the special # character to tell WiX to look up the full installed path of the file with the id myapplication.exe.

The CustomAction element includes the action in the installer. It is given a unique Id, and the BinaryKey and DllEntry properties indicate the assembly and entry point for the custom action. The Impersonate property tells Windows Installer to run the custom action as the installing user.

## Step 4: Trigger the custom action

Simply including the custom action, as in Step 3, isn&apos;t sufficient to cause it to run. Windows Installer must also be told when the custom action should be triggered. This is done by using the [Publish](../../xsd/wix/publish.md) element to add it to the actions run when the user clicks the Finished button on the final page of the UI dialogs. The Publish element should be included inside the `UI` element from Step 2, and looks like this:

```xml
<Publish Dialog="ExitDialog"
         Control="Finish" 
         Event="DoAction" 
         Value="LaunchApplication">WIXUI_EXITDIALOGOPTIONALCHECKBOX = 1 and NOT Installed</Publish>
```

The Dialog property specifies the dialog the Custom Action will be attached to, in this case the ExitDialog. The Control property specifies that the Finish button on the dialog triggers the custom action. The Event property indicates that a custom action should be run when the button is clicked, and the Value property specifies the custom action that was included in Step 3. The condition on the element prevents the action from running unless the checkbox from Step 2 was checked and the application was actually installed (as opposed to being removed or repaired).

## The Complete Sample

```xml
<?xml version="1.0" encoding="UTF-8"?>
<<Wix xmlns="http://schemas.microsoft.com/wix/2006/wi">
    <Product Id="*"
             UpgradeCode="PUT-GUID-HERE"
             Version="1.0.0.0"
             Language="1033"
             Name="My Application Name"
             Manufacturer="My Manufacturer Name">    
    <Package InstallerVersion="300" Compressed="yes"/>
    <Media Id="1" Cabinet="myapplication.cab" EmbedCab="yes" />

    <!-- The following three sections are from the How To: Add a File to Your Installer topic-->
    <Directory Id="TARGETDIR" Name="SourceDir">
        <Directory Id="ProgramFilesFolder">
            <Directory Id="APPLICATIONROOTDIRECTORY" Name="My Application Name"/>
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

    <Feature Id="MainApplication" Title="Main Application" Level="1">
        <ComponentRef Id="myapplication.exe" />
        <ComponentRef Id="documentation.html" />
    </Feature>

    <!-- Step 2: Add UI to your installer / Step 4: Trigger the custom action -->
    <UI>
        <UIRef Id="WixUI_Minimal" />
        <Publish Dialog="ExitDialog" 
            Control="Finish" 
            Event="DoAction" 
            Value="LaunchApplication">WIXUI_EXITDIALOGOPTIONALCHECKBOX = 1 and NOT Installed</Publish>
    </UI>
    <Property Id="WIXUI_EXITDIALOGOPTIONALCHECKBOXTEXT" Value="Launch My Application Name" />

    <!-- Step 3: Include the custom action -->
    <Property Id="WixShellExecTarget" Value="[#myapplication.exe]" />
    <CustomAction Id="LaunchApplication" 
        BinaryKey="WixCA" 
        DllEntry="WixShellExec"
        Impersonate="yes" />
    </Product>
</Wix>
```
