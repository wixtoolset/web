---
title: PayloadGroup Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Describes a payload group to a bootstrapper. PayloadGroups referenced from within a Bundle are tied to the Bundle.                                PayloadGroups referenced from a Fragment are tied to the context of whatever references them such as an ExePackage or MsiPackage.                               It is possible to share a PayloadGroup between multiple Packages and/or a Bundle by creating multiple references to it.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../wix/bundle">Bundle</a>, <a href="../wix/fragment">Fragment</a></dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../wix/payload">Payload</a> (min: 0, max: unbounded)</li><li><a href="../wix/payloadgroupref">PayloadGroupRef</a> (min: 0, max: unbounded)</li></ul></dd>
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
        <td>Identifier for payload group.</td>
        <td>Yes</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>
  </dd>
</dl>
