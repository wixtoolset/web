---
title: Interface Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>COM Interface registration for parent TypeLib.</dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa371168.aspx" target="_blank">Registry Table</a>
  </dd>
  <dt>Parents</dt>
  <dd>
    <a href="../wix/class">Class</a>, <a href="../wix/component">Component</a>, <a href="../wix/typelib">TypeLib</a></dd>
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
        <td><a href="../wix/simple_type_guid">Guid</a></td>
        <td>GUID identifier for COM Interface.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>BaseInterface</td>
        <td><a href="../wix/simple_type_guid">Guid</a></td>
        <td>Identifies the interface from which the current interface is derived.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Name</td>
        <td>String</td>
        <td>Name for COM Interface.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>NumMethods</td>
        <td>Integer</td>
        <td>Number of methods implemented on COM Interface.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ProxyStubClassId</td>
        <td><a href="../wix/simple_type_guid">Guid</a></td>
        <td>GUID CLSID for proxy stub to COM Interface.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ProxyStubClassId32</td>
        <td><a href="../wix/simple_type_guid">Guid</a></td>
        <td>GUID CLSID for 32-bit proxy stub to COM Interface.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Versioned</td>
        <td><a href="../wix/simple_type_yesnotype">YesNoType</a></td>
        <td>Determines whether a Typelib version entry should be created with the other COM Interface registry keys.  Default is 'yes'.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>
  </dd>
</dl>
