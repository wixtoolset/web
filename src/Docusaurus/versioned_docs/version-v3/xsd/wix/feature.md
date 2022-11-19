---
title: Feature Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>                 A feature for the Feature table.  Features are the smallest installable unit.  See msi.chm for more                 detailed information on the myriad installation options for a feature.             </dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa368585.aspx" target="_blank">Feature Table</a>
  </dd>
  <dt>Parents</dt>
  <dd>
    <a href="../feature/">Feature</a>, <a href="../featuregroup/">FeatureGroup</a>, <a href="../featureref/">FeatureRef</a>, <a href="../fragment/">Fragment</a>, <a href="../product/">Product</a></dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../component/">Component</a> (min: 0, max: unbounded)</li><li><a href="../componentgroupref/">ComponentGroupRef</a> (min: 0, max: unbounded)</li><li><a href="../componentref/">ComponentRef</a> (min: 0, max: unbounded)</li><li><a href="../condition/">Condition</a> (min: 0, max: unbounded)</li><li><a href="../feature/">Feature</a> (min: 0, max: unbounded)</li><li><a href="../featuregroupref/">FeatureGroupRef</a> (min: 0, max: unbounded)</li><li><a href="../featureref/">FeatureRef</a> (min: 0, max: unbounded)</li><li><a href="../mergeref/">MergeRef</a> (min: 0, max: unbounded)</li><li><span class="extension">Any Element (namespace='##other' processContents='Lax')                          Extensibility point in the WiX XML Schema.  Schema extensions can register additional                         elements at this point in the schema.                     </span></li></ul></dd>
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
        <td>Unique identifier of the feature.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Absent</td>
        <td>Enumeration</td>
        <td>                         This attribute determines if a user will have the option to set a feature to absent in the user interface.                       This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>allow</dfn></dt><dd>                                     Allows the user interface to display an option to change the feature state to Absent.                                 </dd><dt class="enumerationValue"><dfn>disallow</dfn></dt><dd>                                     Prevents the user interface from displaying an option to change the feature state                                     to Absent by setting the msidbFeatureAttributesUIDisallowAbsent attribute.  This will force the feature                                     to the installation state, whether or not the feature is visible in the UI.                                 </dd></dl></td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>AllowAdvertise</td>
        <td>Enumeration</td>
        <td>                         This attribute determines the possible advertise states for this feature.                       This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>no</dfn></dt><dd>                                     Prevents this feature from being advertised by setting the msidbFeatureAttributesDisallowAdvertise attribute.                                 </dd><dt class="enumerationValue"><dfn>system</dfn></dt><dd>                                     Prevents advertising for this feature if the operating system shell does not support Windows Installer                                     descriptors by setting the msidbFeatureAttributesNoUnsupportedAdvertise attribute.                                 </dd><dt class="enumerationValue"><dfn>yes</dfn></dt><dd>                                     Allows the feature to be advertised.                                 </dd></dl></td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ConfigurableDirectory</td>
        <td>String</td>
        <td>                     Specify the Id of a Directory that can be configured by the user at installation time.  This identifier                     must be a public property and therefore completely uppercase.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Description</td>
        <td>String</td>
        <td>                     Longer string of text describing the feature.  This localizable string is displayed by the                     Text Control of the Selection Dialog.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Display</td>
        <td>String</td>
        <td>                         Determines the initial display of this feature in the feature tree.                         This attribute's value should be one of the following:                         <dl><dt class="enumerationValue"><dfn>collapse</dfn></dt><dd>Initially shows the feature collapsed.  This is the default value.</dd><dt class="enumerationValue"><dfn>expand</dfn></dt><dd>Initially shows the feature expanded.</dd><dt class="enumerationValue"><dfn>hidden</dfn></dt><dd>Prevents the feature from displaying in the user interface.</dd><dt class="enumerationValue"><dfn>&lt;an explicit integer value&gt;</dfn></dt><dd>                                 For advanced users only, it is possible to directly set the integer value                                 of the display value that will appear in the Feature row.                             </dd></dl></td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>InstallDefault</td>
        <td>Enumeration</td>
        <td>                         This attribute determines the default install/run location of a feature.  This attribute cannot be specified                         if the value of the FollowParent attribute is 'yes' since that would ask the installer to force this feature                         to follow the parent installation state and simultaneously favor a particular installation state just for this feature.                       This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>followParent</dfn></dt><dd>                                     Forces the feature to follow the same installation state as its parent feature.                                 </dd><dt class="enumerationValue"><dfn>local</dfn></dt><dd>                                     Favors installing this feature locally by setting the msidbFeatureAttributesFavorLocal attribute.                                 </dd><dt class="enumerationValue"><dfn>source</dfn></dt><dd>                                     Favors running this feature from source by setting the msidbFeatureAttributesFavorSource attribute.                                 </dd></dl></td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Level</td>
        <td>Integer</td>
        <td>                     Sets the install level of this feature.  A value of 0 will disable the feature.  Processing the                     Condition Table can modify the level value (this is set via the Condition child element). The                     default value is "1".                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Title</td>
        <td>String</td>
        <td>                     Short string of text identifying the feature.  This string is listed as an item by the                     SelectionTree control of the Selection Dialog.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>TypicalDefault</td>
        <td>Enumeration</td>
        <td>                     This attribute determines the default advertise state of the feature.                   This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>advertise</dfn></dt><dd>                                     Sets the feature to be advertised by setting the msidbFeatureAttributesFavorAdvertise attribute.                                     This value cannot be set if the value of the AllowAdvertise attribute is 'no' since that would ask the installer to                                     disallow the advertised state for this feature while at the same time favoring it.                                 </dd><dt class="enumerationValue"><dfn>install</dfn></dt><dd>                                     Sets the feature to the default non-advertised installation option.                                 </dd></dl></td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td colspan="4">
          <span class="extension">Any Attribute (namespace='##other' processContents='lax')                      Extensibility point in the WiX XML Schema.  Schema extensions can register additional                     attributes at this point in the schema.                 </span>
        </td>
      </tr>
    </table>
  </dd>
  <dt>How Tos and Examples</dt>
  <dd>
    <ul>
      <li>
        <a href="../../../howtos/files_and_registry/add_a_file">How To: Add a file to your installer</a>
      </li>
    </ul>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Wix Schema</a>, <a href="../featureref/">FeatureRef</a></dd>
</dl>
