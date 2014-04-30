---
wip: 3249
type: Feature
author: r.sean.hall at gmail dot com
title: Allow BA to Run Elevated Async Process Through the Engine
draft: true
---

## User stories

* As a setup developer I can create an elevated process asynchronously from a per-machine bundle without inflicting multiple UAC prompts on the user.


## Proposal

Add the following methods to `IBootstrapperEngine`:

    // Run payload from cache.
    STDMETHOD(RunExeElevated)(
        __in_z LPCWSTR wzPayloadId,
        __in_z_opt LPCWSTR wzArguments,
        __out DWORD dwProcessId
        ) = 0;

    // Run approved .exe from custom path.
    STDMETHOD(RunExeElevatedFromPath)(
        __in_z LPCWSTR wzApprovedExeForElevationId,
        __in_z LPCWSTR wzExecutablePath,
        __in_z_opt LPCWSTR wzArguments,
        __out DWORD dwProcessId
        ) = 0;

For `RunExeElevated`, the payload must have been cached already. [WIXFEAT 4329](http://wixtoolset.org/issues/4329/) adds the ability to always cache a package.

For `RunExeElevatedFromPath`, the engine will verify that the file specified by `wzExecutablePath` matches the information in the engine manifest (like it normally verifies a file when putting it in the cache).  Normally this would be an .exe that the bundle installed.

For both of them, the engine will call `CreateProcess`.

In order to get an .exe approved to be run elevated, add a new element `ApprovedExeForElevation`.  This element is a child of `Bundle`, and can occur 0-unbounded times.

    <xs:element name="ApprovedExeForElevation">
      <xs:annotation>
        <xs:documentation>Provides information about an .exe so that the BA can request the engine to run it elevated from anywhere on the machine.</xs:documentation>
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


## Considerations

1. Should more features of CreateProcess be exposed?
1. Should there be a RemotePayload equivalent for ApprovedExeForElevation?
1. It would be nice if you could specify a FileId for an MsiPackage instead of pointing it to the original file.


## See Also

[WIXFEAT:3249](http://wixtoolset.org/issues/3249/)