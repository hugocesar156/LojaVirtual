using LojaVirtual.Repositories;
using Microsoft.AspNetCore.Mvc;
using LojaVirtual.Authorizations;
using LojaVirtual.Sessions;
using LojaVirtual.Validations;
using System;
using Correios.NET;
using PagarMe;
using Microsoft.Extensions.Configuration;

namespace LojaVirtual.Controllers
{
    [AcessoAutorizacao]
    public class PedidoController : Controller
    {
        private readonly Sessao _sessao;
        private readonly PedidoR _reposPedido;
        private readonly ProdutoR _reposProduto;

        private readonly IConfiguration _configuration;

        public PedidoController(Sessao sessao, PedidoR reposPedido, ProdutoR reposProduto, IConfiguration configuration)
        {
            _sessao = sessao;
            _reposPedido = reposPedido;
            _reposProduto = reposProduto;

            _configuration = configuration;
        }

        //Páginas
        [HttpGet]
        public IActionResult Detalhe(uint id)
        {
            var pedido = _reposPedido.Buscar(id);
            return View(pedido);
        }

        public IActionResult Gerenciar(uint id)
        {
            var produto = _reposPedido.BuscarProdutoPedido(id);
            return View(produto);
        }

        public IActionResult ListaCliente()
        {
            var lista = _reposPedido.ListarPedidos(_sessao.UsuarioSessao().IdCliente);
            return View(lista);
        }

        public IActionResult ListaVendedor()
        {
            var lista = _reposPedido.ListarProdutoPedido(_sessao.UsuarioSessao().IdUsuario);
            return View(lista);
        }

        //Operações
        [HttpPost]
        public IActionResult EstornarProduto(uint idTransacao, uint idProduto)
        {
            try
            {
                PagarMeService.DefaultApiKey = _configuration.GetValue<string>("Pagamento:DefaultApiKey");

                var produtoPedido = _reposPedido.BuscarProdutoPedido(idProduto);
                var valorEstorno = Convert.ToInt32((produtoPedido.Valor * produtoPedido.Quantidade).ToString().Replace(".", ""));

                var transacao = PagarMeService.GetDefaultService().Transactions.Find(idTransacao.ToString());
                transacao.Refund(valorEstorno);

                produtoPedido.Situacao = (byte)Global.Produto.Cancelado;
                produtoPedido.DataAtualizacao = DateTime.Now;

                if (_reposPedido.AtualizarProdutoPedido(produtoPedido) > 0)
                {
                    var produto = _reposProduto.Buscar(produtoPedido.IdProduto);
                    produto.Estoque += produtoPedido.Quantidade;

                    return _reposProduto.Atualizar(produto) > 0 ?
                        Json(Global.Mensagem.SucessoOperacao) : Json(Global.Mensagem.FalhaAtualizacao);
                }

                return Json(Global.Mensagem.FalhaAtualizacao);
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return BadRequest(Global.Mensagem.FalhaBanco);
            }
        }

        [HttpPost]
        public IActionResult RastrearProduto(string codRastreamento)
        {
            try
            {
                var rastreamento = new Services().GetPackageTracking(codRastreamento);
                return Json(rastreamento.TrackingHistory);
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return BadRequest();
            }
        }
    }
}