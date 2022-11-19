---
title: DirectorySearchRef Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>References an existing DirectorySearch element.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../compliancedrive/">ComplianceDrive</a>, <a href="../componentsearch/">ComponentSearch</a>, <a href="../directorysearch/">DirectorySearch</a>, <a href="../directorysearchref/">DirectorySearchRef</a>, <a href="../inifilesearch/">IniFileSearch</a>, <a href="../property/">Property</a>, <a href="../registrysearch/">RegistrySearch</a></dd>
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
        <td>Id of the search being referred to.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Parent</td>
        <td>String</td>
        <td>This attribute is the signature of the parent directory of the file or directory in the Signature_ column. If this field is null, and the Path column does not expand to a full path, then all the fixed drives of the user's system are searched by using the Path.  This field is a key into one of the following tables: the RegLocator, the IniLocator, the CompLocator, or the DrLocator tables.</td>
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
  <dd><p>A reference to another DirectorySearch element must reference the same Id, the same Parent Id, and the same Path. If any of these attribute values are different you must instead use a DirectorySearch element.</p></dd>
  <dt>How Tos and Examples</dt>
  <dd>
    <ul>
      <li>
        <a href="../../../howtos/files_and_registry/directorysearchref">How To: Reference another DirectorySearch element</a>
      </li>
    </ul>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>, <a href="../componentsearch/">ComponentSearch</a>, <a href="../inifilesearch/">IniFileSearch</a>, <a href="../registrysearch/">RegistrySearch</a></dd>
</dl>
