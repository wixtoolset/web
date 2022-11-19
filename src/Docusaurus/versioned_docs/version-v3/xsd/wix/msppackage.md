---
title: MspPackage Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Describes a single msp package to install.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../chain/">Chain</a>, <a href="../packagegroup/">PackageGroup</a></dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../msiproperty/">MsiProperty</a> (min: 0, max: unbounded)</li><li><a href="../payload/">Payload</a> (min: 0, max: unbounded)</li><li><a href="../payloadgroupref/">PayloadGroupRef</a> (min: 0, max: unbounded)</li><li><span class="extension">Any Element (namespace='##other' processContents='Lax')                  Extensibility point in the WiX XML Schema.  Schema extensions can register additional                 elements at this point in the schema.  The extension's                 <code><nobr>CompilerExtension.ParseElement()</nobr></code>                 method will be called with the package identifier as the first value in                 <code>contextValues</code>.             </span><ul><li><a href="../payload/">Payload</a></li><li><a href="../../dependency/provides" class="extension">Provides</a></li></ul></li></ul></dd>
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
        <td>After</td>
        <td>String</td>
        <td>             The identifier of another package that this one should be installed after. By default the After             attribute is set to the previous sibling package in the Chain or PackageGroup element. If this             attribute is specified ensure that a cycle is not created explicitly or implicitly.         </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Cache</td>
        <td><a href="../simple_type_yesnoalwaystype/">YesNoAlwaysType</a></td>
        <td>Whether to cache the package. The default is "yes".</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>CacheId</td>
        <td>String</td>
        <td>The identifier to use when caching the package.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Compressed</td>
        <td><a href="../simple_type_yesnodefaulttype/">YesNoDefaultType</a></td>
        <td>Whether the package payload should be embedded in a container or left as an external payload.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Description</td>
        <td>String</td>
        <td>           Specifies the description to place in the bootstrapper application data manifest for the package. By default, ExePackages           use the FileName field from the version information, MsiPackages use the ARPCOMMENTS property, and MspPackages use           the Description patch metadata property. Other package types must use this attribute to define a description in the           bootstrapper application data manifest.         </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>DisplayInternalUI</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>             Specifies whether the bundle will show the UI authored into the msp package. The default is "no"             which means all information is routed to the bootstrapper application to provide a unified installation             experience. If "yes" is specified the UI authored into the msp package will be displayed on top of             any bootstrapper application UI.           </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>DisplayName</td>
        <td>String</td>
        <td>           Specifies the display name to place in the bootstrapper application data manifest for the package. By default, ExePackages           use the ProductName field from the version information, MsiPackages use the ProductName property, and MspPackages use           the DisplayName patch metadata property. Other package types must use this attribute to define a display name in the           bootstrapper application data manifest.         </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>DownloadUrl</td>
        <td>String</td>
        <td><p>The URL to use to download the package. The following substitutions are supported:</p><ul><li>{0} is replaced by the package Id.</li><li>{1} is replaced by the payload Id.</li><li>{2} is replaced by the payload file name.</li></ul></td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Id</td>
        <td>String</td>
        <td>             Identifier for this package, for ordering and cross-referencing. The default is the Name attribute             modified to be suitable as an identifier (i.e. invalid characters are replaced with underscores).         </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>InstallCondition</td>
        <td>String</td>
        <td>A condition to evaluate before installing the package. The package will only be installed if the condition evaluates to true. If the condition evaluates to false and the bundle is being installed, repaired, or modified, the package will be uninstalled.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>InstallSize</td>
        <td>String</td>
        <td>             The size this package will take on disk in bytes after it is installed. By default, the binder will             calculate the install size by scanning the package (File table for MSIs, Payloads for EXEs)             and use the total for the install size of the package.         </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>LogPathVariable</td>
        <td>String</td>
        <td>             Name of a Variable that will hold the path to the log file. An empty value will cause the variable to not             be set. The default is "WixBundleLog_[PackageId]" except for MSU packages which default to no logging.         </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Name</td>
        <td>String</td>
        <td>             The destination path and file name for this chain payload. Use this attribute to rename the             chain entry point or extract it into a subfolder. The default value is the file name from the             SourceFile attribute, if provided. At a minimum, the Name or SourceFile attribute must be specified.             The use of '..' directories is not allowed.         </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>PerMachine</td>
        <td><a href="../simple_type_yesnodefaulttype/">YesNoDefaultType</a></td>
        <td>Indicates the package must be executed elevated. The default is "no".</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Permanent</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>             Specifies whether the package can be uninstalled. The default is "no".         </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>RollbackLogPathVariable</td>
        <td>String</td>
        <td>             Name of a Variable that will hold the path to the log file used during rollback. An empty value will cause             the variable to not be set. The default is "WixBundleRollbackLog_[PackageId]" except for MSU packages which             default to no logging.         </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Slipstream</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>             Specifies whether to automatically slipstream the patch for any target msi packages in the chain. The default is "no".             Even when the value is "no", you can still author the SlipstreamMsp element under MsiPackage elements as desired.           </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>SourceFile</td>
        <td>String</td>
        <td>             Location of the package to add to the bundle. The default value is the Name attribute, if provided.             At a minimum, the SourceFile or Name attribute must be specified.         </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>SuppressSignatureVerification</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>           By default, a Bundle will use the hash of a package to verify its contents. If this attribute is explicitly set to "no"           and the package is signed with an Authenticode signature the Bundle will verify the contents of the package using the           signature instead. Therefore, the default for this attribute could be considered to be "yes". It is unusual for "yes" to           be the default of an attribute. In this case, the default was changed in WiX v3.9 after experiencing real-world issues           with Windows verifying Authenticode signatures. Since the Authenticode signatures are no more secure than hashing the           packages directly, the default was changed.         </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Vital</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>             Specifies whether the package must succeed for the chain to continue. The default "yes"             indicates that if the package fails then the chain will fail and rollback or stop. If             "no" is specified then the chain will continue even if the package reports failure.         </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td colspan="4">
          <span class="extension">Any Attribute (namespace='##other' processContents='lax')              Extensibility point in the WiX XML Schema.  Schema extensions can register additional             attributes at this point in the schema.  The extension's             <code><nobr>CompilerExtension.ParseAttribute()</nobr></code>             method will be called with the package identifier in             <code><nobr>contextValues["PackageId"]</nobr></code>.         </span>
          <tr>
            <td>
              <span class="extension">PrereqSupportPackage</span>
            </td>
            <td><a href="../../bal/simple_type_yesnotype">YesNoType</a></td>
            <td>                 When set to "yes", the Prereq BA will plan the package to be installed if its InstallCondition is "true" or empty.              (http://schemas.microsoft.com/wix/BalExtension)</td>
            <td>&nbsp;</td>
          </tr>
        </td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Wix Schema</a>, <a href="../slipstreammsp/">SlipstreamMsp</a></dd>
</dl>
