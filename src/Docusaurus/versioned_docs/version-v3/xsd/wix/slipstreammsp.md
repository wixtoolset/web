---
title: SlipstreamMsp Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Specifies a patch included in the same bundle that is installed when the parent MSI package is installed.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../msipackage/">MsiPackage</a>
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
        <td>Id</td>
        <td>String</td>
        <td>The identifier for a MspPackage in the bundle.</td>
        <td>Yes</td>
      </tr>
    </table>
  </dd>
  <dt>Remarks</dt>
  <dd><p>You can also specify that any MspPackage elements in the chain are automatically slipstreamed by setting the Slipstream attribute of an MspPackage to "yes". This will reduce the amount of authoring you need to write and will determine which msi packages can slipstream patches when building a bundle.</p></dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>, <a href="../msppackage/">MspPackage</a></dd>
</dl>
