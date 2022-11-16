---
title: UrlReservation Element (Http Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>         Makes a reservation record for the HTTP Server API configuration store on Windows XP SP2,         Windows Server 2003, and later.  For more information about the HTTP Server API, see         <a href="http://msdn.microsoft.com/library/windows/desktop/aa364510.aspx">           HTTP Server API         </a>.       </dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../component/">Component</a>, <a href="../serviceinstall/">ServiceInstall</a></dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../http/urlace" class="extension">UrlAce</a> (min: 0, max: unbounded)</li></ul></dd>
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
        <td>HandleExisting</td>
        <td>Enumeration</td>
        <td>             Specifies the behavior when trying to install a URL reservation and it already exists.             This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>replace</dfn></dt><dd>                   Replaces the existing URL reservation (the default).                 </dd><dt class="enumerationValue"><dfn>ignore</dfn></dt><dd>                   Keeps the existing URL reservation.                 </dd><dt class="enumerationValue"><dfn>fail</dfn></dt><dd>                   The installation fails.                 </dd></dl></td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Id</td>
        <td>String</td>
        <td>             Unique ID of this URL reservation.             If this attribute is not specified, an identifier will be generated automatically.           </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Sddl</td>
        <td>String</td>
        <td>             Security descriptor to apply to the URL reservation.             Can't be specified when using children UrlAce elements.           </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Url</td>
        <td>String</td>
        <td>             The <a href="http://msdn.microsoft.com/library/windows/desktop/aa364698.aspx">UrlPrefix</a>             string that defines the portion of the URL namespace to which this reservation pertains.           </td>
        <td>Yes</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../http">Http Schema</a>
  </dd>
</dl>
