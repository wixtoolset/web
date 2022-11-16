---
title: TargetFile Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Information about specific files in a target image.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../targetimage/">TargetImage</a>
  </dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Sequence (min: 1, max: 1)<ol><li><a href="../symbolpath/">SymbolPath</a> (min: 0, max: 1)</li><li>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../ignorerange/">IgnoreRange</a> (min: 0, max: unbounded)</li><li><a href="../protectrange/">ProtectRange</a> (min: 0, max: unbounded)</li></ul></li></ol></dd>
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
        <td>Foreign key into the File table.</td>
        <td>Yes</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>
  </dd>
</dl>
