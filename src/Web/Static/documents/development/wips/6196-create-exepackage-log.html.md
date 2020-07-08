---
wip: 6196
type: Feature
by: Sean Hall (r sean hall at gmail.com)
title: Create ExePackage Log
draft: false
---

## User stories

* As a Setup developer I can redirect the console for `ExePackage`s such that I can troubleshoot when errors occur.


## Proposal

Add a new `BurnExeProtocolType` and make it the default for ExePackage/@Protocol:

    
    <xs:enumeration value="redirectConsoleToLog">
        <xs:annotation>
            <xs:documentation>
                Redirect the standard output and standard error to a log file.
                The path of the log file is controlled by the LogPathVariable and RollbackLogPathVariable attributes.
            </xs:documentation>
        </xs:annotation>
    </xs:enumeration>


## Considerations

Making it the default `Protocol` is debatable.
If the `ExePackage` process does not close its standard output and standard input before exiting, then Burn will hang.
The `ExePackage` may output sensitive information that shouldn't be logged.
However, Burn was designed to enable troubleshooting as much as possible with default settings so this is keeping in line with that design.

This functionality could have been added as a separate attribute.
But since all of the existing `BurnExeProtocolType`s already handled creating a log file, it didn't make sense to have the ability to add this on top.


## See Also

* [WIXFEAT:6196](https://github.com/wixtoolset/issues/issues/6196)
