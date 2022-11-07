---
title: ListItem Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>                 The value (and optional text) associated with an item in a ComboBox, ListBox, or ListView.             </dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa367872.aspx" target="_blank">ComboBox Table</a>, <a href="http://msdn.microsoft.com/library/aa369762.aspx" target="_blank">ListBox Table</a>, <a href="http://msdn.microsoft.com/library/aa369764.aspx" target="_blank">ListView Table</a></dd>
  <dt>Parents</dt>
  <dd>
    <a href="../wix/combobox">ComboBox</a>, <a href="../wix/listbox">ListBox</a>, <a href="../wix/listview">ListView</a></dd>
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
        <td>Icon</td>
        <td>String</td>
        <td>                         The identifier of the Binary (not Icon) element containing the icon to associate with this item.                         This value is only valid when nested under a ListView element.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Text</td>
        <td>String</td>
        <td>                         The localizable, visible text to be assigned to the item.                         If not specified, this will default to the value of the Value attribute.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Value</td>
        <td>String</td>
        <td>                         The value assigned to the associated ComboBox, ListBox, or ListView property if this item is selected.                     </td>
        <td>Yes</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>
  </dd>
</dl>
