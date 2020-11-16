function AdicionarQuantidade(idProduto) {
    $.ajax({
        type: "GET",
        url: "/Carrinho/AdicionarItem/" + idProduto,
        success: function (lista) {
            $("#lista").html(lista);

            let subtotal = 0;

            $('.price').each(function () {
                subtotal += this.innerHTML.replace("R$", "").replace(".", "").replace(",", ".");
            });

            //subtotal = subtotal.toLocaleString('pt-br', { style: 'currency', currency: 'BRL' });

            $('#subtotal').html(subtotal);
        },
        error: function () {
            alert("Erro ao tentar atualizar carrinho.");
        }
    });
}

function RetirarQuantidade(idProduto) {
    $.ajax({
        type: "GET",
        url: "/Carrinho/RetirarItem/" + idProduto,
        success: function (lista) {
            $("#lista").html(lista);
        },
        error: function () {
            alert("Erro ao tentar atualizar carrinho.");
        }
    });
}