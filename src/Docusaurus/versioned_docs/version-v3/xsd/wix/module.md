---
title: Module Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>             The Module element is analogous to the main function in a C program.  When linking, only             one Module section can be given to the linker to produce a successful result.  Using this             element creates an msm file.             </dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../wix/">Wix</a>
  </dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Sequence (min: 1, max: 1)<ol><li><a href="../package/">Package</a> (min: 1, max: 1)</li><li>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../appid/">AppId</a> (min: 0, max: unbounded)</li><li><a href="../binary/">Binary</a> (min: 0, max: unbounded)</li><li><a href="../component/">Component</a> (min: 0, max: unbounded)</li><li><a href="../componentgroupref/">ComponentGroupRef</a> (min: 0, max: unbounded)</li><li><a href="../componentref/">ComponentRef</a> (min: 0, max: unbounded)</li><li><a href="../configuration/">Configuration</a> (min: 0, max: unbounded)</li><li><a href="../customaction/">CustomAction</a> (min: 0, max: unbounded)</li><li><a href="../customactionref/">CustomActionRef</a> (min: 0, max: unbounded)</li><li><a href="../customtable/">CustomTable</a> (min: 0, max: unbounded)</li><li><a href="../../dependency/">Dependency</a> (min: 0, max: unbounded)</li><li><a href="../directory/">Directory</a> (min: 0, max: unbounded)</li><li><a href="../directoryref/">DirectoryRef</a> (min: 0, max: unbounded)</li><li><a href="../embeddedchainer/">EmbeddedChainer</a> (min: 0, max: unbounded)</li><li><a href="../embeddedchainerref/">EmbeddedChainerRef</a> (min: 0, max: unbounded)</li><li><a href="../ensuretable/">EnsureTable</a> (min: 0, max: unbounded)</li><li><a href="../exclusion/">Exclusion</a> (min: 0, max: unbounded)</li><li><a href="../icon/">Icon</a> (min: 0, max: unbounded)</li><li><a href="../ignoremodularization/">IgnoreModularization</a> (min: 0, max: unbounded)</li><li><a href="../ignoretable/">IgnoreTable</a> (min: 0, max: unbounded)</li><li><a href="../property/">Property</a> (min: 0, max: unbounded)</li><li><a href="../propertyref/">PropertyRef</a> (min: 0, max: unbounded)</li><li><a href="../setdirectory/">SetDirectory</a> (min: 0, max: unbounded)</li><li><a href="../setproperty/">SetProperty</a> (min: 0, max: unbounded)</li><li><a href="../sfpcatalog/">SFPCatalog</a> (min: 0, max: unbounded)</li><li><a href="../substitution/">Substitution</a> (min: 0, max: unbounded)</li><li><a href="../ui/">UI</a> (min: 0, max: unbounded)</li><li><a href="../uiref/">UIRef</a> (min: 0, max: unbounded)</li><li><a href="../wixvariable/">WixVariable</a> (min: 0, max: unbounded)</li><li>Sequence (min: 1, max: 1)<ol><li><a href="../installexecutesequence/">InstallExecuteSequence</a> (min: 0, max: 1)</li><li><a href="../installuisequence/">InstallUISequence</a> (min: 0, max: 1)</li><li><a href="../adminexecutesequence/">AdminExecuteSequence</a> (min: 0, max: 1)</li><li><a href="../adminuisequence/">AdminUISequence</a> (min: 0, max: 1)</li><li><a href="../advertiseexecutesequence/">AdvertiseExecuteSequence</a> (min: 0, max: 1)</li></ol></li><li><span class="extension">Any Element (namespace='##other' processContents='Lax')                              Extensibility point in the WiX XML Schema.  Schema extensions can register additional                             elements at this point in the schema.                         </span><ul><li><a href="../../util/closeapplication" class="extension">CloseApplication</a></li><li><a href="../../complus/complusapplication" class="extension">ComPlusApplication</a></li><li><a href="../../complus/complusapplicationrole" class="extension">ComPlusApplicationRole</a></li><li><a href="../../complus/compluspartition" class="extension">ComPlusPartition</a></li><li><a href="../../complus/compluspartitionrole" class="extension">ComPlusPartitionRole</a></li><li><a href="../../util/group" class="extension">Group</a></li><li><a href="../../vs/helpcollectionref" class="extension">HelpCollectionRef</a></li><li><a href="../../vs/helpfilter" class="extension">HelpFilter</a></li><li><a href="../../dependency/requires" class="extension">Requires</a></li><li><a href="../../util/restartresource" class="extension">RestartResource</a></li><li><a href="../../sql/sqldatabase" class="extension">SqlDatabase</a></li><li><a href="../../util/user" class="extension">User</a></li><li><a href="../../iis/webapplication" class="extension">WebApplication</a></li><li><a href="../../iis/webapppool" class="extension">WebAppPool</a></li><li><a href="../../iis/webdirproperties" class="extension">WebDirProperties</a></li><li><a href="../../iis/weblog" class="extension">WebLog</a></li><li><a href="../../iis/website" class="extension">WebSite</a></li></ul></li></ul></li></ol></dd>
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
        <td>The name of the merge module (not the file name).</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Codepage</td>
        <td>String</td>
        <td>The code page integer value or web name for the resulting MSM. See remarks for more information.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Guid</td>
        <td><a href="../simple_type_guid/">Guid</a></td>
        <td>This attribute is deprecated. Use the Package/@Id attribute instead.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Language</td>
        <td><a href="../simple_type_localizableinteger/">LocalizableInteger</a></td>
        <td>The decimal language ID (LCID) of the merge module.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Version</td>
        <td>String</td>
        <td>The major and minor versions of the merge module.</td>
        <td>Yes</td>
      </tr>
    </table>
  </dd>
  <dt>Remarks</dt>
  <dd><p>You can specify any valid Windows code by by integer like 1252, or by web name like Windows-1252. See <a href="../../../overview/codepage">Code Pages</a> for more information.</p></dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Wix Schema</a>
  </dd>
</dl>
