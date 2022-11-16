---
title: Game Element (Gaming Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>                 Registers a game in Game Explorer on Windows Vista and later. The executable must have an                 embedded Game Definition File. For more information about Game Explorer and GDFs, see                 <a href="http://msdn.microsoft.com/library/bb173432.aspx" target="_blank">The Windows Vista Game Explorer</a>.                 This registration is accomplished via custom action.<br/><br/>                On Windows XP, this element instead records the same information in the registry so that                 later upgrades to Windows Vista register the game in Game Explorer.             </dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../file/">File</a>
  </dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../gaming/playtask" class="extension">PlayTask</a> (min: 0, max: unbounded)</li><li><a href="../gaming/supporttask" class="extension">SupportTask</a> (min: 0, max: unbounded)</li></ul></dd>
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
        <td><a href="../gaming/simple_type_guid">Guid</a></td>
        <td>The game's instance ID.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>ExecutableFile</td>
        <td>String</td>
        <td>Identifier of the file that is the game's executable, if it isn't the parent file.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>GdfResourceFile</td>
        <td>String</td>
        <td>Identifier of the file that contains the game's GDF resource, if it doesn't exist in the parent file.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../gaming">Gaming Schema</a>
  </dd>
</dl>
