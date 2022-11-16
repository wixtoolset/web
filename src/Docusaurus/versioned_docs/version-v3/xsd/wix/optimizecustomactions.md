---
title: OptimizeCustomActions Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Indicates whether custom actions can be skipped when applying the patch.</dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa370344.aspx" target="_blank">MsiPatchMetadata Table</a>
  </dd>
  <dt>Parents</dt>
  <dd>
    <a href="../patch/">Patch</a>, <a href="../patchmetadata/">PatchMetadata</a></dd>
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
        <td>SkipAssignment</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Skip property (type 51) and directory (type 35) assignment custom actions.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>SkipDeferred</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Skip custom actions that run within the script.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>SkipImmediate</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Skip immediate custom actions that are not property or directory assignment custom actions.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>
  </dd>
</dl>
