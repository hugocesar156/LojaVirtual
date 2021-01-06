$('.card').mouseover(function () {
    $(this).css('cursor', 'pointer');
})

$('#btn-anterior').click(function () {
    let pagina = 0;

    if (parseInt($('#numero-pagina').val()) > 1) {
        pagina = parseInt($('#numero-pagina').val()) - 1;
    }
    else {
        pagina = parseInt($('#qtd-pagina').val());
    }

    $.ajax({
        type: "GET",
        url: "/Home/MudaCategoria",
        data: { pagina: pagina },
        success: function (categorias) {
            $('#div-categoria').html(categorias);
            $('#numero-pagina').val(pagina);
        },
        error: function (data) {
            alert(data.responseText);
        }
    });
})

$('#btn-proximo').click(function () {
    let pagina = 0;

    if (parseInt($('#numero-pagina').val()) < parseInt($('#qtd-pagina').val())) {
        pagina = parseInt($('#numero-pagina').val()) + 1;
    }
    else {
        pagina = 1;
    }

    $.ajax({
        type: "GET",
        url: "/Home/MudaCategoria",
        data: { pagina: pagina },
        success: function (categorias) {
            $('#div-categoria').html(categorias);
            $('#numero-pagina').val(pagina);
        },
        error: function (data) {
            alert(data.responseText);
        }
    });
})

function AdicionaCarrinho(idProduto) {
    $.ajax({
        type: "POST",
        url: "/Carrinho/NovoItem",
        data: { idProduto: idProduto },
        error: function (data) {
            alert(data.responseText);
        }
    });
}

function ListaCategoria(categoria) {
    $('#idCategoria').val(categoria);
    $('#form-categoria').submit();
}