---
sidebar_position: 50
---

# Detecting and installing .NET

WiX includes a number of MSI properties and bundle variables to detect .NET Framework, .NET Core, and .NET in the WixToolset.Netfx.wixext WiX extension. There is also a custom action to generate native images on .NET Framework. To use them, add a package reference to WixToolset.Netfx.wixext in your .wixproj or use [`wix extension`](../wixexe.md#extension) and [`wix build -ext`](../wixexe.md#build) at the command line.


## .NET Framework

WixToolset.Netfx.wixext includes support for "traditional" .NET Framework (as compared to .NET Core and just-call-me-.NET v5 and later).

:::info
Documentation is provided here for WixToolset.Netfx.wixext functionality for currently-supported versions of .NET Framework. Functionality for older versions is available but not documented.
:::


### Native-image generation

The [NativeImage element](../../schema/netfx/nativeimage.md) marks a file to have the WixToolset.Netfx.wixext custom actions invoke the [.NET Framework NGen tool](https://learn.microsoft.com/en-us/dotnet/framework/tools/ngen-exe-native-image-generator) during installation.

```xml
<Wix
  xmlns="http://wixtoolset.org/schemas/v4/wxs"
  xmlns:netfx="http://wixtoolset.org/schemas/v4/wxs/netfx">

  <Fragment>
    <Component>
      <File Source="Important.exe">
        <netfx:NativeImage
          Id="ImportantNgen"
          Platform="64bit" />
      </File>
    </Component>
  </Fragment>
</Wix>
```


### .NET Framework detection properties for MSI packages

WixToolset.Netfx.wixext also includes a set of properties that can be used to detect the presence of various versions of the .NET Framework.

The following properties let you detect a particular minimum version of .NET Framework 4.x releases that are in-place updates (rather than installed side-by-side with older releases).

| Property | Description |
| -------- | ----------- |
| `WIX_IS_NETFRAMEWORK_40_OR_LATER_INSTALLED` | Set to 1 if .NET Framework 4.0 or later is installed. |
| `WIX_IS_NETFRAMEWORK_45_OR_LATER_INSTALLED` | Set to 1 if .NET Framework 4.5 or later is installed. |
| `WIX_IS_NETFRAMEWORK_451_OR_LATER_INSTALLED` | Set to 1 if .NET Framework 4.5.1 or later is installed. |
| `WIX_IS_NETFRAMEWORK_452_OR_LATER_INSTALLED` | Set to 1 if .NET Framework 4.5.2 or later is installed. |
| `WIX_IS_NETFRAMEWORK_46_OR_LATER_INSTALLED` | Set to 1 if .NET Framework 4.6 or later is installed. |
| `WIX_IS_NETFRAMEWORK_461_OR_LATER_INSTALLED` | Set to 1 if .NET Framework 4.6.1 or later is installed. |
| `WIX_IS_NETFRAMEWORK_462_OR_LATER_INSTALLED` | Set to 1 if .NET Framework 4.6.2 or later is installed. |
| `WIX_IS_NETFRAMEWORK_472_OR_LATER_INSTALLED` | Set to 1 if .NET Framework 4.7.2 or later is installed. |
| `WIX_IS_NETFRAMEWORK_48_OR_LATER_INSTALLED` | Set to 1 if .NET Framework 4.8 or later is installed. |
| `WIX_IS_NETFRAMEWORK_481_OR_LATER_INSTALLED` | Set to 1 if .NET Framework 4.8.1 or later is installed. |

For example:

```xml
<PropertyRef Id="WIX_IS_NETFRAMEWORK_48_OR_LATER_INSTALLED" />

<Launch
  Message="This application requires .NET Framework 4.8 or later."
  Condition="Installed OR WIX_IS_NETFRAMEWORK_48_OR_LATER_INSTALLED"
/>
```

The following property is applicable to all versions of the .NET Framework:

| Property | Description |
| -------- | ----------- |
| `NETFRAMEWORKINSTALLROOTDIR` | Set to the root installation directory for all versions of the .NET Framework (`%windir%\Microsoft.NET\Framework\`). |

These properties are available for the .NET Framework 3.5 product family:

| Property | Description |
| -------- | ----------- |
| `NETFRAMEWORK35` | Set to #1 if the .NET Framework 3.5 is installed (not set otherwise). |
| `NETFRAMEWORK35_SP_LEVEL` | Indicates the service pack level for the .NET Framework 3.5. |
| `NETFRAMEWORK35INSTALLROOTDIR` | Set to the installation directory for the .NET Framework 3.5 (`%windir%\Microsoft.NET\Framework\v3.5`). |
| `NETFRAMEWORK35INSTALLROOTDIR64` | Set to the installation directory for the 64-bit .NET Framework 3.5 (`%windir%\Microsoft.NET\Framework64\v3.5`). |
| `NETFRAMEWORK35_ZH_CN_LANGPACK` | Set to #1 if the .NET Framework 3.5 Chinese (Simplified) language pack is installed (not set otherwise). |
| `NETFRAMEWORK35_ZH_TW_LANGPACK` | Set to #1 if the .NET Framework 3.5 Chinese (Traditional) language pack is installed (not set otherwise). |
| `NETFRAMEWORK35_CS_CZ_LANGPACK` | Set to #1 if the .NET Framework 3.5 Czech language pack is installed (not set otherwise). |
| `NETFRAMEWORK35_DA_DK_LANGPACK` | Set to #1 if the .NET Framework 3.5 Danish language pack is installed (not set otherwise). |
| `NETFRAMEWORK35_NL_NL_LANGPACK` | Set to #1 if the .NET Framework 3.5 Dutch language pack is installed (not set otherwise). |
| `NETFRAMEWORK35_FI_FI_LANGPACK` | Set to #1 if the .NET Framework 3.5 Finnish language pack is installed (not set otherwise). |
| `NETFRAMEWORK35_FR_FR_LANGPACK` | Set to #1 if the .NET Framework 3.5 French language pack is installed (not set otherwise). |
| `NETFRAMEWORK35_DE_DE_LANGPACK` | Set to #1 if the .NET Framework 3.5 German language pack is installed (not set otherwise). |
| `NETFRAMEWORK35_EL_GR_LANGPACK` | Set to #1 if the .NET Framework 3.5 Greek language pack is installed (not set otherwise). |
| `NETFRAMEWORK35_HU_HU_LANGPACK` | Set to #1 if the .NET Framework 3.5 Hungarian language pack is installed (not set otherwise). |
| `NETFRAMEWORK35_IT_IT_LANGPACK` | Set to #1 if the .NET Framework 3.5 Italian language pack is installed (not set otherwise). |
| `NETFRAMEWORK35_JA_JP_LANGPACK` | Set to #1 if the .NET Framework 3.5 Japanese language pack is installed (not set otherwise). |
| `NETFRAMEWORK35_KO_KR_LANGPACK` | Set to #1 if the .NET Framework 3.5 Korean language pack is installed (not set otherwise). |
| `NETFRAMEWORK35_NB_NO_LANGPACK` | Set to #1 if the .NET Framework 3.5 Norwegian language pack is installed (not set otherwise). |
| `NETFRAMEWORK35_PL_PL_LANGPACK` | Set to #1 if the .NET Framework 3.5 Polish language pack is installed (not set otherwise). |
| `NETFRAMEWORK35_PT_BR_LANGPACK` | Set to #1 if the .NET Framework 3.5 Portuguese (Brazil) language pack is installed (not set otherwise). |
| `NETFRAMEWORK35_PT_PT_LANGPACK` | Set to #1 if the .NET Framework 3.5 Portuguese (Portugal) language pack is installed (not set otherwise). |
| `NETFRAMEWORK35_RU_RU_LANGPACK` | Set to #1 if the .NET Framework 3.5 Russian language pack is installed (not set otherwise). |
| `NETFRAMEWORK35_ES_ES_LANGPACK` | Set to #1 if the .NET Framework 3.5 Spanish language pack is installed (not set otherwise). |
| `NETFRAMEWORK35_SV_SE_LANGPACK` | Set to #1 if the .NET Framework 3.5 Swedish language pack is installed (not set otherwise). |
| `NETFRAMEWORK35_TR_TR_LANGPACK` | Set to #1 if the .NET Framework 3.5 Turkish language pack is installed (not set otherwise). |
| `NETFRAMEWORK35_CLIENT` | Set to #1 if the .NET Framework 3.5 client profile is installed (not set otherwise). |
| `NETFRAMEWORK35_CLIENT_SP_LEVEL` | Indicates the service pack level for the .NET Framework 3.5 client profile. |

Because .NET Framework v4.5 and later are in-place updates, the following properties apply to all currently-supported versions of .NET Framework v4.x. For more information, see [.NET Framework deployment guide for developers](https://learn.microsoft.com/en-us/dotnet/framework/deployment/deployment-guide-for-developers).

| Property | Description |
| -------- | ----------- |
| `NETFRAMEWORK4X` | Set to Release number of the .NET Framework 4.X if installed (not set otherwise). |
| `NETFRAMEWORK4X_AR_SA_LANGPACK` | Set to Release number of the .NET Framework 4.X Arabic language pack if installed (not set otherwise). |
| `NETFRAMEWORK4X_ZH_CN_LANGPACK` | Set to Release number of the .NET Framework 4.X Chinese (Simplified) language pack if installed (not set otherwise). |
| `NETFRAMEWORK4X_ZH_TW_LANGPACK` | Set to Release number of the .NET Framework 4.X Chinese (Traditional) language pack if installed (not set otherwise). |
| `NETFRAMEWORK4X_CS_CZ_LANGPACK` | Set to Release number of the .NET Framework 4.X Czech language pack if installed (not set otherwise). |
| `NETFRAMEWORK4X_DA_DK_LANGPACK` | Set to Release number of the .NET Framework 4.X Danish language pack if installed (not set otherwise). |
| `NETFRAMEWORK4X_NL_NL_LANGPACK` | Set to Release number of the .NET Framework 4.X Dutch language pack if installed (not set otherwise). |
| `NETFRAMEWORK4X_FI_FI_LANGPACK` | Set to Release number of the .NET Framework 4.X Finnish language pack if installed (not set otherwise). |
| `NETFRAMEWORK4X_FR_FR_LANGPACK` | Set to Release number of the .NET Framework 4.X French language pack if installed (not set otherwise). |
| `NETFRAMEWORK4X_DE_DE_LANGPACK` | Set to Release number of the .NET Framework 4.X German language pack if installed (not set otherwise). |
| `NETFRAMEWORK4X_EL_GR_LANGPACK` | Set to Release number of the .NET Framework 4.X Greek language pack if installed (not set otherwise). |
| `NETFRAMEWORK4X_HE_IL_LANGPACK` | Set to Release number of the .NET Framework 4.X Hebrew language pack if installed (not set otherwise). |
| `NETFRAMEWORK4X_HU_HU_LANGPACK` | Set to Release number of the .NET Framework 4.X Hungarian language pack if installed (not set otherwise). |
| `NETFRAMEWORK4X_IT_IT_LANGPACK` | Set to Release number of the .NET Framework 4.X Italian language pack if installed (not set otherwise). |
| `NETFRAMEWORK4X_JA_JP_LANGPACK` | Set to Release number of the .NET Framework 4.X Japanese language pack if installed (not set otherwise). |
| `NETFRAMEWORK4X_KO_KR_LANGPACK` | Set to Release number of the .NET Framework 4.X Korean language pack if installed (not set otherwise). |
| `NETFRAMEWORK4X_NB_NO_LANGPACK` | Set to Release number of the .NET Framework 4.X Norwegian language pack if installed (not set otherwise). |
| `NETFRAMEWORK4X_PL_PL_LANGPACK` | Set to Release number of the .NET Framework 4.X Polish language pack if installed (not set otherwise). |
| `NETFRAMEWORK4X_PT_BR_LANGPACK` | Set to Release number of the .NET Framework 4.X Portuguese (Brazil) language pack if installed (not set otherwise). |
| `NETFRAMEWORK4X_PT_PT_LANGPACK` | Set to Release number of the .NET Framework 4.X Portuguese (Portugal) language pack if installed (not set otherwise). |
| `NETFRAMEWORK4X_RU_RU_LANGPACK` | Set to Release number of the .NET Framework 4.X Russian language pack if installed (not set otherwise). |
| `NETFRAMEWORK4X_ES_ES_LANGPACK` | Set to Release number of the .NET Framework 4.X Spanish language pack if installed (not set otherwise). |
| `NETFRAMEWORK4X_SV_SE_LANGPACK` | Set to Release number of the .NET Framework 4.X Swedish language pack if installed (not set otherwise). |
| `NETFRAMEWORK4X_TR_TR_LANGPACK` | Set to Release number of the .NET Framework 4.X Turkish language pack if installed (not set otherwise). |


### .NET Framework detection variables for bundles

| Variable | Description |
| -------- | ----------- |
| `NETFRAMEWORK35_SP_LEVEL` | Indicates the service pack level for the .NET Framework 3.5. |
| `WixNetFramework4xInstalledRelease` | Set to Release number of the .NET Framework 4.x if installed (not set otherwise). |

For example:

```xml
<util:RegistrySearchRef Id="WixNetFramework4xInstalledRelease" />
```


## Package groups to install .NET in bundles

| PackageGroup Id | Description |
| --------------- | ----------- |
| `NetFx462Web` | .NET Framework v4.6.2 Web redistributable installer |
| `NetFx462WebAsPrereq` | .NET Framework v4.6.2 Web redistributable installer, as a managed-code bootstrapper application prerequisite |
| `NetFx462Redist` | .NET Framework v4.6.2 standalone redistributable installer |
| `NetFx462RedistAsPrereq` | .NET Framework v4.6.2 standalone redistributable installer, as a managed-code bootstrapper application prerequisite |
| `NetFx472Web` | .NET Framework v4.7.2 Web redistributable installer |
| `NetFx472WebAsPrereq` | .NET Framework v4.7.2 Web redistributable installer, as a managed-code bootstrapper application prerequisite |
| `NetFx472Redist` | .NET Framework v4.7.2 standalone redistributable installer |
| `NetFx472RedistAsPrereq` | .NET Framework v4.7.2 standalone redistributable installer, as a managed-code bootstrapper application prerequisite |
| `NetFx48Web` | .NET Framework v4.8 Web redistributable installer |
| `NetFx48WebAsPrereq` | .NET Framework v4.8 Web redistributable installer, as a managed-code bootstrapper application prerequisite |
| `NetFx48Redist` | .NET Framework v4.8 standalone redistributable installer |
| `NetFx48RedistAsPrereq` | .NET Framework v4.8 standalone redistributable installer, as a managed-code bootstrapper application prerequisite |
| `NetFx481Web` | .NET Framework v4.8.1 Web redistributable installer |
| `NetFx481WebAsPrereq` | .NET Framework v4.8.1 Web redistributable installer, as a managed-code bootstrapper application prerequisite |
| `NetFx481Redist` | .NET Framework v4.8.1 standalone redistributable installer |
| `NetFx481RedistAsPrereq` | .NET Framework v4.8.1 standalone redistributable installer, as a managed-code bootstrapper application prerequisite |

For example:

```xml
<Chain>
  <!-- Our BA needs .NET 4.8, so make sure to include that as a prereq! -->
  <PackageGroupRef Id="NetFx48RedistAsPrereq" />
</Chain>
```


## .NET and .NET Core

This section documents support in WixToolset.Netfx.wixext for non-Framework .NET -- .NET Core and .NET (v5 and later).


### Detecting .NET in MSI packages

WixToolset.Netfx.wixext supports these elements to detect .NET in packages:

| Element | Description |
| ------- | ----------- |
| [`DotNetCompatibilityCheck`](../../schema/netfx/dotnetcompatibilitycheck.md) | Sets a property to a value indicating whether an appropriate version of the .NET runtime is already installed on the machine. |
| [`DotNetCompatibilityCheckRef`](../../schema/netfx/dotnetcompatibilitycheckref.md) | References a `DotNetCompatibilityCheck` defined elsewhere. |

For example:

```xml
<netfx:DotNetCompatibilityCheck
  Property="DOTNETRUNTIMECHECK"
  RollForward="major"
  RuntimeType="desktop"
  Platform="x64"
  Version="6.0.0"
  />
```


### Detecting .NET in bundles

WixToolset.Netfx.wixext supports these elements to detect .NET in bundles:

| Element | Description |
| ------- | ----------- |
| [`DotNetCoreSdkFeatureBandSearch`](../../schema/netfx/dotnetcoresdkfeaturebandsearch.md) | Sets a variable to the latest installed version of the specified .NET SDK by [feature band](https://learn.microsoft.com/en-us/dotnet/core/releases-and-support#feature-bands-sdk-only). |
| [`DotNetCoreSdkFeatureBandSearchRef`](../../schema/netfx/dotnetcoresdkfeaturebandsearchref.md) | References a `DotNetCoreSdkFeatureBandSearch` defined elsewhere. |
| [`DotNetCoreSdkSearch`](../../schema/netfx/dotnetcoresdksearch.md) | Sets a variable to the latest installed version of the specified .NET SDK. |
| [`DotNetCoreSdkSearchRef`](../../schema/netfx/dotnetcoresdksearchref.md) | References a `DotNetCoreSdkSearch` defined elsewhere. |
| [`DotNetCoreSearch`](../../schema/netfx/dotnetcoresearch.md) | Sets a variable to the latest installed version of the specified .NET runtime type. |
| [`DotNetCoreSearchRef`](../../schema/netfx/dotnetcoresearchref.md) | References a `DotNetCoreSearch` defined elsewhere. |

For example:

```xml
<netfx:DotNetCoreSearch
  RuntimeType="aspnet"
  Platform="x64"
  MajorVersion="6"
  Variable="AspNetCoreRuntimeVersion"
  />
<netfx:DotNetCoreSdkSearch
  MajorVersion="6"
  Variable="NetCoreSdkVersion"
  />
<netfx:DotNetCoreSdkFeatureBandSearch
  Version="6.0.100"
  Variable="NetCoreSdkSixOneHundredVersion"
  />
```
