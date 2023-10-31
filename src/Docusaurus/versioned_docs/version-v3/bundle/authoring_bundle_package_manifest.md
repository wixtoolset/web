---
title: Author a Bundle Package Manifest
layout: documentation
after: authoring_bundle_application
---
# Author a Bundle Package Manifest

In order for any package to be consumable by a Bundle, a package definition needs to be authored that describes the package. This authoring can either go directly under the [Chain](../xsd/wix/chain.md) element in the Bundle authoring, or in a [Fragment](../xsd/wix/fragment.md) which can then be consumed by a Bundle by putting a [PackageGroupRef](../xsd/wix/packagegroupref.md) inside the [Chain](../xsd/wix/chain.md). The latter method enables sharing of the same package definition across different Bundle packages.

The WiX schema supports the following chained package types:

* [MsiPackage](../xsd/wix/msipackage.md)
* [ExePackage](../xsd/wix/exepackage.md)
* [MspPackage](../xsd/wix/msppackage.md)
* [MsuPackage](../xsd/wix/msupackage.md)

Here is an example of authoring an ExePackage in a sharable fragment:

```xml
<?xml version="1.0"?>
<Wix xmlns="http://schemas.microsoft.com/wix/2006/wi">
  <Fragment>
    <PackageGroup Id="MyPackage">
        <ExePackage 
          SourceFile="[sources]\packages\shared\MyPackage.exe"
          DetectCondition="ExeDetectedVariable"
          DownloadUrl="http://example.com/?mypackage.exe"
          InstallCommand="/q /ACTION=Install"
          RepairCommand="/q ACTION=Repair /hideconsole"
          UninstallCommand="/q ACTION=Uninstall /hideconsole" />
    </PackageGroup>
  </Fragment>
</Wix>
```

Now you can add an install condition to the package so that it only installs on x86 Windows XP and above. There are [built-in variables](bundle_built_in_variables.md) that can be used to construct these condition statements. The highlighted section shows how to leverage the built-in variables to create that condition:

```xml
<?xml version="1.0"?>
<Wix xmlns="http://schemas.microsoft.com/wix/2006/wi">
  <Fragment>
    <PackageGroup Id="MyPackage">
        <ExePackage 
          SourceFile="[sources]\packages\shared\MyPackage.exe"
          DetectCondition="ExeDetectedVariable"
          DownloadUrl="http://example.com/?mypackage.exe"
          InstallCommand="/q /ACTION=Install"
          RepairCommand="/q ACTION=Repair /hideconsole"
          UninstallCommand="/q ACTION=Uninstall /hideconsole" 
          <strong class="highlight">InstallCondition="NOT VersionNT64 AND VersionNT >= v5.1"</strong> />
    </PackageGroup>
  </Fragment>
</Wix>
```

The VersionNT property takes up to a four-part version number ([Major].[Minor].[Build].[Revision]). For a list of major and minor versions of the Windows operating system, see <a href="http://msdn.microsoft.com/library/ms724832.aspx" target="_blank">Operating System Version</a>.

You can also define your own variables and store search results in them. See [Define Searches using Variables](bundle_define_searches.md).
