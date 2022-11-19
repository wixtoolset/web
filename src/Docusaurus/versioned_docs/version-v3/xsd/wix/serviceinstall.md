---
title: ServiceInstall Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>                 Adds services for parent Component.  Use the ServiceControl element to remove services.             </dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa371637.aspx" target="_blank">ServiceInstall Table</a>
  </dd>
  <dt>Parents</dt>
  <dd>
    <a href="../component/">Component</a>
  </dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../permissionex/">PermissionEx</a> (min: 0, max: unbounded): Configures the ACLs for this service.</li><li><a href="../serviceconfig/">ServiceConfig</a> (min: 0, max: unbounded)</li><li><a href="../serviceconfigfailureactions/">ServiceConfigFailureActions</a> (min: 0, max: unbounded)</li><li><a href="../servicedependency/">ServiceDependency</a> (min: 0, max: unbounded): Ordered list of dependencies when installing services.</li><li><span class="extension">Any Element (namespace='##other' processContents='Lax')                              Extensibility point in the WiX XML Schema.  Schema extensions can register additional                             elements at this point in the schema.                         </span><ul><li><a href="../../util/serviceconfig" class="extension">ServiceConfig</a></li><li><a href="../../http/urlreservation" class="extension">UrlReservation</a></li></ul></li></ul></dd>
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
        <td>Account</td>
        <td>String</td>
        <td>Fully qualified names must be used even for local accounts, e.g.: ".\LOCAL_ACCOUNT". Valid only when ServiceType is ownProcess.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Arguments</td>
        <td>String</td>
        <td>Contains any command line arguments or properties required to run the service.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Description</td>
        <td>String</td>
        <td>Sets the description of the service.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>DisplayName</td>
        <td>String</td>
        <td>This column is the localizable string that user interface programs use to identify the service.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>EraseDescription</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Determines whether the existing service description will be ignored. If 'yes', the service description will be null, even if the Description attribute is set.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ErrorControl</td>
        <td>Enumeration</td>
        <td>Determines what action should be taken on an error.  This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>ignore</dfn></dt><dd>                                     Logs the error and continues with the startup operation.                                 </dd><dt class="enumerationValue"><dfn>normal</dfn></dt><dd>                                     Logs the error, displays a message box and continues the startup operation.                                 </dd><dt class="enumerationValue"><dfn>critical</dfn></dt><dd>                                     Logs the error if it is possible and the system is restarted with the last configuration known to be good. If the last-known-good configuration is being started, the startup operation fails.                                 </dd></dl></td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Id</td>
        <td>String</td>
        <td>                     Unique identifier for this service configuration. This value will default to the Name attribute if not                     specified.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Interactive</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Whether or not the service interacts with the desktop.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>LoadOrderGroup</td>
        <td>String</td>
        <td>The load ordering group that this service should be a part of.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Name</td>
        <td>String</td>
        <td>This column is the string that gives the service name to install.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Password</td>
        <td>String</td>
        <td>The password for the account. Valid only when the account has a password.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Start</td>
        <td>Enumeration</td>
        <td>Determines when the service should be started. The Windows Installer does not support boot or system.  This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>auto</dfn></dt><dd>                                     The service will start during startup of the system.                                 </dd><dt class="enumerationValue"><dfn>demand</dfn></dt><dd>                                     The service will start when the service control manager calls the StartService function.                                 </dd><dt class="enumerationValue"><dfn>disabled</dfn></dt><dd>                                     The service can no longer be started.                                 </dd><dt class="enumerationValue"><dfn>boot</dfn></dt><dd>                                     The service is a device driver that will be started by the operating system boot loader. This value is not currently supported by the Windows Installer.                                 </dd><dt class="enumerationValue"><dfn>system</dfn></dt><dd>                                     The service is a device driver that will be started by the IoInitSystem function. This value is not currently supported by the Windows Installer.                                 </dd></dl></td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Type</td>
        <td>Enumeration</td>
        <td>The Windows Installer does not currently support kernelDriver or systemDriver.  This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>ownProcess</dfn></dt><dd>                                     A Win32 service that runs its own process.                                 </dd><dt class="enumerationValue"><dfn>shareProcess</dfn></dt><dd>                                     A Win32 service that shares a process.                                 </dd><dt class="enumerationValue"><dfn>kernelDriver</dfn></dt><dd>                                     A kernel driver service. This value is not currently supported by the Windows Installer.                                 </dd><dt class="enumerationValue"><dfn>systemDriver</dfn></dt><dd>                                     A file system driver service. This value is not currently supported by the Windows Installer.                                 </dd></dl></td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Vital</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>The overall install should fail if this service fails to install.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>Remarks</dt>
  <dd>The service executable installed will point to the KeyPath for the Component.                     Therefore, you must ensure that the correct executable is either the first child                     File element under this Component or explicitly mark the appropriate File element                     as KeyPath='yes'.</dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Wix Schema</a>
  </dd>
</dl>
