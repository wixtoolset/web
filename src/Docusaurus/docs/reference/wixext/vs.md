---
sidebar_position: 60
---

# Visual Studio detection properties and custom actions

The WixToolset.VisualStudio.wixext WiX extension includes detection of Visual Studio and its components and custom actions for integrating into Visual Studio.

To use WixToolset.VisualStudio.wixext properties or custom actions, you need to add a reference to the WixToolset.VisualStudio.wixext NuGet package to your project.


## Using WixToolset.VisualStudio.wixext for Visual Studio 2003-2015

To use WixToolset.VisualStudio.wixext properties or custom actions for Visual Studio versions on end-user machines prior to Visual Studio 2017, add [`PropertyRef`](../schema/wxs/propertyref.md) or [`CustomActionRef`](../schema/wxs/customactionref.md) elements for properties or custom actions listed in the following tables that you want to use in your MSI. For example:

```xml
<PropertyRef Id="VS2005_ROOT_FOLDER" />
<CustomActionRef Id="VS2005Setup" />
```


## Using WixToolset.VisualStudio.wixext for Visual Studio 2017 and later

To use WixToolset.VisualStudio.wixext properties or custom actions for Visual Studio 2017 and later on end-user machines:

- Add the `http://wixtoolset.org/schemas/v4/wxs/vs` namespace to your WiX authoring.
- Add a [`FindVisualStudio` element](../schema/vs/findvisualstudio.md) to your authoring.
- Add [`PropertyRef`](../schema/wxs/propertyref.md) or [`CustomActionRef`](../schema/wxs/customactionref.md) elements for properties or custom actions listed in the following tables that you want to use in your MSI.

For example:

```xml
<Wix
    xmlns="http://wixtoolset.org/schemas/v4/wxs"
    xmlns:vs="http://wixtoolset.org/schemas/v4/wxs/vs">

  <Package>
    <vs:FindVisualStudio />
    <PropertyRef Id="VS2017DEVENV" />
    <PropertyRef Id="VS2019_IDE_VCSHARP_PROJECTSYSTEM_INSTALLED" />
    <PropertyRef Id="VS2022_ROOT_FOLDER" />
  </Package>
</Wix>
```


## Visual Studio 2003 properties and custom actions

| Property | Description |
| -------- | ----------- |
| VS2003DEVENV | Full path to devenv.exe for Visual Studio .NET 2003 if it is installed on the system. |
| JSHARP_REDIST_11_INSTALLED | Indicates whether the J# redistributable package 1.1 is installed on the system. |

| Custom action | Description |
| ------------- | ----------- |
| VS2003Setup | Runs devenv.exe /setup if a Visual Studio .NET 2003 edition is found on the system. |


## Visual Studio 2005 properties and custom actions

| Property | Description |
| -------- | ----------- |
| VS2005DEVENV | Full path to devenv.exe for Visual Studio 2005 if it is installed on the system. |
| VS2005_ITEMTEMPLATES_DIR | Full path to the Visual Studio 2005 item templates directory. |
| VS2005_PROJECTTEMPLATES_DIR | Full path to the Visual Studio 2005 project templates directory. |
| VS2005_SCHEMAS_DIR | Full path to the Visual Studio 2005 XML schemas directory. |
| VS2005PROJECTAGGREGATOR2 | Indicates whether the Visual Studio 2005 project aggregator for managed code add-ins is installed on the system. |
| VS2005_ROOT_FOLDER | Full path to the Visual Studio 2005 root installation directory. |
| VB2005EXPRESS_IDE | Full path to vbexpress.exe if Visual Basic 2005 Express Edition is installed on the system. |
| VS2005_IDE_VB_PROJECTSYSTEM_INSTALLED | Indicates whether Visual Studio 2005 Standard Edition or higher is installed and the Visual Basic project system is installed for it. |
| VC2005EXPRESS_IDE | Full path to vcexpress.exe if Visual C++ 2005 Express Edition is installed on the system. |
| VS2005_IDE_VC_PROJECTSYSTEM_INSTALLED | Indicates whether Visual Studio 2005 Standard Edition or higher is installed and the Visual C++ project system is installed for it. |
| VCSHARP2005EXPRESS_IDE | Full path to vcsexpress.exe if Visual C# 2005 Express Edition is installed on the system. |
| VS2005_IDE_VCSHARP_PROJECTSYSTEM_INSTALLED | Indicates whether Visual Studio 2005 Standard Edition or higher is installed and the Visual C# project system is installed for it. |
| VJSHARP2005EXPRESS_IDE | Full path to vjsexpress.exe if Visual J# 2005 Express Edition is installed on the system. |
| VS2005_IDE_VJSHARP_PROJECTSYSTEM_INSTALLED | Indicates whether Visual Studio 2005 Standard Edition or higher is installed and the Visual J# project system is installed for it. |
| VWD2005EXPRESS_IDE | Full path to vwdexpress.exe if Visual Web Developer 2005 Express Edition is installed on the system. |
| VS2005_IDE_VWD_PROJECTSYSTEM_INSTALLED | Indicates whether Visual Studio 2005 Standard Edition or higher is installed and the Visual Web Developer project system is installed for it. |
| VS2005_IDE_VSTS_TESTSYSTEM_INSTALLED | Indicates whether the Visual Studio Team Test project system is installed on the system. |
| VSEXTENSIONS_FOR_NETFX30_INSTALLED | Indicates whether the Visual Studio 2008 Development Tools for the .NET Framework 3.0 add-in for Visual Studio 2005 is installed on the system. |
| VS2005_WAP_PROJECT_INSTALLED | Indicates whether the Web Application Project template for Visual Studio 2005 is installed on the system. This project template is available as a standalone add-in and as a part of visual Studio 2005 SP1. |
| VS2005_SP_LEVEL | Indicates the service pack level for Visual Studio 2005 Standard Edition and higher. |
| VSTF2005_SP_LEVEL | Indicates the service pack level for Visual Studio 2005 Team Foundation. |
| VB2005EXPRESS_SP_LEVEL | Indicates the service pack level for Visual Basic 2005 Express Edition. |
| VC2005EXPRESS_SP_LEVEL | Indicates the service pack level for Visual C++ 2005 Express Edition. |
| VCSHARP2005EXPRESS_SP_LEVEL | Indicates the service pack level for Visual C# 2005 Express Edition. |
| VJSHARP2005EXPRESS_SP_LEVEL | Indicates the service pack level for Visual J# 2005 Express Edition. |
| VWD2005EXPRESS_SP_LEVEL | Indicates the service pack level for Visual Web Developer 2005 Express Edition. |
| DEXPLORE_2005_INSTALLED | Indicates whether the Document Explorer 2005 runtime components package is installed on the system. |
| JSHARP_REDIST_20_INSTALLED | Indicates whether the J# redistributable package 2.0 is installed on the system. |
| JSHARP_REDIST_20SE_INSTALLED | Indicates whether the J# redistributable package 2.0 second edition is installed on the system. |

