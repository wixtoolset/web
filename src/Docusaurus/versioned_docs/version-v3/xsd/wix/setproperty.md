---
title: SetProperty Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>                 Sets a Property to a particular value. This is accomplished by creating a Type 51 custom action that is appropriately scheduled in                 the InstallUISequence and InstallExecuteSequence.             </dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa368062.aspx" target="_blank">CustomAction Table</a>
  </dd>
  <dt>Parents</dt>
  <dd>
    <a href="../fragment/">Fragment</a>, <a href="../module/">Module</a>, <a href="../product/">Product</a></dd>
  <dt>Inner Text (xs:string)</dt>
  <dd>                         The condition that determines whether the Property is set. If the condition evaluates to false, the Set is skipped.                     </dd>
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
        <td>Action</td>
        <td>String</td>
        <td>                                 By default the action is "Set" + Id attribute's value. This optional attribute can override the action name in the case                                 where multiple SetProperty elements target the same Id (probably with mutually exclusive conditions).                             </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>After</td>
        <td>String</td>
        <td>The name of the standard or custom action after which this action should be performed. Mutually exclusive with the Before attribute. A Before or After attribute is required when setting a Property.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Before</td>
        <td>String</td>
        <td>The name of the standard or custom action before which this action should be performed. Mutually exclusive with the After attribute. A Before or After attribute is required when setting a Property.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Id</td>
        <td>String</td>
        <td>                                 This attribute specifies the Property to set to the Value.                             </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Sequence</td>
        <td><a href="../simple_type_sequencetype/">SequenceType</a></td>
        <td>                                 Controls which sequences the Property assignment is sequenced in.                                 For 'execute', the assignment is scheduled in the InstallExecuteSequence.                                 For 'ui', the assignment is scheduled in the InstallUISequence.                                 For 'first', the assignment is scheduled in the InstallUISequence or the InstallExecuteSequence if the InstallUISequence is skipped at install time.                                 For 'both', the assignment is scheduled in both the InstallUISequence and the InstallExecuteSequence.                                  The default is 'both'.                             </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Value</td>
        <td>String</td>
        <td>                                 This attribute specifies a string value to assign to the Property. The value can be a literal value or derived from a                                 Property element using the <a href="http://msdn.microsoft.com/library/aa368609.aspx" target="_blank">Formatted</a>                                 syntax.                             </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td colspan="4">
          <span class="extension">Any Attribute (namespace='##other' processContents='lax')                              Extensibility point in the WiX XML Schema.  Schema extensions can register additional                             attributes at this point in the schema.                         </span>
        </td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Wix Schema</a>, <a href="../custom/">Custom</a>, <a href="../customactionref/">CustomActionRef</a>, <a href="../installuisequence/">InstallUISequence</a>, <a href="../installexecutesequence/">InstallExecuteSequence</a></dd>
</dl>
