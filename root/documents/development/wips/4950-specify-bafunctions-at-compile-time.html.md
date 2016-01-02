---
wip: 4950
type: Feature
by: Sean Hall (r sean hall at gmail.com)
title: Specify BAFunctions At Compile Time
draft: false
---

## User stories

* As a WiX User I can specify which DLL is the BAFunctions at compile time such that this feature is discoverable, the DLL can have a configurable name, and WixStdBA can know when the DLL is supposed to be there.


## Proposal

Add a new `bal:IsBAFunctions` attribute for the `Payload` element.
This should only be specified when the `Payload` element is inside a `BootstrapperApplicationRef` element.
This attribute puts the necessary information into BootstrapperApplicationData.xml for WixStdBA to stop blindly trying to load BAFunctions.dll.
If loading the BAFunctions fails, WixStdBA will treat it as a fatal error and immediately exit.


## Considerations

This was a "magical" feature, so it will be hard for existing users to know about this change.


## See Also

[Issue 4950](http://wixtoolset.org/issues/4950/)