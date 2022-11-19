---
title: InternetShortcut Element (Util Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>Creates a shortcut to a URL.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../../wix/component/">Component</a>
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
        <td>Id</td>
        <td>String</td>
        <td>Unique identifier in your installation package for this Internet shortcut.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Directory</td>
        <td>String</td>
        <td>Identifier reference to Directory element where shortcut is to be created. This attribute's value defaults to the parent Component directory.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>IconFile</td>
        <td>String</td>
        <td>             Icon file that should be displayed. Note that this is a formatted field, so you can use             [#fileId] syntax to refer to a file being installed (using the file:             protocol).           </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>IconIndex</td>
        <td>Integer</td>
        <td>             Index of the icon being referenced           </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Name</td>
        <td>String</td>
        <td>                         The name of the shortcut file, which is visible to the user. (The .lnk                          extension is added automatically and by default, is not shown to the user.)                     </td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Target</td>
        <td>String</td>
        <td>                         URL that should be opened when the user selects the shortcut. Windows                         opens the URL in the appropriate handler for the protocol specified                          in the URL. Note that this is a formatted field, so you can use                          [#fileId] syntax to refer to a file being installed (using the file:                          protocol).                     </td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Type</td>
        <td>Enumeration</td>
        <td>Which type of shortcut should be created.  This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>url</dfn></dt><dd>Creates .url files using IUniformResourceLocatorW.</dd><dt class="enumerationValue"><dfn>link</dfn></dt><dd>Creates .lnk files using IShellLinkW (default).</dd></dl></td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>How Tos and Examples</dt>
  <dd>
    <ul>
      <li>
        <a href="../../../howtos/files_and_registry/create_internet_shortcut">How To: Create a shortcut to a webpage</a>
      </li>
    </ul>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Util Schema</a>
  </dd>
</dl>
