---
title: BootstrapperApplicationRef Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>Used to reference a BootstrapperApplication element and optionally add additional payloads to the bootstrapper application.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../wix/bundle">Bundle</a>, <a href="../wix/fragment">Fragment</a></dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../wix/payload">Payload</a> (min: 0, max: unbounded)</li><li><a href="../wix/payloadgroupref">PayloadGroupRef</a> (min: 0, max: unbounded)</li><li><span class="extension">Any Element (namespace='##other' processContents='Lax')                  Extensibility point in the WiX XML Schema.  Schema extensions can register additional                 elements at this point in the schema.               </span><ul><li><a href="../bal/wixmanagedbootstrapperapplicationhost" class="extension">WixManagedBootstrapperApplicationHost</a></li><li><a href="../bal/wixstandardbootstrapperapplication" class="extension">WixStandardBootstrapperApplication</a></li></ul></li></ul></dd>
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
        <td>The identifier of the BootstrapperApplication element to reference.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td colspan="4">
          <span class="extension">Any Attribute (namespace='##other' processContents='lax')                Extensibility point in the WiX XML Schema.  Schema extensions can register additional               attributes at this point in the schema.             </span>
          <tr>
            <td>
              <span class="extension">UseUILanguages</span>
            </td>
            <td><a href="../bal/simple_type_yesnotype">YesNoType</a></td>
            <td>                 When set to "yes", causes WixStdBA/Prereq BA to use the user's control panel language settings. Otherwise, the previous API (which uses locale instead of language) is used to maintain compatiblity with previous versions of WiX.                 On Vista and newer platforms, this value set to "yes" will search all specified user languages, including fallback languages, in order.              (http://schemas.microsoft.com/wix/BalExtension)</td>
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
