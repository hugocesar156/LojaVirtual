$(document).ready(function () {
    ValidaCep();
})

function AdicionarQuantidade(idProduto) {
    $.ajax({
        type: "GET",
        url: "/Carrinho/AdicionarQuantidade/" + idProduto,
        success: function (lista) {
            $("#lista").html(lista);

            CalcularFrete($('#cep-salvo').val().replace("-", ""));
        },
        error: function () {
            alert("Erro ao tentar atualizar carrinho.");
        }
    });
}

function CalculaParcelas() {
    let valor = $('#subtotal').html();
    let frete = $('#frete').html();

    $.ajax({
        type: "POST",
        url: "/Pagamento/CalculaParcelas",
        data: { valor: valor, frete: frete },
        success: function (data) {
            let campos = "";

            campos += `<option value="1">Pagamento à vista: R$ ${data[1][0]}`;

            for (let i = 2; i <= 12; i++) {
                campos += `<option value="${i}">${i}x de R$ ${data[0][i - 1]} | Total: R$ ${data[1][i - 1]}</option>`;
            }

            $('#parcelas').html(campos);
        },
        error: function (erro) {
            alert(erro.responseText);
        }
    });
}

function CalcularFrete(cep) {
    $('#load-frete').removeClass('d-none');
    $('#load-gif-frete').attr('src', '/images/load.gif');

    $('#continuar').attr('disabled', true);

    $('#btn-frete').attr('disabled', true);
    $('#div-frete').addClass('d-none');

    $('#seleciona-endereco').attr('disabled', true);
    $('#retira-endereco').attr('disabled', true);

    $('#load').removeClass('d-none');
    $('#load-gif').attr('src', '/images/load.gif');

    let servico = "";

    if ($('#sedex-input').prop('checked')) {
        servico = "04014";
    }
    else {
        servico = "04510";
    }

    $.ajax({
        type: "GET",
        url: "/Carrinho/CalcularFrete",
        data: { cep: cep, servico: servico },
        success: function (frete) {
            $('#btn-frete').attr('disabled', false);

            $('#seleciona-endereco').attr('disabled', false);
            $('#retira-endereco').attr('disabled', false);

            $('#load').addClass('d-none');
            $('#load-gif').attr('src', '');

            $('#frete').html(frete.valor.toFixed(2).replace(".", ","));
            $('#prazo').html(`Prazo de entrega: ${frete.diasEntrega} dia(s) após aprovação do pagamento`);

            CalculaParcelas();
            CalculaValores();

            $('#total-boleto').html("R$ " + $('#total').html());
        },
        error: function () {
            alert("Erro ao tentar calcular o frete.");

            $('#btn-frete').attr('disabled', false);

            $('#seleciona-endereco').attr('disabled', false);
            $('#retira-endereco').attr('disabled', false);

            $('#load').addClass('d-none');
            $('#load-gif').attr('src', '');
        }
    });
}

function CalculaValores() {
    let subtotal = 0;

    $('.price').each(function () {
        subtotal += parseFloat(
            this.innerHTML.replace(".", "").replace(",", ".")) *
            parseInt($(this).siblings('#quantidade').val());
    });

    let frete = parseFloat($('#frete').html().replace(".", "").replace(",", "."));

    $('#subtotal').html(subtotal.toFixed(2).replace(".", ","));
    $('#total').html((subtotal + frete).toFixed(2).replace(".", ","));

    $('#load-frete').addClass('d-none');
    $('#load-gif-frete').attr('src', '');

    $('#continuar').attr('disabled', false);
}

function RemoverItem(idProduto) {
    $.ajax({
        type: "GET",
        url: "/Carrinho/RemoverItem/" + idProduto,
        success: function (lista) {
            $("#lista").html(lista);

            CalcularFrete($('#cep-salvo').val().replace("-", ""));
        },
        error: function () {
            alert("Erro ao tentar atualizar carrinho.");
        }
    });
}

function RetirarQuantidade(idProduto) {
    $.ajax({
        type: "GET",
        url: "/Carrinho/RetirarQuantidade/" + idProduto,
        success: function (lista) {
            $("#lista").html(lista);

            CalcularFrete($('#cep-salvo').val().replace("-", ""));
        },
        error: function () {
            alert("Erro ao tentar atualizar carrinho.");
        }
    });
}

function SalvaEndereco() {
    ValidaCampoEndereco();

    if ($('#cep').hasClass('is-valid') && $('.form-endereco').length == $('.is-valid').length) {
        $('.form-endereco').each(function () {
            $(this).removeClass('is-valid');
        })

        $('#cep-salvo').val($('#cep').val());
        $('#numero-salvo').val($('#numero-endereco').val());
        $('#nome-endereco-salvo').val($('#nome-endereco').val());
        $('#modal-endereco').modal('hide');

        ValidaCep();
    }
}

function ValidaCampoEndereco(campo) {
    if (campo == undefined) {
        $('.form-endereco').each(function () {
            if ($(this).val() == "" && !$(this).hasClass('campo-nulo')) {
                $(this).removeClass('is-valid');
                $(this).addClass('is-invalid');
            }
            else {
                $(this).removeClass('is-invalid');
                $(this).addClass('is-valid');
            }
        });
    }
    else {
        if ($(campo).val() == "" && !$(campo).hasClass('campo-nulo')) {
            $(campo).removeClass('is-valid');
            $(campo).addClass('is-invalid');
        }
        else {
            $(campo).removeClass('is-invalid');
            $(campo).addClass('is-valid');
        }
    }
}

function ValidaCep() {
    let cep = $('#cep-salvo').val().replace("-", "");

    $.ajax({
        type: "GET",
        url: "https://viacep.com.br/ws/" + cep + "/json",
        dataType: "jsonp",
        success: function (endereco) {
            if (endereco.cep != undefined) {
                $('#exibe-endereco').html(`<strong>Endereço salvo atual:</strong> 
                    ${endereco.cep} | ${endereco.logradouro}, ${endereco.bairro} - ${endereco.localidade}`
                );

                CalcularFrete(cep);
            }
            else {
                $('#load-frete').addClass('d-none');
                $('#load-gif-frete').attr('src', '');
            }
        },
        error: function () {
            alert("Erro ao tentar buscar endereço");

            $('#load-frete').addClass('d-none');
            $('#load-gif-frete').attr('src', '');

            $('#continuar').attr('disabled', false);
        }
    });
}