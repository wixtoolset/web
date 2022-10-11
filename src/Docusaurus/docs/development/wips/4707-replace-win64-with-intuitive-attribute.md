---
wip: 4707
type: Feature
by: Rob Mensching (rob at firegiant.com)
title: Replace Win64 Attribute with Bitness Attribute
draft: false
---

## User stories

* As a developer I can use a more intuitive interface for specifying 32-bit vs. 64-bit elements in WiX

## Proposal

Currently, several elements in the WiX codebase have a Win64 attribute (Component, CustomAction, RegistrySearch are some examples). The Win64 attribute is not very intuitive, because its "yes" value is practically useless, its only purpose would seem to be to break your build when building 32-bit packages. The -arch switch (or creating your own custom similarly-purposed preprocessor variable) is a common way to fill out this confusing attribute automatically, which then allows you to rely on the default value to do the common thing, which you can then override with "no" when you want something to be 32-bit even in a 64-bit MSI.

Instead, all Win64 attributes be removed and replaced with a 'Bitness' attribute, which will typically be omitted. It has two useful values: "always32" which forces the architecture of the element to 32-bit and "always64" which forces the element to 64-bit. The default is `default` which means the element follows the architecture specified by the "-arch" switch.

## Considerations

wix convert migration of authoring will be quite simple for users who use -arch functionality for a sane default. Users who specify their own preprocessor variable to control bitness may be in for a slightly harder time.

## See Also

* [WIXFEAT:4707][]

[WIXFEAT:4707]: http://wixtoolset.org/issues/4707/
