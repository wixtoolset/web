---
title: DigitalCertificate Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>                 Adds a digital certificate.             </dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa370086.aspx" target="_blank">MsiDigitalCertificate Table</a>
  </dd>
  <dt>Parents</dt>
  <dd>
    <a href="../wix/digitalsignature">DigitalSignature</a>, <a href="../wix/packagecertificates">PackageCertificates</a>, <a href="../wix/patchcertificates">PatchCertificates</a></dd>
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
        <td>Id</td>
        <td>String</td>
        <td>Identifier for a certificate file.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>SourceFile</td>
        <td>String</td>
        <td>The path to the certificate file.</td>
        <td>Yes</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>
  </dd>
</dl>
