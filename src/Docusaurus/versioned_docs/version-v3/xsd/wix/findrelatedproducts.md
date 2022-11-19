---
title: FindRelatedProducts Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Runs through each record of the Upgrade table in sequence and compares the upgrade code, product version, and language in each row to products installed on the system.  When FindRelatedProducts detects a correspondence between the upgrade information and an installed product, it appends the product code to the property specified in the ActionProperty column of the UpgradeTable.  The FindRelatedProducts action only runs the first time the product is installed.  The FindRelatedProducts action does not run during maintenance mode or uninstallation.  FindRelatedProducts should be authored into the InstallUISequence table and InstallExecuteSequence tables.  The installer prevents FindRelatedProducts from running in InstallExecuteSequence if the action has already run in InstallUISequence.  The FindRelatedProducts action must come before the MigrateFeatureStates action and the RemoveExistingProducts action.  The condition for this action may be specified in the element's inner text.</dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa368600.aspx" target="_blank">FindRelatedProducts Action</a>
  </dd>
  <dt>Parents</dt>
  <dd>
    <a href="../installexecutesequence/">InstallExecuteSequence</a>, <a href="../installuisequence/">InstallUISequence</a></dd>
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
        <td>After</td>
        <td>String</td>
        <td>The name of an action that this action should come after.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Before</td>
        <td>String</td>
        <td>The name of an action that this action should come before.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Overridable</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>                             If "yes", the sequencing of this action may be overridden by sequencing elsewhere.                         </td>
        <td>&nbsp;</td>
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
    <a href="../">Wix Schema</a>, <a href="../upgrade/">Upgrade</a></dd>
</dl>
