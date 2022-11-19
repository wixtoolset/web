---
title: Component Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Component for parent Directory</dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa368007.aspx" target="_blank">Component Table</a>, <a href="http://msdn.microsoft.com/library/aa368014.aspx" target="_blank">Condition Table</a>, <a href="http://msdn.microsoft.com/library/aa368295.aspx" target="_blank">Directory Table</a></dd>
  <dt>Parents</dt>
  <dd>
    <a href="../componentgroup/">ComponentGroup</a>, <a href="../directory/">Directory</a>, <a href="../directoryref/">DirectoryRef</a>, <a href="../feature/">Feature</a>, <a href="../featuregroup/">FeatureGroup</a>, <a href="../featureref/">FeatureRef</a>, <a href="../fragment/">Fragment</a>, <a href="../module/">Module</a>, <a href="../product/">Product</a></dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../appid/">AppId</a> (min: 0, max: unbounded)</li><li><a href="../category/">Category</a> (min: 0, max: unbounded)</li><li><a href="../class/">Class</a> (min: 0, max: unbounded)</li><li><a href="../condition/">Condition</a> (min: 0, max: unbounded)</li><li><a href="../copyfile/">CopyFile</a> (min: 0, max: unbounded)</li><li><a href="../createfolder/">CreateFolder</a> (min: 0, max: unbounded)</li><li><a href="../environment/">Environment</a> (min: 0, max: unbounded)</li><li><a href="../extension/">Extension</a> (min: 0, max: unbounded)</li><li><a href="../file/">File</a> (min: 0, max: unbounded)</li><li><a href="../inifile/">IniFile</a> (min: 0, max: unbounded)</li><li><a href="../interface/">Interface</a> (min: 0, max: unbounded)</li><li><a href="../isolatecomponent/">IsolateComponent</a> (min: 0, max: unbounded)</li><li><a href="../odbcdatasource/">ODBCDataSource</a> (min: 0, max: unbounded)</li><li><a href="../odbcdriver/">ODBCDriver</a> (min: 0, max: unbounded)</li><li><a href="../odbctranslator/">ODBCTranslator</a> (min: 0, max: unbounded)</li><li><a href="../progid/">ProgId</a> (min: 0, max: unbounded)</li><li><a href="../registry/">Registry</a> (min: 0, max: unbounded)</li><li><a href="../registrykey/">RegistryKey</a> (min: 0, max: unbounded)</li><li><a href="../registryvalue/">RegistryValue</a> (min: 0, max: unbounded)</li><li><a href="../removefile/">RemoveFile</a> (min: 0, max: unbounded)</li><li><a href="../removefolder/">RemoveFolder</a> (min: 0, max: unbounded)</li><li><a href="../removeregistrykey/">RemoveRegistryKey</a> (min: 0, max: unbounded)</li><li><a href="../removeregistryvalue/">RemoveRegistryValue</a> (min: 0, max: unbounded)</li><li><a href="../reservecost/">ReserveCost</a> (min: 0, max: unbounded)</li><li><a href="../serviceconfig/">ServiceConfig</a> (min: 0, max: unbounded)</li><li><a href="../serviceconfigfailureactions/">ServiceConfigFailureActions</a> (min: 0, max: unbounded)</li><li><a href="../servicecontrol/">ServiceControl</a> (min: 0, max: unbounded)</li><li><a href="../serviceinstall/">ServiceInstall</a> (min: 0, max: unbounded)</li><li><a href="../shortcut/">Shortcut</a> (min: 0, max: unbounded)</li><li><a href="../symbolpath/">SymbolPath</a> (min: 0, max: unbounded)</li><li><a href="../typelib/">TypeLib</a> (min: 0, max: unbounded)</li><li><span class="extension">Any Element (namespace='##other' processContents='Lax')                          Extensibility point in the WiX XML Schema.  Schema extensions can register additional                         elements at this point in the schema.                     </span><ul><li><a href="../../iis/certificate" class="extension">Certificate</a></li><li><a href="../../complus/complusapplication" class="extension">ComPlusApplication</a></li><li><a href="../../complus/complusapplicationrole" class="extension">ComPlusApplicationRole</a></li><li><a href="../../complus/complusassembly" class="extension">ComPlusAssembly</a></li><li><a href="../../complus/complusgroupinapplicationrole" class="extension">ComPlusGroupInApplicationRole</a></li><li><a href="../../complus/complusgroupinpartitionrole" class="extension">ComPlusGroupInPartitionRole</a></li><li><a href="../../complus/compluspartition" class="extension">ComPlusPartition</a></li><li><a href="../../complus/compluspartitionrole" class="extension">ComPlusPartitionRole</a></li><li><a href="../../complus/compluspartitionuser" class="extension">ComPlusPartitionUser</a></li><li><a href="../../complus/complusroleforcomponent" class="extension">ComPlusRoleForComponent</a></li><li><a href="../../complus/complusroleforinterface" class="extension">ComPlusRoleForInterface</a></li><li><a href="../../complus/complusroleformethod" class="extension">ComPlusRoleForMethod</a></li><li><a href="../../complus/complussubscription" class="extension">ComPlusSubscription</a></li><li><a href="../../complus/complususerinapplicationrole" class="extension">ComPlusUserInApplicationRole</a></li><li><a href="../../complus/complususerinpartitionrole" class="extension">ComPlusUserInPartitionRole</a></li><li><a href="../../difxapp/driver" class="extension">Driver</a></li><li><a href="../../util/eventsource" class="extension">EventSource</a></li><li><a href="../../util/fileshare" class="extension">FileShare</a></li><li><a href="../../firewall/firewallexception" class="extension">FirewallException</a></li><li><a href="../../util/internetshortcut" class="extension">InternetShortcut</a></li><li><a href="../../msmq/messagequeue" class="extension">MessageQueue</a></li><li><a href="../../msmq/messagequeuepermission" class="extension">MessageQueuePermission</a></li><li><a href="../../util/performancecategory" class="extension">PerformanceCategory</a></li><li><a href="../../dependency/provides" class="extension">Provides</a></li><li><a href="../../util/removefolderex" class="extension">RemoveFolderEx</a></li><li><a href="../../util/restartresource" class="extension">RestartResource</a></li><li><a href="../../util/serviceconfig" class="extension">ServiceConfig</a></li><li><a href="../../sql/sqldatabase" class="extension">SqlDatabase</a></li><li><a href="../../sql/sqlscript" class="extension">SqlScript</a></li><li><a href="../../sql/sqlstring" class="extension">SqlString</a></li><li><a href="../../http/urlreservation" class="extension">UrlReservation</a></li><li><a href="../../util/user" class="extension">User</a></li><li><a href="../../vs/vsixpackage" class="extension">VsixPackage</a></li><li><a href="../../iis/webapppool" class="extension">WebAppPool</a></li><li><a href="../../iis/webdir" class="extension">WebDir</a></li><li><a href="../../iis/webfilter" class="extension">WebFilter</a></li><li><a href="../../iis/webproperty" class="extension">WebProperty</a></li><li><a href="../../iis/webserviceextension" class="extension">WebServiceExtension</a></li><li><a href="../../iis/website" class="extension">WebSite</a></li><li><a href="../../iis/webvirtualdir" class="extension">WebVirtualDir</a></li><li><a href="../../util/xmlconfig" class="extension">XmlConfig</a></li><li><a href="../../util/xmlfile" class="extension">XmlFile</a></li></ul></li></ul></dd>
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
        <td>ComPlusFlags</td>
        <td>Integer</td>
        <td>                         Set this attribute to create a ComPlus entry.  The value should be the export flags used                         during the generation of the .msi file.  For more information see the COM+ documentation                         in the Platform SDK.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Directory</td>
        <td>String</td>
        <td>                         Sets the Directory of the Component.  If this element is nested under a Directory element,                         this value defaults to the value of the parent Directory/@Id.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>DisableRegistryReflection</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>                         Set this attribute to 'yes' in order to disable registry reflection on all existing and                         new registry keys affected by this component.                         When set to 'yes', the Windows Installer calls the RegDisableReflectionKey on each key                         being accessed by the component.                         This bit is available with Windows Installer version 4.0 and is ignored on 32-bit systems.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>DiskId</td>
        <td><a href="../simple_type_diskidtype/">DiskIdType</a></td>
        <td>                         This attribute provides a default DiskId attribute for all child File elements. Specifying                         the DiskId on a Component element will override any DiskId attributes set by parent Directory                         or DirectoryRef elements. See the File element's DiskId attribute for more information about                         the purpose of the DiskId.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Feature</td>
        <td>String</td>
        <td>                         Identifies a feature to which this component belongs, as a shorthand for a child                         ComponentRef element of the Feature element. The value of this attribute should                         correspond to the Id attribute of a Feature element authored elsewhere. Note that                         a single component can belong to multiple features but this attribute allows you                         to specify only a single feature.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Guid</td>
        <td><a href="../simple_type_componentguid/">ComponentGuid</a></td>
        <td>                         This value should be a guid that uniquely identifies this component's contents, language, platform, and version.                         If omitted, the default value is '*' which indicates that the linker should generate a stable guid.                         Generatable guids are supported only for components with a single file as the component's keypath                         or no files and a registry value as the keypath.                         It's also possible to set the value to an empty string to specify an unmanaged component.                         Unmanaged components are a security vulnerability because the component cannot be removed or repaired                         by Windows Installer (it is essentially an unpatchable, permanent component).  Therefore, a guid should                         always be specified for any component which contains resources that may need to be patched in the future.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Id</td>
        <td>String</td>
        <td>                         Component identifier; this is the primary key for identifying components. If omitted,                         the compiler defaults the identifier to the identifier of the resource that is the                         explicit keypath of the component (for example, a child File element with KeyPath                         attribute with value 'yes'.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>KeyPath</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>                         If this attribute's value is set to 'yes', then the Directory of this Component is used                         as the KeyPath. To set a Registry value or File as the KeyPath of a component, set the                         KeyPath attribute to 'yes' on one of those child elements. If KeyPath is not set to 'yes' for the                         Component or for a child Registry value or File, WiX will look at the child elements under the                         Component in sequential order and try to automatically select one of them as a key path. Allowing                         WiX to automatically select a key path can be dangerous because adding or removing child elements                         under the Component can inadvertantly cause the key path to change, which can lead to                         installation problems.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Location</td>
        <td>Enumeration</td>
        <td>                         Optional value that specifies the location that the component can be run from.                       This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>local</dfn></dt><dd>                                     Prevents the component from running from the source or the network (this is the default behavior if this attribute is not set).                                 </dd><dt class="enumerationValue"><dfn>source</dfn></dt><dd>                                     Enforces that the component can only be run from the source (it cannot be run from the user's computer).                                 </dd><dt class="enumerationValue"><dfn>either</dfn></dt><dd>                                     Allows the component to run from source or locally.                                 </dd></dl></td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>MultiInstance</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>                         If this attribute is set to 'yes', a new Component/@Guid will be generated for each                         instance transform. Ensure that all of the resources contained in a multi-instance                         Component will be installed to different paths based on the instance Property; otherwise,                         the Component Rules will be violated.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>NeverOverwrite</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>                         If this attribute is set to 'yes', the installer does not install or reinstall the                         component if a key path file or a key path registry entry for the component already                         exists.  The application does register itself as a client of the component.  Use this                         flag only for components that are being registered by the Registry table.  Do not use                         this flag for components registered by the AppId, Class, Extension, ProgId, MIME, and                         Verb tables.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Permanent</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>                         If this attribute is set to 'yes', the installer does not remove the component during                         an uninstall. The installer registers an extra system client for the component in                         the Windows Installer registry settings (which basically just means that at least one                         product is always referencing this component).  Note that this option differs from the                         behavior of not setting a guid because although the component is permanent, it is still                         patchable (because Windows Installer still tracks it), it's just not uninstallable.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Shared</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>                         If this attribute's value is set to 'yes', enables advanced patching semantics for                         Components that are shared across multiple Products.  Specifically, the Windows Installer                         will cache the shared files to improve patch uninstall.  This functionality is available                         in Windows Installer 4.5 and later.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>SharedDllRefCount</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>                         If this attribute's value is set to 'yes', the installer increments the reference count                         in the shared DLL registry of the component's key file.  If this bit is not set, the                         installer increments the reference count only if the reference count already exists.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Transitive</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>                         If this attribute is set to 'yes', the installer reevaluates the value of the statement                         in the Condition upon a reinstall.  If the value was previously False and has changed to                         True, the installer installs the component.  If the value was previously True and has                         changed to False, the installer removes the component even if the component has other                         products as clients.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>UninstallWhenSuperseded</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>                         If this attribute is set to 'yes', the installer will uninstall the Component's files                         and registry keys when it is superseded by a patch.  This functionality is available in                         Windows Installer 4.5 and later.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Win64</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>                         Set this attribute to 'yes' to mark this as a 64-bit component. This attribute facilitates                         the installation of packages that include both 32-bit and 64-bit components.  If this is a 64-bit                         component replacing a 32-bit component, set this attribute to 'yes' and assign a new GUID in the Guid attribute.           The default value is based on the platform set by the -arch switch to candle.exe           or the InstallerPlatform property in a .wixproj MSBuild project:            For x86 and ARM, the default value is 'no'.            For x64, ARM64, and IA64, the default value is 'yes'.           </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td colspan="4">
          <span class="extension">Any Attribute (namespace='##other' processContents='lax')                      Extensibility point in the WiX XML Schema.  Schema extensions can register additional                     attributes at this point in the schema.                 </span>
        </td>
      </tr>
    </table>
  </dd>
  <dt>How Tos and Examples</dt>
  <dd>
    <ul>
      <li>
        <a href="../../../howtos/files_and_registry/add_a_file">How To: Add a file to your installer</a>
      </li>
    </ul>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Wix Schema</a>, <a href="../componentref/">ComponentRef</a>, <a href="../media/">Media</a></dd>
</dl>
