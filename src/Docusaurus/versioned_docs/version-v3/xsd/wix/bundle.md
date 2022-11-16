---
title: Bundle Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>The root element for creating bundled packages.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../wix/">Wix</a>
  </dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../approvedexeforelevation/">ApprovedExeForElevation</a> (min: 0, max: unbounded)</li><li><a href="../bootstrapperapplication/">BootstrapperApplication</a> (min: 0, max: 1)</li><li><a href="../bootstrapperapplicationref/">BootstrapperApplicationRef</a> (min: 0, max: 1)</li><li><a href="../catalog/">Catalog</a> (min: 0, max: unbounded)</li><li><a href="../chain/">Chain</a> (min: 1, max: 1)</li><li><a href="../container/">Container</a> (min: 0, max: unbounded)</li><li><a href="../containerref/">ContainerRef</a> (min: 0, max: unbounded)</li><li><a href="../log/">Log</a> (min: 0, max: 1)</li><li><a href="../optionalupdateregistration/">OptionalUpdateRegistration</a> (min: 0, max: 1)</li><li><a href="../payloadgroup/">PayloadGroup</a> (min: 0, max: unbounded)</li><li><a href="../payloadgroupref/">PayloadGroupRef</a> (min: 0, max: unbounded)</li><li><a href="../relatedbundle/">RelatedBundle</a> (min: 0, max: unbounded)</li><li><a href="../update/">Update</a> (min: 0, max: unbounded)</li><li><a href="../variable/">Variable</a> (min: 0, max: unbounded)</li><li><a href="../wixvariable/">WixVariable</a> (min: 0, max: unbounded)</li><li><span class="extension">Any Element (namespace='##other' processContents='Lax')                Extensibility point in the WiX XML Schema.  Schema extensions can register additional               elements at this point in the schema.             </span><ul><li><a href="../approvedexeforelevation/">ApprovedExeForElevation</a></li><li><a href="../bootstrapperapplication/">BootstrapperApplication</a></li><li><a href="../bootstrapperapplicationref/">BootstrapperApplicationRef</a></li><li><a href="../catalog/">Catalog</a></li><li><a href="../chain/">Chain</a></li><li><a href="../util/componentsearch" class="extension">ComponentSearch</a></li><li><a href="../util/componentsearchref" class="extension">ComponentSearchRef</a></li><li><a href="../bal/condition" class="extension">Condition</a></li><li><a href="../container/">Container</a></li><li><a href="../containerref/">ContainerRef</a></li><li><a href="../util/directorysearch" class="extension">DirectorySearch</a></li><li><a href="../util/directorysearchref" class="extension">DirectorySearchRef</a></li><li><a href="../util/filesearch" class="extension">FileSearch</a></li><li><a href="../util/filesearchref" class="extension">FileSearchRef</a></li><li><a href="../log/">Log</a></li><li><a href="../util/productsearch" class="extension">ProductSearch</a></li><li><a href="../util/productsearchref" class="extension">ProductSearchRef</a></li><li><a href="../util/registrysearch" class="extension">RegistrySearch</a></li><li><a href="../util/registrysearchref" class="extension">RegistrySearchRef</a></li><li><a href="../relatedbundle/">RelatedBundle</a></li><li><a href="../dependency/requires" class="extension">Requires</a></li><li><a href="../tag/tag" class="extension">Tag</a></li><li><a href="../update/">Update</a></li><li><a href="../ux/">UX</a></li><li><a href="../variable/">Variable</a></li></ul></li></ul></dd>
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
        <td>AboutUrl</td>
        <td>String</td>
        <td>             A URL for more information about the bundle to display in Programs and Features (also             known as Add/Remove Programs).           </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Compressed</td>
        <td><a href="../simple_type_yesnodefaulttype/">YesNoDefaultType</a></td>
        <td>Whether Packages and Payloads not assigned to a container should be added to the default attached container or if they should be external. The default is yes.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Condition</td>
        <td>String</td>
        <td>             The condition of the bundle. If the condition is not met, the bundle will             refuse to run. Conditions are checked before the bootstrapper application is loaded             (before detect), and thus can only reference built-in variables such as             variables which indicate the version of the OS.           </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Copyright</td>
        <td>String</td>
        <td>             The legal copyright found in the version resources of final bundle executable. If             this attribute is not provided the copyright will be set to "Copyright (c) [Bundle/@Manufacturer]. All rights reserved.".           </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>DisableModify</td>
        <td><a href="../simple_type_yesnobuttontype/">YesNoButtonType</a></td>
        <td>             Determines whether the bundle can be modified via the Programs and Features (also known as             Add/Remove Programs). If the value is "button" then Programs and Features will show a single             "Uninstall/Change" button. If the value is "yes" then Programs and Features will only show             the "Uninstall" button". If the value is "no", the default, then a "Change" button is shown.             See the DisableRemove attribute for information how to not display the bundle in Programs             and Features.           </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>DisableRemove</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>             Determines whether the bundle can be removed via the Programs and Features (also             known as Add/Remove Programs). If the value is "yes" then the "Uninstall" button will             not be displayed. The default is "no" which ensures there is an "Uninstall" button to             remove the bundle. If the "DisableModify" attribute is also "yes" or "button" then the             bundle will not be displayed in Progams and Features and another mechanism (such as             registering as a related bundle addon) must be used to ensure the bundle can be removed.           </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>DisableRepair</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>This attribute has been deprecated.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>HelpTelephone</td>
        <td>String</td>
        <td>             A telephone number for help to display in Programs and Features (also known as             Add/Remove Programs).           </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>HelpUrl</td>
        <td>String</td>
        <td>             A URL to the help for the bundle to display in Programs and Features (also known as             Add/Remove Programs).           </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>IconSourceFile</td>
        <td>String</td>
        <td>             Path to an icon that will replace the default icon in the final Bundle executable.             This icon will also be displayed in Programs and Features (also known as Add/Remove             Programs).           </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Manufacturer</td>
        <td>String</td>
        <td>             The publisher of the bundle to display in Programs and Features (also known as             Add/Remove Programs).           </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Name</td>
        <td>String</td>
        <td>             The name of the bundle to display in Programs and Features (also known as Add/Remove             Programs). This name can be accessed and overwritten by a BootstrapperApplication             using the WixBundleName bundle variable.           </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ParentName</td>
        <td>String</td>
        <td>             The name of the parent bundle to display in Installed Updates (also known as Add/Remove             Programs). This name is used to nest or group bundles that will appear as updates.             If the parent name does not actually exist, a virtual parent is created automatically.           </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>SplashScreenSourceFile</td>
        <td>String</td>
        <td>Path to a bitmap that will be shown as the bootstrapper application is being loaded. If this attribute is not specified, no splash screen will be displayed.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Tag</td>
        <td>String</td>
        <td>Set this string to uniquely identify this bundle to its own BA, and to related bundles. The value of this string only matters to the BA, and its value has no direct effect on engine functionality.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>UpdateUrl</td>
        <td>String</td>
        <td>             A URL for updates of the bundle to display in Programs and Features (also             known as Add/Remove Programs).           </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>UpgradeCode</td>
        <td><a href="../simple_type_guid/">Guid</a></td>
        <td>             Unique identifier for a family of bundles. If two bundles have the same UpgradeCode the             bundle with the highest version will be installed.           </td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Version</td>
        <td>String</td>
        <td>             The version of the bundle. Newer versions upgrade earlier versions of the bundles             with matching UpgradeCodes.  If the bundle is registered in Programs and Features             then this attribute will be displayed in the Programs and Features user interface.           </td>
        <td>Yes</td>
      </tr>
      <tr>
        <td colspan="4">
          <span class="extension">Any Attribute (namespace='##other' processContents='lax')              Extensibility point in the WiX XML Schema. Schema extensions can register additional             attributes at this point in the schema.           </span>
          <tr>
            <td>
              <span class="extension">ProviderKey</span>
            </td>
            <td>String</td>
            <td>                 Optional attribute to explicitly author the provider key for the entire bundle.              (http://schemas.microsoft.com/wix/DependencyExtension)</td>
            <td>&nbsp;</td>
          </tr>
        </td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>
  </dd>
</dl>
