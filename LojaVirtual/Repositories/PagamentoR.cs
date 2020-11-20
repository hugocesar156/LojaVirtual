using PagarMe;
using System;

namespace LojaVirtual.Repositories
{
    public class PagamentoR
    {
        public static void GerarBoleto(Transaction transacao)
        {
            try
            {
                PagarMeService.DefaultApiKey = "SUA_CHAVE_DE_API";
                PagarMeService.DefaultEncryptionKey = "SUA_CHAVE_DE_CRIPTOGRAFIA";

                transacao.Save();
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
            }
        }

        public static void PagamentoCartao(Transaction transacao)
        {
            try
            {
                PagarMeService.DefaultApiKey = "SUA_CHAVE_DE_API";
                PagarMeService.DefaultEncryptionKey = "SUA_CHAVE_DE_CRIPTOGRAFIA";

                transacao.Save();
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
            }
        }
    }
}
