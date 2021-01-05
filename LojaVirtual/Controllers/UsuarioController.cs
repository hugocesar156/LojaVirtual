using System;
using Microsoft.AspNetCore.Mvc;
using LojaVirtual.Models.Acesso;
using LojaVirtual.Models.Cliente;
using LojaVirtual.Repositories;
using LojaVirtual.Authorizations;
using LojaVirtual.Sessions;
using LojaVirtual.Validations;
using X.PagedList;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace LojaVirtual.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly Sessao _sessao;
        private readonly ILogger<UsuarioController> _logger;

        private readonly UsuarioR _reposUsuario;

        public UsuarioController(Sessao sessao, ILogger<UsuarioController> logger, UsuarioR reposUsuario)
        {
            _sessao = sessao;
            _logger = logger;

            _reposUsuario = reposUsuario;
        }

        //Páginas
        public IActionResult Cadastro()
        {
            try
            {
                ViewBag.Estados = new string[]
                {
                    "AC", "AL", "AM", "AP", "BA", "CE", "DF", "ES", "GO", "MA",
                    "MG", "MS", "MT", "PA", "PB", "PE", "PI", "PR", "RJ", "RN",
                    "RO", "RR", "RS", "SC", "SE", "SP", "TO"
                };

                return View(new Usuario { Cliente = new Cliente() });
            }
            catch (Exception erro)
            {
                _logger.LogError($"Usuario/Cadastro - {erro.Message} ID de usuário: " +
                  $"{_sessao.UsuarioSessao().IdUsuario}");

                throw new Exception(Global.Mensagem.FalhaBanco);
            }
        }

        [AcessoAutorizacao]
        public IActionResult Lista()
        {
            try
            {
                var lista = _reposUsuario.ListarPaginado();
                return View(lista);
            }
            catch (Exception erro)
            {
                _logger.LogError($"Usuario/Lista - {erro.Message} ID de usuário: " +
                 $"{_sessao.UsuarioSessao().IdUsuario}");

                throw new Exception(Global.Mensagem.FalhaBanco);
            }
        }

        [AcessoAutorizacao]
        public IActionResult Perfil()
        {
            try
            {
                var usuario = _reposUsuario.Buscar(_sessao.UsuarioSessao().IdUsuario);
                return View(usuario);
            }
            catch (Exception erro)
            {
                _logger.LogError($"Usuario/Perfil - {erro.Message} ID de usuário: " +
                $"{_sessao.UsuarioSessao().IdUsuario}");

                throw new Exception(Global.Mensagem.FalhaBanco);
            }
        }


        //Operações
        [HttpGet]
        public IActionResult OrdenarLista(int pagina, int quantidade, string pesquisa, byte ordenacao)
        {
            try
            {
                var lista = _reposUsuario.Listar(pesquisa);

                switch (ordenacao)
                {
                    case 1:
                        return PartialView("_Tabela", lista.OrderBy(u => u.Cliente.Nome).ToPagedList(pagina, quantidade));

                    case 2:
                        return PartialView("_Tabela", lista.OrderBy(u => u.Cliente.Contato[0].Numero).ToPagedList(pagina, quantidade));

                    case 3:
                        return PartialView("_Tabela", lista.OrderBy(u => u.Email).ToPagedList(pagina, quantidade));

                    case 4:
                        return PartialView("_Tabela", lista.OrderBy(u => u.Cliente.Cpf).ToPagedList(pagina, quantidade));

                    default:
                        return PartialView("_Tabela", lista.ToPagedList(pagina, quantidade));
                }
            }
            catch (Exception erro)
            {
                _logger.LogError($"Usuario/OrdenarLista - {erro.Message} ID de usuário: " +
                $"{_sessao.UsuarioSessao().IdUsuario}");

                return BadRequest(Global.Mensagem.FalhaBanco);
            }
        }

        [HttpGet]
        public IActionResult PesquisarLista(int pagina, int quantidade, string pesquisa)
        {
            try
            {
                var lista = _reposUsuario.ListarPaginado(pagina, quantidade, pesquisa);
                return PartialView("_Tabela", lista);
            }
            catch (Exception erro)
            {
                _logger.LogError($"Usuario/PesquisarLista - {erro.Message} ID de usuário: " +
                $"{_sessao.UsuarioSessao().IdUsuario}");

                return BadRequest(Global.Mensagem.FalhaBanco);
            }
        }

        [HttpPost]
        public IActionResult ValidaUsuario(Usuario usuario)
        {
            try
            {
                if (_reposUsuario.ValidaEmail(usuario.Email))
                    return Json(new { });

                return BadRequest(Global.Mensagem.FalhaEmail);
            }
            catch (Exception erro)
            {
                _logger.LogError($"Usuario/ValidaUsuario - {erro.Message} ID de usuário: " +
               $"{_sessao.UsuarioSessao().IdUsuario}");

                return BadRequest(Global.Mensagem.FalhaBanco);
            }
        }

        [HttpPost]
        public IActionResult Registrar(Usuario usuario)
        {
            try
            {
                usuario.Cliente.Endereco.Complemento = usuario.Cliente.Endereco.Complemento ?? "";

                if (_reposUsuario.Registrar(usuario) > 0)
                    return Json(new { });

                return BadRequest(Global.Mensagem.FalhaCadastro);
            }
            catch (Exception erro)
            {
                _logger.LogError($"Usuario/Registrar - {erro.Message} ID de usuário: " +
               $"{_sessao.UsuarioSessao().IdUsuario}");

                return BadRequest(Global.Mensagem.FalhaBanco);
            }
        }
    }
}