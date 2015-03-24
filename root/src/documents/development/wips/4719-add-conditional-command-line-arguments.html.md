---
wip: 4719
type: Feature
author: Bob Arnson (bob@firegiant.com)
title: Add conditional command-line arguments to bundle packages
draft: false
---

## User stories

* As a setup developer, I can author command-line arguments to an ExePackage in a bundle such that individual command-line arguments are included or excluded based on a condition. This allows me to, for example, omit command-line arguments that are empty or need to be omitted during uninstall.

## Proposal

1. Add a new CommandLine element as a child of [ExePackage](http://wixtoolset.org/documentation/manual/v3/xsd/wix/exepackage.html).
1. CommandLine has a Condition attribute that must evaluate to true at package invocation time for that particular CommandLine to apply.
1. CommandLine has an OnInstall attribute of YesNoType that tells Burn to evaluate the CommandLine only when the parent package is being installed.
1. CommandLine has an OnUninstall attribute of YesNoType that tells Burn to evaluate the CommandLine only when the parent package is being uninstalled.
1. CommandLine has an OnRepair attribute of YesNoType that tells Burn to evaluate the CommandLine only when the parent package is being repaired.
1. At least one of @OnInstall, @OnUninstall, and @OnRepair attributes must be set to "yes".
1. Multiple CommandLine elements are allowed; those with true conditions and matching @OnInstall, @OnUninstall, and @OnRepair attributes are concatenated with separating whitespace to create the command line passed to the package.
1. CommandLine children and the InstallCommand, UninstallCommand, and RepairCommand attributes cannot be used simultaneously.

## Considerations

1. CommandLineArgument might be a better, if lengthier, name.
1. Rather than have @OnInstall, @OnUninstall, and @OnRepair attributes, we could provide a property that developers could use in a Condition attribute as desired.
1. The [MsiProperty](http://wixtoolset.org/documentation/manual/v3/xsd/wix/msiproperty.html) element has similar semantics but each property is always passed to the MsiPackage regardless of action. We could add @OnInstall, @OnUninstall, and @OnRepair attributes would require defaulting them to "yes," which is always confusing. We could:
  1. Live with the confusion so as to not introduce a breaking change (i.e., specify @OnInstall/@OnUninstall/@OnRepair="no" to prevent the property from being added).
  1. Rename the attributes ("NotOnInstall"?) and implement them such that if any of the new names are specified, all other attribute values are assumed to be "no".
  1. Add the CommandLine element to all package types.
    * Do we care someone could pass arguments that aren't NAME=VALUE? Should we check and block?
  1. @rseanhall discovered the manifest MsiProperty/@RollbackValue attribute that isn't exposed in the WiX schema. Should we expose that via this change?
  
## See Also

[Issue 4719](http://wixtoolset.org/issues/4719/)