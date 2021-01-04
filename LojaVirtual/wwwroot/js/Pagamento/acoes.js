function PagamentoCartao() {
    if (ValidaFormCartao()) {
        $('#btn-cartao').attr('disabled', true);

        let cartao = {
            nome: $('#nome').val(),
            numero: $('#numero').val().replace(" ", "").replace(" ", "").replace(" ", ""),
            vencimento: $('#vencimento').val(),
            verificador: $('#verificador').val()
        };

        let cep = $('#cep-salvo').val().replace("-", "");
        let servico = "";

        if ($('#sedex-input').prop('checked')) {
            servico = "04014";
        }
        else {
            servico = "04510";
        }

        let endereco = {};

        $.ajax({
            type: "GET",
            url: "https://viacep.com.br/ws/" + cep + "/json",
            dataType: "jsonp",
            success: function (enderecoJson) {
                if (enderecoJson.cep != undefined) {
                    endereco.cep = enderecoJson.cep.replace("-", "");
                    endereco.logradouro = enderecoJson.logradouro;
                    endereco.bairro = enderecoJson.bairro;
                    endereco.cidade = enderecoJson.localidade;
                    endereco.complemento = enderecoJson.complemento;
                    endereco.uf = enderecoJson.uf;
                    endereco.ibge = enderecoJson.ibge;

                    endereco.nome = $('#nome-endereco-salvo').val();
                    endereco.numero = $('#numero-salvo').val();

                    let frete = {};

                    $.ajax({
                        type: "GET",
                        url: "/Carrinho/CalcularFrete",
                        data: { cep: cep, servico: servico },
                        success: function (data) {
                            frete.valor = data.valor.toFixed(2).replace(".", ",");
                            frete.prazo = data.prazo;

                            if (servico == "04014") {
                                frete.servico = '1';
                            }
                            else {
                                frete.servico = '2';
                            }

                            let parcelas = $('#parcelas').val();

                            $.ajax({
                                type: "POST",
                                url: "/Pagamento/PagamentoCartao",
                                data: { cartao: cartao, endereco: endereco, frete: frete, parcelas: parcelas },
                                success: function (transacao) {
                                    window.location.pathname = "Pedido/Detalhe/" + transacao;
                                },
                                error: function (erro) {
                                    $('#btn-cartao').attr('disabled', false);
                                    alert(erro.resposeText);
                                }
                            });
                        }
                    });
                }
            }
        });
    }
}

function PagamentoBoleto() {
    $('#btn-boleto').attr('disabled', true);

    let cep = $('#cep-salvo').val().replace("-", "");
    let servico = "";

    if ($('#sedex-input').prop('checked')) {
        servico = "04014";
    }
    else {
        servico = "04510";
    }

    let endereco = {};

    $.ajax({
        type: "GET",
        url: "https://viacep.com.br/ws/" + cep + "/json",
        dataType: "jsonp",
        success: function (enderecoJson) {
            if (enderecoJson.cep != undefined) {
                endereco.cep = enderecoJson.cep.replace("-", "");
                endereco.logradouro = enderecoJson.logradouro;
                endereco.bairro = enderecoJson.bairro;
                endereco.cidade = enderecoJson.localidade;
                endereco.complemento = enderecoJson.complemento;
                endereco.uf = enderecoJson.uf;
                endereco.ibge = enderecoJson.ibge;

                endereco.nome = $('#nome-endereco-salvo').val();
                endereco.numero = $('#numero-salvo').val();

                let frete = {};

                $.ajax({
                    type: "GET",
                    url: "/Carrinho/CalcularFrete",
                    data: { cep: cep, servico: servico },
                    success: function (data) {
                        frete.valor = data.valor.toFixed(2).replace(".", ",");
                        frete.prazo = data.prazo;

                        if (servico == "04014") {
                            frete.servico = '1';
                        }
                        else {
                            frete.servico = '2';
                        }

                        $.ajax({
                            type: "POST",
                            url: "/Pagamento/PagamentoBoleto",
                            data: { endereco: endereco, frete: frete },
                            success: function (transacao) {
                                window.location.pathname = "Pedido/Detalhe/" + transacao;
                            },
                            error: function (erro) {
                                $('#btn-boleto').attr('disabled', false);
                                alert(erro.responseText);
                            }
                        });
                    }
                });
            }
        }
    });
}

//Validações de campos
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

function ValidaCartao() {
    let numero = $('#numero');

    if (numero.val().length == 19) {
        numero.removeClass('is-invalid');
        numero.addClass('is-valid');
    }
    else {
        numero.removeClass('is-valid');
        numero.addClass('is-invalid');
    }
}

function ValidaData() {
    let vencimento = $('#vencimento');

    var data = new Date();
    let mesAno = vencimento.val().split("/");
    let mes = parseInt(mesAno[0]);
    let ano = parseInt(mesAno[1]);

    if (ano >= data.getFullYear() - 2000 && (mes > 0 && mes < 13)) {
        if (ano > data.getFullYear() - 2000) {
            vencimento.removeClass('is-invalid');
            vencimento.addClass('is-valid');
        }
        else if (mes > data.getMonth() + 1) {
            vencimento.removeClass('is-invalid');
            vencimento.addClass('is-valid');
        }
        else {
            vencimento.removeClass('is-valid');
            vencimento.addClass('is-invalid');
        }
    }
    else {
        vencimento.removeClass('is-valid');
        vencimento.addClass('is-invalid');
    }
}

function ValidaFormCartao() {
    let validos = 0;

    $('.form-cartao').each(function () {
        if ($(this).hasClass('is-valid'))
            validos++;
    });

    return validos == $('.form-cartao').length;
};

function ValidaNome() {
    let nome = $('#nome');

    if (nome.val().length >= 15) {
        nome.removeClass('is-invalid');
        nome.addClass('is-valid');
    }
    else {
        nome.removeClass('is-valid');
        nome.addClass('is-invalid');
    }
}

function ValidaVerificador() {
    let verificador = $('#verificador');

    if (verificador.val().length == 3) {
        verificador.removeClass('is-invalid');
        verificador.addClass('is-valid');
    }
    else {
        verificador.removeClass('is-valid');
        verificador.addClass('is-invalid');
    }
}