---
title: AppSearch Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Uses file signatures to search for existing versions of products.  The AppSearch action may use this information to determine where upgrades are to be installed.  The AppSearch action can also be used to set a property to the existing value of an registry or .ini file entry.  AppSearch should be authored into the InstallUISequence table and InstallExecuteSequence table.  The installer prevents The AppSearch action from running in the InstallExecuteSequence sequence if the action has already run in InstallUISequence sequence.  The AppSearch action searches for file signatures using the CompLocator table first, the RegLocator table next, then the IniLocator table, and finally the DrLocator table.  The condition for this action may be specified in the element's inner text.</dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa367579.aspx" target="_blank">AppSearch Table</a>, <a href="http://msdn.microsoft.com/library/aa367578.aspx" target="_blank">AppSearch Action</a></dd>
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
    <a href="../">Wix Schema</a>, <a href="../componentsearch/">ComponentSearch</a>, <a href="../filesearch/">FileSearch</a>, <a href="../inifilesearch/">IniFileSearch</a>, <a href="../registrysearch/">RegistrySearch</a></dd>
</dl>
