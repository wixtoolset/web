---
title: PatchFamily Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Collection of items that should be kept from the differences between two products.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../fragment/">Fragment</a>, <a href="../patch/">Patch</a>, <a href="../patchfamilygroup/">PatchFamilyGroup</a></dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Sequence (min: 1, max: 1)<ol><li>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../all/">All</a> (min: 0, max: unbounded)</li><li><a href="../binaryref/">BinaryRef</a> (min: 0, max: unbounded)</li><li><a href="../componentref/">ComponentRef</a> (min: 0, max: unbounded)</li><li><a href="../customactionref/">CustomActionRef</a> (min: 0, max: unbounded)</li><li><a href="../digitalcertificateref/">DigitalCertificateRef</a> (min: 0, max: unbounded)</li><li><a href="../directoryref/">DirectoryRef</a> (min: 0, max: unbounded)</li><li><a href="../featureref/">FeatureRef</a> (min: 0, max: unbounded)</li><li><a href="../iconref/">IconRef</a> (min: 0, max: unbounded)</li><li><a href="../propertyref/">PropertyRef</a> (min: 0, max: unbounded)</li><li><a href="../uiref/">UIRef</a> (min: 0, max: unbounded)</li><li><span class="extension">Any Element (namespace='##other' processContents='Lax')                              Extensibility point in the WiX XML Schema.  Schema extensions can register additional                             elements at this point in the schema.                         </span><ul><li><a href="../tag/tagref" class="extension">TagRef</a></li></ul></li></ul></li></ol></dd>
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
        <td>Identifier which indicates a sequence family to which this patch belongs.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>ProductCode</td>
        <td><a href="../simple_type_guid/">Guid</a></td>
        <td>                         Specifies the ProductCode of the product that this family applies to.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Supersede</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>                         Set this value to 'yes' to indicate that this patch will supersede all previous patches in this patch family.                         The default value is 'no'.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Version</td>
        <td>String</td>
        <td>Used to populate the sequence column of the MsiPatchSequence table in the final MSP file. Specified in x.x.x.x format. See documentation for Sequence column of MsiPatchSequence table in MSI SDK.</td>
        <td>Yes</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>
  </dd>
</dl>
