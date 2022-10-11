---
title: RegistrySearch Element (Util Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>Describes a registry search.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../wix/bundle">Bundle</a>, <a href="../wix/fragment">Fragment</a></dd>
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
        <td>After</td>
        <td>String</td>
        <td>Id of the search that this one should come after.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Condition</td>
        <td>String</td>
        <td>Condition for evaluating the search. If this evaluates to false, the search is not executed at all.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ExpandEnvironmentVariables</td>
        <td><a href="../util/simple_type_yesnotype">YesNoType</a></td>
        <td>Whether to expand any environment variables in REG_SZ, REG_EXPAND_SZ, or REG_MULTI_SZ values.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Format</td>
        <td>Enumeration</td>
        <td>What format to return the value in.  This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>raw</dfn></dt><dd>Returns the unformatted value directly from the registry. For example, a REG_DWORD value of '1' is returned as '1', not '#1'.</dd><dt class="enumerationValue"><dfn>compatible</dfn></dt><dd>Returns the value formatted as Windows Installer would. For example, a REG_DWORD value of '1' is returned as '#1', not '1'.</dd></dl></td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Id</td>
        <td>String</td>
        <td>Id of the search for ordering and dependency.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Key</td>
        <td>String</td>
        <td>Key to search for.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Result</td>
        <td>Enumeration</td>
        <td>                         Rather than saving the matching registry value into the variable, a RegistrySearch can save an attribute of the matching entry instead.                       This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>exists</dfn></dt><dd>Saves true if a matching registry entry is found; false otherwise.</dd><dt class="enumerationValue"><dfn>value</dfn></dt><dd>Saves the value of the registry key in the variable. This is the default.</dd></dl></td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Root</td>
        <td>Enumeration</td>
        <td>Registry root hive to search under.  This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>HKLM</dfn></dt><dd>HKEY_LOCAL_MACHINE</dd><dt class="enumerationValue"><dfn>HKCU</dfn></dt><dd>HKEY_CURRENT_USER</dd><dt class="enumerationValue"><dfn>HKCR</dfn></dt><dd>HKEY_CLASSES_ROOT</dd><dt class="enumerationValue"><dfn>HKU</dfn></dt><dd>HKEY_USERS</dd></dl></td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Value</td>
        <td>String</td>
        <td>Optional value to search for under the given Key.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Variable</td>
        <td>String</td>
        <td>Name of the variable in which to place the result of the search.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Win64</td>
        <td><a href="../util/simple_type_yesnotype">YesNoType</a></td>
        <td>Instructs the search to look in the 64-bit registry when the value is 'yes'. When the value is 'no', the search looks in the 32-bit registry. The default value is 'no'.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../util">Util Schema</a>
  </dd>
</dl>
