---
sidebar_position: 0
---

# Get started with WiX

There are three ways to use WiX:

- [Command-line .NET tool](#nettool)
- [MSBuild on the command line and CI/CD build systems](#msbuild)
- [Visual Studio](#vs)


## Command-line .NET tool {#nettool}

WiX is available as a [.NET tool](https://learn.microsoft.com/en-us/dotnet/core/tools/global-tools) for your command-line pleasure.

:::note
The `wix.exe` tool requires the .NET SDK, version 6 or later.
:::

Wix.exe supports commands to perform particular operations. For example, the `build` command lets you build MSI packages, bundles, and other package types.

To install the Wix.exe .NET tool:

```sh
dotnet tool install --global wix
```

To verify Wix.exe was successfully installed:

```sh
wix --version
```

### Update the WiX .NET tool

To update your [.NET tool](https://learn.microsoft.com/en-us/dotnet/core/tools/global-tools) installation of WiX:

```sh
dotnet tool update --global wix
```

To install WiX for the first time as a .NET tool:

```sh
dotnet tool install --global wix
```

To verify Wix.exe was successfully installed or updated:

```sh
wix --version
```

### See also
- [Wix.exe command-line reference](./tools/wixexe.md)


## MSBuild on the command line and CI/CD build systems {#msbuild}

WiX is available as an MSBuild SDK for building from the command line using `dotnet build` from the .NET SDK or the .NET Framework-based `MSBuild` from Visual Studio. SDK-style projects have smart defaults that make for simple .wixproj project authoring. For example, here's a minimal .wixproj that builds an MSI from the .wxs source files in the project directory:

```xml
<Project Sdk="WixToolset.Sdk/5.0.1">
</Project>
```

### Update MSBuild projects

To update your .wixproj MSBuild projects from previous WiX releases, update the `Project` element's `Sdk` attribute:

```xml
<Project Sdk="WixToolset.Sdk/5.0.1">
```

For `PackageReference`s to WiX extensions, update their `Version` attribute. For example:

```xml
<PackageReference Include="WixToolset.Util.wixext" Version="5.*" />
<PackageReference Include="WixToolset.Netfx.wixext" Version="5.*" />
```

To clean up NuGet artifacts from previous releases of WiX, we recommend you delete the `bin` and `obj` directories in your projects. If you're using .NET Framework MSBuild, do an explicit `MSBuild -Restore` to get the latest version restored. (Using `dotnet build` does that implicitly for you.)

### See also
- [MSBuild reference](./tools/msbuild.md)


## Visual Studio {#vs}

[FireGiant](https://www.firegiant.com/) has released [HeatWave Community Edition][heatwave] to support WiX SDK-style MSBuild projects in Visual Studio. HeatWave supports:

- Conversion of WiX v3 projects and authoring
- Building of WiX SDK-style projects
- Project and item templates
- Property pages to control how the project builds

[HeatWave Community Edition is available free of charge.][heatwave]


[heatwave]: https://www.firegiant.com/wix/heatwave/


## Using development builds {#devbuilds}

WiX development builds with all the latest bug fixes are available in a NuGet package feed on GitHub. To add that feed as a package source:

```sh
dotnet nuget add source https://nuget.pkg.github.com/wixtoolset/index.json -n wixtoolset -u <username> -p <access-token>
```

You need to use exact versions for those packages. For example:

```xml
<Project Sdk="WixToolset.Sdk/6.0.0-rc.1-build.42">
</Project>
```

For more detailed instructions, check out [this video](https://youtu.be/2iIjq6zt6z0).


## Hello World from CLI

After having Wix now installed, let's make a very tiny example.
The goal is to have a MSI file which installs a "Hello World" program into `C:\Program Files (x86)`.

Let's get started:

1. Create a new working folder. Create all following files there.
1. Create a new file `HelloWorld.txt`
1. Create a new text file `package.wxs` with the following content:
   ```xml
   <Wix xmlns="http://wixtoolset.org/schemas/v4/wxs">
        <Package Name="Hello World" Manufacturer="Myself" UpgradeCode="554c904d-fef1-42d8-98f6-3930fdec7534" Version="0.1">
            <MediaTemplate EmbedCab="yes" />

            <StandardDirectory Id="ProgramFilesFolder">
                <Directory Id="HelloWorldFolder" Name="Hello World" />
            </StandardDirectory>

            <Feature Id="Main">
                <Component Directory="HelloWorldFolder">
                    <File Source="HelloWorld.txt" />
                </Component>
            </Feature>
        </Package>
    </Wix>
   ```
1. Run this command
    ```batch
    wix build .\package.wxs -o my.msi
    ```
    This command creates a new installer file `my.msi`
1. To install the installer, double click it or run
   ```batch
   msiexec /i my.msi /l*v install.log
   ```
   After successful installation, the program appears in the `C:\Program Files (x86)` folder.
1. To uninstall `Hello World`, use the Windows tool `Add/Remove Programs` or run this command:
   ```batch
   msiexec /x my.msi /l*v uninstall.log
   ```

Congratas, you just created your first simple installer.
