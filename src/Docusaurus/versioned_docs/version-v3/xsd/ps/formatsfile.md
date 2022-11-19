---
title: FormatsFile Element (Ps Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>         Identifies the parent File as a formats XML file for the referenced PowerShell snap-in.       </dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../../wix/file/">File</a>, <a href="../snapin" class="extension">SnapIn</a></dd>
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
        <td>FileId</td>
        <td>String</td>
        <td>             Reference to the formats File ID. This is required when nested under the SnapIn element.           </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>SnapIn</td>
        <td>String</td>
        <td>             Reference to the PowerShell snap-in ID for which this formats file is associated. This is required when nested under the File element.           </td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>Remarks</dt>
  <dd>A formats XML file that defines output formats for objects on the pipeline.</dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Ps Schema</a>
  </dd>
</dl>
