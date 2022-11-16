---
title: ComPlusPartition Element (Complus Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>         Defines a COM+ partition. If this element is a child of a         Component element, the partition will be created in association with this         component. If the element is a child of any of the Fragment, Module or Product         elements it is considered to be a locater, referencing an existing partition.       </dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../component/">Component</a>, <a href="../fragment/">Fragment</a>, <a href="../module/">Module</a>, <a href="../product/">Product</a></dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Sequence (min: 1, max: 1)<ol><li>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../complus/complusapplication" class="extension">ComPlusApplication</a> (min: 0, max: unbounded)</li><li><a href="../complus/compluspartitionrole" class="extension">ComPlusPartitionRole</a> (min: 0, max: unbounded)</li><li><a href="../complus/compluspartitionuser" class="extension">ComPlusPartitionUser</a> (min: 0, max: unbounded)</li></ul></li></ol></dd>
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
        <td>Changeable</td>
        <td><a href="../complus/simple_type_yesnotype">YesNoType</a></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Deleteable</td>
        <td><a href="../complus/simple_type_yesnotype">YesNoType</a></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Description</td>
        <td>String</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Name</td>
        <td>String</td>
        <td>           Name of the partition. This attribute can be omitted if           the element is a locater, and a value is provided for the PartitionId           attribute.         </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>PartitionId</td>
        <td>String</td>
        <td>           Id for the partition. This attribute can be omitted, in           which case an id will be generated on install. If the element is a locater,           this attribute can be omitted if a value is provided for the Name attribute.         </td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../complus">Complus Schema</a>
  </dd>
</dl>
