$('#btn-perfil').click(function () {
    $.ajax({
        type: "POST",
        url: "/Usuario/Perfil",
        success: function (cliente) {
            $('#nome').html(cliente.nome.toLowerCase());
            $('#email').html(cliente.email);
            $('#cpf').html(cliente.cpf);

            let endereco = cliente.endereco;

            $('#endereco').html(
                `${endereco.cep} | ${endereco.logradouro.toLowerCase()}, ${endereco.bairro.toLowerCase()} </br>` +
                `${endereco.cidade.toLowerCase()} - ${endereco.uf.toUpperCase()}`
            );
        },
        error: function (erro) {
            alert(erro.responseText);
        }
    });
});