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

namespace LojaVirtual.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly Sessao _sessao;
        private readonly UsuarioR _reposUsuario;

        public UsuarioController(Sessao sessao, UsuarioR reposUsuario)
        {
            _sessao = sessao;
            _reposUsuario = reposUsuario;
        }

        //Páginas
        public IActionResult Cadastro()
        {
            ViewBag.Estados = new string[]
            {
                "AC", "AL", "AM", "AP", "BA", "CE", "DF", "ES", "GO", "MA",
                "MG", "MS", "MT", "PA", "PB", "PE", "PI", "PR", "RJ", "RN",
                "RO", "RR", "RS", "SC", "SE", "SP", "TO"
            };

            return View(new Usuario { Cliente = new Cliente() });
        }

        [AcessoAutorizacao]
        public IActionResult Lista()
        {
            var lista = _reposUsuario.ListarPaginado();
            return View(lista);
        }

        [AcessoAutorizacao]
        public IActionResult Perfil()
        {
            var usuario = _reposUsuario.Buscar(_sessao.UsuarioSessao().IdUsuario);
            return View(usuario);
        }


        //Operações
        [HttpGet]
        public IActionResult OrdenarLista(int pagina, int quantidade, string pesquisa, byte ordenacao)
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

        [HttpGet]
        public IActionResult PesquisarLista(int pagina, int quantidade, string pesquisa)
        {
            var lista = _reposUsuario.ListarPaginado(pagina, quantidade, pesquisa);
            return PartialView("_Tabela", lista);
        }

        [HttpPost]
        public IActionResult ValidaUsuario(Usuario usuario)
        {
            try
            {
                return Json(_reposUsuario.ValidaEmail(usuario.Email));
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return BadRequest(Mensagem.FalhaBanco);
            }
        }

        [HttpPost]
        public IActionResult Registrar(Usuario usuario)
        {
            try
            {
                if (usuario.Cliente.Endereco.Complemento == null)
                    usuario.Cliente.Endereco.Complemento = "";

                return Json(_reposUsuario.Registrar(usuario));
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return BadRequest(Mensagem.FalhaCadastro);
            }
        }
    }
}
