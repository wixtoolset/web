---
wip: 6296
type: Feature
by: Sean Hall (r sean hall at gmail.com)
title: In-Progress ARP DisplayName
draft: false
---

## User stories

* As a Setup developer I can create a bundle with permanent packages such that the ARP entry accurately reflects the current state of the installation.


## Scenario

The most common scenario is for bundles with a managed BA, where the prereq BA installs .NET and then has to reboot in order to load the MBA.
See [WIP 4822](https://wixtoolset.org/development/wips/4822-dont-write-arp-entry/) for why the ARP entry is required.


## Proposal

Add new concept of an In-Progress ARP `DisplayName`. Burn creates the ARP entry just as it does today, with the exception that this alternate `DisplayName` is used. When Burn has installed a non-permanent package, it updates the ARP entry with the normal `DisplayName`.

Add new `InProgressRegistrationName` attribute to the `Bundle` element:

    <xs:attribute name="InProgressRegistrationName" type="xs:string">
        <xs:annotation>
            <xs:documentation>
                The Bundle creates an ARP entry at the beginning of installation to allow clean uninstallation even if things go wrong.
                This name is used as the display name for the ARP entry until a non-permanent package is installed.
                Specifying this name is strongly recommended for Bundles that can reboot in the middle of installation so that the user can tell that installation hasn't completed.
            </xs:documentation>
        </xs:annotation>
    </xs:attribute>


## Considerations

Some people may want the `InProgressRegistrationName` to be used whenever an installation is happening, whether or non a non-permanent package has been installed.


## See Also

* [WIXFEAT:6296](https://github.com/wixtoolset/issues/issues/6296)
* [WIXFEAT:4822](https://github.com/wixtoolset/issues/issues/4822)
