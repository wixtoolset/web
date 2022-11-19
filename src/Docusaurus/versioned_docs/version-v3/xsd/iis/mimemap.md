---
title: MimeMap Element (Iis Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>MimeMap definition for IIS resources.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../../iis/website" class="extension">WebSite</a>, <a href="../../iis/webvirtualdir" class="extension">WebVirtualDir</a></dd>
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
        <td>Id for the MimeMap.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Extension</td>
        <td>String</td>
        <td>Extension covered by the MimeMap.  Must begin with a dot.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Type</td>
        <td>String</td>
        <td>Mime-type covered by the MimeMap.</td>
        <td>Yes</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Iis Schema</a>
  </dd>
</dl>
