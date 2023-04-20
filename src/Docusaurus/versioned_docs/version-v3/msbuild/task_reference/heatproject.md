---
title: HeatProject Task
layout: documentation
---

# HeatProject Task

The <b>HeatProject</b> task wraps [heat.exe](../../overview/heat.md), the WiX harvester,
using the <b>project</b> harvesting type. It supports a variety of settings that
are described in more detail below. To control these settings in your .wixproj file,
you can create a PropertyGroup and specify the settings that you want to use for
your build process. The following is a sample PropertyGroup that contains settings
that will be used by the <b>HeatProject</b> task:

```xml
<HeatProject
    NoLogo="$(HarvestProjectsNoLogo)"
    SuppressAllWarnings="$(HarvestProjectsSuppressAllWarnings)"
    SuppressSpecificWarnings="$(HarvestProjectsSuppressSpecificWarnings)"
    ToolPath="$(WixToolPath)"
    TreatWarningsAsErrors="$(HarvestProjectsTreatWarningsAsErrors)"
    TreatSpecificWarningsAsErrors="$(HarvestProjectsTreatSpecificWarningsAsErrors)"
    VerboseOutput="$(HarvestProjectsVerboseOutput)"
    AutogenerateGuids="$(HarvestProjectsAutogenerateGuids)"
    GenerateGuidsNow="$(HarvestProjectsGenerateGuidsNow)"
    OutputFile="$(IntermediateOutputPath)_%(_Project.Filename).wxs"
    SuppressFragments="$(HarvestProjectsSuppressFragments)"
    SuppressUniqueIds="$(HarvestProjectsSuppressUniqueIds)"
    Transforms="%(_Project.Transforms)"
    Project="@(_Project)"
    ProjectOutputGroups="%(_Project.ProjectOutputGroups)"
/>
```

The following table describes the common WiX MSBuild parameters that are applicable
to the <b>HeatProject</b> task.

<table border="1" cellspacing="0" cellpadding="4">
    <tr>
        <td>
            <b>Parameter</b>
        </td>
        <td>
            <b>Description</b>
        </td>
    </tr>
    <tr>
        <td>
            <b>NoLogo</b>
        </td>
        <td>
            Optional <b>boolean</b> parameter.<br />
            <br />
            Specifies that the tool logo should be suppressed.
            The default is <b>false</b>.
            This is equivalent to the -nologo switch.</td>
    </tr>
    <tr>
        <td>
            <b>SuppressAllWarnings</b>
        </td>
        <td>
            Optional <b>boolean</b> parameter.<br />
            <br />
            Specifies that all warnings should be suppressed.
            The default is <b>false</b>.
            This is equivalent to the -sw switch.
        </td>
    </tr>
    <tr>
        <td>
            <b>SuppressSpecificWarnings</b>
        </td>
        <td>
            Optional <b>string</b> parameter.<br />
            <br />
            Specifies that certain warnings should be suppressed.
            This is equivalent to the -sw[N] switch.
        </td>
    </tr>
    <tr>
        <td>
            <b>TreatSpecificWarningsAsErrors</b>
        </td>
        <td>
            Optional <b>string</b> parameter.<br />
            <br />
            Specifies that certain warnings should be treated as errors.
            This is equivalent to the -wx[N] switch.
        </td>
    </tr>
    <tr>
        <td>
            <b>TreatWarningsAsErrors</b>
        </td>
        <td>
            Optional <b>boolean</b> parameter.<br />
            <br />
            Specifies that all warnings should be treated as errors.
            The default is <b>false</b>.
            This is equivalent to the -wx switch.
        </td>
    </tr>
    <tr>
        <td>
            <b>VerboseOutput</b>
        </td>
        <td>
            Optional <b>boolean</b> parameter.<br />
            <br />
            Specifies that the tool should provide verbose output.
            The default is <b>false</b>.
            This is equivalent to the -v switch.
        </td>
    </tr>
</table>

&nbsp;

The following table describes the parameters that are 
common to all heat tasks that are applicable to the <b>HeatProject</b>
task.

<table border="1" cellspacing="0" cellpadding="4">
    <tr>
        <td>
            <b>Parameter</b>
        </td>
        <td>
            <b>Description</b>
        </td>
    </tr>
    <tr>
        <td>
            <b>AutogenerateGuids</b></td>
        <td>
            Optional <b>boolean</b> parameter.<br />
            <br />
            Whether to generate authoring that relies on auto-generation of component GUIDs.
            The default is $(HarvestAutogenerateGuids) if specified; otherwise, <b>true</b>.
        </td>
    </tr>
    <tr>
        <td>
            <b>GenerateGuidsNow</b></td>
        <td>
            Optional <b>boolean</b> parameter.<br />
            <br />
            Whether to generate authoring that generates durable GUIDs when harvesting. The
            default is $(HarvestGenerateGuidsNow) if specified; otherwise, <b>false</b>.</td>
    </tr>
    <tr>
        <td>
            <b>OutputFile</b></td>
        <td>
            Required <b>item</b> parameter.<br />
            <br />
            Specifies the output file that contains the generated authoring.</td>
    </tr>
    <tr>
        <td>
            <b>SuppressFragments</b></td>
        <td>
            Optional <b>boolean</b> parameter.<br />
            <br />
            Whether to suppress generation of separate fragments when harvesting. The default
            is $(HarvestSuppressFragments) if specified; otherwise, <b>true</b>.</td>
    </tr>
    <tr>
        <td>
            <b>SuppressUniqueIds</b></td>
        <td>
            Optional <b>boolean</b> parameter.<br />
            <br />
            Whether to suppress generation of unique component IDs. The default
            is $(HarvestSuppressUniqueIds) if specified; otherwise, <b>false</b>.</td>
    </tr>
    <tr>
        <td>
            <b>Transforms</b></td>
        <td>
            Optional <b>string</b> parameter.<br />
            <br />
            XSL transforms to apply to all generated WiX authoring. Separate multiple transforms
            with semicolons. The default is $(HarvestTransforms) if specified.</td>
    </tr>
</table>

&nbsp;

The following table describes the parameters that are specific to the <b>HeatProject</b>
task.

<table border="1" cellspacing="0" cellpadding="4">
    <tr>
        <td>
            <b>Parameter</b>
        </td>
        <td>
            <b>Description</b>
        </td>
    </tr>
    <tr>
        <td>
            <b>Project</b></td>
        <td>
            Required <b>item group</b> parameter.<br />
            <br />
            The list of projects to harvest.
        </td>
    </tr>
    <tr>
        <td>
            <b>ProjectOutputGroups</b></td>
        <td>
            Optional <b>string</b> parameter.<br />
            <br />
            The project output groups to harvest. Separate multiple output groups with semicolons.
            Examples include "Binaries" and "Source".</td>
    </tr>
</table>
