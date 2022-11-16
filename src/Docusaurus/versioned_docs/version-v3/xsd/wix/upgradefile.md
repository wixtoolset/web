---
title: UpgradeFile Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Specifies files to either ignore or to specify optional data about a file.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../upgradeimage/">UpgradeImage</a>
  </dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../symbolpath/">SymbolPath</a> (min: 0, max: unbounded)</li></ul></dd>
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
        <td>AllowIgnoreOnError</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Specifies whether patching this file is vital.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>File</td>
        <td>String</td>
        <td>Foreign key into the File table.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Ignore</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>If yes, the file is ignored during patching, and the next two attributes are ignored.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>WholeFile</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Whether the whole file should be installed, rather than creating a binary patch.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>
  </dd>
</dl>
