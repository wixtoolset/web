# How To: Get the parent directory of a file search

You can set a property to the parent directory of a file.

## Step 1: Define the search root

In the following example, the path to \[WindowsFolder\]Microsoft.NET is defined as the root of the search. If you do not define a search root, Windows Installer will search all fixed drives up to the depth specified.

```xml
<Property Id="NGEN2DIR">
    <DirectorySearch Id="Windows" Path="[WindowsFolder]">
        <DirectorySearch Id="MS.NET" Path="Microsoft.NET">
        </DirectorySearch>
    </DirectorySearch>
</Property>
```

## Step 2: Define the parent directory to find

Under the search root, define the directory you want returned and set the DirectorySearch/@AssignToProperty attribute to 'yes'. You must then define the file you want to find using a unique FileSearch/@Id attribute value.

```xml
<Property Id="NGEN2DIR">
    <DirectorySearch Id="Windows" Path="[WindowsFolder]">
        <DirectorySearch Id="MS.NET" Path="Microsoft.NET"> 
            <DirectorySearch Id="Ngen2Dir" Depth="2" AssignToProperty="yes"> 
                <FileSearch Id="Ngen_exe" Name="ngen.exe" MinVersion="2.0.0.0" /> 
            </DirectorySearch>
        </DirectorySearch>
    </DirectorySearch>
</Property>
```

In this example, if ngen.exe is newer than version 2.0.0.0 and is found no more than two directories under \[WindowsFolder\]Microsoft.NET its parent directory is returned in the NGEN2DIR property.
