---
title: Payload Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Describes a payload to a bootstrapper.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../bootstrapperapplication/">BootstrapperApplication</a>, <a href="../bootstrapperapplicationref/">BootstrapperApplicationRef</a>, <a href="../exepackage/">ExePackage</a>, <a href="../msipackage/">MsiPackage</a>, <a href="../msppackage/">MspPackage</a>, <a href="../msupackage/">MsuPackage</a>, <a href="../payloadgroup/">PayloadGroup</a>, <a href="../ux/">UX</a></dd>
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
        <td>Compressed</td>
        <td><a href="../simple_type_yesnodefaulttype/">YesNoDefaultType</a></td>
        <td>Whether the payload should be embedded in a container or left as an external payload.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>DownloadUrl</td>
        <td>String</td>
        <td><p>The URL to use to download the package. The following substitutions are supported:</p><ul><li>{0} is replaced by the package Id.</li><li>{1} is replaced by the payload Id.</li><li>{2} is replaced by the payload file name.</li></ul></td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Id</td>
        <td>String</td>
        <td>The identifier of Payload element.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Name</td>
        <td>String</td>
        <td>The destination path and file name for this payload. The default is the source file name. The use of '..' directories is not allowed.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>SourceFile</td>
        <td>String</td>
        <td>Location of the source file.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>SuppressSignatureVerification</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>             By default, a Bundle will use the hash of a payload to verify its contents. If this attribute is explicitly set to "no"             and the payload is signed with an Authenticode signature the Bundle will verify the contents of the payload using the             signature instead. Therefore, the default for this attribute could be considered to be "yes". It is unusual for "yes" to             be the default of an attribute. In this case, the default was changed in WiX v3.9 after experiencing real-world issues             with Windows verifying Authenticode signatures. Since the Authenticode signatures are no more secure than hashing the             payloads directly, the default was changed.           </td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Wix Schema</a>
  </dd>
</dl>
