---
title: Verb Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>             Verb definition for an Extension.  When advertised, this element creates a row in the             <a href="http://msdn.microsoft.com/library/aa372487.aspx" target="_blank">Verb table</a>.             When not advertised, this element creates the appropriate rows in <a href="http://msdn.microsoft.com/library/aa371168.aspx" target="_blank">Registry table</a>.             </dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa372487.aspx" target="_blank">Verb Table</a>, <a href="http://msdn.microsoft.com/library/aa371168.aspx" target="_blank">Registry Table</a></dd>
  <dt>Parents</dt>
  <dd>
    <a href="../extension/">Extension</a>
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
        <td>The verb for the command.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Argument</td>
        <td>String</td>
        <td>Value for the command arguments.  Note that the resolution of properties in the                 Argument field is limited. A property formatted as [Property] in this field can only be resolved if the property                 already has the intended value when the component owning the verb is installed. For example, for the argument                 "[#MyDoc.doc]" to resolve to the correct value, the same process must be installing the file MyDoc.doc and the                 component that owns the verb.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Command</td>
        <td>String</td>
        <td>The localized text displayed on the context menu.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Sequence</td>
        <td>Integer</td>
        <td>The sequence of the commands. Only verbs for which the Sequence is specified                 are used to prepare an ordered list for the default value of the shell key. The Verb with the lowest value in this                 column becomes the default verb. Used only for Advertised verbs.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Target</td>
        <td>String</td>
        <td>This attribute has been deprecated; please use the TargetFile attribute instead.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>TargetFile</td>
        <td>String</td>
        <td>                         Either this attribute or the TargetProperty attribute must be specified for a non-advertised verb.                         The value should be the identifier of the target file to be executed for the verb.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>TargetProperty</td>
        <td>String</td>
        <td>                         Either this attribute or the TargetFile attribute must be specified for a non-advertised verb.                         The value should be the identifier of the property which will resolve to the path to the target file to be executed for the verb.                     </td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Wix Schema</a>
  </dd>
</dl>
