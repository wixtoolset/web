---
title: WixVariable Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>                 This element exposes advanced WiX functionality.  Use this element to declare WiX variables                 from directly within your authoring.  WiX variables are not resolved until the final msi/msm/pcp                 file is actually generated.  WiX variables do not persist into the msi/msm/pcp file, so they cannot                 be used when an MSI file is being installed; it's a WiX-only concept.             </dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../bundle/">Bundle</a>, <a href="../fragment/">Fragment</a>, <a href="../module/">Module</a>, <a href="../product/">Product</a></dd>
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
        <td>Id</td>
        <td>String</td>
        <td>The name of the variable.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Overridable</td>
        <td><a href="../simple_type_yesnotype/">YesNoType</a></td>
        <td>                         Set this value to 'yes' in order to make the variable's value overridable either by                         another WixVariable entry or via the command-line option -d&lt;name&gt;=&lt;value&gt;                         for light.exe.  If the same variable is declared overridable in multiple places it                         will cause an error (since WiX won't know which value is correct).  The default value                         is 'no'.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Value</td>
        <td>String</td>
        <td>                         The value of the variable.  The value cannot be an empty string because that would                         make it possible to accidentally set a column to null.                     </td>
        <td>Yes</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../">Wix Schema</a>
  </dd>
</dl>
