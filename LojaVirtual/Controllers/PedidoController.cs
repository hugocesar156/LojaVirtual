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

        private readonly IConfiguration _configuration;

        public PedidoController(Sessao sessao, PedidoR reposPedido, IConfiguration configuration)
        {
            _sessao = sessao;
            _reposPedido = reposPedido;

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
        public IActionResult EstornarPedido(uint idTransacao)
        {
            try
            {
                PagarMeService.DefaultApiKey = _configuration.GetValue<string>("Pagamento:DefaultApiKey");

                var transacao = PagarMeService.GetDefaultService().Transactions.Find(idTransacao.ToString());
                transacao.Refund();

                var pedido = _reposPedido.Buscar(idTransacao);
                pedido.Situacao = (byte)Global.Pedido.Estornado;
                pedido.DataAtualizaco = DateTime.Now;

                return _reposPedido.Atualizar(pedido) > 0 ?
                    Json(Global.Mensagem.SucessoOperacao) : Json(Global.Mensagem.FalhaAtualizacao); 
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return BadRequest(Global.Mensagem.FalhaBanco);
            }
        }

        [HttpPost]
        public IActionResult LiberarProduto(uint id)
        {
            try
            {
                var produto = _reposPedido.BuscarProdutoPedido(id);
                produto.Situacao = (byte)Global.Produto.Enviado;
                produto.DataAtualizacao = DateTime.Now;

                return _reposPedido.AtualizarProdutoPedido(produto) > 0 ?
                   Json(Global.Mensagem.SucessoOperacao) : Json(Global.Mensagem.FalhaAtualizacao);
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return BadRequest();
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