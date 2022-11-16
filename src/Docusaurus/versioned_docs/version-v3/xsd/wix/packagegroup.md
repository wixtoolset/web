---
title: PackageGroup Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Describes a package group to a bootstrapper.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../fragment/">Fragment</a>
  </dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../exepackage/">ExePackage</a> (min: 0, max: unbounded)</li><li><a href="../msipackage/">MsiPackage</a> (min: 0, max: unbounded)</li><li><a href="../msppackage/">MspPackage</a> (min: 0, max: unbounded)</li><li><a href="../msupackage/">MsuPackage</a> (min: 0, max: unbounded)</li><li><a href="../packagegroupref/">PackageGroupRef</a> (min: 0, max: unbounded)</li><li><a href="../rollbackboundary/">RollbackBoundary</a> (min: 0, max: unbounded)</li></ul></dd>
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
        <td>Identifier for package group.</td>
        <td>Yes</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>
  </dd>
</dl>
