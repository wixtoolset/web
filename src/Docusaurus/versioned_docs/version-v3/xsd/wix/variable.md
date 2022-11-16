---
title: Variable Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Describes a burn engine variable to define.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../bundle/">Bundle</a>, <a href="../fragment/">Fragment</a></dd>
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
        <td>Hidden</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Whether the value of the variable should be hidden.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Name</td>
        <td>String</td>
        <td>The name for the variable.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Persisted</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Whether the variable should be persisted.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Type</td>
        <td>Enumeration</td>
        <td>Type of the variable, inferred from the value if not specified.  This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>string</dfn></dt><dd></dd><dt class="enumerationValue"><dfn>numeric</dfn></dt><dd></dd><dt class="enumerationValue"><dfn>version</dfn></dt><dd></dd></dl></td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Value</td>
        <td>String</td>
        <td>Starting value for the variable.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td colspan="4">
          <span class="extension">Any Attribute (namespace='##other' processContents='lax')                      Extensibility point in the WiX XML Schema.  Schema extensions can register additional                     attributes at this point in the schema.                 </span>
          <tr>
            <td>
              <span class="extension">Overridable</span>
            </td>
            <td><a href="../bal/simple_type_yesnotype">YesNoType</a></td>
            <td>                 When set to "yes", lets the user override the variable's default value by specifying another value on the command line,                 in the form Variable=Value. Otherwise, WixStdBA won't overwrite the default value and will log                  "Ignoring attempt to set non-overridable variable: 'BAR'."              (http://schemas.microsoft.com/wix/BalExtension)</td>
            <td>&nbsp;</td>
          </tr>
        </td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>
  </dd>
</dl>