| Custom action | Description |
| ------------- | ----------- |
| VS2005Setup | Runs devenv.exe /setup if Visual Studio 2005 Standard Edition or higher is found on the system. Including this custom action automatically adds the VS2005DEVENV property. |
| VS2005InstallVSTemplates | Runs devenv.exe /InstallVSTemplates if Visual Studio 2005 Standard Edition or higher is found on the system. Including this custom action automatically adds the VS2005DEVENV property. |
| VB2005Setup | Runs vbexpress.exe /setup if Visual Basic 2005 Express Edition is found on the system. Including this custom action automatically adds the VB2005EXPRESS_IDE property. |
| VB2005InstallVSTemplates | Runs vbexpress.exe /InstallVSTemplates if Visual Basic 2005 Express Edition is found on the system. Including this custom action automatically adds the VB2005EXPRESS_IDE property. |
| VC2005Setup | Runs vcexpress.exe /setup if Visual C++ 2005 Express Edition is found on the system. Including this custom action automatically adds the VC2005EXPRESS_IDE property. |
| VC2005InstallVSTemplates | Runs vcexpress.exe /InstallVSTemplates if Visual C++ 2005 Express Edition is found on the system. Including this custom action automatically adds the VC2005EXPRESS_IDE property. |
| VCSHARP2005Setup | Runs vcsexpress.exe /setup if Visual C# 2005 Express Edition is found on the system. Including this custom action automatically adds the VCSHARP2005EXPRESS_IDE property. |
| VCSHARP2005InstallVSTemplates | Runs vcsexpress.exe /InstallVSTemplates if Visual C# 2005 Express Edition is found on the system. Including this custom action automatically adds the VCSHARP2005EXPRESS_IDE property. |
| VJSHARP2005Setup | Runs vjsexpress.exe /setup if Visual J# 2005 Express Edition is found on the system. Including this custom action automatically adds the VJSHARP2005EXPRESS_IDE property. |
| VJSHARP2005InstallVSTemplates | Runs vjsexpress.exe /InstallVSTemplates if Visual J# 2005 Express Edition is found on the system. Including this custom action automatically adds the VJSHARP2005EXPRESS_IDE property. |
| VWD2005Setup | Runs vwdexpress.exe /setup if Visual Web Developer 2005 Express Edition is found on the system. Including this custom action automatically adds the VWD2005EXPRESS_IDE property. |
| VWD2005InstallVSTemplates | Runs vwdexpress.exe /InstallVSTemplates if Visual Web Developer 2005 Express Edition is found on the system. Including this custom action automatically adds the VWD2005EXPRESS_IDE property. |
 
 
## Visual Studio 2008 properties and custom actions

