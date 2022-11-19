---
title: RelatedBundle Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Create a RelatedBundle element.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../bundle/">Bundle</a>, <a href="../fragment/">Fragment</a></dd>
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
        <td><a href="../simple_type_guid/">Guid</a></td>
        <td>The identifier of the RelatedBundle group.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Action</td>
        <td>Enumeration</td>
        <td>The action to take on bundles related to this one. Detect is the default.  This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>Detect</dfn></dt><dd></dd><dt class="enumerationValue"><dfn>Upgrade</dfn></dt><dd></dd><dt class="enumerationValue"><dfn>Addon</dfn></dt><dd></dd><dt class="enumerationValue"><dfn>Patch</dfn></dt><dd></dd></dl></td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Wix Schema</a>
  </dd>
</dl>
