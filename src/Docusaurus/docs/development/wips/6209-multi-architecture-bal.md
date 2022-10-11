---
wip: 6209
type: Feature
by: Sean Hall (r sean hall at gmail.com)
title: Multi-arch BalExtension BAs
draft: false
---

## User stories

* As a Setup developer I can author my bundle using the built-in BootstrapperApplications in BalExtension such that the correct architecture is automatically used.


## Proposal - Bal.wixext

In v3.x, the built-in BootstrapperApplications in BalExtension were used by creating a `BootstrapperApplicationRef` with a documented Id.
They were customized with child `bal:WixStandardBootstrapperApplication` and `bal:WixManagedBootstrapperApplicationHost` elements.
In order to allow the BalExtension compiler to reference the correct `BootstrapperApplication` based on the target architecture, these child elements will be the supported way of using the BA's instead of a special `Id` on `BootstrapperApplicationRef`.

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


## Proposal - Core

This is how the WiX BA should have been added to the bundle in v3:

    <Bundle>
      <BootstrapperApplicationRef Id='ManagedBootstrapperApplicationHost' bal:UseUILanguages='yes'>
        <bal:WixManagedBootstrapperApplicationHost LicenseFile='..\..\..\License.txt' />
        <Payload Name='BootstrapperCore.config' SourceFile='WixBA.BootstrapperCore.config' />
        <Payload SourceFile='WixBA.dll' />
      </BootstrapperApplicationRef>
    </Bundle>

Under the above proposal, this is how it would be in v4:

    <Bundle>
      <bal:WixManagedBootstrapperApplicationHost Theme='standard' LicenseFile='..\..\..\License.txt'>
        <Payload Name='WixToolset.Mba.Core.config' SourceFile='WixBA.BootstrapperCore.config' />
        <Payload SourceFile='WixBA.dll' />
      </bal:WixManagedBootstrapperApplicationHost>
    </Bundle>

The problem with this is that the Bal extension is now required to parse Core elements (`Payload` and `PayloadGroupRef`).
There is no other way for the Setup developer to add payloads to the UX container - currently that requires adding them under `BootstrapperApplication` or `BootstrapperApplicationRef`.
The `BootstrapperApplication` is defined in Bal.wixext so can't be used by the Setup developer.
`BootstrapperApplicationRef` can't be used by the Setup developer either, because the Id changes based on the target architecture (the issue we're solving here).
Requiring extensions to parse Core elements is not acceptable because that parsing logic is in Core and is subject to change.

In order for the Setup Developer to include their own payloads in the UXContainer, the core WiX schema needs to be enhanced.
The basic idea is to remove the payload information from `BootstrapperApplication` and require the new `BootstrapperApplicationDll` element to declare the actual BA.

Remove `Name` and `SourceFile` attributes from `BootstrapperApplication`.
Allow `BootstrapperApplication` and `BootstrapperApplicationRef` to be specified any number of times under `Bundle`.
All child payloads from those elements will go into the UX container.

Add `BootstrapperApplicationDll` element.
A bundle must have exactly one `BootstrapperApplicationDll`.

    <xs:element name="BootstrapperApplicationDll">
      <xs:annotation>
        <xs:documentation>Describes the entry point to the bootstrapper application.</xs:documentation>
        <xs:appinfo>
          <xse:parent namespace="http://wixtoolset.org/schemas/v4/wxs" ref="BootstrapperApplication" />
        </xs:appinfo>
      </xs:annotation>
      <xs:complexType>
        <xs:attribute name="Id" type="xs:string">
          <xs:annotation>
            <xs:documentation>The identifier of BootstrapperApplicationDll element.</xs:documentation>
          </xs:annotation>
        </xs:attribute>
        <xs:attribute name="SourceFile" type="xs:string" use="required">
          <xs:annotation>
            <xs:documentation>Location of the source file.</xs:documentation>
          </xs:annotation>
        </xs:attribute>
        <xs:attribute name="Name" type="xs:string">
          <xs:annotation>
            <xs:documentation>The destination path and file name for this payload. The default is the source file name. The use of '..' directories is not allowed.</xs:documentation>
          </xs:annotation>
        </xs:attribute>
      </xs:complexType>
    </xs:element>


