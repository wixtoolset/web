---
title: Control Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Contains the controls that appear on each dialog.</dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa368044.aspx" target="_blank">Control Table</a>, <a href="http://msdn.microsoft.com/library/aa367872.aspx" target="_blank">ComboBox Table</a>, <a href="http://msdn.microsoft.com/library/aa368286.aspx" target="_blank">Dialog Table</a>, <a href="http://msdn.microsoft.com/library/aa369762.aspx" target="_blank">ListBox Table</a>, <a href="http://msdn.microsoft.com/library/aa369764.aspx" target="_blank">ListView Table</a>, <a href="http://msdn.microsoft.com/library/aa370962.aspx" target="_blank">RadioButton Table</a></dd>
  <dt>Parents</dt>
  <dd>
    <a href="../billboard/">Billboard</a>, <a href="../dialog/">Dialog</a></dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Sequence (min: 1, max: 1)<ol><li><a href="../text/">Text</a> (min: 0, max: 1): alternative to Text attribute when CDATA is needed to escape XML delimiters</li><li><a href="../combobox/">ComboBox</a> (min: 0, max: 1): ComboBox table with ListItem children</li><li><a href="../listbox/">ListBox</a> (min: 0, max: 1): ListBox table with ListItem children</li><li><a href="../listview/">ListView</a> (min: 0, max: 1): ListView table with ListItem children</li><li><a href="../radiobuttongroup/">RadioButtonGroup</a> (min: 0, max: 1): RadioButton table with RadioButton children</li><li><a href="../property/">Property</a> (min: 0, max: 1): Property table entry for the Property table column associated with this control</li><li><a href="../binary/">Binary</a> (min: 0, max: 1): Icon referenced in icon column of row</li><li>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../condition/">Condition</a> (min: 0, max: unbounded): Condition to specify actions for this control based on the outcome of the condition.</li><li><a href="../publish/">Publish</a> (min: 0, max: unbounded)</li><li><a href="../subscribe/">Subscribe</a> (min: 0, max: unbounded)</li></ul></li></ol></dd>
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
        <td>Combined with the Dialog Id to make up the primary key of the Control table.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Bitmap</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>This attribute is only valid for RadioButton and PushButton Controls.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Cancel</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Set this attribute to "yes" to cause this Control to be invoked by the escape key.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>CDROM</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>This attribute is only valid for Volume and Directory Controls.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>CheckBoxPropertyRef</td>
        <td>String</td>
        <td>This attribute is only valid for CheckBox controls. The value is the name of a Property that was already used as the Property for another CheckBox control. The Property attribute cannot be specified. The attribute exists to support multiple checkboxes on different dialogs being tied to the same property.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>CheckBoxValue</td>
        <td>String</td>
        <td>This attribute is only valid for CheckBox Controls. When set, the linked Property will be set to this value when the check box is checked.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ComboList</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>This attribute is only valid for ComboBox Controls.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Default</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Set this attribute to "yes" to cause this Control to be invoked by the return key.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Disabled</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Set this attribute to "yes" to cause the Control to be disabled.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ElevationShield</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>                         This attribute is only valid for PushButton controls.                         Set this attribute to "yes" to add the User Account Control (UAC) elevation icon (shield icon) to the PushButton control.                         If this attribute's value is "yes" and the installation is not yet running with elevated privileges,                         the pushbutton control is created using the User Account Control (UAC) elevation icon (shield icon).                         If this attribute's value is "yes" and the installation is already running with elevated privileges,                         the pushbutton control is created using the other icon attributes.                         Otherwise, the pushbutton control is created using the other icon attributes.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Fixed</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>This attribute is only valid for Volume and Directory Controls.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>FixedSize</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>This attribute is only valid for RadioButton, PushButton, and Icon Controls.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Floppy</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>This attribute is only valid for Volume and Directory Controls.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>FormatSize</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>This attribute is only valid for Text Controls.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>HasBorder</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>This attribute is only valid for RadioButton Controls.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Height</td>
        <td><a href="../simple_type_localizableinteger/">LocalizableInteger</a></td>
        <td>Height of the rectangular boundary of the control. This must be a non-negative number.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Help</td>
        <td>String</td>
        <td>This attribute is reserved for future use. There is no need to use this until Windows Installer uses it for something.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Hidden</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Set this attribute to "yes" to cause the Control to be hidden.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Icon</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>This attribute is only valid for RadioButton and PushButton Controls.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>IconSize</td>
        <td>Enumeration</td>
        <td>This attribute is only valid for RadioButton, PushButton, and Icon Controls.  This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>16</dfn></dt><dd></dd><dt class="enumerationValue"><dfn>32</dfn></dt><dd></dd><dt class="enumerationValue"><dfn>48</dfn></dt><dd></dd></dl></td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Image</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>This attribute is only valid for RadioButton, PushButton, and Icon Controls.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Indirect</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Specifies whether the value displayed or changed by this control is referenced indirectly. If this bit is set, the control displays or changes the value of the property that has the identifier listed in the Property column of the Control table.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Integer</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Set this attribute to "yes" to cause the linked Property value for the Control to be treated as an integer. Otherwise, the Property will be treated as a string.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>LeftScroll</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Set this attribute to "yes" to cause the scroll bar to display on the left side of the Control.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Multiline</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>This attribute is only valid for Edit Controls.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>NoPrefix</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>This attribute is only valid for Text Controls.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>NoWrap</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>This attribute is only valid for Text Controls.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Password</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>This attribute is only valid for Edit Controls.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ProgressBlocks</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>This attribute is only valid for ProgressBar Controls.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Property</td>
        <td>String</td>
        <td>The name of a defined property to be linked to this control. This column is required for active controls.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>PushLike</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>This attribute is only valid for RadioButton and Checkbox Controls.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>RAMDisk</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>This attribute is only valid for Volume and Directory Controls.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Remote</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>This attribute is only valid for Volume and Directory Controls.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Removable</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>This attribute is only valid for Volume and Directory Controls.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>RightAligned</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Set this attribute to "yes" to cause the Control to be right aligned.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>RightToLeft</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Set this attribute to "yes" to cause the Control to display from right to left.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ShowRollbackCost</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>This attribute is only valid for VolumeCostList Controls.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Sorted</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>This attribute is only valid for ListBox, ListView, and ComboBox Controls. Set                 the value of this attribute to "yes" to have entries appear in the order specified under the Control.                 If the attribute value is "no" or absent the entries in the control will appear in alphabetical order.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Sunken</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Set this attribute to "yes" to cause the Control to be sunken.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>TabSkip</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Set this attribute to "yes" to cause this Control to be skipped in the tab sequence.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Text</td>
        <td>String</td>
        <td>A localizable string used to set the initial text contained in a control. This attribute can contain a formatted string that is processed at install time to insert the values of properties using [PropertyName] syntax. Also supported are environment variables, file installation paths, and component installation directories; see <a href="http://msdn.microsoft.com/library/aa368609.aspx" target="_blank">Formatted</a> for details.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ToolTip</td>
        <td>String</td>
        <td>The string used for the Tooltip.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Transparent</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>This attribute is only valid for Text Controls.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Type</td>
        <td>String</td>
        <td>The type of the control. Could be one of the following: Billboard, Bitmap, CheckBox, ComboBox, DirectoryCombo, DirectoryList, Edit, GroupBox, Hyperlink, Icon, Line, ListBox, ListView, MaskedEdit, PathEdit, ProgressBar, PushButton, RadioButtonGroup, ScrollableText, SelectionTree, Text, VolumeCostList, VolumeSelectCombo</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>UserLanguage</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>This attribute is only valid for Text Controls.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Width</td>
        <td><a href="../simple_type_localizableinteger/">LocalizableInteger</a></td>
        <td>Width of the rectangular boundary of the control. This must be a non-negative number.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>X</td>
        <td><a href="../simple_type_localizableinteger/">LocalizableInteger</a></td>
        <td>Horizontal coordinate of the upper-left corner of the rectangular boundary of the control. This must be a non-negative number.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Y</td>
        <td><a href="../simple_type_localizableinteger/">LocalizableInteger</a></td>
        <td>Vertical coordinate of the upper-left corner of the rectangular boundary of the control. This must be a non-negative number.</td>
        <td>Yes</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>
  </dd>
</dl>
