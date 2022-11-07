---
title: Class Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>COM Class registration for parent Component.</dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa367861.aspx" target="_blank">Class Table</a>, <a href="http://msdn.microsoft.com/library/aa370879.aspx" target="_blank">ProgId Table</a>, <a href="http://msdn.microsoft.com/library/aa371168.aspx" target="_blank">Registry Table</a>, <a href="http://msdn.microsoft.com/library/aa367566.aspx" target="_blank">AppId Table</a></dd>
  <dt>Parents</dt>
  <dd>
    <a href="../wix/appid">AppId</a>, <a href="../wix/component">Component</a>, <a href="../wix/file">File</a>, <a href="../wix/typelib">TypeLib</a></dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../wix/filetypemask">FileTypeMask</a> (min: 0, max: unbounded)</li><li><a href="../wix/interface">Interface</a> (min: 0, max: unbounded): These Interfaces will be registered with the parent Class and TypeLib (if present).</li><li><a href="../wix/progid">ProgId</a> (min: 0, max: unbounded): A ProgId associated with Class must be a child element of the Class element</li></ul></dd>
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
        <td><a href="../wix/simple_type_guid">Guid</a></td>
        <td>The Class identifier (CLSID) of a COM server.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Advertise</td>
        <td><a href="../wix/simple_type_yesnotype">YesNoType</a></td>
        <td>                     Set this value to "yes" in order to create a normal Class table row.  Set this value to                     "no" in order to generate Registry rows that perform similar registration (without the                     often problematic Windows Installer advertising behavior).                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>AppId</td>
        <td><a href="../wix/simple_type_guid">Guid</a></td>
        <td>                     This attribute is only allowed when a Class is advertised.  Using this attribute will reference an Application ID                     containing DCOM information for the associated application GUID.  The value must correspond to an AppId/@Id of an                     AppId element nested under a Fragment, Module, or Product element.  To associate an AppId with a non-advertised                     class, nest the class within a parent AppId element.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Argument</td>
        <td>String</td>
        <td>                     This column is optional only when the Context column is set to "LocalServer"                     or "LocalServer32" server context. The text is registered as the argument against                     the OLE server and is used by OLE for invoking the server.  Note that the resolution                     of properties in the Argument field is limited. A property formatted as [Property] in                     this field can only be resolved if the property already has the intended value when                     the component owning the class is installed.  For example, for the argument "[#MyDoc.doc]"                     to resolve to the correct value, the same process must be installing the file MyDoc.doc and the                     component that owns the class.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Context</td>
        <td>List</td>
        <td>                   The server context(s) for this COM server. This attribute is optional for VB6 libraries that are marked "PublicNotCreateable".                   Class elements marked Advertised must specify at least one server context. It is most common for there to be a single value                   for the Context attribute.                   This attribute's value should be a space-delimited list containg one or more of the following:<dl><dt class="enumerationValue"><dfn>LocalServer</dfn></dt><dd>                                             A 16-bit local server application.                                         </dd><dt class="enumerationValue"><dfn>LocalServer32</dfn></dt><dd>                                             A 32-bit local server application.                                         </dd><dt class="enumerationValue"><dfn>InprocServer</dfn></dt><dd>                                             A 16-bit in-process server DLL.                                         </dd><dt class="enumerationValue"><dfn>InprocServer32</dfn></dt><dd>                                             A 32-bit in-process server DLL.                                         </dd></dl></td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Control</td>
        <td><a href="../wix/simple_type_yesnotype">YesNoType</a></td>
        <td>                     Set this attribute's value to 'yes' to identify an object as an ActiveX Control.  The default value is 'no'.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Description</td>
        <td>String</td>
        <td>Localized description associated with the Class ID and Program ID.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ForeignServer</td>
        <td>String</td>
        <td>                   May only be specified if the value of the Advertise attribute is "no" and Server has not been specified. In addition, it may only                   be used when the Class element is directly under the Component element. The value can be                   that of an registry type (REG_SZ). This attribute should be used to specify foreign servers, such as mscoree.dll if needed.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Handler</td>
        <td>String</td>
        <td>                     The default inproc handler.  May be optionally provided only for Context = LocalServer or                     LocalServer32.  Value of "1" creates a 16-bit InprocHandler (appearing as the InprocHandler                     value).  Value of "2" creates a 32-bit InprocHandler (appearing as the InprocHandler32 value).                     Value of "3" creates 16-bit as well as 32-bit InprocHandlers.  A non-numeric value is treated                     as a system file that serves as the 32-bit InprocHandler (appearing as the InprocHandler32 value).                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Icon</td>
        <td>String</td>
        <td>                     The file providing the icon associated with this CLSID.  Reference to an Icon element                     (should match the Id attribute of an Icon element).  This is currently not supported if the                     value of the Advertise attribute is "no".                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>IconIndex</td>
        <td>Integer</td>
        <td>Icon index into the icon file.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Insertable</td>
        <td><a href="../wix/simple_type_yesnotype">YesNoType</a></td>
        <td>                     Specifies the CLSID may be insertable.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Programmable</td>
        <td><a href="../wix/simple_type_yesnotype">YesNoType</a></td>
        <td>                     Specifies the CLSID may be programmable.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>RelativePath</td>
        <td><a href="../wix/simple_type_yesnotype">YesNoType</a></td>
        <td>                     When the value is "yes", the bare file name can be used for COM servers. The installer                     registers the file name only instead of the complete path.  This enables the server in                     the current directory to take precedence and allows multiple copies of the same component.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>SafeForInitializing</td>
        <td><a href="../wix/simple_type_yesnotype">YesNoType</a></td>
        <td>                     May only be specified if the value of the Advertise attribute is "no".                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>SafeForScripting</td>
        <td><a href="../wix/simple_type_yesnotype">YesNoType</a></td>
        <td>                     May only be specified if the value of the Advertise attribute is "no".                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Server</td>
        <td>String</td>
        <td>                     May only be specified if the value of the Advertise attribute is "no" and the ForeignServer attribute is not specified.  File Id of the                     COM server file.  If this element is nested under a File element, this value defaults to                     the value of the parent File/@Id.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ShortPath</td>
        <td><a href="../wix/simple_type_yesnotype">YesNoType</a></td>
        <td>                         Specifies whether or not to use the short path for the COM server.  This can only apply when Advertise is set to 'no'.  The default is 'no' meaning that it will use the long file name for the COM server.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ThreadingModel</td>
        <td>Enumeration</td>
        <td>                     Threading model for the CLSID.                   This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>apartment</dfn></dt><dd></dd><dt class="enumerationValue"><dfn>free</dfn></dt><dd></dd><dt class="enumerationValue"><dfn>both</dfn></dt><dd></dd><dt class="enumerationValue"><dfn>neutral</dfn></dt><dd></dd><dt class="enumerationValue"><dfn>single</dfn></dt><dd></dd><dt class="enumerationValue"><dfn>rental</dfn></dt><dd></dd></dl></td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Version</td>
        <td>String</td>
        <td>                     Version for the CLSID.                 </td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>Remarks</dt>
  <dd>When being used in unadvertised mode, the attributes in the Class element correspond to registry keys                     as follows (values that can be specified in authoring are in bold):                     <dl><dt>Id/Context/Server</dt><dd><dl><dt>In General</dt><dd>                                     [HKCR\CLSID\{'{'}<b>Id</b>{'}'}\<b>Context1</b>]<br />                                     @="[!<b>Server</b>]"<br />                                     [HKCR\CLSID\{'{'}<b>Id</b>{'}'}\<b>Context2</b>]<br />                                     @="[!<b>Server</b>]"                                 </dd><dt>Specific Example</dt><dd>                                     [HKCR\CLSID\{'{'}<b>01234567-89AB-CDEF-0123-456789ABCDEF</b>{'}'}\<b>LocalServer</b>]<br />                                     @="[!<b>comserv.dll</b>]"<br />                                     [HKCR\CLSID\{'{'}<b>01234567-89AB-CDEF-0123-456789ABCDEF</b>{'}'}\<b>LocalServer32</b>]<br />                                     @="[!<b>comserv.dll</b>]"                                 </dd></dl></dd><dt>Id/Context/ForeignServer</dt><dd><dl><dt>In General</dt><dd>                                   [HKCR\CLSID\{'{'}<b>Id</b>{'}'}\<b>Context1</b>]<br />                                   @="<b>ForeignServer</b>"<br />                                   [HKCR\CLSID\{'{'}<b>Id</b>{'}'}\<b>Context2</b>]<br />                                   @="<b>ForeignServer</b>"                                 </dd><dt>Specific Example</dt><dd>                                   [HKCR\CLSID\{'{'}<b>01234567-89AB-CDEF-0123-456789ABCDEF</b>{'}'}\<b>LocalServer</b>]<br />                                   @="<b>mscoree.dll</b>"<br />                                   [HKCR\CLSID\{'{'}<b>01234567-89AB-CDEF-0123-456789ABCDEF</b>{'}'}\<b>LocalServer32</b>]<br />                                   @="<b>mscoree.dll</b>"                                 </dd></dl></dd><dt>AppId</dt><dd><dl><dt>In General</dt><dd>                                     [HKCR\CLSID\{'{'}<b>Id</b>{'}'}]<br />                                     AppId="{'{'}<b>AppId</b>{'}'}"                                 </dd><dt>Specific Example</dt><dd>                                     [HKCR\CLSID\{'{'}<b>01234567-89AB-CDEF-0123-456789ABCDEF</b>{'}'}]<br />                                     AppId="{'{'}<b>00000000-89AB-0000-0123-000000000000</b>{'}'}"                                 </dd></dl></dd><dt>Argument</dt><dd><dl><dt>In General</dt><dd>                                     [HKCR\CLSID\{'{'}<b>Id</b>{'}'}\<b>Context</b>]<br />                                     @="[!<b>Server</b>] <b>Argument</b>"                                 </dd><dt>Specific Example</dt><dd>                                     [HKCR\CLSID\{'{'}<b>01234567-89AB-CDEF-0123-456789ABCDEF</b>{'}'}\<b>LocalServer32</b>]<br />                                     @="[!<b>comserv.dll</b>] <b>/arg1 /arg2 /arg3</b>"<br /></dd></dl></dd><dt>Control</dt><dd><dl><dt>In General</dt><dd>                                     Value "yes" specified:<br />                                     [HKCR\CLSID\{'{'}<b>Id</b>{'}'}\Control]                                 </dd><dt>Specific Example</dt><dd>                                     [HKCR\CLSID\{'{'}<b>01234567-89AB-CDEF-0123-456789ABCDEF</b>{'}'}\Control]                                 </dd></dl></dd><dt>Description</dt><dd><dl><dt>In General</dt><dd>                                     [HKCR\CLSID\{'{'}<b>Id</b>{'}'}]<br />                                     @="<b>Description</b>"                                 </dd><dt>Specific Example</dt><dd>                                     [HKCR\CLSID\{'{'}<b>01234567-89AB-CDEF-0123-456789ABCDEF</b>{'}'}]<br />                                     @="<b>Description of Example COM Component</b>"                                 </dd></dl></dd><dt>Handler</dt><dd><dl><dt>In General</dt><dd>                                     Value "1" specified:<br />                                     [HKCR\CLSID\{'{'}<b>Id</b>{'}'}\InprocHandler]<br />                                     @="ole.dll"<br />                                     Value "2" specified:<br />                                     [HKCR\CLSID\{'{'}<b>Id</b>{'}'}\InprocHandler32]<br />                                     @="ole32.dll"<br />                                     Value "3" specified:<br />                                     [HKCR\CLSID\{'{'}<b>Id</b>{'}'}\InprocHandler]<br />                                     @="ole.dll"<br />                                     [HKCR\CLSID\{'{'}<b>Id</b>{'}'}\InprocHandler32]<br />                                     @="ole32.dll"<br />                                     Other value specified:<br />                                     [HKCR\CLSID\{'{'}<b>Id</b>{'}'}\InprocHandler32]<br />                                     @="<b>Handler</b>"                                 </dd><dt>Specific Example (for other value)</dt><dd>                                     [HKCR\CLSID\{'{'}<b>01234567-89AB-CDEF-0123-456789ABCDEF</b>{'}'}\InprocHandler32]<br />                                     @="<b>handler.dll</b>"                                 </dd></dl></dd><dt>Icon/IconIndex</dt><dd>This is not currently handled properly.</dd><dt>Insertable</dt><dd><dl><dt>In General</dt><dd>                                     Value "no" specified:<br />                                     [HKCR\CLSID\{'{'}<b>Id</b>{'}'}\NotInsertable]<br />                                     Value "yes" specified:<br />                                     [HKCR\CLSID\{'{'}<b>Id</b>{'}'}\Insertable]                                 </dd><dt>Specific Example</dt><dd>                                     [HKCR\CLSID\{'{'}<b>01234567-89AB-CDEF-0123-456789ABCDEF</b>{'}'}\Insertable]                                 </dd></dl></dd><dt>Programmable</dt><dd><dl><dt>In General</dt><dd>                                     Value "yes" specified:<br />                                     [HKCR\CLSID\{'{'}<b>Id</b>{'}'}\Programmable]                                 </dd><dt>Specific Example</dt><dd>                                     [HKCR\CLSID\{'{'}<b>01234567-89AB-CDEF-0123-456789ABCDEF</b>{'}'}\Programmable]                                 </dd></dl></dd><dt>RelativePath</dt><dd>Unsupported.  Please contribute this back to WiX if you know.</dd><dt>SafeForInitializing</dt><dd><dl><dt>In General</dt><dd>                                     Value "yes" specified:<br />                                     [HKCR\CLSID\{'{'}<b>Id</b>{'}'}\Implemented Categories\{'{'}7DD95802-9882-11CF-9FA9-00AA006C42C4{'}'}]                                 </dd><dt>Specific Example</dt><dd>                                     [HKCR\CLSID\{'{'}<b>01234567-89AB-CDEF-0123-456789ABCDEF</b>{'}'}\Implemented Categories\{'{'}7DD95802-9882-11CF-9FA9-00AA006C42C4{'}'}]                                 </dd></dl></dd><dt>SafeForScripting</dt><dd><dl><dt>In General</dt><dd>                                     Value "yes" specified:<br />                                     [HKCR\CLSID\{'{'}<b>Id</b>{'}'}\Implemented Categories\{'{'}7DD95801-9882-11CF-9FA9-00AA006C42C4{'}'}]                                 </dd><dt>Specific Example</dt><dd>                                     [HKCR\CLSID\{'{'}<b>01234567-89AB-CDEF-0123-456789ABCDEF</b>{'}'}\Implemented Categories\{'{'}7DD95801-9882-11CF-9FA9-00AA006C42C4{'}'}]                                 </dd></dl></dd><dt>ThreadingModel</dt><dd><dl><dt>In General</dt><dd>                                     [HKCR\CLSID\{'{'}<b>Id</b>{'}'}\<b>Context</b>]<br />                                     ThreadingModel="<b>ThreadingModel</b>"                                 </dd><dt>Specific Example</dt><dd>                                     [HKCR\CLSID\{'{'}<b>01234567-89AB-CDEF-0123-456789ABCDEF</b>{'}'}\<b>LocalServer32</b>]<br />                                     ThreadingModel="<b>Apartment</b>"                                 </dd></dl></dd><dt>TypeLibId (from parent TypeLib/@Id)</dt><dd><dl><dt>In General</dt><dd>                                     [HKCR\CLSID\{'{'}<b>Id</b>{'}'}\TypeLib]<br />                                     @="{'{'}<b>TypeLibId</b>{'}'}"                                 </dd><dt>Specific Example</dt><dd>                                     [HKCR\CLSID\{'{'}<b>01234567-89AB-CDEF-0123-456789ABCDEF</b>{'}'}\TypeLib]<br />                                     @="{'{'}<b>11111111-89AB-1111-0123-111111111111</b>{'}'}"                                 </dd></dl></dd><dt>Version</dt><dd><dl><dt>In General</dt><dd>                                     [HKCR\CLSID\{'{'}<b>Id</b>{'}'}\Version]<br />                                     @="<b>Version</b>"                                 </dd><dt>Specific Example</dt><dd>                                     [HKCR\CLSID\{'{'}<b>01234567-89AB-CDEF-0123-456789ABCDEF</b>{'}'}\Version]<br />                                     @="<b>1.0.0.0</b>"                                 </dd></dl></dd></dl></dd>  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>, <a href="../wix/appid">AppId</a></dd>
</dl>
