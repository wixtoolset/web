---
title: DirectorySearch Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Searches for directory and assigns to value of parent Property.</dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa368331.aspx" target="_blank">DrLocator Table</a>, <a href="http://msdn.microsoft.com/library/aa371853.aspx" target="_blank">Signature Table</a></dd>
  <dt>Parents</dt>
  <dd>
    <a href="../compliancecheck/">ComplianceCheck</a>, <a href="../compliancedrive/">ComplianceDrive</a>, <a href="../componentsearch/">ComponentSearch</a>, <a href="../directorysearch/">DirectorySearch</a>, <a href="../directorysearchref/">DirectorySearchRef</a>, <a href="../inifilesearch/">IniFileSearch</a>, <a href="../property/">Property</a>, <a href="../registrysearch/">RegistrySearch</a></dd>
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
        <td>Unique identifier for the directory search.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>AssignToProperty</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Set the value of the outer Property to the result of this search. See remarks for more information.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Depth</td>
        <td>Integer</td>
        <td>                         Depth below the path that the installer searches for the file or directory specified by the search. See remarks for more information.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Path</td>
        <td>String</td>
        <td>Path on the user's system. Either absolute, or relative to containing directories.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>Remarks</dt>
  <dd><p>Use the AssignToProperty attribute to search for a file but set the outer property to the directory containing the file. When this attribute is set to 'yes', you may only nest a FileSearch element with a unique Id or define no child element.</p><a>When the parent DirectorySearch/@Depth attribute is greater than 0, the FileSearch/@Id attribute must be absent or the same as the parent DirectorySearch/@Id attribute value, unless the parent DirectorySearch/@AssignToProperty attribute value is 'yes'.</a></dd>
  <dt>How Tos and Examples</dt>
  <dd>
    <ul>
      <li>
        <a href="../../../howtos/files_and_registry/check_the_version_number">How To: Check the version number of a file during installation</a>
      </li>
      <li>
        <a href="../../../howtos/files_and_registry/directorysearchref">How To: Reference another DirectorySearch element</a>
      </li>
      <li>
        <a href="../../../howtos/files_and_registry/parentdirectorysearch">How To: Get the parent directory of a file search</a>
      </li>
    </ul>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>, <a href="../componentsearch/">ComponentSearch</a>, <a href="../inifilesearch/">IniFileSearch</a>, <a href="../registrysearch/">RegistrySearch</a></dd>
</dl>
