---
title: Package Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>             Properties about the package to be placed in the Summary Information Stream.  These are             visible from COM through the IStream interface, and these properties can be seen on the package in Explorer.             </dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../module/">Module</a>, <a href="../product/">Product</a></dd>
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
        <td>AdminImage</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Set to 'yes' if the source is an admin image.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Comments</td>
        <td>String</td>
        <td>Optional comments for browsing.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Compressed</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>                         Set to 'yes' to have compressed files in the source.                         This attribute cannot be set for merge modules.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Description</td>
        <td>String</td>
        <td>The product full name or description.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Id</td>
        <td><a href="../simple_type_autogenguid/">AutogenGuid</a></td>
        <td>                         The package code GUID for a product or merge module.                         When compiling a product, this attribute should not be set in order to allow the package                         code to be generated for each build.                         When compiling a merge module, this attribute must be set to the modularization guid.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>InstallerVersion</td>
        <td>Integer</td>
        <td>                         The minimum version of the Windows Installer required to install this package. Take the major version of the required Windows Installer                         and multiply by a 100 then add the minor version of the Windows Installer. For example, "200" would represent Windows Installer 2.0 and                         "405" would represent Windows Installer 4.5. For 64-bit Windows Installer packages, this property is set to 200 by default as                         Windows Installer 2.0 was the first version to support 64-bit packages.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>InstallPrivileges</td>
        <td>Enumeration</td>
        <td>Use this attribute to specify the priviliges required to install the package on Windows Vista and above.  This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>limited</dfn></dt><dd>                                     Set this value to declare that the package does not require elevated privileges to install.                                 </dd><dt class="enumerationValue"><dfn>elevated</dfn></dt><dd>                                     Set this value to declare that the package requires elevated privileges to install.                                     This is the default value.                                 </dd></dl></td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>InstallScope</td>
        <td>Enumeration</td>
        <td>Use this attribute to specify the installation scope of this package: per-machine or per-user.  This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>perMachine</dfn></dt><dd>                                     Set this value to declare that the package is a per-machine installation and requires elevated privileges to install.                                     Sets the ALLUSERS property to 1.                                 </dd><dt class="enumerationValue"><dfn>perUser</dfn></dt><dd>                                     Set this value to declare that the package is a per-user installation and does not require elevated privileges to install.                                     Sets the package's InstallPrivileges attribute to "limited."                                 </dd></dl></td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Keywords</td>
        <td>String</td>
        <td>Optional keywords for browsing.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Languages</td>
        <td>String</td>
        <td>The list of language IDs (LCIDs) supported in the package.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Manufacturer</td>
        <td>String</td>
        <td>The vendor releasing the package.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Platform</td>
        <td>Enumeration</td>
        <td>             The platform supported by the package. Use of this attribute is discouraged; instead,             specify the -arch switch at the candle.exe command line or the InstallerPlatform              property in a .wixproj MSBuild project.             This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>x86</dfn></dt><dd>                     Set this value to declare that the package is an x86 package.                 </dd><dt class="enumerationValue"><dfn>ia64</dfn></dt><dd>                     Set this value to declare that the package is an ia64 package.                     This value requires that the InstallerVersion property be set to 200 or greater.                 </dd><dt class="enumerationValue"><dfn>x64</dfn></dt><dd>                     Set this value to declare that the package is an x64 package.                     This value requires that the InstallerVersion property be set to 200 or greater.                 </dd><dt class="enumerationValue"><dfn>arm</dfn></dt><dd>                   Set this value to declare that the package is an arm package.                   This value requires that the InstallerVersion property be set to 500 or greater.                 </dd><dt class="enumerationValue"><dfn>arm64</dfn></dt><dd>                   Set this value to declare that the package is an arm64 package.                   This value requires that the InstallerVersion property be set to 500 or greater.                 </dd><dt class="enumerationValue"><dfn>intel</dfn></dt><dd>                     This value has been deprecated. Use "x86" instead.                 </dd><dt class="enumerationValue"><dfn>intel64</dfn></dt><dd>                     This value has been deprecated. Use "ia64" instead.                 </dd></dl></td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Platforms</td>
        <td>String</td>
        <td>             The list of platforms supported by the package. This attribute has been deprecated.             Specify the -arch switch at the candle.exe command line or the InstallerPlatform              property in a .wixproj MSBuild project.           </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ReadOnly</td>
        <td><a href="../simple_type_yesnodefaulttype/">YesNoDefaultType</a></td>
        <td>             The value of this attribute conveys whether the package should be opened as read-only.             A database editing tool should not modify a read-only enforced database and should             issue a warning at attempts to modify a read-only recommended database.           </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ShortNames</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Set to 'yes' to have short filenames in the source.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>SummaryCodepage</td>
        <td>String</td>
        <td>The code page integer value or web name for summary info strings only.  See remarks for more information.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>Remarks</dt>
  <dd><p>You can specify any valid Windows code by by integer like 1252, or by web name like Windows-1252. See <a href="../../../overview/codepage">Code Pages</a> for more information.</p></dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Wix Schema</a>
  </dd>
</dl>
