---
title: WebFilter Element (Iis Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>IIs Filter for a Component</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../../wix/component/">Component</a>, <a href="../../iis/website" class="extension">WebSite</a></dd>
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
        <td>The unique Id for the web filter.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Description</td>
        <td>String</td>
        <td>Description of the filter.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Flags</td>
        <td>Integer</td>
        <td>Sets the MD_FILTER_FLAGS metabase key for the filter. This must be an integer. See MSDN 'FilterFlags' documentation for more details.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>LoadOrder</td>
        <td>String</td>
        <td>                         The legal values are "first", "last", or a number.                         If a number is specified, it must be greater than 0.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Name</td>
        <td>String</td>
        <td>The name of the filter to be used in IIS.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Path</td>
        <td>String</td>
        <td>                         The path of the filter executable file.                         This should usually be a value like '[!FileId]', where 'FileId' is the file identifier                         of the filter executable file.                     </td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>WebSite</td>
        <td>String</td>
        <td>                         Specifies the parent website for this filter (if there is one).                         If this is a global filter, then this attribute should not be specified.                     </td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Iis Schema</a>
  </dd>
</dl>
