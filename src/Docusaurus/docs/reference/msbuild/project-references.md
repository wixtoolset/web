---
sidebar_position: 2
---

# Project references

`ProjectReference` items to other projects are an MSBuild mechanism to ensure that a dependency project is built before the project that depends on it. For example, a .wixproj project depends on a .csproj project to ensure that the application to be installed is built before the .wixproj that installs it.  The WiX MSBuild targets extend `ProjectReference`s to create bind paths and preprocessor variables that contain useful information about dependency projects.

:::note
Project names that are not identifiers will have invalid characters replaced with underscores. Identifiers begin with a letter or underscore and optionally followed by alphanumeric, underscores, and/or period characters. For example, `My Exe.csproj` contains a space that will be replaced and `My_Exe` will be used as the bindpath and preprocessor variable name.
:::


## Bind paths

The WiX MSBuild targets create a bind path to the output directory of each referenced project. That means you can specify, for example, an .exe from a .csproj project using just the file name. For example:

```xml
<File Source="ConsoleApp42.exe" />
```


## Preprocessor variables

The WiX MSBuild targets create a number of preprocessor variables for each referenced project.

| Variable | Example | Example value |
| -------- | ------- | ------------- |
| _ProjectName_.Configuration |  $(MyProject.Configuration) | Release |
| _ProjectName_.FullConfiguration | $(MyProject.FullConfiguration) | Release\|ARM64 |
| _ProjectName_.Platform | $(MyProject.Platform) | ARM64 |
| _ProjectName_.ProjectDir | $(MyProject.ProjectDir) | C:\source\repos\ConsoleApp42\ |
| _ProjectName_.ProjectExt | $(MyProject.ProjectExt) | .csproj |
| _ProjectName_.ProjectFileName | $(MyProject.ProjectFileName) | MyProject.csproj |
| _ProjectName_.ProjectName | $(MyProject.ProjectName) | MyProject |
| _ProjectName_.ProjectPath | $(MyProject.ProjectPath) | C:\source\repos\ConsoleApp42\MyApp.csproj |
| _ProjectName_.TargetDir | $(MyProject.TargetDir) | C:\source\repos\ConsoleApp42\bin\Release\ |
| _ProjectName_.TargetExt | $(MyProject.TargetExt) | .exe |
| _ProjectName_.TargetFileName | $(MyProject.TargetFileName) | MyProject.exe |
| _ProjectName_.TargetName | $(MyProject.TargetName) | MyProject |
| _ProjectName_.TargetPath | $(MyProject.TargetPath) | C:\source\repos\ConsoleApp42\bin\Release\MyProject.exe |
| _ProjectName_.Culture.TargetPath | $(MyProject.en-US.TargetPath) | C:\source\repos\ConsoleApp42\bin\Release\en-US\MyProject.msi |
| SolutionDir | $(SolutionDir) | C:\source\repos\MySolution\ |
| SolutionExt | $(SolutionExt) | .sln |
| SolutionFileName | $(SolutionFileName) | MySolution.sln |
| SolutionName | $(SolutionName) | MySolution |
| SolutionPath | $(SolutionPath) | C:\source\repos\MySolution\MySolution.sln |
