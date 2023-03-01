---
sidebar_position: 50
---

# Code pages

When it was first developed and introduced, Windows Installer was available for Windows 95 and Windows 98. While the 90s were a great decade, those 16-bit versions of Windows came with some significant limitations. One of them is lack of support for Unicode. Windows Installer inherited that limitation and uses _code pages_ to support characters outside of the traditional 7-bit ASCII we know and love.

That said, Windows Installer has limited support for code page 65001 as UTF-8. WiX uses code page 65001 by default but you can override the default using the `Codepage` attribute in the [Package](./schema/wxs/package.md), [SummaryInformation](./schema/wxs/summaryinformation.md), [Module](./schema/wxs/module.md), [Patch](./schema/wxs/patch.md), and [PatchCreation](./schema/wxs/patchcreation.md) elements. `Codepage` attribute values can be integers like 1252 for Windows ANSI or by Web name like `Windows-1252`.

You can specify coded page 0 as a "neutral" code page. The only characters supported are the aforementioned known and loved 7-bit ASCII characters (0 to 127). For more information, see [Creating a Database with a Neutral Code Page](https://learn.microsoft.com/en-us/windows/win32/msi/creating-a-database-with-a-neutral-code-page).

## Centralizing code pages via localization files

WiX localization (.wxl) files contain localized strings and can also specify code pages for both packages and their summary information stream using the `Codepage` and `SummaryInformationCodepage` attributes, respectively:

```xml
<WixLocalization xmlns="http://wixtoolset.org/schemas/v4/wxl"
  Culture="en-US"
  Codepage="UTF-8"
  SummaryInformationCodepage="0">
...
```
