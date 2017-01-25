---
wip: 5433
type: Feature
by: Heath Stewart (heaths at microsoft.com)
title: Add support to detect and install VSIX packages into VS2017
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

Because VSIX extensions can be installed to different instances with different workloads and/or components installed, more of the
process to install extensions will move to install time.

The existing _VS15.wxs_ will be removed since it did not work with any public pre-releases of VS2017, and will be replaced by a new
_VS2017.wxs_ file. Packages using _VS15.wxs_ will fail to link and will need to update references to _VS2017.wxs_.

### Properties

Given how the existing VS-related properties from the _WixVSExtension_ are used and limitations in how Windows Installer works
with properties, the properties defined for VS2017 can only point to one location. For most end users this is expected to be fine.
However, there is currently no concept of a "default instance". Instead, the highest constrained version (e.g. the highest 15.0
for VS2017) and the latest if multiple instances of the same version (i.e. most recently installed) will be used.

To get the root `VS2017_ROOT_FOLDER`, the custom action will enumerate instances searching for one or more of the following product IDs.

* Microsoft.VisualStudio.Product.Enterprise
* Microsoft.VisualStudio.Product.Professional
* Microsoft.VisualStudio.Product.Community

The custom action will be scheduled before `AppSearch` so that existing `DirectorySearch` elements can be used to find
sub-folders for properties:

* `VS2017_EXTENSIONS_DIR`
* `VS2017_PROJECTTEMPLATES_DIR`
* `VS2017_SCHEMAS_DIR`
* `VS2017_ITEMTEPLATES_DIR`
* `VS2017_BOOTSTRAPPER_PACKAGE_FOLDER`
* `VS2017DEVENV`

With the `VS2017DEVENV` property set, the following custom action definitions should continue to work as defined.

* `VS2017Setup`
* `VS2017InstallVSTemplates`

Project system properties will be supported by detecting the related component IDs.

Property                                      | Component ID
--------                                      | ------------
`VS2017_IDE_VC_PROJECTSYSTEM_INSTALLED`       | Microsoft.VisualStudio.Component.VC.CoreIde
`VS2017_IDE_VCSHARP_PROJECTSYSTEM_INSTALLED`  | Microsoft.VisualStudio.Component.Roslyn.LanguageServices
`VS2017_IDE_VB_PROJECTSYSTEM_INSTALLED`       | Microsoft.VisualStudio.Component.Roslyn.LanguageServices
`VS2017_IDE_FSHARP_PROJECTSYSTEM_INSTALLED`   | Microsoft.VisualStudio.Component.FSharp
`VS2017_IDE_MODELING_PROJECTSYSTEM_INSTALLED` | Microsoft.VisualStudio.PackageGroup.DslRuntime
`VS2017_IDE_VSTS_TESTSYSTEM_INSTALLED`        | Microsoft.VisualStudio.Component.TestTools.Core
`VS2017_IDE_VWD_PROJECTSYSTEM_INSTALLED`      | Microsoft.VisualStudio.Component.Web

Note there is no separate component for the modeling tools (DSL). This ID could change in the future.

A new property `VS_INSTANCES_ID` will be supported and represents a comma-delimited list of instance IDs. End users via the command line
or BAs could discover instance IDs ahead of time to determine this list and pass this property to the MSI. Because this is an explicit action,
it is assumed that the client is taking responsibility for selection and this value will override all `ActionProperty` properties as described below.
This will be defined at build time as a secure custom property, but will not be defined in the `Property` table specifically.

Because the `ActionProperty` properties will also be secure custom properties, clients can also pass different instance IDs to each property
individually if required and instead of `VS_INSTANCE_IDS`. While supported, this is not assumed to be atypical.

### Elements

The `VsixPackage` table will be updated to support authoring of an optional `Id` attribute. If not specified, this will be generated
using the `GenerateIdentifier` method accepting "vsx" as the prefix, and the component ID and file ID as input. This `Id` attribute
is used to relate the package to workload and component package IDs on which the package depends. This information could also be harvested.

The existing `Target` and `TargetVersion` attributes can still be specified but are ignored when the `/instanceIds` switch is passed
to _VSIXInstaller.exe_. This will maintain backward compatibility for the custom actions with older versions of VS if VS2017 or newer is not installed.

The existing `Vital` attribute will also be stored in a new `VsixPackage` table as described below to keep track of which packages require instances.
Packages that are not vital will not cause the installation to err if no compatible instances are found. This is analogous to existing behavior with
older versions of VS if a package failed to install, which could be because it is not compatible with an edition and was not authored appropriately.

