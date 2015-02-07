---
wip: 4149
type: Feature
author: Sean Hall (rseanhall at gmail.com)
title: thmutil variable support
draft: false
---

## User stories

* As a setup developer I can conditionally hide thmutil controls such that wixstdba messages can be customized based on context.


## Proposal - Part 1

Add callbacks to thmutil so that it can do operations with variables and conditions.
Add EnableCondition and VisibleCondition attribute on all of the controls.

When showing a page, thmutil will disable a control if the EnableCondition evaluates to false.  Otherwise, it will enable the control.
thmutil will hide a control if Visible="no", the control is disabled and HideWhenDisabled="yes", or if Visible="yes" and the VisibleCondition evaluates to false.  Otherwise, it will show the control.

Remove the code in wixstdba that looked for the [ControlName]State variable to do roughly the same thing.


## Proposal - Part 2

Overhaul the thmutil schema by moving all elements except `Font` under the `Window` element, since that's conceptually where they are.
Remove all undocumented aliases in the parsing implementation.
Create a new `Text` element that has a `Condition` attribute.
This element goes inside of a control element, which makes customizing a control's text much easier
(without this you would have to have multiple overlapping controls, where only one control is visible at a time).  Rename the old `Text` control to `Label`.


## Considerations

There was a lot of discussion on wix-devs about this.
In WiX v3.10, WixStdBA was hard coded to hide and show specific controls on the Success and Failure page in order to display different messages based on which operation was being done.


## See Also
[Discussion on wix-devs](http://windows-installer-xml-wix-toolset.687559.n2.nabble.com/WIXFEAT-4149-Add-UninstallSuccess-page-to-WixStdBA-td7594480.html)
[WIXFEAT:4149](http://wixtoolset.org/issues/4149/)
