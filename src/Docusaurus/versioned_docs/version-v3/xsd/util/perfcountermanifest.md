---
title: PerfCounterManifest Element (Util Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>         Used to install Perfmon Counter Manifests.         Note that this functionality cannot be used with major upgrades that are scheduled after the InstallExecute,         InstallExecuteAgain, or InstallFinalize actions. For more information on major upgrade scheduling, see         <a href="http://msdn.microsoft.com/en-us/library/aa371197.aspx">RemoveExistingProducts Action</a>.       </dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../file/">File</a>
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
        <td>ResourceFileDirectory</td>
        <td>String</td>
        <td>The directory that holds the resource file of the providers in the perfmon counter manifest. Often the resource file path cannot be determined until setup time. Put the directory here and during perfmon manifest registrtion the path will be updated in the registry. If not specified, Perfmon will look for the resource file in the same directory of the perfmon counter manifest file.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../util">Util Schema</a>
  </dd>
</dl>
