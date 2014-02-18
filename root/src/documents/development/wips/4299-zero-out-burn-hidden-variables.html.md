---
wip: 4299
type: Feature
author: Sean Hall (rhall87 at hotmail.com)
title: Zero Out Burn Variables
---

## User stories

* As a Setup developer I can know that Burn variables will be zeroed out when freed such that I can be confident that they will not still be in memory when the application closes.


## Proposal

Make the burn engine call [SecureZeroMemory](http://msdn.microsoft.com/en-us/library/aa366877(VS.85).aspx) as necessary.

In the managed engine, create a new SecureStringVariables property so that the managed BA can pass the contents of a SecureString to the engine without ever putting it into a System.String.


## Considerations

The Burn engine currently stores the variable's value in memory in plaintext.  This is addressed in [WIXFEAT:4304](http://wixtoolset.org/issues/4304/).


## See Also

* [WIXFEAT:4299](http://wixtoolset.org/issues/4299/)