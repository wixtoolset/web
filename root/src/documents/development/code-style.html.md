---
under: Development
title: Code Style
subtitle: for the WiX toolset
keywords: wix toolset,wix,code style,style
layout: secondary
sidebarTitle: Additional information
sidebarItems:
  - uri: /about/governance/
    text: Governance Document
  - uri: /development/assignment-agreement/
    text: Assignment Agreement
---

## WiX Toolset Code Style

This document defines the WiX code style that is adapted from original source code developed at Microsoft. This is a living document and you will find older source in the repository that do not adhere to all of the guidelines in this document. When relevant to do so please fix the code to match this document.

1. Do not use tabs - only spaces.

2. The left indent should be four spaces.

3. Insignificant whitespace (whitespace to the right of text) should be reduced to one space in all cases except _maybe_ comments.

    ``` c
    // Good
    int a = 0;
    DWORD dw = 0; // this exists for some good reason

    // Bad
    int   a  = 0;
    DWORD dw = 0;   // this exists for some good reason
    ```

4. Control flow operators get one space after them while functions do not.

    ``` c
    // Good
    if (x)
    {
        func(x, y, z);
    }

    do
    {
        // do something to change fGo eventually
    } while (fGo);

    // Bad
    if( x )
    {
        func ( x, y, z );
    }
    ```

5. Braces are always left justified.

    ``` c
    // Good
    HRESULT FunctionName(int a)
    {
        int b = 0;
        int c = 0;

        if (0 == a)
        {
            b = 1;
            c = 2;
        }
    }

    // Bad
    HRESULT FunctionName(int a) {
        int a = 0;
        int b = 0;

        if (0 == a)
            {
            b = 1;
            c = 2;
            }
    }
    ```

6. Braces are always used, even when optional.

    ``` c
    // Good
    if (fBar)
    {
        a = 1;
    }

    // Bad
    if (fBar)
        a = 1;
    ```

7. Function definitions should look something like these examples.

    ``` c
    // Good
    void FunctionName();

    extern "C" HRESULT __stdcall FunctionName(
        __in LPCWSTR wzFoo,
        __out BOOL *pfBar
        );

    // Bad
    void FunctionName(
        );

    extern "C"
    HRESULT
    __stdcall
    FunctionName(
        __in LPCWSTR szFoo,
        __out BOOL *pfBar
        );
    ```

8. Use prefix addition and subtraction except where postfix addition or subtraction is absolutely required. Avoid postfix in general to avoid side effects.

    ``` c
    // Good
    for (int i = 0; i < 10; ++i)
    {
    }

    // Bad
    for (int i = 0; i < 10; i++)
    {
    }
    ```

9. Infinite loops should be rare but when necessary use an empty for loop and remember the braces.

    ``` c
    // Example infinite loop required for some reason
    for (;;)
    {
        // eventually break
    }
    ```

10. [SAL](http://msdn.microsoft.com/en-us/library/windows/desktop/aa383701.aspx) annotation is required on all function parameters.

11. Functions should have only one of the following return types: `void`, `BOOL`, or `HRESULT`. `void` and `BOOL` functions can never fail. If they could fail, change the return type to an `HRESULT`. You will find lots of wrapper functions in _dutil.lib_ that all return `HRESULT`s. The only exception to this rule is that "uninitialize"-type functions should return `void`. Work hard to remove any failure cases in the uninitialize route and, if unsuccessful, carefully consider what implications a failed uninitialize route has. Consider `::RevertToSelf()` as an example.

12. The C++ type `bool` is never used. Use `BOOL` instead.

13. Functions that are from a public SDK should be prefixed with the global namespace scope operator `::`.

14. Use the `countof()` macro (defined in _dutil.h_) to get the number of elements in an array. Consider this a sibling of the `sizeof()` language operator.

15. There should only be one exit from a function. An exception to this is error checking that can circumvent significant variable initialization by existing immediately at the top of the function.

16. Local variables should be initialized at the top of the function. If the local variable is not initialized to zero add a comment why.

17. The l-value in conditional tests should be the constant value whenever possible. To some people this makes the logic look "backward" but prevents accidental assignment in native code. After a while, other ways start looking wrong.

    ``` c
    // Example
    if (1 == i)
    {
        ++i;
    }
    ```

18. There are two "[secret handshakes](http://blogs.msdn.com/b/oldnewthing/archive/2005/01/06/347666.aspx)" in the WiX code style. First, the `ExitOnXxx()`, `ExitWithXxx()`, and `ExitFunction()` macros are used to simplify code flow. Never use an explicit `goto`. Second, the `ReleaseXxx()` and `ReleaseNullXxx()` macros are used extensively to clean up dynamically allocated memory when the function exits.

    ``` c
    // Example
    HRESULT FunctionName()
    {
        HRESULT hr = S_OK;
        IUnknown *pObject = NULL;
        LPVOID pv = NULL;
        WCHAR wzPAth[MAX_PATH] = { };

        pv = MemAlloc(50, TRUE);
        ExitOnNull(pv, hr, E_OUTOFMEMORY, "Failed to allocate pointer to nothing.");

        hr = ::CoCreateInstance(IID_IUnknown, &pObject);
        ExitOnFailure(hr, "Failed to get fake COM object.");

        if (!::GetTempPath(wzPath, countof(wzPath)))
        {
            ExitWithLastError(hr, "Failed to get TEMP path.");
        }

    LExit: // this is always present when control flow is used
        ReleaseObject(pObject);
        ReleaseMem(pv);

        return hr;
    }
    ```

19. The WiX support libraries make extensive use of dynamic strings. Use these string extensively instead of constant buffers or other mechanisms. You should use Hungarian notation for dynamic strings to change from "pwz" (pointer to a null-terminated string) to "scz" (for counted null-terminated string). This will make it easier to read "pointer to dynamically-allocated string" ("pscz" instead of "ppwz").

20. Use Hungarian notation for native code but don't go overboard with it. Sometimes just `pProperName` is just fine for an object that you are pointing at.

    ``` c
    BOOL f = FALSE;
    int i = 0;
    long l = 0;
    DWORD dw = 0;
    LPVOID pv = NULL;
    FUNCTION_PTR pfn = NULL;
    HRESULT hr = S_OK;
    ```

21. Use the COM `IUnknown` pattern for lifetime management of objects. `AddRef()` and `Release()` are not perfect but they are better than any other memory tracking operations we've found have in native code.

22. WiX code style for managed code follows [StyleCop](http://stylecop.codeplex.com/) definitions. Most of the above native code has actually morphed gently to match StyleCop suggested design (i.e. no tabs, four spaces).
