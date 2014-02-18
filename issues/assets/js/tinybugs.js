var dirty = false;
var dirtyMessage = "There are edits to this web page. Are you sure you want to abandon them?";

function enableDirtyCheck(message) {
  dirtyMessage = message;
  $(':input').change(function () {
    dirty = true;
  });
}

function clearDirty() {
  dirty = false;
}

function qs() {
  var query = window.location.search.substring(1);
  var pl = /\+/g;  // Regex for replacing addition symbol with a space
  var split = /([^&=]+)=?([^&]*)/g;
  var decode = function (s) { return decodeURIComponent(s.replace(pl, " ")); };
  var match;

  var urlParams = {};
  while (match = split.exec(query)) {
    urlParams[decode(match[1]).toLowerCase()] = decode(match[2]);
  }

  return urlParams;
}

function updateStatusSubmitButton(issueStatus, issueResolution, primaryButtonClass) {
  var triage = $('#triage').prop('checked');
  var resolution = $("#resolution").val();

  if (triage) {
    if (resolution && resolution != issueResolution) {
      $("#submit").text('Triage resolution');
    }
    else if (!resolution && issueResolution) {
      $("#submit").text('Triage issue');
    }
    else if (issueStatus === 'Untriaged') {
      $("#submit").text('Save for triage');
    }
    else {
      $("#submit").text('Send for triage');
    }
    $("#status").val('Untriaged');
  }
  else if (issueStatus === 'Untriaged') {
    if (resolution) {
      $("#submit").text('Resolve');
      $("#status").val('Resolved');
    }
    else {
      $("#submit").text('Open');
      $("#status").val('Open');
    }
  }
  else if (issueStatus === 'Open') {
    if (resolution && resolution != issueResolution) {
      $("#submit").text('Resolve');
      $("#status").val('Resolved');
    }
    else {
      $("#submit").text('Save');
      $("#status").val('Open');
    }
  }
  else {
    if (!resolution) {
      $("#submit").text('Open');
      $("#status").val('Open');
    }
    else if (resolution != issueResolution) {
      $("#submit").text('Resolve');
      $("#status").val('Resolved');
    }
    else {
      $("#submit").text('Save');
      $("#status").val(issueStatus);
    }
  }

  if (triage) {
    $(submit).removeClass(primaryButtonClass).addClass('btn-warning');
  }
  else {
    $(submit).removeClass('btn-warning').addClass(primaryButtonClass);
  }
}

$(function () {
    // support for dirty checking.
    window.onbeforeunload = function (e) {
      if (dirty) {
        e = e || window.event;
        if (e) {
          e.returnValue = dirtyMessage; // IE and Firefox
        }

        return dirtyMessage; // Webkit
      }
    };

    // support for typeaheads with data-urls
    $('.typeahead[data-url]').typeahead({
        source: function (query, process) {
            var url = $(this.$element).attr('data-url');
            return $.get(url, { q: query }, function (data) {
                return process(data);
            });
        },
    });

    // support for closing alerts cleanly.
    $(".alert").find(".close").on("click", function (e) {
        e.stopPropagation();
        e.preventDefault();
        $(this).closest(".alert").slideUp();
    });

    // support for modal login form.
    $('.login.modal').submit(function (e) {
        var dlg = $(this);
        var form = dlg.find('form');
        var submit = dlg.find(':submit').button('loading');
        var alert = dlg.find('.alert').slideUp('fast');

        e.preventDefault();
        $.post(form.attr('action'), form.serialize())
            .done(function () {
                dlg.modal('hide');
            }).fail(function (jqXHR, textStatus, errorThrown) {
                alert.slideDown();
            }).always(function () {
                submit.button('reset');
            });
    });

    $('.login.modal').on('hide', function () {
        $(this).find('.alert').hide();
    });
});
