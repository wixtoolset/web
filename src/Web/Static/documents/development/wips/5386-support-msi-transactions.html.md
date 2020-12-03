---
wip: 5386
type: Feature
by: nir.bar@panel-sw.com and Sean Hall (r sean hall at gmail.com)
title: Support MSI transactions
draft: false
---

## User stories

* As a Setup developer I can upgrade multi-package bundles such that failure on any package will revert system state to what it was before the upgrade attempt.


## Proposal

MSI transactions allow multiple MSI packages to be installed or removed in a batch such that failure in any of the packages will rollback all the preceding packages in the transaction.
See more on MSDN [Multiple-Package Installations](https://msdn.microsoft.com/en-us/library/windows/desktop/bb736322(v=vs.85).aspx)

The main benefit of MSI transactions is that they can properly rollback packages that installed a major upgrade. Consider the following scenraio:

1. A bundle contains 2 packages- A and B
1. During an upgrade:
    1. Package A-v1 performs a major upgrade on package A-v0.
    1. Package B-v1 fails

With current WiX rollback implementation, package B will properly rollback to preceding state. Package A however, will be removed leaving the system with package B-v0 and without package A.

Now consider the same scenario with MSI transaction: Once package B has failed, both packages- B and A-v1 would rollback restoring the state of the system to what it was.

A possible workaround for the same problem would be to detect bundle v0 and repair it. This however, is not always feasible- for example when v0 was deployed as distinct MSI packages rather than a bundle, or if one of the packages was patched at some point.

## Considerations

- When using MSI transactions:
  - Permanent packages will be rolled back if the transaction rolls back.
  - DisableRollback causes Burn to commit the transaction even if a package failed.
- If any package internally starts a new transaction, it would fail. If this is necessary, we would need to support sending the required information for that package to join our transaction.
- If any package installs another MSI, it will install as part of the transaction.
- This means that installing other bundles as part of the chain inside of an MSI transaction requires that they don't use MSI transactions. This doesn't apply to related bundles, since they are always scheduled outside of a transaction.


## See Also

* [WIXFEAT:5386](https://github.com/wixtoolset/issues/issues/5386)
