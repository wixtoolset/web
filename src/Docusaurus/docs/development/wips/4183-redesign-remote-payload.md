---
wip: 4183
type: Feature
by: r.sean.hall at gmail dot com
title: Redesign RemotePayload
draft: false
---

## Design goals

1. Remove the magic of a chain package's primary payload being the first payload if neither `SourceFile` nor `RemotePayload` are specified.
This brings these elements in line with `BootstrapperApplication`, where we already removed this functionality.

1. `RemotePayload` is currently only valid for `ExePackage` and `MsuPackage`, but the functionality has been requested for `MsiPackage` and `Payload`.
There are different fields required for each of these scenarios (and will be different for the currently unimplemented `BundlePackage`).
`RemotePayload` needs to be implemented differently so that the other scenarios are possible without overloading it with tons of attributes.


## Proposal

1. Add `ExePackagePayload`, `MsiPackagePayload`, `MspPackagePayload`, and `MsuPackagePayload` elements.

1. The new payload elements can be specified as a child of their parent element, or a `PayloadGroup`.

1. The `SourceFile` attribute on a package element and the new payload element can't both be specified for the same package, but one of them must be specified.
The `Name`, `Compressed`, and `DownloadUrl` attributes on the package element can only be specified with the `SourceFile` attribute on the package element.

1. If an `MsiPackage` references a `PayloadGroup` with an `MsuPackagePayload` element, that's an error (and similarly for the other elements).

1. Remove the `RemotePayload` element and move all the attributes onto the `ExePackagePayload` and `MsuPackagePayload` elements.
This makes it straightforward to implement the same functionality for other payload elements, just add attributes (or maybe child elements) for the information that the binder harvests.

wix.xsd:

    <xs:element name="ExePackagePayload">
      <xs:annotation>
        <xs:documentation>
          Describes information about the ExePackage payload.
          Cannot be specified if the owning ExePackage specified the SourceFile attribute.
        </xs:documentation>
        <xs:appinfo>
          <xse:parent namespace="http://wixtoolset.org/schemas/v4/wxs" ref="ExePackage" />
          <xse:parent namespace="http://wixtoolset.org/schemas/v4/wxs" ref="PayloadGroup" />
        </xs:appinfo>
      </xs:annotation>
      <xs:complexType>
        <xs:attributeGroup ref="ChainPackagePayloadCommonAttributes" />
        <xs:attributeGroup ref="ExePackageRemoteCommonAttributes" />
      </xs:complexType>
    </xs:element>

    <xs:element name="MsiPackagePayload">
      <xs:annotation>
        <xs:documentation>
          Describes information about the MsiPackage payload.
          Cannot be specified if the owning MsiPackage specified the SourceFile attribute.
        </xs:documentation>
        <xs:appinfo>
          <xse:parent namespace="http://wixtoolset.org/schemas/v4/wxs" ref="MsiPackage" />
          <xse:parent namespace="http://wixtoolset.org/schemas/v4/wxs" ref="PayloadGroup" />
        </xs:appinfo>
      </xs:annotation>
      <xs:complexType>
        <xs:attributeGroup ref="ChainPackagePayloadCommonAttributes" />
        <xs:attribute name="SourceFile" type="xs:string" use="required">
          <xs:annotation>
            <xs:documentation>
              Location of the package to add to the bundle.
            </xs:documentation>
          </xs:annotation>
        </xs:attribute>
      </xs:complexType>
    </xs:element>
    
    
    <xs:element name="MsuPackage">
      <xs:complexType>
        <xs:choice minOccurs="0" maxOccurs="unbounded">
          <xs:element ref="Payload" />
          <xs:element ref="PayloadGroupRef" />
          <xs:element ref="MsuPackagePayload" minOccurs="0" maxOccurs="1" />
          <xs:any namespace="##other" processContents="lax" />
        </xs:choice>
        <xs:attributeGroup ref="ChainPackageCommonAttributes" />
        <xs:attribute name="DetectCondition" type="xs:string" />
        <xs:attribute name="KB" type="xs:string" />
      </xs:complexType>
    </xs:element>

    <xs:attributeGroup name="ChainPackagePayloadCommonAttributes">
      <xs:attribute name="Id" type="xs:string">
        <xs:annotation>
          <xs:documentation>The identifier of the package payload element.</xs:documentation>
        </xs:annotation>
      </xs:attribute>
      <xs:attribute name="Name" type="xs:string">
        <xs:annotation>
          <xs:documentation>
            The destination path and file name for this chain payload. Use this attribute to rename the
            chain entry point or extract it into a subfolder. The default value is the file name from the
            SourceFile attribute. This must be a relative path ('\foo' or 'C:\foo' is not allowed).
          </xs:documentation>
        </xs:annotation>
      </xs:attribute>
      <xs:attribute name="DownloadUrl" type="xs:string">
        <xs:annotation>
          <xs:documentation>
            <html:p>The URL to use to download the package. The following substitutions are supported:</html:p>
            <html:ul>
            <html:li>{0} is replaced by the package Id.</html:li>
            <html:li>{1} is replaced by the payload Id.</html:li>
            <html:li>{2} is replaced by the payload file name.</html:li>
            </html:ul>
          </xs:documentation>
        </xs:annotation>
      </xs:attribute>
      <xs:attribute name="Compressed" type="YesNoDefaultTypeUnion">
        <xs:annotation>
          <xs:documentation>Whether the package payload should be embedded in a container or left as an external payload.</xs:documentation>
        </xs:annotation>
      </xs:attribute>
      <xs:anyAttribute namespace="##other" processContents="lax" />
    </xs:attributeGroup>

    <xs:attributeGroup name="ExePackageRemoteCommonAttributes">
      <xs:attribute name="Description" type="xs:string">
        <xs:annotation>
          <xs:documentation>
            Description of the file from version resources.
            Required if SourceFile is not specified, otherwise must not be specified.
          </xs:documentation>
        </xs:annotation>
      </xs:attribute>
      <xs:attribute name="Hash" type="HexType">
        <xs:annotation>
          <xs:documentation>
            SHA-1 hash of the RemotePayload.
            Required if SourceFile is not specified, otherwise must not be specified.
          </xs:documentation>
        </xs:annotation>
      </xs:attribute>
      <xs:attribute name="ProductName" type="xs:string">
        <xs:annotation>
          <xs:documentation>
            Product name of the file from version resouces.
            Required if SourceFile is not specified, otherwise must not be specified.
          </xs:documentation>
        </xs:annotation>
      </xs:attribute>
      <xs:attribute name="SourceFile" type="xs:string">
        <xs:annotation>
          <xs:documentation>
            Location of the package to add to the bundle.
            If not specified, the DownloadUrl attribute must be specified.
          </xs:documentation>
        </xs:annotation>
      </xs:attribute>
      <xs:attribute name="Size" type="xs:integer">
        <xs:annotation>
          <xs:documentation>
            Size of the remote file in bytes.
            Required if SourceFile is not specified, otherwise must not be specified.
          </xs:documentation>
        </xs:annotation>
      </xs:attribute>
      <xs:attribute name="Version" type="VersionType">
        <xs:annotation>
          <xs:documentation>
            Version of the remote file.
            Required if SourceFile is not specified, otherwise must not be specified.
          </xs:documentation>
        </xs:annotation>
      </xs:attribute>
    </xs:attributeGroup>

