---
title: HelpCollection Element (Vs Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>                 Help Namespace for a help collection.  The parent file is the key for the HxC (Collection) file.             </dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../../wix/file/">File</a>
  </dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../../vs/helpfileref" class="extension">HelpFileRef</a> (min: 0, max: unbounded)</li><li><a href="../../vs/helpfilterref" class="extension">HelpFilterRef</a> (min: 0, max: unbounded)</li><li><a href="../../vs/plugcollectioninto" class="extension">PlugCollectionInto</a> (min: 0, max: unbounded)</li></ul></dd>
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
        <td>Primary Key for HelpNamespace.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Description</td>
        <td>String</td>
        <td>Friendly name for Namespace.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Name</td>
        <td>String</td>
        <td>Internal Microsoft Help ID for this Namespace.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>SuppressCustomActions</td>
        <td><a href="../../vs/simple_type_yesnotype">YesNoType</a></td>
        <td>Suppress linking Help registration custom actions.  Help redistributable merge modules will be required.  Use this when building a merge module.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Vs Schema</a>
  </dd>
</dl>
