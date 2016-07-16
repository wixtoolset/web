---
wip: #5352
type: Feature
by: Phillip Hogland (phogland at rimage.com)
title: Template WiX Improvement Proposal
draft: true
---

## User stories

* As a setup developer I can install the WiX Toolset, using a setup UI which is more familiar to Windows 10 (AppX) users.

* As a setup developer I can install the WiX Toolset on a system configured to use a High Contrast display theme or accessibility tools like Windows Narrator.

## Current State
* The WiX Toolset setup's UI is authored using a 'Metro style' fixed dimension, grid-based control layout.
* The use of absolute dimensions makes changing the displayed information difficult.
* The control elements do not include Automation Properties or color definitions suitable for use with accessibility tools. 

## Proposal
The proposal is to update the 'look and feel' of the UI to be more familiar to Windows 10 users.

## Proposal-3.x
There are no plans to apply this proposal to the WiX Toolset v3.x Setup, at this time.

## Proposal-4.x
* Change the main View in WixBA, to use the 'ThreeDBorderWindow' style and a Window/@ResizeMode='CanMinimize' resulting in standard controls in the window's chrome to minimize or 'close' the setup application.  The maximize control will be visible as disabled. An icon is displayed in the upper left corner by default.  See Considerations.
* Place layout relative to the top and left edges, using minimum dimensions, allowing the size to expand to the right, or down, based on content.  Localization is not in the scope of this proposal, but will be easier to implement if the layout is allowed to float in this manner.
* Create a 'Branding' layout area along the upper right side for placement of the identity of the publisher along with a logo.
* Create a 'SKU' layout area along the upper left side to present details about this particular product or build.
* Create an 'Action' area along the bottom, control placement is justified to the right, to present 'action' controls, such as 'Install', 'Update' or 'Repair'.  The controls are arranged so that the most likely (or most suggested) control is to the right, of lower probability selections.  Controls which are not relevant for a specific configuration are hidden.
* Create a 'Status' area above the 'Action' controls, consisting of the remaining space in the middle of the Window, to provide progress and status informational message, and links to logs when relevant.
*     

## Considerations
### General
I do not have much familiarity with AppX setups.  The original wix-devs thread suggested looking at screen shots at:

 <https://www.microsoft.com/en-us/store/apps/app-installer/9nblggh4nns1>

 The following topics cover issues that need more clarification in my mind. 

### The Window's Chrome
The example AppX screen shot only has a 'windows close' control (x) in the upper left corner, however it has been suggested that allowing the user to minimize the setup application is useful to support.  My research indicates that when Window/@Style is set to 'ThreeDBorderWindow' there is no option to not show the icon in the upper left corner.  The documentation indicates that this icon is also used in the ALT-TAB list of applications.  The example AppX screen shot does not indicate that an icon was used.  Therefore we need to define an .ico file for use in this Window, or allow the OS to pick a default icon from the bundle.exe, or from Window's default application icon.  If it is desirable to emulate the AppX screen shot I suspect we could define an .ico file using the same color as the background.  I have not researched this to know what is needed to hide the icon, but I suspect specifying a .ico file which matches the background might work.  

### Branding
For a logo, logo-black-hollow.png and logo-white-hollow.png, from the web site, were used, but the resulting image seems a little small. So the following ScaleTransform is applied:

    <ScaleTransform ScaleX="1.2" ScaleY="1.2"/>

Whether the ScaleTransform is applied or not some edges of the logo are aliased (ragged).  I am wondering if there is a better way to present the logo?

Would re-sizing it in another tool be advisable?

Which Font Family is preferred for Branding?  The AppX screen shot seems to use a different font so I tried Cambria for the org title.      

### SKU
The AppX screen shot has at the top left a question, such as:

"Install Contoso App?"

I am not clear what would be displayed in other configurations, such as when Update, Repair, and Uninstall are all valid possible actions.  So I am looking for clarification as to whether this line should be implemented and when.

The AppX screen shot has a 'Publisher:' and a 'Version:' (both of which have been implemented in the mock up), followed by a 'Capabilities:' with three bullets and a link labeled 'More'.  I am not clear on what we to present for 'Capabilities:'.  'News' is the closest similarity in the current WixBA.  'License:' and 'News:' links has been implemented, and the value of the Publisher: is also a link to the home page at:

<http://www.WiXToolset.org>

While the goal is to make these view similar to the AppX screen shot, I wonder if Publisher: isn't redundant and the homepage link and the News: link more suited for display below the publisher's name in the Branding area.  I would think that a link to the Release/download page and a 'support' (link pointing at the wix forums page (or specifically to  wix-users) might be more useful in the SKU area.  Or all links in the SKU area to keep the Branding area clean.  I had also considered creating two invisible layout columns, spacing to two links horizontally using more of the center of the dialog, but still in the SKU area.  Any thoughts on these issues?

### Action Controls
The AppX screen shot only shows one Action Control being displayed, however there are configurations where more than one selection is appropriate.  I assume therefore that the controls should be arranged from right to left, with the rightmost being the preferred selection.  The AppX screen shot shows a blue foreground, which in the Aero color scheme appears to be the HotTrackBrush.  Currently all Action Control buttons are styled with this brush.  I assume that there should be some logic to select only one action with the HotTrackBrush, but I seek guidance on the expectation, and if such logic is needed how the selection should be determined.  I'm probably making this more complex than necessary.

The following is a list (from top to bottom) of the Action controls which would be placed from Right to Left:

* **Update** - The existing WixBA has a single button with several labels, Checking, 'Update Available', 'Up To Date', and no connection (button is hidden).  This mock up button corresponds to "Update Available". The lack of an 'Update' button (hidden) corresponds to 'Up to Date' or 'no connection'.  'Checking' is addressed with an indeterminate progress indicator with text indicating "Checking for updates", in the 'Status' area.
* **Try Again?** - Most Buttons are labeled with a verb, is this the right button label? I'm OK with it.
* **Install** - The mock up does not have any message indicating that the user is accepting the license by installing.  Should it?  Possibly to the far left of the Action Controls or immediately above them to the left.
* **Repair**
* **Uninstall**
* **Exit** - The AppX uses "Close", and the Close button is not displayed in the Install configuration scenario of the screen shot.  Is this button needed, given that there is a Close control in windows chrome?  Currently in the mock up only the chrome control is displayed. 
* **Cancel**

### Status Information
I don't know what the AppX similarity is so the mock up uses horizontal progress bars and an area for the action text similar in function to the current WixBA.  Currently text indicating the action, 'Checking for updates' is also placed in this area with an indeterminate progress bar (barbershop style).  I researched putting short status text to the immediate left of the Action Controls, in a status bar model, but did not try an implementation yet.

## See Also
Screen shots of the mock up running on Windows 10 Aero, have been placed at:

<https://github.com/phillHgl/wix4.MyResources/tree/develop/ScreenShots/5352-new-wixba-ui-v4/Aero>

Somce screen shots for a dark high contrast configuration have been placed at (with more work needed):

<https://github.com/phillHgl/wix4.MyResources/tree/develop/ScreenShots/5352-new-wixba-ui-v4/Dark>
