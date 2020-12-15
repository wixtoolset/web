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


## Proposal - Notification

To allow the BA to know about a related bundle that is registered in ARP but not in the package cache,
add a new parameter to `OnDetectRelatedBundle`:

    // Indicates whether the related bundle is missing from the package cache.
    BOOL fMissingFromCache;

## Proposal - Mitigation

To help related bundles gracefully handle the scenario where they're missing from the cache, add the hash and file size to the ARP registration.
Also, add a new attribute to the `Bundle` element which will be written to the ARP registration if specified.

    <xs:attribute name="DownloadUrl" type="xs:string">
      <xs:annotation>
        <xs:documentation>
          The URL to use to download the bundle if missing from the package cache.
        </xs:documentation>
      </xs:annotation>
    </xs:attribute>

Add two new parameters to `OnDetectRelatedBundle`:

    // Indicates whether the engine has the hash and file size of the related bundle to be able to recache it.
    BOOL fCanBeRecached;
    // The download url for the related bundle.
    LPCWSTR wzDownloadUrl;

During `Plan`, related bundles that are missing from the cache will be skipped unless the hash and file size are available.
That means that there will also be no message(s) sent to the BA for that bundle.

If the hash and file size are available, then the default action will depend on whether there's a download url for the bundle.
If it is not available, then the default action will be to do nothing.
Otherwise, the default action will be the same as if it were present in the cache.


## Considerations

The Mitigation Proposal is not strictly necessary, but it helps avoid an extra UAC prompt for per-machine bundles and helps the BA to avoid manually fixing the related bundle outside of the chain.

Burn has only cached itself into the package cache so far, so there might be some implementation details to work out when putting other bundles into the cache.
For example, the `DownloadUrl` will likely point to a bundle with the attached container but the hash and file size will be for the stripped down bundle.


## See Also

* [WIXBUG:4991](https://github.com/wixtoolset/issues/issues/4991)
