---
title: WiX Schema References
layout: documentation
---
# WiX Schema References

This section contains schema reference information for WiX and extensions.

In order to use a schema, the DLL file where the schema is defined has to be imported into the installer project, and the schema namespace
has to be imported as an `xmlns` attribute at the root of the file where it is used. The respective DLL is in the `bin` folder under the WiX
installation folder. See the specifics for each schema in each schema description.

The exception is the Wix schema, which is automatically referenced and imported, and doesn't need to be manually imported.

* [Wix schema](wix/index.html)
* [Wixloc schema](wixloc/index.html)
* [Difxapp schema for WixDifxAppExtension](difxapp/index.html)
* [Firewall schema for WixFirewallExtension](firewall/index.html)
* [Gaming schema for WixGamingExtension](gaming/index.html)
* [Iis schema for WixIIsExtension](iis/index.html)
* [Lux schema for WixLuxExtension](lux/index.html)
* [Netfx schema for WixNetFxExtension](netfx/index.html)
* [Ps schema for WixPSExtension](ps/index.html)
* [Sql schema for WixSqlExtension](sql/index.html)
* [Tag schema for WixTagExtension](tag/index.html)
* [Util schema for WixUtilExtension](util/index.html)
* [Vs schema for WixVSExtension](vs/index.html)
