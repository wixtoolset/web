---
wip: 4822
type: Feature
by: Sean Hall (r sean hall at gmail.com)
title: Don't Write ARP Entry
draft: false
---

## User stories

* As a Setup developer I can create a bundle with permanent packages such that the ARP entry is not written until the bundle is actually installed.

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

Because RunOnce always starts the target program elevated, Burn needs to cache the bundle into the package cache (or other protected area) to be secure. In order to allow the user to clean up their machine, Burn is registering in ARP to give them a way to clean the cache. The ARP entry is confusing since it implies that the installation is complete. To avoid this confusion, Burn needs to make sure the ARP entry does not exist by the end of step 8.


## Proposal

Relax the requirement that there must be an entry in ARP while any part of the bundle is cached.
This allows Burn to remove the ARP entry by the end of step 8 while meeting all of the other requirements.


## Decision - Declined

It is unacceptable for any possibility of the bundle being cached without a corresponding ARP entry.
The ARP entry must always be written at the beginning of the chain.


## See Also

* [WIXFEAT:4822](https://github.com/wixtoolset/issues/issues/4822)
