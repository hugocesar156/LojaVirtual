#pragma checksum "C:\Projetos\Loja Virtual\LojaVirtual\Views\Shared\_Layout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "60669eafb46a1f77e5e03d5d0f297699ab451ae9"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"60669eafb46a1f77e5e03d5d0f297699ab451ae9", @"/Views/Shared/_Layout.cshtml")]
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1839a357adb3435b8ea971446476d7f6", async() => {
                BeginContext(31, 129, true);
                WriteLiteral("\r\n    <meta charset=\"utf-8\" lang=\"pt-br\" />\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />\r\n\r\n    ");
                EndContext();
                BeginContext(160, 66, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3ef4256cd40447e8a46d0a22299feb3d", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e0d9b15d768d4c00b9fd9aeef8254661", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "dface657a758468ab554a293dbed7dd7", async() => {
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
            BeginContext(433, 4603, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f5dbc3989df3444caad87def05d8788f", async() => {
                BeginContext(439, 98, true);
                WriteLiteral("\r\n    <nav class=\"navbar navbar-expand-md navbar-light bg-light\">\r\n        <a class=\"navbar-brand\"");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 537, "\"", 573, 1);
#line 15 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 544, Url.Action("Inicio", "Home"), 544, 29, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(574, 825, true);
                WriteLiteral(@">Loja Virtual</a>
        <button class=""navbar-toggler"" type=""button"" data-toggle=""collapse"" data-target=""#navbar"" aria-controls=""navbarSupportedContent"" aria-expanded=""false"" aria-label=""Toggle navigation"">
            <span class=""navbar-toggler-icon""></span>
        </button>

        <div class=""collapse navbar-collapse justify-content-center"" id=""navbar"">
            <ul class=""navbar-nav"">
                <li class=""nav-item text-center"">
                    <div class=""dropdown"">
                        <a class=""nav-link"" href=""#"" data-toggle=""dropdown"" aria-haspopup=""true""
                           aria-expanded=""false"" id=""dropdown-produto"">Produtos</a>
                        <div class=""dropdown-menu"" aria-labelledby=""dropdown-produto"">
                            <a class=""dropdown-item""");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 1399, "\"", 1440, 1);
#line 27 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 1406, Url.Action("Cadastro", "Produto"), 1406, 34, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1441, 63, true);
                WriteLiteral(">Novo</a>\r\n                            <a class=\"dropdown-item\"");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 1504, "\"", 1542, 1);
#line 28 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 1511, Url.Action("Lista", "Produto"), 1511, 31, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1543, 514, true);
                WriteLiteral(@">Listar</a>
                        </div>
                    </div>
                </li>
                <li class=""nav-item text-center"">
                    <div class=""dropdown"">
                        <a class=""nav-link"" href=""#"" data-toggle=""dropdown"" aria-haspopup=""true""
                           aria-expanded=""false"" id=""dropdown-produto"">Carrinho</a>
                        <div class=""dropdown-menu"" aria-labelledby=""dropdown-produto"">
                            <a class=""dropdown-item""");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 2057, "\"", 2095, 1);
#line 37 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 2064, Url.Action("Menu", "Carrinho"), 2064, 31, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2096, 596, true);
                WriteLiteral(@">Meu carrinho</a>
                            <a class=""dropdown-item"" href=""#"">Gerenciar</a>
                        </div>
                    </div>
                </li>
                <li class=""nav-item text-center"">
                    <div class=""dropdown"">
                        <a class=""nav-link"" href=""#"" data-toggle=""dropdown"" aria-haspopup=""true""
                           aria-expanded=""false"" id=""dropdown-produto"">Pedidos</a>
                        <div class=""dropdown-menu"" aria-labelledby=""dropdown-produto"">
                            <a class=""dropdown-item""");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 2692, "\"", 2736, 1);
#line 47 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 2699, Url.Action("ListaCliente", "Pedido"), 2699, 37, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2737, 71, true);
                WriteLiteral(">Meus pedidos</a>\r\n                            <a class=\"dropdown-item\"");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 2808, "\"", 2853, 1);
#line 48 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 2815, Url.Action("ListaVendedor", "Pedido"), 2815, 38, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2854, 517, true);
                WriteLiteral(@">Gerenciar</a>
                        </div>
                    </div>
                </li>
                <li class=""nav-item text-center"">
                    <div class=""dropdown"">
                        <a class=""nav-link"" href=""#"" data-toggle=""dropdown"" aria-haspopup=""true""
                           aria-expanded=""false"" id=""dropdown-produto"">Usuários</a>
                        <div class=""dropdown-menu"" aria-labelledby=""dropdown-produto"">
                            <a class=""dropdown-item""");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 3371, "\"", 3412, 1);
