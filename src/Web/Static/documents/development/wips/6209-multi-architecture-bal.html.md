---
wip: 6209
type: Feature
by: Sean Hall (r sean hall at gmail.com)
title: Multi-arch BalExtension BAs
draft: false
---

## User stories

* As a Setup developer I can author my bundle using the built-in BootstrapperApplications in BalExtension such that the correct architecture is automatically used.


## Proposal

In v3.x, the built-in BootstrapperApplications in BalExtension were used by creating a `BootstrapperApplicationRef` with a documented Id.
They were customized with child `bal:WixStandardBootstrapperApplication` and `bal:WixManagedBootstrapperApplicationHost` elements.
In order to allow the BalExtension compiler to reference the correct `BootstrapperApplication` based on the target architecture, these child elements will be the supported way of using the BA's and will need to be specified under a `Bundle` or `Fragment` element instead.

The `bal:WixStandardBootstrapperApplication` element will get a new `Theme` attribute to specify which flavor to use:

    <xs:attribute name="Theme" use="required">
        <xs:annotation>
            <xs:documentation>The built-in theme to use.</xs:documentation>
        </xs:annotation>
        <xs:simpleType>
            <xs:restriction base="xs:NMTOKEN">
                <xs:enumeration value="hyperlinkLargeLicense" />
                <xs:enumeration value="hyperlinkLicense" />
                <xs:enumeration value="hyperlinkSidebarLicense" />
                <xs:enumeration value="none" />
                <xs:enumeration value="rtfLargeLicense" />
                <xs:enumeration value="rtfLicense" />
            </xs:restriction>
        </xs:simpleType>
    </xs:attribute>

The `bal:WixManagedBootstrapperApplicationHost` element will also get a new `Theme` attribute to specify which flavor to use:

    <xs:attribute name="Theme" default="standard">
        <xs:annotation>
            <xs:documentation>The built-in theme to use.</xs:documentation>
        </xs:annotation>
        <xs:simpleType>
            <xs:restriction base="xs:NMTOKEN">
                <xs:enumeration value="none" />
                <xs:enumeration value="standard" />
            </xs:restriction>
        </xs:simpleType>
    </xs:attribute>

In order for the Setup Developer to include their own payloads in the UXContainer, the core WiX schema needs to be enhanced.
Here are a few options:

1. Allow `BootstrapperApplicationRef` without an `Id`.
1. Create `BootstrapperApplicationContainerRef` which has no attributes and can have children `PayloadGroupRef` elements.
1. Create `BootstrapperApplicationPayload`, `BootstrapperApplicationPayloadGroup`, and `BootstrapperApplicationPayloadGroupRef` elements.
1. Add `BootstrapperApplication=yes` to `Payload` elements.


## Considerations

In WiX v3.x Setup developers were able to assume that no matter what architecture they picked to build the bundle, the BA would be x86 due to v3 always picking the x86 stub.
Since some of their BA payloads may be architecture specific (bafunctions.dll, the MBA, or any of the MBA's dependencies), automatically converting the old elements could lead to an unusable bundle.


## See Also

* [WIXFEAT:6209](https://github.com/wixtoolset/issues/issues/6209)
