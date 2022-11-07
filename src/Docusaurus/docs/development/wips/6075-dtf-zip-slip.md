---
wip: 6075
type: Bug
by: Rob Mensching (rob at firegiant.com)
title: DTF vulnerable to "Zip Slip"
---

## User stories

* As a setup developer I can use DTF to extract user provided archives to
 isk without concern of overwriting files outside the target folder.


## Proposal

A security vulnerability was reported where a malicious archive (.cab or .zip)
file crafted to include traversal paths in the filenames of the archived
files processed by DTF could overwrite files unexpectedly. Consider the following
code using DTF:

    new CabInfo(@"path\to\bad.cab").Unpack(@"C:\unpack");

This could attempt to overwrite a Windows system file if `bad.cab` contained
an archived file with the name `..\Windows\System32\kernel32.dll`. This
attack vector is known as [Zip Slip][zipslip].

The fix is to ensure that files being decompressed to disk never write
to a folder outside of the specified target folder. An `InvalidDataException`
exception will be thrown when a malicious file is encountered.

## Considerations

* This is a breaking change to DTF methods that decompress files to
disk.

* There are methods in DTF to decompress archived files into memory.
These methods will not be impacted by the fix to minimize the
backwards compatibility impact.


## See Also

* [WIXBUG:6075 - DTF vulnerable to "Zip Slip"][6075]

[6075]: https://github.com/wixtoolset/issues/issues/6075
[zipslip]: https://cwe.mitre.org/data/definitions/29.html
