---
sidebar_position: 60
---

# Wix.exe command-line reference

:::info
TODO: WiX v4 documentation is under development.
:::

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

Wix.exe has the following switches common to all commands:

| Switch | Description |
| ------- | ----------- |
| `--help` or `-h` | Show command line help. |
| `--version` | Display WiX Toolset version in use. |
| `--nologo` | Suppress displaying the logo information. |


## `wix build` command {#build}


| Switch | Description |
| ------ | ----------- |
| `-arch` | Architecture of the package or bundle. Valid values are: *x86*, *x64*, *arm64*. Default: *x86*. Equivalent MSBuild property: `InstallerPlatform` |
| `-bindfiles` or `-bf` | Bind files into an output .wixlib. Ignored if not building a .wixlib. |
| `-bindpath` or `-b` | Bind path to search for content files. |
| `-bindpath:target` or `-bt` | Bind path to search for target package's content files. Only used when building a patch. |
| `-bindpath:update` or `-bu` | Bind path to search for update package's content files. Only used when building a patch. |
| `-cabcache` or `-cc` | Set a folder to cache cabinets across builds. |
| `-culture` | Adds a culture to filter localization files. |
| `-define` or `-d` | Sets a preprocessor variable. |
| `-defaultcompressionlevel` or `-dcl` | Specifies the compression level used when none is specified via `MediaTemplate` or `Media`. Valid values are: *none*, *low*, *medium*, *high*, *mszip*. Default: *medium*. Equivalent MSBuild property: `DefaultCompressionLevel` |
| `-ext` | [Load a WiX extension for use during the build.](#extension) |
| `-include` or `-i` | Folder to search for include files. |
| `-intermediatefolder` | Optional working folder. If not specified a folder in %TMP% will be created. |
| `-loc` | Localization file to use in the build. By default, .wxl files are recognized as localization. |
| `-lib` | Library file to use in the build. By default, .wixlb files are recognized as libraries. |
| `-src` | Source file to use in the build. By default, .wxs files are recognized as source code. |
| `-out` or `-o` | Path to output the build to. |
| `-outputtype` | Explicitly set the output type if it cannot be determined from the output. |
| `-pdb` | Optional path to output .wixpdb. Default will write .wixpdb beside output path. |
| `-pdbtype` | Switch to disable creation of .wixpdb. Types: full or none. |


## `wix msi` command {#msi}

The `wix msi` command has the following subcommands:

| Subcommand | Description |
| ---------- | ----------- |
| `wix msi decompile` | Converts a Windows Installer database back into source code. |
| `wix msi inscribe` | Updates MSI database with cabinet signature information. |
| `wix msi transform` | Creates an MST transform file. |
| `wix msi validate` | Validates MSI database using standard or custom ICEs. |


### `wix msi decompile` subcommand {#msidecompile}

### `wix msi inscribe` subcommand {#msiinscribe}

### `wix msi transform` subcommand {#msitransform}

### `wix msi validate` subcommand {#msivalidate}




## `wix burn` command {#burn}

The `wix burn` command has the following subcommands:

| Subcommand | Description |
| ---------- | ----------- |
| `wix burn detach` | Detach the Burn engine from a bundle so it can be signed. |
| `wix burn extract` | Extract the internals of a bundle to a folder. |
| `wix burn reattach` | Reattach a signed Burn engine to a bundle. |
| `wix burn remotepayload` | Generate source code for a remote payload. |


### `wix burn detach` and `wix burn reattach` subcommands {#burnsigning}

### `wix burn extract` subcommand {#burnextract}

### `wix burn remotepayload` subcommand {#burnremotepayload}


## `wix extension` command {#extension}

The `wix extension` command has the following subcommands:

| Subcommand | Description |
| ---------- | ----------- |
| `wix extension add` | Add extension to the cache. |
| `wix extension list` | List extensions in the cache. |
| `wix extension remove` | Remove extension from the cache. |


### `wix extension add` subcommand {#extensionadd}

### `wix extension list` subcommand {#extensionlist}

### `wix extension remove` subcommand {#extensionremove}



## `wix convert` command {#convert}

The `wix convert` command has the following switches:

| Switch | Description |
| ------ | ----------- |
| `--dry-run` or `-n` | Only display errors, do not update files. |
| `--recurse` or `-r` | Search for matching files in current dir and subdirs. |
| `-set1{file}` | Primary settings file. |
| `-set2{file}` | Secondary settings file (overrides primary). |
| `-indent:n` | Indentation multiple (overrides default of 4). |


## `wix format` command {#format}

The `wix format` command has the following switches:

| Switch | Description |
| ------ | ----------- |
| `--dry-run` or `-n` | Only display errors, do not update files. |
| `--recurse` or `-r` | Search for matching files in current dir and subdirs. |
| `-set1{file}` | Primary settings file. |
| `-set2{file}` | Secondary settings file (overrides primary). |
| `-indent:n` | Indentation multiple (overrides default of 4). |

