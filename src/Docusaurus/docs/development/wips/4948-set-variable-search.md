---
wip: 4948
type: Feature
by: Sean Hall (r sean hall at gmail.com)
title: Set Variable "Search"
draft: false
---

## User stories

* As a Setup developer I can declaratively author setting variables such that I don't have to write code to set variables.


## Proposal

Add a new "search" element called `SetVariable` that can be scheduled during Detect just like any other search:

    <xs:element name="SetVariable">
        <xs:annotation>
            <xs:documentation>Schedules a "search" that sets a variable to the given value.</xs:documentation>
            <xs:appinfo>
                <xse:parent namespace="http://wixtoolset.org/schemas/v4/wxs" ref="Bundle" />
                <xse:parent namespace="http://wixtoolset.org/schemas/v4/wxs" ref="Fragment" />
            </xs:appinfo>
        </xs:annotation>
        <xs:complexType>
            <xs:attributeGroup ref="SearchCommonAttributes" />
            <xs:attribute name="Value" type="xs:string">
                <xs:annotation>
                    <xs:documentation>New value for the variable.</xs:documentation>
                </xs:annotation>
            </xs:attribute>
            <xs:attribute name="Type">
                <xs:annotation>
                    <xs:documentation>Type of the variable, inferred from the value if not specified.</xs:documentation>
                </xs:annotation>
                <xs:simpleType>
                    <xs:restriction base="xs:string">
                        <xs:enumeration value="string" />
                        <xs:enumeration value="numeric" />
                        <xs:enumeration value="version" />
                    </xs:restriction>
                </xs:simpleType>
            </xs:attribute>
            <xs:anyAttribute namespace="##other" processContents="lax">
                <xs:annotation>
                    <xs:documentation>
                        Extensibility point in the WiX XML Schema.  Schema extensions can register additional
                        attributes at this point in the schema.
                    </xs:documentation>
                </xs:annotation>
            </xs:anyAttribute>
        </xs:complexType>
    </xs:element>


## Considerations

If we want to allow setting variables outside of Detect, then we may want to rename this element.


## See Also

* [WIXFEAT:4948](https://github.com/wixtoolset/issues/issues/4948)
