$(document).ready(function () {
    $('.form-control').each(function () {
        $(this).addClass('is-valid');
    })
})

function ValidaEdicao() {
    let altura = parseInt($('#altura').val());
    let largura = parseInt($('#largura').val());
    let comprimento = parseInt($('#comprimento').val());
    let dimensao = altura + largura + comprimento;

    if ($('.form-control').length == $('.is-valid').length) {
        if (dimensao <= 200) {
            let produto = {
                idProduto: $('#id-produto').val(),
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

            let token = $('input[name="__RequestVerificationToken"]').val();

            $.ajax({
                type: "POST",
                url: "/Produto/Atualizar",
                data: { __RequestVerificationToken: token, produto: produto },
                success: function (idProduto) {
                    window.location.pathname = "Produto/Imagem/" + idProduto;
                },
                error: function (erro) {
                    alert(erro.responseText);
                }
            });
        }
        else {
            $('#altura').removeClass('is-valid');
            $('#comprimento').removeClass('is-valid');
            $('#largura').removeClass('is-valid');

            $('#altura').addClass('is-invalid');
            $('#comprimento').addClass('is-invalid');
            $('#largura').addClass('is-invalid');

            $('#altura').val("");
            $('#comprimento').val("");
            $('#largura').val("");

            $('#dimensao').addClass('is-invalid');
            $('.msg-dimensao').html("Dimensão máxima permitida é de 200cm.");
        }
    }
}