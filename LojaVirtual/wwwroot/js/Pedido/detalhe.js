$(document).ready(function () {
    let situacao = $('#situacao-pedido').val();

    if (situacao == 0 || situacao == 1) {
        $('#bar-situacao-pedido').css('width', '1%');

        $('#btn-aguardo').removeClass('btn-outline-light');

        $('#btn-aguardo').addClass('btn-outline-primary');
    }
    else if (situacao == 2) {
        $('#bar-situacao-pedido').css('width', '50%');

        $('#btn-aguardo').removeClass('btn-outline-light');
        $('#btn-pedido-aprovado').removeClass('btn-outline-light');

        $('#btn-aguardo').addClass('btn-outline-primary');
        $('#btn-pedido-aprovado').addClass('btn-outline-primary');
    }
    else if (situacao == 5) {
        $('#bar-situacao-pedido').css('width', '100%');

        $('#btn-aguardo').removeClass('btn-outline-light');
        $('#btn-pedido-aprovado').removeClass('btn-outline-light');
        $('#btn-finalizado').removeClass('btn-outline-light');

        $('#btn-aguardo').addClass('btn-outline-primary');
        $('#btn-pedido-aprovado').addClass('btn-outline-primary');
        $('#btn-finalizado').addClass('btn-outline-primary');
    }
})

function CarregaSituacao(situacao) {
    switch (situacao) {
        case "0":
            $('#div-situacao').removeClass('d-none');
            $('#div-cancelado').addClass('d-none');

            $('#bar-situacao-produto').removeClass('bg-danger');
            $('#bar-situacao-produto').addClass('bg-primary');

            $('#bar-situacao-produto').css('width', '1%');

            $('#btn-espera').removeClass('btn-outline-light');

            $('#btn-espera').addClass('btn-outline-primary');
            break;

        case "1":
            $('#div-situacao').removeClass('d-none');
            $('#div-cancelado').addClass('d-none');

            $('#bar-situacao-produto').removeClass('bg-danger');
            $('#bar-situacao-produto').addClass('bg-primary');

            $('#bar-situacao-produto').css('width', '40%');

            $('#btn-espera').removeClass('btn-outline-light');
            $('#btn-aprovado').removeClass('btn-outline-light');

            $('#btn-espera').addClass('btn-outline-primary');
            $('#btn-aprovado').addClass('btn-outline-primary');
            break;

        case "2":
            $('#div-situacao').removeClass('d-none');
            $('#div-cancelado').addClass('d-none');

            $('#bar-situacao-produto').removeClass('bg-danger');
            $('#bar-situacao-produto').addClass('bg-primary');

            $('#bar-situacao-produto').css('width', '75%');

            $('#btn-espera').removeClass('btn-outline-light');
            $('#btn-aprovado').removeClass('btn-outline-light');
            $('#btn-enviado').removeClass('btn-outline-light');

            $('#btn-espera').addClass('btn-outline-primary');
            $('#btn-aprovado').addClass('btn-outline-primary');
            $('#btn-enviado').addClass('btn-outline-primary');
            break;

        case "3":
            $('#div-situacao').removeClass('d-none');
            $('#div-cancelado').addClass('d-none');

            $('#bar-situacao-produto').removeClass('bg-danger');
            $('#bar-situacao-produto').addClass('bg-primary');

            $('#bar-situacao-produto').css('width', '100%');

            $('#btn-espera').removeClass('btn-outline-light');
            $('#btn-aprovado').removeClass('btn-outline-light');
            $('#btn-enviado').removeClass('btn-outline-light');
            $('#btn-entregue').removeClass('btn-outline-light');

            $('#btn-espera').addClass('btn-outline-primary');
            $('#btn-aprovado').addClass('btn-outline-primary');
            $('#btn-enviado').addClass('btn-outline-primary');
            $('#btn-entregue').addClass('btn-outline-primary');
            break;

        case "4":
            $('#bar-situacao-produto').removeClass('bg-primary');
            $('#bar-situacao-produto').addClass('bg-danger');
            $('#bar-situacao-produto').css('width', '100%');

            $('#div-situacao').addClass('d-none');
            $('#div-cancelado').removeClass('d-none');

            $('#btn-cancelado').removeClass('btn-outline-light');
            $('#btn-cancelado').addClass('btn-outline-danger');
            break;

        default:
            $('#bar-situacao-produto').css('width', '0%');
            break;
    }
}