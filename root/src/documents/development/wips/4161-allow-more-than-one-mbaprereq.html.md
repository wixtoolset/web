---
wip: 4161
type: Feature
author: r.sean.hall at gmail dot com
title: Allow More Than One MBA Prerequisite
draft: false
---

## User stories

* As a setup developer I can create a managed BA and depend on the mbaprereq BA to install more than one dependency, not just .NET.


## Current State

Currently, the mbaprereq BA only supports installing one package.  The WixBalExtension provides the package identity of that package in the custom BootstrapperApplicationData table WixMbaPrereqInformation.  It populates the single row in the table by using Wix binder variables:

    <Fragment>
        <PayloadGroup Id='MbaPreqLicenseUrlMinimal'>
            <Payload Name='mbapreq.dll' Compressed='yes' SourceFile='wixstdba.dll' />
        </PayloadGroup>

        <CustomTable Id='WixMbaPrereqInformation'>
            <Row>
                <Data Column='PackageId'>!(wix.WixMbaPrereqPackageId)</Data>
                <Data Column='LicenseUrl'>!(wix.WixMbaPrereqLicenseUrl)</Data>
            </Row>
        </CustomTable>
    </Fragment>

    <Fragment>
        <PayloadGroup Id='MbaPreqLicenseFileMinimal'>
            <Payload Name='mbapreq.dll' Compressed='yes' SourceFile='wixstdba.dll' />
        </PayloadGroup>

        <CustomTable Id='WixMbaPrereqInformation'>
            <Row>
                <Data Column='PackageId'>!(wix.WixMbaPrereqPackageId)</Data>
                <Data Column='LicenseFile'>!(wix.WixMbaPrereqLicenseRtf)</Data>
            </Row>
        </CustomTable>
    </Fragment>


## Proposal

Because the row was authored using Wix binder variables, the WixBalExtension cannot get rid of that authoring in 3.x and be fully backwards compatible. Therefore, adding support for multiple prerequisite packages will be implemented differently between 3.x and 4.x.


## Proposal - 3.x

Add support to the WixBalExtension to allow a `PrereqSupportPackage` attribute on all XxxPackage elements.  When set to `yes`, the extension will add the package identity to the `MbaPrequisiteSupportPackage` table. The MbaPrequisiteSupportPackage table will be marked with `bootstrapperApplicationData='yes'` such that the prerequisite package identities will be stored in the `BootstrapperApplicationData.xml` file.

For example:

    <Chain>
      <ExePackage Id='MyPrequisitePackage' bal:PrereqSupportPackage='yes' ... />
      <MsiPackage Id='MyOtherPackage' ... />
    </Chain>

The mbaprereq BA will use the prerequisite package identities from the BootstrapperApplicationData.xml as the list of packages to allow to be installed. In other words, during Plan() the mbaprereq BA will request a prerequisite package to be installed, `BOOTSTRAPPER_REQUEST_STATE_PRESENT`,  and all other packages to none, `BOOTSTRAPPER_REQUEST_STATE_NONE`. The package's `InstallCondition` will be respected.

For backwards compatibility, the `WixMbaPrereqPackageId` binder variable (and its licence friends) will still be required. Note that because the original implementation of the mbaprereq BA always installed the package, it will continue to do so. However, the bundle can opt in to the new behavior of respecting the `InstallCondition` by setting the new `PrereqSupportPackage` attribute to `yes` on the package.  I don't know why I previously thought that it couldn't do this; using the new attribute means they should be familiar with the new behavior.

## Proposal - 4.x

 * Remove the `WixMbaPrereqPackageId`, `WixMbaPrereqLicenseUrl`, and `WixMbaPrereqLicenseRtf` binder variables.
 * Remove the `LicenseFile`, `LicenseUrl`, and `NetFxPackageId` attributes from the `WixManagedBootstrapperApplicationHost` element.
 * Rename the `PrereqSupportPackage` attribute to `PrereqPackage`, since all prereq packages will be equal.
 * Create `PrereqLicenseUrl` and `PrereqLicenseRtf` attributes that go on XxxPackage elements (just like the `PrereqPackage` element). At most one can be specified.
 * Delete the `MbaPrerequisiteSupportPackage` table.  This will require removing the assumption that there is always exactly one row in the `WixMbaPrereqInformation` table.
 * Figure out how to ensure there is at least one prereq package, at most one prereq package has a License attribute, and the type of the license attribute matches the type of WixManagedBootstrapperApplicationHost that was chosen.


## Considerations


## See Also

[WIXFEAT:4161](http://wixtoolset.org/issues/4161)