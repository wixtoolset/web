---
title: Condition Element
layout: documentation_xsd_main
---
<dl>
  <dt>Description</dt>
  <dd>                 Conditions for components, controls, features, and products. The condition is specified in the inner text of the element.             </dd>
  <dt>Windows Installer references</dt>
  <dd>
    <a href="http://msdn.microsoft.com/library/aa368007.aspx" target="_blank">Component Table</a>, <a href="http://msdn.microsoft.com/library/aa368035.aspx" target="_blank">ControlCondition Table</a>, <a href="http://msdn.microsoft.com/library/aa368014.aspx" target="_blank">Condition Table</a>, <a href="http://msdn.microsoft.com/library/aa369752.aspx" target="_blank">LaunchCondition Table</a></dd>
  <dt>Parents</dt>
  <dd>
    <a href="../component/">Component</a>, <a href="../control/">Control</a>, <a href="../feature/">Feature</a>, <a href="../fragment/">Fragment</a>, <a href="../permissionex/">PermissionEx</a>, <a href="../product/">Product</a></dd>
  <dt>Inner Text (xs:string)</dt>
  <dd>                         Under a Component element, the condition becomes the condition of the component.  Under a Control element,                         the condition becomes a ControlCondition entry.  Under a Feature element, the condition becomes a Condition                         entry.  Under a Fragment or Product element, the condition becomes a LaunchCondition entry.                     </dd>
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
        <td>Action</td>
        <td>Enumeration</td>
        <td>                             Used only under Control elements and is required.  Allows specific actions to be applied to a control based                             on the result of this condition.                           This attribute's value must be one of the following:<dl><dt class="enumerationValue"><dfn>default</dfn></dt><dd>                                             Set the Control as the default. Only used under Control elements.                                         </dd><dt class="enumerationValue"><dfn>enable</dfn></dt><dd>                                             Enable the Control. Only used under Control elements.                                         </dd><dt class="enumerationValue"><dfn>disable</dfn></dt><dd>                                             Disable the Control. Only used under Control elements.                                         </dd><dt class="enumerationValue"><dfn>hide</dfn></dt><dd>                                             Hide the Control. Only used under Control elements.                                         </dd><dt class="enumerationValue"><dfn>show</dfn></dt><dd>                                             Display the Control. Only used under Control elements.                                         </dd></dl></td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Level</td>
        <td>Integer</td>
        <td>                             Used only under Feature elements and is required.  Allows modifying the level of a Feature based on the                             result of this condition.                         </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Message</td>
        <td>String</td>
        <td>                             Used only under Fragment or Product elements and is required.  Set the value to the text to display when the                             condition fails and the installation must be terminated.                         </td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>How Tos and Examples</dt>
  <dd>
    <ul>
      <li>
        <a href="../../../howtos/redistributables_and_install_checks/block_install_on_os">How To: Block installation based on OS version</a>
      </li>
      <li>
        <a href="../../../howtos/files_and_registry/check_the_version_number">How To: Check the version number of a file during installation</a>
      </li>
    </ul>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../wix">Wix Schema</a>
  </dd>
</dl>
