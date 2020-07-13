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
The basic idea is to use NuGet's implementation of SemVer with some variations to keep v3 Burn functionality.

1. If given a valid NuGet version, Burn will parse it just like NuGet: Major.Minor.Patch.Revision-ReleaseLabels+Metadata.
Unlike NuGet, Major/Minor/Patch/Revision are DWORDs and undefined fields are treated as zero. Everything after Revision is parsed according to the SemVer 2.0 [spec](https://semver.org/spec/v2.0.0.html).
1. If given an invalid NuGet version, then Burn will parse as much as it can and put the rest into Metadata.

For comparisons, Burn will mostly use NuGet's rules.

1. The Major.Minor.Patch.Revision part is compared first, just like v3 Burn.
1. Next, ReleaseLabels are compared as specified in the SemVer 2.0 spec except string comparisons are done case-insensitive.
1. Finally, Metadata is compared as a case-insensitive string comparison.

## Burn API Changes

The only changes to the Burn API are that all places that were using a `QWORD` for a version will now use a `LPWSTR`.
The existing `EvaluateCondition` engine method/message can be used to compare versions.
The details of the parsed version will not be available to the BA, they will be internal to Burn.
This is because Burn is not the source of truth of how the version is supposed to be evaluated.
The code will be available in `butil` (and WixToolset.Mba.Core) if the BA would like to parse the version like Burn.
This allows Burn the flexibility to change the details of parsing the version without being a breaking change.

The `>>`, `<<`, and `><` operators need to be redefined or removed when comparing versions, since they are no longer simple `QWORD`s.

## Examples

### 1.0

    Major: 1
    Minor: 0
    Patch: 0
    Revision: 0
    ReleaseLabels: [] (empty)
    Metadata: "" (empty)

### 1.2.3.004-2.a.22+abcdef

    Major: 1
    Minor: 2
    Patch: 3
    Revision: 4
    ReleaseLabels: [2, "a", 22]
    Metadata: "abcdef"

### 100.-2.0

    Major: 100
    Minor: 0
    Patch: 0
    Revision: 0
    ReleaseLabels: [] (empty)
    Metadata: "-2.0"

### 1-2

    Major: 1
    Minor: 0
    Patch: 0
    Revision: 0
    ReleaseLabels: [2]
    Metadata: "" (empty)

### 2.9999999999999999999999999999999999999.0.0

    Major: 2
    Minor: 0
    Patch: 0
    Revision: 0
    ReleaseLabels: [] (empty)
    Metadata: "9999999999999999999999999999999999999.0.0"

### Comparisons

    1.2.3.4 > 1.2.3
    1.2.3.0 = 1.2.3
    1.0-2.0 > 1.0-1.19
    1.0-2.0 < 1.0-19
    10.-4.0 > 10.-2.0
    0       = "" (empty string)
    0.0.1-a > 0-2
    0.0.1-a < 1-2
    0.01-a.1 = 0.1.0-a.1
    0.1-a.b.0 = 0.1.0-a.b.000
    1.2.3+abcd = 1.2.3.abcd
    1.2.3+abcd < 1.2.3.-abcd
    10.20.30.40 = v10.20.30.40
    4294967295.4294967295.4294967295.4294967295 > 4294967296.4294967296.4294967296.4294967296


## Considerations

The behavior for invalid NuGet versions is completely arbitrary, but needs to be defined.

Allowing Bundles to author SemVer is out of scope of this issue.


## See Also

* [WIXFEAT:6210](https://github.com/wixtoolset/issues/issues/6210)
* [WIXFEAT:4666](https://github.com/wixtoolset/issues/issues/4666)
