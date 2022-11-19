---
title: Update Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Defines the update for a Bundle.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../bundle/">Bundle</a>, <a href="../fragment/">Fragment</a></dd>
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
        <td>Location</td>
        <td>String</td>
        <td>             The absolute path or URL to check for an update bundle. Currently the engine provides this value             in the IBootstrapperApplication::OnDetectUpdateBegin() and otherwise ignores the value. In the             future the engine will be able to acquire an update bundle from the location and determine if it             is newer than the current executing bundle.           </td>
        <td>Yes</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Wix Schema</a>
  </dd>
</dl>
