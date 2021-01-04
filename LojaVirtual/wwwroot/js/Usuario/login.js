function ValidaAcesso() {
    ValidaCampoEmail();
    ValidaCampoSenha();

    if ($('.is-invalid').length == 0) {
        let usuario = {
            email: $('#email').val(),
            senha: $('#senha').val()
        }

        $.ajax({
            type: "POST",
            url: "/Login/ValidaAcesso",
            data: { usuario: usuario },
            success: function () {
                window.location.pathname = "Home/Inicio";
            },
            error: function (erro) {
                alert(erro.responseText);
            }
        });
    }
}

function ValidaCampoEmail() {
    let email = $('#email');

    if (email.val() == "") {
        email.addClass('is-invalid');
    }
    else {
        email.removeClass('is-invalid');
    }
}

function ValidaCampoSenha() {
    let senha = $('#senha');

    if (senha.val() == "") {
        senha.addClass('is-invalid');
    }
    else {
        senha.removeClass('is-invalid');
    }
}