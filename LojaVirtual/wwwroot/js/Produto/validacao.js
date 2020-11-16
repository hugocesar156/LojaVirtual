//Validações de campos
function ValidaAltura() {
    if ($('#altura').val() < 2 || $('#altura').val() > 105) {
        $('#altura').removeClass('is-valid');
        $('#altura').addClass('is-invalid');

        $('.msg-altura').html("A altura deve ser entre 2cm e 105cm.");
    }
    else {
        ValidaCampo($('#altura'));
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
}

function ValidaComprimento() {
    if ($('#comprimento').val() < 16 || $('#comprimento').val() > 105) {
        $('#comprimento').removeClass('is-valid');
        $('#comprimento').addClass('is-invalid');

        $('.msg-comprimento').html("O comprimento deve ser entre 16cm e 105cm.");
    }
    else {
        ValidaCampo($('#comprimento'));
    }
}

function ValidaLargura() {
    if ($('#largura').val() < 11 || $('#largura').val() > 105) {
        $('#largura').removeClass('is-valid');
        $('#largura').addClass('is-invalid');

        $('.msg-largura').html("A largura deve ser entre 11cm e 105cm.");
    }
    else {
        ValidaCampo($('#largura'));
    }
}

function ValidaPeso() {
    if ($('#peso').val() == 0 || $('#peso').val() > 30) {
        $('#peso').removeClass('is-valid');
        $('#peso').addClass('is-invalid');

        $('.msg-peso').html("O peso não pode ser 0 e deve ser até 30Kg.");
    }
    else {
        ValidaCampo($('#peso'));
    }
}

function ValidaValor(campo) {
    if ($(campo).val() == 0) {
        $(campo).removeClass('is-valid');
        $(campo).addClass('is-invalid');

        $('.msg-valor').html("O valor não pode ser 0.");
    }
    else {
        ValidaCampo(campo);
    }
}

//Validação para edição
function ValidaEdicao() {
    $('.form-control').each(function () {
        ValidaCampo(this);
    });

    ValidaAltura();
    ValidaComprimento();
    ValidaLargura();
    ValidaPeso();
    ValidaValor($('#estoque'));
    ValidaValor($('#valor'));

    ValidaRegistro(2);
}

//Validação de cadastro e edição
function ValidaRegistro(acao) {
    if ($('.form-control').length == $('.is-valid').length) {
        let produto = {
            nome: $('#nome').val().toUpperCase(),
            idCategoria: $('#categoria').val(),
            descricao: $('#descricao').val().toUpperCase(),
            valor: $('#valor').val(),
            estoque: $('#estoque').val(),
            fabricante: $('#fabricante').val().toUpperCase(),
            modelo: $('#modelo').val().toUpperCase(),
            cor: $('#cor').val().toUpperCase(),
            peso: $('#peso').val(),
            largura: $('#largura').val(),
            altura: $('#altura').val(),
            comprimento: $('#comprimento').val()
        }

        let action = "Registrar";

        if (acao == 2) {
            action = "Atualizar";
        }

        $.ajax({
            type: "POST",
            url: "/Produto/" + action,
            data: { produto: produto },
            success: function (resultado) {
                if (resultado) {
                    window.location.pathname = "Produto/Lista";
                }
                else {
                    alert("Falha no envio de dados.");
                }
            },
            error: function () {
                alert("Falha no envio de dados.");
            }
        });
    }
}