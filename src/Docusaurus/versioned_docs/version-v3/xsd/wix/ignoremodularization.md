---
title: IgnoreModularization Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>                 This element has been deprecated.                 Use the Binary/@SuppressModularization, CustomAction/@SuppressModularization, or Property/@SuppressModularization attributes instead.             </dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../fragment/">Fragment</a>, <a href="../module/">Module</a></dd>
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
        <td>Name</td>
        <td>String</td>
        <td>                         The name of the item to ignore modularization for.                     </td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Type</td>
        <td>Enumeration</td>
        <td>                         The type of the item to ignore modularization for.                       This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>Action</dfn></dt><dd></dd><dt class="enumerationValue"><dfn>Property</dfn></dt><dd></dd><dt class="enumerationValue"><dfn>Directory</dfn></dt><dd></dd></dl></td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Wix Schema</a>
  </dd>
</dl>
