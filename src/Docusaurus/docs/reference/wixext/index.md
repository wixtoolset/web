---
sidebar_position: 70
---

# WiX extensions and custom actions

WiX extends the functionality of Windows Installer by providing _WiX Extensions_ that typically include compiler extensions to provide custom elements and attributes in your WiX authoring and custom actions to implement the extended functionality.

The following WiX extensions are provided by the WiX team:

| Extension | Documentation |
| --------- | ------------- |
| WixToolset.Bal.wixext | [Bal schema](reference/schema/bal/index.md) |
| WixToolset.ComPlus.wixext | [Complus schema](reference/schema/complus/index.md) |
| WixToolset.Dependency.wixext | [Dependency schema](reference/schema/dependency/index.md) |
| WixToolset.DifxApp.wixext | [Difxapp schema](reference/schema/difxapp/index.md) |
| WixToolset.DirectX.wixext | [Directx schema](reference/schema/directx/index.md) |
| WixToolset.Firewall.wixext | [Firewall schema](reference/schema/firewall/index.md) |
| WixToolset.Http.wixext | [Http schema](reference/schema/http/index.md) |
| WixToolset.Iis.wixext | [Iis schema](reference/schema/iis/index.md) |
| WixToolset.Msmq.wixext | [Msmq schema](reference/schema/msmq/index.md) |
| WixToolset.Netfx.wixext | [Netfx schema](reference/schema/netfx/index.md) |
| WixToolset.PowerShell.wixext | [Powershell schema](reference/schema/powershell/index.md) |
| WixToolset.Sql.wixext | [Sql schema](reference/schema/sql/index.md) |
| WixToolset.UI.wixext | [UI schema](reference/schema/ui/index.md) |
| WixToolset.Util.wixext | [Util schema](reference/schema/util/index.md) |
| WixToolset.VisualStudio.wixext | [Vs schema](reference/schema/vs/index.md) |


## Using extensions

To use a WiX extension during the build of your project, you need to load the extension and reference its namespace in your WiX authoring.

### Loading extensions using the WiX command-line .NET tool

### Loading extensions in an MSBuild .wixproj project

### Declare the extension namespace
