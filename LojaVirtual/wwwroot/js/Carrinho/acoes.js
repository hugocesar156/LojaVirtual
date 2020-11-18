function AdicionarQuantidade(idProduto) {
    $.ajax({
        type: "GET",
        url: "/Carrinho/AdicionarQuantidade/" + idProduto,
        success: function (lista) {
            $("#lista").html(lista);

            if ($('.cep').val().length > 0) {
                CalcularFrete();
            }
        },
        error: function () {
            alert("Erro ao tentar atualizar carrinho.");
        }
    });
}

function CalcularFrete() {
    $('#btn-frete').attr('disabled', true);
    $('#div-frete').addClass('d-none');

    $('#load').removeClass('d-none');
    $('#load-gif').attr('src', '/images/load.gif');

    let cep = $('.cep').val().replace("-", "");

    $.ajax({
        type: "GET",
        url: "/Carrinho/CalcularFrete",
        data: { cep: cep },
        success: function (frete) {
            $('#sedex').html(frete.valorSedex.toFixed(2).replace(".", ","));
            $('#pac').html(frete.valorPac.toFixed(2).replace(".", ","));

            $('#btn-frete').attr('disabled', false);
            $('#div-frete').removeClass('d-none');

            $('#load').addClass('d-none');
            $('#load-gif').attr('src', '');

            CalculaValores();

            if ($('#sedex-input').prop('checked')) {
                SelecionaFrete($('#sedex'))
            }

            if ($('#pac-input').prop('checked')) {
                SelecionaFrete($('#pac'))
            }
        },
        error: function () {
            alert("Erro ao tentar calcular o frete.");

            $('#btn-frete').attr('disabled', false);

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
}

function RemoverItem(idProduto) {
    $.ajax({
        type: "GET",
        url: "/Carrinho/RemoverItem/" + idProduto,
        success: function (lista) {
            $("#lista").html(lista);

            if ($('.cep').val().length > 0) {
                CalcularFrete();
            }
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

            if ($('.cep').val().length > 0) {
                CalcularFrete();
            }
        },
        error: function () {
            alert("Erro ao tentar atualizar carrinho.");
        }
    });
}

function SelecionaFrete(tipo) {
    let frete = tipo.html().replace(",", ".");

    let total = parseFloat($('#subtotal').html().replace(".", "").replace(",", "."));
    total += parseFloat(frete);

    $('#frete').html(frete.replace(".", ","));
    $('#total').html(total.toFixed(2).replace(".", ","));

    $('#valorFrete').val(frete);

    if (tipo.html() == $('#sedex').html()) {
        $('#tipoFrete').val("1");
    }
    else {
        $('#tipoFrete').val("2");
    }
}