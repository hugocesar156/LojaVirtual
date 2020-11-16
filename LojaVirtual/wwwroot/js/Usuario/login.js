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
            success: function (validacao) {
                if (validacao == 0) {
                    window.location.pathname = "Home/Inicio";
                }
                else {
                    if (validacao == 1) {
                        $('#email').addClass('is-invalid');
                        $('.msg-email').html("Email inválido");

                        $('#senha').removeClass('is-invalid');
                    }

                    if (validacao == 2) {
                        $('#senha').addClass('is-invalid');
                        $('.msg-senha').html("Senha incorreta");
                    }
                }
            },
            error: function () {
                alert("Erro na tentativa de acesso.");
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