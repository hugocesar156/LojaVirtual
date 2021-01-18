using LojaVirtual.Repositories;
using Microsoft.AspNetCore.Mvc;
using LojaVirtual.Authorizations;
using LojaVirtual.Sessions;
using LojaVirtual.Validations;
using System;
using Correios.NET;
using PagarMe;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace LojaVirtual.Controllers
{
    [Autorizacao.AcessoAutorizacao]
    public class PedidoController : Controller
    {
        private readonly Sessao _sessao;
        private readonly IConfiguration _configuration;

        private readonly PedidoR _reposPedido;
        private readonly ProdutoR _reposProduto;

        public PedidoController(Sessao sessao, PedidoR reposPedido,
            ProdutoR reposProduto, IConfiguration configuration)
        {
            _sessao = sessao;
            _configuration = configuration;

            _reposPedido = reposPedido;
            _reposProduto = reposProduto;
        }

        //Páginas
        [HttpGet]
        public IActionResult Detalhe(uint id)
        {
            try
            {
                var pedido = _reposPedido.Buscar(id);
                return View(pedido);
            }
            catch (Exception erro)
            {
                GerarLogErro(erro, (byte)Global.Entidade.Pedido, (byte)Global.Acao.Editar);
                throw new Exception(Global.Mensagem.FalhaBanco);
            }
        }

        public IActionResult Gerenciar(uint id)
        {
            try
            {
                var produto = _reposPedido.BuscarProdutoPedido(id);
                return View(produto);
            }
            catch (Exception erro)
            {
                GerarLogErro(erro, (byte)Global.Entidade.Pedido, (byte)Global.Acao.Editar);
                throw new Exception(Global.Mensagem.FalhaBanco);
            }
        }

        public IActionResult ListaCliente()
        {
            try
            {
                var lista = _reposPedido.ListarPedidos(_sessao.UsuarioSessao().IdCliente);
                return View(lista);
            }
            catch (Exception erro)
            {
                GerarLogErro(erro, (byte)Global.Entidade.Pedido, (byte)Global.Acao.Editar);
                throw new Exception(Global.Mensagem.FalhaBanco);
            }
        }

        public IActionResult ListaVendedor()
        {
            try
            {
                var lista = _reposPedido.ListarProdutoPedido(_sessao.UsuarioSessao().IdUsuario);
                return View(lista);
            }
            catch (Exception erro)
            {
                GerarLogErro(erro, (byte)Global.Entidade.Pedido, (byte)Global.Acao.Editar);
                throw new Exception(Global.Mensagem.FalhaBanco);
            }
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

                    if (_reposProduto.Atualizar(produto) > 0)
                    {
                        GerarLog((byte)Global.Entidade.Pedido, (byte)Global.Acao.Editar, Convert.ToUInt32(transacao.Id));
                        return Json(Global.Mensagem.SucessoOperacao);
                    }

                    return BadRequest(Global.Mensagem.FalhaAtualizacao);
                }

                return BadRequest(Global.Mensagem.FalhaAtualizacao);
            }
            catch (Exception erro)
            {
                GerarLogErro(erro, (byte)Global.Entidade.Pedido, (byte)Global.Acao.Editar);
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
                GerarLogErro(erro, (byte)Global.Entidade.Pedido, (byte)Global.Acao.Visualizar);
                return BadRequest(Global.Mensagem.FalhaRastrear);
            }
        }

        public void GerarLog(byte entidade, byte acao, uint objeto)
        {
            Log.ForContext("Usuario", Convert.ToString(_sessao.UsuarioSessao().IdUsuario))
                       .ForContext("Entidade", entidade).ForContext("Acao", acao).ForContext("Objeto", objeto).Information("");
        }

        public void GerarLogErro(Exception erro, byte entidade, byte acao)
        {
            Log.ForContext("Usuario", Convert.ToString(_sessao.UsuarioSessao().IdUsuario))
                       .ForContext("Entidade", entidade).ForContext("Acao", acao).Error(erro, "");
        }
    }
}