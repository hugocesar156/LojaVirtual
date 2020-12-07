using LojaVirtual.Repositories;
using Microsoft.AspNetCore.Mvc;
using LojaVirtual.Authorizations;
using LojaVirtual.Sessions;
using System;
using Correios.NET;

namespace LojaVirtual.Controllers
{
    [AcessoAutorizacao]
    public class PedidoController : Controller
    {
        private readonly Sessao _sessao;
        private readonly PedidoR _reposPedido;

        public PedidoController(Sessao sessao, PedidoR reposPedido)
        {
            _sessao = sessao;
            _reposPedido = reposPedido;
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