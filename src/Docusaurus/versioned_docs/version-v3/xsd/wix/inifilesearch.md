---
title: IniFileSearch Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Searches for file, directory or registry key and assigns to value of parent Property</dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa369283.aspx" target="_blank">IniLocator Table</a>, <a href="http://msdn.microsoft.com/library/aa371853.aspx" target="_blank">Signature Table</a></dd>
  <dt>Parents</dt>
  <dd>
    <a href="../compliancecheck/">ComplianceCheck</a>, <a href="../property/">Property</a></dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Choice of elements (min: 0, max: 1)<ul><li><a href="../directorysearch/">DirectorySearch</a> (min: 0, max: 1)</li><li><a href="../directorysearchref/">DirectorySearchRef</a> (min: 0, max: 1)</li><li><a href="../filesearch/">FileSearch</a> (min: 0, max: 1)</li><li><a href="../filesearchref/">FileSearchRef</a> (min: 0, max: 1)</li></ul></dd>
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
        <td>External key into the Signature table.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Field</td>
        <td>Integer</td>
        <td>The field in the .ini line. If field is Null or 0, the entire line is read.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Key</td>
        <td>String</td>
        <td>The key value within the section.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>LongName</td>
        <td><a href="../simple_type_longfilenametype/">LongFileNameType</a></td>
        <td>This attribute has been deprecated; please use the Name attribute instead.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Name</td>
        <td><a href="../simple_type_longfilenametype/">LongFileNameType</a></td>
        <td>                         In prior versions of the WiX toolset, this attribute specified the short name.                         This attribute's value may now be either a short or long name.                         If a short name is specified, the ShortName attribute may not be specified.                         If a long name is specified, the LongName attribute may not be specified.                         Also, if this value is a long name, the ShortName attribute may be omitted to                         allow WiX to attempt to generate a unique short name.                         However, if you wish to manually specify the short name, then the ShortName                         attribute may be specified.                     </td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Section</td>
        <td>String</td>
        <td>The localizable .ini file section.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>ShortName</td>
        <td><a href="../simple_type_shortfilenametype/">ShortFileNameType</a></td>
        <td>                         The short name of the file in 8.3 format.                         This attribute should only be set if the user wants to manually specify the short name.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Type</td>
        <td>Enumeration</td>
        <td>Must be file if last child is FileSearch element and must be directory if last child is DirectorySearch element.  This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>directory</dfn></dt><dd>A directory location.</dd><dt class="enumerationValue"><dfn>file</dfn></dt><dd>A file location.  This is the default value.</dd><dt class="enumerationValue"><dfn>raw</dfn></dt><dd>A raw .ini value.</dd></dl></td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>, <a href="../componentsearch/">ComponentSearch</a>, <a href="../registrysearch/">RegistrySearch</a></dd>
</dl>
