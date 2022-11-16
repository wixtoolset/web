---
title: MIME Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>                 MIME content-type for an Extension             </dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa370035.aspx" target="_blank">MIME Table</a>
  </dd>
  <dt>Parents</dt>
  <dd>
    <a href="../extension/">Extension</a>
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
        <td>Advertise</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Whether this MIME is to be advertised. The default is to match whatever the parent extension element uses.  If the parent element is not advertised, then this element cannot be advertised either.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Class</td>
        <td><a href="../simple_type_guid/">Guid</a></td>
        <td>Class ID for the COM server that is to be associated with the MIME content.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ContentType</td>
        <td>String</td>
        <td>This is the identifier for the MIME content.  It is commonly written in the form of type/format.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Default</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>If 'yes', become the content type for the parent Extension.  The default value is 'no'.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>
  </dd>
</dl>