A new, optional `ActionProperty` attribute is added. If not specified, this will be the uppercase version of the `Id` attribute which is a valid
property ID. This property will be added to the secure custom properties list because it can be passed to the client and must be passed through to the server.

The `VsixPackage` element will also accept one or more child elements named `VsixDependency` like in the following example.

```xml
<vs:VsixPackage Id="Optional ID; otherwise, generated" ActionProperty="Optional property; otherwise, uppercase Id" ...>
  <vs:Requires Id="Workload Or Component ID" Version="Optional version or version range" Chip="Optional chip" Language="Optional language" Branch="Optional branch" />
</vs:VsixPackage>
```

The `Id` attribute is required, but all other attributes are optional. The `Version` can be a single version number like "1.2.3.4" or a range
using the same syntax as VSIX and NuGet packages like "[1.0,2.0)". Because the attributes are treated as opaque values, the `Language` attribute
should be in the format _language\_Locale_ as with web standards.

### Tables

Until now the `VsixPackage` element was compiled directly into custom actions; however, to fail the installation if a compatible instance
is not found for a package where `VsixPackage/@Vital` is `yes` (default), we need to remember that. To be robust, this will be tracked in an
`Attributes` column. This will allow for other binary attributes to be stored without table schema changes. All rows will be processed without
considering the parent component state because the custom action will enumerate instances only once as an optimization.

The `VsixPackage` table would have the following schema.

Name           | Type | Description
----           | ---- | -----------
VsixPackage    | s72  | The row primary key. This is generated if not authored as described above.
Component_     | s72  | Required parent component ID. Not currently used but could be, and table schemas can only grow. Could be useful for static analysis.
PackageId      | s255 | Required package ID used for reporting.
ActionProperty | s72  | Required per-package property will be set to comma-delimited list of compatible instance IDs.
Attributes     | I4   | Optional attributes including Vital (1).

If any `VsixDependency` elements are authored, the related `VsixPackage/@Id` is associated with the specified package references in a table
with the schema as follows. The column values are treated as opaque values processed by the custom action directly and compared as documented.

Name         | Type | Description
----         | ---- | -----------
VsixPackage_ | s72  | Foreign key reference to related `VsixPackage` row.
Id           | s255 | Required workload or component ID.
Version      | S50  | Optional version or version range.
Chip         | S10  | Optional chip such as "x86" or "x64".
Language     | S10  | Optional language identifier like "en-US" or "ja-JP".
Branch       | S20  | Optional branch identifier. Not typical but supported by the engine.

### Custom actions

Two sets of custom actions are used to discover compatible instances, and to execute _VSIXInstaller.exe_ to install extensions into those
instances of VS2017 or newer, or versions and editions of previous VS releases.

#### Immediate custom action

An immediate custom action will both set properties and enumerate instances, if required. Initially, this custom action will only
set `VS2017_ROOT_FOLDER` as described above but should be updated as future versions are released. It will run before `AppSearch` so that derivative
properties can use the root folder to search for subdirectories. The related `DirectorySearch` and `FileSearch` elements will be authored into _VSIX2017.wxs_
similar to previous releases' authoring.

It will also process the `VsixPackage` table - if it exists - and find compatible instances if the `VS_INSTANCE_IDS` property is not set
using related rows from the `VsixDependency` table that relates a `VsixPackage` row to a collection of workload and component IDs.

The custom action will call `ISetupConfiguration2::EnumAllInstances` to query all instances regardless of the `ISetupInstance::GetState` result.
While enumerating, the version is considered. The version is parsed using `ISetupHelper::ParseVersion`, where `ISetupHelper` is QI'd from
`ISetupConfiguration`. For VS2017, the highest version of 15.0 will be kept as well as the latest installed from `ISetupInstance::GetInstallDate`.
The latest install of the highest version wil be used to set the `VS2017_ROOT_FOLDER` (for the highest 15.0 version), and the
`VS2017_VSIX_INSTALLER_PATH` using combining the result of `ISetupInstance2::GetEnginePath` of "VSIXInstaller.exe". _VsixPackage.wxs_ will be updated
to add another `SetProperty` element to set `VS_VSIX_INSTALLER_PATH` to `VS2017_VSIX_INSTALLER_PATH`, if set.

