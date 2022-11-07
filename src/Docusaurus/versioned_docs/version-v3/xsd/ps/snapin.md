---
title: SnapIn Element (Ps Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>         Identifies the parent File as a PowerShell snap-in to be registered on the system.       </dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../wix/file">File</a>
  </dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../ps/formatsfile" class="extension">FormatsFile</a> (min: 0, max: unbounded)</li><li><a href="../ps/typesfile" class="extension">TypesFile</a> (min: 0, max: unbounded)</li></ul></dd>
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
        <td>             The identifier for this PowerShell snap-in.           </td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>AssemblyName</td>
        <td>String</td>
        <td>This attribute has been deprecated.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>CustomSnapInType</td>
        <td>String</td>
        <td>             The full type name of a class that is used to register a list of cmdlets and providers.           </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Description</td>
        <td>String</td>
        <td>             A brief description of the snap-in.           </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>DescriptionIndirect</td>
        <td><a href="../ps/simple_type_embeddedresource">EmbeddedResource</a></td>
        <td>             An embedded resource that contains a brief description of the snap-in.             This resource must be embedded in the current snap-in assembly.           </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>RequiredPowerShellVersion</td>
        <td><a href="../ps/simple_type_versiontype">VersionType</a></td>
        <td>             The required version of PowerShell that must be installed and is associated with the             snap-in registration. The default value is "1.0".           </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Vendor</td>
        <td>String</td>
        <td>             The name of the snap-in vendor.           </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>VendorIndirect</td>
        <td><a href="../ps/simple_type_embeddedresource">EmbeddedResource</a></td>
        <td>             An embedded resource that contains the name of the snap-in vendor.             This resource must be embedded in the current snap-in assembly.           </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Version</td>
        <td><a href="../ps/simple_type_versiontype">VersionType</a></td>
        <td>             The version of the snapin. If not specified, this is taken from the assembly name.           </td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>Remarks</dt>
  <dd><a href="http://www.microsoft.com/powershell">PowerShell</a> snap-ins           allow developers to extend the functionality of of the PowerShell engine.           Add this element to identify the parent File as a PowerShell snap-in that will           get registered on the system.</dd>
  <dt>See Also</dt>
  <dd>
    <a href="../ps">Ps Schema</a>
  </dd>
</dl>
