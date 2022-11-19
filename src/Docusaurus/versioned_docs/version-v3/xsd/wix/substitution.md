---
title: Substitution Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Specifies the configurable fields of a module database and provides a template for the configuration of each field.</dd>
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
        <td>Column</td>
        <td>String</td>
        <td>Specifies the target column in the row named in the Row column.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Row</td>
        <td>String</td>
        <td>Specifies the primary keys of the target row in the table named in the Table column. If multiple keys, separated by semicolons.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Table</td>
        <td>String</td>
        <td>Specifies the name of the table being modified in the module database.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Value</td>
        <td>String</td>
        <td>Provides a formatting template for the data being substituted into the target field specified by Table, Row, and Column.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Wix Schema</a>
  </dd>
</dl>
