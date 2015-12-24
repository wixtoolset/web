---
wip: 4274
type: Feature
author: Rob Mensching (rob at firegiant.com)
title: Simple Standard File Structure
---

## User stories

* As a WiX developer I can determine the format of a file such that I can go directly to loading the file without exceptions in the normal case.

* As a WiX extension developer I can develop my extension such that I am independent of native code (such as winterop.dll).

## Proposal

There is no standard for the WiX owned output file types such as .wixobj, .wixlib and .wixpdb. Some are just XML documents while others contain a cabinet with appended XML. Sometimes a file might be in either of those formats. This forces tools like light.exe to attempt to attempt to load files in each format catching exceptions until the file is loaded.

This proposal suggests standardizing on a single simple file structure that can be read and written by the `WixToolset.Data.dll`. The `WixToolset.Data.dll` provides consistent programmatic access to the WiX file format with no dependencies beyond the .NET Framework.

The structure layout would be as follows:

*identifier* [6 bytes] - file format identifier: 'wixlib', 'wixobj', 'wixpdb', etc.

*file_count* [4 bytes] - count of embedded file sizes.

*array_file_sizes* [8 bytes] x *file_count* - size of each embedded file.

file_bytes *file_size[0 to count - 1]* - bytes for each file.

*data stream* - remainder of the file is the data (typically an XML document).

The 6 byte identifier makes it easy to determine the type of the file format. Likewise the embedded files are easily accessed after reading the file count and all of the file size then seeking to a position at: 6 + 4 + sum(file_sizes < index of embedded file).

For example, a .wixobj that has no embedded files would have records like:

    'wixobj', '0', data from wixobj

For example, a .wixlib that had three 2 byte files with data 'f1', 'f2', and 'f3' (respectively)  would have records like:

    'wixlib', '3', '2', '2', '2', 'f1', 'f2', 'f3', data from wixlib

## Considerations

All output files types are binary files in this simple format. Diagnosing issues in the files requires similar debugging steps used when diagnosing binary .wixlibs in WiX v3.x. The output can be opened in a text editor and the XML data can be found intact at the end of this simple standard file format. This is less convenient when debugging the WiX toolset but is optimized for the common case (production and consumption by the tools).

Embedded files were compressed in a cabinet. This simple format does not compress files to keep things simple. In the future, we could consider using some compression (such as LZMA) on each embedded file's bytes if the compression algorithm can be embedded in the `WixToolset.Data.dll`.

## See Also

* [WIXFEAT:4274](http://wixtoolset.org/issues/4274/)
* [WIP:4273](4273-wix-layering-improvements/)
