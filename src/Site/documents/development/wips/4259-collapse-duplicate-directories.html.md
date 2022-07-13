---
wip: 4259
type: Feature
by: Rob Mensching (rob at firegiant.com)
title: Collapse Duplicate Directories
---

## User stories

* As a setup developer I can define the same Directory element in multiple Fragments so directories can be written more like registry keys.


## Proposal

Folders (directories, by another name) are a bit unique in that they are generally installed and uninstalled as needed by the Windows Installer.
Registry keys (not values) share the same behavior. However, unlike registry keys, the Windows Installer requires each folder in a path to be defined
as a row in the Directory table. The WiX toolset followed the Windows Installer design and requires each folder to have a unique Directory element.

Unfortunately, this design decision means the ideal way to define folders is to define them centrally in a highly fragmented fashion. For example, a "Folders.wxs" file that looks like:

    <Fragment>
      <Directory Id="TARGETDIR" Name="SourceDir" />
    </Fragment>

    <Fragment>
      <DirectoryRef Id="TARGETDIR">
        <Directory Id="ProgramFilesFolder" Name="PFiles" />
      </Directory>
    </Fragment>

    <Fragment>
      <DirectoryRef Id="ProgamFilesFolder">
        <Directory Id="ManufacturerFolder" Name="My Company" />
      </Directory>
    </Fragment>

    <Fragment>
      <DirectoryRef Id="ProgamFilesFolder">
        <Directory Id="INSTALLFOLDER" Name="My Product" />
      </Directory>
    </Fragment>

And so on. The single file (or few set of files) invites merge collisions. The highly fragmented design makes it challenging to see the final path structure. These problems can be partially addressed by allowing duplicate Directory rows to be collapsed (combined) by the linker. That would allow
the following to exist:

    <!-- file1.wxs -->
    <Fragment>
      <DirectoryRef Id="INSTALLFOLDER">
        <Directory Id="BinFolder" Name="bin" />
      </DirectoryRef>

      <ComponentGroup Id="Stuff1" Directory="BinFolder">
        <!-- many Component elements here -->
      </ComponentGroup>
    </Fragment>

    <!-- file2.wxs -->
    <Fragment>
      <DirectoryRef Id="INSTALLFOLDER">
        <Directory Id="BinFolder" Name="bin" />
      </DirectoryRef>

      <ComponentGroup Id="Stuff2" Directory="BinFolder">
        <!-- many Component elements here -->
      </ComponentGroup>
    </Fragment>

In that example the "BinFolder" would be collapsed. This proposal becomes even more interesting when combined with [WIP:4260].


## Considerations

One problem with this proposal is that a single DirectoryRef element could now cause the linker to bring in multiple sections. Using the example above, a `<DirectoryRef Id="BinFolder" />` would bring in both listed Fragments. This is new behavior and has a very sersious issue. The content of the final output would now be partially dependent on the list of files provided to the linker. That goes against one of the core designs of the WiX toolset.

This problem can be mitigated with [access modifiers for identifiers][WIP:4258] and only allowing collapsing to happen between "private" duplicated Directory symbols. That would change the example above to look more like the following and prevent references from other sections:

    <!-- file1.wxs -->
    <Fragment>
      <DirectoryRef Id="INSTALLFOLDER">
        <Directory Id="fragment BinFolder" Name="bin" />
      </DirectoryRef>

      <ComponentGroup Id="Stuff1" Directory="BinFolder">
        <!-- many Component elements here -->
      </ComponentGroup>
    </Fragment>

    <!-- file2.wxs -->
    <Fragment>
      <DirectoryRef Id="INSTALLFOLDER">
        <Directory Id="fragment BinFolder" Name="bin" />
      </DirectoryRef>

      <ComponentGroup Id="Stuff2" Directory="BinFolder">
        <!-- many Component elements here -->
      </ComponentGroup>
    </Fragment>


## See also

* [WIXFEAT:4259](http://wixtoolset.org/issues/4259/)

* [WIP:4258](4258-identifier-access-modifiers/)

* [WIP:4260](4260-inline-directory-syntax/)
