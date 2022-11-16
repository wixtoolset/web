---
title: Dialog Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>                 Defines a dialog box in the Dialog Table.             </dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa368044.aspx" target="_blank">Control Table</a>, <a href="http://msdn.microsoft.com/library/aa367872.aspx" target="_blank">ComboBox Table</a>, <a href="http://msdn.microsoft.com/library/aa368286.aspx" target="_blank">Dialog Table</a>, <a href="http://msdn.microsoft.com/library/aa369762.aspx" target="_blank">ListBox Table</a>, <a href="http://msdn.microsoft.com/library/aa369764.aspx" target="_blank">ListView Table</a>, <a href="http://msdn.microsoft.com/library/aa370962.aspx" target="_blank">RadioButton Table</a></dd>
  <dt>Parents</dt>
  <dd>
    <a href="../ui/">UI</a>
  </dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Sequence (min: 1, max: 1)<ol><li><a href="../control/">Control</a> (min: 0, max: unbounded): Control elements belonging to this dialog.</li></ol></dd>
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
        <td>Unique identifier for the dialog.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>CustomPalette</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Used to specify if pictures in the dialog box are rendered with a custom palette.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ErrorDialog</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Specifies this dialog as an error dialog.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Height</td>
        <td>Integer</td>
        <td>The height of the dialog box in dialog units.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Hidden</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Used to hide the dialog.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>KeepModeless</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Keep modeless dialogs alive when this dialog is created through DoAction.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>LeftScroll</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Used to align the scroll bar on the left.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Modeless</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Used to set the dialog as modeless.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>NoMinimize</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Used to specify if the dialog can be minimized.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>RightAligned</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Align text on the right.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>RightToLeft</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Used to specify if the text in the dialog should be displayed in right to left reading order.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>SystemModal</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Used to set the dialog as system modal.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Title</td>
        <td>String</td>
        <td>The title of the dialog box.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>TrackDiskSpace</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Have the dialog periodically call the installer to check if available disk space has changed.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Width</td>
        <td>Integer</td>
        <td>The width of the dialog box in dialog units.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>X</td>
        <td>Integer</td>
        <td>Horizontal placement of the dialog box as a percentage of screen width. The default value is 50.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Y</td>
        <td>Integer</td>
        <td>Vertical placement of the dialog box as a percentage of screen height. The default value is 50.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>
  </dd>
</dl>
