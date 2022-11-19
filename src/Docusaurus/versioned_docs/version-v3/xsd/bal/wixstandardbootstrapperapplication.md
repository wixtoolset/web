---
title: WixStandardBootstrapperApplication Element (Bal Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>                 Configures WixStandardBootstrapperApplication for a Bundle.             </dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../../wix/bootstrapperapplicationref/">BootstrapperApplicationRef</a>
  </dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>None</dd>
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
        <td>LaunchArguments</td>
        <td>String</td>
        <td>                         If set, WixStdBA will supply these arguments when launching the application specified by the LaunchTarget attribute.                         The string value can be formatted using Burn variables enclosed in brackets,                         to refer to installation directories and so forth.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>LaunchHidden</td>
        <td><a href="../../bal/simple_type_yesnotype">YesNoType</a></td>
        <td>                         If set to "yes", WixStdBA will launch the application specified by the LaunchTarget attribute with the SW_HIDE flag.                         This attribute is ignored when the LaunchTargetElevatedId attribute is specified.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>LaunchTarget</td>
        <td>String</td>
        <td>                         If set, the success page will show a Launch button the user can use to launch the application being installed.                         The string value can be formatted using Burn variables enclosed in brackets,                          to refer to installation directories and so forth.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>LaunchTargetElevatedId</td>
        <td>String</td>
        <td>                         Id of the target ApprovedExeForElevation element.                         If set with LaunchTarget, WixStdBA will launch the application through the Engine's LaunchApprovedExe method instead of through ShellExecute.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>LaunchWorkingFolder</td>
        <td>String</td>
        <td>                         WixStdBA will use this working folder when launching the specified application.                         The string value can be formatted using Burn variables enclosed in brackets,                         to refer to installation directories and so forth.                         This attribute is ignored when the LaunchTargetElevatedId attribute is specified.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>LicenseFile</td>
        <td>String</td>
        <td>Source file of the RTF license file. Cannot be used simultaneously with LicenseUrl.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>LicenseUrl</td>
        <td>String</td>
        <td>URL target of the license link. Cannot be used simultaneously with LicenseFile. This attribute can be empty to hide the license link completely.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>LocalizationFile</td>
        <td>String</td>
        <td>Source file of the theme localization .wxl file.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>LogoFile</td>
        <td>String</td>
        <td>Source file of the logo graphic.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>LogoSideFile</td>
        <td>String</td>
        <td>Source file of the side logo graphic.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ShowFilesInUse</td>
        <td><a href="../../bal/simple_type_yesnotype">YesNoType</a></td>
        <td>If set to "yes", WixStdBA will show a page allowing the user to restart applications when files are in use.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ShowVersion</td>
        <td><a href="../../bal/simple_type_yesnotype">YesNoType</a></td>
        <td>If set to "yes", the application version will be displayed on the UI.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>SupportCacheOnly</td>
        <td><a href="../../bal/simple_type_yesnotype">YesNoType</a></td>
        <td>If set to "yes", the bundle can be pre-cached using the /cache command line argument.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>SuppressDowngradeFailure</td>
        <td><a href="../../bal/simple_type_yesnotype">YesNoType</a></td>
        <td>If set to "yes", attempting to installer a downgraded version of a bundle will be treated as a successful do-nothing operation.                     The default behavior (or when explicitly set to "no") is to treat downgrade attempts as failures. </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>SuppressOptionsUI</td>
        <td><a href="../../bal/simple_type_yesnotype">YesNoType</a></td>
        <td>If set to "yes", the Options button will not be shown and the user will not be able to choose an installation directory.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>SuppressRepair</td>
        <td><a href="../../bal/simple_type_yesnotype">YesNoType</a></td>
        <td>If set to "yes", the Repair button will not be shown in the maintenance-mode UI.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ThemeFile</td>
        <td>String</td>
        <td>Source file of the theme XML.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Bal Schema</a>
  </dd>
</dl>
