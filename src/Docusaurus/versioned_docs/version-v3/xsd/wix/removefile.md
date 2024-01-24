---
title: RemoveFile Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>                 Remove a file(s) if the parent component is selected for installation or removal.  Multiple files can be removed                 by specifying a wildcard for the value of the Name attribute.  By default, the source                 directory of the file is the directory of the parent component.  This can be overridden by specifying the                 Directory attribute with a value corresponding to the Id of the source directory, or by specifying the Property                 attribute with a value corresponding to a property that will have a value that resolves to the full path                 to the source directory.             </dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa371201.aspx" target="_blank">RemoveFile Table</a>
  </dd>
  <dt>Parents</dt>
  <dd>
    <a href="../component/">Component</a>
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
        <td>Id</td>
        <td>String</td>
        <td>Primary key used to identify this particular entry.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Directory</td>
        <td>String</td>
        <td>                     Overrides the directory of the parent component with a specific Directory.  This Directory must exist in the                     installer database at creation time.  This attribute cannot be specified in conjunction with the Property attribute.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>LongName</td>
        <td><a href="../simple_type_wildcardlongfilenametype/">WildCardLongFileNameType</a></td>
        <td>This attribute has been deprecated; please use the Name attribute instead.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Name</td>
        <td><a href="../simple_type_wildcardlongfilenametype/">WildCardLongFileNameType</a></td>
        <td>                     This value should be set to the localizable name of the file(s) to be removed.  All of the files that                     match the wild card will be removed from the specified directory. Non-existent files are ignored. The value is a filename that may also                     contain the wild card characters "?" for any single character or "*" for zero or more occurrences of any character.                     In prior versions of the WiX toolset, this attribute specified the short file name.                     This attribute's value may now be either a short or long file name.                     If a short file name is specified, the ShortName attribute may not be specified.                     If a long file name is specified, the LongName attribute may not be specified.                     Also, if this value is a long file name, the ShortName attribute may be omitted to                     allow WiX to attempt to generate a unique short file name.                     However, if you wish to manually specify the short file name, then the ShortName attribute may be specified.                 </td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>On</td>
        <td><a href="../simple_type_installuninstalltype/">InstallUninstallType</a></td>
        <td>                         This value determines the time at which the file(s) may be removed. For 'install', the file will                         be removed only when the parent component is being installed (msiInstallStateLocal or                         msiInstallStateSource); for 'uninstall', the file will be removed only when the parent component                         is being removed (msiInstallStateAbsent); for 'both', the file will be removed in both cases.                     </td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Property</td>
        <td>String</td>
        <td>                     Overrides the directory of the parent component with the value of the specified property.  The property                     should have a value that resolves to the full path of the source directory.  The property does not have                     to exist in the installer database at creation time; it could be created at installation time by a custom                     action, on the command line, etc.  This attribute cannot be specified in conjunction with the Directory attribute.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ShortName</td>
        <td><a href="../simple_type_wildcardshortfilenametype/">WildCardShortFileNameType</a></td>
        <td>                         The short file name of the file in 8.3 format.                         This attribute should only be set if you want to manually specify the short file name.                     </td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Wix Schema</a>, <a href="../copyfile/">CopyFile</a></dd>
</dl>