| Property | Description |
| -------- | ----------- |
| VS90DEVENV | Full path to devenv.exe for Visual Studio 2008 if it is installed on the system. |
| VS90_ITEMTEMPLATES_DIR | Full path to the Visual Studio 2008 item templates directory. |
| VS90_PROJECTTEMPLATES_DIR | Full path to the Visual Studio 2008 project templates directory. |
| VS90_SCHEMAS_DIR | Full path to the Visual Studio 2008 XML schemas directory. |
| VS90_ROOT_FOLDER | Full path to the Visual Studio 2008 root installation directory. |
| VB90EXPRESS_IDE | Full path to vbexpress.exe if Visual Basic 2008 Express Edition is installed on the system. |
| VS90_IDE_VB_PROJECTSYSTEM_INSTALLED | Indicates whether Visual Studio 2008 Standard Edition or higher is installed and the Visual Basic project system is installed for it. |
| VC90EXPRESS_IDE | Full path to vcexpress.exe if Visual C++ 2008 Express Edition is installed on the system. |
| VS90_IDE_VC_PROJECTSYSTEM_INSTALLED | Indicates whether Visual Studio 2008 Standard Edition or higher is installed and the Visual C++ project system is installed for it. |
| VCSHARP90EXPRESS_IDE | Full path to vcsexpress.exe if Visual C# 2008 Express Edition is installed on the system. |
| VS90_IDE_VCSHARP_PROJECTSYSTEM_INSTALLED | Indicates whether Visual Studio 2008 Standard Edition or higher is installed and the Visual C# project system is installed for it. |
| VWD90EXPRESS_IDE | Full path to vwdexpress.exe if Visual Web Developer 2008 Express Edition is installed on the system. |
| VS90_IDE_VWD_PROJECTSYSTEM_INSTALLED | Indicates whether Visual Studio 2008 Standard Edition or higher is installed and the Visual Web Developer project system is installed for it. |
| VS90_IDE_VSTS_TESTSYSTEM_INSTALLED | Indicates whether the Visual Studio Team Test project system is installed on the system. |
| VS90_BOOTSTRAPPER_PACKAGE_FOLDER | The location of the Visual Studio 2008 bootstrapper package folder. |
| VS90_SP1 | Indicates whether service pack 1 for Visual Studio 2008 Standard Edition and higher is installed. |
| VB90EXPRESS_SP1 | Indicates whether service pack 1 for Visual Basic 2008 Express Edition is installed. |
| VC90EXPRESS_SP1 | Indicates whether service pack 1 for Visual C++ 2008 Express Edition is installed. |
| VCSHARP90EXPRESS_SP1 | Indicates whether service pack 1 for Visual C# 2008 Express Edition is installed. |
| VWD90EXPRESS_SP1 | Indicates whether service pack 1 for Visual Web Developer 2008 Express Edition is installed. |
| DEXPLORE_2008_INSTALLED | Indicates whether the Document Explorer 2008 runtime components package is installed on the system. |
 
| Custom action | Description |
| ------------- | ----------- |
| VS90Setup | Runs devenv.exe /setup if Visual Studio 2008 Standard Edition or higher is found on the system. Including this custom action automatically adds the VS90DEVENV property. |
| VS90InstallVSTemplates | Runs devenv.exe /InstallVSTemplates if Visual Studio 2008 Standard Edition or higher is found on the system. Including this custom action automatically adds the VS90DEVENV property. |
| VB90Setup | Runs vbexpress.exe /setup if Visual Basic 2008 Express Edition is found on the system. Including this custom action automatically adds the VB90EXPRESS_IDE property. |
| VB90InstallVSTemplates | Runs vbexpress.exe /InstallVSTemplates if Visual Basic 2008 Express Edition is found on the system. Including this custom action automatically adds the VB90EXPRESS_IDE property. |
| VC90Setup | Runs vcexpress.exe /setup if Visual C++ 2008 Express Edition is found on the system. Including this custom action automatically adds the VC90EXPRESS_IDE property. |
| VC90InstallVSTemplates | Runs vcexpress.exe /InstallVSTemplates if Visual C++ 2008 Express Edition is found on the system. Including this custom action automatically adds the VC90EXPRESS_IDE property. |
| VCSHARP90Setup | Runs vcsexpress.exe /setup if Visual C# 2008 Express Edition is found on the system. Including this custom action automatically adds the VCSHARP90EXPRESS_IDE property. |
| VCSHARP90InstallVSTemplates | Runs vcsexpress.exe /InstallVSTemplates if Visual C# 2008 Express Edition is found on the system. Including this custom action automatically adds the VCSHARP90EXPRESS_IDE property. |
| VWD90Setup | Runs vwdexpress.exe /setup if Visual Web Developer 2008 Express Edition is found on the system. Including this custom action automatically adds the VWD90EXPRESS_IDE property. |
| VWD90InstallVSTemplates | Runs vwdexpress.exe /InstallVSTemplates if Visual Web Developer 2008 Express Edition is found on the system. Including this custom action automatically adds the VWD90EXPRESS_IDE property. |
 

## Visual Studio 2010 properties and custom actions

