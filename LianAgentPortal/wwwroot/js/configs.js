
/// NProgress setting
NProgress.configure({
    minimum: 1
});

/// toastr setting
toastr.options = {
    "progressBar": true,
    "positionClass": "toast-bottom-left",
}

/// ajax setting
$.ajaxSetup({
    error: function (xhr, status, error) {
        if (xhr && xhr.responseJSON) {
            if (xhr.responseJSON) {
                $.each(xhr.responseJSON, function (key, value) {
                    toastr.error(xhr.responseJSON[key]);
                });
            }
            else {
                toastr.error(xhr.responseJSON.ExceptionMessage, xhr.responseJSON.ExceptionType);
            }
        } else {
            toastr.error(error, status);
        }
    },
    success: function (result, status, xhr) { },
    beforeSend: function (xhr) { },
    complete: function (xhr, status) { }
});

$(document).ajaxStart(function () {
    NProgress.start();
});

$(document).ajaxStop(function () {
    NProgress.done();
    //NProgress.remove();
});