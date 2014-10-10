---
wip: 4552
type: Feature
author: Sean Hall (rseanhall at gmail.com)
title: Variable Abstraction
draft: false
---

## User stories

* As a dutil consumer I can have access to WiX's variable and condition system.


## Proposal

Move the following methods from IBootstrapperEngine into a new COM interface: IVariableStore.
Make IBootstrapperEngine inherit from IVariableStore.
There will need to be a way to enumerate the variables, too.

* GetVariableNumeric
* GetVariableString
* GetVariableVersion
* SetVariableNumeric
* SetVariableString
* SetVariableVersion
* FormatString
* EscapeString
* EvaluateCondition

## Considerations


## See Also

[WIXFEAT:4552](http://wixtoolset.org/issues/4552/)
