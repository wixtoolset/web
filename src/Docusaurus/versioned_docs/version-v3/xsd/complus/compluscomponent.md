---
title: ComPlusComponent Element (Complus Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>       Represents a COM+ component in an assembly.     </dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../complus/complusassembly" class="extension">ComPlusAssembly</a>
  </dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Sequence (min: 1, max: 1)<ol><li>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../complus/complusinterface" class="extension">ComPlusInterface</a> (min: 0, max: unbounded)</li><li><a href="../complus/complusroleforcomponent" class="extension">ComPlusRoleForComponent</a> (min: 0, max: unbounded)</li><li><a href="../complus/complussubscription" class="extension">ComPlusSubscription</a> (min: 0, max: unbounded)</li></ul></li></ol></dd>
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
        <td>AllowInprocSubscribers</td>
        <td><a href="../complus/simple_type_yesnotype">YesNoType</a></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>CLSID</td>
        <td><a href="../complus/simple_type_uuid">Uuid</a></td>
        <td>           CLSID of the component.         </td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>ComponentAccessChecksEnabled</td>
        <td><a href="../complus/simple_type_yesnotype">YesNoType</a></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ComponentTransactionTimeout</td>
        <td>Int</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ComponentTransactionTimeoutEnabled</td>
        <td><a href="../complus/simple_type_yesnotype">YesNoType</a></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>COMTIIntrinsics</td>
        <td><a href="../complus/simple_type_yesnotype">YesNoType</a></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ConstructionEnabled</td>
        <td><a href="../complus/simple_type_yesnotype">YesNoType</a></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ConstructorString</td>
        <td>String</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>CreationTimeout</td>
        <td>Int</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Description</td>
        <td>String</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>EventTrackingEnabled</td>
        <td><a href="../complus/simple_type_yesnotype">YesNoType</a></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ExceptionClass</td>
        <td>String</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>FireInParallel</td>
        <td><a href="../complus/simple_type_yesnotype">YesNoType</a></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>IISIntrinsics</td>
        <td><a href="../complus/simple_type_yesnotype">YesNoType</a></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>InitializesServerApplication</td>
        <td><a href="../complus/simple_type_yesnotype">YesNoType</a></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>IsEnabled</td>
        <td><a href="../complus/simple_type_yesnotype">YesNoType</a></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>IsPrivateComponent</td>
        <td><a href="../complus/simple_type_yesnotype">YesNoType</a></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>JustInTimeActivation</td>
        <td><a href="../complus/simple_type_yesnotype">YesNoType</a></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>LoadBalancingSupported</td>
        <td><a href="../complus/simple_type_yesnotype">YesNoType</a></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>MaxPoolSize</td>
        <td>Int</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>MinPoolSize</td>
        <td>Int</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>MultiInterfacePublisherFilterCLSID</td>
        <td>String</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>MustRunInClientContext</td>
        <td><a href="../complus/simple_type_yesnotype">YesNoType</a></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>MustRunInDefaultContext</td>
        <td><a href="../complus/simple_type_yesnotype">YesNoType</a></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ObjectPoolingEnabled</td>
        <td><a href="../complus/simple_type_yesnotype">YesNoType</a></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>PublisherID</td>
        <td>String</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>SoapAssemblyName</td>
        <td>String</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>SoapTypeName</td>
        <td>String</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Synchronization</td>
        <td>Enumeration</td>
        <td>This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>ignored</dfn></dt><dd></dd><dt class="enumerationValue"><dfn>none</dfn></dt><dd></dd><dt class="enumerationValue"><dfn>supported</dfn></dt><dd></dd><dt class="enumerationValue"><dfn>required</dfn></dt><dd></dd><dt class="enumerationValue"><dfn>requiresNew</dfn></dt><dd></dd></dl></td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Transaction</td>
        <td>Enumeration</td>
        <td>This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>ignored</dfn></dt><dd></dd><dt class="enumerationValue"><dfn>none</dfn></dt><dd></dd><dt class="enumerationValue"><dfn>supported</dfn></dt><dd></dd><dt class="enumerationValue"><dfn>required</dfn></dt><dd></dd><dt class="enumerationValue"><dfn>requiresNew</dfn></dt><dd></dd></dl></td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>TxIsolationLevel</td>
        <td>Enumeration</td>
        <td>This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>any</dfn></dt><dd></dd><dt class="enumerationValue"><dfn>readUnCommitted</dfn></dt><dd></dd><dt class="enumerationValue"><dfn>readCommitted</dfn></dt><dd></dd><dt class="enumerationValue"><dfn>repeatableRead</dfn></dt><dd></dd><dt class="enumerationValue"><dfn>serializable</dfn></dt><dd></dd></dl></td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../complus">Complus Schema</a>
  </dd>
</dl>
