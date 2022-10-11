---
title: Mutation Element (Lux Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>               Test mutations let you author unit tests with different expected results. The mutation                id is passed as the value of the WIXLUX_RUNNING_MUTATION property. Your custom action,                typically in an '#ifdef DEBUG' block, can retrieve the WIXLUX_RUNNING_MUTATION property                and hard-code different behavior based on the mutation. To author test mutations, use                the Mutation element with UnitTest elements as children.                         </dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../wix/fragment">Fragment</a>
  </dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../lux/unittest" class="extension">UnitTest</a> (min: 0, max: unbounded)</li></ul></dd>
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
        <td>                         Value of the WIXLUX_RUNNING_MUTATION property set by the mutation.                     </td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../lux">Lux Schema</a>
  </dd>
</dl>
