---
wip: 0000
type: Process
by: Rob Mensching (rob at firegiant.com), Bob Arnson (bob at joyofsetup.com)
title: WiX Improvement Proposal
---

## User stories

* As a WiX developer I can document changes I plan to make to the WiX toolset features or processes
such that other developers can discuss the proposal.

* As a WiX developer I can summarize all of the discussion about an improvement such that future
developers and users can find the results in one document.

## Proposal

A WiX Improvement Proposal, or WIP, is a document that defines a process or feature
improvement in the WiX toolset. Not every change to the WiX toolset must have a WIP. Bug
fixes, for example, are often sufficiently defined in the [issue tracker]. For
everything else the WIP process is intended to be lightweight process that provides value
for developers today and tomorrow by recording the data that went into a decision and
providing "institutional memory" for everyone working on the WiX toolset.

### Proposing a change with a WIP

The following list describes one approach for improving WiX using a WIP:

- **Have an idea for improving WiX.**

- **Break it down, if necessary, to discrete ideas.** We don't want to lose the big picture but
breaking down big ideas helps ensure you've thought through all the steps and helps others better
understand your proposal.

- **Open a feature request on the WiX toolset [issue tracker].** Provide enough detail about what the
improvement does and how it makes WiX better; that allows the triage team and attendees to offer
feedback and, if all goes well, schedule the feature in an appropriate release.

- **Draft your WIP.** Get the ideas "down on paper." Send a pull request to get feedback on the draft and
updated in the WiX Git repository.

- **Get public feedback.** You have many options for feedback: E-mail to [wix-devs] describing the
proposed change. E-mail to [wix-users] for the user perspective. Blog posts. Tweets.

- **Capture the feedback.** Use the feedback to improve your WIP. Add useful suggestions. Address
weaknesses. List alternatives. Consider what it means if you're getting lots of negative feedback. (But
don't let the haters get to you.)

- **Update your WIP.** Complete all the sections of the WIP. Send pull requests to get feedback from the
WiX leads and others. When you're done, send the feature request back for triage to get final approval.

That's not a hard set of rules; nor do you have to do them in that order serially. You could finish coding
your change before writing one word in a WIP, for example. The risk in doing so is that you miss out on
feedback when you could incorporate it at relatively low cost -- that is, relatively little rework. It's
better to overcommunicate and overdiscuss.

## Creating a WiX Improvement Proposal

The feature request number from the [issue tracker] also serves as the unique WIP identifier. Using
the same identifier lets us use the issue tracker to schedule (and possibly re-schedule) the feature
request with all the other bugs going into a release. It is up to you to ensure that you've entered
the correct number as the WIP identifier.

With WIP identifier in hand you can now get started on the WIP. First, fork the WiX toolset's
[`web` Git repository](https://github.com/wixtoolset/web) and clone the `master` branch of your fork.
A template WIP file exists in the `root\src\documents\development\wips\` folder named
`0000-template-wix-improvement-proposal.html.md`. Copy that file, replacing the four zeros with the WIP
identifier. The remainder of the file name should be the title of the WIP all lowercase with dashes
separating the words. Finally, the file must end with `.html.md` to be processed correctly.

### WIP Metadata

Open your new WIP document and update the metadata at the top of the file. The `wip:` value
should contain the WIP identifier.

The `type:` should be `Feature` when adding or updating
functionality in the WiX toolset or `Process` when updating the development process for the
WiX toolset.

The `author:` metadata should contain your name and any contributor's names (comma delimited).
Your email address address should also be provided to uniquely identify you from others that
may have the same name (however unlikely that may be).

Finally, update the `title:` of the WIP to match the name of the file using title casing.

### WIP User Stories

The WIP starts with user stories. Follow the standard user story format "As a [role], I can
[accomplish task thanks to proposal] such that [benefit from proposal]." There are a couple
standard roles in the WiX toolset:

* *WiX developer* - someone like you that works on the WiX toolset itself to improve it.

* *Setup developer* - a user of the WiX toolset that builds installation packages.

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

Like the code of the WiX toolset, WIPs are designed to be living documents. So do not be afraid
to "check in early and often". Commit your changes to the WIP and send a pull request any time
you feel the update provides enough value. The WIP update pull requests will be accepted like
any code submission, with a very low review bar (essentially, as long as the update is coherent
we'll integrate it for discussion).

WIP documents can be discussed anywhere (mailing list, online meetings, twitter, etc) but everyone
is encouraged to contribute their ideas to the proposal by editing the document or working with
the author to update the document.

## Considerations

The WIP process is designed to add value with as little overhead as possible. Of course, it takes
effort to write down how a feature should work. But often the process of writing down how to solve
a problem, issues are uncovered that were not initially considered.

More than anything capturing the process adds tremendous value to those that value. So, while it
takes a bit more time up front, we think the WIPs will add a lot of value over the long term.

Finally, this is not a college writing assignment. Use as many words as necessary to capture the
idea. No need to write a book. Also, feel free to enlist others to help you write the document.
Start with a rough draft and have someone help flesh out the missing details.

  [issue tracker]: /issues/
  [wix-devs]: /documentation/mailinglist/
