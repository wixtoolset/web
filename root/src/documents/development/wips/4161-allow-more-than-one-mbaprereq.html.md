---
wip: 4161
type: Feature
author: r.sean.hall at gmail dot com
title: Allow More Than One MBA Prerequisite
draft: false
---

## User stories

* As a setup developer I can create a managed BA and depend on the Prereq BA to install more than one dependency, not just .NET.


## Proposal

Add support to the WixBallExtension to allow a `PrereqSupportPackage` attribute on all XxxPackage elements.  When set to `yes`, the extension will add the package identity to the `MbaPrequisiteSupportPackage` table. The MbaPrequisiteSupportPackage table will be marked with `bootstrapperApplicationData='yes'` such that the prerequisite package identities will be stored in the `BootstrapperApplicationData.xml` file.

For example:

    <Chain>
      <ExePackage Id='MyPrequisitePackage' bal:PrereqSupportPackage='yes' ... />
      <MsiPackage Id='MyOtherPackage' ... />
    </Chain>

The mbapreq BA will use the prerequisite package identities from the BootstrapperApplicationData.xml as the list of packages to allow to be installed. In other words, during Plan() the mbapreq BA will request A prerequisite package to be installed, `BOOTSTRAPPER_REQUEST_STATE_PRESENT`,  and all other packages to none, `BOOTSTRAPPER_REQUEST_STATE_NONE`. The package's `InstallCondition` will be respected.

The existing solution of the `WixMbaPrereqPackageId` binder variable will be deprecated in favor of this mechanism.


## Considerations

The spec originall called out this case in the proposal:

    This attribute will be ignored by the Prereq BA if the package is the MBA Prereq (which gets planned to be installed regardless of the `InstallCondition`).

I don't know why this is necessary. It doesn't seem like the mbapreq ever forces a package to be installed.


## See Also

[WIXFEAT:4161](http://wixtoolset.org/issues/4161)