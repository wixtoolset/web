---
wip: 5433
type: Feature
by: Heath Stewart (heaths at microsoft.com)
title: Add support to detect and install VSIX packages into VS15
---

## User stories

* As a developer I can detect if VS2017 (VS15) is installed and, if needed, where it is installed.
* As a developer I can declare required workloads that must be installed to install my VSIX package.
* As a developer I can install my extension into multiple instances of VS2017.

## Background

VS2017 deployment was redesigned from the ground up to be lighter and allow for multiple instances to be installed.
The default installation - providing faster start times, syntax highlighting of many languages, and more - is evidence of this.

However, to achieve this a number of features were changed, and use of Windows Installer packages and even registry entries
were drastically reduced. As such, no longer will simple registry, component, or file system searches work. The _WixVSExtension_
will need to be updated to work with VS2017.

## Proposal

A fast [COM API][API] was created to enumerate products installed by the new deployment engine. This does mean that a custom action
will need to be executed to set properties. The in ability to create an instance of the COM class - when `CoCreateInstance` returns
`REGDB_E_CLASSNOTREG` - means that no instances are installed in a supported manner.

The existing _VS15.wxs_ will be updated with the information below, and a near-copy created named _VS2017.wxs_ now that marketing
has made the name public.

### Properties

Given how the existing VS-related properties from the _WixVSExtension_ are used and limitations in how Windows Installer works
with properties, the properties defined for VS2017 can only point to one location. For most end users this is expected to be fine.
However, there is currently no concept of a "default instance". Instead, the highest constrained version (e.g. the highest 15.0
for VS15) and the latest if multiple instances of the same version (i.e. most recently installed) will be used.

To get the root `VS15_ROOT_FOLDER`, the custom action will enumerate instances searching for one or more of the following product IDs.

* Microsoft.VisualStudio.Product.Enterprise
* Microsoft.VisualStudio.Product.Professional
* Microsoft.VisualStudio.Product.Community

The custom action will be scheduled before `AppSearch` so that existing `DirectorySearch` elements can be used to find
sub-folders for properties:

* `VS15_EXTENSIONS_DIR`
* `VS15_PROJECTTEMPLATES_DIR`
* `VS15_SCHEMAS_DIR`
* `VS15_ITEMTEPLATES_DIR`
* `VS15_BOOTSTRAPPER_PACKAGE_FOLDER`
* `VS15DEVENV`

With the `VS15DEVENV` property set, the following custom action definitions should continue to work as defined.

* `VS15Setup`
* `VS15InstallVSTemplates`

Project system properties will be supported by detecting the related component IDs.

Property                                    | Component ID
--------------------------------------------|-------------
`VS15_IDE_VC_PROJECTSYSTEM_INSTALLED`       | Microsoft.VisualStudio.Component.VC.CoreIde
`VS15_IDE_VCSHARP_PROJECTSYSTEM_INSTALLED`  | Microsoft.VisualStudio.Component.Roslyn.LanguageServices
`VS15_IDE_VB_PROJECTSYSTEM_INSTALLED`       | Microsoft.VisualStudio.Component.Roslyn.LanguageServices
`VS15_IDE_FSHARP_PROJECTSYSTEM_INSTALLED`   | Microsoft.VisualStudio.Component.FSharp
`VS15_IDE_MODELING_PROJECTSYSTEM_INSTALLED` | Microsoft.VisualStudio.PackageGroup.DslRuntime
`VS15_IDE_VSTS_TESTSYSTEM_INSTALLED`        | Microsoft.VisualStudio.Component.TestTools.Core
`VS15_IDE_VWD_PROJECTSYSTEM_INSTALLED`      | Microsoft.VisualStudio.Component.Web

Note there is no separate component for the modeling tools (DSL). This ID could change in the future.

### VsixPackage Custom Actions

