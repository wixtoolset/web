---
wip: 4274
type: Feature
by: Rob Mensching (rob at firegiant.com)
title: Simple Standard File Structure
---

## User stories

* As a WiX developer I can determine the format of a file such that I can go directly to loading the file without exceptions in the normal case.

* As a WiX extension developer I can develop my extension such that I am independent of native code (such as winterop.dll).


## Proposal

There is no standard for the WiX owned output file types such as .wixlib and .wixpdb. Some are just XML documents while others contain a cabinet with appended XML. Sometimes a file might be in either of those formats. This forces tools to try loading files in each format catching exceptions until the file loads successfully if at all.

This proposal suggests standardizing on a single simple file structure that can be read and written by the `WixToolset.Data.dll`. The `WixToolset.Data.dll` provides consistent programmatic access to the WiX file format with no dependencies beyond .NET.

The WiX output files are compound documents where most of the data is in a text format, namely JSON or XML. Those text formats compress well so the .zip file format is the obvious choice as a container for the WiX output file format.

As the WiX toolset proceeds through different stages of the build process, it adds and/or updates entries in the WiX output file. Some examples of entries included in a WiX output file are:

* `wix-ir.json` - stores the intermediate representation in JSON form
* `wix-wid.xml` - stores the Windows Installer data in XML form
* `wix-burndata.xml` - stores the Burn manifest data in XML format

The WiX output file can also contain additional binary files, such as in the case of "binary .wixlibs".


## Considerations

All output files types are binary files in this simple format. Diagnosing issues in the files requires opening the file as a .zip to find the desired internal stream. The output can be opened in a text editor and the XML data can be found intact at the end of this simple standard file format. This is less convenient when debugging the WiX toolset but is optimized for the common case (production and consumption by the tools).

Embedded files were compressed in a cabinet. This simple format does not compress files to keep things simple. In the future, we could consider using some compression (such as LZMA) on each embedded file's bytes if the compression algorithm can be embedded in the `WixToolset.Data.dll`.


## See Also

* [WIXFEAT:4274](http://wixtoolset.org/issues/4274/)
* [WIP:4273](4273-wix-layering-improvements.md)
