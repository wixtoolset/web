---
title: Property Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Property value for a Product or Module.</dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa370908.aspx" target="_blank">Property Table</a>
  </dd>
  <dt>Parents</dt>
  <dd>
    <a href="../control/">Control</a>, <a href="../fragment/">Fragment</a>, <a href="../module/">Module</a>, <a href="../odbcdatasource/">ODBCDataSource</a>, <a href="../odbcdriver/">ODBCDriver</a>, <a href="../product/">Product</a>, <a href="../ui/">UI</a>, <a href="../upgrade/">Upgrade</a></dd>
  <dt>Inner Text (xs:string)</dt>
  <dd>This element may have inner text.</dd>
  <dt>Children</dt>
  <dd>Choice of elements (min: 0, max: unbounded)<ul><li>Sequence (min: 1, max: 1)<ol><li><a href="../compliancedrive/">ComplianceDrive</a> (min: 0, max: 1): Starts searches from the CCP_DRIVE.</li><li><a href="../componentsearch/">ComponentSearch</a> (min: 0, max: unbounded)</li><li><a href="../registrysearch/">RegistrySearch</a> (min: 0, max: unbounded)</li><li><a href="../registrysearchref/">RegistrySearchRef</a> (min: 0, max: unbounded)</li><li><a href="../inifilesearch/">IniFileSearch</a> (min: 0, max: unbounded)</li><li><a href="../directorysearch/">DirectorySearch</a> (min: 0, max: unbounded)</li><li><a href="../directorysearchref/">DirectorySearchRef</a> (min: 0, max: unbounded)</li><li><a href="../productsearch/">ProductSearch</a> (min: 0, max: unbounded)</li></ol></li><li><span class="extension">Any Element (namespace='##other' processContents='Lax')                          Extensibility point in the WiX XML Schema.  Schema extensions can register additional                         elements at this point in the schema.                     </span></li></ul></dd>
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
        <td>Unique identifier for Property.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Admin</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Denotes that the Property is saved during <a href="http://msdn.microsoft.com/library/aa367541.aspx" target="_blank">admininistrative installation</a>. See the <a href="http://msdn.microsoft.com/library/aa367542.aspx" target="_blank">AdminProperties Property</a> for more information.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ComplianceCheck</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Adds a row to the CCPSearch table.  This attribute is only valid when this Property contains a search element.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Hidden</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Denotes that the Property is not logged during installation. See the <a href="http://msdn.microsoft.com/library/aa370308.aspx" target="_blank">MsiHiddenProperties Property</a> for more information.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Secure</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>Denotes that the Property can be passed to the server side when doing a managed installation with elevated privileges. See the <a href="http://msdn.microsoft.com/library/aa371571.aspx" target="_blank">SecureCustomProperties Property</a> for more information.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>SuppressModularization</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>                         Use to suppress modularization of this property identifier in merge modules.                         Using this functionality is strongly discouraged; it should only be                         necessary as a workaround of last resort in rare scenarios.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Value</td>
        <td>String</td>
        <td>Sets a default value for the property.  The value will be overwritten if the Property is used for a search.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td colspan="4">
          <span class="extension">Any Attribute (namespace='##other' processContents='lax')                      Extensibility point in the WiX XML Schema.  Schema extensions can register additional                     attributes at this point in the schema.                 </span>
        </td>
      </tr>
    </table>
  </dd>
  <dt>How Tos and Examples</dt>
  <dd>
    <ul>
      <li>
        <a href="../../howtos/files_and_registry/check_the_version_number">How To: Check the version number of a file during installation</a>
      </li>
    </ul>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>, <a href="../propertyref/">PropertyRef</a></dd>
</dl>
