---
under: Documentation
title: Error 217
subtitle: for the WiX toolset
keywords: wix toolset,wix
layout: secondary
sidebarTitle: Additional information
sidebarSubtitle: The following external resources are useful but not managed by the WiX community:
sidebarItems:
  - uri: http://blogs.msdn.com/b/heaths/archive/2007/05/31/windows-installer-errors-2738-and-2739-with-script-custom-actions.aspx
    text: Heath Stewart's Explanation
  - uri: http://blogs.msdn.com/b/astebner/archive/2007/06/07/3151752.aspx
    text:  Aaron Stebner's Explanation
---

## Error 217

In WiX v3, Light automatically runs validation, [Windows Installer Internal Consistency Evaluators (ICEs)[ices],
after every successful build. Validation is a great way to catch common authoring errors that can lead to
servicing problems. That is why ICEs are now run by default. Unfortunately, there is an issue that can occur on
Windows Vista and Windows Server 2008 that can cause ICEs the to fail.

For details on the cause and how to fix it, see the additional resources in the sidebar.

  [ices]: http://msdn.microsoft.com/en-us/library/aa369554(VS.85).aspx
