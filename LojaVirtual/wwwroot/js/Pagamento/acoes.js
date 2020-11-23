function PreparaTransacao() {
    let numero = $('#numero').val().replace(" ", "").replace(" ", "").replace(" ", "");
    let vencimento = $('#vencimento').val();
    let verificador = $('#verificador').val();

    let cep = $('#cep').val().replace("-", "");
    let servico = "";

    if ($('#sedex-input').prop('checked')) {
        servico = "04014";
    }
    else {
        servico = "04510";
    }

    $.ajax({
        type: "POST",
        url: "/Pagamento/PagamentoCartao",
        data: { numero: numero, vencimento: vencimento, verificador: verificador, cep: cep, servico: servico },
        success: function () {
           
        },
        error: function () {
            alert("Erro.");
        }
    });
}