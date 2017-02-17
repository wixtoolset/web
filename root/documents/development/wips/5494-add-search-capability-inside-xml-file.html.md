---
wip: # 5494
type: Feature
by: Fyodor Koryazhkin (fyodorkor at gmail.com)
title: XML file search
---

## User stories

As a setup developer I can look for and read elements and attributes from XML file such that I can use them later in installation.


## Proposal

Add custom action that reads elements from XML file and stores result in specified property.
The development of this story will consist from two parts:
1.Modifying WIX/Util schema to add subelement to Property
	<Property Name=SOME_PROPERTY...>
		<XMLSearch Id=Id1 File=<formatted path to file> Element=<XPath> Attribute=<name of attribute> />
	</Property>
	Compilation of this part will create the table with 5 columns (Id, File, Element, Attribute, Property) where first four are primary key that allowing to read several attributes from one element.
2. Adding Custom Action to Util extension that reads from XML file and puts value to specified property.
	a. Action is immediate and placed just after AppSearch standard action in both sequencies
	b. If the file, element or attribute do not exist - write to log.
	c. If Attribute is omitted or is empty string - read inner text of element.

## Considerations
In modern days XML files play significant role in development. Unfortunately there is no XML search procedures built in MSI (Like RegSearch or DrSearch). 
Adding such a functionality to WIX will help setup developers to get more helpfull information at the beginning of installation.
1. It will be possible to add additional condition to installation based on some values from XML conifguration files.
2. It will be possible to easyly tranfer data from one XML to other (as an example - some data the must be persistent through different versions but still is not available at design\build time) 


## See Also
