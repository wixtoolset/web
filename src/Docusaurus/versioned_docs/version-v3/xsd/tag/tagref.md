---
title: TagRef Element (Tag Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>         Allows an ISO/IEC 19770-2:2015 SWID tag file to be referenced in a Patch.       </dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../../wix/patchfamily/">PatchFamily</a>
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
        <td>Regid</td>
        <td>String</td>
        <td>             The regid for the software manufacturer. A regid is a URI simplified for the common             case. Namely, if the scheme is "http://", it can be removed. Additionally, the domain             should be minimized as much as possible (for example, remove "www." prefix if unnecessary).<br/><br/>            For example, the WiX toolset regid is "wixtoolset.org".           </td>
        <td>Yes</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Tag Schema</a>
  </dd>
</dl>
