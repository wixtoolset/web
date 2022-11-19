---
title: UnpublishFeatures Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Removes selection-state and feature-component mapping information from the registry.  The condition for this action may be specified in the element's inner text.</dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa372107.aspx" target="_blank">UnpublishFeatures Action</a>
  </dd>
  <dt>Parents</dt>
  <dd>
    <a href="../installexecutesequence/">InstallExecuteSequence</a>
  </dd>
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
    <a href="../">Wix Schema</a>
  </dd>
</dl>
