---
title: WebSite Element (Iis Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>IIs Web Site</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../wix/component">Component</a>, <a href="../wix/fragment">Fragment</a>, <a href="../wix/module">Module</a>, <a href="../wix/product">Product</a></dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../iis/certificateref" class="extension">CertificateRef</a> (min: 0, max: unbounded)</li><li><a href="../iis/httpheader" class="extension">HttpHeader</a> (min: 0, max: unbounded)</li><li><a href="../iis/mimemap" class="extension">MimeMap</a> (min: 0, max: unbounded)</li><li><a href="../iis/webaddress" class="extension">WebAddress</a> (min: 1, max: unbounded)</li><li><a href="../iis/webapplication" class="extension">WebApplication</a> (min: 0, max: 1)</li><li><a href="../iis/webdir" class="extension">WebDir</a> (min: 0, max: unbounded)</li><li><a href="../iis/webdirproperties" class="extension">WebDirProperties</a> (min: 0, max: 1)</li><li><a href="../iis/weberror" class="extension">WebError</a> (min: 0, max: unbounded)</li><li><a href="../iis/webfilter" class="extension">WebFilter</a> (min: 0, max: unbounded)</li><li><a href="../iis/webvirtualdir" class="extension">WebVirtualDir</a> (min: 0, max: unbounded)</li></ul></dd>
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
        <td>Identifier for the WebSite.  Used within the MSI package only.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>AutoStart</td>
        <td><a href="../iis/simple_type_yesnotype">YesNoType</a></td>
        <td>Specifies whether to automatically start the web site.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ConfigureIfExists</td>
        <td><a href="../iis/simple_type_yesnotype">YesNoType</a></td>
        <td>Specifies whether to configure the web site if it already exists.  Note: This will not affect uninstall behavior.  If the web site exists on uninstall, it will be removed.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ConnectionTimeout</td>
        <td>NonNegativeInteger</td>
        <td>Sets the timeout value for connections in seconds.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Description</td>
        <td>String</td>
        <td>This is the name of the web site that will show up in the IIS management console.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Directory</td>
        <td>String</td>
        <td>Root directory of the web site.  Resolved to a directory in the Directory table at install time by the server custom actions.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>DirProperties</td>
        <td>String</td>
        <td>                         References the Id attribute for a WebDirProperties element that specifies the security and access properties for this website root directory.                         This attribute may not be specified if a WebDirProperties element is directly nested in this element.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Sequence</td>
        <td>Integer</td>
        <td>Sequence that the web site is to be created in.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>SiteId</td>
        <td>String</td>
        <td>                       Optional attribute to directly specify the site id of the WebSite.  Use this to ensure all web                       sites in a web garden get the same site id.  If a number is provided, the site id must be unique                       on all target machines.  If "*" is used, the Description attribute will be hashed to create a unique                       value for the site id. This value must be a positive number or a "*" or a formatted value that resolves                       to "-1" (for the same behavior as "*") or a positive number or blank.  If this attribute is absent then                       the web site will be located using the WebAddress element associated with the web site.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>StartOnInstall</td>
        <td><a href="../iis/simple_type_yesnotype">YesNoType</a></td>
        <td>Specifies whether to start the web site on install.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>WebApplication</td>
        <td>String</td>
        <td>Reference to a WebApplication that is to be installed as part of this web site.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>WebLog</td>
        <td>String</td>
        <td>Reference to WebLog definition.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>Remarks</dt>
  <dd><dl><dd>Nesting WebSite under a Component element will result in a WebSite being installed to the machine as the package is installed.</dd><dd>                             Nesting WebSite under Product, Fragment, or Module                             results in a web site "locator" record being created in                             the IIsWebSite table.  This means that the web site                             itself is neither installed nor uninstalled by the MSI                             package.  It does make the database available for referencing                             from a WebApplication, WebVirtualDir or WebDir record.  This allows an MSI to install                             WebApplications, WebVirtualDirs or WebDirs to already existing web sites on the machine.                             The install will fail if the web site does not exist in these cases.                         </dd></dl></dd>
  <dt>See Also</dt>
  <dd>
    <a href="../iis">Iis Schema</a>
  </dd>
</dl>