The _VSIXInstaller.exe_ program now works with the nw setup engine to install VSIX v3 extensions, which are similar to VSIX v2s
but contain a partial installer manifest that allows developers to declare dependencies on existing components or entire workloads,
or to other extensions already installed. VSIX 2 packages will work with VS2015 and below as normal, and VSIX v3 containers
can contain the _extension.vsixmanifest_ file they did before to support both VS2015 and older, and VS2017.

Authoring `VsixPackage` elements will not **require** changes; however, the custom action proposed here will have to find its location.
At the time of this writing, _VSIXInstaller.exe_ still installs under the VS installation path but will be moving to the setup engine.
To support both scenarios, the custom action will:

1. Enumerate instances and call `ISetupInstance::ResolvePath` passing "Common7\IDE\VSIXInstaller.exe".
2. Enumerate the instances and get the setup engine root folder, then combine with "VSIXInstaller.exe".

By default, calling _VSIXInstaller.exe_ without specifying an instance will install the extension into all instances.
This is consistent with previous behavior when only one "instance" of VS could be installed and will continue to be the default.
Because there is no way to prompt the user to pick which instance(s) in which the extension will be installed that works with both
bare MSIs and Burn bundles, and that works in silent mode, the end user will not be able to pick instances.

This does mean that installing an extension with a lot of dependencies could install a lot of components into end users'
installations. Responsibility is on the extension developer to make sure they depend on only what is required.

The previous custom actions used to schedule _VSIXInstaller.exe_ that currently exist in _VS15.wxs_ will be updated to not pass
`/skuName` or `/skuVersion`.

## Considerations

The following sections are from discussions within Microsoft for issues we have considered but seek feedback from the community.
These could be done incrementally after the base feature work proposed above.

### Installing extensions only into compatible instances

We could support developer-driven selection for into which instances an extension is installed, but it would require adding custom
actions at install time with the proposed custom action. _VSIXInstaller.exe_ can be passed an instance ID so we could allow
for the optional authoring of features required to already be installed so that installing an extension does not install dependencies.

1. Add a table to capture which `VsixPackage` requires which component or workload IDs. This will map the `File` attribute value
   to each required component or workload ID.
2. Add child elements to `VsixPackage` to specify dependencies that will populate the table.
3. Author deferred custom actions that will invoke _VSIXInstaller.exe_ using properties passed via `CustomActionData`.
4. The custom action will find compatible instances and for each call `WcaDoDeferredAction` to set the `CustomActionData`
   and call this new custom action to invoke _VSIXInstaller.exe_ specifically for that instance.

The concern was that this could mean the VSIX package is not installed at all if the user does not have an instance that contains
all required component or workload IDs. If we fail to enumerate any compatible instances, however, we could optionally fail with an
error indicating that the VSIX package was not installed. This could be denoted by using the existing `Vital` attribute of the
`VsixPackage` which defaults to `yes`.

### Selecting instances into which an extension is installed

While there is no universal way to prompt a user to select instances based on some criteria that works with both bare MSIs
and Burn bundles, we could provide the ability for bootstrapper applications (BA) to do this.
The proposed immediate custom action could send a message containing instance IDs, product IDs, and localized display names
based on the `ProductLanguage` (falling back to "en-US"). If the BA handles this message it could set a public property
containing semicolon-delimited instance IDs - also settable on the command line - that the immediate scheduling custom action
proposed in the previous section could use to schedule _VSIXInstaller.exe_.

It is questionable, however, how many BAs would conform. A BA for VS extensions could be written in similar fashion to
"WixStdBA" that developers could use directly or as a base for their own derivations.

## See Also

* [WIXFEAT:5433 - Add support to detect and install VSIX packages into VS15](https://github.com/wixtoolset/issues/issues/5433)
* [Changes to Visual Studio "15" Setup][API]
* [Extensibility in Visual Studio "15": Increasing Reliability and Performance](https://blogs.msdn.microsoft.com/visualstudio/2016/11/10/extensibility-in-visual-studio-15-increasing-reliability-and-performance/)

  [API]: https://blogs.msdn.microsoft.com/heaths/2016/09/15/changes-to-visual-studio-15-setup/