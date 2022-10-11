---
title: RestartResource Element (Util Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>Registers a resource with the Restart Manager.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../wix/component">Component</a>, <a href="../wix/fragment">Fragment</a>, <a href="../wix/module">Module</a>, <a href="../wix/product">Product</a></dd>
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
        <td>The unique identifier for this resource. A unique identifier will                     be generated automatically if not specified.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Path</td>
        <td>String</td>
        <td>The full path to the process module to register with the Restart Manager.                     This can be a formatted value that resolves to a full path.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ProcessName</td>
        <td>String</td>
        <td>The name of a process to register with the Restart Manager.                     This can be a formatted value that resolves to a process name.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ServiceName</td>
        <td>String</td>
        <td>The name of a Windows service to register with the Restart Manager.                     This can be a formatted value that resolves to a service name.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../util">Util Schema</a>
  </dd>
</dl>
