---
wip: 4724
type: Feature
author: Rob Mensching (rob at firegiant.com)
title: Simple Standard File Structure
---

## User stories

* As a WiX developer I can determine the format of a file such that I can go directly loading the file without exceptions in the normal case.

* As a WiX extension developer I can develop my extension such that I am independent of native code (such as winterop.dll).

## Proposal

There is no standard for the WiX owned output file types such as .wixobj, .wixlib and .wixpdb. Some are just XML documents while others contain a cabinet with appeneded XML. Sometimes a file might be in either of those formats. This forces tools like light.exe to attempt to attempt to load files in each format catching exceptions until the file is loaded.

This proposal suggests standardizing on a single simple file structure that can be implemented in the `WixToolset.Data.dll` without any dependencies. The structure layout would be as follows:

*identifier* [6 bytes] - file format identifier: 'wixlib', 'wixobj', 'wixpdb', etc.

*file_count* [4 bytes] - count of embedded file sizes.

*array_file_sizes* [8 bytes] x *file_count* - size of each embedded file.

file_bytes *file_size[0 - count - 1] - bytes for each file.

*data stream* - remainder of the file is the data.

The 6 byte identifer makes it easy to determine the file format. Likewise the embedded files are easily accessed after reading the file count and all of the file size then seeking to position: 6 + 4 + sum(file_sizes < index of embedded file).

For example, a .wixobj that has no embedded files would have records like:

    'wixobj', '0', data from wixobj

For example, a .wixlib that had three 2 byte files with data 'f1', 'f2', and 'f3' (respectively)  would have records like:

    'wixlib', '3', '2', '2', '2', 'f1', 'f2', 'f3', data from wixlib

## Considerations

Embedded files were compressed in a cabinet. This simple format does not compress files to keep things simple. in the future, we could consider
using some compression (such as LZMA) on each embedded file's bytes if
the compression algorithm can be embedded in the `WixToolset.Data.dll`.

## See Also

* [WIXFEAT:4274](http://wixtoolset.org/issues/4274/)
* [WIP:4273](4273-wix-layering-improvements/)
