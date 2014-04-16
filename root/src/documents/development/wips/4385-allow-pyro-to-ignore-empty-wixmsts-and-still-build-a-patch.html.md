---
wip: 4385
type: Feature
author: Sam Slutzky (samuels at microsoft.com)
title: Allow Pyro to Ignore Empty Wixmsts and Still Build a Patch
draft: true
---

## User stories

* As a Setup developer I can author a patch that targets multiple Components share across Products such that a patch can be built successfully even if one or more of the WixMsts for said Products contains no changes.


## Proposal

Currently, I may have a patch that targets multiple Components A, B, and C and multiple Products Y and Z. It may be that Product MSI Z contains Components A and C while Product MSI Y contains Components B and C.

My Product may also have various baselines such as RTM and Service Pack 1. The current Pyro design makes it difficult to build such a patch. If a Binary in Component B changes, the patch should correctly update Product MSI Y but it will not because the .wixmst for Product MSI Z contains no changes.

This requires a huge amount of maintenance to continually update the patch definitions and know when Components have changes.

This proposal therefore is a feature request to allow Pyro, with a command-line parameter, to ignore the empty transform for Product Z in this case and simply patch Product Y. Later, when other changes are made to the Products, the patch will be able to pick them up and target both Product MSI Z and Y.

To accomplish this, a new command-line parameter, -aet will be added to Allow Empty Transforms.  The code change would then be roughly as follows:

1) A new WixWarning will be added with the same structure as the current NoDifferencesInTransform WixError.
2) In src\wix\Binder.cs's BindTransform(), if GenerateTransform() fails, instead of throwing a new WixException, simply call this.core.OnMessage() with the new WixWarning.
3) If GenerateTransform() succeeds, call CreateTransformSummaryInfo() as before.


## Considerations

Should an error be thrown if -aet is provided and no transforms have changes?

## See Also

* [Feature][]

[Feature]: http://wixtoolset.org/issues/4385/ "WIXFEAT:4385"