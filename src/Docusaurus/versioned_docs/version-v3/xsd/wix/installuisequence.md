---
title: InstallUISequence Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>None</dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa369543.aspx" target="_blank">InstallUISequence Table</a>
  </dd>
  <dt>Parents</dt>
  <dd>
    <a href="../wix/fragment">Fragment</a>, <a href="../wix/module">Module</a>, <a href="../wix/product">Product</a>, <a href="../wix/ui">UI</a></dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../wix/appsearch">AppSearch</a> (min: 0, max: unbounded): Uses file signatures to search for existing versions of products.</li><li><a href="../wix/ccpsearch">CCPSearch</a> (min: 0, max: unbounded): Uses file signatures to validate that qualifying products are installed on a system before an upgrade installation is performed.</li><li><a href="../wix/costfinalize">CostFinalize</a> (min: 0, max: unbounded): Ends the internal installation costing process begun by the CostInitialize action.</li><li><a href="../wix/costinitialize">CostInitialize</a> (min: 0, max: unbounded): Initiates the internal installation costing process.</li><li><a href="../wix/custom">Custom</a> (min: 0, max: unbounded): Use to sequence a custom action.</li><li><a href="../wix/executeaction">ExecuteAction</a> (min: 0, max: unbounded): Initiates the execution sequence.</li><li><a href="../wix/filecost">FileCost</a> (min: 0, max: unbounded): Initiates dynamic costing of standard installation actions.</li><li><a href="../wix/findrelatedproducts">FindRelatedProducts</a> (min: 0, max: unbounded): Runs through each record of the Upgrade table in sequence and compares the upgrade code, product version, and language in each row to products installed on the system.</li><li><a href="../wix/isolatecomponents">IsolateComponents</a> (min: 0, max: unbounded): Installs a copy of a component (commonly a shared DLL) into a private location for use by a specific application (typically an .exe).</li><li><a href="../wix/launchconditions">LaunchConditions</a> (min: 0, max: unbounded): Queries the LaunchCondition table and evaluates each conditional statement recorded there.</li><li><a href="../wix/migratefeaturestates">MigrateFeatureStates</a> (min: 0, max: unbounded): Used for upgrading or installing over an existing application.</li><li><a href="../wix/resolvesource">ResolveSource</a> (min: 0, max: unbounded): Determines the location of the source and sets the SourceDir property if the source has not been resolved yet.</li><li><a href="../wix/rmccpsearch">RMCCPSearch</a> (min: 0, max: unbounded): Uses file signatures to validate that qualifying products are installed on a system before an upgrade installation is performed.</li><li><a href="../wix/schedulereboot">ScheduleReboot</a> (min: 0, max: unbounded): Prompts the user to restart the system at the end of installation. Not fixed sequence.</li><li><a href="../wix/show">Show</a> (min: 0, max: unbounded): Displays a Dialog.</li><li><a href="../wix/validateproductid">ValidateProductID</a> (min: 0, max: unbounded): Sets the ProductID property to the full product identifier.</li></ul></dd>
  <dt>Attributes</dt>
  <dd>None</dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>
  </dd>
</dl>
