---
title: Author Bootstrapper Application for a Bundle
layout: documentation
after: authoring_bundle_skeleton
---
# Author Bootstrapper Application for a Bundle

Every bundle requires a bootstrapper application to drive the Burn engine. The [BootstrapperApplication](../xsd/wix/bootstrapperapplication.md) element is used to define a new bootstrapper application. The [BootstrapperApplicationRef](../xsd/wix/bootstrapperapplicationref.md) element is used to refer to a bootstrapper application that exists in a [Fragment](../xsd/wix/fragment.md) or WiX extension.

The [WiX Standard Bootstrapper Application](wixstdba/index.md) exists in the WixBalExtension.dll. The following shows how to use it in a bundle:

```xml
<?xml version="1.0"?>
<Wix xmlns="http://schemas.microsoft.com/wix/2006/wi">
  <Bundle>
    <BootstrapperApplicationRef Id="WixStandardBootstrapperApplication.RtfLicense" />
    <Chain>
    </Chain>
  </Bundle>
</Wix>
```

The WiX Standard Bootstrapper Application may not provide all functionality a specialized bundle requires so a custom bootstrapper application DLL may be developed. The following example creates a bootstrapper application using a fictional "ba.dll":

```xml
<?xml version="1.0"?>
<Wix xmlns="http://schemas.microsoft.com/wix/2006/wi">
  <Bundle>
    <BootstrapperApplication SourceFile="path\to\ba.dll" />
    <Chain>
    </Chain>
  </Bundle>
</Wix>
```

Inside the [BootstrapperApplication](../xsd/wix/bootstrapperapplication.md) element and [BootstrapperApplicationRef](../xsd/wix/bootstrapperapplicationref.md) element, you may add additional payload files such as resources files that are required by the bootstrapper application DLL as follows:

```xml
<?xml version="1.0"?>
<Wix xmlns="http://schemas.microsoft.com/wix/2006/wi">
  <Bundle>
    <BootstrapperApplication SourceFile="path\to\ba.dll">
      <Payload SourceFile="path\to\en-us\resources.dll" />
      <PayloadGroupRef Id="ResourceGroupforJapanese" />
    </BootstrapperApplication>
    <Chain>
    </Chain>
  </Bundle>
</Wix>
```

This example references a payload file that is on the local machine named resources.dll, as well as a group of payload files that are defined in a [PayloadGroup](../xsd/wix/payloadgroup.md) element inside a [Fragment](../xsd/wix/fragment.md) elsewhere.

The next step is to [add installation packages to the chain](authoring_bundle_package_manifest.md).
