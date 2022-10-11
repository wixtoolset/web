---
title: FeatureRef Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Create a reference to a Feature element in another Fragment.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../wix/feature">Feature</a>, <a href="../wix/featuregroup">FeatureGroup</a>, <a href="../wix/featureref">FeatureRef</a>, <a href="../wix/fragment">Fragment</a>, <a href="../wix/patchfamily">PatchFamily</a>, <a href="../wix/product">Product</a></dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../wix/component">Component</a> (min: 0, max: unbounded)</li><li><a href="../wix/componentgroupref">ComponentGroupRef</a> (min: 0, max: unbounded)</li><li><a href="../wix/componentref">ComponentRef</a> (min: 0, max: unbounded)</li><li><a href="../wix/feature">Feature</a> (min: 0, max: unbounded)</li><li><a href="../wix/featuregroup">FeatureGroup</a> (min: 0, max: unbounded)</li><li><a href="../wix/featuregroupref">FeatureGroupRef</a> (min: 0, max: unbounded)</li><li><a href="../wix/featureref">FeatureRef</a> (min: 0, max: unbounded)</li><li><a href="../wix/mergeref">MergeRef</a> (min: 0, max: unbounded)</li><li><span class="extension">Any Element (namespace='##other' processContents='Lax')                          Extensibility point in the WiX XML Schema.  Schema extensions can register additional                         elements at this point in the schema.                     </span></li></ul></dd>
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
        <td>The identifier of the Feature element to reference.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>IgnoreParent</td>
        <td><a href="../wix/simple_type_yesnotype">YesNoType</a></td>
        <td>                     Normally feature references that are nested under a parent element create a connection to that                     parent. This behavior is undesirable when trying to simply reference a Feature in a different                     Fragment.  Specify 'yes' to have this feature reference not create a connection to its parent.                     The default is 'no'.                 </td>
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
    <a href="../wix">Wix Schema</a>, <a href="../wix/feature">Feature</a></dd>
</dl>
