---
wip: 4432
type: Feature
author: r.sean.hall at gmail dot com
title: BOOTSTRAPPER_ACTION_CACHE
draft: false
---

## User stories

* As a Setup Developer I can write a BA to request a new action, `BOOTSTRAPPER_ACTION_CACHE`, such that the engine will set the default action of each package in order to get each package in the package cache.


## Background

Burn shipped in v3.6 with 7 `BOOTSTRAPPER_ACTION` types:

    enum BOOTSTRAPPER_ACTION
    {
        BOOTSTRAPPER_ACTION_UNKNOWN,
        BOOTSTRAPPER_ACTION_HELP,
        BOOTSTRAPPER_ACTION_LAYOUT,
        BOOTSTRAPPER_ACTION_UNINSTALL,
        BOOTSTRAPPER_ACTION_INSTALL,
        BOOTSTRAPPER_ACTION_MODIFY,
        BOOTSTRAPPER_ACTION_REPAIR,
    };

and 6 `BOOTSTRAPPER_REQUEST_STATE` types:

    enum BOOTSTRAPPER_REQUEST_STATE
    {
        BOOTSTRAPPER_REQUEST_STATE_NONE,
        BOOTSTRAPPER_REQUEST_STATE_FORCE_ABSENT,
        BOOTSTRAPPER_REQUEST_STATE_ABSENT,
        BOOTSTRAPPER_REQUEST_STATE_CACHE,
        BOOTSTRAPPER_REQUEST_STATE_PRESENT,
        BOOTSTRAPPER_REQUEST_STATE_REPAIR,
    };

The basic idea was for the following mapping between `BOOTSTRAPPER_ACTION` and `BOOTSTRAPPER_REQUEST_STATE` for each package:

    BOOTSTRAPPER_ACTION_UNINSTALL -> BOOTSTRAPPER_REQUEST_STATE_ABSENT
    BOOTSTRAPPER_ACTION_CACHE -> BOOTSTRAPPER_REQUEST_STATE_CACHE
    BOOTSTRAPPER_ACTION_INSTALL -> BOOTSTRAPPER_REQUEST_STATE_PRESENT
    BOOTSTRAPPER_ACTION_REPAIR -> BOOTSTRAPPER_REQUEST_STATE_REPAIR

There were two problems with this.
A big problem was that `BOOTSTRAPPER_ACTION_CACHE` didn't exist.
The other problem was that `BOOTSTRAPPER_REQUEST_STATE_CACHE` wasn't fully implemented.

[Bug 4393](http://wixtoolset.org/issues/4393/) dealt with implementing `BOOTSTRAPPER_REQUEST_STATE_CACHE`.
When the package is not installed and the requested state is `BOOTSTRAPPER_REQUEST_STATE_CACHE`, the engine should cache the package (execute action: None and cache: Yes).
When the package is installed, the package should be uninstalled and the package should stay in the cache (execute: Uninstall and uncache: No).
`MsiPackage` and `MspPackage` implemented the uninstall behavior, but otherwise `BOOTSTRAPPER_REQUEST_STATE_CACHE` didn't do anything.


## Proposal

`BOOTSTRAPPER_ACTION_CACHE` should work similarly to `BOOTSTRAPPER_ACTION_INSTALL` and `BOOTSTRAPPER_ACTION_MODIFY`: the engine should first evaluate the package's `InstallCondition`.
If it is false, then the default request state should be `BOOTSTRAPPER_REQUEST_STATE_ABSENT`.
If it is true, and `Cache` is 'yes', then the default request state depends on the current state of the package.
The default request state should be `BOOTSTRAPPER_REQUEST_STATE_CACHE` if the state is `BOOTSTRAPPER_PACKAGE_STATE_ABSENT`.
Otherwise, it should be `BOOTSTRAPPER_REQUEST_STATE_NONE`.

`BOOTSTRAPPER_ACTION_CACHE` should be placed between uninstall and install:

    enum BOOTSTRAPPER_ACTION
    {
        BOOTSTRAPPER_ACTION_UNKNOWN,
        BOOTSTRAPPER_ACTION_HELP,
        BOOTSTRAPPER_ACTION_LAYOUT,
        BOOTSTRAPPER_ACTION_UNINSTALL,
        BOOTSTRAPPER_ACTION_CACHE,
        BOOTSTRAPPER_ACTION_INSTALL,
        BOOTSTRAPPER_ACTION_MODIFY,
        BOOTSTRAPPER_ACTION_REPAIR,
    };


## Considerations

There are some conditions in the engine that are:

    BOOTSTRAPPER_ACTION_INSTALL <= action

These need to be converted to:

    BOOTSTRAPPER_ACTION_UNINSTALL < action


## See Also

[4432](http://wixtoolset.org/issues/4432/)