---
wip: 4258
type: Feature
author: Rob Mensching (rob at firegiant.com)
title: Identifier Access Modifiers
---

## User stories

* As a setup developer I can define the scope of an identifier to a Fragment or the .wxs file such that it does not collide with other identifiers defined in my project.

* As a setup developer I can control the identifiers that are "publicly" available from my .wixlib such that other developers cannot link directly to implementation details.


## Proposal

Provide access modifiers to scope files to the section, file, library and output. Today only output is supported so that should remain the default. If we were to use C# identifiers we could maybe use:

* `private` to define section level scope. This would be the default for generated identifiers.
* `protected` to define file level scope.
* `internal` to define library level scope.
* `public` to define output level scope. This would be the default when an Id attribute is provided.

The access modifier would come first and be separated by one or more whitespaces from the identifier. For example:

    <Component Id="protected LocalUniqueName1">

Example 1

Imagine two files that both decide to name their Components "comp" + counting number.

    <!-- file1.wxs -->
    <Fragment>
      <ComponentGroup Id="Group1">
        <ComponentRef Id="comp1" />
        <ComponentRef Id="comp2" />
      </ComponentGroup>
    </Fragment>

    <Fragment>
      <Component Id="protected comp1">
       <File Source="1234.txt" />
      </Component>
    </Fragment>

    <Fragment>
      <Component Id="protected comp2">
       <File Source="abcd.txt" />
      </Component>
    </Fragment>

    <!-- file2.wxs -->
    <Fragment>
      <ComponentGroup Id="Group2">
        <ComponentRef Id="comp1" />
        <ComponentRef Id="comp2" />
      </ComponentGroup>
    </Fragment>

    <Fragment>
      <Component Id="protected comp1">
       <File Source="6789.txt" />
      </Component>
    </Fragment>

    <Fragment>
      <Component Id="protected comp2">
       <File Source="wxyz.txt" />
      </Component>
    </Fragment>

Example 2

Image the above files were combined into a .wixlib. The only references that can be made into the .wixlib would be:

    <ComponentGroupRef Id="Group1" />
    <ComponentGroupRef Id="Group2" />

The Component/@Ids are protected and thus not accessible. The File/@Ids are generated thus private and also not accessible. The ComponentGroup/@Ids are accessible because "public" is the default for specified identifiers.


## Considerations

There is still the chance for collisions, even when the identifier is generated. Typically, this points to duplicate data and a bad situation. But it will be confusing that things with private identifiers collided. One option is to include more information from the private data into the hash of the identifier. The name of the .wxs file could be included but that won't prevent level "private". To do that, the Fragment location or something would have to be included, which would increase the chances of the identifier changing (thus breaking patching and, IIRC, minor upgrades).


## See Also

* [WIXFEAT:4258](http://wixtoolset.org/issues/4258/)
