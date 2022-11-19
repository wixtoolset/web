---
title: Font Element (Thmutil Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>Defines a font including the size and color.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../theme" class="extension">Theme</a>
  </dd>
  <dt>Inner Text (xs:string)</dt>
  <dd>Name of the font face.</dd>
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
        <td>Background</td>
        <td>HexBinary</td>
        <td>Hexadecimal value representing BGR background color of the font. "ffffff" is white, "ff0000" is pure blue, "00ff00" is pure green, "0000ff" is pure red and "000000" is black. If this value is absent the background will be transparent.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Foreground</td>
        <td>HexBinary</td>
        <td>Hexadecimal value representing BGR foreground color of the font. "ffffff" is white, "ff0000" is pure blue, "00ff00" is pure green, "0000ff" is pure red and "000000" is black. If this value is absent the foreground will be transparent.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Height</td>
        <td>Int</td>
        <td>Font size. Use negative numbers to specify the font in pixels.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Id</td>
        <td>NonNegativeInteger</td>
        <td>Numeric identifier for the font. Due to limitations in thmutil the first Font must start with "0" and each subsequent Font must increment the Id by 1. Failure to ensure the Font identifiers follow this strict ordering will create unexpected behavior or crashes.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Underline</td>
        <td><a href="../simple_type_yesnotype">YesNoType</a></td>
        <td>Specifies whether the font is underlined.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Weight</td>
        <td>NonNegativeInteger</td>
        <td>Font weight.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Thmutil Schema</a>
  </dd>
</dl>
