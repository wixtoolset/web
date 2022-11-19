---
title: EventManifest Element (Util Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>Used to install Event Manifests.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../../wix/file/">File</a>
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
        <td>MessageFile</td>
        <td>String</td>
        <td>The message file (including path) of all the providers in the event manifest. Often the message file path cannot be determined until setup time. Put your MessageFile here and the messageFileName attribute of the all the providers in the manifest will be updated with the path before it is registered. </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ParameterFile</td>
        <td>String</td>
        <td>The parameter file (including path) of all the providers in the event manifest. Often the parameter file path cannot be determined until setup time. Put your ParameterFile here and the parameterFileName attribute of the all the providers in the manifest will be updated with the path before it is registered. </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ResourceFile</td>
        <td>String</td>
        <td>The resource file (including path) of all the providers in the event manifest. Often the resource file path cannot be determined until setup time. Put your ResourceFile here and the resourceFileName attribute of the all the providers in the manifest will be updated with the path before it is registered. </td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Util Schema</a>
  </dd>
</dl>
