function AdicionarQuantidade(idProduto) {
    $.ajax({
        type: "GET",
        url: "/Carrinho/AdicionarQuantidade/" + idProduto,
        success: function (lista) {
            $("#lista").html(lista);

            CalculaValores();
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
            $('#sedex').html(frete.valorSedex.toLocaleString('pt-br', { style: 'currency', currency: 'BRL' }));
            $('#pac').html(frete.valorPac.toLocaleString('pt-br', { style: 'currency', currency: 'BRL' }));

            $('#btn-frete').attr('disabled', false);
            $('#div-frete').removeClass('d-none');

            $('#load').addClass('d-none');
            $('#load-gif').attr('src', '');
        },
        error: function () {
            alert("Erro ao tentar calcular o frete.");

            $('#btn-frete').attr('disabled', false);

            $('#load').addClass('d-none');
            $('#load-gif').attr('src', '');
        }
    });
}

function RetirarQuantidade(idProduto) {
    $.ajax({
        type: "GET",
        url: "/Carrinho/RetirarQuantidade/" + idProduto,
        success: function (lista) {
            $("#lista").html(lista);

            CalculaValores();
        },
        error: function () {
            alert("Erro ao tentar atualizar carrinho.");
        }
    });
}

function RemoverItem(idProduto) {
    $.ajax({
        type: "GET",
        url: "/Carrinho/RemoverItem/" + idProduto,
        success: function (lista) {
            $("#lista").html(lista);

            CalculaValores();
        },
        error: function () {
            alert("Erro ao tentar atualizar carrinho.");
        }
    });
}

function SelecionaFrete(tipo) {
    let frete = tipo.html().replace("R$ ", "").replace(",", ".");

    let total = parseFloat($('#total').html().replace("R$&nbsp;", "").replace("R$", "").replace(".", "").replace(",", "."));
    total += parseFloat(frete.replace("R$&nbsp;", ""));

    $('#frete').html(frete.toLocaleString('pt-br', { style: 'currency', currency: 'BRL' }).replace(".", ","));
    $('#total').html(total.toLocaleString('pt-br', { style: 'currency', currency: 'BRL' }));
}

function CalculaValores() {
    let subtotal = 0;

    $('.price').each(function () {
        subtotal += parseFloat(
            this.innerHTML.replace(".", "").replace(",", ".")) *
            parseInt($(this).siblings('#quantidade').val());
    });

    let frete = parseFloat($('#frete').html().replace(".", "").replace(",", "."));

    $('#subtotal').html(subtotal.toFixed(2));
    $('#total').html(subtotal + frete).toFixed(2);
}