---
title: WixLocalization Element (Wixloc Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>None</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>None</dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../string" class="extension">String</a> (min: 0, max: unbounded)</li><li><a href="../ui" class="extension">UI</a> (min: 0, max: unbounded)</li></ul></dd>
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
        <td>Codepage</td>
        <td>String</td>
        <td>The code page integer value or web name for the resulting database. You can also specify -1 which will not reset the database code page. See remarks for more information.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Culture</td>
        <td>String</td>
        <td>Culture of the localization strings.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Language</td>
        <td>Integer</td>
        <td>The decimal language ID (LCID) for the culture.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>Remarks</dt>
  <dd><p>You can specify any valid Windows code page by integer like 1252, or by web name like Windows-1252 or iso-8859-1. See <a href="../../../overview/codepage">Code Pages</a> for more information.</p></dd>
  <dt>How Tos and Examples</dt>
  <dd>
    <ul>
      <li>
        <a href="../../../howtos/ui_and_localization/build_a_localized_version">How To: Build a localized version of your installer</a>
      </li>
      <li>
        <a href="../../../howtos/ui_and_localization/make_installer_localizable">How To: Make your installer localizable</a>
      </li>
    </ul>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Wixloc Schema</a>
  </dd>
</dl>
