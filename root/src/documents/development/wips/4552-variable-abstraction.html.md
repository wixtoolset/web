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

Implement the following variable API:

    typedef void* VARIABLE_ENUM_HANDLE;
    typedef void* VARIABLES_HANDLE;
    typedef const void* C_VARIABLES_HANDLE;

    extern const int VARIABLE_ENUM_HANDLE_BYTES;
    extern const int VARIABLES_HANDLE_BYTES;

    typedef void(*PFN_FREEVARIABLECONTEXT)(
        __in LPVOID pvContext
        );

    typedef enum VARIABLE_VALUE_TYPE
    {
        VARIABLE_VALUE_TYPE_NONE,
        VARIABLE_VALUE_TYPE_NUMERIC,
        VARIABLE_VALUE_TYPE_STRING,
        VARIABLE_VALUE_TYPE_VERSION,
    } VARIABLE_VALUE_TYPE;

    typedef struct _VARIABLE_VALUE
    {
        VARIABLE_VALUE_TYPE type;
        union
        {
            LONGLONG llValue;
            DWORD64 qwValue;
            LPWSTR sczValue;
        };
        BOOL fHidden;
        LPVOID pvContext;
    } VARIABLE_VALUE;

    HRESULT DAPI VarCreate(
        __out_bcount(VARIABLES_HANDLE_BYTES) VARIABLES_HANDLE* ppVariables
        );
    void DAPI VarDestroy(
        __in_bcount(VARIABLES_HANDLE_BYTES) VARIABLES_HANDLE pVariables,
        __in_opt PFN_FREEVARIABLECONTEXT vpfFreeVariableContext
        );
    void DAPI VarFreeValue(
        __in VARIABLE_VALUE* pValue
        );
    HRESULT DAPI VarEscapeString(
        __in_z LPCWSTR wzIn,
        __out_z LPWSTR* psczOut
        );
    HRESULT DAPI VarFormatString(
        __in C_VARIABLES_HANDLE pVariables,
        __in_z LPCWSTR wzIn,
        __out_z_opt LPWSTR* psczOut,
        __out_opt DWORD* pcchOut
        );
    HRESULT DAPI VarGetFormatted(
        __in C_VARIABLES_HANDLE pVariables,
        __in_z LPCWSTR wzVariable,
        __out_z LPWSTR* psczValue
        );
    HRESULT DAPI VarGetNumeric(
        __in C_VARIABLES_HANDLE pVariables,
        __in_z LPCWSTR wzVariable,
        __out LONGLONG* pllValue
        );
    HRESULT DAPI VarGetString(
        __in C_VARIABLES_HANDLE pVariables,
        __in_z LPCWSTR wzVariable,
        __out_z LPWSTR* psczValue
        );
    HRESULT DAPI VarGetVersion(
        __in C_VARIABLES_HANDLE pVariables,
        __in_z LPCWSTR wzVariable,
        __in DWORD64* pqwValue
        );
    HRESULT DAPI VarGetValue(
        __in C_VARIABLES_HANDLE pVariables,
        __in_z LPCWSTR wzVariable,
        __out VARIABLE_VALUE** ppValue
        );
    HRESULT DAPI VarSetNumeric(
        __in VARIABLES_HANDLE pVariables,
        __in_z LPCWSTR wzVariable,
        __in LONGLONG llValue
        );
    HRESULT DAPI VarSetString(
        __in VARIABLES_HANDLE pVariables,
        __in_z LPCWSTR wzVariable,
        __in_z_opt LPCWSTR wzValue
        );
    HRESULT DAPI VarSetVersion(
        __in VARIABLES_HANDLE pVariables,
        __in_z LPCWSTR wzVariable,
        __in DWORD64 qwValue
        );
    HRESULT DAPI VarSetValue(
        __in VARIABLES_HANDLE pVariables,
        __in_z LPCWSTR wzVariable,
        __in VARIABLE_VALUE* pValue
        );
    HRESULT DAPI VarStartEnum(
        __in VARIABLES_HANDLE pVariables,
        __out_bcount(VARIABLE_ENUM_HANDLE_BYTES) VARIABLE_ENUM_HANDLE* ppEnum,
        __out VARIABLE_VALUE** ppValue
        );
    HRESULT DAPI VarNextVariable(
        __in_bcount(VARIABLE_ENUM_HANDLE_BYTES) VARIABLE_ENUM_HANDLE pEnum,
        __out VARIABLE_VALUE** ppValue
        );
    void DAPI VarFinishEnum(
        __in_bcount(VARIABLE_ENUM_HANDLE_BYTES) VARIABLE_ENUM_HANDLE pEnum
        );

Implement the following condition API:

    HRESULT DAPI CondEvaluate(
        __in VARIABLES_HANDLE pVariables,
        __in_z LPCWSTR wzCondition,
        __out BOOL* pf
        );

## Considerations

The initial proposal called for a COM interface.
The feedback was that Burn's COM interfaces were very hard to change in 3.x,
and that a handle based approach is more consistent with the rest of dutil.

## See Also

[WIXFEAT:4552](http://wixtoolset.org/issues/4552/)
