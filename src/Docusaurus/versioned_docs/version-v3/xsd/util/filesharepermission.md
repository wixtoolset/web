---
title: FileSharePermission Element (Util Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>                 Sets ACLs on a FileShare.  This element has no Id attribute.                 The table and key are taken from the parent element.             </dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../util/fileshare" class="extension">FileShare</a>
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
        <td>ChangePermission</td>
        <td><a href="../util/simple_type_yesnotype">YesNoType</a></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>CreateChild</td>
        <td><a href="../util/simple_type_yesnotype">YesNoType</a></td>
        <td>For a directory, the right to create a subdirectory.  Only valid under a 'CreateFolder' parent.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>CreateFile</td>
        <td><a href="../util/simple_type_yesnotype">YesNoType</a></td>
        <td>For a directory, the right to create a file in the directory.  Only valid under a 'CreateFolder' parent.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Delete</td>
        <td><a href="../util/simple_type_yesnotype">YesNoType</a></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>DeleteChild</td>
        <td><a href="../util/simple_type_yesnotype">YesNoType</a></td>
        <td>For a directory, the right to delete a directory and all the files it contains, including read-only files.  Only valid under a 'CreateFolder' parent.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>GenericAll</td>
        <td><a href="../util/simple_type_yesnotype">YesNoType</a></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>GenericExecute</td>
        <td><a href="../util/simple_type_yesnotype">YesNoType</a></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>GenericRead</td>
        <td><a href="../util/simple_type_yesnotype">YesNoType</a></td>
        <td>specifying this will fail to grant read access</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>GenericWrite</td>
        <td><a href="../util/simple_type_yesnotype">YesNoType</a></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Read</td>
        <td><a href="../util/simple_type_yesnotype">YesNoType</a></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ReadAttributes</td>
        <td><a href="../util/simple_type_yesnotype">YesNoType</a></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ReadExtendedAttributes</td>
        <td><a href="../util/simple_type_yesnotype">YesNoType</a></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>ReadPermission</td>
        <td><a href="../util/simple_type_yesnotype">YesNoType</a></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Synchronize</td>
        <td><a href="../util/simple_type_yesnotype">YesNoType</a></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>TakeOwnership</td>
        <td><a href="../util/simple_type_yesnotype">YesNoType</a></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Traverse</td>
        <td><a href="../util/simple_type_yesnotype">YesNoType</a></td>
        <td>For a directory, the right to traverse the directory.  By default, users are assigned the BYPASS_TRAVERSE_CHECKING privilege, which ignores the FILE_TRAVERSE access right.  Only valid under a 'CreateFolder' parent.</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>User</td>
        <td>String</td>
        <td>&nbsp;</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>WriteAttributes</td>
        <td><a href="../util/simple_type_yesnotype">YesNoType</a></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>WriteExtendedAttributes</td>
        <td><a href="../util/simple_type_yesnotype">YesNoType</a></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../util">Util Schema</a>
  </dd>
</dl>
