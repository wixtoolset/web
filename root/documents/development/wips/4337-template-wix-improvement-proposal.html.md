---
wip: 4337
type: Feature
author: Eric Schultz (eschultz at outercurve.org)
title: Support VSTO projects in the Votive Add Reference dialog
draft: true
---

## User stories

* As a developer, I can add a reference to a VSTO project on my Wix project in Votive via the Add Reference dialog

## Proposal
Provide support for referencing VSTO projects in Votive. This will be accomplished by simulating the VSTO project system support for being added as a reference.

To explain why this doesn't currently work: For a project system to be referenced via the Add Reference dialog, the custom project type must support "VSHPROPID_ShowProjInSolutionPage."
In our case, I don't think VSTO projects support this property so it's not showing up in the Add Reference box. This is not unique to Votive; the VSTO project won't show up in the dialog if you add a reference on a C# project either.

There may be a potential fix described at http://social.msdn.microsoft.com/Forums/vstudio/pt-BR/90e39196-488d-46f8-a11b-785764939140/filtering-the-project-list-in-add-reference-dialog?forum=vsx but I have no idea if that works for projects
which don't have VSHPROPID_ShowProjInSolutionPage supported through the project system. The fix would require Votive to set VSHPROPID_ShowProjInSolutionPage to true for all VSTO projects as the Add Reference
dialog box is opened and to false when the Add Reference dialog box is closed. The reason this has to be toggled is explained in considerations.

## Considerations
As eluded to in Proposal, VSHPROPID_ShowProjInSolutionPage allows a project to be added as a reference by ANY project, not just Wix projects. Toggling the property on VSTO projects on open/close for the
Add Reference dialog seems potentially error prone. There might be a better way to handle it but I'm not sure.

## See Also

* [WIXFEAT:4337](http://wixtoolset.org/issues/4337/)