using LojaVirtual.Models.Produto;
using LojaVirtual.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LojaVirtual.Controllers
{
    public class ImagemController : Controller
    {
        private readonly ImagemR _reposImagem;

        public ImagemController (ImagemR reposImagem)
        {
            _reposImagem = reposImagem;
        }

        [HttpPost]
        public JsonResult Carregar(IFormFile arquivo)
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
                Console.WriteLine(erro);
                return Json(null);
            }
        }

        [HttpPost]
        public JsonResult Descartar(string arquivo)
        {
            try
            {
                if (!string.IsNullOrEmpty(arquivo))
                {
                    var nomeArquivo = Path.GetFileName(arquivo);
                    var caminho = $"wwwroot/images/produto/0/{nomeArquivo}";

                    ImagemR.RemoveImagem(caminho);
                    return Json(true);
                }

                return Json(false);
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return Json(false);
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
                    var imagem = lista.Where(i => i.Caminho == caminho).FirstOrDefault();

                    ImagemR.RemoveImagem(caminho);
                    lista.Remove(imagem);

                    if (_reposImagem.Remover(imagem) > 0)
                        return PartialView("Views/Produto/_Imagens.cshtml", lista);
                }

                return BadRequest();
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Salvar(string arquivo, string idProduto)
        {
            try
            {
                var lista = new List<Imagem>();

                if (!string.IsNullOrEmpty(arquivo))
                {
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
                            lista = _reposImagem.BuscaLista(Convert.ToUInt32(idProduto));
                            return PartialView("Views/Produto/_Imagens.cshtml", lista);
                        }
                    }
                }

                lista = _reposImagem.BuscaLista(Convert.ToUInt32(idProduto));
                return PartialView("Views/Produto/_Imagens.cshtml", lista);
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return BadRequest();
            }
        }
    }
}
