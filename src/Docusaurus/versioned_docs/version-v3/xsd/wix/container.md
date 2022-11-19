---
title: Container Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Representation of a file that contains one or more files.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../../wix/bundle/">Bundle</a>, <a href="../../wix/fragment/">Fragment</a></dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../../wix/packagegroupref/">PackageGroupRef</a> (min: 0, max: unbounded)</li></ul></dd>
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
        <td>DownloadUrl</td>
        <td>String</td>
        <td><p>The URL to use to download the container. This attribute is only valid when the container is detached. The             following substitutions are supported:</p><ul><li>{0} is always null.</li><li>{1} is replaced by the container Id.</li><li>{2} is replaced by the container file name.</li></ul></td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Id</td>
        <td>String</td>
        <td>The unique identifier for the container. If this attribute is not specified the Name attribute will be used.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Name</td>
        <td>String</td>
        <td>The file name for this container. A relative path may be provided to place the container in a sub-folder of the bundle.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Type</td>
        <td><a href="../simple_type_burncontainertype/">BurnContainerType</a></td>
        <td>             Indicates whether the container is "attached" to the bundle executable or placed external to the bundle extecutable as "detached". If             this attribute is not specified, the default is to create a detached container.           </td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>
  </dd>
</dl>
