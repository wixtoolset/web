---
title: PatchProperty Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>A property for this patch database.</dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa370344.aspx" target="_blank">MsiPatchMetadata Table</a>
  </dd>
  <dt>Parents</dt>
  <dd>
    <a href="../patch/">Patch</a>, <a href="../patchcreation/">PatchCreation</a></dd>
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
        <td>Company</td>
        <td>String</td>
        <td>Name of the company for a custom metadata property.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Name</td>
        <td>String</td>
        <td>Name of the patch property.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Value</td>
        <td>String</td>
        <td>Value of the patch property.</td>
        <td>Yes</td>
      </tr>
    </table>
  </dd>
  <dt>Remarks</dt>
  <dd><p>When authored under the Patch element, the PatchProperty defines entries in the MsiPatchMetadata table.</p></dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>
  </dd>
</dl>
