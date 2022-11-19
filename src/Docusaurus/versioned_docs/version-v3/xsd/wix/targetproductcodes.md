---
title: TargetProductCodes Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>                 The product codes for products that can accept the patch.             </dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../patch/">Patch</a>
  </dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Choice of elements (min: 1, max: unbounded)<ul><li><a href="../targetproductcode/">TargetProductCode</a> (min: 1, max: unbounded)</li></ul></dd>
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
        <td>Replace</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Whether to replace the product codes that can accept the patch from the target packages with the child elements.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Wix Schema</a>
  </dd>
</dl>
