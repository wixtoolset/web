---
sidebar_position: 15
---

# Deployment Tools Foundation

:::tip
[Deployment Tools Foundation reference documentation is available here.](../reference/api/)
:::

Deployment Tools Foundation is a rich set of .NET class libraries and related resources that together bring the Windows deployment platform technologies into the .NET world. It is designed to greatly simplify deployment-related development tasks while still exposing the complete functionality of the underlying technology.

The primary focus of DTF is to provide a foundation for development of various kinds of tools to support deployment throughout the product lifecycle, including setup authoring, building, analysis, debugging, and testing tools. In addition to tools, DTF can also be useful for install-time activities such as setup bootstrappers, external UI, and custom actions, and for application run-time activities that need to access the deployment platform.

## Working with MSI Databases

### Querying a database

```cs
using (Database db = new Database("product.msi", DatabaseOpenMode.ReadOnly))
{
    string value = (string) db.ExecuteScalar(
        "SELECT `Value` FROM `Property` WHERE `Property` = '{0}'", propName);
}
```

1.  Create a new Database instance referring to the location of the .msi or .msm file.
2.  Execute the query:
  - The ExecuteScalar method is a shortcut for opening a view, executing the view, and fetching a single value. 
  - The ExecuteQuery method is a shortcut for opening a view, executing the view, and fetching all values. 
  - Or do it all manually with Database.OpenView, View.Execute, and View.Fetch. 


### Updating a binary

```cs
Database db = null;
View view = null;
Record rec = null;
try
{
    db = new Database("product.msi", DatabaseOpenMode.Direct);
    view = db.OpenView("UPDATE `Binary` SET `Data` = ? WHERE `Name` = '{0}'", binName))
    rec = new Record(1);
    rec.SetStream(1, binFile);
    view.Execute(rec);
    db.Commit();
}
finally
{
    if (rec != null) rec.Close();
    if (view != null) view.Close();
    if (db != null) db.Close();
}
```

1.  Create a new Database instance referring to the location of the .msi or .msm file.
2.  Open a view by calling one of the Database.OpenView overloads.
  - Parameters can be substituted in the SQL string using the String.Format syntax. 
3.  Create a record with one field containing the new binary value.
4.  Execute the view by calling one of the View.Execute overloads.
  - A record can be supplied for substitution of field tokens (?) in the query. 
5.  Commit the Database.
6.  Close the handles.

### About handles

Handle objects (Database, View, Record, SummaryInfo, Session) will remain open until they are explicitly closed or until the objects are collected by the GC. So for the tightest code, handle objects should be explicitly closed when they are no longer needed, since closing them can release significant resources, and too many unnecessary open handles can degrade performance. This is especially important within a loop construct: for example when iterating over all the Records in a table, it is much cleaner and faster to close each Record after it is used.

The handle classes in the managed library all extend the InstallerHandle class, which implements the IDisposable interface. This makes them easily managed with C#'s using statement. Alternatively, they can be closed in a finally block.

As a general rule, _methods_ in the library return new handle objects that should be managed and closed by the calling code, while _properties_ only return a reference to a prexisting handle object.


## Working with Cabinet Files

### Creating a cabinet

```cs
CabInfo cabInfo = new CabInfo("package.cab");
cabInfo.Pack("D:\\FilesToCompress");
```

1.  Create a new CabInfo instance referring to the (future) location of the .cab file.
2.  Compress files:
  - Easily compress an entire directory with the Pack method. 
  - Compress a specific list of exernal and internal filenames with the PackFiles method. 
  - Compress a dictionary mapping of internal to external filenames with the PackFileSet method. 

### Listing a cabinet

```cs
CabInfo cabInfo = new CabInfo("package.cab");
foreach (CabFileInfo fileInfo in cabInfo.GetFiles())
    Console.WriteLine(fileInfo.Name + "\t" + fileInfo.Length);
```

1.  Create a new CabInfo instance referring to the location of the .cab file.
2.  Enumerate files returned by the GetFiles method.
  - Each CabFileInfo instance contains metadata about one file. 

### Extracting a cabinet

```cs
CabInfo cabInfo = new CabInfo("package.cab");
cabInfo.Unpack("D:\\ExtractedFiles");
```

1.  Create a new CabInfo instance referring to the location of the .cab file.
2.  Extract files:
  - Easily extract all files to a directory with the Unpack method. 
  - Easily extract a single file with the UnpackFile method. 
  - Extract a specific list of filenames with the UnpackFiles method. 
  - Extract a dictionary mapping of internal to external filenames with the UnpackFileSet method. 

### Getting progress
Most cabinet operation methods have an overload that allows you to specify a event handler for receiving archive progress events. The XPack sample demonstrates use of the callback to report detailed progress to the console. 

### Stream-based compression
The CabEngine class contains static methods for performing compression/decompression operations directly on any kind of Stream. However these methods are more difficult to use, since the caller must implement a stream context that provides the file metadata which would otherwise have been provided by the filesystem. The CabInfo class uses the CabEngine class with FileStreams to provide the more traditional file-based interface. 

## Working with Install Packages

### Updating files in a product layout

The InstallPackage class makes it easy to work with files and cabinets in the context of a compressed or uncompressed product layout.

This hypothetical example takes an IDictionary `files` that maps file keys to file paths. Each file is to be updated in the package layout; cabinets are even recompressed if necessary to include the new files.

```cs
using (InstallPackage pkg = new InstallPackage(@"d:\builds\product.msi",
    DatabaseOpenMode.Transact))
{
    pkg.WorkingDirectory = Path.Combine(Path.GetTempFolder(), "pkgtmp");
    foreach (string fileKey in files.Keys)
    {
        string sourceFilePath = files[fileKey];
        string destFilePath = pkg.Files[fileKey].SourcePath;
        destFilePath = Path.Combine(pkg.WorkingDirectory, destFilePath);
        File.Copy(sourceFilePath, destFilePath, true);
    }
    pkg.UpdateFiles(new ArrayList(files.Keys));
    pkg.Commit();
    Directory.Delete(pkg.WorkingDirectory, true);
}
```

1.  Create a new InstallPackage instance referring to the location of the .msi. This is actually just a specialized subclass of a Database.
2.  Set the WorkingDirectory. This is the root directory where the package expects to find the new source files.
3.  Copy each file to its proper location in the working directory. The InstallPackage.Files property is used to look up the relative source path of each file.
4.  Call InstallPackage.UpdateFiles with the list of file keys. This will re-compress and package the files if necessary, and also update the following data: File.FileSize, File.Version, File.Language, MsiFileHash.HashPart*.
5.  Commit the database changes and cleanup the working directory.

