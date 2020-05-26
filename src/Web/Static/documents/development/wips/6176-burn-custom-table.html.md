---
wip: 6176
type: Feature
by: Sean Hall (r sean hall at gmail.com)
title: Create element for custom BA and BE data
draft: false
---

## User stories

* As a Setup developer I can author custom data in my bundle such that my Bootstrapper Application can be dynamic.

* As a Setup developer I can author custom data in my bundle such that my Bundle Extension can by dynamic.


## Proposal

Remove `Unreal` attribute from `CustomTable`.
Add `BurnCustomData` element.

      <xs:element name="BurnCustomData">
        <xs:annotation>
          <xs:documentation>Defines a custom XML element for use in a bundle data manifest.</xs:documentation>
        </xs:annotation>
        <xs:complexType>
          <xs:sequence>
            <xs:element ref="BurnAttributeDefinition" minOccurs="0" maxOccurs="unbounded">
              <xs:annotation>
                <xs:documentation>Attribute definition for BurnCustomData.</xs:documentation>
              </xs:annotation>
            </xs:element>
            <xs:element ref="BurnElement" minOccurs="0" maxOccurs="unbounded">
              <xs:annotation>
                <xs:documentation>Instance data for BurnCustomData.</xs:documentation>
              </xs:annotation>
            </xs:element>
          </xs:sequence>
          <xs:attribute name="Id" type="xs:string" use="required">
            <xs:annotation>
              <xs:documentation>
                Identifier for the custom table.
                Also used as the name of the XML element.
              </xs:documentation>
            </xs:annotation>
          </xs:attribute>
          <xs:attribute name="Type" type="YesNoType" use="required">
            <xs:annotation>
              <xs:documentation>Indicates the custom data is transformed into the bootstrapper application data manifest or the bundle extension data manifest.</xs:documentation>
            </xs:annotation>
            <xs:simpleType>
              <xs:restriction base="xs:NMTOKEN">
                <xs:enumeration value="BootstrapperApplication" />
                <xs:enumeration value="BundleExtension" />
              </xs:restriction>
            </xs:simpleType>
          </xs:attribute>
        </xs:complexType>
      </xs:element>
      <xs:element name="BurnAttributeDefinition">
        <xs:annotation>
          <xs:documentation>Attribute definition for BurnCustomData.</xs:documentation>
        </xs:annotation>
        <xs:complexType>
          <xs:attribute name="Id" type="xs:string" use="required">
            <xs:annotation>
              <xs:documentation>The name of the attribute.</xs:documentation>
            </xs:annotation>
          </xs:attribute>
        </xs:complexType>
      </xs:element>
      <xs:element name="BurnElement">
        <xs:annotation>
          <xs:documentation>Instance data for BurnCustomData.</xs:documentation>
        </xs:annotation>
        <xs:complexType>
          <xs:sequence>
            <xs:element ref="BurnAttribute" maxOccurs="unbounded" />
          </xs:sequence>
        </xs:complexType>
      </xs:element>
      <xs:element name="BurnAttribute">
        <xs:annotation>
          <xs:documentation>Used for BurnCustomData. Specifies a BurnAttributeDefinition and its value for the parent BurnElement.</xs:documentation>
        </xs:annotation>
        <xs:complexType>
          <xs:simpleContent>
            <xs:extension base="xs:string">
              <xs:annotation>
                <xs:documentation>An attribute's value</xs:documentation>
              </xs:annotation>
              <xs:attribute name="Id" use="required" type="xs:string">
                <xs:annotation>
                  <xs:documentation>Specifies the BurnAttributeDefinition associated with this value.</xs:documentation>
                </xs:annotation>
              </xs:attribute>
            </xs:extension>
          </xs:simpleContent>
        </xs:complexType>
      </xs:element>


## Considerations

This will also help the Windows Installer backend and the Burn backend help the Setup developer to use the correct element.


## See Also

[WIXFEAT:6176](https://github.com/wixtoolset/issues/issues/6176)
