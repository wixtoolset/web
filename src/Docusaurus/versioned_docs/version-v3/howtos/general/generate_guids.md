# How To: Generate a GUID

GUIDs are used extensively with the Windows Installer to uniquely identify products, components, upgrades, and other key elements of the installation process. To generate GUIDs use the <a href="http://msdn.microsoft.com/library/ms241442.aspx" target="_blank">guidgen tool</a> that ships with Visual Studio, generally located under **Tools > Create GUID** menu, or the <a href="http://www.guidgen.com/" target="_blank">GuidGen.com</a> site. GUIDs generated this way will work fine in WiX, however since they are in mixed case they may cause issues if you share them with users of other, non-WiX tools. For complete compatibility be sure to <a href="http://msdn.microsoft.com/library/aa368767.aspx" target="_blank">change the letters in the GUID to uppercase</a> prior to use.

All examples in the How To documentation use the text **PUT-GUID-HERE** for GUIDs. Every **PUT-GUID-HERE** must be replaced with a newly-generated GUID.

The [Component](../../xsd/wix/component.md), [Package](../../xsd/wix/package.md), [Patch](../../xsd/wix/patch.md),&nbsp; [Product](../../xsd/wix/product.md) elements support auto-generation of GUIDs every time you build your project by specifying a **\*** in place of the GUID. For example:

```xml
<Product Id="*"
         Version="1.0.0.0"
         Language="1033"
         Name="My Application Name"
         Manufacturer="My Manufacturer Name">
```

For the Component element the generated GUID is based on the install directory and filename of the KeyPath for the component. This GUID will stay consistent from build-to-build provided the directory and filename of the KeyPath do not change.
