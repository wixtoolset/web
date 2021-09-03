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

`REINSTALLMODE` has many different flags, but in the real world everyone is only interested in customizing the mutually exclusive file versioning flags: `p`, `o`, `e`, `d`, and `a`.
`c` is essentially deprecated at this point since no one provides the checksum information in the File table.
`u`, `m`, `s`, and `v` all have clearly defined use cases such that the Burn engine can continue to set these without input from the BA.


Add new parameter to `OnPlanMsiPackage`:

    enum BOOTSTRAPPER_MSI_FILE_VERSIONING
    {
        BOOTSTRAPPER_MSI_FILE_VERSIONING_MISSING_OR_OLDER,          //o
        BOOTSTRAPPER_MSI_FILE_VERSIONING_MISSING_OR_OLDER_OR_EQUAL, //e
        BOOTSTRAPPER_MSI_FILE_VERSIONING_ALL,                       //a
    };

    struct BA_ONPLANMSIPACKAGE_RESULTS
    {
        (existing parameters)
        BOOTSTRAPPER_MSI_FILE_VERSIONING fileVersioning;
    }

`fileVersioning` will default to the value that Burn currently uses (`e` for repair, `o` for everything else).
Note that this will now require Burn to explicitly set REINSTALLMODE for install where it was previously not specifying it to use the default `omus`.

The recently added MEND feature will be removed since it can be achieved with this new functionality.


## Considerations

`p` and `e` were omitted since most people use `o`, `e`, or `a`. There's no technical reason for not adding them later if people ask for it.

Allowing `REINSTALLMODE` to be specified at build time like v3 was an anti-goal because using the same mode for all operations is almost always the wrong thing to do.
Allowing `REINSTALLMODE` to be customized declaratively at build time per action is something that could possibly be added later.


## See Also

* [MSI REINSTALLMODE property](https://docs.microsoft.com/en-us/windows/win32/msi/reinstallmode)
* [WIXFEAT:5911](https://github.com/wixtoolset/issues/issues/5911)
* [MEND pull request](https://github.com/wixtoolset/burn/pull/51)
