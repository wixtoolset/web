---
title: MsiProperty Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Allows an MSI property to be set based on the value of a burn engine expression.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../msipackage/">MsiPackage</a>, <a href="../msppackage/">MspPackage</a></dd>
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
        <td>Name</td>
        <td>String</td>
        <td>The name of the MSI property to set. Burn controls the follow MSI properties so they cannot be set with MsiProperty: ACTION, ALLUSERS, REBOOT, REINSTALL, REINSTALLMODE</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Value</td>
        <td>String</td>
        <td>The value to set the property to. This string is evaluated by the burn engine and can be as simple as a burn engine variable reference or as complex as a full expression.</td>
        <td>Yes</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>
  </dd>
</dl>
