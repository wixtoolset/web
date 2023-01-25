---
sidebar_position: 20
---

# Signing packages and bundles

## Signing Windows Installer packages

Windows Installer packages can be signed directly by signing tools like Signtool.exe. However, you can also sign cabinets that are external to the .msi file and include those signatures in the .msi so Windows Installer can verify that the cabinets haven't been tampered with.

:::info
If you're including MSI packages with external cabinets in a Burn bundle, it is not necessary to sign the cabinets. Instead, sign the bundle; the bundle includes a manifest that contains hashes for every file in the bundle. The bundle's signature ensures the validity of the manifest and Burn securely verifies the included hashes.

If you're embedding the cabinets in their MSI package, signing them is not necessary; just sign the MSI package instead. The signature on the MSI package includes the embedded cabinets.
:::


### Signing packages with MSBuild

To enable signing, set the `SignOutput` property to `true`:

```xml
<PropertyGroup>
  <SignOutput>true</SignOutput>
</PropertyGroup>
```

To sign external cabinets, create a `SignCabs` target in your .wixproj to call your signing tool:

```xml
<Target Name="SignCabs">
  <Message Importance="high" Text="SignCabs: @(SignCabs)" />
  <Exec Command='signtool.exe sign /v /f $(TestCertificate) /p password %(SignCabs.FullPath)' />
</Target>
```

To sign the MSI package, create a `SignMsi` target in your .wixproj to call your signing tool:

```xml
<Target Name="SignMsi">
  <Message Importance="high" Text="SignMsi: @(SignMsi)" />
  <Exec Command='signtool.exe sign /v /f $(TestCertificate) /p password "%(SignMsi.FullPath)" ' />
</Target>
```

The `SignMsi` target updates the MSI package with the signature information of any detached cabinets, then invokes your commands to do the signing.


### Signing packages at the command-line

The Wix.exe command-line tool lets you update the MSI package with the signature information of any detached cabinets. Signing the cabinets and the MSI package itself is left to your build tooling of choice.

To update an MSI package with the signatures of detached cabinets:

```sh
wix msi inscribe path\to\package.msi -out path\to\inscribedpackage.msi
```

To update an MSI package in-place with the signatures of detached cabinets:

```sh
wix msi inscribe path\to\package.msi
```


## Signing bundles

Signing bundles is slightly more complicated than signing packages because bundles need to be signed in two pieces:

1. The Burn engine, along with the bundle manifest and bootstrapper application, is extracted and cached for repair and uninstall operations. It needs to be signed so that those operations present the user with a "friendly" UAC consent prompt that identifies the bundle and signature.
2. The whole bundle .exe file needs to be signed to ensure that a compressed bundle with embedded packages can be verified.

Signing bundles requires the following flow:

1. Build the bundle.
2. Extract the Burn engine from the bundle.
3. Sign the Burn engine.
4. Reattach the signed Burn engine to the bundle.
5. Sign the whole bundle.


### Signing bundles with MSBuild

To enable signing, set the `SignOutput` property to `true`:

```xml
<PropertyGroup>
  <SignOutput>true</SignOutput>
</PropertyGroup>
```

To extract the Burn engine from the bundle, sign it, and reattach it, create a `SignBundleEngine` target in your .wixproj to call your signing tool:

```xml
<Target Name="SignBundleEngine">
  <Message Importance="high" Text="SignBundleEngine: @(SignBundleEngine)" />
  <Exec Command='signtool.exe sign /v /f $(TestCertificate) /p password %(SignBundleEngine.FullPath)' />
</Target>
```

To sign the whole bundle, create a `SignBundle` target in your .wixproj to call your signing tool:

```xml
<Target Name="SignBundle">
  <Message Importance="high" Text="SignBundle: @(SignBundle)" />
  <Exec Command='signtool.exe sign /v /f $(TestCertificate) /p password %(SignBundle.FullPath)' />
</Target>
```


### Signing bundles at the command-line

To extract the Burn engine from the bundle:

```sh
wix burn detach -engine path\to\extracted\burnengine.exe
```

Then sign path\to\extracted\burnengine.exe.

To reattach the signed Burn engine to the bundle:

```sh
wix burn reattach path\to\original\bundle.exe -engine path\to\extracted\burnengine.exe -o path\to\full\bundle.exe
```

Then sign path\to\full\bundle.exe.