| Property | Description |
| -------- | ----------- |
| VS2010DEVENV | Full path to devenv.exe for Visual Studio 2010 if it is installed on the system. |
| VS2010_ITEMTEMPLATES_DIR | Full path to the Visual Studio 2010 item templates directory. |
| VS2010_PROJECTTEMPLATES_DIR | Full path to the Visual Studio 2010 project templates directory. |
| VS2010_SCHEMAS_DIR | Full path to the Visual Studio 2010 XML schemas directory. |
| VS2010_ROOT_FOLDER | Full path to the Visual Studio 2010 root installation directory. |
| VB2010EXPRESS_IDE | Full path to vbexpress.exe if Visual Basic 2010 Express Edition is installed on the system. |
| VS2010_IDE_VB_PROJECTSYSTEM_INSTALLED | Indicates whether Visual Studio 2010 Standard Edition or higher is installed and the Visual Basic project system is installed for it. |
| VC2010EXPRESS_IDE | Full path to vcexpress.exe if Visual C++ 2010 Express Edition is installed on the system. |
| VS2010_IDE_VC_PROJECTSYSTEM_INSTALLED | Indicates whether Visual Studio 2010 Standard Edition or higher is installed and the Visual C++ project system is installed for it. |
| VCSHARP2010EXPRESS_IDE | Full path to vcsexpress.exe if Visual C# 2010 Express Edition is installed on the system. |
| VS2010_IDE_VCSHARP_PROJECTSYSTEM_INSTALLED | Indicates whether Visual Studio 2010 Standard Edition or higher is installed and the Visual C# project system is installed for it. |
| VWD2010EXPRESS_IDE | Full path to vwdexpress.exe if Visual Web Developer 2010 Express Edition is installed on the system. |
| VS2010_IDE_VWD_PROJECTSYSTEM_INSTALLED | Indicates whether Visual Studio 2010 Standard Edition or higher is installed and the Visual Web Developer project system is installed for it. |
| VPD2010EXPRESS_IDE | Full path to vpdexpress.exe if Visual Studio 2010 Express for Windows Phone is installed on the system. |
| VS2010_IDE_VSTS_TESTSYSTEM_INSTALLED | Indicates whether the Visual Studio 2010 Team Test project system is installed on the system. |
| VS2010_IDE_DB_PROJECTSYSTEM_INSTALLED | Indicates whether the Visual Studio 2010 Database project system is installed on the system. |
| VS2010_IDE_VSD_PROJECTSYSTEM_INSTALLED | Indicates whether the Visual Studio 2010 Deployment project system (setup project) is installed on the system. |
| VS2010_IDE_WIX_PROJECTSYSTEM_INSTALLED | Indicates whether the Visual Studio 2010 Windows Installer XML project system is installed on the system. |
| VS2010_IDE_MODELING_PROJECTSYSTEM_INSTALLED | Indicates whether the Visual Studio 2010 Modeling project system is installed on the system. |
| VS2010_IDE_FSHARP_PROJECTSYSTEM_INSTALLED | Indicates whether the Visual Studio 2010 F# project system is installed on the system. |
| VS2010_BOOTSTRAPPER_PACKAGE_FOLDER | The location of the Visual Studio 2010 bootstrapper package folder. |
 
| Custom action | Description |
| ------------- | ----------- |
| VS2010Setup | Runs devenv.exe /setup if Visual Studio 2010 Standard Edition or higher is found on the system. Including this custom action automatically adds the VS2010DEVENV property. |
| VS2010InstallVSTemplates | Runs devenv.exe /InstallVSTemplates if Visual Studio 2010 Standard Edition or higher is found on the system. Including this custom action automatically adds the VS2010DEVENV property. |
| VB2010Setup | Runs vbexpress.exe /setup if Visual Basic 2010 Express Edition is found on the system. Including this custom action automatically adds the VB2010EXPRESS_IDE property. |
| VB2010InstallVSTemplates | Runs vbexpress.exe /InstallVSTemplates if Visual Basic 2010 Express Edition is found on the system. Including this custom action automatically adds the VB2010EXPRESS_IDE property. |
| VC2010Setup | Runs vcexpress.exe /setup if Visual C++ 2010 Express Edition is found on the system. Including this custom action automatically adds the VC2010EXPRESS_IDE property. |
| VC2010InstallVSTemplates | Runs vcexpress.exe /InstallVSTemplates if Visual C++ 2010 Express Edition is found on the system. Including this custom action automatically adds the VC2010EXPRESS_IDE property. |
| VCSHARP2010Setup | Runs vcsexpress.exe /setup if Visual C# 2010 Express Edition is found on the system. Including this custom action automatically adds the VCSHARP2010EXPRESS_IDE property. |
| VCSHARP2010InstallVSTemplates | Runs vcsexpress.exe /InstallVSTemplates if Visual C# 2010 Express Edition is found on the system. Including this custom action automatically adds the VCSHARP2010EXPRESS_IDE property. |
| VWD2010Setup | Runs vwdexpress.exe /setup if Visual Web Developer 2010 Express Edition is found on the system. Including this custom action automatically adds the VWD2010EXPRESS_IDE property. |
| VWD2010InstallVSTemplates | Runs vwdexpress.exe /InstallVSTemplates if Visual Web Developer 2010 Express Edition is found on the system. Including this custom action automatically adds the VWD2010EXPRESS_IDE property. |
| VPD2010Setup | Runs vpdexpress.exe /setup if Visual Studio 2010 Express for Windows Phone is found on the system. Including this custom action automatically adds the VPD2010EXPRESS_IDE property. |
| VPD2010InstallVSTemplates | Runs vpdexpress.exe /InstallVSTemplates if Visual Studio 2010 Express for Windows Phone is found on the system. Including this custom action automatically adds the VPD2010EXPRESS_IDE property. |
 

