---
title: WebServiceExtension Element (Iis Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>The WebServiceExtension property is used by the Web server to determine whether a Web service extension is permitted to run.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../wix/component">Component</a>
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
        <td>Allow</td>
        <td><a href="../iis/simple_type_yesnotype">YesNoType</a></td>
        <td>Indicates if the extension is allowed or denied.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Description</td>
        <td>String</td>
        <td>Description of the extension.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>File</td>
        <td>String</td>
        <td>Usually a Property that resolves to short file name path</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Group</td>
        <td>String</td>
        <td>String used to identify groups of extensions.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>UIDeletable</td>
        <td><a href="../iis/simple_type_yesnotype">YesNoType</a></td>
        <td>Indicates if the UI is allowed to delete the extension from the list of not.  Default: Not deletable.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../iis">Iis Schema</a>
  </dd>
</dl>
