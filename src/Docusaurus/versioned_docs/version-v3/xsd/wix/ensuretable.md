---
title: EnsureTable Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>                 Use this element to ensure that a table appears in the installer database, even if its empty.             </dd>
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
        <td>The name of the table.</td>
        <td>Yes</td>
      </tr>
    </table>
  </dd>
  <dt>Remarks</dt>
  <dd>This element is particularly useful for two problems that may occur while merging merge modules:                     <ol><li>                             The first likely problem is that in order to properly merge you need to have certain                             tables present prior to merging.  Using this element is one way to ensure those tables                             are present prior to the merging.                         </li><li>                             The other common problem is that a merge module has incorrect validation information                             about some tables.  By ensuring these tables prior to merging, you can avoid this                             problem because the correct validation information will go into the installer database                             before the merge module has a chance to set it incorrectly.                         </li></ol></dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>
  </dd>
</dl>
