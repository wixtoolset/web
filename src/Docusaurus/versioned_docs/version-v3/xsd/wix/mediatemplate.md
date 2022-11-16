---
title: MediaTemplate Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>                 MediaTeplate element describes information to automatically assign files to cabinets.                  A maximumum number of cabinets created is 999.             </dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../fragment/">Fragment</a>, <a href="../product/">Product</a></dd>
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
        <td>CabinetTemplate</td>
        <td>String</td>
        <td>                         Templated name of the cabinet if some or all of the files stored on the media are in                          a cabinet file. This name must begin with either a letter or an underscore, contain                          maximum of five characters and {0} in the cabinet name part and must end three character extension.                         The default is cab{0}.cab.                      </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>CompressionLevel</td>
        <td>Enumeration</td>
        <td>                         Indicates the compression level for the Media's cabinet.  This attribute can                          only be used in conjunction with the Cabinet attribute.  The default is 'mszip'.                       This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>high</dfn></dt><dd></dd><dt class="enumerationValue"><dfn>low</dfn></dt><dd></dd><dt class="enumerationValue"><dfn>medium</dfn></dt><dd></dd><dt class="enumerationValue"><dfn>mszip</dfn></dt><dd></dd><dt class="enumerationValue"><dfn>none</dfn></dt><dd></dd></dl></td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>DiskPrompt</td>
        <td>String</td>
        <td>                         The disk name, which is usually the visible text printed on the disk. This localizable text is used                         to prompt the user when this disk needs to be inserted. This value will be used in the "[1]" of the                          DiskPrompt Property. Using this attribute will require you to define a DiskPrompt Property.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>EmbedCab</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Instructs the binder to embed the cabinets in the product if 'yes'.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>MaximumCabinetSizeForLargeFileSplitting</td>
        <td>Int</td>
        <td>                         Maximum size of cabinet files in megabytes for large files. This attribute is used for packaging                          files that are larger than MaximumUncompressedMediaSize into smaller cabinets. If cabinet size                          exceed this value, then setting this attribute will cause the file to be split into multiple                          cabinets of this maximum size. For simply controlling cabinet size without file splitting use                          MaximumUncompressedMediaSize attribute. Setting this attribute will disable smart cabbing feature                          for this Fragment / Product. Setting WIX_MCSLFS environment variable can be used to override this                          value. Minimum allowed value of this attribute is 20 MB. Maximum allowed value and the Default                          value of this attribute is 2048 MB (2 GB).                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>MaximumUncompressedMediaSize</td>
        <td>Int</td>
        <td>                         Size of uncompressed files in each cabinet, in megabytes. WIX_MUMS environment variable                          can be used to override this value. Default value is 200 MB.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>VolumeLabel</td>
        <td>String</td>
        <td>                         The label attributed to the volume. This is the volume label returned                          by the GetVolumeInformation function. If the SourceDir property refers                          to a removable (floppy or CD-ROM) volume, then this volume label is                          used to verify that the proper disk is in the drive before attempting                          to install files. The entry in this column must match the volume label                          of the physical media.                      </td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>
  </dd>
</dl>
