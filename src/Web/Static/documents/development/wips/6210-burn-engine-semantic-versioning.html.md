---
wip: 6210
type: Feature
by: Sean Hall (r sean hall at gmail.com)
title: Burn engine support for SemVer
draft: false
---

## User stories

* As a Setup developer I can use Burn when dealing with non-QWORDable versions.


## Proposal

In v3, the Burn engine uses version numbers as `QWORD`s to drive some of its most critical functionality.
In the real world, versions can't always be parsed into a `QWORD`.
At its most basic level, Burn needs to use strings for versions.

In order to perform comparisons, Burn needs to a new way to parse versions.
The basic idea is to use NuGet's implementation of SemVer.

1. If given a valid NuGet version, Burn will parse it just like NuGet: Major.Minor.Patch.Revision-ReleaseLabels+Metadata.
Major/Minor/Patch/Revision are non-negative integers, and everything after Revision is parsed according to the SemVer 2.0 [spec](https://semver.org/spec/v2.0.0.html).
1. If given an invalid NuGet version, then Burn will parse as much as it can and put the rest into Metadata.

For comparisons, Burn will use NuGet's rules.
The Major.Minor.Patch.Revision part is compared first, as if it's a .NET Version.
Then, ReleaseLabels are compared as specified in the SemVer 2.0 spec.
Finally, Metadata is compared as an ordinal string comparison.

## Examples

### 1.0

    Major: 1
    Minor: 0
    Patch: -1 (undefined)
    Revision: -1 (undefined)
    ReleaseLabels: [] (empty)
    Metadata: null

### 1.2.3.004-2.a.22+abcdef

    Major: 1
    Minor: 2
    Patch: 3
    Revision: 4
    ReleaseLabels: [2, "a", 22]
    Metadata: "abcdef"

### 100.-2.0

    Major: 100
    Minor: -1 (undefined)
    Patch: -1 (undefined)
    Revision: -1 (undefined)
    ReleaseLabels: [] (empty)
    Metadata: "-2.0"

### 1-2

    Major: 1
    Minor: -1 (undefined)
    Patch: -1 (undefined)
    Revision: -1 (undefined)
    ReleaseLabels: ["2"]
    Metadata: null

OR

    Major: -1 (undefined)
    Minor: -1 (undefined)
    Patch: -1 (undefined)
    Revision: -1 (undefined)
    ReleaseLabels: [] (empty)
    Metadata: "1-2"

### 2.9999999999999999999999999999999999999.0.0

    Major: 2
    Minor: -1 (undefined)
    Patch: -1 (undefined)
    Revision: -1 (undefined)
    ReleaseLabels: [] (empty)
    Metadata: "9999999999999999999999999999999999999.0.0"

### Comparisons

    1.2.3.4 > 1.2.3
    1.2.3.0 > 1.2.3
    1.0-2.0 > 1.0-1.19
    10.-4.0 > 10.-2.0
    0.0.1-a > 0-2


## Considerations

The behavior for invalid NuGet versions is completely arbitrary, but needs to be defined.
The "1-2" example above may depend on what's cleaner to implement, it's technically an invalid NuGet version since Minor is required but the proposed implementation is already creating versions with Minor undefined.

Allowing Bundles to author SemVer is out of scope of this issue.


## See Also

* [WIXFEAT:6210](https://github.com/wixtoolset/issues/issues/6210)
* [WIXFEAT:4666](https://github.com/wixtoolset/issues/issues/4666)
