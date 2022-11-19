---
title: Environment Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>                 Environment variables added or removed for the parent component.             </dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa368369.aspx" target="_blank">Environment Table</a>
  </dd>
  <dt>Parents</dt>
  <dd>
    <a href="../component/">Component</a>
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
        <td>Id</td>
        <td>String</td>
        <td>Unique identifier for environment entry.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Action</td>
        <td>Enumeration</td>
        <td>Specfies whether the environmental variable should be created, set or removed when the parent component is installed.  This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>create</dfn></dt><dd>Creates the environment variable if it does not exist, then set it during installation. This has no effect on the value of the environment variable if it already exists.</dd><dt class="enumerationValue"><dfn>set</dfn></dt><dd>Creates the environment variable if it does not exist, and then set it during installation. If the environment variable exists, set it during the installation.</dd><dt class="enumerationValue"><dfn>remove</dfn></dt><dd>                                     Removes the environment variable during an installation.                                     The installer only removes an environment variable during an installation if the name and value                                     of the variable match the entries in the Name and Value attributes.                                     If you want to remove an environment variable, regardless of its value, do not set the Value attribute.                                 </dd></dl></td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Name</td>
        <td>String</td>
        <td>Name of the environment variable.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Part</td>
        <td>Enumeration</td>
        <td>This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>all</dfn></dt><dd>                                     This value is the entire environmental variable.  This is the default.                                 </dd><dt class="enumerationValue"><dfn>first</dfn></dt><dd>                                     This value is prefixed.                                 </dd><dt class="enumerationValue"><dfn>last</dfn></dt><dd>                                     This value is appended.                                 </dd></dl></td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Permanent</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Specifies that the environment variable should not be removed on uninstall.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Separator</td>
        <td>String</td>
        <td>Optional attribute to change the separator used between values.  By default a semicolon is used.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>System</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>                     Specifies that the environment variable should be added to the system environment space.  The default                     is 'no' which indicates the environment variable is added to the user environment space.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Value</td>
        <td>String</td>
        <td>                         The value to set into the environment variable.                         If this attribute is not set, the environment variable is removed during installation if it exists on the machine.                     </td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Wix Schema</a>
  </dd>
</dl>
