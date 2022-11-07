---
title: PermissionEx Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>                 Sets ACLs on File, Registry, or CreateFolder.  When under a Registry element, this cannot be used                 if the Action attribute's value is remove or removeKeyOnInstall.  This element is only available                 when installing with MSI 5.0.  For downlevel support, see the PermissionEx element from the                 WixUtilExtension.             </dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa369774.aspx" target="_blank">MsiLockPermissionsEx Table</a>
  </dd>
  <dt>Parents</dt>
  <dd>
    <a href="../wix/createfolder">CreateFolder</a>, <a href="../wix/file">File</a>, <a href="../wix/registry">Registry</a>, <a href="../wix/registrykey">RegistryKey</a>, <a href="../wix/registryvalue">RegistryValue</a>, <a href="../wix/serviceinstall">ServiceInstall</a></dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Sequence (min: 1, max: 1)<ol><li><a href="../wix/condition">Condition</a> (min: 0, max: 1): Optional condition that controls whether the permissions are applied.</li></ol></dd>
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
        <td>                     Primary key used to identify this particular entry. If this is not specified the parent element's Id attribute                     will be used instead.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Sddl</td>
        <td>String</td>
        <td>                     Security descriptor to apply to parent object.                 </td>
        <td>Yes</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>
  </dd>
</dl>
