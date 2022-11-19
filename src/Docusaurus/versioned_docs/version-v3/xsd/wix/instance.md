---
title: Instance Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>                 Defines an instance transform for your product.             </dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../instancetransforms/">InstanceTransforms</a>
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
        <td>                         The identity of the instance transform. This value will define the name by which the instance                         should be referred to on the command line. In addition, the value of the this attribute will                         determine what the value of the property specified in Property attribute on InstanceTransforms                         will change to for each instance.                     </td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>ProductCode</td>
        <td><a href="../simple_type_autogenguid/">AutogenGuid</a></td>
        <td>The ProductCode for this instance.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>ProductName</td>
        <td>String</td>
        <td>The ProductName for this instance.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>UpgradeCode</td>
        <td><a href="../simple_type_guid/">Guid</a></td>
        <td>The UpgradeCode for this instance.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Wix Schema</a>
  </dd>
</dl>
