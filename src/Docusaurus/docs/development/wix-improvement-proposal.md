---
sidebar_position: 10
---

# WiX Improvement Proposals

## User stories

* As a WiX developer I can document changes I plan to make to the WiX Toolset features or processes
such that other developers can discuss the proposal.

* As a WiX developer I can summarize all of the discussion about an improvement such that future
developers and users can find the results in one document.

## Proposal

A WiX Improvement Proposal, or WIP, is a document that defines a process or feature
improvement in the WiX Toolset. Not every change to the WiX Toolset must have a WIP. Bug
fixes, for example, are often sufficiently defined in the [issue tracker]. For
everything else the WIP process is intended to be a lightweight process that provides value
for developers today and tomorrow by recording the data that went into a decision and
providing "institutional memory" for everyone working on the WiX Toolset.

### Proposing a change with a WIP

The following list describes one approach for improving WiX using a WIP:

- **Have an idea for improving WiX.**

- **Break it down, if necessary, to discrete ideas.** We don't want to lose the big picture but
breaking down big ideas helps ensure you've thought through all the steps and helps others better
understand your proposal.

- **Open a feature request on the WiX Toolset [issue tracker].** Provide enough detail about what the
improvement does and how it makes WiX better; that allows the triage team and those attending our fortnightly triage meetings to offer feedback and, if all goes well, schedule the feature in an appropriate release.

- **Draft your WIP.** Get the ideas "down on paper." Send a pull request to get feedback on the draft and updated in the WiX Git repository.

- **Get public feedback.** Start with a post on the [WiX Development category in the WiX discussion area on GitHub](https://github.com/orgs/wixtoolset/discussions/categories/wix-development).

- **Capture the feedback.** Use the feedback to improve your WIP. Add useful suggestions. Address weaknesses. List alternatives. Consider what it means if you're getting lots of negative feedback. (But don't let the haters get to you.)

- **Update your WIP.** Complete all the sections of the WIP. Send pull requests to get feedback from the WiX leads and others. When you're done, send the feature request back for triage to get final approval.

That's not a hard set of rules; nor do you have to do them in that order serially. You could finish coding your change before writing one word in a WIP, for example. The risk in doing so is that you miss out on feedback when you could incorporate it at relatively low cost -- that is, relatively little rework. It's better to overcommunicate and overdiscuss.

## Creating a WiX Improvement Proposal

WIPs live in the comments of the bug or feature request in the [issue tracker]. GitHub lets you edit your own comments so you can update the WIPs as often as necessary (and previous comment versions are available for your viewing pleasure). 


### WIP User Stories

The WIP starts with user stories. Follow the standard user story format "As a _role_, I can
_accomplish task thanks to proposal_ such that _benefit from proposal_." There are a couple
of standard roles in WiX:

* *WiX developer* - someone like you that works on the WiX Toolset itself to improve it.

* *Setup developer* - a user of the WiX Toolset that builds installation packages.

Ideally, there is more than one user story.


### WIP Proposal

The proposal section of the WIP is a fairly freeform description of the feature or process
improvement. Provide the motivation for the proposal. Describe how the proposal works. List examples,
particularly source code, that demonstrates how the improvement will be used. Basically, provide
the bulk of the detail about the WIP here.


### WIP Considerations

As issues with the proposal come to mind or are raised by reviewers, capture them in the
considerations section of the WIP. As appropriate, explain the trade offs of the proposed
design and why a particular decision was made. This section may provide the most value for
developers and users that follow later so do not be afraid to list everything that comes
to mind. Rare is it that a proposal doesn't have some negatives to consider.

## WIP Workflow

Like the code of the WiX Toolset, WIPs are designed to be living documents. So do not be afraid to "check in early and often." Update the issue comments that contain the WIP content whenever you feel the update provides enough value. 

WIPs can be discussed anywhere but everyone is encouraged to contribute their ideas to the proposal by adding comments to the issue or working with the author to update the document.


## Considerations

The WIP process is designed to add value with as little overhead as possible. Of course, it takes effort to write down how a feature should work. But often the process of writing down how to solve a problem, uncovers issues that were not initially considered. Capturing some of the alternatives or objections that came up during development is of significant value, especially for future developers. So, while it takes a bit more time up front, we think the WIPs will add a lot of value over the long term.

Finally, this is not a college writing assignment. Use as many -- or as few -- words as necessary to capture the idea. No need to write a book. Also, feel free to enlist others to help you write the document. Start with a rough draft and have someone help flesh out the missing details.


[issue tracker]: gethelp.md#bugs
