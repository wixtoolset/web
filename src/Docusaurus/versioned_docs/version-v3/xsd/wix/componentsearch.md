---
title: ComponentSearch Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Searches for file or directory and assigns to value of parent Property.</dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa368001.aspx" target="_blank">CompLocator Table</a>, <a href="http://msdn.microsoft.com/library/aa371853.aspx" target="_blank">Signature Table</a></dd>
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
        <td>&nbsp;</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Guid</td>
        <td><a href="../simple_type_guid/">Guid</a></td>
        <td>The component ID of the component whose key path is to be used for the search.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Type</td>
        <td>Enumeration</td>
        <td>Must be file if last child is FileSearch element and must be directory if last child is DirectorySearch element.  This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>directory</dfn></dt><dd>                                     The key path of the component is a directory.                                 </dd><dt class="enumerationValue"><dfn>file</dfn></dt><dd>                                     The key path of the component is a file.  This is the default value.                                 </dd></dl></td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>, <a href="../inifilesearch/">IniFileSearch</a>, <a href="../registrysearch/">RegistrySearch</a></dd>
</dl>
