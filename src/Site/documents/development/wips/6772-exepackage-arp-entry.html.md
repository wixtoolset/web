---
wip: 6772
type: Feature
by: Sean Hall (r sean hall at gmail.com)
title: ExePackage ARP entry
draft: false
---

## User stories

* As a Setup developer I can provide ARP entry information for an ExePackage such that it can be used for detection and uninstall.


## Proposal

Add new `ArpEntry` element:

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

For example:

    <ExePackage Id="MyExe" SourceFile="my.exe" DetectCondition="MyExe_Version = v1.2.3" InstallCondition="NOT MyExe_Version OR MyExe_Version &lt; v1.2.3>
        <ArpEntry Id="MyExeGuid" Win64="no" />
    </ExePackage>

When Burn starts detecting the `ExePackage`, it will populate a `Variable` with the ARP entry's `DisplayVersion` value.
This should be used in the detect condition.

If the package is requested to be uninstalled, then Burn will now have two options to uninstall it.
1. If `UninstallArguments` were provided and source is available, then Burn will uninstall using those.
2. If source can't be used (either not available or `UninstallArguments` not provided) and the ARP entry is available, then the `QuietUninstallString` value will be used to uninstall the package. This behavior will also be used for `BundlePackage`s.


## Considerations

1. `QuietUninstallString` is not required so it might be missing.
2. The target .exe of `QuietUninstallString` might not be located in a secure directory so running it elevated could cause problems.
3. It is not guaranteed that the program is actually uninstalled after successfully running the `QuietUninstallString`.


## See Also

* [WIXFEAT:6772](https://github.com/wixtoolset/issues/issues/6772)
