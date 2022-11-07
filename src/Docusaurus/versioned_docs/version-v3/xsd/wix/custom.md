---
title: Custom Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Use to sequence a custom action.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../wix/adminexecutesequence">AdminExecuteSequence</a>, <a href="../wix/adminuisequence">AdminUISequence</a>, <a href="../wix/advertiseexecutesequence">AdvertiseExecuteSequence</a>, <a href="../wix/installexecutesequence">InstallExecuteSequence</a>, <a href="../wix/installuisequence">InstallUISequence</a></dd>
  <dt>Inner Text (xs:string)</dt>
  <dd>Text node specifies the condition of the action.</dd>
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
        <td>The action to which the Custom element applies.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>After</td>
        <td>String</td>
        <td>The name of the standard or custom action after which this action should be performed. Mutually exclusive with Before, OnExit, and Sequence attributes</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Before</td>
        <td>String</td>
        <td>The name of the standard or custom action before which this action should be performed. Mutually exclusive with OnExit, After, and Sequence attributes</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>OnExit</td>
        <td><a href="../wix/simple_type_exittype">ExitType</a></td>
        <td>Mutually exclusive with Before, After, and Sequence attributes</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Overridable</td>
        <td><a href="../wix/simple_type_yesnotype">YesNoType</a></td>
        <td>                                 If "yes", the sequencing of this action may be overridden by sequencing elsewhere.                             </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Sequence</td>
        <td>Integer</td>
        <td>The sequence number for this action. Mutually exclusive with Before, After, and OnExit attributes</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>, <a href="../wix/customaction">CustomAction</a></dd>
</dl>
