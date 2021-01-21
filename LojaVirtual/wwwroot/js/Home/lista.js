function AlterarPagina(operacao, categoria) {
    let pesquisa = $('#pesquisa').val();

    let pagina = parseInt($('#pagina').html());
    let numPaginas = parseInt($('#num-paginas').html());

    //Inicio
    if (operacao == 1 && pagina > 1) {
        $.ajax({
            type: "GET",
            url: "/Home/PesquisarLista",
            data: { pesquisa: pesquisa, pagina: 1, idCategoria: categoria },
            success: function (tabela) {
                $('#tabela').html(tabela);
            },
            error: function (erro) {
                alert(erro.responseText);
            }
        });
    }

    //Página anterior 
    if (operacao == 2 && pagina > 1) {
        $.ajax({
            type: "GET",
            url: "/Home/PesquisarLista",
            data: { pesquisa: pesquisa, pagina: pagina - 1, idCategoria: categoria },
            success: function (tabela) {
                $('#tabela').html(tabela);
            },
            error: function (erro) {
                alert(erro.responseText);
            }
        });
    }

    //Próxima página
    if (operacao == 3 && pagina < numPaginas) {
        $.ajax({
            type: "GET",
            url: "/Home/PesquisarLista",
            data: { pesquisa: pesquisa, pagina: pagina + 1, idCategoria: categoria },
            success: function (tabela) {
                $('#tabela').html(tabela);
            },
            error: function (erro) {
                alert(erro.responseText);
            }
        });
    }

    //Final 
    if (operacao == 4 && pagina < numPaginas) {
        $.ajax({
            type: "GET",
            url: "/Home/PesquisarLista",
            data: { pesquisa: pesquisa, pagina: numPaginas, idCategoria: categoria },
            success: function (tabela) {
                $('#tabela').html(tabela);
            },
            error: function (erro) {
                alert(erro.responseText);
            }
        });
    }
}

function Pesquisa(categoria) {
    let pesquisa = $('#pesquisa').val();

    $.ajax({
        type: "GET",
        url: "/Home/PesquisarLista",
        data: { pesquisa: pesquisa, pagina: 1, idCategoria: categoria },
        success: function (tabela) {
            $('#tabela').html(tabela);
        },
        error: function (erro) {
            alert(erro.responseText);
        }
    });
}