---
title: ODBCDataSource Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>                 ODBCDataSource for a Component             </dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa370546.aspx" target="_blank">ODBCDataSource Table</a>
  </dd>
  <dt>Parents</dt>
  <dd>
    <a href="../component/">Component</a>, <a href="../odbcdriver/">ODBCDriver</a></dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Sequence (min: 1, max: 1)<ol><li><a href="../property/">Property</a> (min: 0, max: unbounded): Translates into ODBCSourceAttributes</li></ol></dd>
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
        <td>Identifier of the data source.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>DriverName</td>
        <td>String</td>
        <td>Required if not found as child of ODBCDriver element</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>KeyPath</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Set 'yes' to force this file to be key path for parent Component</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Name</td>
        <td>String</td>
        <td>Name for the data source.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Registration</td>
        <td>Enumeration</td>
        <td>Scope for which the data source should be registered.  This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>machine</dfn></dt><dd>                                     Data source is registered per machine.                                 </dd><dt class="enumerationValue"><dfn>user</dfn></dt><dd>                                     Data source is registered per user.                                 </dd></dl></td>
        <td>Yes</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Wix Schema</a>
  </dd>
</dl>
