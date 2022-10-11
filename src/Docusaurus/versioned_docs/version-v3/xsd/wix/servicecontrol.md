---
title: ServiceControl Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>                 Starts, stops, and removes services for parent Component. This element is used to control the state                 of a service installed by the MSI or MSM file by using the start, stop and remove attributes.                 For example, Start='install' Stop='both' Remove='uninstall' would mean: start the service on install,                 remove the service when the product is uninstalled, and stop the service both on install and uninstall.             </dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa371634.aspx" target="_blank">ServiceControl Table</a>
  </dd>
  <dt>Parents</dt>
  <dd>
    <a href="../wix/component">Component</a>
  </dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Sequence (min: 1, max: 1)<ol><li><a href="../wix/serviceargument">ServiceArgument</a> (min: 0, max: unbounded): Ordered list of arguments used when modifying services.</li></ol></dd>
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
        <td>Name</td>
        <td>String</td>
        <td>Name of the service.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Remove</td>
        <td><a href="../wix/simple_type_installuninstalltype">InstallUninstallType</a></td>
        <td>                     Specifies whether the service should be removed by the DeleteServices action on install, uninstall or both.                     For 'install', the service will be removed only when the parent component is being installed (msiInstallStateLocal or                     msiInstallStateSource); for 'uninstall', the service will be removed only when the parent component                     is being removed (msiInstallStateAbsent); for 'both', the service will be removed in both cases.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Start</td>
        <td><a href="../wix/simple_type_installuninstalltype">InstallUninstallType</a></td>
        <td>                     Specifies whether the service should be started by the StartServices action on install, uninstall or both.                     For 'install', the service will be started only when the parent component is being installed (msiInstallStateLocal or                     msiInstallStateSource); for 'uninstall', the service will be started only when the parent component                     is being removed (msiInstallStateAbsent); for 'both', the service will be started in both cases.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Stop</td>
        <td><a href="../wix/simple_type_installuninstalltype">InstallUninstallType</a></td>
        <td>                     Specifies whether the service should be stopped by the StopServices action on install, uninstall or both.                     For 'install', the service will be stopped only when the parent component is being installed (msiInstallStateLocal or                     msiInstallStateSource); for 'uninstall', the service will be stopped only when the parent component                     is being removed (msiInstallStateAbsent); for 'both', the service will be stopped in both cases.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Wait</td>
        <td><a href="../wix/simple_type_yesnotype">YesNoType</a></td>
        <td>Specifies whether or not to wait for the service to complete before continuing. The default is 'yes'.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>
  </dd>
</dl>
