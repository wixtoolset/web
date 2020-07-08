---
wip: 4822
type: Feature
by: Sean Hall (r sean hall at gmail.com)
title: In-Progress ARP DisplayName
draft: false
---

## User stories

* As a Setup developer I can create a bundle with permanent packages such that the ARP entry accurately reflects the current state of the installation.

## Scenario

1. User starts the per-machine bundle on a clean machine.
2. The bundle has an MBA and needs to install the .NET Framework.
3. The bundle caches itself into the package cache.
4. The bundle registers in ARP.
5. The bundle creates a RunOnce key.
6. The bundle installs the permanent .NET package, which requires a reboot.
7. The BA requests restart from OnPackageComplete.
8. The bundle updates the RunOnce key to resume after the reboot.
9. The user allows the prereq BA to reboot the machine.
10. RunOnce starts the bundle elevated.

Because RunOnce always starts the target program elevated, Burn needs to cache the bundle into the package cache (or other protected area) to be secure. In order to allow the user to clean up their machine, Burn is registering in ARP to give them a way to clean the cache. The ARP entry is confusing since it implies that the installation is complete. To avoid this confusion, Burn needs to make sure the ARP entry does not exist by the end of step 8 or the ARP entry's `DisplayName` needs to be different from when the bundle has installed a non-permanent package.


## Proposal

1. During Plan, Burn needs to pay attention to whether any non-permanent packages will be present at the end. If not, then the ARP entry should be removed and the bundle uncached on success.

2. During Plan, Burn needs to pay attention to whether any non-permanent packages are already present. If not, then the ARP entry should be removed and the bundle uncached on failure (given that there are still no non-permanent packages present).

3. Add new concept of an In-Progress ARP `DisplayName`. Burn creates the ARP entry just as it does today, with the exception that this alternate `DisplayName` is used. When Burn has installed a non-permanent package, it updates the ARP entry with the normal `DisplayName`.

4. Add new `InProgressRegistrationName` attribute to the `Bundle` element:

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

The option to make sure the ARP entry does not exist by the end of step 8 was rejected because there was potential for the cached to remain on the machine without a corresponding ARP entry.
This was deemed unacceptable.


## See Also

* [WIXFEAT:4822](https://github.com/wixtoolset/issues/issues/4822)
