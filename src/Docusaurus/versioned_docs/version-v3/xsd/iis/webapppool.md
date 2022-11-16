---
title: WebAppPool Element (Iis Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>IIS6 Application Pool</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../component/">Component</a>, <a href="../fragment/">Fragment</a>, <a href="../module/">Module</a>, <a href="../product/">Product</a></dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Sequence (min: 1, max: 1)<ol><li><a href="../iis/recycletime" class="extension">RecycleTime</a> (min: 0, max: unbounded)</li></ol></dd>
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
        <td>Id of the AppPool.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>CpuAction</td>
        <td>Enumeration</td>
        <td>Action taken when CPU exceeds maximum CPU use (as defined with MaxCpuUsage and RefreshCpu).  This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>none</dfn></dt><dd></dd><dt class="enumerationValue"><dfn>shutdown</dfn></dt><dd></dd></dl></td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Identity</td>
        <td>Enumeration</td>
        <td>Identity you want the AppPool to run under (applicationPoolIdentity is only available on IIS7). Use the 'other' value in conjunction with the User attribute to specify non-standard user.  This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>networkService</dfn></dt><dd></dd><dt class="enumerationValue"><dfn>localService</dfn></dt><dd></dd><dt class="enumerationValue"><dfn>localSystem</dfn></dt><dd></dd><dt class="enumerationValue"><dfn>other</dfn></dt><dd></dd><dt class="enumerationValue"><dfn>applicationPoolIdentity</dfn></dt><dd></dd></dl></td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>IdleTimeout</td>
        <td>Integer</td>
        <td>Shutdown worker process after being idle for (time in minutes).</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ManagedPipelineMode</td>
        <td>String</td>
        <td>                 Specifies the request-processing mode that is used to process requests for managed content.  Only available on IIS7, ignored on IIS6.                 See <a href="http://www.iis.net/configreference/system.applicationhost/applicationpools/applicationpooldefaults" target="_blank" xmlns="http://schemas.microsoft.com/wix/IIsExtension">http://www.iis.net/ConfigReference/system.applicationHost/applicationPools/applicationPoolDefaults</a> for valid values.                 This attribute may be set via a formatted Property (e.g. [MyProperty]).               </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ManagedRuntimeVersion</td>
        <td>String</td>
        <td>                 Specifies the .NET Framework version to be used by the application pool.  Only available on IIS7, ignored on IIS6.                 See <a href="http://www.iis.net/configreference/system.applicationhost/applicationpools/applicationpooldefaults" target="_blank" xmlns="http://schemas.microsoft.com/wix/IIsExtension">http://www.iis.net/ConfigReference/system.applicationHost/applicationPools/applicationPoolDefaults</a> for valid values.                 This attribute may be set via a formatted Property (e.g. [MyProperty]).               </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>MaxCpuUsage</td>
        <td><a href="../iis/simple_type_percenttype">PercentType</a></td>
        <td>Maximum CPU usage (percent).</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>MaxWorkerProcesses</td>
        <td>Integer</td>
        <td>Maximum number of worker processes.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Name</td>
        <td>String</td>
        <td>Name of the AppPool to be shown in IIs.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>PrivateMemory</td>
        <td>Integer</td>
        <td>Specifies the amount of private memory (in KB) that a worker process can use before the worker process recycles. The maximum value supported for this attribute is 4,294,967 KB.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>QueueLimit</td>
        <td>Integer</td>
        <td>Limit the kernel request queue (number of requests).</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>RecycleMinutes</td>
        <td>Integer</td>
        <td>How often, in minutes, you want the AppPool to be recycled.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>RecycleRequests</td>
        <td>Integer</td>
        <td>How often, in requests, you want the AppPool to be recycled.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>RefreshCpu</td>
        <td>Integer</td>
        <td>Refresh CPU usage numbers (in minutes).</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>User</td>
        <td>String</td>
        <td>User account to run the AppPool as.  To use this, you must set the Identity attribute to 'other'.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>VirtualMemory</td>
        <td>Integer</td>
        <td>Specifies the amount of virtual memory (in KB) that a worker process can use before the worker process recycles. The maximum value supported for this attribute is 4,294,967 KB.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../iis">Iis Schema</a>
  </dd>
</dl>
