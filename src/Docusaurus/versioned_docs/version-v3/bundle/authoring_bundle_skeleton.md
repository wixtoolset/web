---
title: Create the Skeleton Bundle Authoring
layout: documentation
---
# Create the Skeleton Bundle Authoring

The root element of a bundle is [&lt;Bundle&gt;](../xsd/wix/bundle.md). The [&lt;Bundle&gt;](../xsd/wix/bundle.md) element is a child directly under the [&lt;Wix&gt;](../xsd/wix/wix/wix.md) element. Here&apos;s an example of an empty bundle:

    <?xml version="1.0"?>
    <Wix xmlns="http://schemas.microsoft.com/wix/2006/wi">
      <Bundle>
        <!-- Contents of the bundle goes here -->
      </Bundle>
    </Wix>

In this example, you will be adding the following elements to the [&lt;Bundle&gt;](../xsd/wix/bundle.md) element:

* [&lt;BootstrapperApplicationRef&gt;](../xsd/wix/bootstrapperapplicationref.md)
* [&lt;Chain&gt;](../xsd/wix/chain.md)
* [&lt;Variable&gt;](../xsd/wix/variable.md)

As a start, add the two most common elements inside a [&lt;Bundle&gt;](../xsd/wix/bundle.md) :

    <?xml version="1.0"?>
    <Wix xmlns="http://schemas.microsoft.com/wix/2006/wi">
      <Bundle>
        <BootstrapperApplicationRef />
        <Chain>
        </Chain>
      </Bundle>
    </Wix>

The [&lt;BootstrapperApplicationRef&gt;](../xsd/wix/bootstrapperapplicationref.md) element will eventually point to the standard BootstrapperApplication provided by the WiX toolset and the [&lt;Chain&gt;](../xsd/wix/chain.md) element will eventually contain the ordered list of packages that make up the bundle.

Now that you have the skeleton authoring of a Bundle, you can move on to adding information for the [&lt;BootstrapperApplicationRef&gt;](../xsd/wix/bootstrapperapplicationref.md) element. See [Author the BootstrapperApplication for a Bundle](authoring_bundle_application.md).
