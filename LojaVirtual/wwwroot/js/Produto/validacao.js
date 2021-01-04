//Validações de campos
$('.form-control').change(function () {
    if ($(this).val() == "") {
        $(this).removeClass('is-valid');
        $(this).addClass('is-invalid');
    }
    else {
        $(this).removeClass('is-invalid');
        $(this).addClass('is-valid');
    }

    if ($(this).val() == 0 && ($(this).hasClass('real') || $(this).hasClass('quantidade'))) {
        $(this).removeClass('is-valid');
        $(this).addClass('is-invalid');

        $('.msg-valor').html("O valor não pode ser 0.");
    }
})

$('#altura').change(function () {
    if ($('#altura').val() < 1 || $('#altura').val() > 100) {
        $('#altura').removeClass('is-valid');
        $('#altura').addClass('is-invalid');

        $('.msg-altura').html("A altura deve ser entre 1cm e 100cm.");
    }
    else {
        $('#dimensao').removeClass('is-invalid');
        $('#altura').removeClass('is-invalid');
        $('#altura').addClass('is-valid');
    }
})

$('#comprimento').change(function () {
    if ($('#comprimento').val() < 15 || $('#comprimento').val() > 100) {
        $('#comprimento').removeClass('is-valid');
        $('#comprimento').addClass('is-invalid');

        $('.msg-comprimento').html("O comprimento deve ser entre 15cm e 100cm.");
    }
    else {
        $('#dimensao').removeClass('is-invalid');
        $('#comprimento').removeClass('is-invalid');
        $('#comprimento').addClass('is-valid');
    }
})

$('#largura').change(function () {
    if ($('#largura').val() < 10 || $('#largura').val() > 100) {
        $('#largura').removeClass('is-valid');
        $('#largura').addClass('is-invalid');

        $('.msg-largura').html("A largura deve ser entre 10cm e 100cm.");
    }
    else {
        $('#dimensao').removeClass('is-invalid');
        $('#largura').removeClass('is-invalid');
        $('#largura').addClass('is-valid');
    }
})

$('#peso').change(function () {
    if ($('#peso').val() == 0 || $('#peso').val() > 30) {
        $('#peso').removeClass('is-valid');
        $('#peso').addClass('is-invalid');

        $('.msg-peso').html("O peso não pode ser 0 e deve ser de até 30Kg.");
    }
    else {
        $('#peso').removeClass('is-invalid');
        $('#peso').addClass('is-valid');
    }
})

//Validação para cadastro
function ValidaRegistro() {
    let altura = parseInt($('#altura').val());
    let largura = parseInt($('#largura').val());
    let comprimento = parseInt($('#comprimento').val());
    let dimensao = altura + largura + comprimento;

    if ($('.form-control').length == $('.is-valid').length) {
        if (dimensao <= 200) {
            let produto = {
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

            $.ajax({
                type: "POST",
                url: "/Produto/Registrar",
                data: { produto: produto },
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