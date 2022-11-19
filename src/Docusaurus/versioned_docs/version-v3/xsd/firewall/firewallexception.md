---
title: FirewallException Element (Firewall Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>                 Registers an exception for a program or a specific port and protocol in the Windows Firewall                 on Windows XP SP2, Windows Server 2003 SP1, and later. For more information about the Windows                 Firewall, see <a href="http://msdn.microsoft.com/en-us/library/aa364679.aspx">                 About Windows Firewall API</a>.             </dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../../wix/component/">Component</a>, <a href="../../wix/file/">File</a></dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../../firewall/remoteaddress" class="extension">RemoteAddress</a> (min: 0, max: unbounded)</li></ul></dd>
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
        <td>                         Unique ID of this firewall exception.                     </td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Description</td>
        <td>String</td>
        <td>                       Description for this firewall rule displayed in Windows Firewall manager in                        Windows Vista and later.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>File</td>
        <td>String</td>
        <td>                         Identifier of a file to be granted access to all incoming ports and                          protocols. If you use File, you cannot also use Program.<br/><br/>                        If you use File and also Port or Protocol in the same                          FirewallException element, the exception will fail to install on                          Windows XP and Windows Server 2003. IgnoreFailure="yes" can be used to                         ignore the resulting failure, but the exception will not be added.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>IgnoreFailure</td>
        <td><a href="../../firewall/simple_type_yesnotype">YesNoType</a></td>
        <td>                         If "yes," failures to register this firewall exception will be silently                          ignored. If "no" (the default), failures will cause rollback.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Name</td>
        <td>String</td>
        <td>                         Name of this firewall exception, visible to the user in the firewall                          control panel.                     </td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Port</td>
        <td>String</td>
        <td>                         Port to allow through the firewall for this exception. <br/><br/>                        If you use Port and also File or Program in the same                          FirewallException element, the exception will fail to install on                          Windows XP and Windows Server 2003. IgnoreFailure="yes" can be used to                         ignore the resulting failure, but the exception will not be added.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Profile</td>
        <td>Enumeration</td>
        <td>                   Profile type for this firewall exception. Default is "all".                   This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>domain</dfn></dt><dd></dd><dt class="enumerationValue"><dfn>private</dfn></dt><dd></dd><dt class="enumerationValue"><dfn>public</dfn></dt><dd></dd><dt class="enumerationValue"><dfn>all</dfn></dt><dd></dd></dl></td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Program</td>
        <td>String</td>
        <td>                         Path to a target program to be granted access to all incoming ports and                          protocols. Note that this is a formatted field, so you can use [#fileId]                          syntax to refer to a file being installed. If you use Program, you cannot                          also use File.<br/><br/>                        If you use Program and also Port or Protocol in the same                          FirewallException element, the exception will fail to install on                          Windows XP and Windows Server 2003. IgnoreFailure="yes" can be used to                         ignore the resulting failure, but the exception will not be added.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Protocol</td>
        <td>Enumeration</td>
        <td>                         IP protocol used for this firewall exception. If Port is defined,                          "tcp" is assumed if the protocol is not specified. <br/><br/>                        If you use Protocol and also File or Program in the same                          FirewallException element, the exception will fail to install on                          Windows XP and Windows Server 2003. IgnoreFailure="yes" can be used to                         ignore the resulting failure, but the exception will not be added.                       This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>tcp</dfn></dt><dd></dd><dt class="enumerationValue"><dfn>udp</dfn></dt><dd></dd></dl></td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Scope</td>
        <td>Enumeration</td>
        <td>                         The scope of this firewall exception, which indicates whether incoming                         connections can come from any computer including those on the Internet                         or only those on the local network subnet. To more precisely specify                         allowed remote address, specify a custom scope using RemoteAddress                          child elements.                       This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>any</dfn></dt><dd></dd><dt class="enumerationValue"><dfn>localSubnet</dfn></dt><dd></dd></dl></td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Firewall Schema</a>
  </dd>
</dl>
