---
title: UrlAce Element (Http Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>         The security principal and which rights to assign to them for the URL reservation.       </dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../urlreservation" class="extension">UrlReservation</a>
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
        <td>             Unique ID of this URL ACE.             If this attribute is not specified, an identifier will be generated automatically.           </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Rights</td>
        <td>Enumeration</td>
        <td>             Rights for this ACE. Default is "all".             This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>register</dfn></dt><dd></dd><dt class="enumerationValue"><dfn>delegate</dfn></dt><dd></dd><dt class="enumerationValue"><dfn>all</dfn></dt><dd></dd></dl></td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>SecurityPrincipal</td>
        <td>String</td>
        <td>             The security principal for this ACE.  When the UrlReservation is under a ServiceInstall element, this defaults to             "NT SERVICE\ServiceInstallName".  This may be either a SID or an account name in a format that             <a href="http://msdn.microsoft.com/library/windows/desktop/aa379159.aspx">LookupAccountName</a>             supports.  When using a SID, an asterisk must be prepended.  For example, "*S-1-5-18".           </td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Http Schema</a>
  </dd>
</dl>
