---
title: Billboard Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>                 Billboard to display during install of a Feature             </dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa367823.aspx" target="_blank">Billboard Table</a>, <a href="http://msdn.microsoft.com/library/aa367818.aspx" target="_blank">BBControl Table</a></dd>
  <dt>Parents</dt>
  <dd>
    <a href="../wix/billboardaction">BillboardAction</a>
  </dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Sequence (min: 1, max: 1)<ol><li><a href="../wix/control">Control</a> (min: 0, max: unbounded): Only controls of static type such as: Text, Bitmap, Icon, or custom control can be placed on a billboard.</li></ol></dd>
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
        <td>Unique identifier for the Billboard.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Feature</td>
        <td>String</td>
        <td>Feature whose state determines if the Billboard is shown.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>
  </dd>
</dl>
