---
wip: 4773
type: Feature
by: Sean Hall (r sean hall at gmail.com)
title: Modify Burn API
draft: false
---

## User stories

* As a WiX Developer I can add methods (or add parameters to methods) to the Burn API such that WiX Users can continue to compile their custom Bootstrapper Application after upgrading the WiX Toolset without making any changes (adding methods and adding parameters are never breaking changes).

* As a WiX User I can use my compiled custom Bootstrapper Application with any later version of the WiX Toolset with the same major version (the Burn API will maintain binary compatibility).


## Background

The Burn engine works with the Bootstrapper Application to handle the Bundle's installation operations.
The unelevated engine and the BA live in the same process.
There needed to be a way for the engine and the BA to communicate to each other, and it had to be something that unmanaged code could use as well as managed.

In the first version of Burn (WiX v3.x), the engine exposed its functionality through the IBootstrapperEngine COM interface, and called into the BA through the IBootstrapperApplication COM interface.
As newer version were released, methods were added and modified to IBootstrapperApplication.
The first changes were in v3.7, they modified existing methods and added new ones.
Due to the feedback from WiX Users when upgrading, the WiX team tried to leave the interfaces alone.
In v3.9, the WiX team allowed some new methods to be added as well as adding a default parameter to an existing method (maintaining "compile time" compatibility but not binary compatibility).
This brought in multiple bug reports from users where their bundle crashed because of compiling their BA against the wrong version of the toolset.


## Proposal

I propose that Burn offers two options when developing a custom BA: message based or interface based.
Using Win32 messages with structs that have a cbSize member is a proven way to maintain an API that can be extended over time.
This also gives the benefit of maintaining binary compatibility between releases.
The interface option would be an abstraction layer provided by the toolset to hide the fact that the engine is sending Win32 messages instead of making calls on a COM interface.

I propose that we swap the guarantees we give today on the interfaces: a BA compiled to the COM interface will be binary compatible to future releases, but the interface can be changed between releases.
Since the COM interfaces will use the Win32 messages behind the scenes, binary compatibility is free.
I believe that WiX Users would be willing to accept that upgrading the toolset that the BA is compiled against may require modification of their source code, because they could upgrade the Bundle's toolset independently of the BA's toolset (since they'll probably use Nuget to provide the headers for their BA).


## Considerations


## See Also

[Issue 4773](http://wixtoolset.org/issues/4773/)