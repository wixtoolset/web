---
title: WixManagedBootstrapperApplicationHost Element (Bal Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>                 Configures the ManagedBootstrapperApplicationHost for a Bundle.             </dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../bootstrapperapplicationref/">BootstrapperApplicationRef</a>
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
        <td>LicenseFile</td>
        <td>String</td>
        <td>Source file of the RTF license file. Cannot be used simultaneously with LicenseUrl.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>LicenseUrl</td>
        <td>String</td>
        <td>URL target of the license link. Cannot be used simultaneously with LicenseFile.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>LocalizationFile</td>
        <td>String</td>
        <td>Source file of the theme localization .wxl file.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>LogoFile</td>
        <td>String</td>
        <td>Source file of the logo graphic.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>NetFxPackageId</td>
        <td>String</td>
        <td>                         Identifier of the bundle package that contains the .NET Framework. ManagedBootstrapperApplicationHost uses                         this identifier to determine whether .NET needs to be installed before the managed bootstrapper application                         can be launched.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ThemeFile</td>
        <td>String</td>
        <td>Source file of the theme XML.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../bal">Bal Schema</a>
  </dd>
</dl>
