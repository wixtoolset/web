---
wip: 6297
type: Feature
by: Sean Hall (r sean hall at gmail.com)
title: Cleanup Bundle After Quit
draft: false
---

## User stories

* As a Setup developer I can create a bundle such that the default behavior is to uninstall the bundle when no non-permanent packages are installed.


## Scenario

The most common scenario is for bundles with a managed BA, where the prereq BA installs .NET and then has to reboot in order to load the MBA.
See [WIP 4822](https://wixtoolset.org/development/wips/4822-dont-write-arp-entry/) for why the ARP entry is required.


## Proposal

1. During Plan, Burn needs to pay attention to whether any non-permanent packages will be present at the end. If not, then the ARP entry should be removed and the bundle uncached on success.

2. During Plan, Burn needs to pay attention to whether any non-permanent packages are already present. If not, then the ARP entry should be removed and the bundle uncached on failure (given that there are still no non-permanent packages present).

3. After the BA has called `Quit` with `BOOTSTRAPPER_SHUTDOWN_ACTION_NONE` and been unloaded, Burn will try to see if the bundle should be uninstalled (it will run `Detect` if it hasn't already happened):
  * `Apply` was never called (1 and 2 above should have taken care of it already) and
  * The bundle is installed and
  * The bundle is per-machine or has already elevated and
  * There are no non-permanent packages installed and
  * No related bundles that would run during `Apply`

If it should be uninstalled, then it will go through `Plan` and `Apply` for `Uninstall`.
Since the BA has shutdown, all of this is done without interaction with the BA.

To allow the BA to opt out of this behavior, add a new `BOOTSTRAPPER_SHUTDOWN_ACTION`:

    // Opts out of the engine behavior of trying to uninstall itself
    // when no non-permanent packages are installed.
    BOOTSTRAPPER_SHUTDOWN_ACTION_SKIP_CLEANUP,

To allow the BA to know whether this will happen, add `fEligibleForCleanup` as a parameter to `OnDetectComplete`.

    // Indicates whether the engine will uninstall the bundle if shutdown without running Apply.
    BOOL fEligibleForCleanup;


## Considerations

Some bundles use the `Cache` action to purposely stay in the package cache despite not having any non-permanent packages installed.
This is considered an advanced scenario where the BA will need to use `BOOTSTRAPPER_SHUTDOWN_ACTION_SKIP_CLEANUP` if it wants to stay cached.


## See Also

* [WIXFEAT:6297](https://github.com/wixtoolset/issues/issues/6297)
* [WIXFEAT:4822](https://github.com/wixtoolset/issues/issues/4822)
