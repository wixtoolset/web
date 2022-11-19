---
title: OptionalUpdateRegistration Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Writes additional information to the Windows registry that can be used to detect the bundle.       This registration is intended primarily for update to an existing product.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../../wix/bundle/">Bundle</a>
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
        <td>Classification</td>
        <td>String</td>
        <td>The release type of the update bundle, such as Update, Security Update, Service Pack, etc.           The default value is Update.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Department</td>
        <td>String</td>
        <td>The name of the department or division publishing the update bundle.           The PublishingGroup registry value is not written if this attribute is not specified.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Manufacturer</td>
        <td>String</td>
        <td>The name of the manufacturer. The default is the Bundle/@Manufacturer attribute,           but may also be a short form, ex: WiX instead of Windows Installer XML.           An error is generated at build time if neither attribute is specified.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Name</td>
        <td>String</td>
        <td>The name of the bundle. The default is the Bundle/@Name attribute,           but may also be a short form, ex: KB12345 instead of Update to Product (KB12345).           An error is generated at build time if neither attribute is specified.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ProductFamily</td>
        <td>String</td>
        <td>The name of the family of products being updated. The default is the Bundle/@ParentName attribute.           The corresponding registry key is not created if neither attribute is specified.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>Remarks</dt>
  <dd><p>The attributes are used to write the following registry values to the key:           <code>SOFTWARE\[Manufacturer]\Updates\[ProductFamily]\[Name]</code></p><ul><li>ThisVersionInstalled: Y</li><li>PackageName: &gt;bundle name&lt;</li><li>PackageVersion: &gt;bundle version&lt;</li><li>Publisher: [Manufacturer]</li><li>PublishingGroup: [Department]</li><li>ReleaseType: [Classification]</li><li>InstalledBy: [LogonUser]</li><li>InstalledDate: [Date]</li><li>InstallerName: &gt;installer name&lt;</li><li>InstallerVersion: &gt;installer version&lt;</li></ul></dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Wix Schema</a>
  </dd>
</dl>
