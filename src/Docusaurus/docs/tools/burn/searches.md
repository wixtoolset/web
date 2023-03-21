---
sidebar_position: 2
---

# Burn system searches

Searches are used to detect if the target machine meets certain conditions. The result of a search is stored into a variable. Variables are then used to construct conditions. To author Burn searches, you need to reference the WixToolset.Util.wixext WiX extension.

The following searches are available:

- [ComponentSearch](../../schema/util/componentsearch.md)
- [DirectorySearch](../../schema/util/directorysearch.md)
- [FileSearch](../../schema/util/filesearch.md)
- [ProductSearch](../../schema/util/productsearch.md)
- [RegistrySearch](../../schema/util/registrysearch.md)
- [WindowsFeatureSearch](../../schema/util/windowsfeaturesearch.md)

A search can be dependent on the result of another search. To order searches, use the `After` attribute to schedule a search to take place after another search, when the variable from the first search has a value with the results of that search.

Here are some examples:

```xml
<util:RegistrySearch
    Id="RegistrySearchId64"
    Variable="RegistrySearchVariable64"
    Root="HKLM"
    Key="SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full"
    Value="Release"
    Result="value"
    Bitness="always64" />

<util:ProductSearch
    Id="ProductSearchId"
    Variable="ProductSearchVariable"
    UpgradeCode="{8C74C610-AB2A-4BFB-9FC6-8683A9100424}"
    Result="version" />

<util:DirectorySearch
    Id="DirectorySearchId"
    Variable="DirectorySearchVariable"
    Path="[WindowsFolder]System32"
    DisableFileRedirection="yes" />

<util:FileSearch
    Id="FileSearchId"
    Variable="FileSearchVariable"
    After="DirectorySearchId"
    Path="[DirectorySearchVariable]\mscoree.dll"
    Result="exists" />

<util:WindowsFeatureSearch
    Id="DetectSHA2SupportId"
    Variable="IsSHA2Supported"
    Feature="sha2CodeSigning" />
```
