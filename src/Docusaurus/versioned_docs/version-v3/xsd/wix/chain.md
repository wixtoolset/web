---
title: Chain Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Contains the chain of packages to install.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../bundle/">Bundle</a>
  </dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../exepackage/">ExePackage</a> (min: 0, max: unbounded)</li><li><a href="../msipackage/">MsiPackage</a> (min: 0, max: unbounded)</li><li><a href="../msppackage/">MspPackage</a> (min: 0, max: unbounded)</li><li><a href="../msupackage/">MsuPackage</a> (min: 0, max: unbounded)</li><li><a href="../packagegroupref/">PackageGroupRef</a> (min: 0, max: unbounded)</li><li><a href="../rollbackboundary/">RollbackBoundary</a> (min: 0, max: unbounded)</li></ul></dd>
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
        <td>DisableRollback</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>             Specifies whether the bundle will attempt to rollback packages             executed in the chain. If "yes" is specified then when a vital             package fails to install only that package will rollback and the             chain will stop with the error. The default is "no" which             indicates all packages executed during the chain will be             rolledback to their previous state when a vital package fails.           </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>DisableSystemRestore</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>             Specifies whether the bundle will attempt to create a system             restore point when executing the chain. If "yes" is specified then             a system restore point will not be created. The default is "no" which             indicates a system restore point will be created when the bundle is             installed, uninstalled, repaired, modified, etc. If the system restore             point cannot be created, the bundle will log the issue and continue.           </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ParallelCache</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>             Specifies whether the bundle will start installing packages             while other packages are still being cached. If "yes",             packages will start executing when a rollback boundary is             encountered. The default is "no" which dictates all packages             must be cached before any packages will start to be installed.           </td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>
  </dd>
</dl>
