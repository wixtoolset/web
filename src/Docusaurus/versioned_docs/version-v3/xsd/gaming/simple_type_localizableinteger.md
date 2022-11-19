---
title: LocalizableInteger (Simple Type)
layout: documentation_xsd_simpletype
---
<dl>
  <dt>Description</dt>
  <dd>Values of this type must be an integer or the value can be a localization variable with the format !(loc.Variable) where "Variable" is the name of the variable.</dd>
  <dt>Pattern Type</dt>
  <dd>Must match the regular expression: '[0-9][0-9]*|([!$])\((loc|bind)\.[_A-Za-z][0-9A-Za-z_.]+\)'.</dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Gaming Schema</a>
  </dd>
</dl>
