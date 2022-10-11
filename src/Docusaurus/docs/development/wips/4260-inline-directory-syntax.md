---
wip: 4260
type: Feature
by: Rob Mensching (rob at firegiant.com)
title: Inline Directory Syntax
---

## User stories:

* <s>As a setup developer I can define a directory path without breaking the path into individual Directory elements such that my code is easier to read.</s>
* As a setup developer I can define my directory path where it is convenient without needing to create Directory elements elsewhere.


## Proposal

Allow developers to create directory paths that are rooted in a well-known or user-defined Directory element. Private anonymous Directory rows are created behind the scenes and the last directory in the path is used. Additionally, anywhere a Directory reference can be placed, this alternative directory syntax can be used instead.


## Considerations

A more terse syntax was explored that used a colon (`:`) to separate the "root directory reference" from the directory definitions. The syntax mimicked the Windows path syntax. The volume portion of the path (everything before the ":") is a reference to an existing Directory element Id. The remainder of the path creates anonymous directory rows.

For example, consider the case where a Component is to install to a path such as "[ProgramFilesFolder]My Company\My Product\bin". Today that requires code such as:

    <Fragment>
      <Directory Id="ProgramFilesFolder" Name="PFiles">
        <Directory Name="My Company">
          <Directory Name="My Product">
            <Directory Id="private BinFolder" Name="bin">
          </Directory>
        </Directory>
      </Directory>
    </Fragment>

    <Component Directory="BinFolder">

With the terse syntax the above code could be converted into:

    <Component Directory="ProgramFilesFolder:\My Company\My Product\bin\">

If "BinFolder" was to be used in many places it could be defined like this:

    <Directory Id="BinFolder" Name="ProgramFilesFolder:\My Company\My Product\bin\">

The issue with this syntax is that it created confusion when a single value was used in the directory reference when there was also a parent directory that could be inherited. Consider this case:

    <ComponentGroup Directory="ProgramFilesFolder:\My Company\My Product\">
      <Component Directory="bin">

In that case, is `bin` a reference to a Directory with `Id="bin"` or a continuation of the terse syntax `"ProgramFilesFolder:\My Company\My Product\bin\"`? This possibility of confusion lead to the introduction of the `Subdirectory` attribute instead.


## See Also

* [WIXFEAT:4260](http://wixtoolset.org/issues/4260/)
