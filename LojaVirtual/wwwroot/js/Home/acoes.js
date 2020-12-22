$('.card').mouseover(function () {
    $(this).css('cursor', 'pointer');
    $(this).addClass('shadow');
})

$('.card').mouseout(function () {
    $(this).removeClass('shadow');
})

function ListaProdutos(categoria) {
    $('#categoria-produto').val(categoria);
    $('#form-categoria').submit();
}