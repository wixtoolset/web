---
title: PlugCollectionInto Element (Vs Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>Plugin for Help Namespace.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../../vs/helpcollection" class="extension">HelpCollection</a>
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
        <td>Attributes</td>
        <td>String</td>
        <td>Key for HxA (Attributes) file of child namespace.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>SuppressExternalNamespaces</td>
        <td><a href="../../vs/simple_type_yesnotype">YesNoType</a></td>
        <td>Suppress linking Visual Studio Help namespaces.  Help redistributable merge modules will be required.  Use this when building a merge module.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>TableOfContents</td>
        <td>String</td>
        <td>Key for HxT  file of child namespace.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>TargetCollection</td>
        <td>String</td>
        <td>                     Foriegn Key into HelpNamespace table for the parent namespace into which the child will be inserted.                     The following special keys can be used to plug into external namespaces defined outside of the installer.                       MS_VSIPCC_v80 : Visual Studio 2005                       MS.VSIPCC.v90 : Visual Studio 2008                 </td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>TargetFeature</td>
        <td>String</td>
        <td>Key for the feature parent of this help collection.  Required only when plugging into external namespaces.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>TargetTableOfContents</td>
        <td>String</td>
        <td>Key for HxT  file of parent namespace that now includes the new child namespace.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Vs Schema</a>
  </dd>
</dl>
