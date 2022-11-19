---
title: CustomActionRef Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>                 This will cause the entire contents of the Fragment containing the referenced CustomAction to be                 included in the installer database.             </dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../fragment/">Fragment</a>, <a href="../module/">Module</a>, <a href="../patchfamily/">PatchFamily</a>, <a href="../product/">Product</a></dd>
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
        <td>The identifier of the CustomAction to reference.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td colspan="4">
          <span class="extension">Any Attribute (namespace='##other' processContents='lax')                      Extensibility point in the WiX XML Schema.  Schema extensions can register additional                     attributes at this point in the schema.                 </span>
        </td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Wix Schema</a>, <a href="../customaction/">CustomAction</a></dd>
</dl>
