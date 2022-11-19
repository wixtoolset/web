---
title: PatchCreation Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>             The PatchCreation element is analogous to the main function in a C program.  When linking, only one PatchCreation section             can be given to the linker to produce a successful result.  Using this element creates a pcp file.             </dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../wix/">Wix</a>
  </dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Sequence (min: 1, max: 1)<ol><li><a href="../patchinformation/">PatchInformation</a> (min: 1, max: 1)</li><li><a href="../patchmetadata/">PatchMetadata</a> (min: 0, max: 1)</li><li><a href="../family/">Family</a> (min: 1, max: unbounded)</li><li>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../patchproperty/">PatchProperty</a> (min: 0, max: unbounded)</li><li><a href="../patchsequence/">PatchSequence</a> (min: 0, max: unbounded)</li><li><a href="../replacepatch/">ReplacePatch</a> (min: 0, max: unbounded)</li><li><a href="../targetproductcode/">TargetProductCode</a> (min: 0, max: unbounded)</li></ul></li></ol></dd>
  <dt>Attributes</dt>
  <dd>
    <table cellspacing="0" cellpadding="0" class="schema">
      <tr>
        <th width="15%">Name</th>
        <th width="15%">Type</th>
        <th width="65%">Description</th>
        <th width="15%">Required</th>
      </tr>
      <tr>
        <td>Id</td>
        <td><a href="../simple_type_guid/">Guid</a></td>
        <td>PatchCreation identifier; this is the primary key for identifying patches.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>AllowMajorVersionMismatches</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Use this to set whether the major versions between the upgrade and target images match. See <a href="http://msdn.microsoft.com/library/aa370890.aspx" target="_blank">AllowProductVersionMajorMismatches</a> for more information.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>AllowProductCodeMismatches</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Use this to set whether the product code between the upgrade and target images match. See <a href="http://msdn.microsoft.com/library/aa370890.aspx" target="_blank">AllowProductCodeMismatches</a> for more information.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>CleanWorkingFolder</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Use this to set whether Patchwiz should clean the temp folder when finished. See <a href="http://msdn.microsoft.com/library/aa370890.aspx" target="_blank">DontRemoveTempFolderWhenFinished</a> for more information.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Codepage</td>
        <td>String</td>
        <td>The code page integer value or web name for the resulting PCP. See remarks for more information.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>OutputPath</td>
        <td>String</td>
        <td>The full path, including file name, of the patch package file that is to be generated. See <a href="http://msdn.microsoft.com/library/aa370890.aspx" target="_blank">PatchOutputPath</a> for more information.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>SourceList</td>
        <td>String</td>
        <td>Used to locate the .msp file for the patch if the cached copy is unavailable. See <a href="http://msdn.microsoft.com/library/aa370890.aspx" target="_blank">PatchSourceList</a> for more information.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>SymbolFlags</td>
        <td>Int</td>
        <td>An 8-digit hex integer representing the combination of patch symbol usage flags to use when creating a binary file patch. See <a href="http://msdn.microsoft.com/library/aa370890.aspx" target="_blank">ApiPatchingSymbolFlags</a> for more information.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>WholeFilesOnly</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Use this to set whether changing files should be included in their entirety. See <a href="http://msdn.microsoft.com/library/aa370890.aspx" target="_blank">IncludeWholeFilesOnly</a> for more information.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>Remarks</dt>
  <dd><p>You can specify any valid Windows code by by integer like 1252, or by web name like Windows-1252. See <a href="../../../overview/codepage">Code Pages</a> for more information.</p></dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>
  </dd>
</dl>
