# How To: Install the .NET Framework Using Burn

Applications written using the .NET Framework often need to bundle the .NET framework and install it with their application.  Wix 3.6 and later makes this easy with Burn.

## Step 1: Create a bundle for your application
Follow the instructions in [Building Installation Package Bundles](../../bundle/index.md).

## Step 2: Add a reference to one of the .NET PackageGroups

1. Add a reference to WixNetFxExtension to your bundle project.
2. Add a PackageGroupRef element to your bundle's chain that references the .NET package required by your application.  For a full list, see [WixNetfxExtension](../../customactions/wixnetfxextension.md). Ensure that the PayloadGroupRef is placed before any other packages that require .NET.

   ```xml
   <Chain>
       <PackageGroupRef Id="NetFx45Web"/>
       <MsiPackage Id="MyApplication" SourceFile="$(var.MyApplicationSetup.TargetPath)"/>
   </Chain>
   ```

## Step 3: Optionally package the .NET Framework redistributable

The .NET PackageGroups use remote payloads to download the .NET redistributable when required. If you want to create a bundle that does not require Internet connectivity, you can package the .NET redistributable with your bundle. Doing so requires you have a local copy of the redistributable, such as checked in to your source-control system.

```xml
<Bundle>
    <PayloadGroup Id="NetFx452RedistPayload">
        <Payload Name="redist\NDP452-KB2901907-x86-x64-AllOS-ENU.exe"
                 SourceFile="X:\path\to\redists\in\repo\NDP452-KB2901907-x86-x64-AllOS-ENU.exe"/>
    </PayloadGroup>
</Bundle>
```

Note that the PackageGroupRef in the bundle's chain is still required.

## Customizing your bootstrapper application
Any native bootstrapper application, including the [WiX Standard Bootstrapper Application](../../bundle/wixstdba/index.md), will work well with bundles that include .NET.

Managed bootstrapper applications must take care when including .NET to ensure that they do not unnecessarily depend on the .NET framework version being installed.

1. Reference the managed bootstrapper application host from your bundle.

   ```xml
   <BootstrapperApplicationRef Id="ManagedBootstrapperApplicationHost">
     <Payload Name="BootstrapperCore.config"
              SourceFile="$(var.MyMBA.TargetDir)\TestUX.BootstrapperCore.config"/>
     <Payload SourceFile="$(var.MyMBA.TargetPath)"/>
   </BootstrapperApplicationRef>
   ```

2. Target your bootstrapper application to the version of .NET built into the operating system.  For Windows 7, this is .NET 3.5.
3. Support using the newer versions of .NET if the older versions are not available.  The following example shows the content of the BootstrapperCore.config file.

   ```xml
   <configuration>
     <configSections>
       <sectionGroup name="wix.bootstrapper" type="Microsoft.Tools.WindowsInstallerXml.Bootstrapper.BootstrapperSectionGroup, BootstrapperCore">
         <section name="host" type="Microsoft.Tools.WindowsInstallerXml.Bootstrapper.HostSection, BootstrapperCore" />
       </sectionGroup>
     </configSections>
     <startup useLegacyV2RuntimeActivationPolicy="true">
       <supportedRuntime version="v2.0.50727" />
       <supportedRuntime version="v4.0" />
     </startup>
     <wix.bootstrapper>
       <host assemblyName="MyBootstrapperApplicationAssembly">
         <supportedFramework version="v3.5" />
         <supportedFramework version="v4\Client" /> 
           <!-- Example only. Replace the host/@assemblyName attribute with 
           an assembly that implements BootstrapperApplication. -->
           <host assemblyName="$(var.MyMBA.TargetPath)" />
       </host>
     </wix.bootstrapper>
   </configuration>
   ```
