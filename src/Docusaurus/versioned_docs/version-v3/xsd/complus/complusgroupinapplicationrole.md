---
title: ComPlusGroupInApplicationRole Element (Complus Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>         This element represents a security group membership in an         application role. When the parent component of this element is installed, the         user will be added to the associated application role. This element must be a         descendent of a Component element; it can not be a child of a         ComPlusApplicationRole locater element. To reference a locater element use the         ApplicationRole attribute.       </dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../../complus/complusapplicationrole" class="extension">ComPlusApplicationRole</a>, <a href="../../wix/component/">Component</a></dd>
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
        <td>           Identifier for the element.         </td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>ApplicationRole</td>
        <td>String</td>
        <td>           If the element is not a child of a ComPlusApplicationRole           element, this attribute should be provided with the id of a           ComPlusApplicationRole element representing the application role the user is           to be added to.         </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Group</td>
        <td>String</td>
        <td>           Foreign key into the Group table.         </td>
        <td>Yes</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Complus Schema</a>
  </dd>
</dl>
