---
title: Exclusion Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Declares a merge module with which this merge module is incompatible.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../module/">Module</a>
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
        <td>ExcludedId</td>
        <td>String</td>
        <td>Identifier of the merge module that is incompatible.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>ExcludedMaxVersion</td>
        <td>String</td>
        <td>Maximum version excluded from a range. If not set, all versions after min are excluded. If neither max nor min, no exclusion based on version.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ExcludedMinVersion</td>
        <td>String</td>
        <td>Minimum version excluded from a range. If not set, all versions before max are excluded. If neither max nor min, no exclusion based on version.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ExcludeExceptLanguage</td>
        <td>Integer</td>
        <td>Numeric language ID of the merge module in ExcludedID. All except this language will be excluded. Only one of ExcludeExceptLanguage and ExcludeLanguage may be specified.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ExcludeLanguage</td>
        <td>Integer</td>
        <td>Numeric language ID of the merge module in ExcludedID. The specified language will be excluded. Only one of ExcludeExceptLanguage and ExcludeLanguage may be specified.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>
  </dd>
</dl>
