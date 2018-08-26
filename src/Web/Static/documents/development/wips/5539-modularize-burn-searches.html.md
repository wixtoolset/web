---
wip: 5539
type: Feature
by: Sean Hall (r sean hall at gmail.com)
title: Modularize Burn Searches
draft: false
---

## User stories

* As a WiX Extension Developer I can insert my custom search into the Burn bundle such that WiX Users can declaratively specify custom searches in their Bundle wxs code.


## Proposal

1) Create a new concept in Burn for an extension.

    enum BURN_EXTENSION_MESSAGE
    {
        BURN_EXTENSION_MESSAGE_SEARCH,
    };

    enum BURN_EXTENSION_SEARCH_ARGS
    {
        DWORD cbSize;
        LPCWSTR wzVariable;
        LPCWSTR wzXml;
    };

    enum BURN_EXTENSION_SEARCH_RESULTS
    {
        DWORD cbSize;
    };

    extern "C" typedef HRESULT(WINAPI *PFN_BURN_EXTENSION_PROC)(
        __in BURN_EXTENSION_MESSAGE message,
        __in const LPVOID pvArgs,
        __inout LPVOID pvResults,
        __in_opt LPVOID pvContext
        );

    struct BURN_EXTENSION_CREATE_ARGS
    {
        DWORD cbSize;
        DWORD64 qwEngineAPIVersion;
        PFN_BURN_EXTENSION_ENGINE_PROC pfnBurnExtensionEngineProc;
        LPVOID pvBurnExtensionEngineProcContext;
    };

    struct BURN_EXTENSION_CREATE_RESULTS
    {
        DWORD cbSize;
        PFN_BURN_EXTENSION_PROC pfnBurnExtensionProc;
        LPVOID pvBurnExtensionProcContext;
    };

    extern "C" typedef HRESULT(WINAPI *PFN_BURN_EXTENSION_CREATE)(
        __in const BURN_EXTENSION_CREATE_ARGS* pArgs,
        __inout BURN_EXTENSION_CREATE_RESULTS* pResults
        );

    extern "C" typedef void (WINAPI *PFN_BURN_EXTENSION_DESTROY)();

    extern "C" typedef HRESULT(WINAPI *PFN_BURN_EXTENSION_ENGINE_PROC)(
        __in BURN_EXTENSION_ENGINE_MESSAGE message,
        __in const LPVOID pvArgs,
        __inout LPVOID pvResults,
        __in_opt LPVOID pvContext
        );

    enum BURN_EXTENSION_ENGINE_MESSAGE
    {
        BURN_EXTENSION_ENGINE_MESSAGE_GETVARIABLENUMERIC,
        BURN_EXTENSION_ENGINE_MESSAGE_GETVARIABLESTRING,
        BURN_EXTENSION_ENGINE_MESSAGE_GETVARIABLEVERSION,
        BURN_EXTENSION_ENGINE_MESSAGE_FORMATSTRING,
        BURN_EXTENSION_ENGINE_MESSAGE_ESCAPESTRING,
        BURN_EXTENSION_ENGINE_MESSAGE_EVALUATECONDITION,
        BURN_EXTENSION_ENGINE_MESSAGE_LOG,
        BURN_EXTENSION_ENGINE_MESSAGE_SETVARIABLENUMERIC,
        BURN_EXTENSION_ENGINE_MESSAGE_SETVARIABLELITERALSTRING,
        BURN_EXTENSION_ENGINE_MESSAGE_SETVARIABLESTRING,
        BURN_EXTENSION_ENGINE_MESSAGE_SETVARIABLEVERSION,
    };

2) Create a new `BurnExtension` element for the Burn manifest xml.

    <xs:element name="BurnExtension">
        <xs:complexType>
            <xs:attribute name="Id" type="xs:string" />
            <xs:attribute name="EntryPayloadId" type="xs:string" />
            <xs:choice minOccurs="0" maxOccurs="unbounded">
                <xs:element ref="PayloadRef" />
            </xs:choice>
        </xs:complexType>
    </xs:element>

3) Create a new `ExtensionSearch` element for the Burn manifest xml.

    <xs:element name="ExtensionSearch">
        <xs:annotation>
            <xs:documentation>
                The inner XML will contain the information needed for that specific search.
            </xs:documentation>
        </xs:annotation>
        <xs:complexType>
            <xs:attribute name="Id" type="xs:string" />
            <xs:attribute name="Variable" type="xs:string" />
            <xs:attribute name="Condition" type="xs:string" />
            <xs:attribute name="ExtensionId" type="xs:string" />
        </xs:complexType>
    </xs:element>

4) Move the `Util` extension's searches out of the Burn engine and into this new `ExtensionSearch` framework.

5) Move the `WixFileSearch`, `WixRegistrySearch`, `WixComponentSearch`, and `WixProductSearch` tables out of Wix's tables.xml and into the `UtilExtension`'s tables.xml.

6) In `CreateBurnManifestCommand`, it needs to somehow involve the extension in creating the xml.
Ideally the extension would somehow register a table as a Burn search table, and be able to provide its own subclass of `Row` for each of the rows.
This class would inherit from a new interface (`ISearchRow`?) which would have a method that returned an instance of `WixSearchInfo`.

However, this ability for an extension to provide its own subclass of `Row` does not exist yet (this was first brought up [here](https://github.com/wixtoolset/wix4/pull/85)). So the alternative would be to create a new Wix extension interface like `IBurnBinderExtension` and get `CreateBurnManifestCommand` to call each of those extensions and generate the xml that way.

## Example

This directory search will change from

    <DirectorySearch Id="myid" Variable="InstallFolder" Condition="PreviousInstallFolder" Path="[PreviousInstallFolder]" Type="path" />

to

    <UX>
        <Payload Id="UtilExtensionDll" />
    </UX>
    <BurnExtension Id="Util" EntryPayloadId="UtilExtensionDll">
        <PayloadRef Id="UtilExtensionDll" />
    </BurnExtension>
    <ExtensionSearch Id="myid" Variable="InstallFolder" Condition="PreviousInstallFolder" ExtensionId="Util">
        <DirectorySearch Path="[PreviousInstallFolder]" Type="path" />
    </ExtensionSearch>

## Considerations

Once this functionality is in place, I anticipate two feature requests:

1) Add the option to run the search in the elevated process in order to do IIS searches.

2) Add the ability to add custom package types and execute them in the Burn extension.

## See Also

[WIXFEAT:5539](https://github.com/wixtoolset/issues/issues/5539)