---
title: WildCardLongFileNameType (Simple Type)
layout: documentation_xsd_simpletype
---
<dl>
  <dt>Description</dt>
  <dd>Values of this type will look like: "Long File N?me.extension*".  Legal long names contain no more than 260 characters and must contain at least one non-period character.  The following characters are not allowed: \ | &gt; : / " or less-than.  The name must be shorter than 260 characters.  The value could also be a localization variable with the format !(loc.VARIABLE).</dd>
  <dt>Pattern Type</dt>
  <dd>Must match the regular expression: '[^\\\|&gt;&lt;:/"]{1,259}|([!$])\(loc\.[_A-Za-z][0-9A-Za-z_.]*\)'.</dd>
  <dt>See Also</dt>
  <dd>
    <a href="../tag">Tag Schema</a>
  </dd>
</dl>
