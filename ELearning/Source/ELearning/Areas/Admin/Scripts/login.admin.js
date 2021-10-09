
function login() {
    toastr.options.progressBar = true;
    toastr.success('Loading...', { timeOut: 5000 })
    $.ajax({
        type: 'POST',
        url: '/admin/login/checkLogin',
        dataType: 'json',
        data: { userName: $('#Username').val(), passWord: $('#Password').val() },
        success: function (response) {
            toastr.clear()
            if (response.status) {
                toastr.success(response.mess);
                var rtUrl = $('#rtUrl').val();
                if (rtUrl == "") {
                    rtUrl = "/Admin";
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
});