The Bal.wixext currently has this authoring for MBA:

    <Fragment>
      <BootstrapperApplication Id='ManagedBootstrapperApplicationHost$(var.Suffix)' SourceFile='!(bindpath.$(var.platform))\mbahost.dll'>
        <PayloadGroupRef Id='Mba' />
        <PayloadGroupRef Id='MbaPreqStandard' />
      </BootstrapperApplication>
    </Fragment>

This will change to:

    <Fragment>
      <BootstrapperApplication Id='ManagedBootstrapperApplicationHost$(var.Suffix)'>
        <BootstrapperApplicationDll SourceFile='!(bindpath.$(var.platform))\mbahost.dll' />
        <PayloadGroupRef Id='Mba' />
        <PayloadGroupRef Id='MbaPreqStandard' />
      </BootstrapperApplication>
    </Fragment>

The bundle authoring will look like:

    <Bundle>
      <BootstrapperApplication>
        <bal:WixManagedBootstrapperApplicationHost Theme='standard' LicenseFile='..\..\..\License.txt' />
        <Payload Name='WixToolset.Mba.Core.config' SourceFile='WixBA.BootstrapperCore.config' />
        <Payload SourceFile='WixBA.dll' />
        <Payload SourceFile='mbanative.dll' />
      </BootstrapperApplication>
    </Bundle>

## Considerations

