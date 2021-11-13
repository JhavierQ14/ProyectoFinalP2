const sign_in_btn = document.querySelector("#sign-in-btn");
const sign_up_btn = document.querySelector("#sign-up-btn");
const container = document.querySelector(".container");

sign_up_btn.addEventListener("click", () => {
  container.classList.add("sign-up-mode");
});

sign_in_btn.addEventListener("click", () => {
  container.classList.remove("sign-up-mode");
});


$(document).on('submit', '#Succes', function (e) {
    e.preventDefault();
    $.ajax({
        beforeSend: function () {
            $('#Succes button[type=submit]').prop('disabled', true);
        },
        type: 'POST',
        url: '/Authentication/Succes/',
        data: $(this.#Succes).serialize(),
        success: function (data) {
            alert('Usuario registrado con éxito.');
        },
        error: function (xhr, status) {
            alert(xhr.responseJSON.Message);
        },
        complete: function () {
            $('#Succes button[type=submit]').prop('disabled', false);
        }
    });
});

$(document).on('submit', '#Log', function (e) {
    e.preventDefault();
    $.ajax({

        beforeSend: function () {
            $('#Log button[type=submit]').prop('disabled', true);
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
            $('#Log button[type=submit]').prop('disabled', false);
        }
    });
});