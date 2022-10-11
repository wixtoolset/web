---
title: Product Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>         The Product element is analogous to the main function in a C program.  When linking, only one Product section         can be given to the linker to produce a successful result.  Using this element creates an msi file.       </dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../wix/wix">Wix</a>
  </dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Sequence (min: 1, max: 1)<ol><li><a href="../wix/package">Package</a> (min: 1, max: 1)</li><li>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../wix/appid">AppId</a> (min: 0, max: unbounded)</li><li><a href="../wix/binary">Binary</a> (min: 0, max: unbounded)</li><li><a href="../wix/compliancecheck">ComplianceCheck</a> (min: 0, max: unbounded)</li><li><a href="../wix/component">Component</a> (min: 0, max: unbounded)</li><li><a href="../wix/componentgroup">ComponentGroup</a> (min: 0, max: unbounded)</li><li><a href="../wix/condition">Condition</a> (min: 0, max: unbounded)</li><li><a href="../wix/customaction">CustomAction</a> (min: 0, max: unbounded)</li><li><a href="../wix/customactionref">CustomActionRef</a> (min: 0, max: unbounded)</li><li><a href="../wix/customtable">CustomTable</a> (min: 0, max: unbounded)</li><li><a href="../wix/directory">Directory</a> (min: 0, max: unbounded)</li><li><a href="../wix/directoryref">DirectoryRef</a> (min: 0, max: unbounded)</li><li><a href="../wix/embeddedchainer">EmbeddedChainer</a> (min: 0, max: unbounded)</li><li><a href="../wix/embeddedchainerref">EmbeddedChainerRef</a> (min: 0, max: unbounded)</li><li><a href="../wix/ensuretable">EnsureTable</a> (min: 0, max: unbounded)</li><li><a href="../wix/feature">Feature</a> (min: 0, max: unbounded)</li><li><a href="../wix/featuregroupref">FeatureGroupRef</a> (min: 0, max: unbounded)</li><li><a href="../wix/featureref">FeatureRef</a> (min: 0, max: unbounded)</li><li><a href="../wix/icon">Icon</a> (min: 0, max: unbounded)</li><li><a href="../wix/instancetransforms">InstanceTransforms</a> (min: 0, max: unbounded)</li><li><a href="../wix/majorupgrade">MajorUpgrade</a> (min: 0, max: unbounded)</li><li><a href="../wix/media">Media</a> (min: 0, max: unbounded)</li><li><a href="../wix/mediatemplate">MediaTemplate</a> (min: 0, max: unbounded)</li><li><a href="../wix/packagecertificates">PackageCertificates</a> (min: 0, max: unbounded)</li><li><a href="../wix/patchcertificates">PatchCertificates</a> (min: 0, max: unbounded)</li><li><a href="../wix/property">Property</a> (min: 0, max: unbounded)</li><li><a href="../wix/propertyref">PropertyRef</a> (min: 0, max: unbounded)</li><li><a href="../wix/setdirectory">SetDirectory</a> (min: 0, max: unbounded)</li><li><a href="../wix/setproperty">SetProperty</a> (min: 0, max: unbounded)</li><li><a href="../wix/sfpcatalog">SFPCatalog</a> (min: 0, max: unbounded)</li><li><a href="../wix/symbolpath">SymbolPath</a> (min: 0, max: unbounded)</li><li><a href="../wix/ui">UI</a> (min: 0, max: unbounded)</li><li><a href="../wix/uiref">UIRef</a> (min: 0, max: unbounded)</li><li><a href="../wix/upgrade">Upgrade</a> (min: 0, max: unbounded)</li><li><a href="../wix/wixvariable">WixVariable</a> (min: 0, max: unbounded)</li><li>Sequence (min: 1, max: 1)<ol><li><a href="../wix/installexecutesequence">InstallExecuteSequence</a> (min: 0, max: 1)</li><li><a href="../wix/installuisequence">InstallUISequence</a> (min: 0, max: 1)</li><li><a href="../wix/adminexecutesequence">AdminExecuteSequence</a> (min: 0, max: 1)</li><li><a href="../wix/adminuisequence">AdminUISequence</a> (min: 0, max: 1)</li><li><a href="../wix/advertiseexecutesequence">AdvertiseExecuteSequence</a> (min: 0, max: 1)</li></ol></li><li><span class="extension">Any Element (namespace='##other' processContents='Lax')                              Extensibility point in the WiX XML Schema.  Schema extensions can register additional                             elements at this point in the schema.                         </span><ul><li><a href="../util/closeapplication" class="extension">CloseApplication</a></li><li><a href="../complus/complusapplication" class="extension">ComPlusApplication</a></li><li><a href="../complus/complusapplicationrole" class="extension">ComPlusApplicationRole</a></li><li><a href="../complus/compluspartition" class="extension">ComPlusPartition</a></li><li><a href="../complus/compluspartitionrole" class="extension">ComPlusPartitionRole</a></li><li><a href="../util/group" class="extension">Group</a></li><li><a href="../vs/helpcollectionref" class="extension">HelpCollectionRef</a></li><li><a href="../vs/helpfilter" class="extension">HelpFilter</a></li><li><a href="../wix/majorupgrade">MajorUpgrade</a></li><li><a href="../dependency/requires" class="extension">Requires</a></li><li><a href="../util/restartresource" class="extension">RestartResource</a></li><li><a href="../sql/sqldatabase" class="extension">SqlDatabase</a></li><li><a href="../tag/tag" class="extension">Tag</a></li><li><a href="../lux/unittestref" class="extension">UnitTestRef</a></li><li><a href="../util/user" class="extension">User</a></li><li><a href="../iis/webapplication" class="extension">WebApplication</a></li><li><a href="../iis/webapppool" class="extension">WebAppPool</a></li><li><a href="../iis/webdirproperties" class="extension">WebDirProperties</a></li><li><a href="../iis/weblog" class="extension">WebLog</a></li><li><a href="../iis/website" class="extension">WebSite</a></li></ul></li></ul></li></ol></dd>
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
        <td><a href="../wix/simple_type_autogenguid">AutogenGuid</a></td>
        <td>The product code GUID for the product.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Codepage</td>
        <td>String</td>
        <td>The code page integer value or web name for the resulting MSI. See remarks for more information.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Language</td>
        <td><a href="../wix/simple_type_localizableinteger">LocalizableInteger</a></td>
        <td>The decimal language ID (LCID) for the product.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Manufacturer</td>
        <td>String</td>
        <td>The manufacturer of the product.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Name</td>
        <td>String</td>
        <td>The descriptive name of the product.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>UpgradeCode</td>
        <td><a href="../wix/simple_type_guid">Guid</a></td>
        <td>The upgrade code GUID for the product.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Version</td>
        <td>String</td>
        <td>The product's version string.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td colspan="4">
          <span class="extension">Any Attribute (namespace='##other' processContents='lax')                      Extensibility point in the WiX XML Schema.  Schema extensions can register additional                     attributes at this point in the schema.                 </span>
        </td>
      </tr>
    </table>
  </dd>
  <dt>Remarks</dt>
  <dd><p>You can specify any valid Windows code page by integer like 1252, or by web name like Windows-1252. See <a href="../../overview/codepage">Code Pages</a> for more information.</p></dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>
  </dd>
</dl>
