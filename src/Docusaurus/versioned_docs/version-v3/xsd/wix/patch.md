---
title: Patch Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>             The Patch element is analogous to the main function in a C program.  When linking, only one Patch section             can be given to the linker to produce a successful result.  Using this element creates an MSP file.             </dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../wix/">Wix</a>
  </dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Sequence (min: 1, max: 1)<ol><li>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../media/">Media</a> (min: 1, max: unbounded)</li><li><a href="../optimizecustomactions/">OptimizeCustomActions</a> (min: 0, max: 1): Indicates whether custom actions can be skipped when applying the patch.</li><li><a href="../patchfamily/">PatchFamily</a> (min: 1, max: unbounded)</li><li><a href="../patchfamilygroup/">PatchFamilyGroup</a> (min: 1, max: unbounded)</li><li><a href="../patchfamilygroupref/">PatchFamilyGroupRef</a> (min: 0, max: unbounded)</li><li><a href="../patchfamilyref/">PatchFamilyRef</a> (min: 0, max: unbounded)</li><li><a href="../patchinformation/">PatchInformation</a> (min: 0, max: 1): Optional element that allows overriding summary information properties.</li><li><a href="../patchproperty/">PatchProperty</a> (min: 0, max: unbounded)</li><li><a href="../targetproductcodes/">TargetProductCodes</a> (min: 0, max: unbounded)</li><li><span class="extension">Any Element (namespace='##other' processContents='Lax')                              Extensibility point in the WiX XML Schema.  Schema extensions can register additional                             elements at this point in the schema.                         </span></li></ul></li></ol></dd>
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
        <td>AllowRemoval</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Whether this is an uninstallable patch.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ApiPatchingSymbolNoFailuresFlag</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Flag used when creating a binary file patch. Default is "no". Don't fail patch due to imagehlp failures.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ApiPatchingSymbolNoImagehlpFlag</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Flag used when creating a binary file patch. Default is "no". Don't use imagehlp.dll.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ApiPatchingSymbolUndecoratedTooFlag</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Flag used when creating a binary file patch. Default is "no". After matching decorated symbols, try to match remaining by undecorated names.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Classification</td>
        <td>String</td>
        <td>Category of updates. Recommended values are Critical Update, Hotfix, Security Rollup, Security Update, Service Pack, Update, Update Rollup.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>ClientPatchId</td>
        <td>String</td>
        <td>An easily referenced identity unique to a patch that can be used in product authoring. See remarks for more information.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Codepage</td>
        <td>String</td>
        <td>The code page integer value or web name for the resulting MSP. See remarks for more information.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Comments</td>
        <td>String</td>
        <td>Optional comments for browsing.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Description</td>
        <td>String</td>
        <td>Description of the patch.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>DisplayName</td>
        <td>String</td>
        <td>A title for the patch that is suitable for public display. In Add/Remove Programs from XP SP2 on.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Id</td>
        <td><a href="../simple_type_autogenguid/">AutogenGuid</a></td>
        <td>Patch code for this patch.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Manufacturer</td>
        <td>String</td>
        <td>Vendor releasing the package</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>MinorUpdateTargetRTM</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>                     Indicates that the patch targets the RTM version of the product or the most recent major                     upgrade patch.  Author this optional property in minor update patches that contain sequencing                     information to indicate that the patch removes all patches up to the RTM version of the                     product, or up to the most recent major upgrade patch.  This property is available beginning                     with Windows Installer 3.1.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>MoreInfoURL</td>
        <td>String</td>
        <td>A URL that provides information specific to this patch.  In Add/Remove Programs from XP SP2 on.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>OptimizedInstallMode</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>                     If this attribute is set to 'yes' in all the patches to be applied in a transaction, the                     application of the patch is optimized if possible.  Available beginning with Windows Installer 3.1.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>OptimizePatchSizeForLargeFiles</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>When this attribute is set, patches for files greater than approximately 4 MB in size may be made smaller.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>TargetProductName</td>
        <td>String</td>
        <td>Name of the application or target product suite.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>Remarks</dt>
  <dd><p>You can specify any valid Windows code by by integer like 1252, or by web name like Windows-1252. See <a href="../../../overview/codepage">Code Pages</a> for more information.</p><p>The ClientPatchId attribute allows you to specify an easily referenced identity that you can use in product authoring. This identity prefixes properties added by WiX to a patch transform, such as <i>ClientPatchId</i>.PatchCode and <i>ClientPatchId</i>.AllowRemoval. If the patch code GUID is auto-generated you could not reference any properties using this auto-generated prefix.</p><p>For example, if you were planning to ship a patch referred to as "QFE1" and needed to write your own registry values for Add/Remove Programs in product authoring such as the UninstallString for this patch, you could author a RegistryValue with the name UninstallString and the value <code><nobr>[SystemFolder]msiexec.exe</nobr> /package [ProductCode] /uninstall [QFE1.PatchCode]</code>. In your patch authoring you would then set ClientPatchId to "QFE1" and WiX will add the QFE1.PatchCode property to the patch transform when the patch is created. If the Id attribute specified the patch code to be generated automatically, you could not reference the <i>prefix</i>.PatchCode property as shown above.</p><p>The summary information is automatically populated from attribute values of the Patch element including the code page. If you want to override some of these summary information properties or use a different code page for the summary information itself, author the PatchInformation element.</p></dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Wix Schema</a>
  </dd>
</dl>
