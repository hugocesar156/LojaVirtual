#pragma checksum "C:\Projetos\Loja Virtual\LojaVirtual\Views\Shared\_Layout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0a1e245ed96a10eec720f7574110f257e2e726ce"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Layout), @"mvc.1.0.view", @"/Views/Shared/_Layout.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_Layout.cshtml", typeof(AspNetCore.Views_Shared__Layout))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Projetos\Loja Virtual\LojaVirtual\Views\_ViewImports.cshtml"
using X.PagedList;

#line default
#line hidden
#line 2 "C:\Projetos\Loja Virtual\LojaVirtual\Views\_ViewImports.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#line 3 "C:\Projetos\Loja Virtual\LojaVirtual\Views\_ViewImports.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#line 4 "C:\Projetos\Loja Virtual\LojaVirtual\Views\_ViewImports.cshtml"
using LojaVirtual.Sessions;

#line default
#line hidden
#line 5 "C:\Projetos\Loja Virtual\LojaVirtual\Views\_ViewImports.cshtml"
using LojaVirtual.Validations;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0a1e245ed96a10eec720f7574110f257e2e726ce", @"/Views/Shared/_Layout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"db735d035cec3189dc33b803c523a739005925cd", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Layout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/bootstrap/css/bootstrap.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/Global/fontawesome/all.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/Global/pagedlist.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/jquery/jquery-3.5.1.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/jquery/plugins/mask/jquery.mask.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/bootstrap/js/bootstrap.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Global/mascara.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Global/perfil.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 25, true);
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n");
            EndContext();
            BeginContext(25, 406, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "18e207a4777a4359b6356a2851c4509c", async() => {
                BeginContext(31, 129, true);
                WriteLiteral("\r\n    <meta charset=\"utf-8\" lang=\"pt-br\" />\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />\r\n\r\n    ");
                EndContext();
                BeginContext(160, 66, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "53c832cf7970423fbee8e2db2d789891", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(226, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(232, 69, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "58290e080d69451dbad3f27f47492d6d", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(301, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(307, 59, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "802da793626a4a038660e85457a7e7bd", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(366, 15, true);
                WriteLiteral("\r\n\r\n    <title>");
                EndContext();
                BeginContext(382, 17, false);
#line 11 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Shared\_Layout.cshtml"
      Write(ViewData["Title"]);

#line default
#line hidden
                EndContext();
                BeginContext(399, 25, true);
                WriteLiteral(" - Loja Virtual</title>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(431, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(433, 4400, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2d30e05d2771408fbdc6b5b6a74c4295", async() => {
                BeginContext(439, 123, true);
                WriteLiteral("\r\n    <nav class=\"navbar navbar-expand-md navbar-light\" style=\"background-color: #ade9eb\">\r\n        <a class=\"navbar-brand\"");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 562, "\"", 598, 1);
#line 15 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 569, Url.Action("Inicio", "Home"), 569, 29, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(599, 406, true);
                WriteLiteral(@">Loja Virtual</a>
        <button class=""navbar-toggler"" type=""button"" data-toggle=""collapse"" data-target=""#navbar"" aria-controls=""navbarSupportedContent"" aria-expanded=""false"" aria-label=""Toggle navigation"">
            <span class=""navbar-toggler-icon""></span>
        </button>

        <div class=""collapse navbar-collapse justify-content-start"" id=""navbar"">
            <ul class=""navbar-nav"">
");
                EndContext();
#line 22 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Shared\_Layout.cshtml"
                 if (Sessao.ExisteSessao() && Sessao.IdPerfil != (uint)Global.Perfil.Cliente)
                {

#line default
#line hidden
                BeginContext(1119, 442, true);
                WriteLiteral(@"                    <li class=""nav-item text-center"">
                        <div class=""dropdown"">
                            <a class=""nav-link"" href=""#"" data-toggle=""dropdown"" aria-haspopup=""true""
                               aria-expanded=""false"" id=""dropdown-produto"">Produtos</a>
                            <div class=""dropdown-menu"" aria-labelledby=""dropdown-produto"">
                                <a class=""dropdown-item""");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 1561, "\"", 1602, 1);
#line 29 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 1568, Url.Action("Cadastro", "Produto"), 1568, 34, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1603, 67, true);
                WriteLiteral(">Novo</a>\r\n                                <a class=\"dropdown-item\"");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 1670, "\"", 1708, 1);
#line 30 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 1677, Url.Action("Lista", "Produto"), 1677, 31, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1709, 108, true);
                WriteLiteral(">Listar</a>\r\n                            </div>\r\n                        </div>\r\n                    </li>\r\n");
                EndContext();
#line 34 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Shared\_Layout.cshtml"
                }

#line default
#line hidden
                BeginContext(1836, 16, true);
                WriteLiteral("                ");
                EndContext();
#line 35 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Shared\_Layout.cshtml"
                 if (Sessao.ExisteSessao())
                {

#line default
#line hidden
                BeginContext(1900, 441, true);
                WriteLiteral(@"                    <li class=""nav-item text-center"">
                        <div class=""dropdown"">
                            <a class=""nav-link"" href=""#"" data-toggle=""dropdown"" aria-haspopup=""true""
                               aria-expanded=""false"" id=""dropdown-produto"">Pedidos</a>
                            <div class=""dropdown-menu"" aria-labelledby=""dropdown-produto"">
                                <a class=""dropdown-item""");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 2341, "\"", 2385, 1);
#line 42 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 2348, Url.Action("ListaCliente", "Pedido"), 2348, 37, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2386, 19, true);
                WriteLiteral(">Meus pedidos</a>\r\n");
                EndContext();
#line 43 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Shared\_Layout.cshtml"
                                 if (Sessao.IdPerfil != (uint)Global.Perfil.Cliente)
                                {

#line default
#line hidden
                BeginContext(2526, 60, true);
                WriteLiteral("                                    <a class=\"dropdown-item\"");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 2586, "\"", 2631, 1);
#line 45 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 2593, Url.Action("ListaVendedor", "Pedido"), 2593, 38, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2632, 16, true);
                WriteLiteral(">Gerenciar</a>\r\n");
                EndContext();
#line 46 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Shared\_Layout.cshtml"
                                }

#line default
#line hidden
                BeginContext(2683, 95, true);
                WriteLiteral("                            </div>\r\n                        </div>\r\n                    </li>\r\n");
                EndContext();
#line 50 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Shared\_Layout.cshtml"
                }

#line default
#line hidden
                BeginContext(2797, 16, true);
                WriteLiteral("                ");
                EndContext();
#line 51 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Shared\_Layout.cshtml"
                 if (Sessao.ExisteSessao() && Sessao.IdPerfil == (uint)Global.Perfil.Administrador)
                {

#line default
#line hidden
                BeginContext(2917, 150, true);
                WriteLiteral("                    <li class=\"nav-item text-center\">\r\n                        <div class=\"dropdown\">\r\n                            <a class=\"nav-link\"");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 3067, "\"", 3105, 1);
#line 55 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 3074, Url.Action("Lista", "Usuario"), 3074, 31, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3106, 96, true);
                WriteLiteral(" id=\"dropdown-produto\">Usuários</a>\r\n                        </div>\r\n                    </li>\r\n");
                EndContext();
#line 58 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Shared\_Layout.cshtml"
                }

#line default
#line hidden
                BeginContext(3221, 35, true);
                WriteLiteral("            </ul>\r\n        </div>\r\n");
                EndContext();
#line 61 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Shared\_Layout.cshtml"
         if (!Sessao.ExisteSessao())
        {

#line default
#line hidden
                BeginContext(3305, 143, true);
                WriteLiteral("            <div class=\"row d-md-block d-none\">\r\n                <div class=\"col\">\r\n                    <a class=\"btn btn-sm btn-outline-light\"");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 3448, "\"", 3485, 1);
#line 65 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 3455, Url.Action("Entrar", "Login"), 3455, 30, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3486, 57, true);
                WriteLiteral(">Entrar</a>\r\n                </div>\r\n            </div>\r\n");
                EndContext();
#line 68 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Shared\_Layout.cshtml"
        }
        else
        {

#line default
#line hidden
                BeginContext(3579, 125, true);
                WriteLiteral("            <div class=\"row\">\r\n                <div class=\"col\">\r\n                    <a class=\"btn btn-sm btn-outline-light\"");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 3704, "\"", 3742, 1);
#line 73 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 3711, Url.Action("Menu", "Carrinho"), 3711, 31, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3743, 662, true);
                WriteLiteral(@"><i class=""fa fa-shopping-cart""></i></a>
                </div>
                <div class=""col"">
                    <div class=""btn-group dropdown"">
                        <button type=""button"" class=""btn btn-outline-light btn-sm dropdown-toggle"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                            <i class=""fa fa-user""></i> Conta
                        </button>
                        <div class=""dropdown-menu"">
                            <a class=""dropdown-item"" href=""#"" id=""btn-perfil"" data-toggle=""modal"" data-target=""#modal-perfil"">Perfil</a>
                            <a class=""dropdown-item""");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 4405, "\"", 4440, 1);
#line 82 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 4412, Url.Action("Sair", "Login"), 4412, 28, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(4441, 115, true);
                WriteLiteral(">Sair</a>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
                EndContext();
#line 87 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Shared\_Layout.cshtml"
        }

#line default
#line hidden
                BeginContext(4567, 69, true);
                WriteLiteral("    </nav>\r\n\r\n    <div class=\"container mt-3 body-content\">\r\n        ");
                EndContext();
                BeginContext(4637, 12, false);
#line 91 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Shared\_Layout.cshtml"
   Write(RenderBody());

#line default
#line hidden
                EndContext();
                BeginContext(4649, 12, true);
                WriteLiteral("\r\n\r\n        ");
                EndContext();
                BeginContext(4662, 34, false);
#line 93 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Shared\_Layout.cshtml"
   Write(await Html.PartialAsync("_Perfil"));

#line default
#line hidden
                EndContext();
                BeginContext(4696, 60, true);
                WriteLiteral("\r\n        <footer class=\"text-center mt-5\">\r\n            <p>");
                EndContext();
                BeginContext(4757, 17, false);
#line 95 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Shared\_Layout.cshtml"
          Write(DateTime.Now.Year);

#line default
#line hidden
                EndContext();
                BeginContext(4774, 52, true);
                WriteLiteral(" - Loja Virtual</p>\r\n        </footer>\r\n    </div>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4833, 13, true);
            WriteLiteral("\r\n</html>\r\n\r\n");
            EndContext();
            BeginContext(4846, 52, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9f3e247518e0449bb3885ae676b20f91", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4898, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(4900, 64, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "695f2c235b0b44bf8c9e823ee8932bb6", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4964, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(4966, 55, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c52775530bc44738972da6c9d385ca6b", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5021, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(5023, 46, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f7ee59fb7c5e4f8ea17cf0243ea040c1", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5069, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(5071, 45, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a285e37ac610418c9447334eed8f5e77", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
