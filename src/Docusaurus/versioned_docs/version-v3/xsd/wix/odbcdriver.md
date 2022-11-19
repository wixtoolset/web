---
title: ODBCDriver Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>                 ODBCDriver for a Component             </dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa370547.aspx" target="_blank">ODBCDriver Table</a>
  </dd>
  <dt>Parents</dt>
  <dd>
    <a href="../component/">Component</a>, <a href="../file/">File</a></dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Sequence (min: 1, max: 1)<ol><li><a href="../property/">Property</a> (min: 0, max: unbounded): Translates into ODBCSourceAttributes</li><li><a href="../odbcdatasource/">ODBCDataSource</a> (min: 0, max: unbounded)</li></ol></dd>
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
        <td>Identifier for the driver.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>File</td>
        <td>String</td>
        <td>Required if not found as child of File element</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Name</td>
        <td>String</td>
        <td>Name for the driver.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>SetupFile</td>
        <td>String</td>
        <td>Required if not found as child of File element or different from File attribute above</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Wix Schema</a>
  </dd>
</dl>
