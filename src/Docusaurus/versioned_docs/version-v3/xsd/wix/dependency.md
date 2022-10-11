---
title: Dependency Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Declares a dependency on another merge module.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../wix/module">Module</a>
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
        <td>RequiredId</td>
        <td>String</td>
        <td>Identifier of the merge module required by the merge module.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>RequiredLanguage</td>
        <td>Integer</td>
        <td>Numeric language ID of the merge module in RequiredID.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>RequiredVersion</td>
        <td>String</td>
        <td>Version of the merge module in RequiredID.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>
  </dd>
</dl>
