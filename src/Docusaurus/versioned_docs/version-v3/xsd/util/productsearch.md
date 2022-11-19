---
title: ProductSearch Element (Util Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>Describes a product search.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../../wix/bundle/">Bundle</a>, <a href="../../wix/fragment/">Fragment</a></dd>
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
        <td>After</td>
        <td>String</td>
        <td>Id of the search that this one should come after.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Condition</td>
        <td>String</td>
        <td>Condition for evaluating the search. If this evaluates to false, the search is not executed at all.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Guid</td>
        <td>String</td>
        <td>The Guid attribute has been deprecated; use the ProductCode or UpgradeCode attribute instead. If this attribute is used, it is assumed to be a ProductCode.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Id</td>
        <td>String</td>
        <td>Id of the search for ordering and dependency.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ProductCode</td>
        <td>String</td>
        <td>The ProductCode to use for the search. This attribute must be omitted if UpgradeCode is specified.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Result</td>
        <td>Enumeration</td>
        <td>                         Rather than saving the product version into the variable, a ProductSearch can save another attribute of the matching product instead.                       This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>version</dfn></dt><dd>Saves the version of a matching product if found; 0.0.0.0 otherwise. This is the default.</dd><dt class="enumerationValue"><dfn>language</dfn></dt><dd>Saves the language of a matching product if found; empty otherwise.</dd><dt class="enumerationValue"><dfn>state</dfn></dt><dd>Saves the state of the product: advertised (1), absent (2), or locally installed (5).</dd><dt class="enumerationValue"><dfn>assignment</dfn></dt><dd>Saves the assignment type of the product: per-user (0), or per-machine (1).</dd></dl></td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>UpgradeCode</td>
        <td>String</td>
        <td>The UpgradeCode to use for the search. This attribute must be omitted if ProductCode is specified. Note that if multiple products are found, the highest versioned product will be used for the result.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Variable</td>
        <td>String</td>
        <td>Name of the variable in which to place the result of the search.</td>
        <td>Yes</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Util Schema</a>
  </dd>
</dl>
