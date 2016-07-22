---
wip: #5352
type: Feature
by: Phillip Hogland (phogland at rimage.com)
title: New WixBA UI, v4
draft: false
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

Note in WixToolset Online Meeting #109 AppX setup was demonstrated.

### The Window's Chrome
The example AppX screen shot only has a 'windows close' control (x) in the upper left corner, however it has been suggested that allowing the user to minimize the setup application is useful to support.  My research indicates that when Window/@Style is set to 'ThreeDBorderWindow' there is no option to not show the icon in the upper left corner.  The documentation indicates that this icon is also used in the ALT-TAB list of applications.  The example AppX screen shot does not indicate that an icon was used.  Therefore we need to define an .ico file for use in this Window, or allow the OS to pick a default icon from the bundle.exe, or from Window's default application icon.  If it is desirable to emulate the AppX screen shot I suspect we could define an .ico file using the same color as the background.  I have not researched this to know what is needed to hide the icon, but I suspect specifying a .ico file which matches the background might work.  

In WixToolset Online Meeting #109 the direction was to research the default WPF behavior on Windows 10, suppress the icon in the left corner of the chrome if possible, and allow user re-size the window.  The current implementation re-sizes to the content of the layout, but does not allow re-sizing.  I plan to address other concerns and submit Pull requests that do not support re-sizing initially, then work on the re-sizing and needed scroll/wrapping behavior later.

### Branding
For a logo, logo-black-hollow.png and logo-white-hollow.png, from the web site, were used, but the resulting image seems a little small. 

Note in WixToolset Online Meeting #109 I will research a preferred size for the logo and provide that back to wix-devs.

Which Font Family is preferred for Branding?  The AppX screen shot seems to use a different font so I tried Cambria for the org title.    

Note in WixToolset Online Meeting #109 we did not cover which FontFamily to use.  Still interested in feedback.  

### SKU
The AppX screen shot has at the top left a question, such as:

"Install Contoso App?"

The AppX screen shot has a 'Publisher:' and a 'Version:' (both of which have been implemented in the mock up), followed by a 'Capabilities:' with three bullets and a link labeled 'More'.  I am not clear on what we to present for 'Capabilities:'.  'News' is the closest similarity in the current WixBA.  'License:' and 'News:' links has been implemented, and the value of the Publisher: is also a link to the home page at:

<http://www.WiXToolset.org>

While the goal is to make these view similar to the AppX screen shot, I wonder if Publisher: isn't redundant and the homepage link and the News: link more suited for display below the publisher's name in the Branding area.  I would think that a link to the Release/download page and a 'support' (link pointing at the wix forums page (or specifically to  wix-users) might be more useful in the SKU area.  Or all links in the SKU area to keep the Branding area clean.  I had also considered creating two invisible layout columns, spacing to two links horizontally using more of the center of the dialog, but still in the SKU area.  Any thoughts on these issues?

The online meeting #109 consensus was to have a static title and not try present a 'question' in the title.  I also received guidance for the layout of Publisher etc, using labels where I only had links.  When an update is available, provide details in the SKU area.  Research how to link to the release notes page and if needed update WixDistribution.  I plan to implement (some of) these changes prior to submitting a PR for folks to experiment with.

### Action Controls
The AppX screen shot only shows one Action Control being displayed, however there are configurations where more than one selection is appropriate.  I assume therefore that the controls should be arranged from right to left, with the rightmost being the preferred selection.

In the online meeting #109 the "rightmost being the preferred" was questioned so I will try to find the Microsoft guidelines and check or correct my understanding of them.  

The following is a list (from top to bottom) of the Action controls which would be placed from Right to Left:

* **Update** - The existing WixBA has a single button with several labels, Checking, 'Update Available', 'Up To Date', and no connection (button is hidden).  This mock up button corresponds to "Update Available". The lack of an 'Update' button (hidden) corresponds to 'Up to Date' or 'no connection'.  'Checking' is addressed with an indeterminate progress indicator with text indicating "Checking for updates", in the 'Status' area.
* **Try Again?** - Most Buttons are labeled with a verb, is this the right button label? I'm OK with it.
* **Install** - The mock up does not have any message indicating that the user is accepting the license by installing.  Should it?  Possibly to the far left of the Action Controls or immediately above them to the left.
* **Repair**
* **Uninstall**
* **Exit** - The AppX uses "Close", and the Close button is not displayed in the Install configuration scenario of the screen shot.  Is this button needed, given that there is a Close control in windows chrome?  Currently in the mock up only the chrome control is displayed. 
* **Cancel**

In the online meeting #109 consensus was that a Close button is needed (not named Exit, and in addition to the one in the window chrome, even though AppX seems to use the Windows chrome).

My research of UI Design Guidelines has failed to clarify location of the 'preferred' Button Control, except to point out how the styling that was implemented to get the blue with white lettering, to conform to the AppX screen shots, also conflict with the UI Design Guidelines.  So for the moment I plan to remove that custom styling, and try to conform as much as possible to Windows 10 behavior, leaving the question of matching AppX look, for additional discussion.  As for the placement question, the guidelines indicate that final actions should be in the lower right and that initiating actions should be to the left, and preferably to the top left.  For initial PR I plan to order the initiating Action Controls along the bottom with the preferred action to the left.  One I get this to a functional level I will do a PR to allow folks to try it out and provide additional feedback.  Of course feedback is appreciated at any point.

### Status Information
I don't know what the AppX similarity is so the mock up uses horizontal progress bars and an area for the action text similar in function to the current WixBA.  Currently text indicating the action, 'Checking for updates' is also placed in this area with an indeterminate progress bar (barbershop style).  I researched putting short status text to the immediate left of the Action Controls, in a status bar model, but did not try an implementation yet.

In the online meeting #109 the install progress is immediately above the action buttons.  Consensus to remove the Action Text area, but to have a shorter message which displays the name of the package being installed immediately above the install progress.  I had not worked on styling the progress bar yet (importing code from another project just to get something working) but we want to try and get close to Windows 10 default behavior.  The Update Progress 'marquee' should be replaced with whatever the Windows 10 default behavior is, yet to be researched.

## See Also
Screen shots of the mock up running on Windows 10 Aero, have been placed at:

<https://github.com/phillHgl/wix4.MyResources/tree/develop/ScreenShots/5352-new-wixba-ui-v4/Aero>

Somce screen shots for a dark high contrast configuration have been placed at (with more work needed):

<https://github.com/phillHgl/wix4.MyResources/tree/develop/ScreenShots/5352-new-wixba-ui-v4/Dark>
