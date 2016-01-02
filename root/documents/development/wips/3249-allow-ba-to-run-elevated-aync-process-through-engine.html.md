---
wip: 3249
type: Feature
by: r.sean.hall at gmail dot com
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

    STDMETHOD(LaunchApprovedExe)(
        __in_opt HWND hwndParent,
        __in_z LPCWSTR wzApprovedExeForElevationId,
        __in_z_opt LPCWSTR wzArguments,
        __in DWORD dwWaitForInputIdleTimeout
        ) = 0;

The engine will use the given Id to lookup the registry location specified at compile time, and then get the executable path from there.
To ensure that an unprivileged user can't modify the target executable, the path must be in a secure folder.
For now, the Package Cache folder and the Program Files folder(s) (x86 and x64) are the only folders considered secure.
If the file is not inside one of these folders, then the engine will return Access Denied.
Normally the file would be an .exe that the bundle installed.
The engine will perform Variable substitution on wzArguments.

After verification, the engine will call `CreateProcess`, attempting to set the working directory to the .exe's directory.
If dwWaitForInputIdleTimeout is not zero, the engine will call WaitForInputIdle with the given timeout.
Finally, it will return the process id from the new `IBootstrapperApplication` method:

    // OnLaunchApprovedExeBegin - called before trying to launch the preapproved executable.
    //
    STDMETHOD_(int, OnLaunchApprovedExeBegin)() = 0;

    // OnLaunchApprovedExeComplete - called after trying to launch the preapproved executable.
    //
    // Parameters:
    //  dwProcessId is only valid if the operation succeeded.
    //
    STDMETHOD_(void, OnLaunchApprovedExeComplete)(
        __in HRESULT hrStatus,
        __in DWORD dwProcessId
        ) = 0;

In order to get an .exe approved to be run elevated, add a new element `ApprovedExeForElevation`.  This element is a child of `Bundle`, and can occur 0-unbounded times.

    <xs:element name="ApprovedExeForElevation">
      <xs:annotation>
        <xs:documentation>Provides a registry key path and value name that will point to an .exe so that the BA can request the engine to run it elevated.</xs:documentation>
        <xs:appinfo>
          <xse:parent namespace="http://schemas.microsoft.com/wix/2006/wi" ref="Bundle" />
        </xs:appinfo>
      </xs:annotation>
      <xs:complexType>
        <xs:attribute name="Id" type="xs:string" use="required">
          <xs:annotation>
            <xs:documentation>The identifier of the ApprovedExeForElevation element.</xs:documentation>
          </xs:annotation>
        </xs:attribute>
        <xs:attribute name="Key" type="xs:string" use="required">
          <xs:annotation>
            <xs:documentation>
              The key path.
              For security purposes, the root key will be HKLM and Variables are not supported.
            </xs:documentation>
          </xs:annotation>
        </xs:attribute>
        <xs:attribute name="Value" type="xs:string">
          <xs:annotation>
            <xs:documentation>
              The value name.
              For security purposes, Variables are not supported.
            </xs:documentation>
          </xs:annotation>
        </xs:attribute>
        <xs:attribute name="Win64" type="YesNoTypeUnion">
          <xs:annotation>
            <xs:documentation>
              Instructs the search to look in the 64-bit registry when the value is 'yes'.
              When the value is 'no', the search looks in the 32-bit registry.
              The default value is 'no'.
            </xs:documentation>
          </xs:annotation>
        </xs:attribute>
      </xs:complexType>
    </xs:element>


## WixStandardBA

Add `LaunchTargetElevatedId` attribute to `bal:WixStandardBootstrapperApplication` element, which takes the `Id` of an `ApprovedExeForElevation` element.
This will make WixStandardBA use the new `LaunchApprovedExe` method instead of `ShelExecute`.
If `LaunchApprovedExe` fails because of Access Denied, it will fallback to the previous behavior (calling `ShelExecute` on the executable specified in the `LaunchTarget` attribute).

Add `LaunchArguments` and `LaunchHidden` attributes to `bal:WixStandardBootstrapperApplication` to give a documented way to use the magic variables `LaunchArguments` and `LaunchHidden`.


## Considerations

The original proposal added a second method to allow the BA to run an EXE package from the chain.  This was removed because packages are supposed to be included in the chain to participate in the installation, not launch executables after the installation completed.

The second version of the proposal made the setup developer provide the EXE at compile time so it could be hashed.
The engine allowed the BA to specify the executable path in `LaunchApprovedExe`.
Then the engine confirmed that the executable was in a secure folder as well as matching the hash.
This was changed to getting the executable path from HKLM to support the scenario where the target executable is patched outside of the bundle.


## See Also

[WIXFEAT:3249](http://wixtoolset.org/issues/3249/)