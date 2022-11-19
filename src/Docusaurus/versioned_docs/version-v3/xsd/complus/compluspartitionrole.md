---
title: ComPlusPartitionRole Element (Complus Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>         Defines a COM+ partition role. Partition roles can not be         created; this element can only be used as a locater to reference an existing         role.       </dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../../complus/compluspartition" class="extension">ComPlusPartition</a>, <a href="../../wix/component/">Component</a>, <a href="../../wix/fragment/">Fragment</a>, <a href="../../wix/module/">Module</a>, <a href="../../wix/product/">Product</a></dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Sequence (min: 1, max: 1)<ol><li>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../../complus/complusgroupinpartitionrole" class="extension">ComPlusGroupInPartitionRole</a> (min: 0, max: unbounded)</li><li><a href="../../complus/complususerinpartitionrole" class="extension">ComPlusUserInPartitionRole</a> (min: 0, max: unbounded)</li></ul></li></ol></dd>
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
        <td>           Identifier for the element.         </td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Name</td>
        <td>String</td>
        <td>           Name of the partition role.         </td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Partition</td>
        <td>String</td>
        <td>           The id of a ComPlusPartition element representing the partition           the role belongs to.         </td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Complus Schema</a>
  </dd>
</dl>
