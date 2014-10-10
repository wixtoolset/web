---
wip: 4149
type: Feature
author: Sean Hall (rseanhall at gmail.com)
title: thmutil variable support
draft: false
---

## User stories

* As a setup developer I can conditionally hide thmutil controls such that wixstdba messages can be customized based on context.


## Proposal

Add the ability to provide thmutil with an IVariableStore (see [WIP 4552](http://wixtoolset.org/development/wips/4552-variable-abstraction)).
Add EnableCondition and VisibleCondition attribute on all of the controls.

When showing a page, thmutil will disable a control if the EnableCondition evaluates to false.  Otherwise, it will enable the control.
thmutil will hide a control if Visible="no", the control is disabled and HideWhenDisabled="yes", or if Visible="yes" and the VisibleCondition evaluates to false.  Otherwise, it will show the control.

Remove the code in wixstdba that looked for the [ControlName]State variable to do roughly the same thing.


## Considerations

There was a lot of discussion on wix-devs about this.
The suggestion for child Content elements seems to be a nice thing to have that can be added later.


## See Also
[Discussion on wix-devs](http://windows-installer-xml-wix-toolset.687559.n2.nabble.com/WIXFEAT-4149-Add-UninstallSuccess-page-to-WixStdBA-td7594480.html)
[WIXFEAT:4149](http://wixtoolset.org/issues/4149/)
