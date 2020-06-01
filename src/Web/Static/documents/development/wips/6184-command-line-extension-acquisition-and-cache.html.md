---
wip: 6184
type: Feature
by: Rob Mensching (rob at firegiant.com)
title: Command-line Extension Acquisition and Cache
---

## User stories

* As a Setup developer I can acquire extensions for use by a command-line build.

* As a WiX extension developer I only have to publish my extension via NuGet and Setup developers can access it via the command-line build and MSBuild/NuGet project-based build.

## Proposal

Add a new command to `wix.exe` to download and extract extensions from NuGet packages into an "extension cache" for easy reference by the `build` command. This design is inspired by the `dotnet tool` command which manages local and global .NET Core tools.

The new `extension` command will have three sub-commands:

1. `add` - adds the extension to the local or global cache. The NuGet package id must be provided and a `--version` switch is optional.
2. `remove` - removes an extension from the local or global cache. The NuGet package id must be provided and a `--version` switch is optional.
3. `list` - lists the extensions in the local or global cache.

Each sub-command accepts a `-g` switch to use to the global cache instead of the local cache.


### Cache Locations

The extensions NuGet packages are extracted to a `.wix\extensions\[packageId]\[packageVersion]` cache folder.

For local packages, the root cache folder is the current directory when the `wix.exe extension` command is executed. Care must be taken by the Setup developer to set the current directory correctly when adding extensions and building using them.

For global packages, the root cache folder defaults to  the user's home folder (`%USERPROFILE%`). The global cache root folder can be overridden using the `WIX_EXTENSION` environment variable.


### Referencing Cached Extensions

Extensions in the cache will be referenced by their package id, for example:

    wix extension add WixToolset.Util.wixext
    wix build -ext WixToolset.Util.wixext source.wxs

The local cache is always checked before the global cache.

Extensions can always be referenced by a `build` command using the full path and will bypass the cache look-up, for example:

    wix build -ext C:\ext\WixToolset.Util.wixext.dll source.wxs


## Considerations

1. Should MSBuild/dotnet build use the extension cache or only depend on project's package references being restored during the build?

   Suggestion: No. Let the extension cache only be used by the command-line and the NuGet package cache used for MSBuild/dotnet build. This does mean the extensions shared between command-line builds and project based builds are cached twice but a) we don't expect devs to generally use _both_ command-line _and_ project based options and b) extensions are small.

2. Should we make the `.wixext` optional when referencing via the `-ext` switch?

   Suggestion: No. It is inconsistent as ".wixext" will be required to find the package in a NuGet feed.


## See Also

* [WIXFEAT:6184](https://github.com/wixtoolset/issues/issues/6184)
