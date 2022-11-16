---
title: XmlFile Element (Util Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>                 Adds or removes .xml file entries.  If you use the XmlFile element you must reference WixUtilExtension.dll as it contains the XmlFile custom actions.             </dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../component/">Component</a>
  </dd>
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
        <td>Identifier for xml file modification.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Action</td>
        <td>Enumeration</td>
        <td>The type of modification to be made to the XML file when the component is installed.  This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>createElement</dfn></dt><dd>Creates a new element under the element specified in ElementPath.  The Name attribute is required in this case and specifies the name of the new element.  The Value attribute is not necessary when createElement is specified as the action.  If the Value attribute is set, it will cause the new element's text value to be set.</dd><dt class="enumerationValue"><dfn>deleteValue</dfn></dt><dd>Deletes a value from the element specified in the ElementPath.  If Name is specified, the attribute with that name is deleted.  If Name is not specified, the text value of the element specified in the ElementPath is deleted.  The Value attribute is ignored if deleteValue is the action specified.</dd><dt class="enumerationValue"><dfn>setValue</dfn></dt><dd>Sets a value in the element specified in the ElementPath.  If Name is specified, and attribute with that name is set to the value specified in Value.  If Name is not specified, the text value of the element is set.  Value is a required attribute if setValue is the action specified.</dd><dt class="enumerationValue"><dfn>bulkSetValue</dfn></dt><dd>Sets all the values in the elements that match the ElementPath.  If Name is specified, attributes with that name are set to the same value specified in Value.  If Name is not specified, the text values of the elements are set.  Value is a required attribute if setBulkValue is the action specified.</dd></dl></td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>ElementPath</td>
        <td>String</td>
        <td>The XPath of the element to be modified.  Note that this is a formatted field and therefore, square brackets in the XPath must be escaped. In addition, XPaths allow backslashes to be used to escape characters, so if you intend to include literal backslashes, you must escape them as well by doubling them in this attribute. The string is formatted by MSI first, and the result is consumed as the XPath.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>File</td>
        <td>String</td>
        <td>Path of the .xml file to configure.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Name</td>
        <td>String</td>
        <td>Name of XML node to set/add to the specified element.  Not setting this attribute causes the element's text value to be set.  Otherwise this specified the attribute name that is set.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Permanent</td>
        <td><a href="../util/simple_type_yesnotype">YesNoType</a></td>
        <td>Specifies whether or not the modification should be removed on uninstall.  This has no effect on uninstall if the action was deleteValue.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>PreserveModifiedDate</td>
        <td><a href="../util/simple_type_yesnotype">YesNoType</a></td>
        <td>Specifies wheter or not the modification should preserve the modified date.  Preserving the modified date will allow the file to be patched if no other modifications have been made.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>SelectionLanguage</td>
        <td>Enumeration</td>
        <td>                         Specify whether the DOM object should use XPath language or the old XSLPattern language (default) as the query language.                                               This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>XPath</dfn></dt><dd></dd><dt class="enumerationValue"><dfn>XSLPattern</dfn></dt><dd></dd></dl></td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Sequence</td>
        <td>Integer</td>
        <td>Specifies the order in which the modification is to be attempted on the XML file.  It is important to ensure that new elements are created before you attempt to add an attribute to them.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Value</td>
        <td>String</td>
        <td>                         The value to be written.  See the <a href="http://msdn.microsoft.com/library/aa368609(VS.85).aspx" target="_blank">Formatted topic</a> for information how to escape square brackets in the value.                     </td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../util">Util Schema</a>
  </dd>
</dl>
