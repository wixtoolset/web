---
title: PackageGroupRef Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Create a reference to PackageGroup element that exists inside a Bundle or Fragment element.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../chain/">Chain</a>, <a href="../container/">Container</a>, <a href="../packagegroup/">PackageGroup</a></dd>
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
        <td>The identifier of the PackageGroup element to reference.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>After</td>
        <td>String</td>
        <td>The identifier of a package that this group should be installed after.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Wix Schema</a>, <a href="../packagegroup/">PackageGroup</a></dd>
</dl>
