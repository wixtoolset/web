# How To: Reference another DirectorySearch element

There may be times when you need to locate different files or subdirectories under the same directory, and assign each to a separate property. Since you cannot define the same DirectorySearch element more than once, you must use a DirectorySearchRef element. To reference another DirectorySearch element, you must specify the same Id, Parent Id, and Path attribute values or you will get unresolved symbol errors when linking with light.exe.

## Step 1: Define a DirectorySearch element

You first need to define the parent DirectorySearch element. This is expected to contain the different files or subdirectories you will assign to separate properties.

```xml
<Property Id="SHDOCVW">
    <DirectorySearch Id="WinDir" Path="[WindowsFolder]">
        <DirectorySearch Id="Media" Path="Media">
            <FileSearch Id="Chimes" Name="chimes.wav" />
        </DirectorySearch>
    </DirectorySearch>
</Property>
```

This will search for the file "chimes.wav" under the Media directory in Windows. If the file is found, the full path will be assigned to the public property "SHDOCVW".

## Step 2: Define a DirectorySearchRef element

To search for another file in the Media directory, you need to reference all the same Id, Parent Id, and Path attributes. Because the Media DirectorySearch element is nested under the WinDir DirectorySearch element, its Parent attribute is automatically assigned the parent DirectorySearch elements Id attribute value; thus, that is what you must specify for the DirectorySearchRef element's Parent attribute value.

```xml
<Property Id="USER32">
    <DirectorySearchRef Id="Media" Parent="WinDir" Path="Media">
        <FileSearch Id="Chord" Name="chord.wav" />
    </DirectorySearchRef>
</Property>
```

If you wanted to refer to another DirectorySearch element that used the Id Media but was under a different parent path, you would have to define a new DirectorySearch element under a different parent than in step 1.
