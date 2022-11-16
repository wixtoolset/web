---
title: WebDirProperties Element (Iis Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>                 WebDirProperties used by one or more WebSites. Lists properties common to IIS web sites and vroots. Corresponding properties can be viewed through the IIS Manager snap-in. One property entry can be reused by multiple sites or vroots using the Id field as a reference, using WebVirtualDir.DirProperties, WebSite.DirProperties, or WebDir.DirProperties.             </dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../fragment/">Fragment</a>, <a href="../module/">Module</a>, <a href="../product/">Product</a>, <a href="../iis/webdir" class="extension">WebDir</a>, <a href="../iis/website" class="extension">WebSite</a>, <a href="../iis/webvirtualdir" class="extension">WebVirtualDir</a></dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>None</dd>
  <dt>Attributes</dt>
  <dd>
    <table cellspacing="0" cellpadding="0" class="schema">
      <tr>
        <th width="15%">Name</th>
        <th width="15%">Type</th>
        <th width="65%">Description</th>
        <th width="15%">Required</th>
      </tr>
      <tr>
        <td>Id</td>
        <td>String</td>
        <td>&nbsp;</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>AccessSSL</td>
        <td><a href="../iis/simple_type_yesnotype">YesNoType</a></td>
        <td>A value of true indicates that file access requires SSL file permission processing, with or without a client certificate. This corresponds to AccessSSL flag for AccessSSLFlags IIS metabase property.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>AccessSSL128</td>
        <td><a href="../iis/simple_type_yesnotype">YesNoType</a></td>
        <td>A value of true indicates that file access requires SSL file permission processing with a minimum key size of 128 bits, with or without a client certificate. This corresponds to AccessSSL128 flag for AccessSSLFlags IIS metabase property.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>AccessSSLMapCert</td>
        <td><a href="../iis/simple_type_yesnotype">YesNoType</a></td>
        <td>This corresponds to AccessSSLMapCert flag for AccessSSLFlags IIS metabase property.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>AccessSSLNegotiateCert</td>
        <td><a href="../iis/simple_type_yesnotype">YesNoType</a></td>
        <td>This corresponds to AccessSSLNegotiateCert flag for AccessSSLFlags IIS metabase property.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>AccessSSLRequireCert</td>
        <td><a href="../iis/simple_type_yesnotype">YesNoType</a></td>
        <td>This corresponds to AccessSSLRequireCert flag for AccessSSLFlags IIS metabase property.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>AnonymousAccess</td>
        <td><a href="../iis/simple_type_yesnotype">YesNoType</a></td>
        <td>Sets the Enable Anonymous Access checkbox, which maps anonymous users to a Windows user account. When setting this to 'yes' you should also provide the user account using the AnonymousUser attribute, and determine what setting to use for the IIsControlledPassword attribute. Defaults to 'no.'</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>AnonymousUser</td>
        <td>String</td>
        <td>Reference to the Id attribute on the User element to be used as the anonymous user for the directory. See the User element for more information.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>AspDetailedError</td>
        <td><a href="../iis/simple_type_yesnotype">YesNoType</a></td>
        <td>Sets the option for whether to send detailed ASP errors back to the client on script error. Default is 'no.'</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>AuthenticationProviders</td>
        <td>String</td>
        <td>Comma delimited list, in order of precedence, of Windows authentication providers that IIS will attempt to use: NTLM, Kerberos, Negotiate, and others.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>BasicAuthentication</td>
        <td><a href="../iis/simple_type_yesnotype">YesNoType</a></td>
        <td>Sets the Basic Authentication option, which allows clients to provide credentials in plaintext over the wire. Defaults to 'no.'</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>CacheControlCustom</td>
        <td>String</td>
        <td>Custom HTTP 1.1 cache control directives.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>CacheControlMaxAge</td>
        <td>NonNegativeInteger</td>
        <td>Integer value specifying the cache control maximum age value.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ClearCustomError</td>
        <td><a href="../iis/simple_type_yesnotype">YesNoType</a></td>
        <td>Specifies whether IIs will return custom errors for this directory.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>DefaultDocuments</td>
        <td>String</td>
        <td>The list of default documents to set for this web directory, in comma-delimited format.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>DigestAuthentication</td>
        <td><a href="../iis/simple_type_yesnotype">YesNoType</a></td>
        <td>Sets the Digest Authentication option, which allows using digest authentication with domain user accounts. Defaults to 'no.'</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Execute</td>
        <td><a href="../iis/simple_type_yesnotype">YesNoType</a></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>HttpExpires</td>
        <td>String</td>
        <td>Value to set the HttpExpires attribute to for a Web Dir in the metabase.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>IIsControlledPassword</td>
        <td><a href="../iis/simple_type_yesnotype">YesNoType</a></td>
        <td>Sets whether IIS should control the password used for the Windows account specified in the AnonymousUser attribute. Defaults to 'no.'</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Index</td>
        <td><a href="../iis/simple_type_yesnotype">YesNoType</a></td>
        <td>Sets the Index Resource option, which specifies whether this web directory should be indexed. Defaults to 'no.'</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>LogVisits</td>
        <td><a href="../iis/simple_type_yesnotype">YesNoType</a></td>
        <td>Sets whether visits to this site should be logged. Defaults to 'no.'</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>PassportAuthentication</td>
        <td><a href="../iis/simple_type_yesnotype">YesNoType</a></td>
        <td>Sets the Passport Authentication option, which allows clients to provide credentials via a .Net Passport account. Defaults to 'no.'</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Read</td>
        <td><a href="../iis/simple_type_yesnotype">YesNoType</a></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Script</td>
        <td><a href="../iis/simple_type_yesnotype">YesNoType</a></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>WindowsAuthentication</td>
        <td><a href="../iis/simple_type_yesnotype">YesNoType</a></td>
        <td>Sets the Windows Authentication option, which enables integrated Windows authentication to be used on the site. Defaults to 'no.'</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Write</td>
        <td><a href="../iis/simple_type_yesnotype">YesNoType</a></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../iis">Iis Schema</a>
  </dd>
</dl>
