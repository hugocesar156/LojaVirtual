﻿//Validações de campo
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

    if (valor.length != 11 ||
        valor == "00000000000" || valor == "11111111111" ||
        valor == "22222222222" || valor == "33333333333" ||
        valor == "44444444444" || valor == "55555555555" ||
        valor == "66666666666" || valor == "77777777777" ||
        valor == "88888888888" || valor == "99999999999") return false;

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

function ValidaSenha(senha) {
    if (senha.val().length < 6) {
        senha.removeClass('is-valid');
        senha.addClass('is-invalid');

        $('.msg-senha').html("A senha deve conter no mínimo 6 caracteres.");
    }

    if ($('#confirma').val() != "") {
        ConfirmaSenha($('#confirma'));
    }
}

//Validações de cadastro
function ValidaUsuario(acao = 1) {
    if (ValidaFormulario(1)) {
        let usuario = CarregaUsuario();
        let token = $('input[name="__RequestVerificationToken"]').val();

        $.ajax({
            type: "POST",
            url: "/Usuario/ValidaUsuario",
            data: { __RequestVerificationToken: token, usuario: usuario, acao: acao },
            success: function () {
                $('#form-cliente').addClass('d-none');
                $('#form-endereco').removeClass('d-none');
            },
            error: function (erro) {
                alert(erro.responseText);
            }
        });
    }
}

function RegistraUsuario(acao = 1) {
    if (ValidaFormulario(2) && ValidaFormulario(3)) {
        let usuario = CarregaUsuario();
        usuario.cliente.email = usuario.email;

        let token = $('input[name="__RequestVerificationToken"]').val();
        let url = acao == 1 ? "/Usuario/Registrar" : "/Usuario/Atualizar";

        $.ajax({
            type: "POST",
            url: url,
            data: { __RequestVerificationToken: token, usuario: usuario },
            success: function () {
                window.location.pathname = acao == 1 ? "Login/Entrar" : "Home/Inicio";
            },
            error: function (erro) {
                alert(erro.responseText);
            }
        });
    }
}

//Operações
function CarregaUsuario() {
    return {
        email: $('#email').val(),
        senha: $('#senha').val(),
        perfil: '2',

        cliente: {
            nome: $('#nome').val(),
            cpf: $('#cpf').val().replace(".", "").replace(".", "").replace("-", ""),
            nascimento: $('#nascimento').val(),

            endereco: {
                cep: $('#cep').val().replace("-", ""),
                logradouro: $('#logradouro').val().toUpperCase(),
                numero: $('#numero').val(),
                bairro: $('#bairro').val().toUpperCase(),
                cidade: $('#cidade').val().toUpperCase(),
                uf: $('#uf').val().toUpperCase(),
                nome: $('#nome-endereco').val().toUpperCase(),
                complemento: $('#complemento').val().toUpperCase()
            },

            contato: [{
                nome: $('#nome-contato').val().toUpperCase(),
                numero: $('#numero-contato').val().replace(" ", "").replace("-", "").replace("(", "").replace(")", "")
            }]
        }
    }
}

function ValidaFormulario(form) {
    let validos = 0;

    if (form == 1) {
        $('.form-cliente').each(function () {
            if ($(this).hasClass('is-valid'))
                validos++;
        });

        return validos == $('.form-cliente').length;
    }
    else if (form == 2) {
        $('.form-endereco').each(function () {
            if ($(this).hasClass('is-valid'))
                validos++;
        });

        return validos == $('.form-endereco').length;
    }

    $('.form-contato').each(function () {
        if ($(this).hasClass('is-valid'))
            validos++;
    });

    return validos == $('.form-contato').length;
}

function Voltar(limparForm = false) {
    if (limparForm) {
        $('.form-endereco').each(function () {
            $(this).val("");
            $(this).removeClass('is-valid');
            $(this).removeClass('is-invalid');
        });

        $('.form-contato').each(function () {
            $(this).val("");
            $(this).removeClass('is-valid');
            $(this).removeClass('is-invalid');
        });
    }
    
    $('#form-endereco').addClass('d-none');
    $('#form-cliente').removeClass('d-none');
}