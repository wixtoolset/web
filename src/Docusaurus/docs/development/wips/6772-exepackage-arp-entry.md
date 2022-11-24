---
wip: 6772
type: Feature
by: Sean Hall (r sean hall at gmail.com)
title: ExePackage ARP entry
draft: false
---

## User stories

* As a Setup developer I can provide ARP entry information for an ExePackage such that it can be used for detection and uninstall.


## Final design

Add new `ArpEntry` element:

```xml
<xs:element name="ArpEntry">
    <xs:annotation>
        <xs:documentation>
            Information about the Add/Remove Programs entry that is installed by the package.
            ArpEntry may not be specified with DetectCondition or UninstallArguments.
        </xs:documentation>
        <xs:appinfo>
            <xse:parent namespace="http://wixtoolset.org/schemas/v4/wxs" ref="ExePackage" />
        </xs:appinfo>
    </xs:annotation>
    <xs:complexType>
        <xs:attribute name="Id" type="xs:string" use="required">
            <xs:annotation>
                <xs:documentation>
                    The id of the ARP entry.
                </xs:documentation>
            </xs:annotation>
        </xs:attribute>
        <xs:attribute name="Win64" type="YesNoTypeUnion" use="required">
            <xs:annotation>
                <xs:documentation>
                    Whether the ARP entry is 64-bit.
                </xs:documentation>
            </xs:annotation>
        </xs:attribute>
        <xs:attribute name="Version" type="xs:string" use="required">
            <xs:annotation>
                <xs:documentation>
                    The DisplayVersion value of the ARP entry that is installed by this package.
                    Older or missing versions cause this package to be detected as absent.
                    Newer versions cause this package to be detected as obsolete.
                </xs:documentation>
            </xs:annotation>
        </xs:attribute>
    </xs:complexType>
</xs:element>
```

For example:

```xml
<ExePackage Id="MyExe" SourceFile="my.exe">
    <ArpEntry Id="MyExeGuid" Win64="no" Version="1.2.3" />
</ExePackage>
```

When Burn starts detecting the `ExePackage`, it will read the ARP entry's `DisplayVersion` value.
If the value is missing or less than the given version, then it is absent.
If the value is equal, then it is present.
If the value is greater, then it is obsolete.
This means that `DetectCondition` is not allowed with `ArpEntry`.

If the package is requested to be uninstalled, then the `QuietUninstallString` value is read from the ArpEntry and that is used to uninstall the package.
If `QuietUninstallString` is missing then the package will fail during uninstall.
The original source is not used for uninstall, so `UninstallArguments` is also not allowed with `ArpEntry`.

Burn will search for the ARP entry based on whether the parent `ExePackage` is per-machine or per-user.
Like `MsiPackage`, there will be no support for packages that can be per-machine or per-user.

## Original Proposal

Add new `ArpEntry` element:

```xml
<xs:element name="ArpEntry">
    <xs:annotation>
        <xs:documentation>
            Information about the Add/Remove Programs entry that is installed by the package.
        </xs:documentation>
        <xs:appinfo>
            <xse:parent namespace="http://wixtoolset.org/schemas/v4/wxs" ref="ExePackage" />
        </xs:appinfo>
    </xs:annotation>
    <xs:complexType>
        <xs:attribute name="Id" type="xs:string" use="required">
            <xs:annotation>
                <xs:documentation>
                    The id of the ARP entry.
                </xs:documentation>
            </xs:annotation>
        </xs:attribute>
        <xs:attribute name="Win64" type="YesNoTypeUnion" use="required">
            <xs:annotation>
                <xs:documentation>
                    Whether the ARP entry is 64-bit.
                </xs:documentation>
            </xs:annotation>
        </xs:attribute>
        <xs:attribute name="VersionVariable" type="xs:string">
            <xs:annotation>
                <xs:documentation>
                    Name of a Variable that will hold the DisplayVersion value of the ARP entry.
                    The default is "[PackageId]_Version".
                </xs:documentation>
            </xs:annotation>
        </xs:attribute>
    </xs:complexType>
</xs:element>
```

For example:

```xml
<!-- Only uninstall this exact version -->
<ExePackage Id="MyExe" SourceFile="my.exe" DetectCondition="MyExe_Version = v1.2.3" InstallCondition="NOT MyExe_Version OR MyExe_Version &lt; v1.2.3">
    <ArpEntry Id="MyExeGuid" Win64="no" />
</ExePackage>

<!-- Uninstall this version and any higher versions -->
<ExePackage Id="MyExe" SourceFile="my.exe" DetectCondition="MyExe_Version &gt;= v1.2.3">
    <ArpEntry Id="MyExeGuid" Win64="no" />
</ExePackage>
```

When Burn starts detecting the `ExePackage`, it will populate a `Variable` with the ARP entry's `DisplayVersion` value.
This should be used in the detect condition.

If the package is requested to be uninstalled, then Burn will now have two options to uninstall it.
1. If `UninstallArguments` were provided and source is available, then Burn will uninstall using those.
2. If source can't be used (either not available or `UninstallArguments` not provided) and the ARP entry is available, then the `QuietUninstallString` value will be used to uninstall the package. This behavior will also be used for `BundlePackage`s.


## Original Alternate Proposal

Use the same `ArpEntry` element as above, and include additional attributes to specify a min and max version:

```xml
<xs:attribute name="MinVersion" type="xs:string">
    <xs:annotation>
        <xs:documentation>
            When detecting the package, if the DisplayVersion value of the ARP entry is greater than or equal to the MinVersion value then it is present.
            If DisplayVersion is less than MinVersion then it is Absent.
            At least one of MinVersion or MaxVersion is required.
        </xs:documentation>
    </xs:annotation>
</xs:attribute>
<xs:attribute name="MaxVersion" type="xs:string">
    <xs:annotation>
        <xs:documentation>
            When detecting the package, if the DisplayVersion value of the ARP entry is less than or equal to the MaxVersion value then it is present.
            If DisplayVersion is greater than MaxVersion then it is Obsolete.
            At least one of MinVersion or MaxVersion is required.
        </xs:documentation>
    </xs:annotation>
</xs:attribute>
```

The above examples would now be:

```xml
<!-- Only uninstall this exact version -->
<ExePackage Id="MyExe" SourceFile="my.exe">
    <ArpEntry Id="MyExeGuid" Win64="no" MinVersion="v1.2.3" MaxVersion="v1.2.3" />
</ExePackage>

<!-- Uninstall this version and any higher versions -->
<ExePackage Id="MyExe" SourceFile="my.exe">
    <ArpEntry Id="MyExeGuid" Win64="no" MinVersion="v1.2.3" />
</ExePackage>
```

This would mean that `DetectCondition` must not be specified with `ArpEntry` since it is handling detection.

Because the ARP entry is the source of truth in this proposal, it no longer makes sense to try to uninstall the package using the original source with `UninstallArguments`.
This means that `UninstallArguments` must not be specified.
At this point, it might be better to create a new package type since `ArpEntry` is fundamentally changing how `ExePackage` works.


## Considerations

1. `QuietUninstallString` is not required so it might be missing.
2. The target .exe of `QuietUninstallString` might not be located in a secure directory so running it elevated could cause problems.
3. It is not guaranteed that the program is actually uninstalled after successfully running the `QuietUninstallString`.


## See Also

* [WIXFEAT:6772](https://github.com/wixtoolset/issues/issues/6772)
