---
title: File Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>                 File specification for File table, must be child node of Component.             </dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa368596.aspx" target="_blank">File Table</a>
  </dd>
  <dt>Parents</dt>
  <dd>
    <a href="../component/">Component</a>
  </dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../appid/">AppId</a> (min: 0, max: unbounded)</li><li><a href="../assemblyname/">AssemblyName</a> (min: 0, max: unbounded)</li><li><a href="../class/">Class</a> (min: 0, max: unbounded)</li><li><a href="../copyfile/">CopyFile</a> (min: 0, max: unbounded): Used to create a duplicate of this file elsewhere.</li><li><a href="../odbcdriver/">ODBCDriver</a> (min: 0, max: unbounded)</li><li><a href="../odbctranslator/">ODBCTranslator</a> (min: 0, max: unbounded)</li><li><a href="../permission/">Permission</a> (min: 0, max: unbounded): Used to configure the ACLs for this file.</li><li><a href="../permissionex/">PermissionEx</a> (min: 0, max: unbounded): Can also configure the ACLs for this file.</li><li><a href="../shortcut/">Shortcut</a> (min: 0, max: unbounded): Target of the shortcut will be set to this file.</li><li><a href="../symbolpath/">SymbolPath</a> (min: 0, max: unbounded)</li><li><a href="../typelib/">TypeLib</a> (min: 0, max: unbounded)</li><li><span class="extension">Any Element (namespace='##other' processContents='Lax')                          Extensibility point in the WiX XML Schema.  Schema extensions can register additional                         elements at this point in the schema.                     </span><ul><li><a href="../../util/eventmanifest" class="extension">EventManifest</a></li><li><a href="../../firewall/firewallexception" class="extension">FirewallException</a></li><li><a href="../../ps/formatsfile" class="extension">FormatsFile</a></li><li><a href="../../gaming/game" class="extension">Game</a></li><li><a href="../../vs/helpcollection" class="extension">HelpCollection</a></li><li><a href="../../vs/helpfile" class="extension">HelpFile</a></li><li><a href="../../netfx/nativeimage" class="extension">NativeImage</a></li><li><a href="../../util/perfcounter" class="extension">PerfCounter</a></li><li><a href="../../util/perfcountermanifest" class="extension">PerfCounterManifest</a></li><li><a href="../../util/permissionex" class="extension">PermissionEx</a></li><li><a href="../../ps/snapin" class="extension">SnapIn</a></li><li><a href="../../ps/typesfile" class="extension">TypesFile</a></li><li><a href="../../vs/vsixpackage" class="extension">VsixPackage</a></li></ul></li></ul></dd>
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
        <td>Assembly</td>
        <td>Enumeration</td>
        <td>                         Specifies if this File is a Win32 Assembly or .NET Assembly that needs to be installed into the                         Global Assembly Cache (GAC).  If the value is '.net' or 'win32', this file must also be the key path of the Component.                       This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>.net</dfn></dt><dd>                                     The file is a .NET Framework assembly.                                 </dd><dt class="enumerationValue"><dfn>no</dfn></dt><dd>                                     The file is not a .NET Framework or Win32 assembly. This is the default value.                                 </dd><dt class="enumerationValue"><dfn>win32</dfn></dt><dd>                                     The file is a Win32 assembly.                                 </dd></dl></td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>AssemblyApplication</td>
        <td>String</td>
        <td>                         Specifies the file identifier of the application file.  This assembly will be isolated                         to the same directory as the application file.                         If this attribute is absent, the assembly will be installed to the Global Assembly Cache (GAC).                         This attribute may only be specified if the Assembly attribute is set to '.net' or 'win32'.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>AssemblyManifest</td>
        <td>String</td>
        <td>                         Specifies the file identifier of the manifest file that describes this assembly.                         The manifest file should be in the same component as the assembly it describes.                         This attribute may only be specified if the Assembly attribute is set to '.net' or 'win32'.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>BindPath</td>
        <td>String</td>
        <td>A list of paths, separated by semicolons, that represent the paths to be searched to find the imported DLLs. The list is usually a list of properties, with each property enclosed inside square brackets. The value may be set to an empty string. Including this attribute will cause an entry to be generated for the file in the BindImage table.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Checksum</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>This attribute should be set to "yes" for every executable file in the installation that has a valid checksum stored in the Portable Executable (PE) file header.  Only those files that have this attribute set will be verified for valid checksum during a reinstall.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>CompanionFile</td>
        <td>String</td>
        <td>Set this attribute to make this file a companion child of another file.  The installation                     state of a companion file depends not on its own file versioning information, but on the versioning of its                     companion parent.  A file that is the key path for its component can not be a companion file (that means                     this attribute cannot be set if KeyPath="yes" for this file).  The Version attribute cannot be set along                     with this attribute since companion files are not installed based on their own version.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Compressed</td>
        <td><a href="../simple_type_yesnodefaulttype/">YesNoDefaultType</a></td>
        <td>Sets the file's source type compression.  A setting of "yes" or "no" will override the setting in the Word Count Summary Property.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>DefaultLanguage</td>
        <td>String</td>
        <td>This is the default language of this file.  The linker will replace this value from the value in the file if the suppress files option is not used.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>DefaultSize</td>
        <td>Integer</td>
        <td>This is the default size of this file.  The linker will replace this value from the value in the file if the suppress files option is not used.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>DefaultVersion</td>
        <td>String</td>
        <td>This is the default version of this file.  The linker will replace this value from the value in the file if the suppress files option is not used.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>DiskId</td>
        <td><a href="../simple_type_diskidtype/">DiskIdType</a></td>
        <td>                     The value of this attribute should correspond to the Id attribute of a Media                     element authored elsewhere.  By creating this connection between a file and                     its media, you set the packaging options to the values specified in the Media                     element (values such as compression level, cab embedding, etc...). Specifying                     the DiskId attribute on the File element overrides the default DiskId attribute                     from the parent Component element. If no DiskId attribute is specified,                     the default is "1". This DiskId attribute is ignored when creating a merge module                     because merge modules do not have media.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>FontTitle</td>
        <td>String</td>
        <td>Causes an entry to be generated for the file in the Font table with the specified FontTitle. This attribute is intended to be used to register the file as a non-TrueType font.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Hidden</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Set to yes in order to have the file's hidden attribute set when it is installed on the target machine.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Id</td>
        <td>String</td>
        <td>                     The unique identifier for this File element. If you omit Id, it defaults to the file name portion of the Source attribute, if specified. May be referenced as a Property by specifying [#value].                   </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>KeyPath</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Set to yes in order to force this file to be the key path for the parent component.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>LongName</td>
        <td><a href="../simple_type_longfilenametype/">LongFileNameType</a></td>
        <td>This attribute has been deprecated; please use the Name attribute instead.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Name</td>
        <td><a href="../simple_type_longfilenametype/">LongFileNameType</a></td>
        <td>                         In prior versions of the WiX toolset, this attribute specified the short file name.                         This attribute's value may now be either a short or long file name.                         If a short file name is specified, the ShortName attribute may not be specified.                         If a long file name is specified, the LongName attribute may not be specified.                         Also, if this value is a long file name, the ShortName attribute may be omitted to                         allow WiX to attempt to generate a unique short file name.                         However, if this name collides with another file or you wish to manually specify                         the short file name, then the ShortName attribute may be specified.                         Finally, if this attribute is omitted then its default value is the file name portion                         of the Source attribute, if one is specified, or the value of the Id attribute, if                         the Source attribute is omitted or doesn't contain a file name.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>PatchAllowIgnoreOnError</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Set to indicate that the patch is non-vital.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>PatchGroup</td>
        <td>Integer</td>
        <td>                     This attribute must be set for patch-added files.  Each patch should be assigned a different patch group number.  Patch groups                     numbers must be greater 0 and should be assigned consecutively.  For example, the first patch should use PatchGroup='1', the                     second patch will have PatchGroup='2', etc...                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>PatchIgnore</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Prevents the updating of the file that is in fact changed in the upgraded image relative to the target images.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>PatchWholeFile</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Set if the entire file should be installed rather than creating a binary patch.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ProcessorArchitecture</td>
        <td>Enumeration</td>
        <td>Specifies the architecture for this assembly. This attribute should only be used on .NET Framework 2.0 or higher assemblies.  This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>msil</dfn></dt><dd>                                     The file is a .NET Framework assembly that is processor-neutral.                                 </dd><dt class="enumerationValue"><dfn>x86</dfn></dt><dd>                                     The file is a .NET Framework assembly for the x86 processor.                                 </dd><dt class="enumerationValue"><dfn>x64</dfn></dt><dd>                                     The file is a .NET Framework assembly for the x64 processor.                                 </dd><dt class="enumerationValue"><dfn>arm</dfn></dt><dd>                                     The file is a .NET Framework assembly for a 32-bit ARM processor.                                 </dd><dt class="enumerationValue"><dfn>arm64</dfn></dt><dd>                                     The file is a .NET Framework assembly for a 64-bit ARM processor.                                 </dd><dt class="enumerationValue"><dfn>ia64</dfn></dt><dd>                                     The file is a .NET Framework assembly for the ia64 processor.                                 </dd></dl></td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ReadOnly</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Set to yes in order to have the file's read-only attribute set when it is installed on the target machine.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>SelfRegCost</td>
        <td>Integer</td>
        <td>The cost of registering the file in bytes. This must be a non-negative number. Including this attribute will cause an entry to be generated for the file in the SelfReg table.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ShortName</td>
        <td><a href="../simple_type_shortfilenametype/">ShortFileNameType</a></td>
        <td>                         The short file name of the file in 8.3 format.                         This attribute should only be set if there is a conflict between generated short file names                         or the user wants to manually specify the short file name.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Source</td>
        <td>String</td>
        <td>Specifies the path to the File in the build process. Overrides default source path set by parent directories and Name attribute. This attribute must be set if no source information can be gathered from parent directories. For more information, see <a href="../../../howtos/general/specifying_source_files">Specifying source files</a>.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>src</td>
        <td>String</td>
        <td>This attribute has been deprecated; please use the Source attribute instead.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>System</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Set to yes in order to have the file's system attribute set when it is installed on the target machine.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>TrueType</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Causes an entry to be generated for the file in the Font table with no FontTitle specified. This attribute is intended to be used to register the file as a TrueType font.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Vital</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>If a file is vital, then installation cannot proceed unless the file is successfully installed.  The user will have no option to ignore an error installing this file.  If an error occurs, they can merely retry to install the file or abort the installation. The default is "yes," unless the -sfdvital switch (candle.exe) or SuppressFileDefaultVital property (.wixproj) is used.</td>
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
    <a href="../">Wix Schema</a>
  </dd>
</dl>
