---
title: Hyperlink Element (Thmutil Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>Defines a hyperlink.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../page" class="extension">Page</a>, <a href="../theme" class="extension">Theme</a></dd>
  <dt>Inner Text (xs:string)</dt>
  <dd>Text to display as the link.</dd>
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
        <td>FontId</td>
        <td>NonNegativeInteger</td>
        <td>Numeric identifier to the Font element that serves as the unselected font.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Height</td>
        <td>Int</td>
        <td>Height of the control. Non-positive values extend the control to the bottom of the window minus the value.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>HexStyle</td>
        <td>HexBinary</td>
        <td>Hexadecimal window style for the control.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>HideWhenDisabled</td>
        <td><a href="../simple_type_yesnotype">YesNoType</a></td>
        <td>Specifies whether the control should be hidden when disabled.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>HoverFontId</td>
        <td>NonNegativeInteger</td>
        <td>Numeric identifier to the Font element that serves as the font when the control is hovered over.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Name</td>
        <td>String</td>
        <td>Optional name for the control.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>SelectedFontId</td>
        <td>NonNegativeInteger</td>
        <td>Numeric identifier to the Font element that serves as the font when the control is selected.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>TabStop</td>
        <td><a href="../simple_type_yesnotype">YesNoType</a></td>
        <td>Specifies whether the control is part of the tab sequence of controls.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Visible</td>
        <td><a href="../simple_type_yesnotype">YesNoType</a></td>
        <td>Specifies whether the control is initially visible.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Width</td>
        <td>Int</td>
        <td>Width of the control. Non-positive values extend the control to the right of the window minus the value.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>X</td>
        <td>Int</td>
        <td>X coordinate for the control from the left of the window. Negative values are coordinates from the right of the window minus the width of the control.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Y</td>
        <td>Int</td>
        <td>Y coordinate for the control from the top of the window. Negative values are coordinates from the bottom of the window minus the height of the control.</td>
        <td>Yes</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Thmutil Schema</a>
  </dd>
</dl>
