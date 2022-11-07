---
title: Theme Element (Thmutil Extension)
layout: documentation_xsd_extension
---
<dl>
  <dt>Description</dt>
  <dd>None</dd>
  <dt>Windows Installer references</dt>
  <dd>None</dd>
  <dt>Parents</dt>
  <dd>None</dd>
  <dt>Inner Text</dt>
  <dd>None</dd>
  <dt>Children</dt>
  <dd>Choice of elements (min: 1, max: unbounded)<ul><li><a href="../thmutil/font" class="extension">Font</a> (min: 1, max: unbounded)</li><li><a href="../thmutil/imagelist" class="extension">ImageList</a> (min: 1, max: unbounded)</li><li><a href="../thmutil/page" class="extension">Page</a> (min: 1, max: unbounded)</li><li><a href="../thmutil/window" class="extension">Window</a> (min: 1, max: unbounded)</li><li>Choice of elements (min: 1, max: unbounded)<ul><li><a href="../thmutil/billboard" class="extension">Billboard</a> (min: 1, max: unbounded)</li><li><a href="../thmutil/button" class="extension">Button</a> (min: 1, max: unbounded)</li><li><a href="../thmutil/checkbox" class="extension">Checkbox</a> (min: 1, max: unbounded)</li><li><a href="../thmutil/combobox" class="extension">Combobox</a> (min: 1, max: unbounded)</li><li><a href="../thmutil/editbox" class="extension">Editbox</a> (min: 1, max: unbounded)</li><li><a href="../thmutil/hyperlink" class="extension">Hyperlink</a> (min: 1, max: unbounded)</li><li><a href="../thmutil/hypertext" class="extension">Hypertext</a> (min: 1, max: unbounded)</li><li><a href="../thmutil/image" class="extension">Image</a> (min: 1, max: unbounded)</li><li><a href="../thmutil/listview" class="extension">ListView</a> (min: 1, max: unbounded)</li><li><a href="../thmutil/progressbar" class="extension">Progressbar</a> (min: 1, max: unbounded)</li><li><a href="../thmutil/richedit" class="extension">Richedit</a> (min: 1, max: unbounded)</li><li><a href="../thmutil/static" class="extension">Static</a> (min: 1, max: unbounded)</li><li><a href="../thmutil/tab" class="extension">Tab</a> (min: 1, max: unbounded)</li><li><a href="../thmutil/text" class="extension">Text</a> (min: 1, max: unbounded)</li><li><a href="../thmutil/treeview" class="extension">TreeView</a> (min: 1, max: unbounded)</li></ul></li></ul></dd>
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
        <td>ImageFile</td>
        <td>String</td>
        <td>Relative path to an image file that can serve as a single source for images in the rest of the                     theme. This image is referenced by controls using the SourceX and SourceY attributes.</td>
        <td>&nbsp;</td>
      </tr>
    </table>
  </dd>
  <dt>See Also</dt>
  <dd>
    <a href="../thmutil">Thmutil Schema</a>
  </dd>
</dl>
