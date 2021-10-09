function login() {
    toastr.options.progressBar = true;
    toastr.success('Loading...', { timeOut: 5000 });
    $.ajax({
        type: 'POST',
        url: '/account/checkLogin',
        dataType: 'json',
        data: { userName: $('#Username').val(), passWord: $('#Password').val() },
        success: function (response) {
            toastr.clear()
            if (response.status) {
                toastr.success(response.mess);
                var rtUrl = $('#rtUrl').val();
                if (rtUrl == "") {
                    rtUrl = "/";
                }
                setTimeout(function () {
                    window.location.href = rtUrl;
                }, 3000);
            } else {
                toastr.error(response.mess);
            }
        },
        error: function (jqXHR) {
            toastr.error(jqXHR.responseText);
        }
    });
};
$(document).ready(function () {
    $('input').keypress(function (e) {
        if (e.which == 13) {
            e.preventDefault();
            login();
            return false;
        }
    });
    $('#btnLogin').click(function (e) {
        e.preventDefault();
        login();
    });

    $('#frmLogin').submit(function (e) {
        e.preventDefault();
    });

    $('#frmReg').submit(function (e) {
        e.preventDefault();

        var formData = new FormData(this);
        $.ajax({
            url: '/account/register',
            type: 'POST',
            data: formData,
            success: function (response) {
                if (response.status) {
                    toastr.success(response.mess);
                    var rtUrl = $('#rtUrl').val();
                    if (rtUrl == "") {
                        rtUrl = "/";
                    }
                    setTimeout(function () {
                        window.location.href = rtUrl;
                    }, 3000);
                } else {
                    toastr.error(response.mess);
                }
            },
            cache: false,
            contentType: false,
            processData: false
        });
    });
});