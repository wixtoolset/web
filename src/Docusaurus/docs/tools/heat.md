---
sidebar_position: 100
---

# Heat harvesting

In WiX v4, Heat is available in a WiX extension NuGet Package. To use Heat to harvest directories, files, or projects:

1. Add a reference to the [WixToolset.Heat NuGet package](https://www.nuget.org/packages/WixToolset.Heat/).
2. Add an item group based on the kind of harvesting you want to do in your project:
   - `HarvestDirectory` to harvest files from a directory
   - `HarvestFile` to harvest data from a file
   - `HarvestProject` to harvest output from a project


## Using `HarvestDirectory` to harvest files from a directory

`HarvestDirectory` items can contain the following options to control harvesting:

| Option | Description |
| ------ | ----------- |
| `Include` | Required string attribute. The directory to harvest. This path can be relative to the project file, or it can be an absolute path.
| `ComponentGroupName` | Optional string element. The name of the ComponentGroup to create for the generated authoring. Useful when harvesting multiple directories in a single project. |
| `DirectoryRefId` | Optional string. The ID of the directory to reference instead of TARGETDIR. |
| `KeepEmptyDirectories` | Optional boolean element. Whether to create Directory entries for empty directories. The default is **false**. |
| `PreprocessorVariable` | Optional string element. Substitute another preprocessor variable name for `SourceDir`. For example, specify `MyDir` to have Heat use `$(MyDir)` instead of `$(SourceDir)`. |
| `SuppressCom` | Optional boolean element. Suppress generation of COM registry elements. The default is **false**. |
| `SuppressRegistry` | Optional boolean element. Suppress generation of any registry elements. The default is **false**. |
| `SuppressRootDirectory` | Optional boolean element. Suppress generation of a Directory element for the top-level harvested directory itself. The default is **false**. |
| `Transforms` | Optional string element. Semicolon-delimited list of paths to XSL transforms to apply to the generated authoring. |

The following properties control harvesting:

| Property | Description |
| -------- | ----------- |
| `HarvestDirectoryAutogenerateGuids` | Optional boolean property. Whether to generate authoring that relies on auto-generation of component GUIDs. The default is `$(HarvestAutogenerateGuids)` if specified; otherwise, **true**. |
| `HarvestDirectoryComponentGroupName` | Optional string property. The name of the ComponentGroup to created for the generated authoring. Useful when harvesting multiple directories in a single project. |
| `HarvestDirectoryDirectoryRefId` | Optional string property. The identifier of the Directory element that will contain all generated authoring. |
| `HarvestDirectoryGenerateGuidsNow` | Optional boolean property. Whether to generate authoring that generates durable GUIDs when harvesting. The default is `$(HarvestGenerateGuidsNow)` if specified; otherwise, **false**. |
| `HarvestDirectoryKeepEmptyDirectories` | Optional boolean property. Whether to create Directory entries for empty directories when harvesting. The default is **false**. |
| `HarvestDirectoryNoLogo` | Optional boolean property. Whether to show the logo for heat.exe. The default is `$(NoLogo)` if specified; otherwise, **false**. |
| `HarvestDirectoryPreprocessorVariable` | Optional string property. Substitute another preprocessor variable name for `SourceDir`. For example, specify `MyDir` to have Heat use `$(MyDir)` instead of `$(SourceDir)`. |
| `HarvestDirectorySuppressAllWarnings` | Optional boolean parameter. Specifies that all warnings should be suppressed. The default is `$(HarvestSuppressAllWarnings)` if specified; otherwise, **false**. |
| `HarvestDirectorySuppressCom` | Optional boolean property. Whether to suppress generation of COM registry elements when harvesting files in directories. The default is **false**. |
| `HarvestDirectorySuppressFragments` | Optional boolean property. Whether to suppress generation of separate fragments when harvesting. The default is `$(HarvestSuppressFragments)` if specified; otherwise, **true**. |
| `HarvestDirectorySuppressRegistry` | Optional boolean property. Whether to suppress generation of all registry elements when harvesting files in directories. The default is **false**. |
| `HarvestDirectorySuppressRootDirectory` | Optional boolean property. Whether to suppress generation of a Directory element for the top-level harvested directory itself. The default is **false**. |
| `HarvestDirectorySuppressSpecificWarnings` | Optional string parameter. Specifies that certain warnings should be suppressed. The default is `$(HarvestSuppressSpecificWarnings)` if specified. |
| `HarvestDirectorySuppressUniqueIds` | Optional boolean property. Whether to suppress generation of unique component IDs. The default is `$(HarvestSuppressUniqueIds)` if specified; otherwise, **false**. |
| `HarvestDirectoryTransforms` | Optional string property. Semicolon-delimited list of paths to XSL transforms to apply to the generated authoring. The default is `$(HarvestTransforms)` if specified. |
| `HarvestDirectoryTreatSpecificWarningsAsErrors` | Optional string property. Specifies that certain warnings should be treated as errors. The default is `$(HarvestTreatSpecificWarningsAsErrors)` if specified. |
| `HarvestDirectoryTreatWarningsAsErrors` | Optional boolean property. Specifies that all warnings should be treated as errors. The default is `$(HarvestTreatWarningsAsErrors)` if specified; otherwise, **false**. |
| `HarvestDirectoryVerboseOutput` | Optional boolean property. Specifies that the tool should provide verbose output. The default is `$(HarvestVerboseOutput)` if specified; otherwise, **false**. |

Example:

```xml
<Project Sdk="WixToolset.Sdk">
  <ItemGroup>
    <HarvestDirectory Include="FilesDir">
      <ComponentGroupName>HarvestedComponents</ComponentGroupName>
      <DirectoryRefId>ApplicationFolder</DirectoryRefId>
      <SuppressRootDirectory>true</SuppressRootDirectory>
    </HarvestDirectory>

    <BindPath Include="FilesDir" />
  </ItemGroup>

  <ItemGroup>
    <PackageReference Include="WixToolset.Heat" />
  </ItemGroup>
</Project>
```


## Using `HarvestFile` to harvest data from a file

The `Include` attribute specifies the file to harvest. The path can be relative to the `.wixproj` project file, or it can be an absolute path.

`HarvestFile` items can contain the following options to control harvesting:

| Option | Description |
| ------ | ----------- |
| `Include` | Required string attribute. The file to harvest. This path can be relative to the project file, or it can be an absolute path.
| `ComponentGroupName` | Optional string element. The name of the ComponentGroup to create for all the generated authoring.  |
| `DirectoryRefId` | Optional string element. The ID of the directory to reference instead of TARGETDIR. |
| `PreprocessorVariable` | Optional string element. Substitute another preprocessor variable name for `SourceDir`. For example, specify `MyDir` to have Heat use `$(MyDir)` instead of `$(SourceDir)`. |
| `SuppressCom` | Optional boolean element. Suppress generation of COM registry elements. The default is **false**. |
| `SuppressRegistry` | Optional boolean element. Suppress generation of any registry elements. The default is **false**. |
| `SuppressRootDirectory` | Optional boolean element. Suppress generation of a Directory element for the directory containing the file. The default is **false**. |
| `Transforms` | Optional string element. Semicolon-delimited list of paths to XSL transforms to apply to the generated authoring. |

The following properties control harvesting:

| Property | Description |
| -------- | ----------- |
| `HarvestFileAutogenerateGuids` | Optional boolean property. Whether to generate authoring that relies on auto-generation of component GUIDs. The default is `$(HarvestAutogenerateGuids)` if specified; otherwise, **true**. |
| `HarvestFileComponentGroupName` | Optional string property. The ComponentGroup name that will contain all generated authoring. Useful when harvesting multiple items in a single project. |
| `HarvestFileDirectoryRefId` | Optional string property. The identifier of the Directory element that will contain all generated authoring. |
| `HarvestFileGenerateGuidsNow` | Optional boolean property. Whether to generate authoring that generates durable GUIDs when harvesting. The default is `$(HarvestGenerateGuidsNow)` if specified; otherwise, **false**. |
| `HarvestFileNoLogo` | Optional boolean property. Whether to show the logo for heat.exe. The default is `$(NoLogo)` if specified; otherwise, **false**. |
| `HarvestFilePreprocessorVariable` | Optional string property. Substitute another preprocessor variable name for `SourceDir`. For example, specify `MyDir` to have Heat use `$(MyDir)` instead of `$(SourceDir)`. |
| `HarvestFileSuppressAllWarnings` | Optional boolean parameter. Specifies that all warnings should be suppressed. The default is `$(HarvestSuppressAllWarnings)` if specified; otherwise, **false**. |
| `HarvestFileSuppressCom` | Optional boolean property. Whether to suppress generation of COM registry elements when harvesting files in directories. The default is **false**. |
| `HarvestFileSuppressFragments` | Optional boolean property. Whether to suppress generation of separate fragments when harvesting. The default is `$(HarvestSuppressFragments)` if specified; otherwise, **true**. |
| `HarvestFileSuppressRegistry` | Optional boolean property. Whether to suppress generation of all registry elements when harvesting files in directories. The default is **false**. |
| `HarvestFileSuppressRootDirectory` | Optional boolean property. Whether to suppress generation of a Directory element for the directory containing the harvested file. The default is **false**. |
| `HarvestFileSuppressSpecificWarnings` | Optional string parameter. Specifies that certain warnings should be suppressed. The default is `$(HarvestSuppressSpecificWarnings)` if specified. |
| `HarvestFileSuppressUniqueIds` | Optional boolean property. Whether to suppress generation of unique component IDs. The default is `$(HarvestSuppressUniqueIds)` if specified; otherwise, **false**. |
| `HarvestFileTransforms` | Optional string property. Semicolon-delimited list of paths to XSL transforms to apply to the generated authoring. The default is `$(HarvestTransforms)` if specified. |
| `HarvestFileTreatSpecificWarningsAsErrors` | Optional string property. Specifies that certain warnings should be treated as errors. The default is `$(HarvestTreatSpecificWarningsAsErrors)` if specified. |
| `HarvestFileTreatWarningsAsErrors` | Optional boolean property. Specifies that all warnings should be treated as errors. The default is `$(HarvestTreatWarningsAsErrors)` if specified; otherwise, **false**. |
| `HarvestFileVerboseOutput` | Optional boolean property. Specifies that the tool should provide verbose output. The default is `$(HarvestVerboseOutput)` if specified; otherwise, **false**. |

Example:

```xml
<Project Sdk="WixToolset.Sdk">
  <PropertyGroup>
    <HarvestFileSuppressUniqueIds>true</HarvestFileSuppressUniqueIds>
  </PropertyGroup>

  <ItemGroup>
    <HarvestFile Include="MyProgram.txt">
      <ComponentGroupName>TxtProductComponents</ComponentGroupName>
      <DirectoryRefId>INSTALLFOLDER</DirectoryRefId>
      <SuppressRootDirectory>true</SuppressRootDirectory>
    </HarvestFile>

    <HarvestFile Include="MyProgram.json">
      <ComponentGroupName>JsonProductComponents</ComponentGroupName>
      <DirectoryRefId>INSTALLFOLDER</DirectoryRefId>
      <SuppressRootDirectory>true</SuppressRootDirectory>
    </HarvestFile>
  </ItemGroup>

  <ItemGroup>
    <PackageReference Include="WixToolset.Heat" />
  </ItemGroup>
</Project>
```


## Using `HarvestProject` to harvest output from a project

Harvesting projects is disabled by default because it may not always work correctly. To enable it, set `EnableProjectHarvesting` to **true** in your project file.
When project harvesting is enabled, Heat will try to harvest all referenced projects. Use the `DoNotHarvest` flag in any `ProjectReference` element to exclude individual projects.

`HarvestProject` items can contain the following options to control harvesting:

| Option | Description |
| -------- | ----------- |
| `Include` | Required attribute. The project file to harvest. The path can be relative to the project file, or it can be an absolute path. |
| `ProjectOutputGroups` | Required attribute. Semicolon-delimited list of project output groups to harvest. Examples include `Binaries` and `Source`. |
| `Transforms` | Optional string element. Semicolon-delimited list of paths to XSL transforms to apply to the generated authoring. |

The following properties control harvesting:

| Property | Description |
| -------- | ----------- |
| `HarvestProjectsAutogenerateGuids` | Optional boolean property. Whether to generate authoring that relies on auto-generation of component GUIDs. The default is `$(HarvestAutogenerateGuids)` if specified; otherwise, **true**. |
| `HarvestProjectsGenerateGuidsNow` | Optional boolean property. Whether to generate authoring that generates durable GUIDs when harvesting. The default is `$(HarvestGenerateGuidsNow)` if specified; otherwise, **false**. |
| `HarvestProjectsNoLogo` | Optional boolean property. Whether to show the logo for heat.exe. The default is `$(NoLogo)` if specified; otherwise, **false**. |
| `HarvestProjectsProjectOutputGroups` | Optional string property. Semicolon-delimited list of project output groups to harvest. Possible Values: `Binaries`, `Symbols`, `Documents`, `Satellites`, `Sources` & `Content`. |
| `HarvestProjectsSuppressAllWarnings` | Optional boolean property. Specifies that all warnings should be suppressed. The default is `$(HarvestSuppressAllWarnings)` if specified; otherwise, **false**. |
| `HarvestProjectsSuppressFragments` | Optional boolean property. Whether to suppress generation of separate fragments when harvesting. The default is `$(HarvestSuppressFragments)` if specified; otherwise, **true**. |
| `HarvestProjectsSuppressSpecificWarnings` | Optional string property. Specifies that certain warnings should be suppressed. The default is `$(HarvestSuppressSpecificWarnings)` if specified. |
| `HarvestProjectsSuppressUniqueIds` | Optional boolean property. Whether to suppress generation of unique component IDs. The default is `$(HarvestSuppressUniqueIds)` if specified; otherwise, **false**. |
| `HarvestProjectsTransforms` | Optional string property. Semicolon-delimited list of paths to XSL transforms to apply to the generated authoring. The default is `$(HarvestTransforms)` if specified. |
| `HarvestProjectsTreatSpecificWarningsAsErrors` | Optional string property. Specifies that certain warnings should be treated as errors. The default is `$(HarvestTreatSpecificWarningsAsErrors)` if specified. |
| `HarvestProjectsTreatWarningsAsErrors` | Optional boolean property. Specifies that all warnings should be treated as errors. The default is `$(HarvestTreatWarningsAsErrors)` if specified; otherwise, **false**. |
| `HarvestProjectsVerboseOutput` | Optional boolean property. Specifies that the tool should provide verbose output. The default is `$(HarvestVerboseOutput)` if specified; otherwise, **false**. |

Example:

```xml
<Project Sdk="WixToolset.Sdk">
  <PropertyGroup>
    <EnableProjectHarvesting>true</EnableProjectHarvesting>
    <HarvestProjectsSuppressUniqueIds>true</HarvestProjectsSuppressUniqueIds>
  </PropertyGroup>

  <ItemGroup>
    <HarvestProject Include="..\MyProgram\MyProgram.csproj" ProjectOutputGroups="Binaries;Content;" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="..\MyProgram\MyProgram.csproj" DoNotHarvest="true" />
  </ItemGroup>

  <ItemGroup>
    <PackageReference Include="WixToolset.Heat" />
  </ItemGroup>
</Project>
```

Heat creates a `ComponentGroup` for each of the selected `ProjectOutputGroups`. Use `ComponentGroupRef`s to include these in your installation.

Example:
```xml
<ComponentGroupRef Id="MyProgram.Binaries" />
<ComponentGroupRef Id="MyProgram.Content" />
```
