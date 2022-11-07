---
title: CreateFolder Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Create folder as part of parent Component.</dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa368053.aspx" target="_blank">CreateFolder Table</a>
  </dd>
  <dt>Parents</dt>
  <dd>
    <a href="../wix/component">Component</a>
  </dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../wix/permission">Permission</a> (min: 0, max: unbounded): ACL permission</li><li><a href="../wix/permissionex">PermissionEx</a> (min: 0, max: unbounded): Can also configure the ACLs for this folder.</li><li><a href="../wix/shortcut">Shortcut</a> (min: 0, max: unbounded): Non-advertised shortcut to this folder, Shortcut Target is preset to the folder</li><li><span class="extension">Any Element (namespace='##other' processContents='Lax')                              Extensibility point in the WiX XML Schema.  Schema extensions can register additional                             elements at this point in the schema.                         </span><ul><li><a href="../util/permissionex" class="extension">PermissionEx</a></li></ul></li></ul></dd>
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
        <td>Directory</td>
        <td>String</td>
        <td>Identifier of Directory to create.  Defaults to Directory of parent Component.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>, <a href="../wix/removefolder">RemoveFolder</a></dd>
</dl>
