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

## Verutil Version Specification

1. Simple versions take the form `Major.Minor.Patch.Revision`, where `Major`, `Minor`, `Patch`, and `Revision` are unsigned 32-bit numbers. `Minor`, `Patch`, and `Revision` are optional.
Valid examples are `1`, `1.0`, `1.2.3.4`, `0.02.3`, `0.0`, `4294967295.4294967295.4294967295.4294967295`.
Invalid examples are `1.`, `1.-1`, `1.2.3.4.5`, `4294967296.4294967296.4294967296.4294967296`.

1. A pre-release version is a simple version followed by a hyphen followed by a series of dot separated identifiers. These identifiers may only contain ASCII alphanumeric characters or a hyphen (`[0-9a-zA-Z-]+`).
Valid examples are `1.0-a`, `1.0-1.a`, `1.0-a-2`.
Invalid examples are `1.0-`, `1.0-a.`, `1.0-@`.

1. Build metadata is optional, and can be added to simple versions and pre-release versions.
Build metadata starts with a plus sign.
While any characters are allowed, characters other than `[0-9a-zA-Z-_.+]` are discouraged since Burn can't parse them in a condition expression.
For example, `1.0+any_string+here` or `1.0-beta+string`.

1. When not in strict mode, invalid versions are parsed as much as possible and then the rest is treated as build metadata. The version is also marked as invalid.

1. Versions must be less than 2,147,483,647 characters.

1. Versions may begin with `v` or `V`.

The precedence rules mostly follow NuGet.

1. The Major.Minor.Patch.Revision part is compared first, just like v3 Burn.
Undefined fields are treated as zero.
Examples: `1.2.3.4 > 1.2.3`, `1.2.3.0 = 1.2.3`, `0.0 = 0`.

1. Next, ReleaseLabels are compared as specified in the SemVer 2.0 spec except string comparisons are done case-insensitive.

1. Next, the invalid flag is compared.
Examples: `0.0 > @#$%^&*`, `0.0 > 0.0..1`, `2.0.-1 > 1.0`, `1-1 > 1-2_3`.

1. Finally, if the versions are invalid then Metadata is compared as a case-insensitive string comparison.

## Burn API Changes

The main change to the Burn API is that all places that were using a `QWORD` for a version will now use a `LPWSTR`.
The existing `EvaluateCondition` engine method/message can be used to compare versions.
The details of the parsed version will not be available to the BA, they will be internal to Burn.
This is because Burn is not the source of truth of how the version is supposed to be evaluated.
The code will be available in `verutil` (and WixToolset.Mba.Core) if the BA would like to parse the version like Burn.

The condition expression parser for versions will be updated to accept the characters `0-9`, `a-z`, `A-Z`, `.`, `-`, `_`, and `+`.

The `>>`, `<<`, and `><` operators will be removed when comparing versions, since they are no longer simple `QWORD`s.

When a version variable is coerced into a numeric value, then the version string is parsed as a number (just like when coercing a string variable into a number). This will fail for most versions.

When a numeric variable is coerced into a version value, then the value is split into a version using the v3 logic. The highest word is Major, the next word is Minor, the next word is Patch, and the lowest word is Revision.

Add a new `CompareVersions` method for a more convenient way to compare versions:

    STDMETHOD(CompareVersions)(
        __in_z LPCWSTR wzVersionLeft,
        __in_z LPCWSTR wzVersionRight,
        __out int* pnResult
        ) = 0;

## Examples

### 1.0

    Major: 1
    Minor: 0
    Patch: 0
    Revision: 0
    ReleaseLabels: [] (empty)
    Metadata: "" (empty)
    Invalid: false

### 1.2.3.004-2.a.22+abcdef

    Major: 1
    Minor: 2
    Patch: 3
    Revision: 4
    ReleaseLabels: [2, "a", 22]
    Metadata: "abcdef"
    Invalid: false

### 100.-2.0

    Major: 100
    Minor: 0
    Patch: 0
    Revision: 0
    ReleaseLabels: [] (empty)
    Metadata: "-2.0"
    Invalid: true

### 1-2

    Major: 1
    Minor: 0
    Patch: 0
    Revision: 0
    ReleaseLabels: [2]
    Metadata: "" (empty)
    Invalid: false

### 2.9999999999999999999999999999999999999.0.0

    Major: 2
    Minor: 0
    Patch: 0
    Revision: 0
    ReleaseLabels: [] (empty)
    Metadata: "9999999999999999999999999999999999999.0.0"
    Invalid: true

### Comparisons

    1.2.3.4 > 1.2.3
    1.2.3.0 = 1.2.3
    1.0-2.0 > 1.0-1.19
    1.0-2.0 < 1.0-19
    10.-4.0 > 10.-2.0
    0       > "" (empty string)
    0.0.1-a > 0-2
    0.0.1-a < 1-2
    0.01-a.1 = 0.1.0-a.1
    0.1-a.b.0 = 0.1.0-a.b.000
    1.2.3+abc = 1.2.3+xyz
    1.2.3+abcd > 1.2.3.-abcd
    10.20.30.40 = v10.20.30.40
    4294967295.4294967295.4294967295.4294967295 > 4294967296.4294967296.4294967296.4294967296


## Considerations

The behavior for invalid versions is completely arbitrary, but needs to be defined.

Allowing Bundles to author SemVer is out of scope of this issue.


## See Also

* [WIXFEAT:6210](https://github.com/wixtoolset/issues/issues/6210)
* [WIXFEAT:4666](https://github.com/wixtoolset/issues/issues/4666)
