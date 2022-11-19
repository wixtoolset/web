---
title: SqlLogFileSpec Element (Sql Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>File specification for a Sql database.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../../sql/sqldatabase" class="extension">SqlDatabase</a>
  </dd>
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
        <td>Filename</td>
        <td>String</td>
        <td>Specifies the operating-system file name for the log file.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>GrowthSize</td>
        <td>String</td>
        <td>                         Specifies the growth increment of the log file. The GB, MB and KB and % suffixes can be used to                          specify gigabytes, megabytes, kilobytes or a percentage of the current file size to grow. The default is                          megabytes if no suffix is specified. The default value is 10% if GrowthSize is not specified, and the                          minimum value is 64 KB. The GrowthSize setting for a file cannot exceed the MaxSize setting.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Id</td>
        <td>String</td>
        <td>ID of the log file specification.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>MaxSize</td>
        <td>String</td>
        <td>                         Specifies the maximum size to which the log file can grow. The GB, MB and KB suffixes can be used to                          to specify gigabytes, megabytes or kilobytes. The default is megabytes if no suffix is specified. If                          MaxSize is not specified, the file will grow until the disk is full.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Name</td>
        <td>String</td>
        <td>Specifies the logical name for the log file.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Size</td>
        <td>String</td>
        <td>                         Specifies the size of the log file. The GB, MB and KB suffixes can be used to specify gigabytes,                          megabytes or kilobytes. The default is megabytes if no suffix is specified. When a Size is not                          supplied for a log file, SQL Server makes the file 1 MB.                     </td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Sql Schema</a>
  </dd>
</dl>
