---
title: IgnoreTable Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>                 Specifies a table from the merge module that is not merged into an .msi file.                 If the table already exists in an .msi file, it is not modified by the merge.                 The specified table can therefore contain data that is unneeded after the merge.                 To minimize the size of the .msm file, it is recommended that developers remove                 unused tables from modules intended for redistribution rather than creating                 IgnoreTable elements for those tables.             </dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../module/">Module</a>
  </dd>
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
        <td>                         The name of the table in the merge module that is not to be merged into the .msi file.                     </td>
        <td>Yes</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Wix Schema</a>
  </dd>
</dl>
