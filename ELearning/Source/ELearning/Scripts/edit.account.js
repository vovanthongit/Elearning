$(document).ready(function () {
    $('#frmEdit').submit(function (e) {
        e.preventDefault();

        var formData = new FormData(this);
        $.ajax({
            url: '/account/update',
            type: 'POST',
            data: formData,
            success: function (response) {
                if (response.status) {
                    toastr.success(response.mess); 
                    setTimeout(function () {
                        window.location.href = '/account';
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

    $('#updatePass').submit(function (e) {
        e.preventDefault(); 
        var formData = new FormData(this);
        $.ajax({
            url: '/account/updatepass',
            type: 'POST',
            data: formData,
            success: function (response) {
                if (response.status) {
                    toastr.success(response.mess); 
                    setTimeout(function () {
                        window.location.href = '/account';
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