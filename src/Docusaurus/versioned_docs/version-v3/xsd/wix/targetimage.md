---
title: TargetImage Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Contains information about the target images of the product.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../upgradeimage/">UpgradeImage</a>
  </dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../symbolpath/">SymbolPath</a> (min: 0, max: unbounded)</li><li><a href="../targetfile/">TargetFile</a> (min: 0, max: unbounded)</li></ul></dd>
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
        <td>Identifier for the target image.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>IgnoreMissingFiles</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Files missing from the target image are ignored by the installer.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Order</td>
        <td>Int</td>
        <td>Relative order of the target image.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>SourceFile</td>
        <td>String</td>
        <td>Full path to the location of the msi file for the target image.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>src</td>
        <td>String</td>
        <td>This attribute has been deprecated; please use the SourceFile attribute instead.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Validation</td>
        <td>String</td>
        <td>Product checking to avoid applying irrelevant transforms.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Wix Schema</a>
  </dd>
</dl>
