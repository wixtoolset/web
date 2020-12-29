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
Remove all payload attributes from `ExePackage`, `MsiPackage`, `MspPackage`, and `MsuPackage`, and move them to the new elements.

1. The new payload elements can be specified as a child of their parent element, or a `PayloadGroup`.
To reduce the verbosity of the common case where the source file is available and will be available at runtime (either compressed or not),
put the `SourceFile` attribute back on the package elements.

1. The `SourceFile` attribute on a package element and the new payload element can't both be specified for the same package, but one of them must be specified.

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
        <xs:attribute name="SourceFile" type="xs:string">
          <xs:annotation>
            <xs:documentation>
              Location of the package to add to the bundle.
              To specify more advanced payload information such as Compressed or DownloadUrl, use the child MsuPackagePayload element instead.
            </xs:documentation>
          </xs:annotation>
        </xs:attribute>
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
      <xs:attribute name="EnableSignatureVerification" type="YesNoTypeUnion">
        <xs:annotation>
          <xs:documentation>(to be removed)</xs:documentation>
        </xs:annotation>
      </xs:attribute>
      <xs:anyAttribute namespace="##other" processContents="lax" />
    </xs:attributeGroup>

    <xs:attributeGroup name="ExePackageRemoteCommonAttributes">
      <xs:attribute name="CertificatePublicKey" type="HexType">
        <xs:annotation>
          <xs:documentation>(to be removed)</xs:documentation>
        </xs:annotation>
      </xs:attribute>
      <xs:attribute name="CertificateThumbprint" type="HexType">
        <xs:annotation>
          <xs:documentation>(to be removed)</xs:documentation>
        </xs:annotation>
      </xs:attribute>
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

    <xs:attributeGroup name="ChainPackageCommonAttributes">
      <!-- removed <xs:attribute name="Name" type="xs:string" /> -->
      <!-- removed <xs:attribute name="DownloadUrl" type="xs:string" /> -->
      <!-- removed <xs:attribute name="Compressed" type="YesNoDefaultTypeUnion" /> -->
      <!-- removed <xs:attribute name="EnableSignatureVerification" type="YesNoTypeUnion" /> -->
      <!-- removed <xs:attribute name="SourceFile" type="YesNoTypeUnion" /> -->
      <xs:attribute name="Id" type="xs:string" />
      <xs:attribute name="After" type="xs:string" />
      <xs:attribute name="InstallSize" type="xs:string" />
      <xs:attribute name="InstallCondition" type="xs:string" />
      <xs:attribute name="Cache" type="YesNoAlwaysTypeUnion" />
      <xs:attribute name="CacheId" type="xs:string" />
      <xs:attribute name="DisplayName" type="xs:string" />
      <xs:attribute name="Description" type="xs:string" >
      <xs:attribute name="LogPathVariable" type="xs:string" />
      <xs:attribute name="RollbackLogPathVariable" type="xs:string" />
      <xs:attribute name="Permanent" type="YesNoTypeUnion" />
      <xs:attribute name="Vital" type="YesNoTypeUnion" />
      <xs:anyAttribute namespace="##other" processContents="lax" />
    </xs:attributeGroup>


## Considerations

The original motivation for #4183 was for the NetFx extension to provide the payload information for NetFx packages so the user could create their own `ExePackage`s.
In order for this to work, the chain package elements allow the package payload element to be pulled in by a `PayloadGroupRef`.
This breaks the current logic of generating the package `Id` from the `Name` attribute from the package payload.


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
