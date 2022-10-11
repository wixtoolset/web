---
title: PatchMetadata Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Properties about the patch to be placed in the PatchMetadata table.</dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa370344.aspx" target="_blank">MsiPatchMetadata Table</a>
  </dd>
  <dt>Parents</dt>
  <dd>
    <a href="../wix/patchcreation">PatchCreation</a>
  </dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Sequence (min: 1, max: 1)<ol><li>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../wix/customproperty">CustomProperty</a> (min: 0, max: unbounded): A custom property that extends the standard set.</li><li><a href="../wix/optimizecustomactions">OptimizeCustomActions</a> (min: 0, max: 1): Indicates whether custom actions can be skipped when applying the patch.</li></ul></li></ol></dd>
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
        <td><a href="../wix/simple_type_yesnotype">YesNoType</a></td>
        <td>Whether this is an uninstallable patch.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Classification</td>
        <td>String</td>
        <td>Category of updates. Recommended values are Critical Update, Hotfix, Security Rollup, Security Update, Service Pack, Update, Update Rollup.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>CreationTimeUTC</td>
        <td>String</td>
        <td>Creation time of the .msp file in the form mm-dd-yy HH:MM (month-day-year hour:minute).</td>
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
        <td>ManufacturerName</td>
        <td>String</td>
        <td>Name of the manufacturer.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>MinorUpdateTargetRTM</td>
        <td>String</td>
        <td>                     Indicates that the patch targets the RTM version of the product or the most recent major                     upgrade patch.  Author this optional property in minor update patches that contain sequencing                     information to indicate that the patch removes all patches up to the RTM version of the                     product, or up to the most recent major upgrade patch.  This property is available beginning                     with Windows Installer 3.1.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>MoreInfoURL</td>
        <td>String</td>
        <td>A URL that provides information specific to this patch.  In Add/Remove Programs from XP SP2 on.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>OptimizedInstallMode</td>
        <td><a href="../wix/simple_type_yesnotype">YesNoType</a></td>
        <td>                     If this attribute is set to 'yes' in all the patches to be applied in a transaction, the                     application of the patch is optimized if possible.  Available beginning with Windows Installer 3.1.                 </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>TargetProductName</td>
        <td>String</td>
        <td>Name of the application or target product suite.</td>
        <td>Yes</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>
  </dd>
</dl>
