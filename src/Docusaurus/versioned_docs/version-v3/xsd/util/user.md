---
title: User Element (Util Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>User for all kinds of things.  When it is not nested under a component it is included in the MSI so it can be referenced by other elements such as the User attribute in the AppPool element.  When it is nested under a Component element, the User will be created on install and can also be used for reference.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../wix/component">Component</a>, <a href="../wix/fragment">Fragment</a>, <a href="../wix/module">Module</a>, <a href="../wix/product">Product</a></dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Sequence (min: 1, max: 1)<ol><li><a href="../util/groupref" class="extension">GroupRef</a> (min: 0, max: unbounded)</li></ol></dd>
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
        <td>CanNotChangePassword</td>
        <td><a href="../util/simple_type_yesnotype">YesNoType</a></td>
        <td>The user cannot change the account's password. Equivalent to UF_PASSWD_CANT_CHANGE.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>CreateUser</td>
        <td><a href="../util/simple_type_yesnotype">YesNoType</a></td>
        <td>Indicates whether or not to create the user.  User creation can be skipped if all that is desired is to join a user to groups.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Disabled</td>
        <td><a href="../util/simple_type_yesnotype">YesNoType</a></td>
        <td>The account is disabled. Equivalent to UF_ACCOUNTDISABLE.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Domain</td>
        <td>String</td>
        <td>A <a href="http://msdn.microsoft.com/library/aa368609.aspx" target="_blank" xmlns="http://schemas.microsoft.com/wix/UtilExtension">Formatted</a> string that contains the local machine or Active Directory domain for the user.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>FailIfExists</td>
        <td><a href="../util/simple_type_yesnotype">YesNoType</a></td>
        <td>Indicates if the install should fail if the user already exists.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>LogonAsBatchJob</td>
        <td><a href="../util/simple_type_yesnotype">YesNoType</a></td>
        <td>Indicates whether or not the user can logon as a batch job.  User creation can be skipped if all that is desired is to set this access right on the user.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>LogonAsService</td>
        <td><a href="../util/simple_type_yesnotype">YesNoType</a></td>
        <td>Indicates whether or not the user can logon as a serivce.  User creation can be skipped if all that is desired is to set this access right on the user.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Name</td>
        <td>String</td>
        <td>A <a href="http://msdn.microsoft.com/library/aa368609.aspx" target="_blank" xmlns="http://schemas.microsoft.com/wix/UtilExtension">Formatted</a> string that contains the name of the user account.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Password</td>
        <td>String</td>
        <td>Usually a Property that is passed in on the command-line to keep it more secure.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>PasswordExpired</td>
        <td><a href="../util/simple_type_yesnotype">YesNoType</a></td>
        <td>Indicates whether the user must change their password on their first login.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>PasswordNeverExpires</td>
        <td><a href="../util/simple_type_yesnotype">YesNoType</a></td>
        <td>The account's password never expires. Equivalent to UF_DONT_EXPIRE_PASSWD.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>RemoveOnUninstall</td>
        <td><a href="../util/simple_type_yesnotype">YesNoType</a></td>
        <td>Indicates whether the user account should be removed or left behind on uninstall.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>UpdateIfExists</td>
        <td><a href="../util/simple_type_yesnotype">YesNoType</a></td>
        <td>Indicates if the user account properties should be updated if the user already exists.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Vital</td>
        <td><a href="../util/simple_type_yesnotype">YesNoType</a></td>
        <td>Indicates whether failure to create the user or add the user to a group fails the installation. The default value is "yes".</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../util">Util Schema</a>, <a href="../util/group" class="extension">Group</a>, <a href="../util/groupref" class="extension">GroupRef</a></dd>
</dl>
