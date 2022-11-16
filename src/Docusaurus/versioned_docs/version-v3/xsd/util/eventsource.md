---
title: EventSource Element (Util Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>Creates an event source.</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>
    <a href="../component/">Component</a>
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
        <td>CategoryCount</td>
        <td>Integer</td>
        <td>                         The number of categories in CategoryMessageFile. CategoryMessageFile                         must be specified too.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>CategoryMessageFile</td>
        <td>String</td>
        <td>                         Name of the category message file. CategoryCount must be specified too.                         Note that this is a formatted field, so you can use [#fileId] syntax to                         refer to a file being installed. It is also written as a REG_EXPAND_SZ                         string, so you can use %environment_variable% syntax to refer to a file                         already present on the user's machine.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>EventMessageFile</td>
        <td>String</td>
        <td>                         Name of the event message file.                         Note that this is a formatted field, so you can use [#fileId] syntax to                         refer to a file being installed. It is also written as a REG_EXPAND_SZ                         string, so you can use %environment_variable% syntax to refer to a file                         already present on the user's machine.                     </td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>KeyPath</td>
        <td><a href="../util/simple_type_yesnotype">YesNoType</a></td>
        <td>                         Marks the EventSource registry as the key path of the component it belongs to.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>Log</td>
        <td>String</td>
        <td>Name of the event source's log.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>Name</td>
        <td>String</td>
        <td>Name of the event source.</td>
        <td>Yes</td>
      </tr>
      <tr>
        <td>ParameterMessageFile</td>
        <td>String</td>
        <td>                         Name of the parameter message file.                         Note that this is a formatted field, so you can use [#fileId] syntax to                         refer to a file being installed. It is also written as a REG_EXPAND_SZ                         string, so you can use %environment_variable% syntax to refer to a file                         already present on the user's machine.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>SupportsErrors</td>
        <td><a href="../util/simple_type_yesnotype">YesNoType</a></td>
        <td>                         Equivalent to EVENTLOG_ERROR_TYPE.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>SupportsFailureAudits</td>
        <td><a href="../util/simple_type_yesnotype">YesNoType</a></td>
        <td>                         Equivalent to EVENTLOG_AUDIT_FAILURE.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>SupportsInformationals</td>
        <td><a href="../util/simple_type_yesnotype">YesNoType</a></td>
        <td>                         Equivalent to EVENTLOG_INFORMATION_TYPE.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>SupportsSuccessAudits</td>
        <td><a href="../util/simple_type_yesnotype">YesNoType</a></td>
        <td>                         Equivalent to EVENTLOG_AUDIT_SUCCESS.                     </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>SupportsWarnings</td>
        <td><a href="../util/simple_type_yesnotype">YesNoType</a></td>
        <td>                         Equivalent to EVENTLOG_WARNING_TYPE.                     </td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../util">Util Schema</a>
  </dd>
</dl>
