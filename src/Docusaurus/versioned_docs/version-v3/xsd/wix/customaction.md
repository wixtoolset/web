---
title: CustomAction Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>                 Specifies a custom action to be added to the MSI CustomAction table. Various combinations of the attributes for this element                 correspond to different custom action types. For more information about custom actions see the                 <a href="http://msdn.microsoft.com/library/aa372048.aspx" target="_blank">                 Custom Action Types</a> topic on MSDN.             </dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa368062.aspx" target="_blank">CustomAction Table</a>
  </dd>
  <dt>Parents</dt>
  <dd>
    <a href="../fragment/">Fragment</a>, <a href="../module/">Module</a>, <a href="../product/">Product</a></dd>
  <dt>Inner Text (xs:string)</dt>
  <dd>                         The text node is only valid if the Script attribute is specified.  In that case, the text node contains the script to embed.                     </dd>
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
        <td>Id</td>
        <td>String</td>
        <td>                             The identifier of the custom action.                         </td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>BinaryKey</td>
        <td>String</td>
        <td>                                 This attribute is a reference to a Binary element with matching Id attribute.  That binary stream contains                                 the custom action for use during install.  The custom action will not be installed into a target directory.  This attribute is                                 typically used with the DllEntry attribute to specify the custom action DLL to use for a type 1 custom action, with the ExeCommand                                 attribute to specify a type 17 custom action that runs an embedded executable, or with the VBScriptCall or JScriptCall attributes                                 to specify a type 5 or 6 custom action.                             </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Directory</td>
        <td>String</td>
        <td>                                 This attribute specifies a reference to a Directory element with matching Id attribute containing a directory path.                                 This attribute is typically used with the ExeCommand attribute to specify the source executable for a type 34                                 custom action, or with the Value attribute to specify a formatted string to place in the specified Directory                                 table entry in a type 35 custom action.                             </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>DllEntry</td>
        <td>String</td>
        <td>                                 This attribute specifies the name of a function in a custom action to execute.                                 This attribute is used with the BinaryKey attribute to create a type 1 custom                                 action, or with the FileKey attribute to create a type 17 custom action.                             </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Error</td>
        <td>String</td>
        <td>                                 This attribute specifies an index in the MSI Error table to use as an error message for a                                 type 19 custom action that displays the error message and aborts a product's installation.                             </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ExeCommand</td>
        <td>String</td>
        <td>                                 This attribute specifies the command line parameters to supply to an externally                                 run executable. This attribute is typically used with the BinaryKey attribute for a type 2 custom action,                                 the FileKey attribute for a type 18 custom action, the Property attribute for a type 50 custom action,                                 or the Directory attribute for a type 34 custom action that specify the executable to run.                             </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Execute</td>
        <td>Enumeration</td>
        <td>                                 This attribute indicates the scheduling of the custom action.                               This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>commit</dfn></dt><dd>                                             Indicates that the custom action will run after successful completion of the installation script (at the end of the installation).                                         </dd><dt class="enumerationValue"><dfn>deferred</dfn></dt><dd>                                             Indicates that the custom action runs in-script (possibly with elevated privileges).                                         </dd><dt class="enumerationValue"><dfn>firstSequence</dfn></dt><dd>                                             Indicates that the custom action will only run in the first sequence that runs it.                                         </dd><dt class="enumerationValue"><dfn>immediate</dfn></dt><dd>                                             Indicates that the custom action will run during normal processing time with user privileges.  This is the default.                                         </dd><dt class="enumerationValue"><dfn>oncePerProcess</dfn></dt><dd>                                             Indicates that the custom action will only run in the first sequence that runs it in the same process.                                         </dd><dt class="enumerationValue"><dfn>rollback</dfn></dt><dd>                                             Indicates that a custom action will run in the rollback sequence when a failure                                             occurs during installation, usually to undo changes made by a deferred custom action.                                         </dd><dt class="enumerationValue"><dfn>secondSequence</dfn></dt><dd>                                             Indicates that a custom action should be run a second time if it was previously run in an earlier sequence.                                         </dd></dl></td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>FileKey</td>
        <td>String</td>
        <td>                                 This attribute specifies a reference to a File element with matching Id attribute that                                 will execute the custom action code in the file after the file is installed.  This                                 attribute is typically used with the ExeCommand attribute to specify a type 18 custom action                                 that runs an installed executable, with the DllEntry attribute to specify an installed custom                                 action DLL to use for a type 17 custom action, or with the VBScriptCall or JScriptCall                                 attributes to specify a type 21 or 22 custom action.                             </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>HideTarget</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Ensures the installer does not log the CustomActionData for the deferred custom action.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Impersonate</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>                                 This attribute specifies whether the Windows Installer, which executes as LocalSystem,                                 should impersonate the user context of the installing user when executing this custom action.                                 Typically the value should be 'yes', except when the custom action needs elevated privileges                                 to apply changes to the machine.                             </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>JScriptCall</td>
        <td>String</td>
        <td>                             This attribute specifies the name of the JScript function to execute in a script. The script must be                             provided in a Binary element identified by the BinaryKey attribute described above. In other words, this                             attribute must be specified in conjunction with the BinaryKey attribute.                         </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>PatchUninstall</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>                                 This attribute specifies that the Windows Installer, execute the custom action only when                                 a patch is being uninstalled.  These custom actions should also be conditioned using the                                 MSIPATCHREMOVE property to ensure proper down level (less than Windows Installer 4.5)                                 behavior.                             </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Property</td>
        <td>String</td>
        <td>                                 This attribute specifies a reference to a Property element with matching Id attribute that specifies the Property                                 to be used or updated on execution of this custom action. This attribute is                                 typically used with the Value attribute to create a type 51 custom action that parses                                 the text in Value and places it into the specified Property.  This attribute is also used with                                 the ExeCommand attribute to create a type 50 custom action that uses the value of the                                 given property to specify the path to the executable. Type 51 custom actions are often useful to                                 pass values to a deferred custom action.                                 See <a href="http://msdn.microsoft.com/library/aa370543.aspx" target="_blank">                                 http://msdn.microsoft.com/library/aa370543.aspx</a>                                 for more information.                             </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Return</td>
        <td>Enumeration</td>
        <td>                                 Set this attribute to set the return behavior of the custom action.                               This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>asyncNoWait</dfn></dt><dd>                                             Indicates that the custom action will run asyncronously and execution may continue after the installer terminates.                                         </dd><dt class="enumerationValue"><dfn>asyncWait</dfn></dt><dd>                                             Indicates that the custom action will run asynchronously but the installer will wait for the return code at sequence end.                                         </dd><dt class="enumerationValue"><dfn>check</dfn></dt><dd>                                             Indicates that the custom action will run synchronously and the return code will be checked for success.  This is the default.                                         </dd><dt class="enumerationValue"><dfn>ignore</dfn></dt><dd>                                             Indicates that the custom action will run synchronously and the return code will not be checked.                                         </dd></dl></td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Script</td>
        <td>Enumeration</td>
        <td>                             Creates a type 37 or 38 custom action.  The text of the element should contain the script to be embedded in the package.                           This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>jscript</dfn></dt><dd></dd><dt class="enumerationValue"><dfn>vbscript</dfn></dt><dd></dd></dl></td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>SuppressModularization</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>                                 Use to suppress modularization of this custom action name in merge modules.                                 This should only be necessary for table-driven custom actions because the                                 table name which they interact with cannot be modularized, so there can only                                 be one instance of the table.                             </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>TerminalServerAware</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>                                 This attribute specifies controls whether the custom action will impersonate the                                 installing user during per-machine installs on Terminal Server machines.                                 Deferred execution custom actions that do not specify this attribute, or explicitly set it 'no',                                 will run with no user impersonation on Terminal Server machines during                                 per-machine installations.  This attribute is only applicable when installing on the                                 Windows Server 2003 family.                             </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Value</td>
        <td>String</td>
        <td>                                 This attribute specifies a string value to use in the custom action. This attribute                                 must be used with the Property attribute to set the property as part of a                                 type 51 custom action or with the Directory attribute to set a directory path in that                                 table in a type 35 custom action. The value can be a literal value or derived from a                                 Property element using the <a href="http://msdn.microsoft.com/library/aa368609.aspx" target="_blank">Formatted</a>                                 syntax.                             </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>VBScriptCall</td>
        <td>String</td>
        <td>                             This attribute specifies the name of the VBScript Subroutine to execute in a script. The script must be                             provided in a Binary element identified by the BinaryKey attribute described above. In other words, this                             attribute must be specified in conjunction with the BinaryKey attribute.                         </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Win64</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>                                 Specifies that a script custom action targets a 64-bit platform. Valid only when used with                                 the Script, VBScriptCall, and JScriptCall attributes.           The default value is based on the platform set by the -arch switch to candle.exe           or the InstallerPlatform property in a .wixproj MSBuild project:            For x86 and ARM, the default value is 'no'.            For x64, ARM64, and IA64, the default value is 'yes'.               </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td colspan="4">
          <span class="extension">Any Attribute (namespace='##other' processContents='lax')                              Extensibility point in the WiX XML Schema.  Schema extensions can register additional                             attributes at this point in the schema.                         </span>
        </td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Wix Schema</a>, <a href="../custom/">Custom</a>, <a href="../customactionref/">CustomActionRef</a></dd>
</dl>
