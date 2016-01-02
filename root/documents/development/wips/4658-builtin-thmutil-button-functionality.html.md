---
wip: 4658
type: Feature
by: Sean Hall (rseanhall at gmail.com)
title: Builtin thmutil Button Functionality
draft: false
---

## User stories

* As a Setup Developer I can use builtin button functionality such that I can write more flexible UIs for WixStdBA.


## Proposal

1) Create a new `CloseWindowAction` element.

    <xs:element name="CloseWindowAction">
        <xs:annotation>
            <xs:documentation>
                When the button is pressed, the WM_CLOSE message is sent to the window.
            </xs:documentation>
        </xs:annotation>
        <xs:complexType>
            <xs:attribute name="Condition" type="xs:string">
                <xs:annotation>
                    <xs:documentation>
                        The condition that determines if the parent control will execute this action.
                    </xs:documentation>
                </xs:annotation>
            </xs:attribute>
        </xs:complexType>
    </xs:element>

2) Create a new `ChangePageAction` element.

    <xs:element name="ChangePageAction">
        <xs:annotation>
            <xs:documentation>
                When the button is pressed, the specified page is shown.
            </xs:documentation>
        </xs:annotation>
        <xs:complexType>
            <xs:attribute name="Cancel" type="YesNoType">
                <xs:annotation>
                    <xs:documentation>
                        When set to 'yes', none of the variable changes made on the current page are saved.
                    </xs:documentation>
                </xs:annotation>
            </xs:attribute>
            <xs:attribute name="Condition" type="xs:string">
                <xs:annotation>
                    <xs:documentation>
                        The condition that determines if the parent control will execute this action.
                    </xs:documentation>
                </xs:annotation>
            </xs:attribute>
            <xs:attribute name="Page" type="xs:string" use="required">
                <xs:annotation>
                    <xs:documentation>
                        The Name of the Page to show.
                    </xs:documentation>
                </xs:annotation>
            </xs:attribute>
        </xs:complexType>
    </xs:element>

3) Create a new `BrowseDirectoryAction` element to designate that clicking the button calls `SHBrowseForFolder` and then saves the selection to a variable.

    <xs:element name="BrowseDirectoryAction">
        <xs:annotation>
            <xs:documentation>
                When the button is pressed, a directory browser dialog is shown.
            </xs:documentation>
        </xs:annotation>
        <xs:complexType>
            <xs:attribute name="Condition" type="xs:string">
                <xs:annotation>
                    <xs:documentation>
                        The condition that determines if the parent control will execute this action.
                    </xs:documentation>
                </xs:annotation>
            </xs:attribute>
            <xs:attribute name="VariableName" type="xs:string" use="required">
                <xs:annotation>
                    <xs:documentation>
                        The name of the variable to update when the user selects a directory from the dialog.
                    </xs:documentation>
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
        <ChangePageAction Page="Modify" Condition="WixBundleInstalled" Cancel="yes" />
        <ChangePageAction Page="Install" Cancel="yes" />
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
        <BrowseDirectoryAction VariableName="InstallFolder" />
    </Button>


## Considerations

The original proposal had a `PreviousPageAction`.
With the `Condition` attribute added to the actions, that functionality can be done with the `ChangePageAction`.
Also, implementing `PreviousPageAction` would be tricky.
Let's look at dialog sequences where every page has a `< Back` button and a `Next >` button, where the `< Back` button would always performs the `PreviousPageAction` and the `Next >` button always performs the `ChangePageAction`.

The first sequence starts with a Welcome page (`W`) that leads to an Install page (`I`).
`I` has an Options button that leads to the Options page (`O`).
Both buttons on `O` go to `I`.
So the desired sequence is: (`>` is for `Next`/`ChangePageAction` and `<` is for `Back`/`PreviousPageAction`)

    W > I > O < I < W

Consider the naive implementation where every time thmutil performs a `ChangePageAction`, it keeps track of the old page.
This would actually result in the sequence `W`>`I`>`O`<`I`<`O`, not what we wanted (here the `< Back` button on `I` could be changed to an unconditional `ChangePageAction`, but we could easily insert pages into the sequence that makes that impossible).

Now consider the implementation where thmutil keeps a stack of pages, where the `ChangePageAction` pushes pages onto the stack and `PreviousPageAction` pops them off.
This stack implementation provides our desired sequence.

The second sequence builds on the first sequence by making the `Next >` button going to a second Options page (`S`).
The `Next >` button on `S` leads to `I`.
So the desired sequence is:

    W > I > O > S > I < ???

It's not clear what the desired sequence should be.
On one hand, the last page the user saw was `S`.
On the other hand, the sequence `I`>`O`>`S`>`I` was a closed loop so maybe we want the user to go through `O` again to get to `S`.
Furthermore, pressing `< Back` on `I` leads to `W` in most scenarios; some users are confused when pressing the same button in different contexts performs different actions (with no visual difference between the contexts).

The actual sequence for both the naive and stack implementation would be `W`>`I`>`O`>`S`>`I`<`S`, but it's pretty much guaranteed that someone would file a bug saying that the sequence should be `W`>`I`>`O`>`S`>`I`<`W`.


## See Also

[WIXFEAT:4658](http://wixtoolset.org/issues/4658/)
