---
wip: 5911
type: Feature
by: Sean Hall (r sean hall at gmail.com)
title: BA Configurable REINSTALLMODE
draft: false
---

## User stories

* As a Setup developer I can customize REINSTALLMODE per MsiPackage/MspPackage such that the bundle can handle edge cases like telling Windows Installer to downgrade files.


## Proposal

Add new parameter to `OnPlanMsiPackage`:

    enum BOOTSTRAPPER_REINSTALLMODE
    {
        BOOTSTRAPPER_REINSTALLMODE_AMUS,
        BOOTSTRAPPER_REINSTALLMODE_OMUS,
        BOOTSTRAPPER_REINSTALLMODE_VAMUS,
        BOOTSTRAPPER_REINSTALLMODE_VOMUS,
        BOOTSTRAPPER_REINSTALLMODE_CMUSA,
        BOOTSTRAPPER_REINSTALLMODE_CMUSE,
        BOOTSTRAPPER_REINSTALLMODE_CMUSO,
    };

    struct BA_ONPLANMSIPACKAGE_RESULTS
    {
        (existing parameters)
        BOOTSTRAPPER_REINSTALLMODE reinstallMode;
    }

`reinstallMode` will default to the value that Burn currently uses.

The recently added MEND feature will be removed since it can be achieved with this new functionality.


## Considerations

The enum value names require knowing what each letter does. It might be better to have a more descriptive name, although that will probably just mean having to read Burn documentation in addition to MSI documentation.

Providing an enum instead of letting the BA pick an arbitrary string is a compromise between giving the BA full control over `REINSTALLMODE` and giving it no control.

Allowing `REINSTALLMODE` to be specified at build time like v3 was an anti-goal because using the same mode for all operations is almost always the wrong thing to do. Allowing `REINSTALLMODE` to be specified declaratively at build time per action is something that could possibly be added later.


## See Also

* [WIXFEAT:5911](https://github.com/wixtoolset/issues/issues/5911)
* [MEND pull request](https://github.com/wixtoolset/burn/pull/51)
