---
wip: 4991
type: Feature
by: Sean Hall (r sean hall at gmail.com)
title: Handling of related bundles missing from cache
draft: false
---

## User stories

* As a Setup developer I can receive notifications of related bundles that are installed but missing from the cache such that my bundle can successfully perform the requested action from the user.

## Example scenario

1. Install BundleA v1.0.
1. Delete BundleA from the package cache (default for per-machine is C:\ProgramData\Package Cache).
1. Run BundleA v1.1 which is supposed to do a major upgrade of BundleA v1.0 from step 1.
1. BA is not notified of BundleA v1.0 because it's not present in the package cache.
1. BundleA v1.1 installs as if BundleA v1.0 is not installed on the machine.
1. BundleA v1.1 and BundleA v1.0 are now both installed and the BA had no way to know this without manually checking for related bundles.


## Proposal

To allow the BA to know about a related bundle that is registered in ARP but not in the package cache,
add a new parameter to `OnDetectRelatedBundle`:

    // Indicates whether the related bundle is missing from the package cache.
    BOOL fMissingFromCache;

During `Plan`, related bundles that are missing from the cache will be skipped just as they are today.
No messages for that related bundle will be sent to the BA during planning since it is impossible to run the bundle if it's missing.


## Considerations

The functionality for helping the BA re-cache the bundle inside the chain was moved to the WIP for #5504.


## See Also

* [WIXBUG:4991](https://github.com/wixtoolset/issues/issues/4991)
* [WIXBUG:4991](https://github.com/wixtoolset/issues/issues/5504)
