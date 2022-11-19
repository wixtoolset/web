---
title: AdvertiseExecuteSequence Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>None</dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa367551.aspx" target="_blank">AdvtExecuteSequence Table</a>
  </dd>
  <dt>Parents</dt>
  <dd>
    <a href="../fragment/">Fragment</a>, <a href="../module/">Module</a>, <a href="../product/">Product</a></dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../costfinalize/">CostFinalize</a> (min: 0, max: unbounded): Ends the internal installation costing process begun by the CostInitialize action.</li><li><a href="../costinitialize/">CostInitialize</a> (min: 0, max: unbounded): Initiates the internal installation costing process.</li><li><a href="../createshortcuts/">CreateShortcuts</a> (min: 0, max: unbounded): Manages the creation of shortcuts.</li><li><a href="../custom/">Custom</a> (min: 0, max: unbounded): Use to sequence a custom action.  The only custom actions that are allowed in the AdvtExecuteSequence are type 19 (0x013) type 35 (0x023) and type 51 (0x033).</li><li><a href="../installfinalize/">InstallFinalize</a> (min: 0, max: unbounded): Marks the end of a sequence of actions that change the system.</li><li><a href="../installinitialize/">InstallInitialize</a> (min: 0, max: unbounded): Marks the beginning of a sequence of actions that change the system.</li><li><a href="../installvalidate/">InstallValidate</a> (min: 0, max: unbounded): Verifies that all costed volumes have enough space for the installation.</li><li><a href="../msipublishassemblies/">MsiPublishAssemblies</a> (min: 0, max: unbounded): Manages the advertisement of CLR and Win32 assemblies.</li><li><a href="../publishcomponents/">PublishComponents</a> (min: 0, max: unbounded): Manages the advertisement of the components from the PublishComponent table.</li><li><a href="../publishfeatures/">PublishFeatures</a> (min: 0, max: unbounded): Writes each feature's state into the system registry.</li><li><a href="../publishproduct/">PublishProduct</a> (min: 0, max: unbounded): Manages the advertisement of the product information with the system.</li><li><a href="../registerclassinfo/">RegisterClassInfo</a> (min: 0, max: unbounded): Manages the registration of COM class information with the system.</li><li><a href="../registerextensioninfo/">RegisterExtensionInfo</a> (min: 0, max: unbounded): Manages the registration of extension related information with the system.</li><li><a href="../registermimeinfo/">RegisterMIMEInfo</a> (min: 0, max: unbounded): Registers MIME-related registry information with the system.</li><li><a href="../registerprogidinfo/">RegisterProgIdInfo</a> (min: 0, max: unbounded): Manages the registration of OLE ProgId information with the system.</li></ul></dd>
  <dt>Attributes</dt>
  <dd>None</dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Wix Schema</a>
  </dd>
</dl>
