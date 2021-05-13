---
title: Development
subtitle: of the WiX toolset
keywords: wix toolset,wix
layout: heronone
sidebarTitle: Additional information
sidebarItems: [
  { uri: "/about/governance/",
    text: "Governance Document" },
  { uri: "/development/code-style/",
    text: "Code Style" },
  { uri: "/development/wips/",
    text: "WiX Improvement Proposals" }
]
---

## WiX Toolset Development

So you want to hack on the WiX Toolset? Excellent. Here's what you need to do...but first, there are some one-time logistical hoops to jump through. 

### Logistics

To get started as a developer we recommend walking through the following steps. You can do them in any order or even in parallel but all of them need to be completed before your first submission can be committed.

1. Join the [wix-devs mailing list](/documentation/mailinglist).
2. Sign the [WiX toolset Contribution License Agreement](/development/assignment-agreement/).
3. Create a fork of the Git repository on GitHub for [WiX v3.x](http://github.com/wixtoolset/wix3) or [WiX v4.x](http://github.com/wixtoolset/wix4) and clone it to your development machine.

### Coding

1. **Find something to work on.** Take a look at the [issues database](https://github.com/wixtoolset/issues/issues) for [open bugs](https://github.com/wixtoolset/issues/labels/bug) or [open feature requests](https://github.com/wixtoolset/issues/labels/feature). Look for issues that aren't assigned to someone already. If you have an idea for a new feature, [open a new feature request](https://github.com/wixtoolset/issues/issues/new/).
2. **Stake your claim.** If the issue is marked *No one assigned*, add a comment indicating that you want to work on it.
3. **Discuss how you'd fix the bug or implement the feature.** Start a thread on the [wix-devs mailing list](/documentation/mailinglist) outlining your approach.      
4. **Act on the feedback.** Not everybody's perfect every time (or so I'm told). Depending on how interesting your issue is, you might get feedback that concurs with your approach or feedback that suggests alternatives. Don't be sad; free feedback is one of the great benefits of contributing to open-source projects. Take it in the positive spirit we hope it was intended.
5. **If needed, create a WiX Improvement Proposal (WIP).** WIPs are lightweight documents that record the data that influenced how an issue was resolved. They're not usually needed for bug fixes but implementing a feature generally involves assumptions and ideas that should be recorded for posterity. The [WIP instructions](/development/wips/0000-wix-improvement-proposal/) have all the details.   
6. **Code your change and test it.** Review our [code style](/development/code-style/) and write consistent code throughout the project. Remember to [build WiX](/development/building-wix/) in both debug and release modes, and to run test\test.bat to make sure nothing is broken.
7. **Send a [pull request](https://help.github.com/articles/using-pull-requests).** A committer will review your pull request and might have feedback that requires you to make further changes. The review cycle might take a few turns -- we're sticklers for code quality.           
8. **Repeat**. Your first change is accepted and getting used by WiX users all over the world. Go grab another bug and do it all over again.
