---
title: CertificateRef Element (Iis Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>                 Associates a certificate with the parent WebSite.  The Certificate element should be                 in the same Component as the parent WebSite.             </dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../iis/website" class="extension">WebSite</a>
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
        <td>Id</td>
        <td>String</td>
        <td>                         The identifier of the referenced Certificate.                     </td>
        <td>Yes</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../iis">Iis Schema</a>, <a href="../iis/certificate" class="extension">Certificate</a></dd>
</dl>
