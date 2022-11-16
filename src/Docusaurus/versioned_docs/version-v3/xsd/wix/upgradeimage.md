---
title: UpgradeImage Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Contains information about the upgraded images of the product.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../family/">Family</a>
  </dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Sequence (min: 1, max: 1)<ol><li><a href="../targetimage/">TargetImage</a> (min: 1, max: unbounded)</li><li>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../symbolpath/">SymbolPath</a> (min: 0, max: unbounded)</li><li><a href="../upgradefile/">UpgradeFile</a> (min: 0, max: unbounded)</li></ul></li></ol></dd>
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
        <td>Identifier to connect target images with upgraded image.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>SourceFile</td>
        <td>String</td>
        <td>Full path to location of msi file for upgraded image.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>SourcePatch</td>
        <td>String</td>
        <td>Modified copy of the upgraded installation database that contains additional authoring specific to patching.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>src</td>
        <td>String</td>
        <td>This attribute has been deprecated; please use the SourceFile attribute instead.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>srcPatch</td>
        <td>String</td>
        <td>This attribute has been deprecated; please use the SourcePatch attribute instead.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>
  </dd>
</dl>
