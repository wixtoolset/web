---
title: Using Built-in WixUI Dialog Sets
layout: documentation
---

# Using Built-in WixUI Dialog Sets

The WixUI dialog library contains the following built-in dialog sets that provide a familiar wizard-style setup user interface.

1. [WixUI_Advanced](dialog_reference/wixui_advanced.md)
1. [WixUI_FeatureTree](dialog_reference/wixui_featuretree.md)
1. [WixUI_InstallDir](dialog_reference/wixui_installdir.md)
1. [WixUI_Minimal](dialog_reference/wixui_minimal.md)
1. [WixUI_Mondo](dialog_reference/wixui_mondo.md)

The built-in WixUI dialog sets are also customizable, from the bitmaps shown in the UI to adding and removing custom dialogs. See [Customizing the WixUI Dialog Sets](wixui_customizations.md) for additional information.

## How to add a built-in WixUI dialog set to a product installer

Assuming you have an existing installer that is functional but is just lacking a user interface, here are the steps you need to follow to include a built-in WixUI dialog set:

1. Add a UIRef element to your setup authoring that has an Id that matches the name of one of the dialog sets described above. For example:

```
<Product ...>
<UIRef Id="WixUI_InstallDir" />
</Product>
```

2. Pass the -ext and -cultures switches to [light.exe](../overview/light.md) to reference the WixUIExtension. For example:

```
light -ext WixUIExtension -cultures:en-us Product.wixobj -out Product.msi
```

Note - If you are using WiX in Visual Studio you can add the WixUIExtension using the Add Reference dialog and the necessary command lines will automatically be added when linking your .msi. To do this, use the following steps:

1. Open your WiX project in Visual Studio
2. Right click on your project in Solution Explorer and select Add Reference...
3. Select the **WixUIExtension.dll** assembly from the list and click Add
4. Close the Add Reference dialog
