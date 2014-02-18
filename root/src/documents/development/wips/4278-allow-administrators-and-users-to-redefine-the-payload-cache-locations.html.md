---
wip: 4278
type: Feature
author: Heath Stewart (heaths at microsoft.com)
title: Allow administrators and users to redefine the payload cache locations
---

## User stories

* As an administrator or normal user I can change the default location or payload caches.
* As an administrator or normal user I can move the payload cache location safely and securely.

## Proposal

Burn should define a set of KNOWNFOLDERIDs for per-user and per-machine payload cache locations. This allows administrators and power users to set the default location for the payload caches, which can be very large. This would apply to all bundles.

We should also provide guidance or even a utility for administrators and power users to move an existing cache complete with the proper ACLs to maintain the security model as originally designed for Burn's payload cache.

## Considerations

KNOWNFOLDERIDs and associated APIs are not supported by Windows XP. They were added in Windows Vista. Documentation does not suggest a way to crete new CSIDLs for legacy support - only how to get and set pre-defined system folders - so Windows XP is out of support and the fallback behavior for Burn would apply.

### Known folders not yet defined

If the known folder IDs are not yet defined in either the user or elevated context, each respective context will create the known folder mapping to the default location as currently defined in Burn (AppData or ProgramData).

On Windows Vista and newer, call `CoCreateInstance` with `CLSID_KnownFolderManager` to get an instance of [IKFM][] and call `RegisterFolder` to create new mappings.

### Known folders not yet created

If the known folder IDs are defined but the folders are not yet created, Burn should create these as it currently does but verify that ACL inheritance would define the proper security. This is to support when the defined folder locations are not under AppData or ProgramData but some custom directory.

The code might also just not inherit and instead create the necessary ACL, but administrators may choose to further lock down permissions to ProgramData so inheritting - when secure to do so - is probably best.

### Older versions of Burn

Older versions of Burn will continue to check "%ProgramData%\Package Cache", so to support newer versions of Burn that support this particular feature and share cached payloads between old and new Burn versions we will default the KNOWNFOLDERID to a separate path, ex: "%ProgramData%\Package Files". Newer versions of Burn that support this feature would first query for and check the folder defined by the KNOWNFOLDERID, followed by the current "Package Cache" folder.

While an older bundle may cache a package twice in this manner, it seems logical that newer bundles would install newer packages more often than older bundles. Newer versions of Burn would at least consider both locations to reduce duplication of payloads.

### Known folder location is moved

Guidance should be provided to administrators that known folder locations have certain DACLs to be security. Administrators can choose to use whatever deployment tools they wish to define or redirect KNOWNFOLDERIDs we define.

We should also write a utility that calls `Redirect` on [IKFM][] with the following attribute to move the payload cache with a progress UI:

    KF_REDIRECT_COPY_SOURCE_DACL
    KF_REDIRECT_OWNER_USER
    KF_REDIRECT_SET_OWNER_EXPLICIT
    KF_REDIRECT_WITH_UI
    KF_REDIRECT_COPY_CONTENTS
    KF_REDIRECT_DEL_SOurCE_CONTENTS

The Burn engine itself could even provide a command line parameter to operate in this mode - which makes the feature more accessible - but really feels like we're overloading the engine. (For comparison, _msiexec.exe_ supported -regserver and -unregserver prior to Windows Vista.)

### Cache location is inaccessible

Prior to this feature, if AppData or ProgramData were unavailable Windows itself probably wouldn't even function right so this consideration would be out of scope.

However, now that we allow redirection to - for example - a separate drive which may not be attached when necessary, Burn must gracefully handle this situation. I propose that we use the same fallback logic to AppData or ProgramData and if the cache is missing we download it again. If no payload URLs are provided, the situation is no worse than before and the bundle would fail like it would without this feature implemented.

To support when the drive is reattached, the payload cache in the old/fallback location would be an extra copy. So when a bundle is uninstalled, it should check for the payload cache in both the redirected location and the fallback location and remove both when appropriate to do so. Comparing the two locations wouldn't be necessary since, if these calls were made subsequently, the check for the cache in the fallback location would fail since the cache was already removed by the first check to the known folder location.

## See Also

* [Feature][]
* [IKFM][]

[Feature]: http://wixtoolset.org/issues/4278/ "WIXFEAT:4278"
[IKFM]: http://msdn.microsoft.com/en-us/library/windows/desktop/bb761744.aspx "IKnownFolderManager"
