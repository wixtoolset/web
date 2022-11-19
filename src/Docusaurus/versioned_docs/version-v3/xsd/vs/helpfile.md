---
title: HelpFile Element (Vs Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>                 File for Help Namespace.  The parent file is the key for HxS (Title) file.             </dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../../wix/file/">File</a>
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
        <td>Primary Key for HelpFile Table.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>AttributeIndex</td>
        <td>String</td>
        <td>Key for HxR (Attributes) file.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Index</td>
        <td>String</td>
        <td>Key for HxI (Index) file.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Language</td>
        <td>Integer</td>
        <td>Language ID for content file.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Name</td>
        <td>String</td>
        <td>Internal Microsoft Help ID for this HelpFile.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>SampleLocation</td>
        <td>String</td>
        <td>Key for a file that is in the "root" of the samples directory for this HelpFile.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Search</td>
        <td>String</td>
        <td>Key for HxQ (Query) file.</td>
        <td>&nbsp;</td>
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
