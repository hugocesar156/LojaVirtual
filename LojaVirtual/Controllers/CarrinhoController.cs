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
using LojaVirtual.Validations;
using Serilog;

namespace LojaVirtual.Controllers
{
    [Autorizacao.AcessoAutorizacao]
    public class CarrinhoController : Controller
    {
        private readonly Sessao _sessao;

        private readonly ProdutoR _reposProduto;
        private readonly CarrinhoR _reposCarrinho;
        private readonly FreteR _reposFrete;
        private readonly ClienteR _reposCliente;

        public CarrinhoController(Sessao sessao, ProdutoR reposProduto, CarrinhoR reposCarrinho, 
            FreteR reposFrete, ClienteR reposCliente)
        {
            _sessao = sessao;

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

                ViewBag.Quantidade = carrinho.ToDictionary(i => i.IdProduto, i => i.Quantidade);

                ViewBag.Endereco = _reposCliente.BuscaEndereco(_sessao.UsuarioSessao().IdCliente);
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
                GerarLogErro(erro, (byte)Global.Entidade.Carrinho, (byte)Global.Acao.Visualizar);
                throw new Exception(Global.Mensagem.FalhaBanco);
            }
        }


        //Operações
        [HttpGet]
        public IActionResult AdicionarQuantidade(uint id)
        {
            try
            {
                var carrinho = _reposCarrinho.Buscar(_sessao.UsuarioSessao().IdCliente);
                var item = carrinho.FirstOrDefault(c => c.IdProduto == id);

                if (_reposProduto.Buscar(id).Estoque > item.Quantidade)
                {
                    if (_reposCarrinho.Atualizar(item, 1) > 0)
                        return PartialView("_Carrinho", BuscaProdutosCarrinho(carrinho));
                }

                return BadRequest(Global.Mensagem.SemEstoque);
            }
            catch (Exception erro)
            {
                GerarLogErro(erro, (byte)Global.Entidade.Carrinho, (byte)Global.Acao.Editar);
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
                GerarLogErro(erro, (byte)Global.Entidade.Carrinho, (byte)Global.Acao.Visualizar);
                return BadRequest(Global.Mensagem.FalhaBanco);
            }
        }

        [HttpPost]
        public IActionResult NovoItem(uint idProduto)
        {
            try
            {
                if (_reposCarrinho.ItemAdicionado(_sessao.UsuarioSessao().IdCliente, idProduto))
                    return Json(new { });

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
                GerarLogErro(erro, (byte)Global.Entidade.Carrinho, (byte)Global.Acao.Inserir);
                return BadRequest(Global.Mensagem.FalhaBanco);
            }
        }

        [HttpGet]
        public IActionResult RetirarQuantidade(uint id)
        {
            try
            {
                var carrinho = _reposCarrinho.Buscar(_sessao.UsuarioSessao().IdCliente);
                var item = carrinho.FirstOrDefault(c => c.IdProduto == id);

                if (item.Quantidade > 1)
                {
                    if (_reposCarrinho.Atualizar(item, 2) > 0)
                        return PartialView("_Carrinho", BuscaProdutosCarrinho(carrinho));
                }
                else if (_reposCarrinho.RemoverItem(item) > 0)
                    return PartialView("_Carrinho", BuscaProdutosCarrinho(carrinho));

                return BadRequest(Global.Mensagem.FalhaRetirar);
            }
            catch (Exception erro)
            {
                GerarLogErro(erro, (byte)Global.Entidade.Carrinho, (byte)Global.Acao.Editar);
                return BadRequest(Global.Mensagem.FalhaBanco);
            }
        }

        [HttpGet]
        public IActionResult RemoverItem(uint id)
        {
            try
            {
                var carrinho = _reposCarrinho.Buscar(_sessao.UsuarioSessao().IdCliente);
                var item = carrinho.FirstOrDefault(c => c.IdProduto == id);

                if (_reposCarrinho.RemoverItem(item) > 0)
                {
                    carrinho.Remove(item);

                    if (carrinho.Count() > 0)
                        return PartialView("_Carrinho", BuscaProdutosCarrinho(carrinho));

                    return Json(null);
                }

                return BadRequest(Global.Mensagem.FalhaRemover);
            }
            catch (Exception erro)
            {
                GerarLogErro(erro, (byte)Global.Entidade.Carrinho, (byte)Global.Acao.Remover);
                return BadRequest(Global.Mensagem.FalhaBanco);
            }
        }

        public List<Produto> BuscaProdutosCarrinho(List<Carrinho> carrinho)
        {
            var produtos = new List<Produto>();

            foreach (var item in carrinho)
                produtos.Add(_reposProduto.Buscar(item.IdProduto));

            ViewBag.Quantidade = carrinho.ToDictionary(i => i.IdProduto, i => i.Quantidade);

            return produtos;
        }

        public void GerarLogErro(Exception erro, byte entidade, byte acao)
        {
            Log.ForContext("Usuario", Convert.ToString(_sessao.UsuarioSessao().IdUsuario))
                       .ForContext("Entidade", entidade).ForContext("Acao", acao).Error(erro, "");
        }
    }
}