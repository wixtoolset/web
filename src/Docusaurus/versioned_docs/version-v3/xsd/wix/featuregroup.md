---
title: FeatureGroup Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>                 Groups together multiple components, features, and merges to be used in other locations.             </dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../featureref/">FeatureRef</a>, <a href="../fragment/">Fragment</a></dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../component/">Component</a> (min: 0, max: unbounded)</li><li><a href="../componentgroupref/">ComponentGroupRef</a> (min: 0, max: unbounded)</li><li><a href="../componentref/">ComponentRef</a> (min: 0, max: unbounded)</li><li><a href="../feature/">Feature</a> (min: 0, max: unbounded)</li><li><a href="../featuregroupref/">FeatureGroupRef</a> (min: 0, max: unbounded)</li><li><a href="../featureref/">FeatureRef</a> (min: 0, max: unbounded)</li><li><a href="../mergeref/">MergeRef</a> (min: 0, max: unbounded)</li><li><span class="extension">Any Element (namespace='##other' processContents='Lax')                              Extensibility point in the WiX XML Schema.  Schema extensions can register additional                             elements at this point in the schema.                         </span></li></ul></dd>
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
        <td>Identifier for the FeatureGroup.</td>
        <td>Yes</td>
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
    <a href="../wix">Wix Schema</a>, <a href="../featuregroupref/">FeatureGroupRef</a></dd>
</dl>
