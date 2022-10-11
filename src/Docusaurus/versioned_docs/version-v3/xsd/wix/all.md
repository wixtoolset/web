---
title: All Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Used only for PatchFamilies to include all changes between the baseline and upgraded packages in a patch.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../wix/patchfamily">PatchFamily</a>
  </dd>
  <dt>Remarks</dt>
  <dd><p>Warning: this is intended for testing purposes only. Shipping a patch with all changes negates the benefits of using patch families for including only specific changes.</p><p>Because changing the ProductCode is not supported in a patch, the ProductCode property is automatically removed from the transform.</p></dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>
  </dd>
</dl>
