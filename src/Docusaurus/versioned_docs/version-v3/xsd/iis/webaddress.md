---
title: WebAddress Element (Iis Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>WebAddress for WebSite</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../../iis/website" class="extension">WebSite</a>
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
        <td>&nbsp;</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Header</td>
        <td>String</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>IP</td>
        <td>String</td>
        <td>                       The IP address to locate an existing WebSite or create a new WebSite. When the WebAddress is part of a WebSite element                       used to locate an existing web site the following rules are used:                       <ul><li>When this attribute is not specified only the "All Unassigned" IP address will be located.</li><li>When this attribute is explicitly specified only the specified IP address will be located.</li><li>When this attribute has the value "*" then any IP address including the "All Unassigned" IP address will be located</li></ul>                       When the WebAddress is part of a WebSite element used to create a new web site the following rules are used:                       <ul><li>When this attribute is not specified or the value is "*" the "All Unassigned" IP address will be used.</li><li>When this attribute is explicitly specified the IP address will use that value.</li></ul>                       The IP attribute can contain a formatted string that is processed at install time to insert the values of properties using                       [PropertyName] syntax.                      </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Port</td>
        <td>String</td>
        <td>&nbsp;</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Secure</td>
        <td><a href="../../iis/simple_type_yesnotype">YesNoType</a></td>
        <td>Determines if this address represents a secure binding.  The default is 'no'.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Iis Schema</a>
  </dd>
</dl>
