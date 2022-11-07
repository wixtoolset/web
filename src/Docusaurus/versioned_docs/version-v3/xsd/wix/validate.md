---
title: Validate Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Sets information in the patch transform that determines if the transform applies to an installed product and what errors should be ignored when applying the patch transform.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../wix/patchbaseline">PatchBaseline</a>
  </dd>
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
        <td>IgnoreAddExistingRow</td>
        <td><a href="../wix/simple_type_yesnotype">YesNoType</a></td>
        <td>Ignore errors when adding existing rows. The default is 'yes'.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>IgnoreAddExistingTable</td>
        <td><a href="../wix/simple_type_yesnotype">YesNoType</a></td>
        <td>Ignore errors when adding existing tables. The default is 'yes'.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>IgnoreChangingCodePage</td>
        <td><a href="../wix/simple_type_yesnotype">YesNoType</a></td>
        <td>Ignore errors when changing the database code page. The default is 'no'.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>IgnoreDeleteMissingRow</td>
        <td><a href="../wix/simple_type_yesnotype">YesNoType</a></td>
        <td>Ignore errors when deleting missing rows. The default is 'yes'.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>IgnoreDeleteMissingTable</td>
        <td><a href="../wix/simple_type_yesnotype">YesNoType</a></td>
        <td>Ignore errors when deleting missing tables. The default is 'yes'.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>IgnoreUpdateMissingRow</td>
        <td><a href="../wix/simple_type_yesnotype">YesNoType</a></td>
        <td>Ignore errors when updating missing rows. The default is 'yes'.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ProductId</td>
        <td><a href="../wix/simple_type_yesnotype">YesNoType</a></td>
        <td>Requires that the installed ProductCode match the target ProductCode used to create the transform. The default is 'yes'.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ProductLanguage</td>
        <td><a href="../wix/simple_type_yesnotype">YesNoType</a></td>
        <td>Requires that the installed ProductLanguage match the target ProductLanguage used to create the transform. The default is 'no'.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ProductVersion</td>
        <td>Enumeration</td>
        <td>Determines how many fields of the installed ProductVersion to compare. See remarks for more information. The default is 'Update'.  This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>Major</dfn></dt><dd>Checks the major version.</dd><dt class="enumerationValue"><dfn>Minor</dfn></dt><dd>Checks the major and minor versions.</dd><dt class="enumerationValue"><dfn>Update</dfn></dt><dd>Checks the major, minor, and update versions.</dd></dl></td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ProductVersionOperator</td>
        <td>Enumeration</td>
        <td>Determines how the installed ProductVersion is compared to the target ProductVersion used to create the transform. See remarks for more information. The default is 'Equal'.  This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>Lesser</dfn></dt><dd>Installed ProductVersion &lt; target ProductVersion.</dd><dt class="enumerationValue"><dfn>LesserOrEqual</dfn></dt><dd>Installed ProductVersion &lt;= target ProductVersion.</dd><dt class="enumerationValue"><dfn>Equal</dfn></dt><dd>Installed ProductVersion = target ProductVersion.</dd><dt class="enumerationValue"><dfn>GreaterOrEqual</dfn></dt><dd>Installed ProductVersion &gt;= target ProductVersion.</dd><dt class="enumerationValue"><dfn>Greater</dfn></dt><dd>Installed ProductVersion &gt; target ProductVersion.</dd></dl></td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>UpgradeCode</td>
        <td><a href="../wix/simple_type_yesnotype">YesNoType</a></td>
        <td>Requires that the installed UpgradeCode match the target UpgradeCode used to create the transform. The default is 'yes'.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>Remarks</dt>
  <dd><p>A transform contains the differences between the target product and the upgraded product. When a transform or a patch (which contains transforms) is applied, the following properties of the installed product are validated against the properties of the target product stored in a transform.</p><ul><li>ProductCode</li><li>ProductLanguage</li><li>ProductVersion</li><li>UpgradeCode</li></ul><p>Windows Installer simply validates that the ProductCode, ProductLanguage, and UpgradeCode of an installed product are equivalent to those propeties of the target product used to create the transform; however, the ProductVersion can be validated with a greater range of comparisons.</p><p>You can compare up to the first three fields of the ProductVersion. Changes to the fourth field are not validated and are useful for small updates. You can also choose how to compare the target ProductVersion used to create the transform with the installed ProductVersion. For example, while the default value of 'Equals' is recommended, if you wanted a minor upgrade patch to apply to the target ProductVersion and all older products with the same ProductCode, you would use 'LesserOrEqual'.</p></dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>
  </dd>
</dl>
