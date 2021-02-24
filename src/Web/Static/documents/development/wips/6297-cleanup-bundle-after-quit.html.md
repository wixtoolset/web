---
wip: 6297
type: Feature
by: Sean Hall (r sean hall at gmail.com)
title: Cleanup Bundle After Quit
draft: false
---

## User stories

* As a Setup developer I can create a bundle such that the default behavior is to uninstall the bundle when no non-permanent packages are installed.

* As a WiX developer I can provide a bootstrapper/chainer such that system administrators can trust that it will not leave traces on the machine once uninstalled.


## Scenario

The most common scenario is for bundles with a managed BA, where the prereq BA installs .NET and then has to reboot in order to load the MBA.
See [WIP 4822](https://wixtoolset.org/development/wips/4822-dont-write-arp-entry/) for why the ARP entry is required.


## Proposal

1. During Plan, Burn needs to pay attention to whether any non-permanent packages will be present at the end. If not, then the ARP entry should be removed and the bundle uncached on success.

2. During Plan, Burn needs to pay attention to whether any non-permanent packages are already present. If not, then the ARP entry should be removed and the bundle uncached on failure (given that there are still no non-permanent packages present).

3. The package is considered present if it is installed or cached.

4. After the BA has called `Quit` with `BOOTSTRAPPER_SHUTDOWN_ACTION_NONE` and been unloaded, Burn will try to see if the bundle should be uninstalled:
  * `Apply` was never called (1 and 2 above should have taken care of it already) and
  * The bundle is installed and
  * The bundle is per-user or has already elevated and
  * There are no non-permanent packages installed and
  * No related bundles that would run during `Apply`

There are some caveats:
* It will run `Detect` if it hasn't already happened.
* Calling `Detect` will reset the condition on whether `Apply` has been called.
* Calling `Apply` with some of the special actions like `Layout` will be treated as if it had never been called because it wouldn't have had a chance to remove the registration.

If it should be uninstalled, then it will go through `Plan` and `Apply` for `Uninstall`.
Since the BA has shutdown, all of this is done without interaction with the BA.

To allow the BA to opt out of this behavior, add a new `BOOTSTRAPPER_SHUTDOWN_ACTION`:

    // Opts out of the engine behavior of trying to uninstall itself
    // when no non-permanent packages are installed.
    BOOTSTRAPPER_SHUTDOWN_ACTION_SKIP_CLEANUP,

To allow the BA to know whether this will happen, add `fEligibleForCleanup` as a parameter to `OnDetectComplete`.

    // Indicates whether the engine will uninstall the bundle if shutdown without running Apply.
    BOOL fEligibleForCleanup;


## OnUnregisterBegin

The BA will no longer be able to cancel from `OnUnregisterBegin`.
To allow the BA to stay installed despite not having any non-permanent packages present, add `fKeepRegistration` (read-only for the BA) and `fForceKeepRegistration` (writable by the BA) to `OnUnregisterBegin`:

    // Indicates whether the engine will uninstall the bundle.
    BOOL fKeepRegistration;

    // If fKeepRegistration is FALSE, then this can be set to TRUE to make the engine keep the bundle installed.
    BOOL fForceKeepRegistration;


## Considerations

Some bundles may want to stay installed despite not having any non-permanent packages present.
This is considered an advanced scenario where the BA will need to use `fForceKeepRegistration` and/or `BOOTSTRAPPER_SHUTDOWN_ACTION_SKIP_CLEANUP` if it wants to stay installed.


## See Also

* [WIXFEAT:6297](https://github.com/wixtoolset/issues/issues/6297)
* [WIXFEAT:4822](https://github.com/wixtoolset/issues/issues/4822)
