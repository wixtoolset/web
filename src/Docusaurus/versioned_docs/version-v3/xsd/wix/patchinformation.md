---
title: PatchInformation Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Properties about the patch to be placed in the Summary Information Stream.  These are visible from COM through the IStream interface, and these properties can be seen on the package in Explorer.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../patch/">Patch</a>, <a href="../patchcreation/">PatchCreation</a></dd>
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
        <td>AdminImage</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>This attribute has been deprecated.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Comments</td>
        <td>String</td>
        <td>General purpose of the patch package. For example, "This patch contains the logic and data required to install <i>&lt;product&gt;</i>."</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Compressed</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>This attribute has been deprecated.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Description</td>
        <td>String</td>
        <td>A short description of the patch that includes the name of the product.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Keywords</td>
        <td>String</td>
        <td>A semicolon-delimited list of network or URL locations for alternate sources of the patch. The default is "Installer,Patching,PCP,Database".</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Languages</td>
        <td>String</td>
        <td>This attribute has been deprecated.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Manufacturer</td>
        <td>String</td>
        <td>The name of the manufacturer of the patch package.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Platforms</td>
        <td>String</td>
        <td>This attribute has been deprecated.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ReadOnly</td>
        <td><a href="../simple_type_yesnodefaulttype/">YesNoDefaultType</a></td>
        <td>                         The value of this attribute conveys whether the package should be opened as read-only.                         A database editing tool should not modify a read-only enforced database and should                         issue a warning at attempts to modify a read-only recommended database.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ShortNames</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>This attribute has been deprecated.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>SummaryCodepage</td>
        <td>String</td>
        <td>The code page integer value or web name for summary info strings only.  The default is 1252.  See remarks for more information.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>Remarks</dt>
  <dd><p>You can specify any valid Windows code by by integer like 1252, or by web name like Windows-1252. See <a href="../../../overview/codepage">Code Pages</a> for more information.</p></dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>
  </dd>
</dl>