## Examples

1. RemotePayload renamed.

Before:

    <ExePackage>
      <RemotePayload DownloadUrl="example.com" Hash="..." ... />
    </ExePackage>

After:

    <ExePackage>
      <ExePackagePayload DownloadUrl="example.com" Hash="..." ... />
    </ExePackage>

2. No more magic package payload.

Before, this was valid but would be an error now:

    <MsiPackage Id="ABC">
      <PayloadGroupRef Id="A" />
    </MsiPackage>
    <PayloadGroup Id="A">
      <Payload SourceFile="abc.msi" DownloadUrl="example.com" />
    </PayloadGroup>

After:

    <MsiPackage Id="ABC">
      <PayloadGroupRef Id="A" />
    </MsiPackage>
    <PayloadGroup Id="A">
      <MsiPackagePayload SourceFile="abc.msi" DownloadUrl="example.com" />
    </PayloadGroup>

3. All payload information must be on the same element.

This is an error:

    <ExePackage DownloadUrl="example.com">
      <ExePackagePayload Hash="..." />
    </ExePackage>

4. The new elements are not required.

This is still valid:

    <ExePackage SourceFile="abc.exe" DownloadUrl="example.com" Permanent="yes" />

5. There is no difference between using the new element or specifying it on the package element.

These are equivalent:

    <MsiPackage SourceFile="abc.exe" DownloadUrl="example.com">
      <Payload SourceFile="supporting.file" />
    </MsiPackage>

    <MsiPackage>
      <MsiPackagePayload SourceFile="abc.exe" DownloadUrl="example.com" />
      <Payload SourceFile="supporting.file" />
    </MsiPackage>

## Considerations

The original proposal removed the payload attributes from the package elements (e.g. `SourceFile`, `Name`, `Compressed`, `DownloadUrl` from `MsiPackage`) to remove confusion from having multiple ways to specify the payload information.
Also, it's not clear at all that these attributes apply only to the magic payload created behind the scenes and not any child payloads.

This was deemed to be too verbose, so a modified proposal kept only `SourceFile`.
This was also deemed to be too verbose, so a compromise was to also keep `DownloadUrl`.
At that point, the breakage wasn't worth it especially since `DownloadUrl` is one of the confusing attributes that doesn't apply to other payloads in the package.


## Alternate Proposal

1. Decline #4183, and require either `SourceFile` or a child `RemotePayload` element for chain packages (which removes the ability to implicitly use the first payload as the package payload).

1. Rename the `RemotePayload` element to `RemoteExePayload` and `RemoteMsuPayload`.
Then future payload elements would create their own remote payload element, which would be a child of the original element.


## See Also

* [4183 - Allow separation of package and payload in chain](https://github.com/wixtoolset/issues/issues/4183)
* [4865 - Heat: Invalid payload for MSU packages](https://github.com/wixtoolset/issues/issues/4865)
* [4928 - RemotePayload support for .msi and .cab files](https://github.com/wixtoolset/issues/issues/4928)
* [5601 - Support RemotePayload for Payload elements](https://github.com/wixtoolset/issues/issues/5601)
* [6209 - Add BootstrapperApplicationDll element](https://github.com/wixtoolset/issues/issues/6209)
