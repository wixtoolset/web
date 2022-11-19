---
title: AdminExecuteSequence Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>None</dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa367540.aspx" target="_blank">AdminExecuteSequence Table</a>
  </dd>
  <dt>Parents</dt>
  <dd>
    <a href="../fragment/">Fragment</a>, <a href="../module/">Module</a>, <a href="../product/">Product</a></dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../costfinalize/">CostFinalize</a> (min: 0, max: unbounded): Ends the internal installation costing process begun by the CostInitialize action.</li><li><a href="../costinitialize/">CostInitialize</a> (min: 0, max: unbounded): Initiates the internal installation costing process.</li><li><a href="../custom/">Custom</a> (min: 0, max: unbounded): Use to sequence a custom action.</li><li><a href="../filecost/">FileCost</a> (min: 0, max: unbounded): Initiates dynamic costing of standard installation actions.</li><li><a href="../installadminpackage/">InstallAdminPackage</a> (min: 0, max: unbounded): Copies the product database to the administrative installation point.</li><li><a href="../installfiles/">InstallFiles</a> (min: 0, max: unbounded): Copies files specified in the File table from the source directory to the destination directory.</li><li><a href="../installfinalize/">InstallFinalize</a> (min: 0, max: unbounded): Marks the end of a sequence of actions that change the system.</li><li><a href="../installinitialize/">InstallInitialize</a> (min: 0, max: unbounded): Marks the beginning of a sequence of actions that change the system.</li><li><a href="../installvalidate/">InstallValidate</a> (min: 0, max: unbounded): Verifies that all costed volumes have enough space for the installation.</li><li><a href="../launchconditions/">LaunchConditions</a> (min: 0, max: unbounded): Queries the LaunchCondition table and evaluates each conditional statement recorded there.</li><li><a href="../patchfiles/">PatchFiles</a> (min: 0, max: unbounded): Queries the Patch table to determine which patches are to be applied.</li><li><a href="../resolvesource/">ResolveSource</a> (min: 0, max: unbounded): Determines the location of the source and sets the SourceDir property if the source has not been resolved yet.</li></ul></dd>
  <dt>Attributes</dt>
  <dd>None</dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Wix Schema</a>
  </dd>
</dl>
