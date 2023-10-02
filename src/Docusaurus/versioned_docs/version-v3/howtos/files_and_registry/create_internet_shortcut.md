# How To: Create a Shortcut to a Webpage

WiX provides support for creating shortcuts to Internet sites as part of the install process. This how to demonstrates referencing the necessary utility library and adding an Internet shortcut to your installer. It assumes you have already followed the steps in the [How To: Create a shortcut on the Start Menu](create_start_menu_shortcut.md).

## Step 1: Add the WiX Utility extensions library to your project
The WiX support for Internet shortcuts is included in a WiX extension library that must be added to your project prior to use. If you are using WiX on the command-line you need to add the following to your candle and light command lines:

    -ext WiXUtilExtension

If you are using WiX in Visual Studio you can add the extensions using the Add Reference dialog:

1. Open your WiX project in Visual Studio
1. Right click on your project in Solution Explorer and select Add Reference...
1. Select the **WixUtilExtension.dll** assembly from the list and click Add
1. Close the Add Reference dialog

## Step 2: Add the WiX Utility extensions namespace to your project
Once the library is added to your project, you need to add the Utility extensions namespace to your project so you can access the appropriate WiX elements. To do this modify the top-level [Wix](../../xsd/wix/wix/wix.md) element in your project by adding the following attribute:

```xml
xmlns:util="http://schemas.microsoft.com/wix/UtilExtension"
```

A complete Wix element with the standard namespace and the Utility extensions namespace added looks like this:

```xml
<Wix xmlns="http://schemas.microsoft.com/wix/2006/wi"
     xmlns:util="http://schemas.microsoft.com/wix/UtilExtension">
```

## Step 3: Add the Internet shortcut to your installer package

Internet shortcuts are created using the [Util:InternetShortcut](../../xsd/util/internetshortcut.md) element. The following example adds an InternetShortcut element to the existing shortcut creation example from [How To: Create a shortcut on the Start Menu](create_start_menu_shortcut.md).

```xml
<DirectoryRef Id="ApplicationProgramsFolder">
  <Component Id="ApplicationShortcut" Guid="PUT-GUID-HERE">
    <Shortcut Id="ApplicationStartMenuShortcut" 
              Name="My Application Name"
              Description="My Application Description"
              Target="[#MyApplicationExeFileId]"
              WorkingDirectory="APPLICATIONROOTDIRECTORY"/>
    <util:InternetShortcut Id="OnlineDocumentationShortcut"
                           Name="My Online Documentation"
                           Target="http://wixtoolset.org/"/>
    <RemoveFolder Id="ApplicationProgramsFolder" On="uninstall"/>
    <RegistryValue Root="HKCU" Key="Software\MyCompany\MyApplicationName" Name="installed" Type="integer" Value="1" KeyPath="yes"/>
  </Component>
</DirectoryRef>
```

The InternetShortcut is given a unique id with the Id attribute. in this case the application's Start Menu folder. The Name attribute specifies the name of the shortcut on the Start Menu. The Target attribute specifies the destination address for the shortcut. The [DirectoryRef](../../xsd/wix/directoryref.md) element is used to refer to the directory structure already defined by the project file. By referencing the ApplicationProgramsFolder directory the shortcut will be installed into the user's Start Menu inside the My Application Name folder.
