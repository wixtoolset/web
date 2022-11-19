---
title: TargetProductCode Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>                 A product code for a product that can accept the patch.             </dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../patchcreation/">PatchCreation</a>, <a href="../targetproductcodes/">TargetProductCodes</a></dd>
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
        <td>Id</td>
        <td>String</td>
        <td>                         The product code for a product that can accept the patch. This can be '*'. See remarks for more information.                     </td>
        <td>Yes</td>
      </tr>
    </table>
  </dd>
  <dt>Remarks</dt>
  <dd><p>When using the PatchCreation element, if the Id attribute value is '*' or this element is not authored, the product codes of all products referenced by the TargetImages element are used.</p><p>When using the Patch element, the Id attribute value must not be '*'. Use the TargetProductCodes/@Replace attribute instead.</p></dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Wix Schema</a>
  </dd>
</dl>
