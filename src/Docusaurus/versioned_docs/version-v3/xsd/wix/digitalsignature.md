---
title: DigitalSignature Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>                 Adds a digital signature.             </dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa370087.aspx" target="_blank">MsiDigitalSignature Table</a>
  </dd>
  <dt>Parents</dt>
  <dd>
    <a href="../wix/media">Media</a>
  </dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Choice of elements (min: 1, max: 1)<ul><li><a href="../wix/digitalcertificate">DigitalCertificate</a> (min: 1, max: 1)</li></ul></dd>
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
        <td>SourceFile</td>
        <td>String</td>
        <td>The path to signature's optional hash file.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>
  </dd>
</dl>
