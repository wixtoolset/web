---
title: CopyFile Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>                 Copy or move an existing file on the target machine, or copy a file that is being installed, to another destination.  When                 this element is nested under a File element, the parent file will be installed, then copied to the specified destination                 if the parent component of the file is selected for installation or removal.  When this element is nested under                 a Component element and no FileId attribute is specified, the file to copy or move must already be on the target machine.                 When this element is nested under a Component element and the FileId attribute is specified, the specified file is installed,                 then copied to the specified destination if the parent component is selected for installation or removal (use                 this option to control the copy of a file in a different component by the parent component's installation state).  If the                 specified destination directory is the same as the directory containing the original file and the name for the proposed source                 file is the same as the original, then no action takes place.             </dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa368335.aspx" target="_blank">DuplicateFile Table</a>, <a href="http://msdn.microsoft.com/library/aa370055.aspx" target="_blank">MoveFile Table</a></dd>
  <dt>Parents</dt>
  <dd>
    <a href="../wix/component">Component</a>, <a href="../wix/file">File</a></dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
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
        <td>Primary key used to identify this particular entry.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Delete</td>
        <td><a href="../wix/simple_type_yesnotype">YesNoType</a></td>
        <td>                     This attribute cannot be specified if the element is nested under a File element or the FileId attribute is specified.  In other                     cases, if the attribute is not specified, the default value is "no" and the file is copied, not moved.  Set the value to "yes"                     in order to move the file (thus deleting the source file) instead of copying it.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>DestinationDirectory</td>
        <td>String</td>
        <td>                     Set this value to the destination directory where an existing file on the target machine should be moved or copied to.  This                     Directory must exist in the installer database at creation time.  This attribute cannot be specified in conjunction with                     DestinationProperty.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>DestinationLongName</td>
        <td><a href="../wix/simple_type_longfilenametype">LongFileNameType</a></td>
        <td>This attribute has been deprecated; please use the DestinationName attribute instead.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>DestinationName</td>
        <td><a href="../wix/simple_type_longfilenametype">LongFileNameType</a></td>
        <td>                   In prior versions of the WiX toolset, this attribute specified the short file name.                   Now set this value to the localizable name to be given to the original file after it is moved or copied.                   If this attribute is not specified, then the destination file is given the same name as the source file.                   If a short file name is specified, the DestinationShortName attribute may not be specified.                   If a long file name is specified, the DestinationLongName attribute may not be specified.                   Also, if this value is a long file name, the DestinationShortName attribute may be omitted to                   allow WiX to attempt to generate a unique short file name.                   However, if this name collides with another file or you wish to manually specify                   the short file name, then the DestinationShortName attribute may be specified.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>DestinationProperty</td>
        <td>String</td>
        <td>                     Set this value to a property that will have a value that resolves to the full path of the destination directory.  The property                     does not have to exist in the installer database at creation time; it could be created at installation time by a custom                     action, on the command line, etc.  This attribute cannot be specified in conjunction with DestinationDirectory.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>DestinationShortName</td>
        <td><a href="../wix/simple_type_shortfilenametype">ShortFileNameType</a></td>
        <td>                   The short file name of the file in 8.3 format.                   This attribute should only be set if there is a conflict between generated short file names                   or you wish to manually specify the short file name.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>FileId</td>
        <td>String</td>
        <td>                     This attribute cannot be specified if the element is nested under a File element.  Set this attribute's value to the identifier                     of a file from a different component to copy it based on the install state of the parent component.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>SourceDirectory</td>
        <td>String</td>
        <td>                     This attribute cannot be specified if the element is nested under a File element or the FileId attribute is specified.  Set                     this value to the source directory from which to copy or move an existing file on the target machine.  This Directory must                     exist in the installer database at creation time.  This attribute cannot be specified in conjunction with SourceProperty.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>SourceName</td>
        <td><a href="../wix/simple_type_wildcardlongfilenametype">WildCardLongFileNameType</a></td>
        <td>                     This attribute cannot be specified if the element is nested under a File element or the FileId attribute is specified.  Set                     this value to the localizable name of the file(s) to be copied or moved.  All of the files that                     match the wild card will be removed from the specified directory.  The value is a filename that may also                     contain the wild card characters "?" for any single character or "*" for zero or more occurrences of any character.  If this                     attribute is not specified (and this element is not nested under a File element or specify a FileId attribute) then the                     SourceProperty attribute should be set to the name of a property that will resolve to the full path of the source filename.                     If the value of this attribute contains a "*" wildcard and the DestinationName attribute is specified, all moved or copied                     files retain the file names from their sources.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>SourceProperty</td>
        <td>String</td>
        <td>                     This attribute cannot be specified if the element is nested under a File element or the FileId attribute is specified.  Set                     this value to a property that will have a value that resolves to the full path of the source directory (or full path                     including file name if SourceName is not specified).  The property does not have to exist in the installer database at                     creation time; it could be created at installation time by a custom action, on the command line, etc.  This attribute                     cannot be specified in conjunction with SourceDirectory.                 </td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>, <a href="../wix/removefile">RemoveFile</a></dd>
</dl>
