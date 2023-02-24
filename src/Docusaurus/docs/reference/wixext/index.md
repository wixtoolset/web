---
sidebar_position: 70
---

# WiX extensions and custom actions

WiX extends the functionality of Windows Installer by providing _WiX Extensions_ that typically include compiler extensions to provide custom elements and attributes in your WiX authoring and custom actions to implement the extended functionality.

The following WiX extensions are provided by the WiX team:

| Extension | Documentation |
| --------- | ------------- |
| WixToolset.Bal.wixext | [Bal schema](reference/schema/bal/index.md) |
| WixToolset.ComPlus.wixext | [Complus schema](reference/schema/complus/index.md) |
| WixToolset.Dependency.wixext | [Dependency schema](reference/schema/dependency/index.md) |
| WixToolset.DifxApp.wixext | [Difxapp schema](reference/schema/difxapp/index.md) |
| WixToolset.DirectX.wixext | [Directx schema](reference/schema/directx/index.md) |
| WixToolset.Firewall.wixext | [Firewall schema](reference/schema/firewall/index.md) |
| WixToolset.Http.wixext | [Http schema](reference/schema/http/index.md) |
| WixToolset.Iis.wixext | [Iis schema](reference/schema/iis/index.md) |
| WixToolset.Msmq.wixext | [Msmq schema](reference/schema/msmq/index.md) |
| WixToolset.Netfx.wixext | [Netfx schema](reference/schema/netfx/index.md) |
| WixToolset.PowerShell.wixext | [Powershell schema](reference/schema/powershell/index.md) |
| WixToolset.Sql.wixext | [Sql schema](reference/schema/sql/index.md) |
| WixToolset.UI.wixext | [UI schema](reference/schema/ui/index.md) |
| WixToolset.Util.wixext | [Util schema](reference/schema/util/index.md) |
| WixToolset.VisualStudio.wixext | [Vs schema](reference/schema/vs/index.md) |


## Using extensions

To use a WiX extension during the build of your project, you need to load the extension and reference its namespace in your WiX authoring.


### Loading extensions using the Wix.exe command-line tool

To use a WiX extension when using the Wix.exe command-line .NET tool, you need to:

1. [Add the extension to the WiX extension cache.](../wixexe.md#extensionadd)
2. [Use the extension when building.](../wixexe.md#build)

For example:

```xml
wix extension add -g WixToolset.Util.wixext
wix extension add -g WixToolset.Bal.wixext
wix build Bundle.wxs Bundle.en-us.wxl -ext WixToolset.Util.wixext -ext WixToolset.Bal.wixext
```


### Loading extensions in a .wixproj MSBuild project

WiX extensions are available as NuGet packages on NuGet.org. You can reference them as `PackageReference` items in your .wixproj MSBuild projects:

```xml
<ItemGroup>
  <PackageReference Include="WixToolset.Bal.wixext" />
  <PackageReference Include="WixToolset.Util.wixext" />
</ItemGroup>
```

You might need to specify a version for WiX extension packages (such as when they're prerelease packages):

```xml
<ItemGroup>
  <PackageReference Include="WixToolset.Bal.wixext" Version="4.0.0-rc.3" />
  <PackageReference Include="WixToolset.Util.wixext" Version="4.0.0-rc.3" />
</ItemGroup>
```

You need to restore package references. When using the `dotnet build` command, restore is automatic. When using .NET Framework MSBuild, you can use the `-Restore` switch on your `msbuild` command line to run package restore before building.


### Declare the extension namespace

When you need to use a custom element from a WiX extension in your WiX authoring, you need to use the namespace of that extension. For example, the WixToolset.VisualStudio.wixext extension uses the `http://wixtoolset.org/schemas/v4/wxs/vs` namespace for its elements so to use the WixToolset.VisualStudio.wixext extension element `FindVisualStudio`, you might have authoring that looks like this:

```xml {3,6}
<Wix
    xmlns="http://wixtoolset.org/schemas/v4/wxs"
    xmlns:vs="http://wixtoolset.org/schemas/v4/wxs/vs">

  <Package>
    <vs:FindVisualStudio />

    <PropertyRef Id="VS2022_ROOT_FOLDER" />
  </Package>
</Wix>
```
