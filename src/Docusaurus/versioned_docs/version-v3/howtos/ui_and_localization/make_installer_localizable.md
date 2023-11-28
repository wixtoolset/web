# How To: Make your installer localizable

WiX supports building localized installers through the use of language files that include localized strings. It is a good practice to put all your strings in a language file as you create your setup, even if you do not currently plan on shipping localized versions of your installer. This how to describes how to create a language file and use its strings in your WiX project.

## Step 1: Create the language file

Language files end in the .wxl extension and specify their culture using the [WixLocalization](../../xsd/wixloc/wixlocalization.md) element. To create a language file on the command line create a new file with the appropriate name and add the following:

```xml
<?xml version="1.0" encoding="utf-8"?>
<WixLocalization Culture="en-us" xmlns="http://schemas.microsoft.com/wix/2006/localization">
</WixLocalization>
```

If you are using Visual Studio you can add a new language file to your project by doing the following:

1. Right click on your project in Solution Explorer and select Add > New Item...
1. Select WiX Localization File, give the file an appropriate name, and select Add

By default Visual Studio creates language files in the en-us culture. To create a language file for a different culture change the Culture attribute to the appropriate culture string.

## Step 2: Add the localized strings

Localized strings are defined using the [String](../../xsd/wixloc/string.md) element. Each element consists of a unique id for later reference in your WiX project and the string value. For example:

```xml
<String Id="ApplicationName">My Application Name</String>
<String Id="ManufacturerName">My Manufacturer Name</String>
```

The String element goes inside the WixLocalization element, and you should add one String element for each piece of text you need to localize.

## Step 3: Use the localized strings in your project
Once you have defined the strings you can use them in your project wherever you would normally use text. For example, to set your product's Name and Manufacturer to the localized strings do the following:

```xml
<Product Id="*"
         UpgradeCode="PUT-GUID-HERE"
         Version="1.0.0.0"
         Language="1033"
         Name="!(loc.ApplicationName)"
         Manufacturer="!(loc.ManufacturerName)">
```

Localization strings are referenced using the **!(loc.stringname)** syntax. These references will be replaced with the actual strings for the appropriate locale at build time.

For information on how to compile localized versions of your installer once you have the necessary language files see [How To: Build a localized version of your installer](build_a_localized_version.md).
