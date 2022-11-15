---
sidebar_position: 10
---

# MSBuild

:::info
TODO: WiX v4 documentation is under development.
:::

:::tip
See [Signing packages and bundles](../signing.md#msbuild) for information about signing packages and bundles when using MSBuild.
:::


## Properties

You can set the following properties in your .wixproj to control the build:

| Property | Description |
| -------- | ----------- |
| AdditionalCub | Semicolon-delimited list of .cub files to use during MSI validation. Default: darice.cub for .msi packages; mergemod.cub for .msm packages |
| BindFiles | When **true**, bind referenced files into the output file. Valid only when building .wixlib WiX libraries. Default: **false** |
| CabinetCreationThreadCount | Specifies the number of simultaneous threads used when building multiple cabinets. Default: The number of logical processors in the system. |
| CompilerAdditionalOptions | A string specifying arbitrary [Wix.exe command-line arguments](../wixexe.md) to use during the build. Default: none |
| DebugType | Specifies the .wixpdb output: *full* for full symbol information or *none* to suppress the .wixpdb. Default: *full* |
| DefaultCompressionLevel | Specifies the compression level used when none is specified via `MediaTemplate` or `Media`. Valid values are: *none*, *low*, *medium*, *high*, *mszip*. Default: *medium*. Default Wix.exe switch: `-defaultcompressionlevel` |
| DefineConstants | Semicolon-delimited list of **name**=**value** string pairs that specify preprocessor variable values. Default: none |
| Ices | Semicolon-delimited list of ICE validation names to run during MSI validation. Default: all available ICEs |
| IncludeSearchPaths | Semicolon-delimited list of paths to use to locate `<?include?>` files. Default: current directory |
| InstallerPlatform | Architecture of the package or bundle. Valid values are: *x86*, *x64*, *arm64*. Default: `$(Platform)`. Default Wix.exe switch: `-arch` |
| IntermediateOutputPath | Path used for intermediate outputs. Default: obj/*platform*/*configuration* |
| LinkerAdditionalOptions | A string specifying arbitrary [Wix.exe command-line arguments](../wixexe.md) to use during the build. Default: none |
| OutputType | Specifies the type of package being built. Valid values are: *Package*, *Module*, *Patch*, *PatchCreation*, *Library*, *Bundle*, *IntermediatePostLink*. Default: *Package* |
| Pedantic | If **true**, turns on pedantic warning messages. Default: **false** |
| SuppressAllWarnings | If **true**, turns off all warning messages. Default: **false** |
| SuppressIces | Semicolon-delimited list of ICE validation names to *not* run during MSI validation. Default: none |
| SuppressSpecificWarnings | Semicolon-delimited list of warning message numbers to turn off. Default: none |
| SuppressValidation | If **true**, turns off MSI validation. Default: **false** |
| TreatSpecificWarningsAsErrors | Semicolon-delimited list of warning message numbers to treat as errors. Default: none |
| TreatWarningsAsErrors | If **true**, treats all warning messages as errors. Default: **false** |
| ValidationAdditionalOptions | A string specifying arbitrary [Wix.exe command-line arguments](../wixexe.md#msi) to use during validation. Default: none |
| VerboseOutput | If **true**, turns on verbose messages. Default: **false** |


## Items

| Item | Description |
| ---- | ----------- |
| BindPath | Bind paths used to locate payload files. To create named bind paths, specify `BindName` metadata with the name of the bind path. |
| Compile | Files to compile. By default, the WiX SDK automatically includes all WiX authoring using the wildcard `**/*.wxs`. To control default items, see [the project SDK documentation](https://learn.microsoft.com/en-us/dotnet/core/project-sdk/msbuild-props#default-item-inclusion-properties). |
| EmbeddedResource | Localization files used to build locale-specific packages. By default, the WiX SDK automatically includes all localization files using the wildcard `**/*.wxl`. To control default items, see [the project SDK documentation](https://learn.microsoft.com/en-us/dotnet/core/project-sdk/msbuild-props#default-item-inclusion-properties).|
| WixLibrary | Paths to WiX libraries (.wixlib files) that contain authoring referenced by the package being built. |

