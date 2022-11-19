---
title: RegistrySearch Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Searches for file, directory or registry key and assigns to value of parent Property</dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa371171.aspx" target="_blank">RegLocator Table</a>, <a href="http://msdn.microsoft.com/library/aa371853.aspx" target="_blank">Signature Table</a></dd>
  <dt>Parents</dt>
  <dd>
    <a href="../compliancecheck/">ComplianceCheck</a>, <a href="../property/">Property</a></dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Choice of elements (min: 0, max: 1)<ul><li><a href="../directorysearch/">DirectorySearch</a> (min: 0, max: 1)</li><li><a href="../directorysearchref/">DirectorySearchRef</a> (min: 0, max: 1)</li><li><a href="../filesearch/">FileSearch</a> (min: 0, max: 1)</li><li><a href="../filesearchref/">FileSearchRef</a> (min: 0, max: 1)</li></ul></dd>
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
        <td>Signature to be used for the file, directory or registry key being searched for.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Key</td>
        <td>String</td>
        <td>Key for the registry value.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Name</td>
        <td>String</td>
        <td>Registry value name. If this value is null, then the value from the key's unnamed or default value, if any, is retrieved.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Root</td>
        <td>Enumeration</td>
        <td>Root key for the registry value.  This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>HKCR</dfn></dt><dd>                                     HKEY_CLASSES_ROOT                                 </dd><dt class="enumerationValue"><dfn>HKCU</dfn></dt><dd>                                     HKEY_CURRENT_USER                                 </dd><dt class="enumerationValue"><dfn>HKLM</dfn></dt><dd>                                     HKEY_LOCAL_MACHINE                                 </dd><dt class="enumerationValue"><dfn>HKU</dfn></dt><dd>                                     HKEY_USERS                                 </dd></dl></td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Type</td>
        <td>Enumeration</td>
        <td>                         The value must be 'file' if the child is a FileSearch element, and must be 'directory' if child is a DirectorySearch element.                       This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>directory</dfn></dt><dd>                                     The registry value contains the path to a directory.                                 </dd><dt class="enumerationValue"><dfn>file</dfn></dt><dd>                                     The registry value contains the path to a file. To return the full file path you must add a FileSearch element as a child of this element; otherwise, the parent directory of the file path is returned.                                 </dd><dt class="enumerationValue"><dfn>raw</dfn></dt><dd>                                     Sets the raw value from the registry value.  Please note that this value will contain a prefix as follows:<br /><br /><dl><dt>DWORD</dt><dd>Starts with '#' optionally followed by '+' or '-'.</dd><dt>REG_BINARY</dt><dd>Starts with '#x' and the installer converts and saves each hexadecimal digit (nibble) as an ASCII character prefixed by '#x'.</dd><dt>REG_EXPAND_SZ</dt><dd>Starts with '#%'.</dd><dt>REG_MULTI_SZ</dt><dd>Starts with '[~]' and ends with '[~]'.</dd><dt>REG_SZ</dt><dd>No prefix, but if the first character of the registry value is '#', the installer escapes the character by prefixing it with another '#'.</dd></dl></dd></dl></td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Win64</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Instructs the search to look in the 64-bit registry when the value is 'yes'. When the value is 'no', the search looks in the 32-bit registry.           The default value is based on the platform set by the -arch switch to candle.exe           or the InstallerPlatform property in a .wixproj MSBuild project:            For x86 and ARM, the default value is 'no'.            For x64, ARM64, and IA64, the default value is 'yes'.           </td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>Remarks</dt>
  <dd><p>                         When the Type attribute value is 'directory' the registry value must specify the path to a directory excluding the file name.                         When the Type attribute value is 'file' the registry value must specify the path to a file including the file name;                         however, if there is no child FileSearch element the parent directory of the file is returned. The FileSearch element requires                         that you author the name of the file you are searching for. If you do not know the file name                         you must set the Type attribute to 'raw' to return the full file path including the file name.                     </p></dd>
  <dt>How Tos and Examples</dt>
  <dd>
    <ul>
      <li>
        <a href="../../../howtos/files_and_registry/read_a_registry_entry">How To: Read a registry entry during installation</a>
      </li>
    </ul>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>, <a href="../componentsearch/">ComponentSearch</a>, <a href="../inifilesearch/">IniFileSearch</a></dd>
</dl>
