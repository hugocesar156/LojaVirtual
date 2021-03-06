﻿function AlterarPagina(operacao) {
    let pesquisa = $('#pesquisa').val();
    let quantidade = $('#quantidade').val();

    let pagina = parseInt($('#pagina').html());
    let numPaginas = parseInt($('#num-paginas').html());

    //Inicio
    if (operacao == 1 && pagina > 1) {
        $.ajax({
            type: "GET",
            url: "/Usuario/PesquisarLista",
            data: { pesquisa: pesquisa, pagina: 1, quantidade: quantidade },
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
            url: "/Usuario/PesquisarLista",
            data: { pesquisa: pesquisa, pagina: pagina - 1, quantidade: quantidade },
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
            url: "/Usuario/PesquisarLista",
            data: { pesquisa: pesquisa, pagina: pagina + 1, quantidade: quantidade },
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
            url: "/Usuario/PesquisarLista",
            data: { pesquisa: pesquisa, pagina: numPaginas, quantidade: quantidade },
            success: function (tabela) {
                $('#tabela').html(tabela);
            },
            error: function (erro) {
                alert(erro.responseText);
            }
        });
    }
}

function Ordenacao(ordenacao) {
    let pesquisa = $('#pesquisa').val();
    let quantidade = $('#quantidade').val();

    let pagina = parseInt($('#pagina').html());

    $.ajax({
        type: "GET",
        url: "/Usuario/OrdenarLista",
        data: { pesquisa: pesquisa, pagina: pagina, ordenacao: ordenacao, quantidade: quantidade },
        success: function (tabela) {
            $('#tabela').html(tabela);
        },
        error: function (erro) {
            alert(erro.responseText);
        }
    });
}

function Pesquisa() {
    let pesquisa = $('#pesquisa').val();
    let quantidade = $('#quantidade').val();

    $.ajax({
        type: "GET",
        url: "/Usuario/PesquisarLista",
        data: { pesquisa: pesquisa, pagina: 1, quantidade: quantidade },
        success: function (tabela) {
            $('#tabela').html(tabela);
        },
        error: function (erro) {
            alert(erro.responseText);
        }
    });
}