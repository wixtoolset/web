---
title: ComPlusAssembly Element (Complus Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>         Represents a DLL or assembly to be registered with COM+. If         this element is a child of a ComPlusApplication element, the assembly will be         registered in this application. Other ways the Application attribute must be         set to an application. The element must be a descendent of a Component element,         it can not be a child of a ComPlusApplication locator element.       </dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../complus/complusapplication" class="extension">ComPlusApplication</a>, <a href="../wix/component">Component</a></dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Sequence (min: 1, max: 1)<ol><li>Choice of elements (min: 0, max: unbounded)<ul><li><a href="../complus/complusassemblydependency" class="extension">ComPlusAssemblyDependency</a> (min: 0, max: unbounded)</li><li><a href="../complus/compluscomponent" class="extension">ComPlusComponent</a> (min: 0, max: unbounded)</li></ul></li></ol></dd>
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
        <td>           Identifier for the element.         </td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Application</td>
        <td>String</td>
        <td>           If the element is not a child of a ComPlusApplication           element, this attribute should be provided with the id of a ComPlusApplication           element representing the application the assembly is to be registered in.           This attribute can be omitted for a .NET assembly even if the application is           not a child of a ComPlusApplication element.         </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>AssemblyName</td>
        <td>String</td>
        <td>           The name of the assembly used to identify the assembly in           the GAC. This attribute can be provided only if DllPathFromGAC is set to           “yes”.         </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>DllPath</td>
        <td>String</td>
        <td>           The path to locate the assembly DLL during registration.           This attribute should be provided if DllPathFromGAC is not set to “yes”.         </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>DllPathFromGAC</td>
        <td><a href="../complus/simple_type_yesnotype">YesNoType</a></td>
        <td>           Indicates that the DLL path should be extracted from the           GAC instead for being provided in the DllPath attribute. If this attribute is           set to “yes”, the name of the assembly can be provided using the AssemblyName           attribute. Or, if this AssemblyName attribute is missing, the name will be           extracted from the MsiAssemblyName table using the id of the parent Component           element.         </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>EventClass</td>
        <td><a href="../complus/simple_type_yesnotype">YesNoType</a></td>
        <td>           Indicates that the assembly is to be installed as an event           class DLL. This attribute is only valid for native assemblies. The assembly           will be installed with the COM+ catalog’s InstallEventClass() function.         </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>PSDllPath</td>
        <td>String</td>
        <td>           An optional path to an external proxy/stub DLL for the assembly.         </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>RegisterInCommit</td>
        <td><a href="../complus/simple_type_yesnotype">YesNoType</a></td>
        <td>           Indicates that the assembly should be installed in the           commit custom action instead of the normal deferred custom action. This is           necessary when installing .NET assemblies to the GAC in the same           installation, as the assemblies are not visible in the GAC until after the           InstallFinalize action has run.         </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>TlbPath</td>
        <td>String</td>
        <td>           An optional path to an external type lib for the assembly.           This attribute must be provided if the Type attribute is set to “.net”.         </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Type</td>
        <td>Enumeration</td>
        <td>This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>native</dfn></dt><dd></dd><dt class="enumerationValue"><dfn>.net</dfn></dt><dd></dd></dl></td>
        <td>Yes</td>
      </tr>
    </table>
  </dd>
  <dt>Remarks</dt>
  <dd><p>             When installing a native assembly, all components             contained in the assembly must be represented as ComPlusComponent elements             under this element. Any component not listed will not be removed during             uninstall.           </p><p>             The fields DllPath, TlbPath and PSDllPath are formatted             fields that should contain file paths to there respective file types. A typical             value for DllPath for example, should be something like “[#MyAssembly_dll]”,             where “MyAssembly_dll” is the key of the dll file in the File table.           </p><p><b>Warning</b>: The assembly name provided in the AssemblyName             attribute must be a fully specified assembly name, if a partial name is             provided a random assembly matching the partial name will be selected.           </p></dd>
  <dt>See Also</dt>
  <dd>
    <a href="../complus">Complus Schema</a>
  </dd>
</dl>
