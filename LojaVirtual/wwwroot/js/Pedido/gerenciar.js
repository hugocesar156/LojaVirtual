$(document).ready(function () {
    let situacao = parseInt($('#produto-situacao').val());

    switch (situacao) {
        case 0:
            $('#div-situacao').removeClass('d-none');
            $('#div-cancelado').addClass('d-none');

            $('#bar-situacao-produto').removeClass('bg-danger');
            $('#bar-situacao-produto').addClass('bg-primary');

            $('#bar-situacao-produto').css('width', '1%');

            $('#btn-espera').removeClass('btn-outline-light');

            $('#btn-espera').addClass('btn-outline-primary');
            break;

        case 1:
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

        case 2:
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

        case 3:
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

        case 4:
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
})