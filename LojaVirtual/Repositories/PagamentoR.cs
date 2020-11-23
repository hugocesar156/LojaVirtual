using Microsoft.Extensions.Configuration;
using PagarMe;
using System;

namespace LojaVirtual.Repositories
{
    public class PagamentoR
    {
        private readonly IConfiguration _configuration;

        public PagamentoR(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void GerarBoleto(Transaction transacao)
        {
            try
            {
                PagarMeService.DefaultApiKey = _configuration.GetValue<string>("Pagamento:DefaultApiKey");
                PagarMeService.DefaultEncryptionKey = _configuration.GetValue<string>("Pagamento:DefaultEncryptionKey");

                transacao.Save();
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
            }
        }

        public void PagamentoCartao(Transaction transacao)
        {
            try
            {
                PagarMeService.DefaultApiKey = _configuration.GetValue<string>("Pagamento:DefaultApiKey");
                PagarMeService.DefaultEncryptionKey = _configuration.GetValue<string>("Pagamento:DefaultEncryptionKey");

                transacao.Save();
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
            }
        }
    }
}
