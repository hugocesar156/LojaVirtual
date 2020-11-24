function PreparaTransacao() {
    let cartao = {
        nome: "",
        numero: $('#numero').val().replace(" ", "").replace(" ", "").replace(" ", ""),
        vencimento: $('#vencimento').val(),
        verificador: $('#verificador').val()
    };
   
    let cep = $('#cep').val().replace("-", "");
    let servico = "";

    if ($('#sedex-input').prop('checked')) {
        servico = "04014";
    }
    else {
        servico = "04510";
    }

    let endereco = { };

    $.ajax({
        type: "GET",
        url: "https://viacep.com.br/ws/" + cep + "/json",
        dataType: "jsonp",
        success: function (enderecoJson) {
            if (enderecoJson.cep != undefined) {
                endereco.cep = enderecoJson.cep.replace("-", "");
                endereco.logradouro = enderecoJson.logradouro;
                endereco.bairro = enderecoJson.bairro;
                endereco.cidade = enderecoJson.localidade;
                endereco.complemento = enderecoJson.complemento;
                endereco.uf = enderecoJson.uf;
                endereco.ibge = enderecoJson.ibge;

                let frete = { };

                $.ajax({
                    type: "GET",
                    url: "/Carrinho/CalcularFrete",
                    data: { cep: cep, servico: servico },
                    success: function (data) {
                        frete.valor = data.valor.toFixed(2).replace(".", ",");
                        frete.prazo = data.prazo;

                        $.ajax({
                            type: "POST",
                            url: "/Pagamento/PagamentoCartao",
                            data: { cartao: cartao, endereco: endereco, frete: frete },
                            success: function () {

                            }
                        });
                    }
                });
            }
        },
        error: function () {
            alert("Erro ao preparar transação.");
        }
    });
}