function ConfirmaSenha(conf) {
    if ($('#senha').hasClass('is-valid')) {
        if (conf.val() == $('#senha').val()) {
            conf.removeClass('is-invalid');
            conf.addClass('is-valid');
        }
        else {
            conf.removeClass('is-valid');
            conf.addClass('is-invalid');

            $('.msg-conf').html("Falha ao confirmar senha.");
        }
    }
    else {
        conf.removeClass('is-valid');
        conf.removeClass('is-invalid');

        conf.val("");
    }
}

function ValidaCampo(campo) {
    if ($(campo).val() == "") {
        $(campo).removeClass('is-valid');
        $(campo).addClass('is-invalid');
    }
    else {
        $(campo).removeClass('is-invalid');
        $(campo).addClass('is-valid');
    }
    
    if ($(campo).hasClass('cpf')) {
        if (!ValidaCpf($(campo))) {
            $(campo).removeClass('is-valid');
            $(campo).addClass('is-invalid');
        }
    }

    if ($(campo).hasClass('senha')) {
        ValidaSenha($(campo));
    }

    if ($(campo).hasClass('conf')) {
        ConfirmaSenha($(campo));
    }
}

function ValidaCpf(cpf) {
    let valor = cpf.val().replace(".", "").replace(".", "").replace("-", "");
    let soma = 0;

    if (
        valor.length != 11 ||
        valor == "00000000000" ||
        valor == "11111111111" ||
        valor == "22222222222" ||
        valor == "33333333333" ||
        valor == "44444444444" ||
        valor == "55555555555" ||
        valor == "66666666666" ||
        valor == "77777777777" ||
        valor == "88888888888" ||
        valor == "99999999999"
    ) return false;

    for (i = 1; i <= 9; i++) soma += parseInt(valor.substring(i - 1, i)) * (11 - i);
    let resto = (soma * 10) % 11;

    if ((resto == 10) || (resto == 11)) resto = 0;
    if (resto != parseInt(valor.substring(9, 10))) return false;

    soma = 0;
    for (i = 1; i <= 10; i++) soma += parseInt(valor.substring(i - 1, i)) * (12 - i);
    resto = (soma * 10) % 11;

    if ((resto == 10) || (resto == 11)) resto = 0;
    if (resto != parseInt(valor.substring(10, 11))) return false;

    return true;
}

function ValidaRegistro() {
    if ($('.form-control').length == $('.is-valid').length) {
        let usuario = {
            email: $('#email').val(),
            senha: $('#senha').val(),

            cliente: {
                nome: $('#nome').val(),
                cpf: $('#cpf').val().replace(".", "").replace(".", "").replace("-", "")
            }
        }

        $.ajax({
            type: "POST",
            url: "/Usuario/Registrar",
            data: { usuario: usuario },
            success: function (resultado) {
                if (resultado) {
                    window.location.pathname = "Home/Inicio";
                }
                else {
                    alert("Falha na tentativa de cadastro.");
                }
            },
            error: function () {
                alert("Falha na tentativa de cadastro.");
            }
        });
    }
}

function ValidaSenha(senha) {
    if (senha.val() == "") {
        $('.msg-senha').html("Preencha este campo.");
    }
    else if (senha.val().length < 6) {
        senha.removeClass('is-valid');
        senha.addClass('is-invalid');

        $('.msg-senha').html("A senha deve conter no mínimo 6 caracteres.");
    }

    if ($('#confirma').val() != "") {
        ConfirmaSenha($('#confirma'));
    }
}
