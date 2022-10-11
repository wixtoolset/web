---
title: Extension Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>                 Extension for a Component             </dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa370035.aspx" target="_blank">MIME Table</a>, <a href="http://msdn.microsoft.com/library/aa372487.aspx" target="_blank">Verb Table</a>, <a href="http://msdn.microsoft.com/library/aa371168.aspx" target="_blank">Registry Table</a></dd>
  <dt>Parents</dt>
  <dd>
    <a href="../wix/component">Component</a>, <a href="../wix/progid">ProgId</a></dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../wix/mime">MIME</a> (min: 0, max: unbounded)</li><li><a href="../wix/verb">Verb</a> (min: 0, max: unbounded)</li></ul></dd>
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
        <td>This is simply the file extension, like "doc" or "xml".  Do not include the preceding period.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Advertise</td>
        <td><a href="../wix/simple_type_yesnotype">YesNoType</a></td>
        <td>Whether this extension is to be advertised. The default is "no".</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ContentType</td>
        <td>String</td>
        <td>The MIME type that is to be written.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td colspan="4">
          <span class="extension">Any Attribute (namespace='##other' processContents='lax')                      Extensibility point in the WiX XML Schema.  Schema extensions can register additional                     attributes at this point in the schema.                 </span>
          <tr>
            <td>
              <span class="extension">IsRichSavedGame</span>
            </td>
            <td>&nbsp;</td>
            <td>                 Registers this extension for the                  <a href="http://msdn.microsoft.com/library/bb173448.aspx" target="_blank">rich saved games</a>                  property handler on Windows Vista and later.              (http://schemas.microsoft.com/wix/GamingExtension)</td>
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
