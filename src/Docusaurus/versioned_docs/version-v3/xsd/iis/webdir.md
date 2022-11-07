---
title: WebDir Element (Iis Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>Defines a subdirectory within an IIS web site. When this element is a child of WebSite, the web directory is defined within that web site. Otherwise the web directory must reference a WebSite element via the WebSite attribute.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../wix/component">Component</a>, <a href="../iis/website" class="extension">WebSite</a></dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../iis/webapplication" class="extension">WebApplication</a> (min: 0, max: 1)</li><li><a href="../iis/webdirproperties" class="extension">WebDirProperties</a> (min: 0, max: 1)</li></ul></dd>
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
        <td>DirProperties</td>
        <td>String</td>
        <td>                         References the Id attribute for a WebDirProperties element that specifies the security and access properties for this web directory.                         This attribute may not be specified if a WebDirProperties element is directly nested in this element.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Path</td>
        <td>String</td>
        <td>Specifies the name of this web directory.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>WebSite</td>
        <td>String</td>
        <td>References the Id attribute for a WebSite element in which this directory belongs. Required when this element is not a child of a WebSite element.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../iis">Iis Schema</a>
  </dd>
</dl>
