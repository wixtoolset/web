---
title: UI Element (Wixloc Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>Allows a localization to override the position, size, and text of dialogs and controls. Override the text by specifying the replacement text in the inner text of the UI element.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../wixlocalization" class="extension">WixLocalization</a>
  </dd>
  <dt>Inner Text (xs:string)</dt>
  <dd>This element may have inner text.</dd>
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
        <td>Control</td>
        <td>String</td>
        <td>Combined with the Dialog attribute, identifies the control to localize.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Dialog</td>
        <td>String</td>
        <td>Identifies the dialog to localize or the dialog that a control to localize is in.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Height</td>
        <td>Integer</td>
        <td>For a dialog, overrides the authored height in dialog units. For a control, overrides the authored height of the rectangular boundary of the control. This must be a non-negative number.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>LeftScroll</td>
        <td><a href="../simple_type_localizationyesnotype">LocalizationYesNoType</a></td>
        <td>Set this attribute to "yes" to cause the scroll bar to display on the left side of the Control. Not valid for a dialog.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>RightAligned</td>
        <td><a href="../simple_type_localizationyesnotype">LocalizationYesNoType</a></td>
        <td>Set this attribute to "yes" to cause the Control to be right aligned. Not valid for a dialog.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>RightToLeft</td>
        <td><a href="../simple_type_localizationyesnotype">LocalizationYesNoType</a></td>
        <td>Set this attribute to "yes" to cause the Control to display from right to left. Not valid for a dialog.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Width</td>
        <td>Integer</td>
        <td>For a dialog, overrides the authored width in dialog units. For a control, overrides the authored width of the rectangular boundary of the control. This must be a non-negative number.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>X</td>
        <td>Integer</td>
        <td>For a dialog, overrides the authored horizontal centering. For a control, overrides the authored horizontal coordinate of the upper-left corner of the rectangular boundary. This must be a non-negative number.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Y</td>
        <td>Integer</td>
        <td>For a dialog, overrides the authored vertical centering. For a control, overrides the authored vertical coordinate of the upper-left corner of the rectangular boundary of the control. This must be a non-negative number.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Wixloc Schema</a>
  </dd>
</dl>
