using LojaVirtual.Models.Produto;
using LojaVirtual.Models.Venda;
using LojaVirtual.Repositories;
using Microsoft.AspNetCore.Mvc;
using LojaVirtual.Authorizations;
using LojaVirtual.Sessions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;
using LojaVirtual.Validations;

namespace LojaVirtual.Controllers
{
    [AcessoAutorizacao]
    public class CarrinhoController : Controller
    {
        private readonly Sessao _sessao;
        private readonly ILogger<CarrinhoController> _logger;

        private readonly ProdutoR _reposProduto;
        private readonly CarrinhoR _reposCarrinho;
        private readonly FreteR _reposFrete;
        private readonly ClienteR _reposCliente;

        private static List<Carrinho> _carrinho;

        public CarrinhoController(Sessao sessao, ILogger<CarrinhoController> logger, ProdutoR reposProduto, CarrinhoR reposCarrinho, 
            FreteR reposFrete, ClienteR reposCliente)
        {
            _sessao = sessao;
            _logger = logger;

            _reposProduto = reposProduto;
            _reposCarrinho = reposCarrinho;
            _reposFrete = reposFrete;
            _reposCliente = reposCliente;
        }

        //Páginas
        public IActionResult Menu()
        {
            try
            {
                var carrinho = _reposCarrinho.Buscar(_sessao.UsuarioSessao().IdCliente);
                var produtos = new List<Produto>();

                foreach (var item in carrinho)
                    produtos.Add(_reposProduto.Buscar(item.IdProduto));

                _carrinho = carrinho;

                ViewBag.Quantidade = carrinho.ToDictionary(i => i.IdProduto, i => i.Quantidade);

                var endereco = _reposCliente.BuscaEndereco(_sessao.UsuarioSessao().IdCliente);
                ViewBag.Cep = endereco.Cep;
                ViewBag.Numero = endereco.Numero;
                ViewBag.Nome = endereco.Nome;

                ViewBag.Estados = new string[]
                {
                "AC", "AL", "AM", "AP", "BA", "CE", "DF", "ES", "GO", "MA",
                "MG", "MS", "MT", "PA", "PB", "PE", "PI", "PR", "RJ", "RN",
                "RO", "RR", "RS", "SC", "SE", "SP", "TO"
                };

                return View(produtos);
            }
            catch (Exception erro)
            {
                _logger.LogError($"Carrinho/Menu - {erro.Message} ID de usuário: " +
                    $"{_sessao.UsuarioSessao().IdUsuario}");

                throw new Exception(Global.Mensagem.FalhaBanco);
            }
        }


        //Operações
        [HttpGet]
        public IActionResult AdicionarQuantidade(uint id)
        {
            try
            {
                var item = _carrinho.FirstOrDefault(c => c.IdProduto == id);

                if (_reposProduto.Buscar(id).Estoque > item.Quantidade)
                {
                    if (_reposCarrinho.Atualizar(item, 1) > 0)
                        return PartialView("_Carrinho", BuscaProdutosCarrinho(_carrinho));
                }

                return BadRequest(Global.Mensagem.SemEstoque);
            }
            catch (Exception erro)
            {
                _logger.LogError($"Carrinho/AdicionarQuantidade - {erro.Message} ID de usuário: " +
                    $"{_sessao.UsuarioSessao().IdUsuario}");

                return BadRequest(Global.Mensagem.FalhaBanco);
            }
        }

        [HttpGet]
        public async Task<IActionResult> CalcularFrete(string cep, string servico)
        {
            try
            {
                var lista = new List<Produto>();
                var carrinho = _reposCarrinho.Buscar(_sessao.UsuarioSessao().IdCliente);

                var quantidade = new Dictionary<uint, uint>();

                foreach (var item in carrinho)
                {
                    lista.Add(_reposProduto.Buscar(item.IdProduto));
                    quantidade.Add(item.IdProduto, item.Quantidade);
                }

                return Json(await _reposFrete.CalcularFrete(cep, FreteR.PrepararPacotes(lista, quantidade), servico));
            }
            catch (Exception erro)
            {
                _logger.LogError($"Carrinho/CalcularFrete - {erro.Message} ID de usuário: " +
                    $"{_sessao.UsuarioSessao().IdUsuario}");

                return BadRequest(Global.Mensagem.FalhaBanco);
            }
        }

        [HttpPost]
        public IActionResult NovoItem(uint idProduto)
        {
            try
            {
                var carrinho = new Carrinho
                {
                    IdProduto = idProduto,
                    IdCliente = _sessao.UsuarioSessao().IdCliente,
                    Quantidade = 1
                };

                if (_reposCarrinho.AdicionarItem(carrinho) > 0)
                    return Json(new { });

                return BadRequest(Global.Mensagem.FalhaAdicionar);
            }
            catch (Exception erro)
            {
                _logger.LogError($"Carrinho/NovoItem - {erro.Message} ID de usuário: " +
                   $"{_sessao.UsuarioSessao().IdUsuario}");

                return BadRequest(Global.Mensagem.FalhaBanco);
            }
        }

        [HttpGet]
        public IActionResult RetirarQuantidade(uint id)
        {
            try
            {
                var item = _carrinho.FirstOrDefault(c => c.IdProduto == id);

                if (item.Quantidade > 1)
                {
                    if (_reposCarrinho.Atualizar(item, 2) > 0)
                        return PartialView("_Carrinho", BuscaProdutosCarrinho(_carrinho));
                }
                else if (_reposCarrinho.RemoverItem(item) > 0)
                {
                    _carrinho.Remove(item);
                    return PartialView("_Carrinho", BuscaProdutosCarrinho(_carrinho));
                }

                return BadRequest(Global.Mensagem.FalhaRetirar);
            }
            catch (Exception erro)
            {
                _logger.LogError($"Carrinho/RetirarQuantidade - {erro.Message} ID de usuário: " +
                   $"{_sessao.UsuarioSessao().IdUsuario}");

                return BadRequest(Global.Mensagem.FalhaBanco);
            }
        }

        [HttpGet]
        public IActionResult RemoverItem(uint id)
        {
            try
            {
                var item = _carrinho.FirstOrDefault(c => c.IdProduto == id);

                if (_reposCarrinho.RemoverItem(item) > 0)
                {
                    _carrinho.Remove(item);
                    return PartialView("_Carrinho", BuscaProdutosCarrinho(_carrinho));
                }

                return BadRequest(Global.Mensagem.FalhaRemover);
            }
            catch (Exception erro)
            {
                _logger.LogError($"Carrinho/RemoverItem - {erro.Message} ID de usuário: " +
                   $"{_sessao.UsuarioSessao().IdUsuario}");

                return BadRequest(Global.Mensagem.FalhaBanco);
            }
        }

        public List<Produto> BuscaProdutosCarrinho(List<Carrinho> itens)
        {
            var carrinho = new List<Produto>();

            foreach (var item in itens)
                carrinho.Add(_reposProduto.Buscar(item.IdProduto));

            ViewBag.Quantidade = itens.ToDictionary(i => i.IdProduto, i => i.Quantidade);

            return carrinho;
        }
    }
}