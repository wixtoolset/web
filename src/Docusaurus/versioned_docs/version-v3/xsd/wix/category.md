---
title: Category Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>                 Qualified published component for parent Component             </dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa370921.aspx" target="_blank">PublishComponent Table</a>
  </dd>
  <dt>Parents</dt>
  <dd>
    <a href="../wix/component">Component</a>
  </dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Sequence (min: 0, max: unbounded)<ol><li><a href="../wix/appdata">AppData</a> (min: 0, max: unbounded)</li></ol></dd>
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
        <td><a href="../wix/simple_type_guid">Guid</a></td>
        <td>A string GUID that represents the category of components being grouped together.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>AppData</td>
        <td>String</td>
        <td>An optional localizable text describing the category.  The string is commonly parsed by the application and can be displayed to the user.  It should describe the category.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Feature</td>
        <td>String</td>
        <td>Feature that controls the advertisement of the category.  Defaults to the primary Feature for the parent Component .</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Qualifier</td>
        <td>String</td>
        <td>A text string that qualifies the value in the Id attribute.  A qualifier is used to distinguish multiple forms of the same Component, such as a Component that is implemented in multiple languages.</td>
        <td>Yes</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>
  </dd>
</dl>
