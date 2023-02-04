---
sidebar_position: 0
---

# Bundle package chains

Burn supports the following kinds of packages:

| Package | Description |
| ------- | ----------- |
| [BundlePackage](../schema/wxs/bundlepackage.md) | Another Burn bundle .exe |
| [ExePackage](../schema/wxs/exepackage.md) | An executable .exe installer |
| [MsiPackage](../schema/wxs/msipackage.md) | A Windows Installer .msi package |
| [MspPackage](../schema/wxs/msppackage.md) | A Windows Installer .msp patch package |
| [MsuPackage](../schema/wxs/msupackage.md) | A Windows update .msu package |

To include a package in a bundle's chain of packages:

- Include the package element as a child of the [`Chain` element](../schema/wxs/chain.md).
- Include the package element as a child of a [`PackageGroup` element](../schema/wxs/packagegroup.md) and include that package group in the chain with a [`PackageGroupRef` element](../schema/wxs/packagegroupref.md) as a child of the [`Chain` element](../schema/wxs/chain.md).

For example:

```xml
...
<Chain>
    <PackageGroupRef Id="BundlePackages" />

    <ExePackage
        DetectCondition="DetectedSomethingVariable"
        UninstallArguments="-uninstall"
        SourceFile="EndOfChain.exe" />
</Chain>
...
<Fragment>
    <PackageGroup Id="BundlePackages">
        <PackageGroupRef Id="PrereqPackages" />
        <MsiPackage Id="PackageA" SourceFile="PackageA.msi" />
        <MsiPackage Id="PackageB" SourceFile="PackageB.msi" />
    </PackageGroup>
</Fragment>

<Fragment>
    <PackageGroup Id="PrereqPackages">
        <MsiPackage SourceFile="Prereqs.msi">
            <MsiProperty Name="PREREQSONLY" Value="1" />
        </MsiPackage>
    </PackageGroup>
</Fragment>
```
