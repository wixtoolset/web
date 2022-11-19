---
title: Condition Element (Bal Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>                 Conditions for a bundle. The condition is specified in the inner text of the element.             </dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../../wix/bundle/">Bundle</a>, <a href="../../wix/fragment/">Fragment</a></dd>
  <dt>Inner Text (xs:string)</dt>
  <dd>                             The condition that must evaluate to true for the installation to continue.                         </dd>
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
        <td>Message</td>
        <td>String</td>
        <td>                                 Set the value to the text to display when the condition fails and the installation must be terminated.                             </td>
        <td>Yes</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Bal Schema</a>
  </dd>
</dl>