In WiX v3.x Setup developers were able to assume that no matter what architecture they picked to build the bundle, the BA would be x86 due to v3 always picking the x86 stub.
Since some of their BA payloads may be architecture specific (bafunctions.dll, the MBA, or any of the MBA's dependencies), automatically converting the old elements could lead to an unusable bundle.

These were the options considered for enhancing the language:

Option 1.
Create `BootstrapperApplicationContainer` element, which can be specified any number of times.
It can have an Id to be referenced from a new `BootstrapperApplicationContainerRef` element.
This would look like:

    <Bundle>
      <bal:WixManagedBootstrapperApplicationHost Theme='standard' LicenseFile='..\..\..\License.txt' />
      <BootstrapperApplicationContainer>
        <Payload Name='WixToolset.Mba.Core.config' SourceFile='WixBA.BootstrapperCore.config' />
        <Payload SourceFile='WixBA.dll' />
      </BootstrapperApplicationContainer>
    </Bundle>

or

    <Bundle>
      <bal:WixManagedBootstrapperApplicationHost Theme='standard' LicenseFile='..\..\..\License.txt' />
      <BootstrapperApplicationContainerRef Id='WixBA'>
        <Payload Name='WixToolset.Mba.Core.config' SourceFile='WixBA.BootstrapperCore.config' />
      </BootstrapperApplicationContainerRef>
    </Bundle>
    <Fragment>
      <BootstrapperApplicationContainer Id='WixBA'>
        <Payload SourceFile='WixBA.dll' />
      </BootstrapperApplicationContainer>
    </Fragment>

Option 2.
Same as option 1, but also remove the ability to specify child `Payload` or `PayloadGroup` elements under `BootstrapperApplication`.
Require the payload information on the `BootstrapperApplication` element.
Remove the `BootstrapperApplicationRef` element entirely.
Require the parent of `BootstrapperApplication` to be `BootstrapperApplicationContainer` or `BootstrapperApplicationContainerRef`.
Change the parent of the Bal BA elements to also be either `BootstrapperApplicationContainer` or `BootstrapperApplicationContainerRef`.
The Bal.wixext currently has this authoring for MBA:

    <Fragment>
      <BootstrapperApplication Id='ManagedBootstrapperApplicationHost$(var.Suffix)' SourceFile='!(bindpath.$(var.platform))\mbahost.dll'>
        <PayloadGroupRef Id='Mba' />
        <PayloadGroupRef Id='MbaPreqStandard' />
      </BootstrapperApplication>
    </Fragment>

This would change to:

    <Fragment>
      <BootstrapperApplicationContainer Id='ManagedBootstrapperApplicationHost$(var.Suffix)'>
        <BootstrapperApplication SourceFile='!(bindpath.$(var.platform))\mbahost.dll' />
        <PayloadGroupRef Id='Mba' />
        <PayloadGroupRef Id='MbaPreqStandard' />
      </BootstrapperApplication>
    </Fragment>

The bundle authoring would look like:

    <Bundle>
      <BootstrapperApplicationContainer>
        <bal:WixManagedBootstrapperApplicationHost Theme='standard' LicenseFile='..\..\..\License.txt' />
        <Payload Name='WixToolset.Mba.Core.config' SourceFile='WixBA.BootstrapperCore.config' />
        <Payload SourceFile='WixBA.dll' />
      </BootstrapperApplicationContainer>
    </Bundle>

Option 3.
Allow `BootstrapperApplicationRef` without an `Id`.
This would look like:

    <Bundle>
      <bal:WixManagedBootstrapperApplicationHost Theme='standard' LicenseFile='..\..\..\License.txt' />
      <BootstrapperApplicationRef>
        <Payload Name='WixToolset.Mba.Core.config' SourceFile='WixBA.BootstrapperCore.config' />
        <Payload SourceFile='WixBA.dll' />
      </BootstrapperApplicationRef>
    </Bundle>

Option 4.
Create `BootstrapperApplicationContainerRef` which has no attributes and can have children `Payload` and `PayloadGroupRef` elements.
This would look like:

    <Bundle>
      <bal:WixManagedBootstrapperApplicationHost Theme='standard' LicenseFile='..\..\..\License.txt' />
      <BootstrapperApplicationContainerRef>
        <Payload Name='WixToolset.Mba.Core.config' SourceFile='WixBA.BootstrapperCore.config' />
        <Payload SourceFile='WixBA.dll' />
      </BootstrapperApplicationContainerRef>
    </Bundle>

Option 5.
Create `BootstrapperApplicationPayload`, `BootstrapperApplicationPayloadGroup`, and `BootstrapperApplicationPayloadGroupRef` elements.
This would look like:

    <Bundle>
      <bal:WixManagedBootstrapperApplicationHost Theme='standard' LicenseFile='..\..\..\License.txt' />
      <BootstrapperApplicationPayloadGroup Id='WixBA'>
        <Payload Name='WixToolset.Mba.Core.config' SourceFile='WixBA.BootstrapperCore.config' />
        <Payload SourceFile='WixBA.dll' />
      </BootstrapperApplicationPayloadGroup>
    </Bundle>

or

    <Bundle>
      <bal:WixManagedBootstrapperApplicationHost Theme='standard' LicenseFile='..\..\..\License.txt' />
      <PayloadGroup Id='WixBA'>
        <BootstrapperApplicationPayload Name='WixToolset.Mba.Core.config' SourceFile='WixBA.BootstrapperCore.config' />
        <BootstrapperApplicationPayload SourceFile='WixBA.dll' />
      </PayloadGroup>
    </Bundle>


Option 6.
Add `BootstrapperApplication=yes` to `Payload` elements.
This would look like:

    <Bundle>
      <bal:WixManagedBootstrapperApplicationHost Theme='standard' LicenseFile='..\..\..\License.txt' />
      <PayloadGroup Id='WixBA'>
        <Payload BootstrapperApplication='yes' Name='WixToolset.Mba.Core.config' SourceFile='WixBA.BootstrapperCore.config' />
        <Payload BootstrapperApplication='yes' SourceFile='WixBA.dll' />
      </PayloadGroup>
    </Bundle>


## See Also

* [WIXFEAT:6209](https://github.com/wixtoolset/issues/issues/6209)
