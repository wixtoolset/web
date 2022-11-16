---
title: Directory Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Directory layout for the product.  Also specifies the mappings between source and target directories.</dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa368295.aspx" target="_blank">Directory Table</a>
  </dd>
  <dt>Parents</dt>
  <dd>
    <a href="../directory/">Directory</a>, <a href="../directoryref/">DirectoryRef</a>, <a href="../fragment/">Fragment</a>, <a href="../module/">Module</a>, <a href="../product/">Product</a></dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../component/">Component</a> (min: 0, max: unbounded)</li><li><a href="../directory/">Directory</a> (min: 0, max: unbounded)</li><li><a href="../merge/">Merge</a> (min: 0, max: unbounded)</li><li><a href="../symbolpath/">SymbolPath</a> (min: 0, max: unbounded)</li><li><span class="extension">Any Element (namespace='##other' processContents='Lax')                          Extensibility point in the WiX XML Schema.  Schema extensions can register additional                         elements at this point in the schema.                     </span></li></ul></dd>
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
        <td>This value is the unique identifier of the directory entry.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>ComponentGuidGenerationSeed</td>
        <td><a href="../simple_type_guid/">Guid</a></td>
        <td>                         The Component Guid Generation Seed is a guid that must be used when a Component with the generate guid directive ("*")                         is not rooted in a standard Windows Installer directory (for example, ProgramFilesFolder or CommonFilesFolder).                         It is recommended that this attribute be avoided and that developers install their Components under standard                         directories with unique names instead (for example, "ProgramFilesFolder\Company Name Product Name Version"). It is                         important to note that once a directory is assigned a Component Guid Generation Seed the value must not change until                         (and must be changed when) the path to that directory, including itself and all parent directories, changes.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>DiskId</td>
        <td><a href="../simple_type_diskidtype/">DiskIdType</a></td>
        <td>                         Sets the default disk identifier for the files contained in this directory.                         This attribute's value may be overridden by a child Component, Directory,                         Merge or File element. See the File or Merge elements' DiskId attribute for                         more information.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>FileSource</td>
        <td>String</td>
        <td>Used to set the file system source for this directory's child elements. For more information, see <a href="../../howtos/general/specifying_source_files">Specifying source files</a>.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>LongName</td>
        <td><a href="../simple_type_longfilenametype/">LongFileNameType</a></td>
        <td>This attribute has been deprecated; please use the Name attribute instead.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>LongSource</td>
        <td><a href="../simple_type_longfilenametype/">LongFileNameType</a></td>
        <td>This attribute has been deprecated; please use the SourceName attribute instead.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Name</td>
        <td><a href="../simple_type_longfilenametype/">LongFileNameType</a></td>
        <td>                         The name of the directory.<br/><br/>                        Do not specify this attribute (or the LongName attribute) if this directory represents                         the same directory as the parent (see the Windows Installer SDK's                         <a href="http://msdn.microsoft.com/library/Aa368295.aspx" target="_blank">Directory table</a>                         topic for more information about the "." operator).<br/><br/>                        In prior versions of the WiX toolset, this attribute specified the short directory name.                         This attribute's value may now be either a short or long directory name.                         If a short directory name is specified, the ShortName attribute may not be specified.                         If a long directory name is specified, the LongName attribute may not be specified.                         Also, if this value is a long directory name, the ShortName attribute may be omitted to                         allow WiX to attempt to generate a unique short directory name.                         However, if this name collides with another directory or you wish to manually specify                         the short directory name, then the ShortName attribute may be specified.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ShortName</td>
        <td><a href="../simple_type_shortfilenametype/">ShortFileNameType</a></td>
        <td>                         The short name of the directory in 8.3 format.                         This attribute should only be set if there is a conflict between generated short directory names                         or the user wants to manually specify the short directory name.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ShortSourceName</td>
        <td><a href="../simple_type_shortfilenametype/">ShortFileNameType</a></td>
        <td>                         The short name of the directory on the source media in 8.3 format.                         This attribute should only be set if there is a conflict between generated short directory names                         or the user wants to manually specify the short source directory name.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>SourceName</td>
        <td><a href="../simple_type_longfilenametype/">LongFileNameType</a></td>
        <td>                         The name of the directory on the source media.                         If this attribute is not specified, Windows Installer will default to the Name attribute.<br/><br/>                        In prior versions of the WiX toolset, this attribute specified the short source directory name.                         This attribute's value may now be either a short or long directory name.                         If a short directory name is specified, the ShortSourceName attribute may not be specified.                         If a long directory name is specified, the LongSource attribute may not be specified.                         Also, if this value is a long directory name, the ShortSourceName attribute may be omitted to                         allow WiX to attempt to generate a unique short directory name.                         However, if this name collides with another directory or you wish to manually specify                         the short directory name, then the ShortSourceName attribute may be specified.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>src</td>
        <td>String</td>
        <td>This attribute has been deprecated; please use the FileSource attribute instead.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td colspan="4">
          <span class="extension">Any Attribute (namespace='##other' processContents='lax')              Extensibility point in the WiX XML Schema.  Schema extensions can register additional             attributes at this point in the schema.           </span>
        </td>
      </tr>
    </table>
  </dd>
  <dt>How Tos and Examples</dt>
  <dd>
    <ul>
      <li>
        <a href="../../howtos/files_and_registry/add_a_file">How To: Add a file to your installer</a>
      </li>
    </ul>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>, <a href="../directoryref/">DirectoryRef</a></dd>
</dl>
