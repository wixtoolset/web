---
title: ShortcutProperty Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Property values for a shortcut. This element's functionality is available starting with MSI 5.0.</dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://social.msdn.microsoft.com/Search/?query=MsiShortcutProperty%20table%20windows%20installer" target="_blank">MsiShortcutProperty Table</a>
  </dd>
  <dt>Parents</dt>
  <dd>
    <a href="../shortcut/">Shortcut</a>
  </dd>
  <dt>Inner Text (xs:string)</dt>
  <dd>This element may have inner text.</dd>
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
        <td>Unique identifier for MsiShortcutProperty table. If omitted, a stable identifier will be generated from the parent shortcut identifier and Key value.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Key</td>
        <td>String</td>
        <td>A formatted string identifying the property to be set.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Value</td>
        <td>String</td>
        <td>A formatted string supplying the value of the property.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Wix Schema</a>, <a href="../shortcut/">Shortcut</a></dd>
</dl>
