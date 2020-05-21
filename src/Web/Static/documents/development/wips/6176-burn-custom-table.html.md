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
Add BurnCustomTable element.

      <xs:element name="BurnCustomTable">
        <xs:annotation>
          <xs:documentation>Defines a custom table for use in a bundle.</xs:documentation>
        </xs:annotation>
        <xs:complexType>
          <xs:sequence>
            <xs:element ref="BurnColumn" minOccurs="0" maxOccurs="unbounded">
              <xs:annotation>
                <xs:documentation>Column definition for the custom table.</xs:documentation>
              </xs:annotation>
            </xs:element>
            <xs:element ref="BurnRow" minOccurs="0" maxOccurs="unbounded">
              <xs:annotation>
                <xs:documentation>Row definition for the custom table.</xs:documentation>
              </xs:annotation>
            </xs:element>
          </xs:sequence>
          <xs:attribute name="Id" type="xs:string" use="required">
            <xs:annotation>
              <xs:documentation>Identifier for the custom table.</xs:documentation>
            </xs:annotation>
          </xs:attribute>
          <xs:attribute name="Type" type="YesNoType" use="required">
            <xs:annotation>
              <xs:documentation>Indicates the table data is transformed into the bootstrapper application data manifest or the bundle extension data manifest.</xs:documentation>
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
      <xs:element name="BurnColumn">
        <xs:annotation>
          <xs:documentation>Column definition for a BurnCustomTable</xs:documentation>
        </xs:annotation>
        <xs:complexType>
          <xs:attribute name="Id" type="xs:string" use="required">
            <xs:annotation>
              <xs:documentation>Identifier for the column.</xs:documentation>
            </xs:annotation>
          </xs:attribute>
        </xs:complexType>
      </xs:element>
      <xs:element name="BurnRow">
        <xs:annotation>
          <xs:documentation>Row data for a BurnCustomTable</xs:documentation>
        </xs:annotation>
        <xs:complexType>
          <xs:sequence>
            <xs:element ref="Data" maxOccurs="unbounded" />
          </xs:sequence>
        </xs:complexType>
      </xs:element>
      <xs:element name="BurnData">
        <xs:annotation>
          <xs:documentation>Used for a BurnCustomTable. Specifies the data for the parent BurnRow and specified BurnColumn.</xs:documentation>
        </xs:annotation>
        <xs:complexType>
          <xs:simpleContent>
            <xs:extension base="xs:string">
              <xs:annotation>
                <xs:documentation>A data value</xs:documentation>
              </xs:annotation>
              <xs:attribute name="Column" use="required" type="xs:string">
                <xs:annotation>
                  <xs:documentation>Specifies in which column to insert this data.</xs:documentation>
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
