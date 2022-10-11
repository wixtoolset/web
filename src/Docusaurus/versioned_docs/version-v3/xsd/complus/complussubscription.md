---
title: ComPlusSubscription Element (Complus Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>         Defines an event subscription for a COM+ component.       </dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../complus/compluscomponent" class="extension">ComPlusComponent</a>, <a href="../wix/component">Component</a></dd>
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
        <td>           Identifier for the element.         </td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Component</td>
        <td>String</td>
        <td>           If the element is not a child of a ComPlusComponent           element, this attribute should be provided with the id of a ComPlusComponent           element representing the component the subscription is to be created for.         </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Description</td>
        <td>String</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Enabled</td>
        <td><a href="../complus/simple_type_yesnotype">YesNoType</a></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>EventClassPartitionID</td>
        <td>String</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>EventCLSID</td>
        <td>String</td>
        <td>           CLSID of the event class for the subscription. If a value           for this attribute is not provided, a value for the PublisherID attribute           must be provided.         </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>FilterCriteria</td>
        <td>String</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>InterfaceID</td>
        <td>String</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>MachineName</td>
        <td>String</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>MethodName</td>
        <td>String</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Name</td>
        <td>String</td>
        <td>           Name of the subscription.         </td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>PerUser</td>
        <td><a href="../complus/simple_type_yesnotype">YesNoType</a></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>PublisherID</td>
        <td>String</td>
        <td>           Publisher id for the subscription. If a value for this           attribute is not provided, a value for the EventCLSID attribute must be           provided.         </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Queued</td>
        <td><a href="../complus/simple_type_yesnotype">YesNoType</a></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>SubscriberMoniker</td>
        <td>String</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>SubscriptionId</td>
        <td>String</td>
        <td>           Id of the subscription. If a value is not provided for           this attribute, an id will be generated during installation.         </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>UserName</td>
        <td>String</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../complus">Complus Schema</a>
  </dd>
</dl>
