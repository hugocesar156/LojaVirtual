using LojaVirtual.Models.Produto;
using LojaVirtual.Models.Venda;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSCorreios;

namespace LojaVirtual.Repositories
{
    public class FreteR
    {
        private readonly IConfiguration _configuration;
        private readonly CalcPrecoPrazoWSSoap _servico;

        public FreteR(IConfiguration configuration, CalcPrecoPrazoWSSoap servico)
        {
            _configuration = configuration;
            _servico = servico;
        }

        public static List<Pacote> PrepararPacotes(List<Produto> lista, Dictionary<uint, uint> quantidade)
        {
            try
            {
                var pacotes = new List<Pacote>();
                var pacote = new Pacote();

                foreach (var produto in lista)
                {
                    for (int i = 0; i < quantidade[produto.IdProduto]; i++)
                    {
                        var dimensaoProduto = (produto.Largura * 2) + (produto.Altura * 2) + produto.Comprimento;
                        var dimensaoPacote = pacote.Comprimento + pacote.Largura + pacote.Altura;

                        if ((produto.Peso + pacote.Peso) >= 30 || (dimensaoProduto + dimensaoPacote) >= 200)
                        {
                            pacotes.Add(pacote);
                            pacote = new Pacote();
                        }

                        pacote.Peso += produto.Peso;

                        if (pacote.Comprimento < produto.Comprimento)
                            pacote.Comprimento = produto.Comprimento;

                        if (pacote.Largura < produto.Largura)
                            pacote.Largura = produto.Largura;

                        pacote.Altura += produto.Altura;
                    }
                }

                if (pacotes.LastOrDefault() != pacote) 
                    pacotes.Add(pacote);

                return pacotes;
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return new List<Pacote>();
            }
        }

        public async Task<Frete> CalcularFrete(string cepDestino, List<Pacote> lista, string servico)
        {
            try
            {
                var cepOrigem = _configuration.GetValue<string>("Frete:CepOrigem");
                var maoPropria = _configuration.GetValue<string>("Frete:MaoPropria");
                var avisoRecebimento = _configuration.GetValue<string>("Frete:AvisoRecebimento");

                var prazo = await _servico.CalcPrazoAsync(servico, cepOrigem, cepDestino);

                var frete = new Frete();

                if (prazo.Servicos[0].Erro == "")
                    frete.Prazo = Convert.ToDateTime(prazo.Servicos[0].DataMaxEntrega);

                foreach (var pacote in lista)
                {
                    var diametro = pacote.Altura + pacote.Comprimento + pacote.Largura;

                    var valor = await _servico.CalcPrecoAsync("", "", servico, cepOrigem, cepDestino, pacote.Peso.ToString(),
                        1, pacote.Comprimento, pacote.Altura, pacote.Largura, diametro, maoPropria, 0, avisoRecebimento);

                    if (valor.Servicos[0].Erro == "")
                        frete.Valor += float.Parse(valor.Servicos[0].Valor);
                }

                return frete;
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return new Frete();
            }
        }
    }
}
