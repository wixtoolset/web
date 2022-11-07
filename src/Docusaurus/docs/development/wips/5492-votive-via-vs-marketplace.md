---
wip: 5492
type: Feature
by: Rob Mensching (rob at firegiant.com)
title: Votive via VS Marketplace
---

## User stories

* As a setup developer I can install Votive such that I can use the WiX
Toolset in Visual Studio 2017.

* As a setup developer I can install the WiX Toolset quickly.

* As a non-setup developer I can install only Votive such that opening a
solution with a .wixproj does not error.

* As a WiX developer I can see how many times Votive is installed into each
Visual Studio version such that I can make educated decisions about future
Visual Studio support.


## Proposal

Visual Studio 2017 introduced a number of breaking changes that makes it
challenging to impossible to distribute Visual Studio Extensions purely via an MSI
package. To support VS2017, the WiX Toolset will publish Votive via VSIX to
the [Visual Studio Marketplace][vsm]. When the [Repository Reorganization][repos]
work is complete, Votive will be removed from the WiX Toolset bundle and
only available from the Visual Studio Marketplace for all versions of Visual Studio.

The "WiX Toolset Visual Studio YYYY Extension" (where YYYY is 2010, 2012, 2013,
2015 or 2017) will be the display name for Votive in the Marketplace. There will be
a separate entry in the Marketplace for each Visual Studio version so we get
accurate download numbers of Votive per Visual Studio version.

In addition to VS2017 support, publishing Votive independent of the WiX Toolset
enables non-setup developers to install the Votive without installing all of
the WiX Toolset. This will allow .sln files with .wixprojs to load without error
although the projects cannot be built. However, it is easy to use Visual Studio's
using Solution Build Configuration Manager to create a build configuration that
skips .wixprojs.

A final benefit of extracting Votive from the WiX Toolset bundle, is that the WiX
Toolset will now install/uninstall/update very quickly. Today the bulk of the
time spent in installation is executing `devenv /setup` so Visual Studio will
recognize Votive. That will no longer be necessary when Votive is available
only via the Visual Studio Marketplace.

There is a singular disadvantage. The WiX Toolset bundle will longer install
"everything you need to get going" for everyone. On a clean machine it will
take two steps for developers to get Visual Studio fully configured. We could
re-create the single installation experience if we introduced the VSIX installs
into the bundle. But this would skew installation numbers via Visual Studio
Marketplace and slow the installation again (VSIXs take a bit to detect whether
they are applicable).

For now we'll go with the simple solution of distributing the "WiX Toolset Visual
Studio YYYY Extension" solely via the Visual Studio Marketplace.


## Considerations

* When the "WiX Toolset Visual Studio YYYY Extension" is available for pre-2017
Visual Studio versions there is the potential for confusion in WiX v3.x since
Votive is still installed as part of the WiX Toolset. One consideration is to
introduce this change into WiX v3.11 so developers are exposed to the change
as soon as possible.

* The VSIX identifiers will use `WixToolset.Dev##` where `##` is the codename
for Visual Studio. This removes the necessity of updating pre-released VSIXs
when the marketing name of Visual Studio is finally known. For example,
"WiX Toolset Visual Studio 2017 Extension" will always use the id
`WixToolset.Dev15` even though the display name metdata would be updated
when the VS marketing name is known.

* It is technically possibile to ship VS2010-VS2015 support or VS2012-VS2017
support in a single VSIX. However, it is not possible to ship VS2010 and
VS2017 support in the same VSIX. This is moot since we want separate entries
in the Visual Studio Marketplace for each VS version to track download
numbers correctly.


## See Also

* [WIXFEAT:5492 - Votive via VS Marketplace][5492]

[5492]: https://github.com/wixtoolset/issues/issues/5492
[repos]: 5489-repository-reorganization.md
[vsm]: https://marketplace.visualstudio.com/
