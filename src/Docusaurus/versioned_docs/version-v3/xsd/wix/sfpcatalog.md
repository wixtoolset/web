---
title: SFPCatalog Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>                 Adds a system file protection update catalog file             </dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa371833.aspx" target="_blank">SFPCatalog Table</a>
  </dd>
  <dt>Parents</dt>
  <dd>
    <a href="../fragment/">Fragment</a>, <a href="../module/">Module</a>, <a href="../product/">Product</a>, <a href="../sfpcatalog/">SFPCatalog</a></dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../sfpcatalog/">SFPCatalog</a> (min: 0, max: unbounded)</li><li><a href="../sfpfile/">SFPFile</a> (min: 0, max: unbounded): Primary Key to File Table.</li></ul></dd>
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
        <td>Dependency</td>
        <td>String</td>
        <td>Used to define dependency outside of the package.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Name</td>
        <td>String</td>
        <td>Filename for catalog file when installed.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>SourceFile</td>
        <td>String</td>
        <td>Path to catalog file in binary.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>
  </dd>
</dl>
