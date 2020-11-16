function CarregaImagem() {
    let caminho = $(".custom-file-input")[0].files[0];
    let formulario = new FormData();
    formulario.append("arquivo", caminho);

    $('#lista-imagem').addClass('d-none');

    $.ajax({
        type: "POST",
        url: "/Imagem/Carregar",
        data: formulario,
        processData: false,
        contentType: false,
        success: function (imagem) {
            $('#imagem').attr('src', imagem);
            $('.custom-file-input').val("");

            $('#form-imagem').removeClass('d-none');

            $('#caminho').val(imagem);
        },
        error: function () {
            alert("Erro ao tentar carregar imagem.");

            $('#lista-imagem').removeClass('d-none');
        }
    });
}

function DescartaImagem() {
    $('#salvar').attr('disabled', true);
    $('#remover').attr('disabled', true);

    let arquivo = $("#caminho").val();

    $.ajax({
        type: "POST",
        url: "/Imagem/Descartar",
        data: { arquivo: arquivo },
        success: function (resultado) {
            if (resultado) {
                $('#form-imagem').addClass('d-none');
                $('#lista-imagem').removeClass('d-none');
            }
          
            $('#salvar').attr('disabled', false);
            $('#remover').attr('disabled', false);
        },
        error: function () {
            alert("Erro ao descartar imagem.");

            $('#salvar').attr('disabled', false);
            $('#remover').attr('disabled', false);
        }
    });
}

function RemoveImagem() {
    let idProduto = $("#id-produto").val();
    let arquivo = $('#caminho-remover').val();

    $.ajax({
        type: "POST",
        url: "/Imagem/Remover/" + idProduto,
        data: { arquivo: arquivo },
        success: function (imagens) {
            $("#lista-imagem").html(imagens);
        },
        error: function () {
            alert("Erro ao remover imagem.");
        }
    });
}

function SalvaImagem() {
    $('#salvar').attr('disabled', true);
    $('#remover').attr('disabled', true);

    let idProduto = $("#id-produto").val();
    let arquivo = $("#caminho").val();

    $.ajax({
        type: "POST",
        url: "/Imagem/Salvar",
        data: { arquivo: arquivo, idProduto: idProduto },
        success: function (imagens) {
            $("#imagem").attr("src", "");
            $("#form-imagem").addClass('d-none');

            $('#salvar').attr('disabled', false);
            $('#remover').attr('disabled', false);

            $("#lista-imagem").html(imagens);
            $('#lista-imagem').removeClass('d-none');
        },
        error: function () {
            alert("Erro ao enviar imagem.");

            $("#salvar").removeClass('d-none');
            $("#remover").removeClass('d-none');
        }
    });
}