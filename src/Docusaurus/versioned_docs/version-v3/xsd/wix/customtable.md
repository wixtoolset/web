---
title: CustomTable Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Defines a custom table for use from a custom action.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../fragment/">Fragment</a>, <a href="../module/">Module</a>, <a href="../product/">Product</a></dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Sequence (min: 1, max: 1)<ol><li><a href="../column/">Column</a> (min: 0, max: unbounded): Column definition for the custom table.</li><li><a href="../row/">Row</a> (min: 0, max: unbounded): Row definition for the custom table.</li></ol></dd>
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
        <td>Identifier for the custom table.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>BootstrapperApplicationData</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Indicates the table data is transformed into the bootstrapper application data manifest.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Wix Schema</a>
  </dd>
</dl>
