---
wip: 4867
type: Feature
by: Rob Mensching (rob at firegaint.com)
title: SWID Tag 2015 Support
---

## User stories

* As a setup developer I can easily support the ISO/IEC 19770-2:2015 specification such that my software is compliant with large organizations purchasing requirements.


## Proposal

The WiX toolset provides support for the first release of the ISO/IEC 19770-2, better known as Software Identity Tags or SWID Tags. In 2015 the original specification was completely reworked, rendering the existing WiX toolset support invalid. Demand for SWID Tags is growing as organizations look to ISO/IEC 19770-2:2015 to help manage their software.

There are three major changes in the latest relese of the specification:

1. Streamlined XML Format. Previously, the specification avoided the use XML attributes in the SWID tag XML. The new specification utilitizes attributes to reduce the number of defined elements.

2. Simplified Regids. Previously, the definition of Regids required the year and month the a domain name was registered (e.g. "regid.1995-08.com.example"). The new Regid format uses a simplified URI where "http://" and "www." are removed when possible.

3. New Install Location. Previousy, SWID tags were installed in a folder under `CommonAppDataFolder` (for per-machine packages) or `LocalAppDataFolder` (for per-user packages). Now SWID tags are to be installed in a `swidtag` folder under the install location of the installation package.

The latter two changes require breaking changes to definition of SWID tags in the WiX toolset. In particular, the old .wxs authoring that would look like:

    <swid:Tag Regid="regid.1995-08.com.example" />

Changes the Regid and requires the user to specify the install location:

    <swid:Tag Regid="example.com" InstallDirectory="INSTALLFOLDER" />

When used in a bundle, there is no Directory tree to reference so a full path must be specified:

    <swid:Tag Regid="example.com" InstallPath="[ProgramFilesFolder]\Example Company\Example Application\" />

To minimize the damage of the breaking change but actively encourage developers using WixTagExtension to move to the new specification, when a `Regid` attribute in the old format is encountered the extension will display a new warning informing the developer of the deprecation and indicate the `Tag` element is ignored.

To have a SWID Tag included in their product in WiX v3.10+, developers will need to use the new Regid format and set the `InstallDirectory` or `InstallPath` attribute appropriately.


## Considerations

* We did consider continuing to support the old SWID tag format. However, it was requested to strongly encourage developers to move forward to the new specification and not ship SWID tags following the old specification. Thus the decision to use a warning (not immediately break upgrades to WiX v3.10) but also not create the old tag.

* It would be ideal if the SWID Tag extension could use `ARPINSTALLLOCATION` to avoid requiring the `InstallDirectory` attribute. Unfortunately, `ARPINSTALLLOCATION` is designed to be set via a custom action and ICEs prevent it from appearing the in the Directory table. That prevents its use as a parent for the "swidtag" Directory. In future versions of the WiX toolset, we could reevaluate the utility of the ICE and define `ARPINSTALLLOCATION` as a Directory.

* Burn does not currently provide a mechanism like `ARPINSTALLLOCATION`. Definining such a mechanism could allow the WixTagExtension to automatically calculate the installation location for the SWID tag.

## See Also

* [WIXFEAT:4867](http://wixtoolset.org/issues/4867/)
