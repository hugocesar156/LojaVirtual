function CarregaSituacao(situacao) {
   
    switch (situacao) {
        case '1':
            $('#bar-situacao').css('width', '1%');

            $('#btn-espera').removeClass('btn-outline-light');

            $('#btn-espera').addClass('btn-outline-primary');
            break;

        case '2':
            $('#bar-situacao').css('width', '40%');

            $('#btn-espera').removeClass('btn-outline-light');
            $('#btn-espera').removeClass('btn-outline-light');

            $('#btn-espera').addClass('btn-outline-primary');
            $('#btn-aprovado').addClass('btn-outline-primary');
            break;

        case '3':
            $('#bar-situacao').css('width', '75%');

            $('#btn-espera').removeClass('btn-outline-light');
            $('#btn-espera').removeClass('btn-outline-light');
            $('#btn-espera').removeClass('btn-outline-light');

            $('#btn-espera').addClass('btn-outline-primary');
            $('#btn-aprovado').addClass('btn-outline-primary');
            $('#btn-enviado').addClass('btn-outline-primary');
            break;

        case '4':
            $('#bar-situacao').css('width', '100%');

            $('#btn-espera').removeClass('btn-outline-light');
            $('#btn-espera').removeClass('btn-outline-light');
            $('#btn-espera').removeClass('btn-outline-light');
            $('#btn-espera').removeClass('btn-outline-light');

            $('#btn-espera').addClass('btn-outline-primary');
            $('#btn-aprovado').addClass('btn-outline-primary');
            $('#btn-enviado').addClass('btn-outline-primary');
            $('#btn-entregue').addClass('btn-outline-primary');
            break;

        default:
            $('#bar-situacao').css('width', '0%');
            break;
    }
}