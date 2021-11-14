const sign_in_btn = document.querySelector("#sign-in-btn");
const sign_up_btn = document.querySelector("#sign-up-btn");
const container = document.querySelector(".container");

sign_up_btn.addEventListener("click", () => {
  container.classList.add("sign-up-mode");
});

sign_in_btn.addEventListener("click", () => {
  container.classList.remove("sign-up-mode");
});

$(document).ready(function () {
    $("#Log").validate({
        rules: {
            correoU: {
                required: true,
                email: true
            },
            contraU: {
                required: true,               
            },
            
        },
        messages: {
            correoU: {
                required: "Ingrese su correo",
                email: "Debe ingresar un correo"
            },
            contraU: {
                required: "Ingrese su password",
            }
        }
    });
});

