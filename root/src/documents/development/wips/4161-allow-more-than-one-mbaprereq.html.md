---
wip: 4161
type: Feature
author: r.sean.hall at gmail dot com
title: Allow More Than One MBA Prerequisite
draft: false
---

## User stories

* As a setup developer I can create a managed BA and depend on the Prereq BA to install more than one dependency, not just .NET.


## Proposal

Add `MBAPrereqSupportPackage` attribute to all package types.  When set to yes, the Prereq BA will plan the package to be installed if its `InstallCondition` is true.  This attribute will be ignored by the Prereq BA if the package is the MBA Prereq (which gets planned to be installed regardless of the `InstallCondition`).


## See Also

[WIXFEAT:4161](http://wixtoolset.org/issues/4161)