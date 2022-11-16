---
title: RollbackBoundary Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Describes a rollback boundary in the chain.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../chain/">Chain</a>, <a href="../packagegroup/">PackageGroup</a></dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Choice of elements (min: 0, max: unbounded)<ul><li><span class="extension">Any Element (namespace='##other' processContents='Lax')                  Extensibility point in the WiX XML Schema.  Schema extensions can register additional                 elements at this point in the schema.  The extension's                 <code><nobr>CompilerExtension.ParseElement()</nobr></code>                 method will be called with the rollback boundary identifier as the 'RollbackBoundaryId' key in                 <code>contextValues</code>.             </span></li></ul></dd>
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
        <td>             Identifier for this rollback boundary, for ordering and cross-referencing. If this attribute is             not provided a stable identifier will be generated.           </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Vital</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>             Specifies whether the rollback boundary aborts the chain. The default "yes" indicates that if             the rollback boundary is encountered then the chain will fail and rollback or stop. If "no"             is specified then the chain should continue successfuly at the next rollback boundary.           </td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>
  </dd>
</dl>
