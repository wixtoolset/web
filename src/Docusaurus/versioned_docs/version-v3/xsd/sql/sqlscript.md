---
title: SqlScript Element (Sql Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>SQL Script</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../wix/component">Component</a>, <a href="../sql/sqldatabase" class="extension">SqlDatabase</a></dd>
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
        <td>&nbsp;</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>BinaryKey</td>
        <td>String</td>
        <td>Reference to Binary stream that contains the SQL script to execute.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>ContinueOnError</td>
        <td><a href="../sql/simple_type_yesnotype">YesNoType</a></td>
        <td>Continue executing scripts even if this one fails.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ExecuteOnInstall</td>
        <td><a href="../sql/simple_type_yesnotype">YesNoType</a></td>
        <td>Specifies to execute the script when the associated component is installed.  This attribute is mutually exclusive with the RollbackOnInstall, RollbackOnReinstall and RollbackOnUninstall attributes.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ExecuteOnReinstall</td>
        <td><a href="../sql/simple_type_yesnotype">YesNoType</a></td>
        <td>Specifies whether to execute the script when the associated component is reinstalled.  Setting ExecuteOnInstall to yes does <b>not</b> imply ExecuteOnReinstall is set to yes.  ExecuteOnReinstall must be set in addition to ExecuteOnInstall for it to be executed during both install and reinstall.  This attribute is mutually exclusive with the RollbackOnInstall, RollbackOnReinstall and RollbackOnUninstall attributes.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ExecuteOnUninstall</td>
        <td><a href="../sql/simple_type_yesnotype">YesNoType</a></td>
        <td>Specifies to execute the script when the associated component is uninstalled.  This attribute is mutually exclusive with the RollbackOnInstall, RollbackOnReinstall and RollbackOnUninstall attributes.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>RollbackOnInstall</td>
        <td><a href="../sql/simple_type_yesnotype">YesNoType</a></td>
        <td>Specifies whether to execute the script on rollback if an attempt is made to install the associated component.  This attribute is mutually exclusive with the ExecuteOnInstall, ExecuteOnReinstall and ExecuteOnUninstall attributes.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>RollbackOnReinstall</td>
        <td><a href="../sql/simple_type_yesnotype">YesNoType</a></td>
        <td>Specifies whether to execute the script on rollback if an attempt is made to reinstall the associated component.  This attribute is mutually exclusive with the ExecuteOnInstall, ExecuteOnReinstall and ExecuteOnUninstall attributes.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>RollbackOnUninstall</td>
        <td><a href="../sql/simple_type_yesnotype">YesNoType</a></td>
        <td>Specifies whether to execute the script on rollback if an attempt is made to uninstall the associated component.  This attribute is mutually exclusive with the ExecuteOnInstall, ExecuteOnReinstall and ExecuteOnUninstall attributes.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Sequence</td>
        <td>Integer</td>
        <td>Specifes the order to run the SQL Scripts.  It is recommended that rollback scripts be scheduled before their complementary execution script.  This order is also relative across the SqlString element.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>SqlDb</td>
        <td>String</td>
        <td>required when not child of SqlDatabase</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>User</td>
        <td>String</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../sql">Sql Schema</a>
  </dd>
</dl>
