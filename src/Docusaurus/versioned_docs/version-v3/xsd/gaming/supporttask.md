---
title: SupportTask Element (Gaming Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>                 Creates an Internet shortcut and registers it as a "support task" in Game Explorer. For more information, see                 <a href="http://msdn.microsoft.com/library/bb173450.aspx" target="_blank">                     Game Explorer Tasks                 </a>.  SupportTask should not be used when authoring the tasks in the GDF using ExtendedProperties\GameTasks available in Windows 7.             </dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../gaming/game" class="extension">Game</a>
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
        <td>Address</td>
        <td>String</td>
        <td>URI for this task.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Name</td>
        <td>String</td>
        <td>User-visible task name Game Explorer shows on its context menu. Note that the first task is named "Play" regardless of the name you provide.</td>
        <td>Yes</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../gaming">Gaming Schema</a>
  </dd>
</dl>
