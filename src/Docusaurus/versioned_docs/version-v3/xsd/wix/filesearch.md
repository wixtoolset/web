---
title: FileSearch Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Searches for file and assigns to fullpath value of parent Property</dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa368331.aspx" target="_blank">DrLocator Table</a>, <a href="http://msdn.microsoft.com/library/aa371853.aspx" target="_blank">Signature Table</a></dd>
  <dt>Parents</dt>
  <dd>
    <a href="../componentsearch/">ComponentSearch</a>, <a href="../directorysearch/">DirectorySearch</a>, <a href="../directorysearchref/">DirectorySearchRef</a>, <a href="../inifilesearch/">IniFileSearch</a>, <a href="../registrysearch/">RegistrySearch</a></dd>
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
        <td>Unique identifier for the file search and external key into the Signature table. If this attribute value is not set then the parent element's @Id attribute is used.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Languages</td>
        <td>String</td>
        <td>The languages supported by the file.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>LongName</td>
        <td><a href="../simple_type_longfilenametype/">LongFileNameType</a></td>
        <td>This attribute has been deprecated; please use the Name attribute instead.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>MaxDate</td>
        <td>DateTime</td>
        <td>The maximum modification date and time of the file. Formatted as YYYY-MM-DDTHH:mm:ss, where YYYY is the year, MM is month, DD is day, 'T' is literal, HH is hour, mm is minute and ss is second.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>MaxSize</td>
        <td>Int</td>
        <td>The maximum size of the file.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>MaxVersion</td>
        <td>String</td>
        <td>The maximum version of the file.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>MinDate</td>
        <td>DateTime</td>
        <td>The minimum modification date and time of the file. Formatted as YYYY-MM-DDTHH:mm:ss, where YYYY is the year, MM is month, DD is day, 'T' is literal, HH is hour, mm is minute and ss is second.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>MinSize</td>
        <td>Int</td>
        <td>The minimum size of the file.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>MinVersion</td>
        <td>String</td>
        <td>The minimum version of the file.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Name</td>
        <td><a href="../simple_type_longfilenametype/">LongFileNameType</a></td>
        <td>                         In prior versions of the WiX toolset, this attribute specified the short file name.                         This attribute's value may now be either a short or long file name.                         If a short file name is specified, the ShortName attribute may not be specified.                         If a long file name is specified, the LongName attribute may not be specified.                         If you wish to manually specify the short file name, then the ShortName                         attribute may be specified.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ShortName</td>
        <td><a href="../simple_type_shortfilenametype/">ShortFileNameType</a></td>
        <td>                         The short file name of the file in 8.3 format.                         There is a Windows Installer bug which prevents the FileSearch functionality from working                         if both a short and long file name are specified.  Since the Name attribute allows either                         a short or long name to be specified, it is the only attribute related to file names which                         should be specified.                     </td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>Remarks</dt>
  <dd><a>When the parent DirectorySearch/@Depth attribute is greater than 0, the FileSearch/@Id attribute must be absent or the same as the parent DirectorySearch/@Id attribute value, unless the parent DirectorySearch/@AssignToProperty attribute value is 'yes'.</a></dd>
  <dt>How Tos and Examples</dt>
  <dd>
    <ul>
      <li>
        <a href="../../howtos/files_and_registry/check_the_version_number">How To: Check the version number of a file during installation</a>
      </li>
    </ul>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>, <a href="../componentsearch/">ComponentSearch</a>, <a href="../directorysearch/">DirectorySearch</a>, <a href="../directorysearchref/">DirectorySearchRef</a>, <a href="../filesearchref/">FileSearchRef</a>, <a href="../inifilesearch/">IniFileSearch</a>, <a href="../registrysearch/">RegistrySearch</a></dd>
</dl>
