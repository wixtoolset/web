---
wip: 3249
type: Feature
author: r.sean.hall at gmail dot com
title: Allow BA to Run Elevated Async Process Through the Engine
draft: false
---

## User stories

* As a setup developer I can create an elevated process asynchronously from a per-machine bundle without inflicting multiple UAC prompts on the user.

## Security Context

There are currently two ways that the BA can execute arbitrary processes with elevation with only one UAC prompt.

One way is to hack the .exe manifest to require administrator.  Running the BA elevated is asking for trouble. There's nothing we can do to prevent this, beyond making the engine refuse to run in this scenario.

The second way is to put an EXE package in the chain that simply runs the executable specified in its command-line arguments.  We can't prevent this either without crippling EXE packages.  When you include an EXE package in the chain that will run anything you tell it, that means that compromising the BA gives an attacker the ability to run elevated code, which means game over.


## Proposal

Add the following method to `IBootstrapperEngine`:

    // Run approved .exe from custom path.
    STDMETHOD(RunExeElevatedFromPath)(
        __in_z LPCWSTR wzApprovedExeForElevationId,
        __in_z LPCWSTR wzExecutablePath,
        __in_z_opt LPCWSTR wzArguments,
        __out DWORD dwProcessId
        ) = 0;

The engine will verify that the file specified by `wzExecutablePath` matches the information in the engine manifest (like it normally verifies a file when putting it in the cache).  In order to perform this verification, the path must be in a secure folder.  For now, the Package Cache folder and the Program Files folder (x86 and x64) are the only folders considered secure.  If the file is not inside one of these folders, then the engine will return Access Denied.  Normally the file would be an .exe that the bundle installed.

After verification, the engine will call `CreateProcess`.

In order to get an .exe approved to be run elevated, add a new element `ApprovedExeForElevation`.  This element is a child of `Bundle`, and can occur 0-unbounded times.

    <xs:element name="ApprovedExeForElevation">
      <xs:annotation>
        <xs:documentation>Provides information about an .exe so that the BA can request the engine to run it elevated from anywhere.</xs:documentation>
        <xs:appinfo>
          <xse:parent namespace="http://schemas.microsoft.com/wix/2006/wi" ref="Bundle" />
        </xs:appinfo>
      </xs:annotation>
      <xs:complexType>
        <xs:attribute name="Id" type="xs:string">
          <xs:annotation>
            <xs:documentation>The identifier of the ApprovedExeForElevation element.</xs:documentation>
          </xs:annotation>
        </xs:attribute>
        <xs:attribute name="SourceFile" type="xs:string">
          <xs:annotation>
            <xs:documentation>The .exe file</xs:documentation>
          </xs:annotation>
        </xs:attribute>
	    <xs:attribute name="SuppressSignatureVerification" type="YesNoTypeUnion">
	      <xs:annotation>
	        <xs:documentation>
	          By default, a Bundle will use the .exe's Authenticode signature to verify the contents. If the package does not have an Authenticode signature then the Bundle will use a hash of the .exe instead. Set this attribute to "yes" to suppress the default behavior and force the Bundle to always use the hash of the .exe even when the package is signed.
	        </xs:documentation>
	      </xs:annotation>
	    </xs:attribute>
      </xs:complexType>
    </xs:element>


## WixStandardBA

Add `LaunchTargetElevatedId` attribute to `bal:WixStandardBootstrapperApplication` element, which takes the `Id` of an `ApprovedExeForElevation` element. This will make WixStandardBA use the new `RunExeElevatedFromPath` method instead of `ShelExecute`.

Add `LaunchArguments` and `LaunchHidden` attributes to `bal:WixStandardBootstrapperApplication` to give a documented way to use the magic variables `LaunchArguments` and `LaunchHidden`. Specifying the `LaunchTargetElevatedId` attribute and the `LaunchHidden` attribute won't be allowed since `RunExeElevatedFromPath` doesn't give the ability to specify that.


## Considerations

The original proposal added a second method to allow the BA to run an EXE package from the chain.  This was removed because packages are supposed to be included in the chain to participate in the installation, not launch executables after the installation completed.

The ApprovedExeForElevation element could have another attribute, maybe `TargetPath`, that could point to the .exe with Variables.  This could let the BA pass in NULL for the path.  It could even be a required attribute, and then the `wzExecutablePath` parameter would be removed from `RunExeElevatedFromPath` (thus probably renaming it to RunApprovedExeElevated), requiring the path to be specified at compile time.  There's no security gained from doing this, however.

1. Should more features of CreateProcess be exposed?
1. Should there be a RemotePayload equivalent for ApprovedExeForElevation?
1. It would be nice if you could specify a FileId for an MsiPackage instead of pointing it to the original file.


## See Also

[WIXFEAT:3249](http://wixtoolset.org/issues/3249/)