---
wip: 6164
type: Feature
by: Sean Hall (r sean hall at gmail.com)
title: Move DisplayInternalUI from Core to BalExtension
draft: false
---

## User stories

* As a Setup developer I can have more control over when my bundle shows the MSI UI such that I can keep using my existing MSI UI.


## Background

I looked through the wix-users list and users are asking for everything between `DisplayInternalUI` being configurable at runtime and wanting the full MSI UI for every operation (install/modify/repair/uninstall).
There are 3 different approaches we can take in v4 for Burn.

1. Remove `DisplayInternalUI` entirely. This enforces the design decision for Burn that there should be one unified UI for the bundle (documented in http://robmensching.com/blog/posts/2012/6/25/b-is-for-bundle-and-thats-good-enough-for-me/ and http://www.joyofsetup.com/2013/07/05/burn-zero-one-or-n/).

2. Continue with the v3 design of `DisplayInternalUI` - allow the MSI UI to be shown, but the Burn engine will ensure that the user/MSI can only do what was planned.
The basic idea to implement this approach is to expose `MsiEngineCalculateInstallUiLevel` as a BA message, but disallow certain UI levels when not doing an install.
This satisfies some user requests but many want full MSI UI during maintenance operations, e.g. feature selection during Modify.

3. Allow the BA full control of the UI level of the MSI, even if that means the user/MSI ends up doing something other than what was planned.
The basic idea to implement this approach is to expose `MsiEngineCalculateInstallUiLevel` as a BA message, and allow disabling the Burn external UI handler to support EmbeddedUI.
This should satisfy all user requests, or at least enable them to build a BA that can do what they want.

If we take #3 for Burn, then there are 3 similar approaches we can take for wixstdba.

1. Remove support for displaying MSI UI.

2. Continue with the v3 design of `DisplayInternalUI`.
The basic idea behind this approach is to use the same logic that v3 Burn used to restrict uiLevel, so MSI UI is can only be shown during install.
The external UI handler is always used.

3. Allow the Setup developer to show MSI UI during non-install operations.


## Proposal - Burn

Take approach #3. Add new event for OnPlanMsiPackage:

    enum BURN_MSI_PROPERTY
    {
        BURN_MSI_PROPERTY_NONE,     // no property added
        BURN_MSI_PROPERTY_INSTALL,  // add BURNMSIINSTALL=1
        BURN_MSI_PROPERTY_MODIFY,   // add BURNMSIMODIFY=1
        BURN_MSI_PROPERTY_REPAIR,   // add BURNMSIREPAIR=1
        BURN_MSI_PROPERTY_UNINSTALL,// add BURNMSIUNINSTALL=1
    };

    struct BA_ONPLANMSIPACKAGE_ARGS
    {
        DWORD cbSize;
        LPCWSTR wzPackageId;
        BOOL fExecute; // false means rollback.
        BOOTSTRAPPER_ACTION_STATE action;
    };

    struct BA_ONPLANMSIPACKAGE_RESULTS
    {
        DWORD cbSize;
        BOOL fCancel;
        BURN_MSI_PROPERTY actionMsiProperty;
        INSTALLUILEVEL uiLevel;
        BOOL fDisableExternalUiHandler;
    };

Burn will:
* Call `OnPlanMsiPackage` for each MSI or MSP package authored in the chain, somewhere between `OnPlanPackageBegin` and `OnPlanPackageComplete`.
* Default `actionMsiProperty` based on the planned action.
* Always default `uiLevel` to `INSTALLUILEVEL_NONE | INSTALLUILEVEL_SOURCERESONLY`.
* Always default `fDisableExternalUiHandler` to false.
* Provide `uiLevel` and `fDisableExternalUiHandler` in `BA_ONEXECUTEPACKAGEBEGIN_ARGS` so the BA doesn't have to keep track of what it chose during plan.


## Proposal - wixstdba

Take approach #3.
Move the `DisplayInternalUI` attribute into the `BalExtension`.
Modify the attribute to take a condition so that it can be configured at runtime, and rename it to `DisplayInternalUICondition`.
If not specified, then internal UI will never be shown.
The same condition is used for all operations.
wixstdba will not change the value of `actionMsiProperty`.
wixstdba will not support EmbeddedUI so it will not change the value of `fDisableExternalUiHandler`.
This is because if the Setup developer has the resources to implement embedded UI, then they should spend those resources creating a custom theme for wixstdba or create a custom BA.


## Proposal - UI.wixext

Teach all of the built-in UIs in UI.wixext about the new `BURNMSIINSTALL`, `BURNMSIMODIFY`, `BURNMSIREPAIR`, and `BURNMSIUNINSTALL` properties so that users are required to choose the same action they chose in the BA UI.


## Considerations

* There are plans for adding a new built-in BA that will support EmbeddedUI.
* Making Burn default `uiLevel` to `INSTALLUILEVEL_NONE | INSTALLUILEVEL_SOURCERESONLY` may change in the future since `INSTALLUILEVEL_SOURCERESONLY` might cause dialogs to be shown even if the bundle is supposed to be quiet.


## See Also

[WIXFEAT:6164](https://github.com/wixtoolset/issues/issues/6164)
