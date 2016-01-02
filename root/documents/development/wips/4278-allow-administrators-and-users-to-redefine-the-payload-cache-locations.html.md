---
wip: 4278
type: Feature
by: Heath Stewart (heaths at microsoft.com)
title: Allow administrators and users to redefine the payload cache locations
---

## User stories

* As an administrator or normal user I can change the location of the package.

## Proposal

Because the package cache can be very large, Burn should get the location of the package cache from registry policy. Administrators and normal users can then use a different location than the default currently on the system drive.

## Considerations

Registry policy keys are a common way to define define and overwrite settings for applications. They are supported on all versions of Windows and are easy to define across an enterprise.

There were other considerations including `KNOWNFOLDERIDs`; however, `KNOWNFOLDERIDs` are not supported on Windows XP - they were introduced in Vista, and their predecessor is not extensible - are require administrative privileges to define. That would prevent per-user bundles from defining `KNOWNFOLDERIDs` if undefined.

### Registry policy not defined

When the registry policy is not defined, Burn will use the default package cache location of "%ProgramData%\Package Cache".

### Registry policy set to default

When the registry policy is set to the default value, Burn will still use the default package cache location of "%ProgramData%\Package Cache".

### Registry policy set to custom

When the value of the registry policy is set and is not the default value, Burn will use the specified location first to find packages. If packages are not found in the specified location, Burn will check for the packages in the default location of "%ProgramData%\Package Cache".

### Older bundles do not support the registry policy

Because older bundles do not understand or support this new registry policy, the current default location of "%ProgramData%\Package Cache". This will also support newer bundles that share packages with older bundles, since installing the older bundles first will put the packages in the current default location.

In the case where a newer bundle installs shared packages, newer bundles would attempt to recache those packages in the current default. While not ideal, most likely newer bundles would be installed after older bundles regardless of the product. Further in the future, still fewer older bundles would likely be installed so this problem eventually subsides.

### Registry policy changed multiple times

Burn will not track multiple changes to the registry policy. If the registry policy value is changed a second time to a custom value, any packages in the cache from the first change to a custom value would be ignored and non-discoverable. Administrators should not change this value multiple times if bundles have been installed when a custom location has already been set.

### Cache location is inaccessible

Prior to this feature, if AppData or ProgramData were unavailable Windows itself probably wouldn't even function right so this consideration would be out of scope.

However, now that we allow redirection to - for example - a separate drive which may not be attached when necessary, Burn must gracefully handle this situation. I propose that we use the same fallback logic to AppData or ProgramData and if the cache is missing we download it again. If no payload URLs are provided, the situation is no worse than before and the bundle would fail like it would without this feature implemented.

To support when the drive is reattached, the payload cache in the old/fallback location would be an extra copy. So when a bundle is uninstalled, it should check for the payload cache in both the custom location and the fallback location and remove both when appropriate to do so. Comparing the two locations wouldn't be necessary since, if these calls were made subsequently, the check for the cache in the fallback location would fail since the cache was already removed by the first check to the known folder location.

## Design

The following registry keys are defined for Burn policy settings.

The cache location is defined in registry value "CacheLocation" as a `REG_SZ` type that should not use environment variables. Burn will not expand these to avoid potential security issues.

The registry key is defined as the same location for 32- and 64-bit locations since the Software\Policies key is [shared][WOW64].

### Per-machine policy

For secure, per-machine settings including the package cache location, the following registry key is defined.

    HKLM\Software\Policies\Wix\Burn

### Per-user policy

The per-user registry policy for settings is defined as follows.

    HKCU\Software\Policies\Wix\Burn

## See Also

* [Feature][]
* [Registry keys affected by WOW64][WOW64]

[Feature]: http://wixtoolset.org/issues/4278/ "WIXFEAT:4278"
[WOW64]: http://msdn.microsoft.com/en-us/library/windows/desktop/aa384253(v=vs.85).aspx "Registry keys under WOW64"