## Visual Studio 2012 properties and custom actions

| Property | Description |
| -------- | ----------- |
| VS2012DEVENV | Full path to devenv.exe for Visual Studio 2012 if it is installed on the system. |
| VS2012_EXTENSIONS_DIR | Full path to the Visual Studio 2012 extensions directory. |
| VS2012_ITEMTEMPLATES_DIR | Full path to the Visual Studio 2012 item templates directory. |
| VS2012_PROJECTTEMPLATES_DIR | Full path to the Visual Studio 2012 project templates directory. |
| VS2012_SCHEMAS_DIR | Full path to the Visual Studio 2012 XML schemas directory. |
| VS2012_ROOT_FOLDER | Full path to the Visual Studio 2012 root installation directory. |
| VS2012_IDE_VB_PROJECTSYSTEM_INSTALLED | Indicates whether Visual Studio 2012 Professional Edition or higher is installed and the Visual Basic project system is installed for it. |
| VS2012_IDE_VC_PROJECTSYSTEM_INSTALLED | Indicates whether Visual Studio 2012 Professional Edition or higher is installed and the Visual C++ project system is installed for it. |
| VS2012_IDE_VCSHARP_PROJECTSYSTEM_INSTALLED | Indicates whether Visual Studio 2012 Professional Edition or higher is installed and the Visual C# project system is installed for it. |
| VWD2012EXPRESS_IDE | Full path to vwdexpress.exe if Visual Studio Express 2012 for Web is installed on the system. |
| VPD2012EXPRESS_IDE | Full path to vpdexpress.exe if Visual Studio 2012 Express for Windows Phone is installed on the system. |
| VS2012_IDE_VWD_PROJECTSYSTEM_INSTALLED | Indicates whether Visual Studio 2012 Professional Edition or higher is installed and the Visual Web Developer project system is installed for it. |
| VS2012_IDE_VSTS_TESTSYSTEM_INSTALLED | Indicates whether the Visual Studio 2012 Team Test project system is installed on the system. |
| VS2012_IDE_DB_PROJECTSYSTEM_INSTALLED | Indicates whether the Visual Studio 2012 Database project system is installed on the system. |
| VS2012_IDE_WIX_PROJECTSYSTEM_INSTALLED | Indicates whether the Windows Installer XML project system is installed on the system for Visual Studio 2012. |
| VS2012_IDE_MODELING_PROJECTSYSTEM_INSTALLED | Indicates whether the Visual Studio 2012 Modeling project system is installed on the system. |
| VS2012_IDE_FSHARP_PROJECTSYSTEM_INSTALLED | Indicates whether the Visual Studio 2012 F# project system is installed on the system. |
| VS2012_BOOTSTRAPPER_PACKAGE_FOLDER | The location of the Visual Studio 2012 bootstrapper package folder. |

| Custom action | Description |
| ------------- | ----------- |
| VS2012Setup | Runs devenv.exe /setup if Visual Studio 2012 Professional Edition or higher is found on the system. Including this custom action automatically adds the VS2012DEVENV property. |
| VS2012InstallVSTemplates | Runs devenv.exe /InstallVSTemplates if Visual Studio 2012 Professional Edition or higher is found on the system. Including this custom action automatically adds the VS2012DEVENV property. |
| VWD2012Setup | Runs vwdexpress.exe /setup if Visual Studio Express 2012 for Web is found on the system. Including this custom action automatically adds the VWD2012EXPRESS_IDE property. |
| VWD2012InstallVSTemplates | Runs vwdexpress.exe /InstallVSTemplates if Visual Studio Express 2012 for Web is found on the system. Including this custom action automatically adds the VWD2012EXPRESS_IDE property. |
| VS2012WinExpressSetup | Runs vswinexpress.exe /setup if Visual Studio Express 2012 for Windows 8 is found on the system. Including this custom action automatically adds the VS2012WINEXPRESS_IDE property. |
| VS2012WinExpressInstallVSTemplates | Runs vswinexpress.exe /InstallVSTemplates if Visual Studio Express 2012 for Windows 8 is found on the system. Including this custom action automatically adds the VS2012WINEXPRESS_IDE property. |
| VPD2012Setup | Runs vpdexpress.exe /setup if Visual Studio 2012 Express for Windows Phone is found on the system. Including this custom action automatically adds the VPD2012EXPRESS_IDE property. |
| VPD2012InstallVSTemplates | Runs vpdexpress.exe /InstallVSTemplates if Visual Studio 2012 Express for Windows Phone is found on the system. Including this custom action automatically adds the VPD2012EXPRESS_IDE property. |
 

## Visual Studio 2013 properties and custom actions

