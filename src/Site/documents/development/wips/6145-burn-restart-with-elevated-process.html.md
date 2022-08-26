---
wip: 6145
type: Feature
by: Sean Hall (rseanhall at gmail.com)
title: Burn restart with elevated process
draft: false
---

## User stories

* As a setup developer I can build a Burn bundle such that it can restart on hardened machines where the unelevated process doesn't have the privilege to shutdown the machine.


## Background

On Windows, the process token must have the SE_SHUTDOWN_NAME privilege enabled in order to request that the machine be shutdown or restarted.
The default configuration on client OS's (for example, Windows 11) gives this privilege to elevated admins, unelevated admins, and non-admins.
The default configuration on server OS's (for example, Server 2022) has gradually removed this privilege except from elevated admins.
This means that Burn bundles have been failing to request a restart on a growing number of machines.

All proposals below require the ability to create an elevated process.
Under certain configurations of Windows, Burn will not have that ability.
By the time that the engine realizes that the restart request has failed, the BA is no longer available.
Unless Burn is going to pop up a message box itself, the only thing it can do is log the error.


## Proposal 1 - Use elevated engine

Most bundles that want to restart will have already started an elevated engine.
Under this proposal, the unelevated process will tell the elevated engine to request the restart instead of making the request itself.
If the bundle never started an elevated engine, then it will attempt to request the restart like it does today.

To help BA's know whether the bundle will require an elevated engine to restart, a new built-in variable, `WixCanRestart`, will be added.
If that variable is false, the built-in BA's will be updated to show the UAC shield on the Restart button and call IBootstrapperEngine::Elevate if necessary before shutting down.

## Considerations for Proposal 1

This proposal is the most user friendly since most bundles that want to restart will have already started an elevated engine, so there should be at most one UAC prompt.

Adding the ability for the unelevated engine to tell the elevated engine to request a restart is technically a privilege escalation vulnerability and a denial of service risk.
While mitigations like requiring that the elevated engine ran a package that required a restart could be added, I don't think it's worth worrying about.
An attacker would require code execution to exploit this vulnerability as well as a user that accepts the UAC prompt.


## Proposal 2 - Add new elevation mode

The same `WixCanRestart` built-in variable as in Proposal 1 will be added.
If that variable is false, the built-in BA's will be updated to show the UAC shield on the Restart button.

If that variable is false, the unelevated engine will use `ShellExecuteEx` and the `runas` verb to run `{bundle}.exe -burn.restartnow` instead of programmatically requesting the restart.


## Considerations for Proposal 2

This proposal would always require an additional UAC prompt.
It may be confusing to the user why the bundle wants to elevate itself multiple times.


## Proposal 3 - Use shutdown.exe

The same `WixCanRestart` built-in variable as in Proposal 1 will be added.
If that variable is false, the built-in BA's will be updated to show the UAC shield on the Restart button.

If that variable is false, the unelevated engine will use `ShellExecuteEx` and the `runas` verb to run `shutdown.exe /r /d p:4:2` instead of programmatically requesting the restart.


## Considerations for Proposal 3

This proposal would always require an additional UAC prompt, but it should always be a trusted program since it should be signed by Microsoft.

This proposal relies on `shutdown.exe` being available and not blocked by policy.


## See Also

[WIXFEAT:6145](http://github.com/wixtoolset/issues/issues/6145)
[WIXFEAT:5499](http://github.com/wixtoolset/issues/issues/5499)
[WIXFEAT:5650](http://github.com/wixtoolset/issues/issues/5650)
