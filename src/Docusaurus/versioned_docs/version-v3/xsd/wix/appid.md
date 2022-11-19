---
title: AppId Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>                 Application ID containing DCOM information for the associated application GUID.                 If this element is nested under a Fragment, Module, or Product element, it must be                 advertised.             </dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa367566.aspx" target="_blank">AppId Table</a>, <a href="http://msdn.microsoft.com/library/aa371168.aspx" target="_blank">Registry Table</a></dd>
  <dt>Parents</dt>
  <dd>
    <a href="../component/">Component</a>, <a href="../file/">File</a>, <a href="../fragment/">Fragment</a>, <a href="../module/">Module</a>, <a href="../product/">Product</a>, <a href="../typelib/">TypeLib</a></dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../class/">Class</a> (min: 0, max: unbounded)</li></ul></dd>
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
        <td><a href="../simple_type_guid/">Guid</a></td>
        <td>                     Set this value to the AppID GUID that corresponds to the named executable.                 </td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>ActivateAtStorage</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>                     Set this value to 'yes' to configure the client to activate on the same system as persistent storage.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Advertise</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>                     Set this value to 'yes' in order to create a normal AppId table row.  Set this value to 'no' in order to                     generate Registry rows that perform similar registration (without the often problematic Windows Installer                     advertising behavior).                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Description</td>
        <td>String</td>
        <td>                     Set this value to the description of the AppId.  It can only be specified when the AppId is not being advertised.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>DllSurrogate</td>
        <td>String</td>
        <td>                     Set this value to specify that the class is a DLL that is to be activated in a surrogate EXE                     process, and the surrogate process to be used is the path of a surrogate EXE file specified by the value.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>LocalService</td>
        <td>String</td>
        <td>                     Set this value to the name of a service to allow the object to be installed as a Win32 service.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>RemoteServerName</td>
        <td>String</td>
        <td>                     Set this value to the name of the remote server to configure the client to request the object                     be run at a particular machine whenever an activation function is called for which a COSERVERINFO                     structure is not specified.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>RunAsInteractiveUser</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>                     Set this value to 'yes' to configure a class to run under the identity of the user currently                     logged on and connected to the interactive desktop when activated by a remote client without                     being written as a Win32 service.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ServiceParameters</td>
        <td>String</td>
        <td>                     Set this value to the parameters to be passed to a LocalService on invocation.                 </td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>Remarks</dt>
  <dd>When being used in unadvertised mode, the attributes in the AppId element correspond to registry keys                     as follows (values that can be specified in authoring are in bold):                     <dl><dt>Id</dt><dd><dl><dt>In General</dt><dd>                                     [HKCR\AppID\{<b>Id</b>}]<br /></dd><dt>Specific Example</dt><dd>                                     [HKCR\AppID\{<b>01234567-89AB-CDEF-0123-456789ABCDEF</b>}]<br /></dd></dl></dd><dt>ActivateAtStorage</dt><dd><dl><dt>In General</dt><dd>                                     [HKCR\AppID\{<b>Id</b>}]<br />                                     ActivateAtStorage="<b>ActivateAtStorage</b>"                                 </dd><dt>Specific Example</dt><dd>                                     [HKCR\AppID\{<b>01234567-89AB-CDEF-0123-456789ABCDEF</b>}]<br />                                     ActivateAtStorage="<b>Y</b>"                                 </dd></dl></dd><dt>Description</dt><dd><dl><dt>In General</dt><dd>                                     [HKCR\AppID\{<b>Id</b>}]<br />                                     @="<b>Description</b>"                                 </dd><dt>Specific Example</dt><dd>                                     [HKCR\AppID\{<b>01234567-89AB-CDEF-0123-456789ABCDEF</b>}]<br />                                     @="<b>My AppId Description</b>"                                 </dd></dl></dd><dt>DllSurrogate</dt><dd><dl><dt>In General</dt><dd>                                     [HKCR\AppID\{<b>Id</b>}]<br />                                     DllSurrogate="<b>DllSurrogate</b>"                                 </dd><dt>Specific Example</dt><dd>                                     [HKCR\AppID\{<b>01234567-89AB-CDEF-0123-456789ABCDEF</b>}]<br />                                     DllSurrogate="<b>C:\surrogate.exe</b>"                                 </dd></dl></dd><dt>LocalService</dt><dd><dl><dt>In General</dt><dd>                                     [HKCR\AppID\{<b>Id</b>}]<br />                                     LocalService="<b>LocalService</b>"                                 </dd><dt>Specific Example</dt><dd>                                     [HKCR\AppID\{<b>01234567-89AB-CDEF-0123-456789ABCDEF</b>}]<br />                                     LocalService="<b>MyServiceName</b>"                                 </dd></dl></dd><dt>RemoteServerName</dt><dd><dl><dt>In General</dt><dd>                                     [HKCR\AppID\{<b>Id</b>}]<br />                                     RemoteServerName="<b>RemoteServerName</b>"                                 </dd><dt>Specific Example</dt><dd>                                     [HKCR\AppID\{<b>01234567-89AB-CDEF-0123-456789ABCDEF</b>}]<br />                                     RemoteServerName="<b>MyRemoteServer</b>"                                 </dd></dl></dd><dt>RunAsInteractiveUser</dt><dd><dl><dt>In General</dt><dd>                                     [HKCR\AppID\{<b>Id</b>}]<br />                                     RunAs="<b>RunAsInteractiveUser</b>"                                 </dd><dt>Specific Example</dt><dd>                                     [HKCR\AppID\{<b>01234567-89AB-CDEF-0123-456789ABCDEF</b>}]<br />                                     RunAs="<b>Interactive User</b>"                                 </dd></dl></dd><dt>ServiceParameters</dt><dd><dl><dt>In General</dt><dd>                                     [HKCR\AppID\{<b>Id</b>}]<br />                                     ServiceParameters="<b>ServiceParameters</b>"                                 </dd><dt>Specific Example</dt><dd>                                     [HKCR\AppID\{<b>01234567-89AB-CDEF-0123-456789ABCDEF</b>}]<br />                                     ServiceParameters="<b>-param</b>"                                 </dd></dl></dd></dl></dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Wix Schema</a>
  </dd>
</dl>