| Property | Description |
| -------- | ----------- |
| VS2013DEVENV | Full path to devenv.exe for Visual Studio 2013 if it is installed on the system. |
| VS2013_EXTENSIONS_DIR | Full path to the Visual Studio 2013 extensions directory. |
| VS2013_ITEMTEMPLATES_DIR | Full path to the Visual Studio 2013 item templates directory. |
| VS2013_PROJECTTEMPLATES_DIR | Full path to the Visual Studio 2013 project templates directory. |
| VS2013_SCHEMAS_DIR | Full path to the Visual Studio 2013 XML schemas directory. |
| VS2013_ROOT_FOLDER | Full path to the Visual Studio 2013 root installation directory. |
| VS2013_IDE_VB_PROJECTSYSTEM_INSTALLED | Indicates whether Visual Studio 2013 Professional Edition or higher is installed and the Visual Basic project system is installed for it. |
| VS2013_IDE_VC_PROJECTSYSTEM_INSTALLED | Indicates whether Visual Studio 2013 Professional Edition or higher is installed and the Visual C++ project system is installed for it. |
| VS2013_IDE_VCSHARP_PROJECTSYSTEM_INSTALLED | Indicates whether Visual Studio 2013 Professional Edition or higher is installed and the Visual C# project system is installed for it. |
| VWD2013EXPRESS_IDE | Full path to vwdexpress.exe if Visual Studio Express 2013 for Web is installed on the system. |
| VS2013WINEXPRESS_IDE | Full path to vswinexpress.exe if Visual Studio Express 2013 for Windows is installed on the system. |
| VS2013WDEXPRESS_IDE | Full path to wdexpress.exe if Visual Studio Express 2013 for Windows Desktop is installed on the system. |
| VPD2013EXPRESS_IDE | Full path to vpdexpress.exe if Visual Studio 2013 Express for Windows Phone is installed on the system. |
| VS2013_IDE_VWD_PROJECTSYSTEM_INSTALLED | Indicates whether Visual Studio 2013 Professional Edition or higher is installed and the Visual Web Developer project system is installed for it. |
| VS2013_IDE_VSTS_TESTSYSTEM_INSTALLED | Indicates whether the Visual Studio 2013 Team Test project system is installed on the system. |
| VS2013_IDE_WIX_PROJECTSYSTEM_INSTALLED | Indicates whether the Windows Installer XML project system is installed on the system for Visual Studio 2013. |
| VS2013_IDE_MODELING_PROJECTSYSTEM_INSTALLED | Indicates whether the Visual Studio 2013 Modeling project system is installed on the system. |
| VS2013_IDE_FSHARP_PROJECTSYSTEM_INSTALLED | Indicates whether the Visual Studio 2013 F# project system is installed on the system. |
| VS2013_BOOTSTRAPPER_PACKAGE_FOLDER | The location of the Visual Studio 2013 bootstrapper package folder. |

| Custom action | Description |
| ------------- | ----------- |
| VS2013Setup | Runs devenv.exe /setup if Visual Studio 2013 Professional Edition or higher is found on the system. Including this custom action automatically adds the VS2013DEVENV property. |
| VS2013InstallVSTemplates | Runs devenv.exe /InstallVSTemplates if Visual Studio 2013 Professional Edition or higher is found on the system. Including this custom action automatically adds the VS2013DEVENV property. |
| VWD2013Setup | Runs vwdexpress.exe /setup if Visual Studio Express 2013 for Web is found on the system. Including this custom action automatically adds the VWD2013EXPRESS_IDE property. |
| VWD2013InstallVSTemplates | Runs vwdexpress.exe /InstallVSTemplates if Visual Studio Express 2013 for Web is found on the system. Including this custom action automatically adds the VWD2013EXPRESS_IDE property. |
| VS2013WinExpressSetup | Runs vswinexpress.exe /setup if Visual Studio Express 2013 for Windows 8 is found on the system. Including this custom action automatically adds the VS2013WINEXPRESS_IDE property. |
| VS2013WinExpressInstallVSTemplates | Runs vswinexpress.exe /InstallVSTemplates if Visual Studio Express 2013 for Windows 8 is found on the system. Including this custom action automatically adds the VS2013WINEXPRESS_IDE property. |
| VS2013WDExpressSetup | Runs WDExpress.exe /setup if Visual Studio Express 2013 for Windows Desktop is found on the system. Including this custom action automatically adds the VS2013WDEXPRESS_IDE property. |
| VS2013WDExpressInstallVSTemplates | Runs WDExpress.exe /InstallVSTemplates if Visual Studio Express 2013 for Windows Desktop is found on the system. Including this custom action automatically adds the VS2013WDEXPRESS_IDE property. |
| VPD2013Setup | Runs vpdexpress.exe /setup if Visual Studio 2013 Express for Windows Phone is found on the system. Including this custom action automatically adds the VPD2013EXPRESS_IDE property. |
| VPD2013InstallVSTemplates | Runs vpdexpress.exe /InstallVSTemplates if Visual Studio 2013 Express for Windows Phone is found on the system. Including this custom action automatically adds the VPD2013EXPRESS_IDE property. |


## Visual Studio 2015 properties and custom actions

