---
title: Upgrade Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>                 Upgrade info for a particular UpgradeCode           </dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa372379.aspx" target="_blank">Upgrade Table</a>
  </dd>
  <dt>Parents</dt>
  <dd>
    <a href="../fragment/">Fragment</a>, <a href="../product/">Product</a></dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../property/">Property</a> (min: 0, max: unbounded): Nesting a Property element under an Upgrade element has been deprecated.                             Please nest Property elements in any of the other supported locations.</li><li><a href="../upgradeversion/">UpgradeVersion</a> (min: 0, max: unbounded)</li></ul></dd>
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
        <td>This value specifies the upgrade code for the products that are to be detected by the FindRelatedProducts action.</td>
        <td>Yes</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Wix Schema</a>
  </dd>
</dl>
