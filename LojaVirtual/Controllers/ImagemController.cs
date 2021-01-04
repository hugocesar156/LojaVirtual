using LojaVirtual.Models.Produto;
using LojaVirtual.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LojaVirtual.Authorizations;
using System;
using System.IO;
using System.Linq;
using LojaVirtual.Sessions;
using Microsoft.Extensions.Logging;
using LojaVirtual.Validations;

namespace LojaVirtual.Controllers
{
    [AcessoAutorizacao]
    public class ImagemController : Controller
    {
        private readonly Sessao _sessao;
        private readonly ILogger<ImagemController> _logger;

        private readonly ImagemR _reposImagem;

        public ImagemController (Sessao sessao, ILogger<ImagemController> logger, ImagemR reposImagem)
        {
            _sessao = sessao;
            _logger = logger;

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
                }

                return Json($"/images/produto/0/{arquivo.FileName}");
            }
            catch (Exception erro)
            {
                _logger.LogError($"Imagem/Carregar - {erro.Message} ID de usuário: " +
                    $"{_sessao.UsuarioSessao().IdUsuario}");

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
                _logger.LogError($"Imagem/Descartar - {erro.Message} ID de usuário: " +
                   $"{_sessao.UsuarioSessao().IdUsuario}");

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
                        return PartialView("Views/Produto/_Imagens.cshtml", lista);
                }

                return BadRequest(Global.Mensagem.ArquivoNaoEncontrado);
            }
            catch (Exception erro)
            {
                _logger.LogError($"Imagem/Remover - {erro.Message} ID de usuário: " +
                   $"{_sessao.UsuarioSessao().IdUsuario}");

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
                        var lista = _reposImagem.BuscaLista(Convert.ToUInt32(idProduto));
                        return PartialView("Views/Produto/_Imagens.cshtml", lista);
                    }
                }

                return BadRequest(Global.Mensagem.FalhaSalvarImagem);
            }
            catch (Exception erro)
            {
                _logger.LogError($"Imagem/Salvar - {erro.Message} ID de usuário: " +
                   $"{_sessao.UsuarioSessao().IdUsuario}");

                return BadRequest(Global.Mensagem.FalhaBanco);
            }
        }
    }
}