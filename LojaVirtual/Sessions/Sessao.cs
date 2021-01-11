using LojaVirtual.Models.Acesso;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace LojaVirtual.Sessions
{
    public class Sessao
    {
        public static Sessao sessao;
        public static uint IdPerfil;

        private readonly IHttpContextAccessor _context;

        public Sessao(IHttpContextAccessor context)
        {
            _context = context;
        }

        public void Salvar(object valor, string chave)
        {
            _context.HttpContext.Session.SetString(chave, JsonConvert.SerializeObject(valor));
        }

        public string Buscar(string chave)
        {
            return _context.HttpContext.Session.GetString(chave) != null ? 
              JsonConvert.DeserializeObject(_context.HttpContext.Session.GetString(chave)).ToString() : null;
        }

        public void Remover(string chave)
        {
            _context.HttpContext.Session.Remove(chave);
        }

        public void RemoverTodas()
        {
            _context.HttpContext.Session.Clear();
        }

        public Usuario UsuarioSessao()
        {
            return JsonConvert.DeserializeObject<Usuario>
                (_context.HttpContext.Session.GetString("Acesso"));
        }

        public static bool ExisteSessao()
        {
            return sessao.Buscar("Acesso") != null;
        }
    }
}