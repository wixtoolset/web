---
title: UI Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>                 Enclosing element to compartmentalize UI specifications.             </dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../wix/fragment">Fragment</a>, <a href="../wix/module">Module</a>, <a href="../wix/product">Product</a></dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../wix/billboardaction">BillboardAction</a> (min: 0, max: unbounded): Billboard table item with child Controls</li><li><a href="../wix/binary">Binary</a> (min: 0, max: unbounded)</li><li><a href="../wix/combobox">ComboBox</a> (min: 0, max: unbounded): ComboBox table with ListItem children</li><li><a href="../wix/dialog">Dialog</a> (min: 0, max: unbounded): Dialog specification, called from Sequence</li><li><a href="../wix/dialogref">DialogRef</a> (min: 0, max: unbounded): Reference to a Dialog specification.</li><li><a href="../wix/embeddedui">EmbeddedUI</a> (min: 0, max: unbounded): Embedded UI definition with EmbeddedResource children.</li><li><a href="../wix/error">Error</a> (min: 0, max: unbounded): Error text associated with install error</li><li><a href="../wix/listbox">ListBox</a> (min: 0, max: unbounded): ListBox table with ListItem children</li><li><a href="../wix/listview">ListView</a> (min: 0, max: unbounded): ListView table with ListItem children</li><li><a href="../wix/progresstext">ProgressText</a> (min: 0, max: unbounded): ActionText entry associated with an action</li><li><a href="../wix/property">Property</a> (min: 0, max: unbounded)</li><li><a href="../wix/propertyref">PropertyRef</a> (min: 0, max: unbounded)</li><li><a href="../wix/publish">Publish</a> (min: 0, max: unbounded)</li><li><a href="../wix/radiobuttongroup">RadioButtonGroup</a> (min: 0, max: unbounded): RadioButton table with RadioButton children</li><li><a href="../wix/textstyle">TextStyle</a> (min: 0, max: unbounded): TextStyle entry for use in control text</li><li><a href="../wix/uiref">UIRef</a> (min: 0, max: unbounded)</li><li><a href="../wix/uitext">UIText</a> (min: 0, max: unbounded): values for UIText property, not installer Property</li><li>Sequence (min: 1, max: 1)<ol><li><a href="../wix/adminuisequence">AdminUISequence</a> (min: 0, max: 1)</li><li><a href="../wix/installuisequence">InstallUISequence</a> (min: 0, max: 1)</li></ol></li></ul></dd>
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
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>, <a href="../wix/uiref">UIRef</a></dd>
</dl>
