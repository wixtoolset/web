# How To: NGen Managed Assemblies During Installation

<a target="_blank" href="http://msdn.microsoft.com/en-us/magazine/cc163808.aspx">NGen</a> during installation can improve your managed application&apos;s startup time by creating native images of the managed assemblies on the target machine. This how to describes using the WiX support to NGen managed assemblies at install time.

## Step 1: Add the WiX .NET extensions library to your project
The WiX support for NGen is included in a WiX extension library that must be added to your project prior to use. If you are using WiX on the command-line you need to add the following to your candle and light command lines:

    -ext WixNetFxExtension

If you are using WiX in Visual Studio you can add the extensions using the Add Reference dialog:

1. Open your WiX project in Visual Studio
1. Right click on your project in Solution Explorer and select Add Reference...
1. Select the <strong>WixNetFxExtension.dll</strong> assembly from the list and click Add
1. Close the Add Reference dialog

## Step 2: Add the WiX .NET extensions namespace to your project
Once the library is added to your project you need to add the .NET extensions namespace to your project so you can access the appropriate WiX elements. To do this modify the top-level [Wix](../../xsd/wix/wix/wix.md) element in your project by adding the following attribute:

```
xmlns:netfx="http://schemas.microsoft.com/wix/NetFxExtension"
```

A complete Wix element with the standard namespace and the .NET extensions namespace added looks like this:

```xml
<Wix xmlns="http://schemas.microsoft.com/wix/2006/wi"
     xmlns:netfx="http://schemas.microsoft.com/wix/NetFxExtension">
```

## Step 3: Mark the managed files for NGen
Once you have the .NET extension library and namespace added to your project you can use the [NetFx:NativeImage](../../xsd/netfx/nativeimage.md) element to enable NGen on your managed assemblies. The NativeImage element goes inside a parent File element:

```xml
<Component Id="myapplication.exe" Guid="PUT-GUID-HERE">
    <File Id="myapplication.exe" Source="MySourceFiles\MyApplication.exe" KeyPath="yes" Checksum="yes">
        <netfx:NativeImage Id="ngen_MyApplication.exe" Platform="32bit" Priority="0" AppBaseDirectory="APPLICATIONROOTDIRECTORY"/>
    </File>
</Component>
```

The Id attribute is a unique identifier for the native image. The Platform attribute specifies the platforms for which the native image should be generated, in this case 32-bit. The Priority attribute specifies when the image generation should occur, in this case immediately during the setup process. The AppBaseDirectory attribute identifies the directory to use to search for dependent assemblies during the image generation. In this case it is set to the install directory for the application.
