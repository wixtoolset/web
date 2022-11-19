---
title: Publish Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>None</dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa368037.aspx" target="_blank">ControlEvent Table</a>
  </dd>
  <dt>Parents</dt>
  <dd>
    <a href="../control/">Control</a>, <a href="../ui/">UI</a></dd>
  <dt>Inner Text (xs:string)</dt>
  <dd>The element value is the optional Condition expression.</dd>
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
        <td>Control</td>
        <td>String</td>
        <td>                                 The parent Control for this Publish element, should only be specified when this element is a child of the UI element.                             </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Dialog</td>
        <td>String</td>
        <td>                                 The parent Dialog for this Publish element, should only be specified when this element is a child of the UI element.                                 This attribute will create a reference to the specified Dialog, so an additional DialogRef is not necessary.                             </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Event</td>
        <td>String</td>
        <td>                                 Set this attribute's value to one of the standard control events to trigger that event.                                 Either this attribute or the Property attribute must be set, but not both at the same time.                             </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Order</td>
        <td>String</td>
        <td>                                 This attribute should only need to be set if this element is nested under a UI element in order to                                 control the order in which this publish event will be started.                                 If this element is nested under a Control element, the default value will be one greater than any                                 previous Publish element's order (the first element's default value is 1).                                 If this element is nested under a UI element, the default value is always 1 (it does not get a                                 default value based on any previous Publish elements).                             </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Property</td>
        <td>String</td>
        <td>                                 Set this attribute's value to a property name to set that property.                                 Either this attribute or the Event attribute must be set, but not both at the same time.                             </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Value</td>
        <td>String</td>
        <td>                                 If the Property attribute is specified, set the value of this attribute to the new value for the property.                                 To set a property to null, do not set this attribute (the ControlEvent Argument column will be set to '{}').                                 Otherwise, this attribute's value should be the argument for the event specified in the Event attribute.                                 If the event doesn't take an attribute, a common value to use is "0".                             </td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Wix Schema</a>
  </dd>
</dl>
