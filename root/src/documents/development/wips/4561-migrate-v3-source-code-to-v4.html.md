---
wip: 4561
type: Feature
author: Rob Mensching (rob at firegiant.com)
title: Migrate v3 Source Code to v4.
---

## User stories

* As a setup developer I can evaluate the changes made in the WiX v4.0 schema such that I plan my migration.

* As a setup developer I have a tool to migrate my WiX v3.x source code to v4.0 such that I move to WiX v4.0 easily.


## Proposal

WiX v4.0 contains several breaking changes to the WiX schema. These breaking changes improve the WiX toolset language. The changes can also be the largest impediment to upgrading from WiX v3.x to WiX v4.0.

This document attempts to track all the breaking changes and how to address them so developers using WIX v3.x can plan their migration to WiX v4.0. It is expected that WixCop.exe will automatically update as many of these changes as possible. The **Considerations** section will list those that cannot be migrated programmatically.

1. Namespace changes. The main schema and all extension schemas were changed to allow unfettered change to the schema.

   Fix: Rename `http://schemas.microsoft.com/wix/2006/wi` to `http://wixtoolset.org/schemas/v4/wxs`

   Fix: Rename `http://schemas.microsoft.com/wix/BalExtension` to `http://wixtoolset.org/schemas/v4/wxs/bal`

   Fix: Rename `http://schemas.microsoft.com/wix/ComPlusExtension` to `http://wixtoolset.org/schemas/v4/wxs/complus`

   Fix: Rename `http://schemas.microsoft.com/wix/DependencyExtension` to `http://wixtoolset.org/schemas/v4/wxs/dependency`

   Fix: Rename `http://schemas.microsoft.com/wix/DifxAppExtension` to `http://wixtoolset.org/schemas/v4/wxs/difxapp`

   Fix: Rename `http://schemas.microsoft.com/wix/FirewallExtension` to `http://wixtoolset.org/schemas/v4/wxs/firewall`

   Fix: Rename `http://schemas.microsoft.com/wix/GamingExtension` to `http://wixtoolset.org/schemas/v4/wxs/gaming`

   Fix: Rename `http://schemas.microsoft.com/wix/IIsExtension` to `http://wixtoolset.org/schemas/v4/wxs/iis`

   Fix: Rename `http://schemas.microsoft.com/wix/MsmqExtension` to `http://wixtoolset.org/schemas/v4/wxs/msmq`

   Fix: Rename `http://schemas.microsoft.com/wix/NetFxExtension` to `http://wixtoolset.org/schemas/v4/wxs/netfx`

   Fix: Rename `http://schemas.microsoft.com/wix/PSExtension` to `http://wixtoolset.org/schemas/v4/wxs/powershell`

   Fix: Rename `http://schemas.microsoft.com/wix/SqlExtension` to `http://wixtoolset.org/schemas/v4/wxs/sql`

   Fix: Rename `http://schemas.microsoft.com/wix/TagExtension` to `http://wixtoolset.org/schemas/v4/wxs/tag`

   Fix: Rename `http://schemas.microsoft.com/wix/UtilExtension` to `http://wixtoolset.org/schemas/v4/wxs/util`

   Fix: Rename `http://schemas.microsoft.com/wix/VSExtension` to `http://wixtoolset.org/schemas/v4/wxs/vs`

   Fix: Rename `http://wixtoolset.org/schemas/thmutil/2010` to `http://wixtoolset.org/schemas/v4/thmutil`

   Fix: Rename `http://schemas.microsoft.com/wix/2009/Lux` to `http://wixtoolset.org/schemas/v4/lux`

2. File identifier generation. In WiX v3.x, file identifiers defaulted to the filename of a file. In WiX v4.0 the file identifier is generated from a combination of the file name plus its target directory.

   Fix: Explicitly set absent `Id` attributes on `File` element to the `Name` attribute or filename from the `Source` attribute.

3. Bundle package and payload signature verification. Late in WiX v3.9 the default for Bundle package and payload signature validation was changed to "off". That made the default for the optional `SuppressSignatureValidation` attribute `yes` and thus counter to the desired pattern where an absent boolean attribute is `no`.

  Fix: Rename `SuppressSignatureValidation` attribute on `ExePackage`, `MsiPackage`, `MspPackage`, `MsuPackage` and `Payload` elements to `EnableSignatureValidation`.


## Considerations

The following are a list of changes that cannot be automatically updated.

1. None at this time.


## See Also

[WIXFEAT:4561](http://wixtoolset.org/issues/4561/)
