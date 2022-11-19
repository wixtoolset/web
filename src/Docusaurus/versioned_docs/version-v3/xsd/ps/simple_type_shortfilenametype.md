---
title: ShortFileNameType (Simple Type)
layout: documentation_xsd_simpletype
---
<dl>
  <dt>Description</dt>
  <dd>Values of this type will look like: "FileName.ext".  Only one period is allowed.  The following characters are not allowed: \ ? | &gt; : / * " + , ; = [ ] less-than, or whitespace.  The name cannot be longer than 8 characters and the extension cannot exceed 3 characters.  The value could also be a localization variable with the format !(loc.VARIABLE).</dd>
  <dt>Pattern Type</dt>
  <dd>Must match the regular expression: '[^\\\?|&gt;&lt;:/\*"\+,;=\[\]\. ]{1,8}(\.[^\\\?|&gt;&lt;:/\*"\+,;=\[\]\. ]{0,3})?|([!$])\(loc\.[_A-Za-z][0-9A-Za-z_.]*\)'.</dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Ps Schema</a>
  </dd>
</dl>