| Property | Description |
| -------- | ----------- |
| VS2015DEVENV | Full path to devenv.exe for Visual Studio 2015 if it is installed on the system. |
| VS2015_EXTENSIONS_DIR | Full path to the Visual Studio 2015 extensions directory. |
| VS2015_ITEMTEMPLATES_DIR | Full path to the Visual Studio 2015 item templates directory. |
| VS2015_PROJECTTEMPLATES_DIR | Full path to the Visual Studio 2015 project templates directory. |
| VS2015_SCHEMAS_DIR | Full path to the Visual Studio 2015 XML schemas directory. |
| VS2015_ROOT_FOLDER | Full path to the Visual Studio 2015 root installation directory. |
| VS2015_IDE_VB_PROJECTSYSTEM_INSTALLED | Indicates whether Visual Studio 2015 Professional Edition or higher is installed and the Visual Basic project system is installed for it. |
| VS2015_IDE_VC_PROJECTSYSTEM_INSTALLED | Indicates whether Visual Studio 2015 Professional Edition or higher is installed and the Visual C++ project system is installed for it. |
| VS2015_IDE_VCSHARP_PROJECTSYSTEM_INSTALLED | Indicates whether Visual Studio 2015 Professional Edition or higher is installed and the Visual C# project system is installed for it. |
| VS2015_IDE_VWD_PROJECTSYSTEM_INSTALLED | Indicates whether Visual Studio 2015 Professional Edition or higher is installed and the Visual Web Developer project system is installed for it. |
| VS2015_IDE_VSTS_TESTSYSTEM_INSTALLED | Indicates whether the Visual Studio 2015 Team Test project system is installed on the system. |
| VS2015_IDE_MODELING_PROJECTSYSTEM_INSTALLED | Indicates whether the Visual Studio 2015 Modeling project system is installed on the system. |
| VS2015_IDE_FSHARP_PROJECTSYSTEM_INSTALLED | Indicates whether the Visual Studio 2015 F# project system is installed on the system. |
| VS2015_BOOTSTRAPPER_PACKAGE_FOLDER | The location of the Visual Studio 2015 bootstrapper package folder. |
 
| Custom action | Description |
| ------------- | ----------- |
| VS2015Setup | Runs devenv.exe /setup if Visual Studio 2015 Professional Edition or higher is found on the system. Including this custom action automatically adds the VS2013DEVENV property. |
| VS2015InstallVSTemplates | Runs devenv.exe /InstallVSTemplates if Visual Studio 2015 Professional Edition or higher is found on the system. Including this custom action automatically adds the VS2013DEVENV property. |


## Visual Studio 2017 properties and custom actions

| Property | Description |
| -------- | ----------- |
| VS2017DEVENV | Full path to devenv.exe for Visual Studio 2017 if it is installed on the system. |
| VS2017_EXTENSIONS_DIR | Full path to the Visual Studio 2017 extensions directory. |
| VS2017_ITEMTEMPLATES_DIR | Full path to the Visual Studio 2017 item templates directory. |
| VS2017_PROJECTTEMPLATES_DIR | Full path to the Visual Studio 2017 project templates directory. |
| VS2017_SCHEMAS_DIR | Full path to the Visual Studio 2017 XML schemas directory. |
| VS2017_ROOT_FOLDER | Full path to the Visual Studio 2017 root installation directory. |
| VS2017_IDE_DIR | Full path to the Visual Studio 2017 directory containing devenv.exe. |
| VS2017_IDE_VB_PROJECTSYSTEM_INSTALLED | Indicates whether Visual Studio 2017 Professional Edition or higher is installed and the Visual Basic project system is installed for it. |
| VS2017_IDE_VC_PROJECTSYSTEM_INSTALLED | Indicates whether Visual Studio 2017 Professional Edition or higher is installed and the Visual C++ project system is installed for it. |
| VS2017_IDE_VCSHARP_PROJECTSYSTEM_INSTALLED | Indicates whether Visual Studio 2017 Professional Edition or higher is installed and the Visual C# project system is installed for it. |
| VS2017_IDE_VWD_PROJECTSYSTEM_INSTALLED | Indicates whether Visual Studio 2017 Professional Edition or higher is installed and the Visual Web Developer project system is installed for it. |
| VS2017_IDE_VSTS_TESTSYSTEM_INSTALLED | Indicates whether the Visual Studio 2017 Team Test project system is installed on the system. |
| VS2017_IDE_MODELING_PROJECTSYSTEM_INSTALLED | Indicates whether the Visual Studio 2017 Modeling project system is installed on the system. |
| VS2017_IDE_FSHARP_PROJECTSYSTEM_INSTALLED | Indicates whether the Visual Studio 2017 F# project system is installed on the system. |
| VS2017_BOOTSTRAPPER_PACKAGE_FOLDER | The location of the Visual Studio 2017 bootstrapper package folder. |
 
| Custom action | Description |
| ------------- | ----------- |
| VS2017Setup | Runs devenv.exe /setup if Visual Studio 2017 Community Edition or higher is found on the system. Including this custom action automatically adds the VS2017DEVENV property. |
| VS2017InstallVSTemplates | Runs devenv.exe /InstallVSTemplates if Visual Studio 2017 Community Edition or higher is found on the system. Including this custom action automatically adds the VS2017DEVENV property. |


## Visual Studio 2019 properties and custom actions

