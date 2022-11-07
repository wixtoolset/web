---
title: FileSearch Element (Util Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>Describes a file search.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../wix/bundle">Bundle</a>, <a href="../wix/fragment">Fragment</a></dd>
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
        <td>Id</td>
        <td>String</td>
        <td>Id of the search for ordering and dependency.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Path</td>
        <td>String</td>
        <td>File path to search for.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Result</td>
        <td>Enumeration</td>
        <td>                         Rather than saving the matching file path into the variable, a FileSearch can save an attribute of the matching file instead.                       This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>exists</dfn></dt><dd>Saves true if a matching file is found; false otherwise.</dd><dt class="enumerationValue"><dfn>version</dfn></dt><dd>Saves the version information for files that have it (.exe, .dll); zero-version (0.0.0.0) otherwise.</dd></dl></td>
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
    <a href="../util">Util Schema</a>
  </dd>
</dl>
