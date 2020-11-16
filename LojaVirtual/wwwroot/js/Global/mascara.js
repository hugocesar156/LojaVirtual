$(document).ready(function () {
    $(".cm").mask('000');
    $(".cpf").mask('000.000.000-00');
    $(".kg").mask('00,00', { reverse: true });
    $(".quantidade").mask('0000');
    $(".real").mask('000.000,00', { reverse: true });

    $('.form-control').css('background-color', '#fafafa');
});