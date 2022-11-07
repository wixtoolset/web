---
title: FileCost Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Initiates dynamic costing of standard installation actions.  Any standard or custom actions that affect costing should sequenced before the CostInitialize action.  Call the FileCost action immediately following the CostInitialize action.  Then call the CostFinalize action following the FileCost action to make all final cost calculations available to the installer through the Component table.  The CostInitialize action must be executed before the FileCost action.  The installer then determines the disk-space cost of every file in the File table, on a per-component basis, taking both volume clustering and the presence of existing files that may need to be overwritten into account.  All actions that consume or release disk space are also considered.  If an existing file is found, a file version check is performed to determine whether the new file actually needs to be installed or not.  If the existing file is of an equal or greater version number, the existing file is not overwritten and no disk-space cost is incurred.  In all cases, the installer uses the results of version number checking to set the installation state of each file.  The FileCost action initializes cost calculation with the installer.  Actual dynamic costing does not occur until the CostFinalize action is executed.  The condition for this action may be specified in the element's inner text.</dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa368589.aspx" target="_blank">FileCost Action</a>
  </dd>
  <dt>Parents</dt>
  <dd>
    <a href="../wix/adminexecutesequence">AdminExecuteSequence</a>, <a href="../wix/adminuisequence">AdminUISequence</a>, <a href="../wix/installexecutesequence">InstallExecuteSequence</a>, <a href="../wix/installuisequence">InstallUISequence</a></dd>
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
        <td><a href="../wix/simple_type_yesnotype">YesNoType</a></td>
        <td>If yes, this action will not occur.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>, <a href="../wix/costinitialize">CostInitialize</a>, <a href="../wix/costfinalize">CostFinalize</a></dd>
</dl>
