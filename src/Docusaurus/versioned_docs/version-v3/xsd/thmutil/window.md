---
title: Window Element (Thmutil Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>Defines the overall look of the main window.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../theme" class="extension">Theme</a>
  </dd>
  <dt>Inner Text (xs:string)</dt>
  <dd>Caption for the window.</dd>
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
        <td>AutoResize</td>
        <td><a href="../simple_type_yesnotype">YesNoType</a></td>
        <td>Specifies whether the ThmUtil default window proc should process WM_SIZE and WM_SIZING events.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>FontId</td>
        <td>NonNegativeInteger</td>
        <td>Numeric identifier to the Font element that serves as the default font for the window.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Height</td>
        <td>PositiveInteger</td>
        <td>Height of the window.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>HexStyle</td>
        <td>HexBinary</td>
        <td>                                 Hexadecimal window style. If this is not specified the default value is: WS_OVERLAPPED | WS_VISIBLE | WS_MINIMIZEBOX | WS_SYSMENU.                                 If SourceX and SourceY are greater than 0, then WS_OVERLAPPED is replaced with WS_POPUP.                             </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>IconFile</td>
        <td>String</td>
        <td>Relative path to an icon file for the window. Mutually exclusive with IconResource and SourceX and SourceY attributes.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>IconResource</td>
        <td>String</td>
        <td>Identifier that references icon resource in the module for the window. Mutually exclusive with IconFile and SourceX and SourceY attributes.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>MinimumHeight</td>
        <td>PositiveInteger</td>
        <td>Minimum height of the window. Only functions if AutoResize is enabled.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>MinimumWidth</td>
        <td>PositiveInteger</td>
        <td>Minimum width of the window. Only functions if AutoResize is enabled.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>SourceX</td>
        <td>NonNegativeInteger</td>
        <td>X offset of the window background in the Theme/@ImageFile. Mutually exclusive with IconFile and IconResource.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>SourceY</td>
        <td>NonNegativeInteger</td>
        <td>Y offset of the window background in the Theme/@ImageFile. Mutually exclusive with IconFile and IconResource.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Width</td>
        <td>PositiveInteger</td>
        <td>Width of the window.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Thmutil Schema</a>
  </dd>
</dl>
