---
title: ComPlusRoleForComponent Element (Complus Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>         Represents a role assignment to a COM+ component.       </dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../../complus/compluscomponent" class="extension">ComPlusComponent</a>, <a href="../../wix/component/">Component</a></dd>
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
        <td>           Id of the ComPlusApplicationRole element representing the           role that shall be granted access to the component.         </td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Component</td>
        <td>String</td>
        <td>           If the element is not a child of a ComPlusComponent           element, this attribute should be provided with the id of a ComPlusComponent           element representing the component the role is to be added to.         </td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Complus Schema</a>
  </dd>
</dl>
