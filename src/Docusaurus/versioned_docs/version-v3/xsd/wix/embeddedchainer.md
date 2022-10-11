---
title: EmbeddedChainer Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>None</dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/bb736316.aspx" target="_blank">MsiEmbeddedChainer  Table</a>
  </dd>
  <dt>Parents</dt>
  <dd>
    <a href="../wix/fragment">Fragment</a>, <a href="../wix/module">Module</a>, <a href="../wix/product">Product</a></dd>
  <dt>Inner Text (xs:string)</dt>
  <dd>                             Element value is the condition.  CDATA may be used to when a condition contains many XML characters                             that must be escaped.  It is important to note that each EmbeddedChainer element must have a mutually exclusive condition                             to ensure that only one embedded chainer will execute at a time. If the conditions are not mutually exclusive the chainer                             that executes is undeterministic.                         </dd>
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
        <td>Unique identifier for embedded chainer.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>BinarySource</td>
        <td>String</td>
        <td>                                 Reference to the Binary element that contains the chainer executable. Mutually exclusive with                                 the FileSource and PropertySource attributes.                             </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>CommandLine</td>
        <td>String</td>
        <td>Value to append to the transaction handle and passed to the chainer executable.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>FileSource</td>
        <td>String</td>
        <td>                                 Reference to the File element that is the chainer executable. Mutually exclusive with                                 the BinarySource and PropertySource attributes.                             </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>PropertySource</td>
        <td>String</td>
        <td>                                 Reference to a Property that resolves to the full path to the chainer executable. Mutually exclusive with                                 the BinarySource and FileSource attributes.                             </td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>, <a href="../wix/binary">Binary</a>, <a href="../wix/file">File</a>, <a href="../wix/property">Property</a>, <a href="../wix/embeddedchainerref">EmbeddedChainerRef</a></dd>
</dl>
