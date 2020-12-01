using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace Rastreamento.Sessions
{
    public class Cookie
    {
        private readonly IHttpContextAccessor _context;

        public Cookie(IHttpContextAccessor context)
        {
            _context = context;
        }

        public void Adicionar(string chave, object valor)
        {
            var json = JsonConvert.SerializeObject(valor);

            _context.HttpContext.Response.Cookies
               .Append(chave, json, new CookieOptions { Expires = DateTime.Now.AddDays(7) });
        }

        public string Buscar(string chave)
        {
            return _context.HttpContext.Request.Cookies[chave] != null ?
                JsonConvert.DeserializeObject(_context.HttpContext.Request.Cookies[chave]).ToString() : string.Empty;
        }

        public void Remover(string chave)
        {
            _context.HttpContext.Response.Cookies.Delete(chave);
        }

        public void RemoverTodos()
        {
            var lista = _context.HttpContext.Request.Cookies.ToList();

            foreach (var cookie in lista)
                Remover(cookie.Key);
        }
    }
}