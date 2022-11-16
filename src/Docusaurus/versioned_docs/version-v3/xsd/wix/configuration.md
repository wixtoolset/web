---
title: Configuration Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Defines the configurable attributes of merge module.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../module/">Module</a>
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
        <td>ContextData</td>
        <td>String</td>
        <td>Specifies a semantic context for the requested data.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>DefaultValue</td>
        <td>String</td>
        <td>Specifies a default value for the item in this record if the merge tool declines to provide a value.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Description</td>
        <td>String</td>
        <td>Description for authoring.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>DisplayName</td>
        <td>String</td>
        <td>Display name for authoring.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Format</td>
        <td>Enumeration</td>
        <td>Specifies the format of the data being changed.  This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>Text</dfn></dt><dd></dd><dt class="enumerationValue"><dfn>Key</dfn></dt><dd></dd><dt class="enumerationValue"><dfn>Integer</dfn></dt><dd></dd><dt class="enumerationValue"><dfn>Bitfield</dfn></dt><dd></dd></dl></td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>HelpKeyword</td>
        <td>String</td>
        <td>Keyword into chm file for authoring.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>HelpLocation</td>
        <td>String</td>
        <td>Location of chm file for authoring.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>KeyNoOrphan</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Does not merge rule according to rules in MSI SDK.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Name</td>
        <td>String</td>
        <td>Defines the name of the configurable item.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>NonNullable</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>If yes, null is not a valid entry.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Type</td>
        <td>String</td>
        <td>Specifies the type of the data being changed.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>
  </dd>
</dl>
