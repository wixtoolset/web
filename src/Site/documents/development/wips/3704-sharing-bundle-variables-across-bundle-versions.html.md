---
wip: 3704
type: feature)
by: Jacob Hoover (jchoover at gmail.com)
title: Sharing Bundle Variables Across Bundle Versions
draft: true
---

## User stories

* As a Setup developer I can read previous user enterd setup options from a prior version of my bundle such that the user doesn't have to reconfigure the installation every time a new bundle is ran.


## Proposal

Modify the type on the persisted attribute of the Variable element for bundles to incude a shared option.
When a Variable is shared, not only will it be persisted, it will also store a copy of it's value in a variables subkey of the provider key in the registry. 
In addition, enhance butil to include new API's for reading variables 

    HRESULT DAPI BundleGetBundleSharedVariable(
        __in LPCWSTR wzBundleId,
        __in LPCWSTR wzAttribute,
        __out_opt LPDWORD pdwType,
        __out_bcount_opt(*pcbData) PVOID pvData,
        __inout_opt LPDWORD pcbData
        )
	
To allow bundles to read the variables (especially MBA's), enhancing EngineForApplication to add new methods: new API's

    STDMETHOD(GetRelatedBundleVariableNumeric)(
        __in_z LPCWSTR wzBundleId,
        __in_z LPCWSTR wzVariable,
        __out LONGLONG* pllValue
        ) = 0;

    STDMETHOD(GetRelatedBundleVariableString)(
        __in_z LPCWSTR wzBundleId,
        __in_z LPCWSTR wzVariable,
        __out_ecount_opt(*pcchValue) LPWSTR wzValue,
        __inout DWORD* pcchValue
        ) = 0;

    STDMETHOD(GetRelatedBundleVariableVersion)(
        __in_z LPCWSTR wzBundleId,
        __in_z LPCWSTR wzVariable,
        __out DWORD64* pqwValue
        ) = 0;

## Considerations

If a variable is marked as shared, it by definition won't be secure (IE don't mark passwords as shared). 

The assumption was made that the current calls to persist BA state are in the "right places" so I added an additional call to my new persistance method any time the call to RegistrationSaveState was called.  This new internal method is:

    HRESULT RegistrationSaveSharedVariables(
        __in BURN_REGISTRATION* pRegistration,
        __in BURN_VARIABLES* pVariables
    );

For the case of per user bundles we can jsut call this directly, however in the case of per machine bundles the call has to happen from the elevated BA.  To accomplish this I deserialized a private copy of the persisted variables in OnSaveState on the elevated BA and then called RegistrationSaveSharedVariables.

## See Also
