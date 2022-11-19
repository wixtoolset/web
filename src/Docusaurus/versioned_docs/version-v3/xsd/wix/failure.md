---
title: Failure Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Failure action for a ServiceConfigFailureActions element.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../serviceconfigfailureactions/">ServiceConfigFailureActions</a>
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
        <td>Action</td>
        <td>String</td>
        <td>                     Specifies the action to take when the service fails. Valid values are "none", "restartComputer", "restartService", "runCommand" or a Formatted property                     that resolves to "0" (for "none"), "1" (for "restartService"), "2" (for "restartComputer") or "3" (for "runCommand").                 </td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Delay</td>
        <td>String</td>
        <td>                     Specifies the time in milliseconds to wait before performing the value from the Action attribute.                 </td>
        <td>Yes</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Wix Schema</a>
  </dd>
</dl>
