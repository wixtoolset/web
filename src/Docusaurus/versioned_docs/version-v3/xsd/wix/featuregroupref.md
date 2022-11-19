---
title: FeatureGroupRef Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Create a reference to a FeatureGroup in another Fragment.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../feature/">Feature</a>, <a href="../featuregroup/">FeatureGroup</a>, <a href="../featureref/">FeatureRef</a>, <a href="../product/">Product</a></dd>
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
        <td>Id</td>
        <td>String</td>
        <td>The identifier of the FeatureGroup to reference.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>IgnoreParent</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>                     Normally feature group references that end up nested under a parent element create a                     connection to that parent. This behavior is undesirable when trying to simply reference                     to a FeatureGroup in a different Fragment.  Specify 'yes' to have this feature group                     reference not create a connection to its parent. The default is 'no'.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Primary</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>                         Set this attribute to 'yes' in order to make the parent feature of this group                         the primary feature for any components and merges contained in the group.                         Features may belong to multiple features.  By designating a feature as the                         primary feature of a component or merge, you ensure that whenever a component is                         selected for install-on-demand (IOD), the primary feature will be the one to install                         it.  This attribute should only be set if a component actually nests under multiple                         features.  If a component nests under only one feature, that feature is the primary                         feature for the component.  You cannot set more than one feature as the primary                         feature of a given component.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td colspan="4">
          <span class="extension">Any Attribute (namespace='##other' processContents='lax')                          Extensibility point in the WiX XML Schema.  Schema extensions can register additional                         attributes at this point in the schema.                     </span>
        </td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Wix Schema</a>, <a href="../featuregroup/">FeatureGroup</a></dd>
</dl>