For each instance, the CA will check for each workload and component ID in the `VsixDependency` table and keep track of which instances contain each ID.
After enumeration is complete, instances that contain all workload and component IDs for a package are set in the associated row's `ActionProperty`
as a comma-separated list of instance IDs. The deferred custom action below uses this property in its condition whether to run,
as well as the command line as described above. If the package is attributed as `Vital` and its `ActionProperty` is not set,
the custom action will log a custom error message and exit with an error. This is necessary because the deferred custom actions
are conditioned on that property as described below and would not run if the property is not set.

##### Error message

The WixVSExtension will define an error message in _src\\libs\\wcautil\\custommsierrors.h_ in the range 27101 to 27200.

ID                  | Message                                          | Description
--                  | -------                                          | -----------
msierrVSNoInstances | No compatible instances found for package "[2]". | [2] is the `PackageId` column value.

#### Deferred custom action

The existing custom actions generated at compile time will be used. These are generated per-package in a declarative manner.
To support installing extensions to specified or discovered compatible instances, associated `VsixPackage` table rows' `ActionProperty`
will be used in the command line like so: "{/instanceIds[_ActionProperty_]}". This means if the `ActionProperty` is defined, the
`/instanceIds` command line switch is passed to _VSIXInstaller.exe_ which takes precedence over the existing `/skuName` and `/skuVersion` switches.
The `ActionProperty` will also be used in the custom action's `Condition` column in the `InstallExecuteSequence` table so that if no instances
were found, the custom action will not run.

The scheduling of these custom actions will not change.

## Considerations

The following sections are from discussions within Microsoft for issues we have considered but seek feedback from the community.
These could be done incrementally after the base feature work proposed above.

### Harvest workload and component IDs from VSIX packages

Because installing VSIX packages without required workloads and instances will install them to all installed instances (at least for
compatible package IDs authored into the package manifest itself). This will install any dependent workloads and/or components.
So it's best to harvest these IDs from VSIX packages if they are available.

VSIX packages are based on the Open Packaging Convention (OPC), which use a ZIP container format. In the root of the package is a _manifest.json_
file that contains a `dependencies` object property. The keys are dependent package IDs that contain all the same values as the columns in
the new `VsixDependency` table and can be harvested directly, like in the following example.

```json
{
  "dependencies": {
    "a": "",
    "b": "[1.0,2.0)",
    "c": {
      "version": "[1.0,2.0)",
      "chip": "x86",
      "language": "en-US",
      "branch": "develop"
    }
  }
}
```

All three examples are supported, where package "a" specifies only an ID, "b" declares a dependent version range, and "c" declares all supported
package reference attributes. These would map to rows like in the following example.

```xml
<vs:VsixPackage PackageId="Example">
  <vs:Requires Id="a" />
  <vs:Requires Id="b" Version="[1.0,2.0)" />
  <vs:Requires Id="c" Version="[1.0,2.0)" Chip="x86" Language="en-US" Branch="develop" />
</vs:VsixPackage>
```

### MSI messages

To support external UI handlers for single MSI installs, the custom actions could send messages for all instances - mapping to the `VSIX_INSTANCE_IDS`
property - and/or each individual instance using package rows' `ActionProperty` properties. The InstanceId, DisplayName, Nickname (optional property),
and InstallationPath properties would be packaged into message data to be displayed by the external  UI handler.

The DisplayName would be selected by passing the `ProductLanguage` MSI property to `ISetupConfiuration::GetDisplayName` as the `lcid` parameter.
If the language is not supported, the English (US) (1033) DisplayName is returned.

### BA functions

Because it's most likely a Burn bundle will install multiple MSIs, it would only make sense to define a BA function that enumerates instances
and can provide the UI with the InstanceId, DisplayName, Nickname (optional property), and InstallationPath so that the UI can present display
information to the user and pass back selected the InstanceIds via either the global `VS_INSTANCE_IDS` or individual `ActionProperty` properties.

The DisplayName would be selected by passing in the locale used by the BA to `ISetupConfiguration::GetDisplayName` as the `lcid` parameter.
If the language is not supported, the English (US) (1033) DisplayName is returned.

## See Also

* [WIXFEAT:5433 - Add support to detect and install VSIX packages into VS15](https://github.com/wixtoolset/issues/issues/5433)
* [Changes to Visual Studio "15" Setup](https://blogs.msdn.microsoft.com/heaths/2016/09/15/changes-to-visual-studio-15-setup/)
* [Extensibility in Visual Studio "15": Increasing Reliability and Performance](https://blogs.msdn.microsoft.com/visualstudio/2016/11/10/extensibility-in-visual-studio-15-increasing-reliability-and-performance/)
* [Setup Configuration API documentation][API]

  [API]: https://aka.ms/setup/configuration/docs