---
wip: 4505
type: Feature
author: r.sean.hall at gmail dot com
title: Add ability to configure URL ACLs
draft: false
---

## User stories

* As a Setup Developer I can configure URL ACLs such that I don't have to use run netsh.exe in my own custom actions.


## Proposal

Create new WixHttpExtension with UrlAcl elements.  These provide wrappers around `netsh.exe http add/delete urlacl`
and their API equivalents `HTTPSetServiceConfiguration` and `HTTPDeleteServiceConfiguration`.

    <xs:schema xmlns:xs="http://www.w3.org/2001/XMLSchema"
              xmlns:xse="http://schemas.microsoft.com/wix/2005/XmlSchemaExtension"
             xmlns:html="http://www.w3.org/1999/xhtml"
        targetNamespace="http://schemas.microsoft.com/wix/HttpExtension"
                  xmlns="http://schemas.microsoft.com/wix/HttpExtension">
        <xs:annotation>
            <xs:documentation>
                The source code schema for the Windows Installer XML Toolset Http Extension.
            </xs:documentation>
        </xs:annotation>

        <xs:import namespace="http://schemas.microsoft.com/wix/2006/wi" />

        <xs:element name="UrlAcl">
            <xs:annotation>
                <xs:documentation>
                    Makes a reservation record for the HTTP Server API configuration store on Windows XP SP2, 
                    Windows Server 2003, and later.  For more information about the HTTP Server API, see
                    <html:a href="http://msdn.microsoft.com/library/windows/desktop/aa364510.aspx">
                    HTTP Server API</html:a>.
                </xs:documentation>
                <xs:appinfo>
                    <xse:parent namespace="http://schemas.microsoft.com/wix/2006/wi" ref="Component" />
                    <xse:parent namespace="http://schemas.microsoft.com/wix/2006/wi" ref="ServiceInstall" />
                    <xse:parent namespace="http://schemas.microsoft.com/wix/UtilExtension" ref="Group" />
                    <xse:parent namespace="http://schemas.microsoft.com/wix/UtilExtension" ref="User" />
                </xs:appinfo>
            </xs:annotation>

            <xs:complexType>
                <xs:choice minOccurs="0" maxOccurs="unbounded">
                    <xs:annotation>
                        <xs:documentation>
                            The access control entries for the access control list.
                        </xs:documentation>
                    </xs:annotation>
                    <xs:element ref="UrlAce" />
                </xs:choice>

                <xs:attribute name="Url" type="xs:string" use="required">
                    <xs:annotation>
                        <xs:documentation>
                            The <html:a href="http://msdn.microsoft.com/library/windows/desktop/aa364698.aspx">UrlPrefix</html:a>
                            string that defines the portion of the URL namespace to which this reservation pertains.
                        </xs:documentation>
                    </xs:annotation>
                </xs:attribute>
            </xs:complexType>
        </xs:element>

        <xs:element name="UrlAce">
            <xs:annotation>
                <xs:documentation>
                    The security principal and which rights to assign to them for the URL reservation.
                </xs:documentation>
            </xs:annotation>
            <xs:complexType>
                <xs:attribute name="SecurityPrincipal" type="xs:string" use="required">
                    <xs:annotation>
                        <xs:documentation>
                            The security principal for this ACE.  When the UrlAcl is under a ServiceInstall element, this defaults to
                            "NT SERVICE\ServiceInstallName".  When under a util:Group or util:User, this defaults to "Domain\Name".
                            This may be either a SID or an account name in a format that 
                            <html:a href="http://msdn.microsoft.com/library/windows/desktop/aa379159.aspx">LookupAccountName</html:a>
                            supports.  When using a SID, an asterisk must be prepended.  For example, "*S-1-5-18".
                        </xs:documentation>
                    </xs:annotation>
                </xs:attribute>

                <xs:attribute name="Rights">
                  <xs:annotation>
                    <xs:documentation>
                      Rights for this ACE. Default is "both".
                    </xs:documentation>
                  </xs:annotation>
                  <xs:simpleType>
                    <xs:restriction base="xs:NMTOKEN">
                      <xs:enumeration value="register" />
                      <xs:enumeration value="delegate" />
                      <xs:enumeration value="both" />
                    </xs:restriction>
                  </xs:simpleType>
                </xs:attribute>
            </xs:complexType>
        </xs:element>
    </xs:schema>


## Considerations

I'm not sure if this warrants a new extension, maybe it could be added to the Util extension.


## See Also

[WIXFEAT:4505](http://wixtoolset.org/issues/4505/)
