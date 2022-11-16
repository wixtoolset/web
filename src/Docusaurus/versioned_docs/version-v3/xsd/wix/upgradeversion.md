---
title: UpgradeVersion Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>None</dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa372379.aspx" target="_blank">Upgrade Table</a>
  </dd>
  <dt>Parents</dt>
  <dd>
    <a href="../upgrade/">Upgrade</a>
  </dd>
  <dt>Inner Text (xs:string)</dt>
  <dd>This element may have inner text.</dd>
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
        <td>ExcludeLanguages</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Set to "yes" to detect all languages, excluding the languages listed in the Language attribute.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>IgnoreRemoveFailure</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Set to "yes" to continue installation upon failure to remove a product or application.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>IncludeMaximum</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Set to "yes" to make the range of versions detected include the value specified in Maximum.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>IncludeMinimum</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Set to "no" to make the range of versions detected exclude the value specified in Minimum.  This attribute is "yes" by default.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Language</td>
        <td>String</td>
        <td>Specifies the set of languages detected by FindRelatedProducts.  Enter a list of numeric language identifiers (LANGID) separated by commas (,).  Leave this value null to specify all languages.  Set ExcludeLanguages to "yes" in order detect all languages, excluding the languages listed in this value.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Maximum</td>
        <td>String</td>
        <td>Specifies the upper boundary of the range of product versions detected by FindRelatedProducts.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>MigrateFeatures</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Set to "yes" to migrate feature states from upgraded products by enabling the logic in the MigrateFeatureStates action.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Minimum</td>
        <td>String</td>
        <td>Specifies the lower bound on the range of product versions to be detected by FindRelatedProducts.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>OnlyDetect</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Set to "yes" to detect products and applications but do not uninstall.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Property</td>
        <td>String</td>
        <td>When the FindRelatedProducts action detects a related product installed on the system, it appends the product code to the property specified in this field.  Windows Installer documentation for the <a href="http://msdn.microsoft.com/library/aa372379.aspx" target="_blank">Upgrade table</a> states that the property specified in this field must be a public property and must be added to the <a href="http://msdn.microsoft.com/library/aa371571.aspx" target="_blank">SecureCustomProperties</a> property.  WiX automatically appends the property specified in this field to the SecureCustomProperties property when creating an MSI.  Each UpgradeVersion must have a unique Property value.  After the FindRelatedProducts action is run, the value of this property is a list of product codes, separated by semicolons (;), detected on the system.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>RemoveFeatures</td>
        <td>String</td>
        <td>The installer sets the REMOVE property to features specified in this column.  The features to be removed can be determined at run time.  The Formatted string entered in this field must evaluate to a comma-delimited list of feature names.  For example: [Feature1],[Feature2],[Feature3].  No features are removed if the field contains formatted text that evaluates to an empty string.  The installer sets REMOVE=ALL only if the Remove field is empty.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td colspan="4">
          <span class="extension">Any Attribute (namespace='##other' processContents='lax')                              Extensibility point in the WiX XML Schema.  Schema extensions can register additional                             attributes at this point in the schema.                         </span>
        </td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>
  </dd>
</dl>
