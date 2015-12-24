---
wip: 4951
type: Feature
author: Sean Hall (r sean hall at gmail.com)
title: Make BAFunctions Interface Binary and Forward All BA Messages
draft: false
---

## User stories

* As a WiX Developer I can add methods (or add parameters to methods) to the BAFunctions API such that WiX Users can continue to compile their BAFunctions after upgrading the WiX Toolset without making any changes (adding methods and adding parameters are never breaking changes).

* As a WiX User I can use my compiled BAFunctions with any later version of the WiX Toolset with the same major version (the BAFunctions API will maintain binary compatibility).


## Proposal

Create BAFunctionsProc function that is like BAProc and BAEngineProc.
This makes it trivial for WixStdBA to forward all BA messages to BAFunctions.
After processing each BA message, WixStdBA will forward it to BAFunctions.
Logging needs to be added around certain messages just like the engine does to make it clear when BAFunctions alters important decisions.


## Considerations

BAFunctions already has unrestricted access to the engine, but WixStdBA might want to start intercepting calls to log when they come from BAFunctions.


## See Also

[Issue 4951](http://wixtoolset.org/issues/4951/)

[Issue 4773](http://wixtoolset.org/issues/4773/)