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

1)
Create a new concept in Burn for an extension.

    enum BUNDLE_EXTENSION_MESSAGE
    {
        BUNDLE_EXTENSION_MESSAGE_SEARCH,
    };

    struct BUNDLE_EXTENSION_SEARCH_ARGS
    {
        DWORD cbSize;
        LPCWSTR wzId;
        LPCWSTR wzVariable;
    };

    struct BUNDLE_EXTENSION_SEARCH_RESULTS
    {
        DWORD cbSize;
    };

    extern "C" typedef HRESULT(WINAPI *PFN_BUNDLE_EXTENSION_PROC)(
        __in BUNDLE_EXTENSION_MESSAGE message,
        __in const LPVOID pvArgs,
        __inout LPVOID pvResults,
        __in_opt LPVOID pvContext
        );

    struct BUNDLE_EXTENSION_CREATE_ARGS
    {
        DWORD cbSize;
        DWORD64 qwEngineAPIVersion;
        PFN_BUNDLE_EXTENSION_ENGINE_PROC pfnBundleExtensionEngineProc;
        LPVOID pvBundleExtensionEngineProcContext;
        LPCWSTR wzBootstrapperWorkingFolder;
        LPCWSTR wzBundleExtensionDataPath;
    };

    struct BUNDLE_EXTENSION_CREATE_RESULTS
    {
        DWORD cbSize;
        PFN_BUNDLE_EXTENSION_PROC pfnBundleExtensionProc;
        LPVOID pvBundleExtensionProcContext;
    };

    extern "C" typedef HRESULT(WINAPI *PFN_BUNDLE_EXTENSION_CREATE)(
        __in const BUNDLE_EXTENSION_CREATE_ARGS* pArgs,
        __inout BUNDLE_EXTENSION_CREATE_RESULTS* pResults
        );

    extern "C" typedef void (WINAPI *PFN_BUNDLE_EXTENSION_DESTROY)();

    extern "C" typedef HRESULT(WINAPI *PFN_BUNDLE_EXTENSION_ENGINE_PROC)(
        __in BUNDLE_EXTENSION_ENGINE_MESSAGE message,
        __in const LPVOID pvArgs,
        __inout LPVOID pvResults,
        __in_opt LPVOID pvContext
        );

    enum BUNDLE_EXTENSION_ENGINE_MESSAGE
    {
        BUNDLE_EXTENSION_ENGINE_MESSAGE_ESCAPESTRING,
        BUNDLE_EXTENSION_ENGINE_MESSAGE_EVALUATECONDITION,
        BUNDLE_EXTENSION_ENGINE_MESSAGE_FORMATSTRING,
        BUNDLE_EXTENSION_ENGINE_MESSAGE_GETVARIABLENUMERIC,
        BUNDLE_EXTENSION_ENGINE_MESSAGE_GETVARIABLESTRING,
        BUNDLE_EXTENSION_ENGINE_MESSAGE_GETVARIABLEVERSION,
        BUNDLE_EXTENSION_ENGINE_MESSAGE_LOG,
        BUNDLE_EXTENSION_ENGINE_MESSAGE_SETVARIABLELITERALSTRING,
        BUNDLE_EXTENSION_ENGINE_MESSAGE_SETVARIABLENUMERIC,
        BUNDLE_EXTENSION_ENGINE_MESSAGE_SETVARIABLESTRING,
        BUNDLE_EXTENSION_ENGINE_MESSAGE_SETVARIABLEVERSION,
    };

2)
Create a new `BundleExtension` element for the Burn manifest xml.

    <xs:element name="BundleExtension">
        <xs:complexType>
            <xs:attribute name="Id" type="xs:string" />
            <xs:attribute name="EntryPayloadId" type="xs:string" />
            <xs:choice minOccurs="0" maxOccurs="unbounded">
                <xs:element ref="PayloadRef" />
            </xs:choice>
        </xs:complexType>
    </xs:element>

3)
Create a new `ExtensionSearch` element for the Burn manifest xml.

    <xs:element name="ExtensionSearch">
        <xs:complexType>
            <xs:attribute name="Id" type="xs:string" />
            <xs:attribute name="Variable" type="xs:string" />
            <xs:attribute name="Condition" type="xs:string" />
            <xs:attribute name="ExtensionId" type="xs:string" />
        </xs:complexType>
    </xs:element>

4) Create new BundleExtensionData.xml file for bundle extensions' custom data.

5) The Burn backend finds extension searches by looking for Symbols with the new `BundleExtensionSearchSymbolDefinitionTag`. These are added to the BundleExtensionData based on the corresponding `WixSearchSymbol`'s `ExtensionId` field.

6) Add `util:DetectWindowsFeature` and the core `SetVariable` "searches" as examples.

## Example

This directory search will change from

manifest.xml

    <DirectorySearch Id="myid" Variable="InstallFolder" Condition="PreviousInstallFolder" Path="[PreviousInstallFolder]" Type="path" />

to

manifest.xml

    <UX>
        <Payload Id="UtilExtensionDll" />
    </UX>
    <BundleExtension Id="Util" EntryPayloadId="UtilExtensionDll">
        <PayloadRef Id="UtilExtensionDll" />
    </BundleExtension>
    <ExtensionSearch Id="myid" Variable="InstallFolder" Condition="PreviousInstallFolder" ExtensionId="Util" />

BundleExtensionData.xml

    <BundleExtensionData>
        <BundleExtension Id="Util">
            <DirectorySearch Path="[PreviousInstallFolder]" Type="path" />
        </BundleExtension>
    </BundleExtensionData>

## Considerations

Moving Util's old searches out of the core toolset will still need to be done.

Once this functionality is in place, I anticipate two feature requests:

1) Add the option to run the search in the elevated process in order to do IIS searches.

2) Add the ability to add custom package types and execute them in the Bundle extension.

## See Also

[WIXFEAT:5539](https://github.com/wixtoolset/issues/issues/5539)