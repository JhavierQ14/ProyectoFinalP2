// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).on('submit', '#LogIn', function (e) {
    e.preventDefault();
    $.ajax({

        beforeSend: function () {
            $('#Registrar button[type=submit]').prop('disabled', true);
        },

        type: this.method,
        url: this.action,
        data: $(this).serialize(),
        success: function (data) {
            alert('Bienvenido' + data.nombreU);
        },

        error: function (xhr, status) {
            alert(xhr.responseJSON.Message);
        },

        complete: function () {
            $('#Registrar button[type=submit]').prop('disabled', false);
        }
    });
});