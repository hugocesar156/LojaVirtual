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
                if (validacao) {
                    window.location.pathname = "Home/Inicio";
                }
                else {
                    alert("Dados de acesso não conferem.");
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