$('.card').mouseover(function () {
    $(this).css('cursor', 'pointer');
    $(this).addClass('shadow');
})

$('.card').mouseout(function () {
    $(this).removeClass('shadow');
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

function ListaProdutos(categoria) {
    $('#categoria-produto').val(categoria);
    $('#form-categoria').submit();
}