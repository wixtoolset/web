---
title: CostInitialize Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Initiates the internal installation costing process.  Any standard or custom actions that affect costing should be sequenced before the CostInitialize action.  Call the FileCost action immediately following the CostInitialize action.  Then call the CostFinalize action following the CostInitialize action to make all final cost calculations available to the installer through the Component table.  The condition for this action may be specified in the element's inner text.</dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa368048.aspx" target="_blank">CostInitialize Action</a>
  </dd>
  <dt>Parents</dt>
  <dd>
    <a href="../adminexecutesequence/">AdminExecuteSequence</a>, <a href="../adminuisequence/">AdminUISequence</a>, <a href="../advertiseexecutesequence/">AdvertiseExecuteSequence</a>, <a href="../installexecutesequence/">InstallExecuteSequence</a>, <a href="../installuisequence/">InstallUISequence</a></dd>
  <dt>Inner Text (xs:string)</dt>
  <dd>This element may have inner text.</dd>
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
        <td>Sequence</td>
        <td>Integer</td>
        <td>A value used to indicate the position of this action in a sequence.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Suppress</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>If yes, this action will not occur.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>, <a href="../filecost/">FileCost</a>, <a href="../costfinalize/">CostFinalize</a></dd>
</dl>
