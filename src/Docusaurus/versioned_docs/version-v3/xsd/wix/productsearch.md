---
title: ProductSearch Element
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
    <a href="../wix/property">Property</a>
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
        <td><a href="../wix/simple_type_yesnotype">YesNoType</a></td>
        <td>Set to "yes" to detect all languages, excluding the languages listed in the Language attribute.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>IncludeMaximum</td>
        <td><a href="../wix/simple_type_yesnotype">YesNoType</a></td>
        <td>Set to "yes" to make the range of versions detected include the value specified in Maximum.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>IncludeMinimum</td>
        <td><a href="../wix/simple_type_yesnotype">YesNoType</a></td>
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
        <td>Minimum</td>
        <td>String</td>
        <td>Specifies the lower bound on the range of product versions to be detected by FindRelatedProducts.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>UpgradeCode</td>
        <td><a href="../wix/simple_type_guid">Guid</a></td>
        <td>This value specifies the upgrade code for the products that are to be detected by the FindRelatedProducts action.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td colspan="4">
          <span class="extension">Any Attribute (namespace='##other' processContents='lax')                                  Extensibility point in the WiX XML Schema.  Schema extensions can register additional                                 attributes at this point in the schema.                             </span>
        </td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>
  </dd>
</dl>
