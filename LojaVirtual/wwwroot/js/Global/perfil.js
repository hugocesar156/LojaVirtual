$('#btn-perfil').click(function () {
    $.ajax({
        type: "POST",
        url: "/Usuario/Perfil",
        success: function (cliente) {
            $('#nome-perfil').html(cliente.nome.toLowerCase());
            $('#email-perfil').html(cliente.email);
            $('#cpf-perfil').html(cliente.cpf);

            let endereco = cliente.endereco;

            $('#endereco-perfil').html(
                `${endereco.cep} | ${endereco.logradouro.toLowerCase()}, ${endereco.bairro.toLowerCase()} </br>` +
                `${endereco.cidade.toLowerCase()} - ${endereco.uf.toUpperCase()}`
            );
        },
        error: function (erro) {
            alert(erro.responseText);
        }
    });
});