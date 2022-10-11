---
title: RemoveFolderEx Element (Util Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>               Remove a folder and all contained files and folders if the parent component is selected for installation or removal.               The folder must be specified in the Property attribute as the name of a property that will have a value that resolves                to the full path of the folder before the CostInitialize action. Note that Directory ids cannot be used.                For more details, see the Remarks.           </dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa371201.aspx" target="_blank">RemoveFile Table</a>
  </dd>
  <dt>Parents</dt>
  <dd>
    <a href="../wix/component">Component</a>
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
        <td>Primary key used to identify this particular entry. If this is not specified, a stable identifier                   will be generated at compile time based on the other attributes.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>On</td>
        <td>Enumeration</td>
        <td>                       This value determines when the folder may be removed.                     This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>install</dfn></dt><dd>                                   Removes the folder only when the parent component is being installed (msiInstallStateLocal or msiInstallStateSource).                               </dd><dt class="enumerationValue"><dfn>uninstall</dfn></dt><dd>                                   Default: Removes the folder only when the parent component is being removed (msiInstallStateAbsent).                               </dd><dt class="enumerationValue"><dfn>both</dfn></dt><dd>                                   Removes the folder when the parent component is being installed or removed.                               </dd></dl></td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Property</td>
        <td>String</td>
        <td>                       The id of a property that resolves to the full path of the source directory.  The property does not have                       to exist in the installer database at creation time; it could be created at installation time by a custom                       action, on the command line, etc. The property value can contain environment variables surrounded by                        percent signs such as from a REG_EXPAND_SZ registry value; environment variables will be expanded before                        being evaluated for a full path.                   </td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>Remarks</dt>
  <dd><p>The custom action that implements RemoveFolderEx does so by writing temporary rows to the RemoveFile table                 for each subfolder of the root folder you specify. Because it might dramatically affect Windows Installer's                 <a href="http://msdn.microsoft.com/en-us/library/aa368593.aspx">File Costing</a>,                  the temporary rows must be written before the CostInitialize standard action. Unfortunately, MSI doesn't                 create properties for the Directory hierarchy in your package until later, in the CostFinalize action.</p><p>An easy workaround for a typical use case of removing a folder during uninstall is to write the directory                 path to the registry and to load it during uninstall. See                  <a href="http://robmensching.com/blog/posts/2010/5/2/the-wix-toolsets-remember-property-pattern">The WiX toolset's "Remember Property" pattern</a>                 for an example.</p><p>If you use custom actions to set properties, ensure that they are scheduled before the WixRemoveFoldersEx custom action.</p></dd>
  <dt>See Also</dt>
  <dd>
    <a href="../util">Util Schema</a>
  </dd>
</dl>
