---
title: RadioButton Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Text or Icon plus Value that is assigned to the Property of the parent Control (RadioButtonGroup).</dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa370962.aspx" target="_blank">RadioButton Table</a>, <a href="http://msdn.microsoft.com/library/aa368044.aspx" target="_blank">Control Table</a>, <a href="http://msdn.microsoft.com/library/aa368286.aspx" target="_blank">Dialog Table</a></dd>
  <dt>Parents</dt>
  <dd>
    <a href="../radiobuttongroup/">RadioButtonGroup</a>
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
        <td>Bitmap</td>
        <td>String</td>
        <td>                     This attribute defines the bitmap displayed with the radio button.  The value of the attribute creates a reference                     to a Binary element that represents the bitmap.  This attribute is mutually exclusive with the Icon and Text                     attributes.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Height</td>
        <td><a href="../simple_type_localizableinteger/">LocalizableInteger</a></td>
        <td>&nbsp;</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Help</td>
        <td>String</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Icon</td>
        <td>String</td>
        <td>                     This attribute defines the icon displayed with the radio button.  The value of the attribute creates a reference                     to a Binary element that represents the icon.  This attribute is mutually exclusive with the Bitmap and Text                     attributes.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Text</td>
        <td>String</td>
        <td>Text displayed with the radio button.  This attribute is mutually exclusive with the Bitmap and Icon attributes.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ToolTip</td>
        <td>String</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Value</td>
        <td>String</td>
        <td>Value assigned to the associated control Property when this radio button is selected.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Width</td>
        <td><a href="../simple_type_localizableinteger/">LocalizableInteger</a></td>
        <td>&nbsp;</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>X</td>
        <td><a href="../simple_type_localizableinteger/">LocalizableInteger</a></td>
        <td>&nbsp;</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Y</td>
        <td><a href="../simple_type_localizableinteger/">LocalizableInteger</a></td>
        <td>&nbsp;</td>
        <td>Yes</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Wix Schema</a>, <a href="../radiobuttongroup/">RadioButtonGroup</a></dd>
</dl>
