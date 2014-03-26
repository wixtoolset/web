---
wip: 4299
type: Feature
author: Sean Hall (r.sean.hall at gmail.com)
title: Improve Security for Hidden Burn Variables
---

## User stories

* As a Setup developer I can know that Burn variables will be zeroed out when freed such that I can be confident that they will not still be in memory when the application closes.  In addition, hidden variables will be encrypted while not being used.


## Proposal

Make the burn engine call [SecureZeroMemory](http://msdn.microsoft.com/en-us/library/aa366877(VS.85).aspx) as necessary.

Make the burn engine encrypt the values in the BURN_VARIANT struct.

In the managed engine, create a new SecureStringVariables property so that the managed BA can pass the contents of a SecureString to the engine without ever putting it into a System.String.


## Considerations

This greatly reduces the window of opportunity of an adversary to get the unencrypted value, but it doesn't eliminate it.  For example, if the engine's process is forcibly killed then it won't be able to make sure that the memory was zeroed out.


## See Also

* [WIXFEAT:4299](http://wixtoolset.org/issues/4299/)