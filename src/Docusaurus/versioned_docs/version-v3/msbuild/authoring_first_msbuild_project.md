---
title: Creating a .wixproj File
layout: documentation
---
# Creating a .wixproj File

In order to build WiX using MSBuild, a .wixproj file must be created. The easiest way to create a new .wixproj for your installer is to WiX in Visual Studio because it automatically generates standard msbuild project files that can be built on the command line by simply typing:

*msbuild &lt;projectfile&gt;.wixproj*

If you do not have Visual Studio available, a .wixproj file can be created using any text editor. The following is a sample .wixproj file that builds an installer consisting of a single product.wxs file. 
If you want to copy and paste this example, remember to change the &lt;ProjectGuid&gt; 
value to match your own.

```
<Project DefaultTargets="Build" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <PropertyGroup>
    <Configuration Condition=" '$(Configuration)' == '' ">Debug</Configuration>
    <Platform Condition=" '$(Platform)' == '' ">x86</Platform>
    <ProductVersion>3.0</ProductVersion>
    <ProjectGuid>{c523055d-a9d0-4318-ae85-ec934d33204b}</ProjectGuid>
    <SchemaVersion>2.0</SchemaVersion>
    <OutputName>WixProject1</OutputName>
    <OutputType>Package</OutputType>
    <WixTargetsPath Condition=" '$(WixTargetsPath)' == '' ">$(MSBuildExtensionsPath)\Microsoft\WiX\v[[Version.Major]].x\Wix.targets</WixTargetsPath>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug|x86' ">
    <OutputPath>bin\$(Configuration)\</OutputPath>
    <IntermediateOutputPath>obj\$(Configuration)\</IntermediateOutputPath>
    <DefineConstants>Debug</DefineConstants>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Release|x86' ">
    <OutputPath>bin\$(Configuration)\</OutputPath>
    <IntermediateOutputPath>obj\$(Configuration)\</IntermediateOutputPath>
  </PropertyGroup>
  <ItemGroup>
    <Compile Include="Product.wxs" />
  </ItemGroup>
  <Import Project="$(WixTargetsPath)" />
</Project>
```

Additional .wxs files can be added using additional &lt;Compile&gt; elements within an ItemGroup. Localization files (.wxl) should be added using the &lt;EmbeddedResource&gt; element within an ItemGroup. Include files (.wxi) should be added using the &lt;Content&gt; element within an ItemGroup.
