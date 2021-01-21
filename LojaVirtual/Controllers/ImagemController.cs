using LojaVirtual.Models.Produto;
using LojaVirtual.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LojaVirtual.Authorizations;
using System;
using System.IO;
using System.Linq;
using LojaVirtual.Sessions;
using LojaVirtual.Validations;
using Serilog;

namespace LojaVirtual.Controllers
{
    [Autorizacao.AcessoAutorizacao]
    public class ImagemController : Controller
    {
        private readonly Sessao _sessao;
        private readonly ImagemR _reposImagem;

        public ImagemController (Sessao sessao, ImagemR reposImagem)
        {
            _sessao = sessao;
            _reposImagem = reposImagem;
        }

        [HttpPost]
        public IActionResult Carregar(IFormFile arquivo)
        {
            try
            {
                if (!string.IsNullOrEmpty(arquivo.FileName))
                {
                    var temp = Directory.GetCurrentDirectory() + $"/wwwroot/images/produto/0";

                    using (var stream = new FileStream($"{temp}/{arquivo.FileName}", FileMode.Create))
                    {
                        arquivo.CopyTo(stream);
                    }
                      
                    return Json($"/images/produto/0/{arquivo.FileName}");
                }

                return BadRequest(Global.Mensagem.ArquivoNaoEncontrado);
            }
            catch (Exception erro)
            {
                GerarLogErro(erro, (byte)Global.Entidade.Produto, (byte)Global.Acao.Visualizar);
                return BadRequest(Global.Mensagem.FalhaCarregarImagem);
            }
        }

        [HttpPost]
        public IActionResult Descartar(string arquivo)
        {
            try
            {
                if (!string.IsNullOrEmpty(arquivo))
                {
                    var nomeArquivo = Path.GetFileName(arquivo);
                    var caminho = $"wwwroot/images/produto/0/{nomeArquivo}";

                    ImagemR.RemoveImagem(caminho);
                    return Json(new { });
                }

                return BadRequest(Global.Mensagem.ArquivoNaoEncontrado);
            }
            catch (Exception erro)
            {
                GerarLogErro(erro, (byte)Global.Entidade.Produto, (byte)Global.Acao.Visualizar);
                return BadRequest(Global.Mensagem.FalhaDescartarImagem);
            }
        }

        [HttpPost]
        public IActionResult Remover(string arquivo, uint id)
        {
            try
            {
                if (!string.IsNullOrEmpty(arquivo))
                {
                    var nomeArquivo = Path.GetFileName(arquivo);
                    var caminho = $"wwwroot/images/produto/{id}/{nomeArquivo}";

                    var lista = _reposImagem.BuscaLista(Convert.ToUInt32(id));
                    var imagem = lista.FirstOrDefault(i => i.Caminho == caminho);

                    ImagemR.RemoveImagem(caminho);
                    lista.Remove(imagem);

                    if (_reposImagem.Remover(imagem) > 0)
                    {
                        GerarLog((byte)Global.Entidade.Produto, (byte)Global.Acao.Remover, id);
                        return PartialView("Views/Produto/_Imagens.cshtml", lista);
                    }
                }

                return BadRequest(Global.Mensagem.ArquivoNaoEncontrado);
            }
            catch (Exception erro)
            {
                GerarLogErro(erro, (byte)Global.Entidade.Produto, (byte)Global.Acao.Remover);
                return BadRequest(Global.Mensagem.FalhaRemoverImagem);
            }
        }

        [HttpPost]
        public IActionResult Salvar(string arquivo, string idProduto)
        {
            try
            {
                if (string.IsNullOrEmpty(arquivo))
                    return BadRequest(Global.Mensagem.ArquivoNaoEncontrado);

                var pastaProduto = Directory.GetCurrentDirectory() + $"/wwwroot/images/produto/{idProduto}";
                if (!Directory.Exists(pastaProduto)) Directory.CreateDirectory(pastaProduto);

                var nomeArquivo = Path.GetFileName(arquivo);

                var temp = Path.Combine(Directory.GetCurrentDirectory(),
                    $"wwwroot/images/produto/0/{nomeArquivo}");

                var destino = $"wwwroot/images/produto/{idProduto}/{nomeArquivo}";

                if (ImagemR.MoveImagem(temp, destino))
                {
                    var imagem = new Imagem { Caminho = destino, IdProduto = Convert.ToUInt32(idProduto) };

                    if (_reposImagem.Inserir(imagem) > 0)
                    {
                        GerarLog((byte)Global.Entidade.Produto, (byte)Global.Acao.Inserir, Convert.ToUInt32(idProduto));

                        var lista = _reposImagem.BuscaLista(Convert.ToUInt32(idProduto));
                        return PartialView("Views/Produto/_Imagens.cshtml", lista);
                    }
                }

                return BadRequest(Global.Mensagem.FalhaSalvarImagem);
            }
            catch (Exception erro)
            {
                GerarLogErro(erro, (byte)Global.Entidade.Produto, (byte)Global.Acao.Remover);
                return BadRequest(Global.Mensagem.FalhaBanco);
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