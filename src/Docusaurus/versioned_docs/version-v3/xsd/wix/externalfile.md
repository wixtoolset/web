---
title: ExternalFile Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Contains information about specific files that are not part of a regular target image.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../family/">Family</a>
  </dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Sequence (min: 1, max: 1)<ol><li><a href="../protectrange/">ProtectRange</a> (min: 1, max: unbounded)</li><li><a href="../symbolpath/">SymbolPath</a> (min: 1, max: unbounded)</li><li>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../ignorerange/">IgnoreRange</a> (min: 0, max: unbounded)</li></ul></li></ol></dd>
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
        <td>File</td>
        <td>String</td>
        <td>Foreign key into the File table.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Order</td>
        <td>Int</td>
        <td>Specifies the order of the external files to use when creating the patch.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Source</td>
        <td>String</td>
        <td>Full path of the external file.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>src</td>
        <td>String</td>
        <td>This attribute has been deprecated; please use the Source attribute instead.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Wix Schema</a>
  </dd>
</dl>
