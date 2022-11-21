---
title: ServiceConfig Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>                 Configures a service being installed or one that already exists. This element's functionality is available starting with MSI 5.0.             </dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="https://learn.microsoft.com/en-us/windows/win32/msi/msiserviceconfig-table" target="_blank">MsiServiceConfig Table</a>
  </dd>
  <dt>Parents</dt>
  <dd>
    <a href="../component/">Component</a>, <a href="../serviceinstall/">ServiceInstall</a></dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../requiredprivilege/">RequiredPrivilege</a> (min: 0, max: unbounded): List of privileges to apply to service.</li></ul></dd>
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
        <td>DelayedAutoStart</td>
        <td>String</td>
        <td>                     This attribute specifies whether an auto-start service should delay its start until after all other auto-start                     services. This attribute only affects auto-start services. Allowed values are "yes", "no" or a Formatted property that                     resolves to "1" (for "yes") or "0" (for "no"). If this attribute is not present the setting is not configured.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>FailureActionsWhen</td>
        <td>String</td>
        <td>                     This attribute specifies when failure actions should be applied. Allowed values are "failedToStop", "failedToStopOrReturnedError"                     or a Formatted property that resolves to "1" (for "failedToStopOrReturnedError") or "0" (for "failedToStop").  If this attribute                     is not present the setting is not configured.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Id</td>
        <td>String</td>
        <td>                     Unique identifier for this service configuration. This value will default to the ServiceName attribute if not                     specified.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>OnInstall</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>                     Specifies whether to configure the service when the parent Component is installed. This attribute may be combined with OnReinstall                     and OnUninstall.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>OnReinstall</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>                     Specifies whether to configure the service when the parent Component is reinstalled. This attribute may be combined with OnInstall                     and OnUninstall.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>OnUninstall</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>                     Specifies whether to configure the service when the parent Component is uninstalled. This attribute may be combined with OnInstall                     and OnReinstall.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>PreShutdownDelay</td>
        <td>String</td>
        <td>                     This attribute specifies time in milliseconds that the Service Control Manager (SCM) waits after notifying the service of a system                     shutdown.  If this attribute is not present the default value, 3 minutes, is used.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ServiceName</td>
        <td>String</td>
        <td>                     Specifies the name of the service to configure. This value will default to the ServiceInstall/@Name attribute when nested under                     a ServiceInstall element.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ServiceSid</td>
        <td>String</td>
        <td>                     Specifies the service SID to apply to the service. Valid values are "none", "restricted", "unrestricted" or a Formatted property                     that resolves to "0" (for "none"), "3" (for "restricted") or "1" (for "unrestricted"). If this attribute is not present the                     setting is not configured.                 </td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>Remarks</dt>
  <dd><p>MsiServiceConfig functionality is documented in the Windows Installer SDK to "not [work] as expected." Consider using   the WixUtilExtension ServiceConfig instead.</p></dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Wix Schema</a>
  </dd>
</dl>
