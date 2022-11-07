---
title: WebLog Element (Iis Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>WebLog definition.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../wix/fragment">Fragment</a>, <a href="../wix/module">Module</a>, <a href="../wix/product">Product</a></dd>
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
        <td>Identifier for the WebLog.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Type</td>
        <td>Enumeration</td>
        <td>This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>IIS</dfn></dt><dd>                                     Microsoft IIS Log File Format                                 </dd><dt class="enumerationValue"><dfn>NCSA</dfn></dt><dd>                                     NCSA Common Log File Format                                 </dd><dt class="enumerationValue"><dfn>none</dfn></dt><dd>                                     Disables logging.                                 </dd><dt class="enumerationValue"><dfn>ODBC</dfn></dt><dd>                                     ODBC Logging                                 </dd><dt class="enumerationValue"><dfn>W3C</dfn></dt><dd>                                     W3C Extended Log File Format                                 </dd></dl></td>
        <td>Yes</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../iis">Iis Schema</a>
  </dd>
</dl>