| Property | Description |
| -------- | ----------- |
| VS2019DEVENV | Full path to devenv.exe for Visual Studio 2019 if it is installed on the system. |
| VS2019_EXTENSIONS_DIR | Full path to the Visual Studio 2019 extensions directory. |
| VS2019_ITEMTEMPLATES_DIR | Full path to the Visual Studio 2019 item templates directory. |
| VS2019_PROJECTTEMPLATES_DIR | Full path to the Visual Studio 2019 project templates directory. |
| VS2019_SCHEMAS_DIR | Full path to the Visual Studio 2019 XML schemas directory. |
| VS2019_ROOT_FOLDER | Full path to the Visual Studio 2019 root installation directory. |
| VS2019_IDE_DIR | Full path to the Visual Studio 2019 directory containing devenv.exe. |
| VS2019_IDE_VB_PROJECTSYSTEM_INSTALLED | Indicates whether Visual Studio 2019 Professional Edition or higher is installed and the Visual Basic project system is installed for it. |
| VS2019_IDE_VC_PROJECTSYSTEM_INSTALLED | Indicates whether Visual Studio 2019 Professional Edition or higher is installed and the Visual C++ project system is installed for it. |
| VS2019_IDE_VCSHARP_PROJECTSYSTEM_INSTALLED | Indicates whether Visual Studio 2019 Professional Edition or higher is installed and the Visual C# project system is installed for it. |
| VS2019_IDE_VWD_PROJECTSYSTEM_INSTALLED | Indicates whether Visual Studio 2019 Professional Edition or higher is installed and the Visual Web Developer project system is installed for it. |
| VS2019_IDE_VSTS_TESTSYSTEM_INSTALLED | Indicates whether the Visual Studio 2019 Team Test project system is installed on the system. |
| VS2019_IDE_MODELING_PROJECTSYSTEM_INSTALLED | Indicates whether the Visual Studio 2019 Modeling project system is installed on the system. |
| VS2019_IDE_FSHARP_PROJECTSYSTEM_INSTALLED | Indicates whether the Visual Studio 2019 F# project system is installed on the system. |
| VS2019_BOOTSTRAPPER_PACKAGE_FOLDER | The location of the Visual Studio 2019 bootstrapper package folder. |

| Custom action | Description |
| ------------- | ----------- |
| VS2019Setup | Runs devenv.exe /setup if Visual Studio 2019 Community Edition or higher is found on the system. Including this custom action automatically adds the VS2019DEVENV property. |
| VS2019InstallVSTemplates | Runs devenv.exe /InstallVSTemplates if Visual Studio 2019 Community Edition or higher is found on the system. Including this custom action automatically adds the VS2019DEVENV property. |


## Visual Studio 2022 properties and custom actions

| Property | Description |
| -------- | ----------- |
| VS2022DEVENV | Full path to devenv.exe for Visual Studio 2022 if it is installed on the system. |
| VS2022_EXTENSIONS_DIR | Full path to the Visual Studio 2022 extensions directory. |
| VS2022_ITEMTEMPLATES_DIR | Full path to the Visual Studio 2022 item templates directory. |
| VS2022_PROJECTTEMPLATES_DIR | Full path to the Visual Studio 2022 project templates directory. |
| VS2022_SCHEMAS_DIR | Full path to the Visual Studio 2022 XML schemas directory. |
| VS2022_ROOT_FOLDER | Full path to the Visual Studio 2022 root installation directory. |
| VS2022_IDE_DIR | Full path to the Visual Studio 2022 directory containing devenv.exe. |
| VS2022_IDE_VB_PROJECTSYSTEM_INSTALLED | Indicates whether Visual Studio 2022 Professional Edition or higher is installed and the Visual Basic project system is installed for it. |
| VS2022_IDE_VC_PROJECTSYSTEM_INSTALLED | Indicates whether Visual Studio 2022 Professional Edition or higher is installed and the Visual C++ project system is installed for it. |
| VS2022_IDE_VCSHARP_PROJECTSYSTEM_INSTALLED | Indicates whether Visual Studio 2022 Professional Edition or higher is installed and the Visual C# project system is installed for it. |
| VS2022_IDE_VWD_PROJECTSYSTEM_INSTALLED | Indicates whether Visual Studio 2022 Professional Edition or higher is installed and the Visual Web Developer project system is installed for it. |
| VS2022_IDE_VSTS_TESTSYSTEM_INSTALLED | Indicates whether the Visual Studio 2022 Team Test project system is installed on the system. |
| VS2022_IDE_MODELING_PROJECTSYSTEM_INSTALLED | Indicates whether the Visual Studio 2022 Modeling project system is installed on the system. |
| VS2022_IDE_FSHARP_PROJECTSYSTEM_INSTALLED | Indicates whether the Visual Studio 2022 F# project system is installed on the system. |
| VS2022_BOOTSTRAPPER_PACKAGE_FOLDER | The location of the Visual Studio 2022 bootstrapper package folder. |
 
| Custom action | Description |
| ------------- | ----------- |
| VS2022Setup | Runs devenv.exe /setup if Visual Studio 2022 Community Edition or higher is found on the system. Including this custom action automatically adds the VS2022DEVENV property. |
| VS2022InstallVSTemplates | Runs devenv.exe /InstallVSTemplates if Visual Studio 2022 Community Edition or higher is found on the system. Including this custom action automatically adds the VS2022DEVENV property. |

