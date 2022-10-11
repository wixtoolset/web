---
title: Media Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Media element describes a disk that makes up the source media for the installation.</dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa369801.aspx" target="_blank">Media Table</a>
  </dd>
  <dt>Parents</dt>
  <dd>
    <a href="../wix/fragment">Fragment</a>, <a href="../wix/patch">Patch</a>, <a href="../wix/product">Product</a></dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Sequence (min: 1, max: 1)<ol><li>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../wix/digitalsignature">DigitalSignature</a> (min: 0, max: unbounded)</li><li><a href="../wix/patchbaseline">PatchBaseline</a> (min: 0, max: unbounded)</li><li><a href="../wix/symbolpath">SymbolPath</a> (min: 0, max: unbounded)</li></ul></li></ol></dd>
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
        <td><a href="../wix/simple_type_diskidtype">DiskIdType</a></td>
        <td>Disk identifier for Media table. This number must be equal to or greater than 1.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Cabinet</td>
        <td>String</td>
        <td>The name of the cabinet if some or all of the files stored on the media are in a cabinet file.  If no cabinets are used, this attribute must not be set.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>CompressionLevel</td>
        <td><a href="../wix/simple_type_compressionleveltype">CompressionLevelType</a></td>
        <td>                         Indicates the compression level for the Media's cabinet.  This attribute can                         only be used in conjunction with the Cabinet attribute.  The default is 'mszip'.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>DiskPrompt</td>
        <td>String</td>
        <td>The disk name, which is usually the visible text printed on the disk. This localizable text is used to prompt the user when this disk needs to be inserted. This value will be used in the "[1]" of the DiskPrompt Property. Using this attribute will require you to define a DiskPrompt Property.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>EmbedCab</td>
        <td><a href="../wix/simple_type_yesnotype">YesNoType</a></td>
        <td>Instructs the binder to embed the cabinet in the product if 'yes'.  This attribute can only be specified in conjunction with the Cabinet attribute.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Layout</td>
        <td>String</td>
        <td>                         This attribute specifies the root directory for the uncompressed files that                         are a part of this Media element.  By default, the src will be the output                         directory for the final image.  The default value ensures the binder generates                         an installable image.  If a relative path is specified in the src attribute,                         the value will be appended to the image's output directory.  If an absolute                         path is provided, that path will be used without modification.  The latter two                         options are provided to ease the layout of an image onto multiple medias (CDs/DVDs).                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Source</td>
        <td>String</td>
        <td>                         Optional property that identifies the source of the embedded cabinet.                         If a cabinet is specified for a patch, this property should be defined                         and unique to each patch so that the embedded cabinet containing patched                         and new files can be located in the patch package. If the cabinet is not                         embedded - this is not typical - the cabinet can be found in the directory                         referenced in this column. If empty, the external cabinet must be located                         in the SourceDir directory.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>src</td>
        <td>String</td>
        <td>This attribute has been deprecated; please use the Layout attribute instead.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>VolumeLabel</td>
        <td>String</td>
        <td>                         The label attributed to the volume. This is the volume label returned                         by the GetVolumeInformation function. If the SourceDir property refers                         to a removable (floppy or CD-ROM) volume, then this volume label is                         used to verify that the proper disk is in the drive before attempting                         to install files. The entry in this column must match the volume label                         of the physical media.                     </td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>
  </dd>
</dl>
