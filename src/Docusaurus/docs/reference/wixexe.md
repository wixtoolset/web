---
sidebar_position: 60
---

# Wix.exe command-line reference

The [Wix.exe .NET tool](../intro.md#nettool) provides a reassuringly old-fashioned command-line interface to WiX. Like the `dotnet` command-line tool that inspired it, Wix.exe has a number of command, some with subcommands, and both required and optional switches.

## Wix.exe commands

Wix.exe offers the following commands:

| Wix.exe command | Description |
| --------------- | ----------- |
| `wix build` | Build a wixlib, package, or bundle. |
| `wix msi` | Specialized operations for manipulating Windows Installer packages. |
| `wix burn` | Specialized operations for manipulating Burn-based bundles. |
| `wix extension` | Manage WiX extension cache. |
| `wix convert` | Convert v3 source code to v4 source code. |
| `wix format` | Ensure consistent formatting of source code. |

Wix.exe has the following switches that are common to all commands:

| Option | Description |
| ------- | ----------- |
| `--help` or `-h` | Show command line help. |
| `--version` | Display WiX Toolset version in use. |
| `--nologo` | Suppress displaying the logo information. |


## `wix build` command {#build}

Build a package, bundle, or library.

```sh
wix build [options] source_file.wxs [source_file.wxs ...]
```

| Option | Description |
| ------ | ----------- |
| `-arch` _arch_ | Architecture of the package or bundle. Valid values are: *x86*, *x64*, *arm64*. Default: *x86*. Equivalent MSBuild property: `InstallerPlatform` |
| `-bindfiles` or `-bf` | Bind files into an output .wixlib. Ignored if not building a .wixlib. |
| `-bindpath` or `-b` _path_ | Bind path to search for content files. |
| `-bindpath:target` or `-bt` _path_ | Bind path to search for target package's content files. Only used when building a patch. |
| `-bindpath:update` or `-bu` _path_ | Bind path to search for update package's content files. Only used when building a patch. |
| `-cabcache` or `-cc` _path_ | Set a folder to cache cabinets across builds. |
| `-culture` _culture_ | Adds a culture to filter localization files. |
| `-define` or `-d` _name_=_value_ | Sets a preprocessor variable. |
| `-defaultcompressionlevel` or `-dcl` _level_ | Specifies the compression level used when none is specified via `MediaTemplate` or `Media`. Valid values are: *none*, *low*, *medium*, *high*, *mszip*. Default: *medium*. Equivalent MSBuild property: `DefaultCompressionLevel` |
| `-ext` _id_ | [Load a WiX extension for use during the build.](#extension) |
| `-include` or `-i` _path_ | Folder to search for include files. |
| `-intermediateFolder` _path_ | Optional working folder. If not specified, a folder in %TMP% is created. |
| `-loc` _path_ | Localization file to use in the build. By default, .wxl files are recognized as localization. |
| `-lib` _path_ | Library file to use in the build. By default, .wixlib files are recognized as libraries. |
| `-src` _path_ | Source file to use in the build. By default, .wxs files are recognized as source code. |
| `-out` or `-o` _path_ | Destination path of output. Required when there are multiple source files; otherwise, defaults to the base name of the source file. |
| `-outputtype` _type_ | Explicitly set the output type if it cannot be determined from the output. |
| `-pdb` _path_ | Optional path to output .wixpdb. Default will write .wixpdb beside output path. |
| `-pdbtype` _type_ | Switch to disable creation of .wixpdb. Types: full or none. |


## `wix msi` command {#msi}

The `wix msi` command has the following subcommands:

| Subcommand | Description |
| ---------- | ----------- |
| `wix msi decompile` | Converts a Windows Installer database back into source code. |
| `wix msi inscribe` | Updates MSI database with cabinet signature information. |
| `wix msi transform` | Creates an MST transform file. |
| `wix msi validate` | Validates MSI database using standard or custom ICEs. |


### `wix msi decompile` subcommand {#msidecompile}

Decompile a package or merge module into WiX authoring or WiX data file.

```sh
wix msi decompile [options] {inputfile.msi|inputfile.msm}
```

| Option | Description |
| ------ | ----------- |
| `-data` | Decompile into a WiX data file instead of WiX authoring. |
| `-sct` | Suppress decompiling custom tables. |
| `-sdet` | Suppress dropping empty tables. |
| `-sras` | Suppress relative action sequencing. |
| `-sui` | Suppress decompiling UI tables. |
| `-type` _type_ | Optionally specify the input file type: _msi_ or _msm_. If not specified, type is inferred by file extension. |
| `-intermediateFolder` _path_ | Optional working folder. If not specified, a folder in %TMP% is created. |
| `-out` or `-o` _path_ | Optional path for the decompiled output file. If not specified, output path will have the same base name as the input file in the same directory. |
| `x` _path_ | If specified, export embedded binaries and icons to specified folder. |


### `wix msi inscribe` subcommand {#msiinscribe}

Update an MSI package with the signatures of detached cabinets.

```sh
wix msi inscribe [options] input.msi
```

| Option | Description |
| ------ | ----------- |
| `-intermediateFolder` _path_ | Optional working folder. If not specified, a folder in %TMP% is created. |
| `-out` or `-o` _path_ | Optional path for the inscribed package. If not specified, `wix msi inscribe` updates the input file in-place. |


### `wix msi transform` subcommand {#msitransform}

Create a Windows Installer transform file (.mst).

```sh
msi transform [options] target.msi [updated.msi] -out output.mst
```

| Option | Description |
| ------ | ----------- |
| `-intermediateFolder` _path_ | Optional working folder. If not specified, a folder in %TMP% is created. |
| `-out` or `-o` _path_ | Required path for the transform file. |
| `-p` | Preserve unchanged rows. |
| `-pedantic` | Show pedantic messages. |
| `-serr` _flags_ | Suppress error when applying transform; see Error flags below. |
| `-t` _type_ | Use default validation flags for the specified transform type; see Transform types below. |
| `-val` _flags_ | Validation flags for the transform; see Validation flags below. |
| `-x` _path_ | If specified, export embedded binaries and icons to specified folder. |
| `-xo` | Output transfrom as a WiX output instead of an MST file. |

| Error flag for `-serr` | Description |
| ---------------------- | ----------- |
| `a` | Ignore errors when adding an existing row. |
| `b` | Ignore errors when deleting a missing row. |
| `c` | Ignore errors when adding an existing table. |
| `d` | Ignore errors when deleting a missing table. |
| `e` | Ignore errors when modifying a missing row. |
| `f` | Ignore errors when changing the code page. |

| Validation flag for `-val` | Description |
| -------------------------- | ----------- |
| `g` | UpgradeCode must match |
| `l` | Language must match |
| `r` | Product ID must match |
| `s` | Check major version only |
| `t` | Check major and minor versions |
| `u` | Check major, minor, and upgrade versions |
| `v` | Upgrade version < target version |
| `w` | Upgrade version <= target version |
| `x` | Upgrade version = target version |
| `y` | Upgrade version > target version |
| `z` | Upgrade version >= target version |

| Transform type for `-t` | Description |
| ----------------------- | ----------- |
| `language` | Default flags for a language transform: `abcdef` and `r` |
| `instance` | Default flags for an instance transform: `abcdef` and `ruy` |
| `patch` | Default flags for a patch transform: `abcdef` and `grux` |


### `wix msi validate` subcommand {#msivalidate}

Validates MSI database using standard or custom Internal Consistency Evaluators (ICEs).

```sh
msi validate [options] {inputfile.msi|inputfile.msm}
```

| Option | Description |
| ------ | ----------- |
| `-cub` _path_ | Optional path to a custom validation .CUBe file. |
| `-ice` _id_ | Validates only with the specified ICE. May be provided multiple times. |
| `-intermediateFolder` _path_ | Optional working folder. If not specified, a folder in %TMP% is created. |
| `-pdb` _path_ | Optional path to .wixpdb for source line information. If not provided, `wix msi validate` looks next to the input file. |
| `-sice` _id_ | Suppresses an ICE validator. May be provided multiple times. |


## `wix burn` command {#burn}

The `wix burn` command has the following subcommands:

| Subcommand | Description |
| ---------- | ----------- |
| `wix burn detach` | Detach the Burn engine from a bundle so it can be signed. |
| `wix burn extract` | Extract the internals of a bundle to a folder. |
| `wix burn reattach` | Reattach a signed Burn engine to a bundle. |
| `wix burn remotepayload` | Generate source code for a remote payload. |


### `wix burn detach` and `wix burn reattach` subcommands {#burnsigning}

The `wix burn detach` and `wix burn reattach` subcommands are used to sign bundles. For details, see [Signing bundles](./signing.md/#signing-bundles).

```sh
wix burn detach [options] original.exe -engine engine.exe
```

| Option | Description |
| ------ | ----------- |
| `-intermediateFolder` _path_ | Optional working folder. If not specified, a folder in %TMP% is created. |
| `-engine` _path_ | Path for extracted bundle engine. |


```sh
wix burn reattach [options] original.exe -engine signed.exe -o final.exe
```

| Option | Description |
| ------ | ----------- |
| `-intermediateFolder` _path_ | Optional working folder. If not specified, a folder in %TMP% is created. |
| `-engine` _path_ | Required path to Burn engine extracted using `wix burn detach` and then signed. |
| `-out` or `-o` _path_ | Required path to output bundle with reattached signed engine that can then be signed as a whole. |


### `wix burn extract` subcommand {#burnextract}

Extracts the contents of a bundle.

```sh
wix burn extract [options] bundle.exe -o outputfolder
```

| Option | Description |
| ------ | ----------- |
| `-intermediateFolder` _path_ | Optional working folder. If not specified, a folder in %TMP% is created. |
| `-out` or `-o` _path_ | Target directory for extracted bundle containers. At least one of `-out` and `-outba` must be specified. |
| `-outba` or `-oba` _path_ | Target directory for extracted bootstrapper application container. At least one of `-out` and `-outba` must be specified. |


### `wix burn remotepayload` subcommand {#burnremotepayload}

Generate source code for a remote payload.

```sh
wix burn remotepayload [options] payloadfile [payloadfile ...]
```

| Option | Description |
| ------ | ----------- |
| `-basepath` or `-bp` _path_ | Folder as base to make payloads relative. |
| `-bundlepayloadgeneration` _type_ | Sets the package payload generation option; available types are: _none_, _externalwithoutdownloadurl_, _external_, _all_. |
| `-downloadurl` or `-du` | Sets the DownloadUrl attribute on the generated payloads. |
| `-intermediateFolder` _path_ | Optional working folder. If not specified, a folder in %TMP% is created. |
| `-out` or `-o` _path_ | Destination path of output source file. |
| `-recurse` or `-r` | Generate source code for all payloads in directory recursively. |
| `-packagetype` _type_ | Explicitly set package type; available types are: _bundle_, _exe_, _msu_. |
| `-usecertificate` | Use certificate to validate signed payloads. This option is not recommended. |


## `wix extension` command {#extension}

Manage the extension cache. Extensions are referenced by:

- `id`/`version` (uses specified version)
- `id` (uses the latest available version)

| Subcommand | Description |
| ---------- | ----------- |
| `wix extension add` | Add extension to the cache. |
| `wix extension list` | List extensions in the cache. |
| `wix extension remove` | Remove extension from the cache. |

```sh
wix extension add|remove|list [options] [extensionRef]
```

| Option | Description |
| ------ | ----------- |
| `--global` or `-g` | Manage the extension for the current user's WiX extension cache. If not specified, manages the extension relative to the current directory. |


## `wix convert` command {#convert}

Convert v3 source code to v4 source code.

```sh
wix convert [options] sourceFile [sourceFile ...]
```

_sourceFile_ can include wildcards like `*.wxs`.

| Option | Description |
| ------ | ----------- |
| `--custom-table` _type_ | Convert custom table authoring for use in MSI packages (_msi_) or bundles (_bundle_). |
| `--dry-run` or `-n` | Only display errors, do not update files. |
| `--recurse` or `-r` | Search for matching files in current dir and subdirs. |
| `-set1`_path_ | Primary settings file. No space between `-set1` and file path. |
| `-set2`_path_ | Secondary settings file (overrides primary). No space between `-set2` and file path. |
| `-indent:n` | Indentation multiple (overrides default of 4). |


## `wix format` command {#format}

Ensure consistent formatting of source code.

```sh
wix format [options] sourceFile [sourceFile ...]
```
_sourceFile_ can include wildcards like `*.wxs`.

| Option | Description |
| ------ | ----------- |
| `--dry-run` or `-n` | Only display errors, do not update files. |
| `--recurse` or `-r` | Search for matching files in current dir and subdirs. |
| `-set1`_path_ | Primary settings file. No space between `-set1` and file path. |
| `-set2`_path_ | Secondary settings file (overrides primary). No space between `-set2` and file path. |
| `-indent:n` | Indentation multiple (overrides default of 4). |

## convert/format settings

| Test ID | Description |
| ------- | ----------- |
| `InspectorTestTypeUnknown` | Internal only: displayed when a string cannot be converted to an InspectorTestType. |
| `XmlException` | Displayed when an XML loading exception has occurred. |
| `WhitespacePrecedingNodeWrong` | Displayed when the whitespace preceding a node is wrong. |
| `WhitespacePrecedingEndElementWrong` | Displayed when the whitespace preceding an end element is wrong. |
| `DeclarationPresent` | Displayed when the XML declaration is present in the source file. |
| `DeprecatedLocalizationVariablePrefixInTextValue` | Displayed when inner text contains a deprecated $(loc.xxx) reference. |
| `UnauthorizedAccessException` | Displayed when a file cannot be accessed; typically when trying to save back a fixed file. |
| `XmlnsMissing` | Displayed when the xmlns attribute is missing from the document element.x |
| `XmlnsValueWrong` | Displayed when the xmlns attribute on the document element is wrong.x |
| `DeprecatedLocalizationVariablePrefixInTextValue` | Displayed when inner text contains a deprecated $(loc.xxx) reference. |
| `DeprecatedLocalizationVariablePrefixInAttributeValue` | Displayed when an attribute value contains a deprecated $(loc.xxx) reference. |
| `AssignAnonymousFileId` | Assign an identifier to a File element when on Id attribute is specified. |
| `BundleSignatureValidationObsolete` | SuppressSignatureValidation attribute is obsolete and corresponding functionality removed. |
| `WixCABinaryIdRenamed` | WixCA Binary/@Id has been renamed to UtilCA. |
| `QuietExecCustomActionsRenamed` | QtExec custom actions have been renamed. |
| `QtExecCmdTimeoutAmbiguous` | QtExecCmdTimeout was previously used for both CAQuietExec and CAQuietExec64. For WixQuietExec, use WixQuietExecCmdTimeout. For WixQuietExec64, use WixQuietExec64CmdTimeout. |
| `AssignDirectoryNameFromShortName` | Directory/@ShortName may only be specified with Directory/@Name. |
| `BootstrapperApplicationDataDeprecated` | BootstrapperApplicationData attribute is deprecated and replaced with Unreal for MSI. Use BundleCustomData element for Bundles. |
| `AssignPermissionExInheritable` | Inheritable is new and is now defaulted to 'yes' which is a change in behavior for all but children of CreateFolder. |
| `ColumnCategoryCamelCase` | Column element's Category attribute is camel-case. |
| `ColumnModularizeCamelCase` | Column element's Modularize attribute is camel-case. |
| `InnerTextDeprecated` | Inner text value should move to an attribute. |
| `AutoGuidUnnecessary` | Explicit auto-GUID unnecessary. |
| `FeatureAbsentAttributeReplaced` | The Feature Absent attribute renamed to AllowAbsent. |
| `FeatureAllowAdvertiseValueDeprecated` | The Feature AllowAdvertise attribute value deprecated. |
| `PublishConditionOneUnnecessary` | The Condition='1' attribute is unnecessary on Publish elements. |
| `AssignBootstrapperApplicationDpiAwareness` | DpiAwareness is new and is defaulted to 'perMonitorV2' which is a change in behavior. |
| `AssignVariableTypeFormatted` | The string variable type was previously treated as formatted. |
| `CustomActionKeysAreNowRefs` | The CustomAction attributes have been renamed from BinaryKey and FileKey to BinaryRef and FileRef. |
| `ProductAndPackageRenamed` | The Product and Package elements have been renamed and reorganized. |
| `ModuleAndPackageRenamed` | The Module and Package elements have been renamed and reorganized. |
| `DefaultMediaTemplate` | A MediaTemplate with no attributes set is now provided by default. |
| `UtilRegistryValueSearchBehaviorChange` | util:RegistrySearch has breaking change when value is missing. |
| `DisplayInternalUiNotConvertable` | DisplayInternalUI can't be converted. |
| `InstallerVersionBehaviorChange` | InstallerVersion has breaking change when omitted. |
| `VerbTargetNotConvertable` | Verb/@Target can't be converted. |
| `BootstrapperApplicationDll` | The bootstrapper application dll is now specified in its own element. |
| `BootstrapperApplicationDllRequired` | The new bootstrapper application dll element is required. |
| `BalUseUILanguagesDeprecated` | bal:UseUILanguages is deprecated, 'true' is now the standard behavior. |
| `BalBootstrapperApplicationRefToElement` | The custom elements for built-in BAs are now required. |
| `RenameExePackageCommandToArguments` | The ExePackage elements "XxxCommand" attributes have been renamed to "XxxArguments". |
| `Win64AttributeRenamed` | The Win64 attribute has been renamed. Use the Bitness attribute instead. |
| `Win64AttributeRenameCannotBeAutomatic` | Breaking change: The Win64 attribute's value '{0}' cannot be converted automatically to the new Bitness attribute. |
| `TagElementRenamed` | The Tag element has been renamed. Use the element 'SoftwareTag' name. |
| `IntegratedDependencyNamespace` | The Dependency namespace has been incorporated into WiX v4 namespace. |
| `RemoveUnusedNamespaces` | Remove unused namespaces. |
| `RemotePayloadRenamed` | The Remote element has been renamed. Use the "XxxPackagePayload" element instead. |
| `NameAttributeMovedToRemotePayload` | The XxxPackage/@Name attribute must be specified on the child XxxPackagePayload element when using a remote payload. |
| `CompressedAttributeUnnecessaryForRemotePayload` | The XxxPackage/@Compressed attribute should not be specified when using a remote payload. |
| `DownloadUrlAttributeMovedToRemotePayload` | The XxxPackage/@DownloadUrl attribute must be specified on the child XxxPackagePayload element when using a remote payload. |
| `BurnHashAlgorithmChanged` | The hash algorithm used for bundles changed from SHA1 to SHA512. |
| `CustomTableNotAlwaysConvertable` | CustomTable elements can't always be converted. |
| `CustomTableRef` | CustomTable elements that don't contain the table definition are now CustomTableRef. |
| `RegistryKeyActionObsolete` | The RegistryKey element's Action attribute is obsolete. |
| `TagRefElementRenamed` | The TagRef element has been renamed. Use the element 'SoftwareTagRef' name. |
| `SoftwareTagLicensedObsolete` | The SoftwareTag element's Licensed attribute is obsolete. |
| `SoftwareTagTypeObsolete` | The SoftwareTag element's Type attribute is obsolete. |
| `TargetDirDeprecated` | TARGETDIR directory should no longer be explicitly defined. |
| `DefiningStandardDirectoryDeprecated` | Standard directories should no longer be defined using the Directory element. |
| `ReferencesReplaced` | Naked UI, custom action, and property references replaced with elements. |
| `BundlePackageCacheAttributeValueObsolete` | Cache attribute value updated. |
| `MsuPackageKBObsolete` | The MsuPackage element contains obsolete '{0}' attribute. Windows no longer supports silently removing MSUs so the attribute is unnecessary. The attribute will be removed. |
| `MsuPackagePermanentObsolete` | The MsuPackage element contains obsolete '{0}' attribute. MSU packages are now always permanent because Windows no longer supports silently removing MSUs. The attribute will be removed. |
| `MoveNamespacesToRoot` | Namespace should be defined on the root. The '{0}' namespace was move to the root element. |
| `CustomActionIdsIncludePlatformSuffix` | Custom action ids have changed in WiX v4 extensions. Because WiX v4 has platform-specific custom actions, the platform is applied as a suffix: _X86, _X64, _A64 (Arm64). When manually rescheduling custom actions, you must use the new custom action id, with platform suffix. |
| `StandardDirectoryRefDeprecated` | The {0} directory should no longer be explicitly referenced. Remove the DirectoryRef element with Id attribute '{0}'. |
| `EmptyStandardDirectoryRefNotConvertable` | Referencing '{0}' directory directly is no longer supported. The DirectoryRef will not be removed but you will probably need to reference a more specific directory. |
| `WixMbaPrereqLicenseUrlDeprecated` | The magic WixVariable 'WixMbaPrereqLicenseUrl' has been removed. Add bal:PrereqLicenseUrl="_url_" to a prereq package instead. |
| `WixMbaPrereqPackageIdDeprecated` | The magic WixVariable 'WixMbaPrereqPackageId' has been removed. Add bal:PrereqPackage="yes" to the target package instead. |
| `TargetDirRefRemoved` | A reference to the TARGETDIR Directory was removed. This may cause the Fragment that defined TARGETDIR to not be included in the final output. If this happens, reference a different element in the Fragment to replace the old reference to TARGEDIR. |
