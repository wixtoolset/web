---
title: EmbeddedUI Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Element value is the condition. Use CDATA if message contains delimiter characters.</dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/bb736317.aspx" target="_blank">MsiEmbeddedUI Table</a>
  </dd>
  <dt>Parents</dt>
  <dd>
    <a href="../ui/">UI</a>
  </dd>
  <dt>Inner Text (xs:string)</dt>
  <dd>This element may have inner text.</dd>
  <dt>Children</dt>
  <dd>Sequence (min: 1, max: 1)<ol><li><a href="../embeddeduiresource/">EmbeddedUIResource</a> (min: 0, max: unbounded): Specifies extra files to be extracted for use by the embedded UI, such as language resources.</li></ol></dd>
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
        <td>String</td>
        <td>                         Unique identifier for embedded UI.If this attribute is not specified the Name attribute or the file name                         portion of the SourceFile attribute will be used.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>IgnoreActionData</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Embedded UI will not recieve any INSTALLLOGMODE_ACTIONDATA messages.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>IgnoreActionStart</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Embedded UI will not recieve any INSTALLLOGMODE_ACTIONSTART messages.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>IgnoreCommonData</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Embedded UI will not recieve any INSTALLLOGMODE_COMMONDATA messages.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>IgnoreError</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Embedded UI will not recieve any INSTALLLOGMODE_ERROR messages.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>IgnoreFatalExit</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Embedded UI will not recieve any INSTALLLOGMODE_FATALEXIT messages.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>IgnoreFilesInUse</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Embedded UI will not recieve any INSTALLLOGMODE_FILESINUSE messages.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>IgnoreInfo</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Embedded UI will not recieve any INSTALLLOGMODE_INFO messages.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>IgnoreInitialize</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Embedded UI will not recieve any INSTALLLOGMODE_INITIALIZE messages.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>IgnoreInstallEnd</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Embedded UI will not recieve any INSTALLLOGMODE_INSTALLEND messages.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>IgnoreInstallStart</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Embedded UI will not recieve any INSTALLLOGMODE_INSTALLSTART messages.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>IgnoreOutOfDiskSpace</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Embedded UI will not recieve any INSTALLLOGMODE_OUTOFDISKSPACE messages.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>IgnoreProgress</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Embedded UI will not recieve any INSTALLLOGMODE_PROGRESS messages.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>IgnoreResolveSource</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Embedded UI will not recieve any INSTALLLOGMODE_RESOLVESOURCE messages.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>IgnoreRMFilesInUse</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Embedded UI will not recieve any INSTALLLOGMODE_RMFILESINUSE messages.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>IgnoreShowDialog</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Embedded UI will not recieve any INSTALLLOGMODE_SHOWDIALOG messages.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>IgnoreTerminate</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Embedded UI will not recieve any INSTALLLOGMODE_TERMINATE messages.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>IgnoreUser</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Embedded UI will not recieve any INSTALLLOGMODE_USER messages.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>IgnoreWarning</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Embedded UI will not recieve any INSTALLLOGMODE_WARNING messages.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Name</td>
        <td><a href="../simple_type_longfilenametype/">LongFileNameType</a></td>
        <td>                         The name for the embedded UI DLL when it is extracted from the Product and executed. (Windows Installer                         does not support the typical short filename and long filename combination for embedded UI files as it                         does for other kinds of files.) If this attribute is not specified the file name portion of the SourceFile                         attribute will be used.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>SourceFile</td>
        <td>String</td>
        <td>                         Path to the binary file that is the embedded UI. This must be a DLL that exports the following                         three entry points: InitializeEmbeddedUI, EmbeddedUIHandler and ShutdownEmbeddedUI.                     </td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>SupportBasicUI</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Set yes to allow the Windows Installer to display the embedded UI during basic UI level installation.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>
  </dd>
</dl>
