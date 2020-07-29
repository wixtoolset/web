---
wip: 4863
type: Feature
by: Sean Hall (r sean hall at gmail.com)
title: Literal Variables in ThmUtil
draft: false
---

## User stories

* As a Setup developer I can create a thmutil based UI that prompts for paths such that the value can be passed on to packages unaltered.


## Required Functionality

In v3, wixstdba's "variable magic" for editbox controls was simple but couldn't properly handle escape characters. It populated the editbox with the raw value, and then saved the editbox's contents directly into the variable. In v4, thmutil needs to save the editbox's contents as a literal string. When populating the editbox, it needs to format the variable's value first.


## Proposal

Add a new Variable/@Type called `formatted`.
This corresponds to a new variant type: `BURN_VARIANT_TYPE_FORMATTED_STRING`.
These work the same as the `string` type in v3.

The existing `string` type in v4 will represent a literal string value.
This replaces the internal Burn functionality in v3 where a Variable could be set as "literal".
As in that case, when Burn tries to format a variable with a literal string value then the result is the string value unformatted.

Change the `SetVariableString` method on Burn's interface to

    STDMETHOD(SetVariableString)(
        __in_z LPCWSTR wzVariable,
        __in_z_opt LPCWSTR wzValue,
        __in BOOL fFormatted
        )


## Considerations

Some Setup developers may want to allow the users to specify Variables while using wixstdba.
This was possible in v3 but isn't under this proposal.
However, this should be possible with BAFunctions now that they are much more powerful in v4.

There were some questions about whether there is a need to be able to tell what the underlying type of a variable is.
There doesn't seem to be a valid scenario for this, the BA should already know the types of its variables.


## See Also

* [WIXFEAT:4863](https://github.com/wixtoolset/issues/issues/4863)
* [WIXFEAT:4763](https://github.com/wixtoolset/issues/issues/4763)
