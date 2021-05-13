---
wip: 6264
type: Feature
by: James Parsons (japarson at microsoft.com)
title: Add DotNetCompatibilityCheck to the NetFx extension for the detection of .NET Core/.NET 5 runtimes
draft: false
---

## User stories
* As a Setup developer I can specify a .NET runtime package in my bundle with built-in and robust runtime installation detection.

* As a Setup developer I can run a check in my bundle that will determine if a specific version of the .NET runtime is installed such that the result can be used as an install condition for the runtime.

## Proposal
Right now, the NetFx extension supports .NET Core/.NET 5 runtime detection using a combination of path and registry checks. As discussed in [dotnet/runtime#36479](https://github.com/dotnet/runtime/issues/36479), this strategy is not sufficient for robust runtime installation detection.

An alternate solution is to use the the NETCoreCheck tool, built and published in the .NET repo [here](https://github.com/dotnet/deployment-tools/tree/master/src/clickonce/native/projects/NetCoreCheck). NetCoreCheck is a CLI tool that can determine if a specific .NET runtime can be executed on the system. Using this tool in the NetFx extension will allow us to easily handle runtime dependency installation for .NET Core package definitions, including newer version detection [#6257](https://github.com/wixtoolset/issues/issues/6257). The NetCoreCheck tool is already being used in Visual Studio by ClickOnce and Installer Projects for the same purpose.

I'm proposing that we create a `DotNetCompatibilityCheck` element in the NetFx extension that will allow us to run the NETCoreCheck tool and use the result as a condition to install a .NET runtime package. The element will be implemented as an extension search as defined by this [WIP](https://wixtoolset.org/development/wips/5539-modularize-burn-searches/). The NetCoreCheck tool will be included by the Burn engine as an embedded payload, which makes it available to the check through native code.

Using this approach will allow developers to avoid the question "is this software installed?", which can be misleading for .NET runtimes, in favor of "will my app run?". According to the [.NET Core Releases and Support page](https://devblogs.microsoft.com/dotnet/net-core-releases-and-support/), "Current" releases are supported for up to 3 months after the next major/minor release and "LTS" releases are supported for just 3 years. In addition, there are monthly servicing updates that are out of support as soon as the next one is released.

It is important for developers to keep their applications supported and secure. The easiest way to do that with such short periods of support for current releases is to utilize roll-forward policies. With this in mind, the question "will my app run on this PC?" becomes more important than "is this software installed?". If there is a newer version of the release available, developers will want their application to use that version.

The NetCoreCheck tool (after some improvements) will allow applications that use roll-forward policies to accurately detect if the app will run on the target PC. Without this check, it's possible the installer would install a .NET release that the app doesn't even use when running. For example, if there’s a 3.1 app with roll-forward set to "LatestMajor" and it gets installed using this design on a machine with just 5.0, we would install the 3.1 runtime but then 5.0 would still be loaded when the app runs. This approach will also avoid the situation described in [#6257](https://github.com/wixtoolset/issues/issues/6257) where an older patch version attempting to install over a newer one will fail.

The element will also be used for [#6264](https://github.com/wixtoolset/issues/issues/6264), Luke's proposal for .NET Core/.NET 5 runtime installation checks with custom actions and launch conditions. To make this possible, the element must me made available to bundles as well as MSIs.

I've designed a preliminary schema for `DotNetCompatibilityCheck` below:

    <xs:element name="DotNetCompatibilityCheck">
        <xs:annotation>
            <xs:documentation>Determines if an application that uses a specific version of the .NET runtime will run on the target machine.</xs:documentation>
            <xs:appinfo>
                <xse:parent namespace="http://wixtoolset.org/schemas/v4/wxs" ref="Bundle" />
                <xse:parent namespace="http://wixtoolset.org/schemas/v4/wxs" ref="Fragment" />
            </xs:appinfo>
        </xs:annotation>
        <xs:complexType>
            <xs:attribute name="Id" type="xs:string" use="required">
                <xs:annotation>
                    <xs:documentation>
                        The identifier for this DotNetCompatibilityCheck.
                    </xs:documentation>
                </xs:annotation>
            </xs:attribute>
            <xs:attribute name="RuntimeType" type="xs:string" use="required">
                <xs:annotation>
                    <xs:documentation>
                        The type of .NET runtime being checked for.
                    </xs:documentation>
                </xs:annotation>
                <xs:simpleType>
                    <xs:restriction base="xs:NMTOKEN">
                        <xs:enumeration value="aspnet">
                            <xs:annotation>
                                <xs:documentation>
                                    Attempt to check for an ASP.NET Core type runtime. The ASP.NET Core Runtime enables
                                    you to run web/server applications.
                                </xs:documentation>
                            </xs:annotation>
                        </xs:enumeration>
                        <xs:enumeration value="desktop">
                            <xs:annotation>
                                <xs:documentation>
                                    Attempt to check for a .NET Desktop type runtime. The .NET Desktop Runtime enables
                                    you to run Windows desktop applications.
                                </xs:documentation>
                            </xs:annotation>
                        </xs:enumeration>
                        <xs:enumeration value="core">
                            <xs:annotation>
                                <xs:documentation>
                                    Attempt to check for a .NET type runtime. The .NET Runtime contains just the components
                                    needed to run a console app.
                                </xs:documentation>
                            </xs:annotation>
                        </xs:enumeration>
                    </xs:restriction>
                </xs:simpleType>
            </xs:attribute>
            <xs:attribute name="Platform" type="xs:string" use="required">
                <xs:annotation>
                    <xs:documentation>
                        Sets the platform for the .NET runtime being checked for.
                    </xs:documentation>
                </xs:annotation>
                <xs:simpleType>
                    <xs:restriction base="xs:NMTOKEN">
                        <xs:enumeration value="x86">
                            <xs:annotation>
                                <xs:documentation>
                                    Attempt to check for the x86 version of a .NET runtime.
                                </xs:documentation>
                            </xs:annotation>
                        </xs:enumeration>
                        <xs:enumeration value="x64">
                            <xs:annotation>
                                <xs:documentation>
                                    Attempt to check for the x64 version of a .NET runtime.
                                </xs:documentation>
                            </xs:annotation>
                        </xs:enumeration>
                        <xs:enumeration value="arm64">
                            <xs:annotation>
                                <xs:documentation>
                                    Attempt to check for the ARM64 version of a .NET runtime.
                                </xs:documentation>
                            </xs:annotation>
                        </xs:enumeration>
                    </xs:restriction>
                </xs:simpleType>
            </xs:attribute>
            <xs:attribute name="RollForward" type="xs:string" use="optional">
                <xs:annotation>
                    <xs:documentation>
                        Sets the roll-forward policy that the application is using.
                    </xs:documentation>
                </xs:annotation>
                <xs:simpleType>
                    <xs:restriction base="xs:NMTOKEN">
                        <xs:enumeration value="latestpatch">
                            <xs:annotation>
                                <xs:documentation>
                                    Roll forward to the highest patch version. This disables minor version roll forward.
                                </xs:documentation>
                            </xs:annotation>
                        </xs:enumeration>
                        <xs:enumeration value="minor">
                            <xs:annotation>
                                <xs:documentation>
                                    Roll forward to the lowest higher minor version, if requested minor version is missing. If the requested minor version is present, then the latestpatch policy is used.
                                </xs:documentation>
                            </xs:annotation>
                        </xs:enumeration>
                        <xs:enumeration value="major">
                            <xs:annotation>
                                <xs:documentation>
                                    Roll forward to lowest higher major version, and lowest minor version, if requested major version is missing. If the requested major version is present, then the minor policy is used.
                                </xs:documentation>
                            </xs:annotation>
                        </xs:enumeration>
                        <xs:enumeration value="latestminor">
                            <xs:annotation>
                                <xs:documentation>
                                    Roll forward to highest minor version, even if requested minor version is present.
                                </xs:documentation>
                            </xs:annotation>
                        </xs:enumeration>
                        <xs:enumeration value="latestmajor">
                            <xs:annotation>
                                <xs:documentation>
                                    Roll forward to highest major and highest minor version, even if requested major is present.
                                </xs:documentation>
                            </xs:annotation>
                        </xs:enumeration>
                        <xs:enumeration value="disable">
                            <xs:annotation>
                                <xs:documentation>
                                    Do not roll forward. Only bind to specified version. This policy is not recommended for general use since it disable the ability to roll-forward to the latest patches. It is only recommended for testing.
                                </xs:documentation>
                            </xs:annotation>
                        </xs:enumeration>
                    </xs:restriction>
                </xs:simpleType>
            </xs:attribute>
            <xs:attribute name="Version" type="xs:string" use="required">
                <xs:annotation>
                    <xs:documentation>
                        The version of the .NET runtime being checked for (e.g. 3.1.10, 5.0.1).
                    </xs:documentation>
                </xs:annotation>
            </xs:attribute>
            <xs:attribute name="Variable" type="xs:string" use="required">
                <xs:annotation>
                    <xs:documentation>Name of the variable in which to place the result of the check.</xs:documentation>
                </xs:annotation>
            </xs:attribute>
            <xs:attribute name="Condition" type="xs:string">
                <xs:annotation>
                    <xs:documentation>Condition for evaluating the check. If this evaluates to false, the check is not executed at all.</xs:documentation>
                </xs:annotation>
            </xs:attribute>
            <xs:attribute name="After" type="xs:string">
                <xs:annotation>
                    <xs:documentation>Id of the element that this one should come after.</xs:documentation>
                </xs:annotation>
            </xs:attribute>
        </xs:complexType>
    </xs:element>

I've also designed a schema for the corresponding `DotNetCompatibilityCheckRef` element:

    <xs:element name="DotNetCompatibilityCheckRef">
        <xs:annotation>
            <xs:documentation>References a DotNetCompatibilityCheck.</xs:documentation>
            <xs:appinfo>
                <xse:parent namespace="http://wixtoolset.org/schemas/v4/wxs" ref="Bundle" />
                <xse:parent namespace="http://wixtoolset.org/schemas/v4/wxs" ref="Fragment" />
            </xs:appinfo>
        </xs:annotation>
        <xs:complexType>
            <xs:attribute name="Id" type="xs:string" use="required" />
        </xs:complexType>
    </xs:element>

A core component of this check is the NetCoreCheck exe which is a CLI tool that can be executed with the following arguments:

- Required framework name (Examples: "Microsoft.WindowsDesktop.App", "Microsoft.NETCore.App")
- Required major/minor/build framework version (Examples: "3.1.4", "5.0.0")
- Optional roll-forward policy (Example: "LatestPatch", "Minor")
  - Support for this argument is under development and tracked by [dotnet/deployment-tools/issues/82](https://github.com/dotnet/deployment-tools/issues/82).

And returns the following codes:

- Success: 0, Means the required runtime is installed on the machine
- Failure:
  - 1 - Failed to load HostFxr, meaning no runtime is installed
  - 2 - Failed to initialize HostFxr for the config, meaning the required runtime isn't installed
  - 3 - Invalid Args
  - Other - Unexpected failures

Examples:

- NetCoreCheck.exe Microsoft.WindowsDesktop.App 3.1.4
- NetCoreCheck.exe Microsoft.NETCore.App 5.0.0

It should be noted that there are two versions of the NetCoreCheck exe (Win-x64/Win-x86). Support for ARM64 is under development and tracked by [dotnet/deployment-tools/issues/81](https://github.com/dotnet/deployment-tools/issues/81);

The check can be used by Setup developers to detect .NET runtime installations as an installation condition for a .NET runtime package:

    <?xml version="1.0"?>
    <Wix xmlns="http://schemas.microsoft.com/wix/2006/wi"
         xmlns:netfx="http://schemas.microsoft.com/wix/NetFxExtension">
      <Fragment>
        <netfx:DotNetCompatibilityCheck Id="Runtime"
            RuntimeType="Desktop"
            Platform="x86"
            Version="3.1.10"
            Variable="DotNetCompatibilityCheckResult" />

        <PackageGroup Id="MyPackage">
          <ExePackage 
            SourceFile="[sources]\packages\shared\windowsdesktop-runtime-3.1.10-win-x86.exe"
            DownloadURL="https://download.visualstudio.microsoft.com/download/pr/865d0be5-16e2-4b3d-a990-f4c45acd280c/ec867d0a4793c0b180bae85bc3a4f329/windowsdesktop-runtime-3.1.10-win-x86.exe"
            InstallCommand="/q /ACTION=Install"
            RepairCommand="/q ACTION=Repair /hideconsole"
            UninstallCommand="/q ACTION=Uninstall /hideconsole"
            InstallCondition="x86 = 1 AND OSVersion >= v5.0.5121.0 AND DotNetCompatibilityCheckResult = 0" />
        </PackageGroup>
      </Fragment>
    </Wix>  

And in the NetFx extension to improve the installation detection of the built-in .NET Core/.NET 5 package groups:

NetCore3_Platform.wxi

    <?foreach PLATFORM in x86;x64?>
        <Fragment>
            <netfx:DotNetCompatibilityCheck Id="$(var.AspNetCoreId)"
                RuntimeType="ASP.NET"
                Platform="$(var.PLATFORM)"
                Version="$(var.NetCoreVersion)"
                Variable="$(var.AspNetCoreId)" />
        </Fragment>
    <?endforeach?>

    <?foreach PLATFORM in x86;x64?>
        <Fragment>
            <netfx:DotNetCompatibilityCheck Id="$(var.DesktopNetCoreId)"
                RuntimeType="Desktop"
                Platform="$(var.PLATFORM)"
                Version="$(var.NetCoreVersion)"
                Variable="$(var.DesktopNetCoreId)" />
        </Fragment>
    <?endforeach?>

    <?foreach PLATFORM in x86;x64?>
        <Fragment>
            <netfx:DotNetCompatibilityCheck Id="$(var.DotNetCoreId)"
                RuntimeType="Core"
                Platform="$(var.PLATFORM)"
                Version="$(var.NetCoreVersion)"
                Variable="$(var.DotNetCoreId)" />
        </Fragment>
    <?endforeach?>

NetCore3.1.8_x64.wxs

    <Fragment>
        <netfx:DotNetCompatibilityCheckRef Id="$(var.AspNetCoreId)" />

        <WixVariable Id="AspNetCoreRuntime$(var.NetCoreIdVersion)Redist$(var.NetCorePlatform)DetectCondition" Value="$(var.AspNetCoreId)" Overridable="yes" />
        <WixVariable Id="AspNetCoreRuntime$(var.NetCoreIdVersion)Redist$(var.NetCorePlatform)InstallCondition" Value="" Overridable="yes" />
        <WixVariable Id="AspNetCoreRuntime$(var.NetCoreIdVersion)Redist$(var.NetCorePlatform)PackageDirectory" Value="redist\" Overridable="yes" />
        <WixVariable Id="AspNetCoreRuntime$(var.NetCoreIdVersion)Redist$(var.NetCorePlatform)RepairCommand" Value="" Overridable="yes" />

        <PackageGroup Id="$(var.AspNetCoreRedistId)">
            <ExePackage
                Name="!(wix.AspNetCoreRuntime$(var.NetCoreIdVersion)Redist$(var.NetCorePlatform)PackageDirectory)aspnetcore-runtime-$(var.NetCoreVersion)-win-$(var.NetCorePlatform).exe"
                InstallCommand="$(var.AspNetCoreRedistInstallCommand)"
                RepairCommand="!(wix.AspNetCoreRuntime$(var.NetCoreIdVersion)Redist$(var.NetCorePlatform)RepairCommand)"
                UninstallCommand="$(var.AspNetCoreRedistUninstallCommand)"
                PerMachine="yes"
                DetectCondition="!(wix.AspNetCoreRuntime$(var.NetCoreIdVersion)Redist$(var.NetCorePlatform)DetectCondition)"
                InstallCondition="!(wix.AspNetCoreRuntime$(var.NetCoreIdVersion)Redist$(var.NetCorePlatform)InstallCondition)"
                Id="$(var.AspNetCoreRedistId)"
                Vital="yes"
                Permanent="yes"
                Protocol="burn"
                DownloadUrl="$(var.AspNetCoreRedistLink)"
                LogPathVariable="$(var.AspNetCoreRedistLog)"
                Compressed="no">
                <RemotePayload
                    CertificatePublicKey="3756E9BBF4461DCD0AA68E0D1FCFFA9CEA47AC18"
                    CertificateThumbprint="2485A7AFA98E178CB8F30C9838346B514AEA4769"
                    Description="Microsoft ASP.NET Core 3.1.8 - Shared Framework"
                    Hash="61DC9EAA0C8968E48E13C5913ED202A2F8F94DBA"
                    ProductName="Microsoft ASP.NET Core 3.1.8 - Shared Framework"
                    Size="7841880"
                    Version="3.1.8.20421" />
            </ExePackage>
        </PackageGroup>
    </Fragment>

Which can be used by Setup developers for built-in .NET runtime detection and installation in their bundles:

    <Chain>
        <PackageGroupRef Id="DotNetCoreRuntime31Redist_x64"/>
        <MsiPackage Id="MyApplication" SourceFile="$(var.MyApplicationSetup.TargetPath)"/>
    </Chain>

## Considerations
### DotNetCompatibilityCheck Implementation
There are a few different ways that we can implement .NET Core/.NET 5 runtime detection:
1. Run the NetCoreCheck exe to determine if a suitable runtime is installed by loading the .NET runtime. The NetCoreCheck tool will:
    - Attempt to locate hostfxr.dll using get_hostfxr_path.
    - Generate a temporary runtimeconfig.json file based on the runtime.
    - Load library hostfxr.dll and call hostfxr_initialize_for_runtime_config using the generated runtimeconfig.json file, success here means the necessary runtime is installed.
    - Call hostfxr_close and unload hostfxr library.
2. Parse the output of dotnet.exe --list-runtimes to determine which runtimes are installed (suggested by rseanhall in [#6264](https://github.com/wixtoolset/issues/issues/6264)).
    - More research will be needed to determine whether to try to locate the different architectures of dotnet.exe or create our own exes to run it through hostfxr_main.
3. Use the solution outlined in [dotnet/sdk/15021](https://github.com/dotnet/sdk/issues/15021) which involves using host fxr APIs along with installed bundle directory checks.
    - This is how dotnet.exe currently works.

Approach 1 is what I have proposed in the previous section. rseanhall mentioned that it could be more efficient to write code that could be shared with [#6264](https://github.com/wixtoolset/issues/issues/6264). One question I'm not sure about: can the NetCoreCheck-in-binary-table approach work for both [#6257: Burn chain](https://github.com/wixtoolset/issues/issues/6257) and [#6264: Custom actions/launch conditions](https://github.com/wixtoolset/issues/issues/6264)?

In [dotnet/runtime/36479](https://github.com/dotnet/runtime/issues/36479), vitek-karas addresses approach 2 (parsing the output of --list-runtimes):

> "I think the proposal (for this approach) is to add wrapper tool around the dotnet --list-runtimes that does the text processing and provides a return value, so that individual installers don't have to worry about it." <br><br> My understanding of the ask here is to answer a question like "Will application requiring framework XYZ run on this machine?". Answering that question from just a list of installed frameworks is actually non-trivial. The entire machinery of framework resolution, version conflict resolution and roll-forward is on top of the flat list. That's a lot of logic. So I don't think that parsing the dotnet.exe output is the right approach here.

I'm leaning towards the NetCoreCheck approach because it already exists, has been validated, and answers the valuable question of "will my app run?" instead of "is this software installed?".

Regarding approach 3, the hostfxr API in question is not currently available. Should it become available, we can easily add the functionality it provides to the NetCoreCheck tool.

## See Also
* [dotnet/runtime#36479](https://github.com/dotnet/runtime/issues/36479)
* [WIXFEAT:6257](https://github.com/wixtoolset/issues/issues/6257)
* [WIXFEAT:6264](https://github.com/wixtoolset/issues/issues/6264)