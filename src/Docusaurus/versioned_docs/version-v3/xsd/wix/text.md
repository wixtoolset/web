---
title: Text Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>                 An alternative to using the Text attribute when the value contains special XML characters like &lt;, &gt;, or &amp;.             </dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../control/">Control</a>
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
        <td>SourceFile</td>
        <td>String</td>
        <td>Instructs the text to be imported from a file instead of the element value during the binding process.</td>
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
  <dt>See Also</dt>
  <dd>
    <a href="../">Wix Schema</a>
  </dd>
</dl>