#line 57 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 3378, Url.Action("Cadastro", "Usuario"), 3378, 34, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3413, 63, true);
                WriteLiteral(">Novo</a>\r\n                            <a class=\"dropdown-item\"");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 3476, "\"", 3514, 1);
#line 58 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 3483, Url.Action("Lista", "Usuario"), 3483, 31, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3515, 131, true);
                WriteLiteral(">Listar</a>\r\n                        </div>\r\n                    </div>\r\n                </li>\r\n            </ul>\r\n        </div>\r\n");
                EndContext();
#line 64 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Shared\_Layout.cshtml"
         if (!Sessao.ExisteSessao())
        {

#line default
#line hidden
                BeginContext(3695, 138, true);
                WriteLiteral("            <div class=\"row d-md-block d-none\">\r\n                <div class=\"col\">\r\n                    <a class=\"btn btn-outline-primary\"");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 3833, "\"", 3870, 1);
#line 68 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 3840, Url.Action("Entrar", "Login"), 3840, 30, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3871, 56, true);
                WriteLiteral(">Entrar</a>\r\n                    <a class=\"btn btn-link\"");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 3927, "\"", 3968, 1);
#line 69 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 3934, Url.Action("Cadastro", "Usuario"), 3934, 34, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3969, 63, true);
                WriteLiteral(">Registrar-se</a>\r\n                </div>\r\n            </div>\r\n");
                EndContext();
#line 72 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Shared\_Layout.cshtml"
        }
        else
        {

#line default
#line hidden
                BeginContext(4068, 484, true);
                WriteLiteral(@"            <div class=""row"">
                <div class=""col"">
                    <div class=""btn-group dropdown"">
                        <button type=""button"" class=""btn btn-outline-primary dropdown-toggle"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                            <i class=""fa fa-user""></i> Conta
                        </button>
                        <div class=""dropdown-menu"">
                            <a class=""dropdown-item""");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 4552, "\"", 4591, 1);
#line 82 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 4559, Url.Action("Perfil", "Usuario"), 4559, 32, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(4592, 65, true);
                WriteLiteral(">Perfil</a>\r\n                            <a class=\"dropdown-item\"");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 4657, "\"", 4692, 1);
#line 83 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 4664, Url.Action("Sair", "Login"), 4664, 28, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(4693, 115, true);
                WriteLiteral(">Sair</a>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
                EndContext();
#line 88 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Shared\_Layout.cshtml"
        }

#line default
#line hidden
                BeginContext(4819, 67, true);
                WriteLiteral("    </nav>\r\n    <div class=\"container mt-3 body-content\">\r\n        ");
                EndContext();
                BeginContext(4887, 12, false);
#line 91 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Shared\_Layout.cshtml"
   Write(RenderBody());

#line default
#line hidden
                EndContext();
                BeginContext(4899, 60, true);
                WriteLiteral("\r\n        <footer class=\"text-center mt-5\">\r\n            <p>");
                EndContext();
                BeginContext(4960, 17, false);
#line 93 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Shared\_Layout.cshtml"
          Write(DateTime.Now.Year);

#line default
#line hidden
                EndContext();
                BeginContext(4977, 52, true);
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
            BeginContext(5036, 13, true);
            WriteLiteral("\r\n</html>\r\n\r\n");
            EndContext();
            BeginContext(5049, 52, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "45fe7347909d425099d68b587f77667e", async() => {
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
            BeginContext(5101, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(5103, 64, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eebfadab0e4d4218806daa1d7df18a12", async() => {
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
            BeginContext(5167, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(5169, 55, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8ed974bbe2e345b98d6a3387f4ce23d8", async() => {
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
            BeginContext(5224, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(5226, 46, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "178ed6e637b34700a216cace40cc64bd", async() => {
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
