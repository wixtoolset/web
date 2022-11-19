---
title: ComponentGroup Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>                 Groups together multiple components to be used in other locations.             </dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../fragment/">Fragment</a>, <a href="../product/">Product</a></dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../component/">Component</a> (min: 0, max: unbounded)</li><li><a href="../componentgroupref/">ComponentGroupRef</a> (min: 0, max: unbounded)</li><li><a href="../componentref/">ComponentRef</a> (min: 0, max: unbounded)</li><li><span class="extension">Any Element (namespace='##other' processContents='Lax')                          Extensibility point in the WiX XML Schema.  Schema extensions can register additional                         elements at this point in the schema.                     </span></li></ul></dd>
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
        <td>Identifier for the ComponentGroup.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Directory</td>
        <td>String</td>
        <td>             Sets the default directory identifier for child Component elements.           </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Source</td>
        <td>String</td>
        <td>             Used to set the default file system source for child Component elements. For more information, see              <a href="../../../howtos/general/specifying_source_files">Specifying source files</a>.           </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td colspan="4">
          <span class="extension">Any Attribute (namespace='##other' processContents='lax')                      Extensibility point in the WiX XML Schema.  Schema extensions can register additional                     attributes at this point in the schema.                 </span>
        </td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>, <a href="../componentgroupref/">ComponentGroupRef</a></dd>
</dl>
