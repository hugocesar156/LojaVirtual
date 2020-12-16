$(document).ready(function () {
    ValidaCep();
})

function AdicionarQuantidade(idProduto) {
    $.ajax({
        type: "GET",
        url: "/Carrinho/AdicionarQuantidade/" + idProduto,
        success: function (lista) {
            $("#lista").html(lista);

            CalcularFrete($('#cep').val().replace("-", ""));
        },
        error: function () {
            alert("Erro ao tentar atualizar carrinho.");
        }
    });
}

function ValidaCep() {
    let cep = $('#cep-salvo').val().replace("-", "");

    $.ajax({
        type: "GET",
        url: "https://viacep.com.br/ws/"+ cep +"/json",
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

            let data = frete.prazo.split("T");
            let prazo = data[0].split("-");
            $('#prazo').html(`Prazo de entrega: ${prazo[2]}/${prazo[1]}/${prazo[0]}`);

            CalculaValores();

            $('#calculo-frete').modal('hide');
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

            CalcularFrete($('#cep').val().replace("-", ""));
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

            CalcularFrete($('#cep').val().replace("-", ""));
        },
        error: function () {
            alert("Erro ao tentar atualizar carrinho.");
        }
    });
}

$('.form-endereco').change(function () {
    if ($('.form-endereco').length == $('.is-valid').length) {
        $('#cep-salvo').val($('#cep').val().replace("-", ""));
        $('#btn-endereco').attr('disabled', false);
    }
    else {
        $('#btn-endereco').attr('disabled', true);
    }
})