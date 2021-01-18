using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using LojaVirtual.Sessions;

namespace LojaVirtual.Authorizations
{
    public class Autorizacao
    {
        public class AcessoAutorizacao : Attribute, IAuthorizationFilter
        {
            private Sessao _sessao;

            public void OnAuthorization(AuthorizationFilterContext context)
            {
                _sessao = (Sessao)context.HttpContext.RequestServices.GetService(typeof(Sessao));

                var sessao = _sessao.Buscar("Acesso");

                if (sessao == null)
                    context.Result = new RedirectToActionResult("Entrar", "Login", null);
            }
        }

        public class AnonimoAutorizacao : Attribute, IAuthorizationFilter
        {
            private Sessao _sessao;

            public void OnAuthorization(AuthorizationFilterContext context)
            {
                _sessao = (Sessao)context.HttpContext.RequestServices.GetService(typeof(Sessao));

                var sessao = _sessao.Buscar("Acesso");

                if (sessao != null)
                    context.Result = new RedirectToActionResult("Inicio", "Home", null);
            }
        }
    }
}