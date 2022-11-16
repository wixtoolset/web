---
title: Shortcut Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>                 Shortcut, default target is parent File, CreateFolder, or Component's Directory             </dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa371847.aspx" target="_blank">Shortcut Table</a>
  </dd>
  <dt>Parents</dt>
  <dd>
    <a href="../component/">Component</a>, <a href="../createfolder/">CreateFolder</a>, <a href="../file/">File</a></dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../icon/">Icon</a> (min: 0, max: unbounded)</li><li><a href="../shortcutproperty/">ShortcutProperty</a> (min: 0, max: unbounded)</li></ul></dd>
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
        <td>Unique identifier for the shortcut. This value will serve as the primary key for the row.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Advertise</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Specifies if the shortcut should be advertised or not. Note that advertised shortcuts                 always point at a particular application, identified by a ProductCode, and should not be shared between applications.                 Advertised shortcuts only work for the most recently installed application, and are removed when that application is                 removed.  The default value is 'no'.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Arguments</td>
        <td>String</td>
        <td>The command-line arguments for the shortcut. Note that the resolution of properties                 in the Arguments field is limited. A property formatted as [Property] in this field can only be resolved if the                 property already has the intended value when the component owning the shortcut is installed. For example, for the                 argument "[#MyDoc.doc]" to resolve to the correct value, the same process must be installing the file MyDoc.doc and                 the component that owns the shortcut.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Description</td>
        <td>String</td>
        <td>The localizable description for the shortcut.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>DescriptionResourceDll</td>
        <td>String</td>
        <td>                         The Formatted string providing the full path to the language neutral file containing the MUI Manifest.   Generally                         authored using [#filekey] form.  When this attribute is specified, the DescriptionResourceId attribute must also                         be provided.<br/><br/>                        This attribute is only used on Windows Vista and above.  If this attribute is not specified and the install                         is running on Vista and above, the value in the Name attribute is used.  If this attribute is provided and                         the install is running on Vista and above, the value in the Name attribute is ignored.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>DescriptionResourceId</td>
        <td>Integer</td>
        <td>                         The description name index for the shortcut. This must be a non-negative number.  When this attribute is specified,                         the DescriptionResourceDll attribute must also be populated.<br/><br/>                        This attribute is only used on Windows Vista and above.  If this attribute is not specified and the install                         is running on Vista and above, the value in the Name attribute is used.  If this attribute is populated and the                         install is running on Vista and above, the value in the Name attribute is ignored.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Directory</td>
        <td>String</td>
        <td>Identifier reference to Directory element where shortcut is to be created. When nested under a Component element, this attribute's value will default to the parent directory. Otherwise, this attribute is required.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>DisplayResourceDll</td>
        <td>String</td>
        <td>                         The Formatted string providing the full path to the language neutral file containing the MUI Manifest.   Generally                         authored using [#filekey] form.  When this attribute is specified, the DisplayResourceId attribute must also                         be provided.<br/><br/>                        This attribute is only used on Windows Vista and above.  If this attribute is not populated and the install                         is running on Vista and above, the value in the Name attribute is used.  If this attribute is populated and                         the install is running on Vista and above, the value in the Name attribute is ignored.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>DisplayResourceId</td>
        <td>Integer</td>
        <td>                         The display name index for the shortcut. This must be a non-negative number.  When this attribute is specified, the                         DisplayResourceDll attribute must also be provided.<br/><br/>                        This attribute is only used on Windows Vista and above.  If this attribute is not specified and the install                         is running on Vista and above, the value in the Name attribute is used.  If this attribute is specified and                         the install is running on Vista and above, the value in the Name attribute is ignored.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Hotkey</td>
        <td>Integer</td>
        <td>The hotkey for the shortcut. The low-order byte contains the virtual-key code for                 the key, and the high-order byte contains modifier flags. This must be a non-negative number. Authors of                 installation packages are generally recommend not to set this option, because this can add duplicate hotkeys to a                 users desktop. In addition, the practice of assigning hotkeys to shortcuts can be problematic for users using hotkeys                 for accessibility.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Icon</td>
        <td>String</td>
        <td>Identifier reference to Icon element. The Icon identifier should have the same extension                 as the file that it points at.  For example, a shortcut to an executable (e.g. "my.exe") should reference an Icon with identifier                 like "MyIcon.exe"</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>IconIndex</td>
        <td>Integer</td>
        <td>Identifier reference to Icon element.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>LongName</td>
        <td><a href="../simple_type_longfilenametype/">LongFileNameType</a></td>
        <td>This attribute has been deprecated; please use the Name attribute instead.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Name</td>
        <td><a href="../simple_type_longfilenametype/">LongFileNameType</a></td>
        <td>                         In prior versions of the WiX toolset, this attribute specified the short name.                         This attribute's value may now be either a short or long name.                         If a short name is specified, the ShortName attribute may not be specified.                         If a long name is specified, the LongName attribute may not be specified.                         Also, if this value is a long name, the ShortName attribute may be omitted to                         allow WiX to attempt to generate a unique short name.                         However, if this name collides with another shortcut or you wish to manually specify                         the short name, then the ShortName attribute may be specified.                     </td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>ShortName</td>
        <td><a href="../simple_type_shortfilenametype/">ShortFileNameType</a></td>
        <td>                         The short name of the shortcut in 8.3 format.                         This attribute should only be set if there is a conflict between generated short names                         or the user wants to manually specify the short name.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Show</td>
        <td>Enumeration</td>
        <td>This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>normal</dfn></dt><dd>                                     The shortcut target will be displayed using the SW_SHOWNORMAL attribute.                                 </dd><dt class="enumerationValue"><dfn>minimized</dfn></dt><dd>                                     The shortcut target will be displayed using the SW_SHOWMINNOACTIVE attribute.                                 </dd><dt class="enumerationValue"><dfn>maximized</dfn></dt><dd>                                     The shortcut target will be displayed using the SW_SHOWMAXIMIZED attribute.                                 </dd></dl></td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Target</td>
        <td>String</td>
        <td>                         This attribute can only be set if this Shortcut element is nested under a Component element.                         When nested under a Component element, this attribute's value will default to the parent directory.                         This attribute's value is the target for a non-advertised shortcut.                         This attribute is not valid for advertised shortcuts.                         If you specify this value, its value should be a property identifier enclosed by square brackets ([ ]), that is expanded into the file or a folder pointed to by the shortcut.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>WorkingDirectory</td>
        <td>String</td>
        <td>Directory identifier (or Property identifier that resolves to a directory) that resolves                 to the path of the working directory for the shortcut.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>How Tos and Examples</dt>
  <dd>
    <ul>
      <li>
        <a href="../../howtos/files_and_registry/create_start_menu_shortcut">How To: Create a shortcut on the Start Menu</a>
      </li>
    </ul>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>
  </dd>
</dl>
