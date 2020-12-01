$(document).ready(function () {
    $(".cartao").mask('0000 0000 0000 0000');
    $(".cm").mask('000');
    $(".cep").mask('00000-000');
    $(".cpf").mask('000.000.000-00');
    $(".data").mask('00/00');
    $(".num-3").mask('000');
    $(".kg").mask('00,00', { reverse: true });
    $(".quantidade").mask('0000');
    $(".real").mask('000.000,00', { reverse: true });
    $(".telefone").mask('00 00000-0000');

    $('.form-control').css('background-color', '#fafafa');
});