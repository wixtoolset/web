---
title: ProviderKey Attribute (Dependency Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>                 Optional attribute to explicitly author the provider key for the entire bundle.             </dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../wix/bundle">Bundle</a>
  </dd>
  <dt>Remarks</dt>
  <dd><p>                         This provider key is designed to persist throughout compatible upgrades so that dependent bundles do not have to be reinstalled                         and will not prevent your product from being upgraded. If this attribute is not authored, the value is the                         automatically-generated bundle ID and will not automatically support upgrades.                     </p><p>                         Only a single provider key is supported for bundles. To author that your bundle provides additional features via                         packages, author different provider keys for your packages.                     </p></dd>
  <dt>See Also</dt>
  <dd>
    <a href="../dependency">Dependency Schema</a>, <a href="../dependency/provides" class="extension">Provides</a></dd>
</dl>
