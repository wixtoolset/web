---
sidebar_position: 95
---

# Validation

[Package validation](https://learn.microsoft.com/en-us/windows/win32/msi/package-validation) checks the content of MSI packages to, among other things, ensure the internal database structure follows (at least some of) the rules for MSI packages.

Building a package using [MSBuild](msbuild.md) automatically runs validation using the stock MSI SDK [ICEs](https://learn.microsoft.com/en-us/windows/win32/msi/ice-reference). To run validation when using the Wix.exe .NET tool, use the [`wix msi validate` subcommand](https://wixtoolset.org/docs/tools/wixexe/#msivalidate).


## Errors running validation

Because the stock MSI ICEs are implemented as custom actions that are executed after merging them into an MSI package being built, the user running validation must be able to run Windows Installer. That works fine on a typical developer machine. However, non-interactive, non-administrator system accounts typically cannot. (System accounts that are administrators typically _can_.) Unfortunately, non-interactive system accounts are commonly used on continuous integration build machines. So if validation succeeds on your machine but fails during a CI build, you've run into this problem.

Anecdotal evidence suggests that typical hosted CI build machines use service accounts that are incompatible with validation and because the hosted machines cannot be configured, there is no workaround to run validation during the build. The only option is to suppress validation by setting `<SuppressValidation>true</SuppressValidation>` in your WiX MSBuild project.

Self-hosted CI build machines can run validation if the service account is `LocalSystem` or another administrator user.
