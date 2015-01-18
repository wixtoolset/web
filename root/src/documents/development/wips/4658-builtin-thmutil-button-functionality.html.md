---
wip: 4658
type: Feature
author: Sean Hall (rseanhall at gmail.com)
title: Builtin thmutil Button Functionality
draft: false
---

## User stories

* As a Setup Developer I can use builtin button functionality such that I can write more flexible UIs for WixStdBA.


## Proposal

1) Create a new `CloseWindowAction` element.

    <xs:element name="CloseWindowAction">
        <xs:annotation>
            <xs:documentation>When the button is pressed, the WM_CLOSE message is sent to the window.</xs:documentation>
        </xs:annotation>
    </xs:element>

2) Create a new `ChangePageAction` element.

    <xs:element name="ChangePageAction">
        <xs:annotation>
            <xs:documentation>When the button is pressed, the specified page is shown.</xs:documentation>
        </xs:annotation>
        <xs:complexType>
            <xs:attribute name="Page" type="xs:string">
                <xs:annotation>
                    <xs:documentation>The Name of the Page to show.</xs:documentation>
                </xs:annotation>
            </xs:attribute>
        </xs:complexType>
    </xs:element>

3) Create a new `PreviousPageAction` element.

    <xs:element name="PreviousPageAction">
        <xs:annotation>
            <xs:documentation>When the button is pressed, the previous page is shown.</xs:documentation>
        </xs:annotation>
        <xs:complexType>
            <xs:attribute name="Cancel" type="YesNoType">
                <xs:annotation>
                    <xs:documentation>When set to 'yes', none of the variable changes made on the current page are saved.</xs:documentation>
                </xs:annotation>
            </xs:attribute>
        </xs:complexType>
    </xs:element>

4) Create a new `BrowseDirectoryAction` element to designate that clicking the button calls SHBrowseForFolder and then saves the selection to a specific editbox.

    <xs:element name="BrowseDirectoryAction">
        <xs:annotation>
            <xs:documentation>
                When the button is pressed, a directory browser dialog is shown.
            </xs:documentation>
        </xs:annotation>
        <xs:complexType>
            <xs:attribute name="Editbox" type="xs:string">
                <xs:annotation>
                    <xs:documentation>The Name of the Editbox to update when the user selects a directory from the dialog.</xs:documentation>
                </xs:annotation>
            </xs:attribute>
        </xs:complexType>
    </xs:element>


## Examples

1) The `WIXSTDBA_CONTROL_WELCOME_CANCEL_BUTTON` related code will be removed from WixStdBA.  In the theme file, it will change from

    <Button Name="WelcomeCancelButton" X="-11" Y="-11" Width="75" Height="23" TabStop="yes" FontId="0">
        #(loc.InstallCloseButton)
    </Button>

to

    <Button Name="WelcomeCancelButton" X="-11" Y="-11" Width="75" Height="23" TabStop="yes" FontId="0">
        <Text>#(loc.InstallCloseButton)</Text>
        <CloseWindowAction />
    </Button>

2) The `WIXSTDBA_CONTROL_OPTIONS_BUTTON` related code will be removed from WixStdBA.  In the theme file, it will change from

    <Button Name="OptionsButton" X="-171" Y="-11" Width="75" Height="23" TabStop="yes" FontId="0" HideWhenDisabled="yes">
        #(loc.InstallOptionsButton)
    </Button>

to

    <Button Name="OptionsButton" X="-171" Y="-11" Width="75" Height="23" TabStop="yes" FontId="0" HideWhenDisabled="yes">
        <Text>#(loc.InstallOptionsButton)</Text>
        <ChangePageAction Page="Options" />
    </Button>

3) The `WIXSTDBA_CONTROL_CANCEL_BUTTON` related code will be removed from WixStdBA.  In the theme file, it will change from

    <Button Name="OptionsCancelButton" X="-11" Y="-11" Width="75" Height="23" TabStop="yes" FontId="0">
        #(loc.OptionsCancelButton)
    </Button>

to

    <Button Name="OptionsCancelButton" X="-11" Y="-11" Width="75" Height="23" TabStop="yes" FontId="0">
        <Text>#(loc.OptionsCancelButton)</Text>
        <PreviousPageAction Cancel="yes" />
    </Button>

4) `The WIXSTDBA_CONTROL_FOLDER_EDITBOX` and `WIXSTDBA_CONTROL_BROWSE_BUTTON` related code will be removed from WixStdBA.  In the theme file, it will change from

    <Editbox Name="FolderEditbox" X="11" Y="143" Width="-91" Height="21" TabStop="yes" FontId="3" FileSystemAutoComplete="yes" />
    <Button Name="BrowseButton" X="-11" Y="142" Width="75" Height="23" TabStop="yes" FontId="3">
        #(loc.OptionsBrowseButton)
    </Button>

to

    <Editbox Name="InstallFolder" X="11" Y="143" Width="-91" Height="21" TabStop="yes" FontId="3" FileSystemAutoComplete="yes" />
    <Button Name="BrowseButton" X="-11" Y="142" Width="75" Height="23" TabStop="yes" FontId="3">
        <Text>#(loc.OptionsBrowseButton)</Text>
        <BrowseDirectoryAction Editbox="InstallFolder" />
    </Button>


## See Also

[WIXFEAT:4658](http://wixtoolset.org/issues/4658/)
