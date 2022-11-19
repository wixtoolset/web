---
title: SqlDatabase Element (Sql Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>SQL Database</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../../wix/component/">Component</a>, <a href="../../wix/fragment/">Fragment</a>, <a href="../../wix/module/">Module</a>, <a href="../../wix/product/">Product</a></dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../../sql/sqlscript" class="extension">SqlScript</a> (min: 0, max: unbounded)</li><li><a href="../../sql/sqlstring" class="extension">SqlString</a> (min: 0, max: unbounded)</li><li>Sequence (min: 1, max: 1)<ol><li><a href="../../sql/sqlfilespec" class="extension">SqlFileSpec</a> (min: 0, max: 1)</li><li><a href="../../sql/sqllogfilespec" class="extension">SqlLogFileSpec</a> (min: 0, max: 1)</li></ol></li></ul></dd>
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
        <td>&nbsp;</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>ConfirmOverwrite</td>
        <td><a href="../../sql/simple_type_yesnotype">YesNoType</a></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ContinueOnError</td>
        <td><a href="../../sql/simple_type_yesnotype">YesNoType</a></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>CreateOnInstall</td>
        <td><a href="../../sql/simple_type_yesnotype">YesNoType</a></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>CreateOnReinstall</td>
        <td><a href="../../sql/simple_type_yesnotype">YesNoType</a></td>
        <td>                         Specifies whether to create the database when the associated component is reinstalled.  Setting CreateOnInstall to yes does <b>not</b> imply CreateOnReinstall is set to yes.  CreateOnReinstall must be set in addition to CreateOnInstall for it to be created during both install and reinstall.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>CreateOnUninstall</td>
        <td><a href="../../sql/simple_type_yesnotype">YesNoType</a></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Database</td>
        <td>String</td>
        <td>                         The name of the database. The value can be a literal value or derived from a                         Property element using the <a href="http://msdn.microsoft.com/library/aa368609.aspx" target="_blank">Formatted</a>                         syntax.                     </td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>DropOnInstall</td>
        <td><a href="../../sql/simple_type_yesnotype">YesNoType</a></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>DropOnReinstall</td>
        <td><a href="../../sql/simple_type_yesnotype">YesNoType</a></td>
        <td>                         Specifies whether to drop the database when the associated component is reinstalled.  Setting DropOnInstall to yes does <b>not</b> imply DropOnReinstall is set to yes.  DropOnReinstall must be set in addition to DropOnInstall for it to be dropped during both install and reinstall.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>DropOnUninstall</td>
        <td><a href="../../sql/simple_type_yesnotype">YesNoType</a></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Instance</td>
        <td>String</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Server</td>
        <td>String</td>
        <td>&nbsp;</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>User</td>
        <td>String</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>Remarks</dt>
  <dd><dl><dd>Nesting SqlDatabase under a Component element will result in a SqlDatabase being installed to the machine as the package is installed.</dd><dd>                             Nesting SqlDatabase under Product, Fragment, or Module                             results in a database "locator" record being created in                             the SqlDatabase table.  This means that the database                             itself is neither installed nor uninstalled by the MSI                             package.  It does make the database available for referencing                             from a SqlString or SqlScript record.  This allows MSI to install                             SqlScripts or SqlStrings to already existing databases on the machine.                             The install will fail if the database does not exist in these cases.                         </dd><dd>                             The User attribute references credentials specified in a User element.                             If a user is not specified then Windows Authentication will be used by default                             using the credentials of the user performing the install to execute sql                             strings, etc.                         </dd></dl></dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Sql Schema</a>, <a href="../../util/user" class="extension">User</a></dd>
</dl>
