function Detalhar(idProduto) {
    $.ajax({
        type: "GET",
        url: "/Produto/Detalhar/" + idProduto,
        success: function (produto) {
            $('#nome').html(produto.nome.toLowerCase());
            $('#fabricante').html(produto.fabricante.toLowerCase());
            $('#modelo').html(produto.modelo.toLowerCase());
            $('#cor').html(produto.cor.toLowerCase());
            $('#valor').html("R$ " + produto.valor);
            $('#dimensao').html(`${produto.comprimento}x${produto.largura}x${produto.altura}`);
            $('#descricao').html(produto.descricao.toLowerCase());
            $('#imagem-produto').attr('src', produto.imagem[0].caminho.replace('wwwroot', ''))
        },
        error: function (erro) {
            alert(erro.responseText);
        }
    });
}

function Mensagem(idProduto, fabricante, modelo, cor) {
    $('#id-produto').val(idProduto);
    $('#modal-body-remover').html(`Tem certeza que quer remover o produto ${fabricante} ${modelo} ${cor}?`);
}

function Remover() {
    let idProduto = $('#id-produto').val();

    $.ajax({
        type: "POST",
        url: "/Produto/Remover",
        data: { idProduto: idProduto },
        success: function () {
            window.location.pathname = "Produto/Lista";
        },
        error: function (erro) {
            alert(erro.responseText);
        }
    });
}