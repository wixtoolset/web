---
wip: 4889
type: Feature
by: Bob Arnson (bob@joyofsetup.com)
title: Abstract Burn containers
---

## User stories

* As a WiX Developer I can implement alternate container formats such that Burn needs no changes to support those alternate container formats.

## Proposal

Today, Burn implements containers as cabinets and code for both containers and cabinet extraction is part of Burn. I'm proposing that we move the implementation to DUtil in preparation for changing the container format away from cabinets to another format that supports better compression (e.g., LZMA).

This should happen in two steps:

1. Move containers and cabinet support from Burn to DUtil. This is the minimum viable product: In the end, Burn should behave exactly as it does today and no other code changes, such as to the build toolset, are required. This is the smallest and fastest change to get the overall work started in WiX v4.0.

2. Replace the cabinet container format with other format(s). One approach is to jump straight to LZMA, though that's not exactly a short hop because of the work needed for both Burn and the build toolset. Another approach is pick a format like Zip, which is conceptually similar to cabinets and for which we already have managed-code support for the build toolset. Whether we ship Zip support or treat it as a stepping stone is a decision that can be made at that time. This work can happen for WiX v4.0 if time is available or later in the v4.x series, given that we currently don't document the container format.

## Considerations

* I'd like to consider the container format to be opaque and subject to change so we don't need to support multiple formats. That works for Burn but might not be appreciated if it's a general library in DUtil. As we investigate other formats, we can investigate ways of choosing at link time the container format.

* We can leave the cabinet support in DUtil even if we later add Zip or LZMA support and swap it in to the container library.

* I'd love to call this `boxutil` but I'd settle for `containerutil` or `contutil` if we must.

## See Also

* [WIXFEAT:4889](http://wixtoolset.org/issues/4889/)
