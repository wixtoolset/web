---
title: Merge Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Merge directive to bring in a merge module that will be redirected to the parent directory.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../directory/">Directory</a>, <a href="../directoryref/">DirectoryRef</a></dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../configurationdata/">ConfigurationData</a> (min: 0, max: unbounded): Data to use as input to a configurable merge module.</li></ul></dd>
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
        <td>The unique identifier for the Merge element in the source code.  Referenced by the MergeRef/@Id.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>DiskId</td>
        <td><a href="../simple_type_diskidtype/">DiskIdType</a></td>
        <td>The value of this attribute should correspond to the Id attribute of a                     Media element authored elsewhere.  By creating this connection between the merge module and Media                     element, you set the packaging options to the values specified in the Media                     element (values such as compression level, cab embedding, etc...).</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>FileCompression</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Specifies if the files in the merge module should be compressed.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Language</td>
        <td><a href="../simple_type_localizableinteger/">LocalizableInteger</a></td>
        <td>Specifies the decimal LCID or localization token for the language to merge the Module in as.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>SourceFile</td>
        <td>String</td>
        <td>Path to the source location of the merge module.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>src</td>
        <td>String</td>
        <td>This attribute has been deprecated; please use the SourceFile attribute instead.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>How Tos and Examples</dt>
  <dd>
    <ul>
      <li>
        <a href="../../../howtos/redistributables_and_install_checks/install_vcredist">How To: Install the Visual C++ Redistributable with your installer</a>
      </li>
    </ul>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Wix Schema</a>, <a href="../mergeref/">MergeRef</a></dd>
</dl>
