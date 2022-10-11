---
title: Log Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Overrides the default log settings for a bundle.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../wix/bundle">Bundle</a>
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
        <td>Disable</td>
        <td><a href="../wix/simple_type_yesnotype">YesNoType</a></td>
        <td>                         Disables the default logging in the Bundle. The end user can still generate a                         log file by specifying the "-l" command-line argument when installing the                         Bundle.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Extension</td>
        <td>String</td>
        <td>The extension to use for the log. The default is ".log".</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>PathVariable</td>
        <td>String</td>
        <td>                         Name of a Variable that will hold the path to the log file. An empty value                         will cause the variable to not be set. The default is "WixBundleLog".                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Prefix</td>
        <td>String</td>
        <td>                         File name and optionally a relative path to use as the prefix for the log file. The                         default is to use the Bundle/@Name or, if Bundle/@Name is not specified, the value                         "Setup".                     </td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>
  </dd>
</dl>
