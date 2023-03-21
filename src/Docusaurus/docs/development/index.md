---
sidebar_position: 100
---

# Development

So you want to hack on the WiX Toolset? Excellent! WiX development happens on [GitHub](https://github.com/wixtoolset/), so you'll need an account there. You'll need to create a fork of the Git repository for [WiX v4](http://github.com/wixtoolset/wix4) on GitHub and clone it to your development machine.

1. **Find something to work on.** Take a look at the [issues database](https://github.com/wixtoolset/issues/issues) for issues labeled [`up for grabs`](https://github.com/wixtoolset/issues/issues?q=is%3Aopen+is%3Aissue+label%3A%22up+for+grabs%22). If you have an idea for a new feature, [open a new feature request](https://github.com/wixtoolset/issues/issues/new/choose).
2. **Stake your claim.** If the issue is marked *No one assigned*, add a comment indicating that you want to work on it.
3. **Discuss how you'd fix the bug or implement the feature.** Start a thread on the [WiX Development](https://github.com/orgs/wixtoolset/discussions/categories/wix-development) category in the [WiX discussions area](https://github.com/orgs/wixtoolset/discussions).
4. **Act on the feedback.** Not everybody's perfect every time (or so I'm told). Depending on how interesting your issue is, you might get feedback that concurs with your approach or feedback that suggests alternatives. Don't be sad; free feedback is one of the great benefits of contributing to open-source projects. Take it in the positive spirit we hope it was intended.
5. **If needed, create a WiX Improvement Proposal (WIP).** WIPs are lightweight documents that record the data that influenced how an issue was resolved. They're not usually needed for bug fixes but implementing a feature generally involves assumptions and ideas that should be recorded for posterity. The [WIP instructions](wix-improvement-proposal.md) have all the details.
6. **Code your change and test it.** Review our [code style](code-style.md) and write consistent code throughout the project. Add unit tests and integration tests as appropriate. Remember to [build WiX](https://github.com/wixtoolset/wix4#to-build-the-wix-toolset) in both debug and release modes, and to run src\test\test.cmd to make sure nothing is broken.
7. **Send a [pull request](https://help.github.com/articles/using-pull-requests).** A committer will review your pull request and might have feedback that requires you to make further changes. The review cycle might take a few turns -- we're sticklers for code quality.
8. **Repeat**. Your first change is accepted and getting used by WiX users all over the world. Go grab another bug and do it all over again.
