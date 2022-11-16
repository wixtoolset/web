---
title: FileSearchRef Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>References an existing FileSearch element.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
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
        <td>Specify the Id to the FileSearch to reference.</td>
        <td>Yes</td>
      </tr>
    </table>
  </dd>
  <dt>Remarks</dt>
  <dd><p>A reference to another FileSearch element must reference the same Id and the same Parent Id. If any of these attribute values are different you must instead use a FileSearch element.</p></dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>, <a href="../filesearch/">FileSearch</a></dd>
</dl>
