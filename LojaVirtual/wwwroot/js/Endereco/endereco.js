function BuscaEndereco() {
    if ($('#cep').val().length == 9) {
        let cep = $('#cep').val().replace("-", "");

        $.ajax({
            type: "GET",
            url: "https://viacep.com.br/ws/"+ cep +"/json",
            dataType: "jsonp",
            success: function (endereco) {
                if (endereco.cep != undefined) {
                    $('#logradouro').val(endereco.logradouro);
                    $('#bairro').val(endereco.bairro);
                    $('#cidade').val(endereco.localidade);
                    $('#uf').val(endereco.uf);
                    $('#complemento').val(endereco.complemento);

                    ValidaCampo();
                }
                else {
                    $('#cep').removeClass('is-valid');
                    $('#cep').addClass('is-invalid');
                }
            },
            error: function () {
                alert("Erro ao tentar buscar endereço");
            }
        });
    }
}

function ValidaCampoEndereco(campo) {
    if (campo == undefined) {
        $('.form-endereco').each(function () {
            if ($(this).val() == "" && !$(this).hasClass('campo-nulo')) {
                $(this).removeClass('is-valid');
                $(this).addClass('is-invalid');
            }
            else {
                $(this).removeClass('is-invalid');
                $(this).addClass('is-valid');
            }
        });
    }
    else {
        if ($(campo).val() == "" && !$(campo).hasClass('campo-nulo')) {
            $(campo).removeClass('is-valid');
            $(campo).addClass('is-invalid');
        }
        else {
            $(campo).removeClass('is-invalid');
            $(campo).addClass('is-valid');
        }
    }
}