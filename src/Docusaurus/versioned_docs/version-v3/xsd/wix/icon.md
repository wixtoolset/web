---
title: Icon Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>                 Icon used for Shortcut, ProgId, or Class elements (but not UI controls)             </dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa369210.aspx" target="_blank">Icon Table</a>
  </dd>
  <dt>Parents</dt>
  <dd>
    <a href="../fragment/">Fragment</a>, <a href="../module/">Module</a>, <a href="../product/">Product</a>, <a href="../shortcut/">Shortcut</a></dd>
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
        <td>The Id cannot be longer than 55 characters.  In order to prevent errors in cases where the Id is modularized, it should not be longer than 18 characters.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>SourceFile</td>
        <td>String</td>
        <td>Path to the icon file.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>src</td>
        <td>String</td>
        <td>This attribute has been deprecated; please use the SourceFile attribute instead.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>How Tos and Examples</dt>
  <dd>
    <ul>
      <li>
        <a href="../../../howtos/ui_and_localization/configure_arp_appearance">How To: Set your installer's icon in Add/Remove Programs</a>
      </li>
      <li>
        <a href="../../../howtos/files_and_registry/create_start_menu_shortcut">How To: Create a shortcut on the Start Menu</a>
      </li>
    </ul>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>
  </dd>
</dl>
