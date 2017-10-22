---
title: How To: Install a windows service
layout: documentation
---
# How To: Install a windows service
To install a Windows service, you use the [\<ServiceInstall>](./../../xsd/wix/serviceconfig.html) element from the Wix schema.
Fine-tuned configuration can be made using the [\<ServiceControl>](./../../xsd/wix/servicecontrol.html) element, and the \<ServiceConfig>
elements from the Wix and Util schema.

## Step 1: Add the \<ServiceInstall> element to Product.wxs
Your main XML file, normally named Product.wxs, should include a \<ServiceInstall> element with the basic information about the service to install.
This element should be the child of a [\<Component>](./../../xsd/wix/component.html). It is most useful to use the \<Component> representing
the service executable file as the parent.

In the \<ServiceInstall> you define various attributes of the service, as explained in the element's documentation.

**Tip:** to specify a system account, such as LocalService or NetworkService, use the prefix "NT AUTHORITY", e.g. use the value `NT AUTHORITY\LocalService`
to make the service run under this account.