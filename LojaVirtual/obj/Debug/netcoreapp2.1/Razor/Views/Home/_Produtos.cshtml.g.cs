#pragma checksum "C:\Projetos\Loja Virtual\LojaVirtual\Views\Home\_Produtos.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4b43676e0b45fbd29debb349c7329503ca83a7a4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home__Produtos), @"mvc.1.0.view", @"/Views/Home/_Produtos.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/_Produtos.cshtml", typeof(AspNetCore.Views_Home__Produtos))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4b43676e0b45fbd29debb349c7329503ca83a7a4", @"/Views/Home/_Produtos.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"db735d035cec3189dc33b803c523a739005925cd", @"/Views/_ViewImports.cshtml")]
    public class Views_Home__Produtos : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/jquery/jquery-3.5.1.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Home/acoes.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Home/lista.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Home\_Produtos.cshtml"
 if (Model.Count > 0)
{

#line default
#line hidden
            BeginContext(26, 28, true);
            WriteLiteral("    <div class=\"row mt-3\">\r\n");
            EndContext();
#line 4 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Home\_Produtos.cshtml"
         foreach (var produto in Model)
        {
            var imagem = produto.Imagem.Count > 0 ? produto.Imagem[0].Caminho.Replace("wwwroot", "") : "";


#line default
#line hidden
            BeginContext(216, 147, true);
            WriteLiteral("            <div class=\"col-3 mt-5\">\r\n                <div class=\"card\">\r\n                    <div class=\"card-body\">\r\n                        <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 363, "\"", 376, 1);
#line 11 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Home\_Produtos.cshtml"
WriteAttributeValue("", 369, imagem, 369, 7, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(377, 105, true);
            WriteLiteral(" width=\"150\" height=\"150\" />\r\n                        <div class=\"mt-3\">\r\n                            <p>");
            EndContext();
            BeginContext(483, 12, false);
#line 13 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Home\_Produtos.cshtml"
                          Write(produto.Nome);

#line default
#line hidden
            EndContext();
            BeginContext(495, 110, true);
            WriteLiteral("</p>\r\n                            <div class=\"text-left\">\r\n                                <small>Fabricante: ");
            EndContext();
            BeginContext(606, 18, false);
#line 15 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Home\_Produtos.cshtml"
                                              Write(produto.Fabricante);

#line default
#line hidden
            EndContext();
            BeginContext(624, 146, true);
            WriteLiteral("</small>\r\n                            </div>\r\n                            <div class=\"text-left\">\r\n                                <small>Modelo: ");
            EndContext();
            BeginContext(771, 14, false);
#line 18 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Home\_Produtos.cshtml"
                                          Write(produto.Modelo);

#line default
#line hidden
            EndContext();
            BeginContext(785, 216, true);
            WriteLiteral("</small>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"card-footer\">\r\n                        <div class=\"row justify-content-end\">\r\n");
            EndContext();
#line 24 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Home\_Produtos.cshtml"
                             if (Sessao.ExisteSessao())
                            {

#line default
#line hidden
            BeginContext(1089, 95, true);
            WriteLiteral("                                <button class=\"btn btn-outline-primary col-3\" id=\"btn-carrinho\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 1184, "\"", 1230, 3);
            WriteAttributeValue("", 1194, "AdicionaCarrinho(", 1194, 17, true);
#line 26 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Home\_Produtos.cshtml"
WriteAttributeValue("", 1211, produto.IdProduto, 1211, 18, false);

#line default
#line hidden
            WriteAttributeValue("", 1229, ")", 1229, 1, true);
            EndWriteAttribute();
            BeginContext(1231, 47, true);
            WriteLiteral("><i class=\"fa fa-shopping-cart\"></i></button>\r\n");
            EndContext();
#line 27 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Home\_Produtos.cshtml"
                            }
                            else
                            {

#line default
#line hidden
            BeginContext(1374, 72, true);
            WriteLiteral("                                <a class=\"btn btn-outline-primary col-3\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1446, "\"", 1483, 1);
#line 30 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Home\_Produtos.cshtml"
WriteAttributeValue("", 1453, Url.Action("Entrar", "Login"), 1453, 30, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1484, 42, true);
            WriteLiteral("><i class=\"fa fa-shopping-cart\"></i></a>\r\n");
            EndContext();
#line 31 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Home\_Produtos.cshtml"
                            }

#line default
#line hidden
            BeginContext(1557, 104, true);
            WriteLiteral("                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
            EndContext();
#line 36 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Home\_Produtos.cshtml"
        }

#line default
#line hidden
            BeginContext(1672, 12, true);
            WriteLiteral("    </div>\r\n");
            EndContext();
#line 38 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Home\_Produtos.cshtml"
}
else
{

#line default
#line hidden
            BeginContext(1696, 39, true);
            WriteLiteral("    <p>Nenhum registro encontrado</p>\r\n");
            EndContext();
#line 42 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Home\_Produtos.cshtml"
}

#line default
#line hidden
            BeginContext(1738, 32, true);
            WriteLiteral("\r\n<div class=\"text-left mt-3\">\r\n");
            EndContext();
#line 45 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Home\_Produtos.cshtml"
     if (Model.PageCount > 0)
    {

#line default
#line hidden
            BeginContext(1808, 163, true);
            WriteLiteral("        <div class=\"row\">\r\n            <div class=\"col\">\r\n                <small>\r\n                    <strong>\r\n                        Página <label id=\"pagina\">");
            EndContext();
            BeginContext(1972, 16, false);
#line 51 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Home\_Produtos.cshtml"
                                             Write(Model.PageNumber);

#line default
#line hidden
            EndContext();
            BeginContext(1988, 61, true);
            WriteLiteral("</label> de\r\n                        <label id=\"num-paginas\">");
            EndContext();
            BeginContext(2050, 15, false);
#line 52 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Home\_Produtos.cshtml"
                                           Write(Model.PageCount);

#line default
#line hidden
            EndContext();
            BeginContext(2065, 251, true);
            WriteLiteral("</label>\r\n                    </strong>\r\n                </small>\r\n            </div>\r\n        </div>\r\n        <div class=\"row\">\r\n            <div class=\"col\">\r\n                <small class=\"justify-content-end\">\r\n                    <strong>Total de ");
            EndContext();
            BeginContext(2317, 20, false);
#line 60 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Home\_Produtos.cshtml"
                                Write(Model.TotalItemCount);

#line default
#line hidden
            EndContext();
            BeginContext(2337, 83, true);
            WriteLiteral(" registros</strong>\r\n                </small>\r\n            </div>\r\n        </div>\r\n");
            EndContext();
#line 64 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Home\_Produtos.cshtml"
    }

#line default
#line hidden
            BeginContext(2427, 26, true);
            WriteLiteral("\r\n    <div class=\"mt-3\">\r\n");
            EndContext();
#line 67 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Home\_Produtos.cshtml"
         if (Model.PageNumber > 2)
        {

#line default
#line hidden
            BeginContext(2500, 69, true);
            WriteLiteral("            <button class=\"btn btn-sm btn-primary mr-2\" type=\"button\"");
            EndContext();
            BeginWriteAttribute("onclick", "\r\n                    onclick=\"", 2569, "\"", 2641, 4);
            WriteAttributeValue("", 2600, "AlterarPagina(1,", 2600, 16, true);
            WriteAttributeValue(" ", 2616, "\'", 2617, 2, true);
#line 70 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Home\_Produtos.cshtml"
WriteAttributeValue("", 2618, Model[0].IdCategoria, 2618, 21, false);

#line default
#line hidden
            WriteAttributeValue("", 2639, "\')", 2639, 2, true);
            EndWriteAttribute();
            BeginContext(2642, 45, true);
            WriteLiteral(">\r\n                1\r\n            </button>\r\n");
            EndContext();
#line 73 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Home\_Produtos.cshtml"
        }

#line default
#line hidden
            BeginContext(2698, 8, true);
            WriteLiteral("        ");
            EndContext();
#line 74 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Home\_Produtos.cshtml"
         if (Model.PageNumber > 1)
        {

#line default
#line hidden
            BeginContext(2745, 64, true);
            WriteLiteral("            <button class=\"btn btn-sm btn-primary\" type=\"button\"");
            EndContext();
            BeginWriteAttribute("onclick", "\r\n                    onclick=\"", 2809, "\"", 2881, 4);
            WriteAttributeValue("", 2840, "AlterarPagina(2,", 2840, 16, true);
            WriteAttributeValue(" ", 2856, "\'", 2857, 2, true);
#line 77 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Home\_Produtos.cshtml"
WriteAttributeValue("", 2858, Model[0].IdCategoria, 2858, 21, false);

#line default
#line hidden
            WriteAttributeValue("", 2879, "\')", 2879, 2, true);
            EndWriteAttribute();
            BeginContext(2882, 3, true);
            WriteLiteral(">\r\n");
            EndContext();
#line 78 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Home\_Produtos.cshtml"
                   var anterior = Model.PageNumber - 1;

#line default
#line hidden
            BeginContext(2941, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(2943, 8, false);
#line 78 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Home\_Produtos.cshtml"
                                                    Write(anterior);

#line default
#line hidden
            EndContext();
            BeginContext(2951, 25, true);
            WriteLiteral("\r\n            </button>\r\n");
            EndContext();
#line 80 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Home\_Produtos.cshtml"
        }

#line default
#line hidden
            BeginContext(2987, 8, true);
            WriteLiteral("        ");
            EndContext();
#line 81 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Home\_Produtos.cshtml"
         if (Model.PageCount > 0)
        {

#line default
#line hidden
            BeginContext(3033, 93, true);
            WriteLiteral("            <button class=\"btn btn-outline-primary\" type=\"button\" disabled>\r\n                ");
            EndContext();
            BeginContext(3127, 16, false);
#line 84 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Home\_Produtos.cshtml"
           Write(Model.PageNumber);

#line default
#line hidden
            EndContext();
            BeginContext(3143, 25, true);
            WriteLiteral("\r\n            </button>\r\n");
            EndContext();
#line 86 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Home\_Produtos.cshtml"
        }

#line default
#line hidden
            BeginContext(3179, 8, true);
            WriteLiteral("        ");
            EndContext();
#line 87 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Home\_Produtos.cshtml"
         if (Model.PageNumber < Model.PageCount)
        {

#line default
#line hidden
            BeginContext(3240, 64, true);
            WriteLiteral("            <button class=\"btn btn-sm btn-primary\" type=\"button\"");
            EndContext();
            BeginWriteAttribute("onclick", "\r\n                    onclick=\"", 3304, "\"", 3376, 4);
            WriteAttributeValue("", 3335, "AlterarPagina(3,", 3335, 16, true);
            WriteAttributeValue(" ", 3351, "\'", 3352, 2, true);
#line 90 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Home\_Produtos.cshtml"
WriteAttributeValue("", 3353, Model[0].IdCategoria, 3353, 21, false);

#line default
#line hidden
            WriteAttributeValue("", 3374, "\')", 3374, 2, true);
            EndWriteAttribute();
            BeginContext(3377, 3, true);
            WriteLiteral(">\r\n");
            EndContext();
#line 91 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Home\_Produtos.cshtml"
                   var proximo = Model.PageNumber + 1;

#line default
#line hidden
            BeginContext(3435, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(3437, 7, false);
#line 91 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Home\_Produtos.cshtml"
                                                   Write(proximo);

#line default
#line hidden
            EndContext();
            BeginContext(3444, 25, true);
            WriteLiteral("\r\n            </button>\r\n");
            EndContext();
#line 93 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Home\_Produtos.cshtml"
        }

#line default
#line hidden
            BeginContext(3480, 8, true);
            WriteLiteral("        ");
            EndContext();
#line 94 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Home\_Produtos.cshtml"
         if (Model.PageNumber < Model.PageCount - 1)
        {

#line default
#line hidden
            BeginContext(3545, 69, true);
            WriteLiteral("            <button class=\"btn btn-sm btn-primary ml-2\" type=\"button\"");
            EndContext();
            BeginWriteAttribute("onclick", "\r\n                    onclick=\"", 3614, "\"", 3686, 4);
            WriteAttributeValue("", 3645, "AlterarPagina(4,", 3645, 16, true);
            WriteAttributeValue(" ", 3661, "\'", 3662, 2, true);
#line 97 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Home\_Produtos.cshtml"
WriteAttributeValue("", 3663, Model[0].IdCategoria, 3663, 21, false);

#line default
#line hidden
            WriteAttributeValue("", 3684, "\')", 3684, 2, true);
            EndWriteAttribute();
            BeginContext(3687, 19, true);
            WriteLiteral(">\r\n                ");
            EndContext();
            BeginContext(3707, 15, false);
#line 98 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Home\_Produtos.cshtml"
           Write(Model.PageCount);

#line default
#line hidden
            EndContext();
            BeginContext(3722, 25, true);
            WriteLiteral("\r\n            </button>\r\n");
            EndContext();
#line 100 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Home\_Produtos.cshtml"
        }

#line default
#line hidden
            BeginContext(3758, 22, true);
            WriteLiteral("    </div>\r\n</div>\r\n\r\n");
            EndContext();
            BeginContext(3780, 52, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9e8b733648a1448c9a460559e34adba6", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3832, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(3834, 42, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "67381fe1349e4fad9b0e3128a785b722", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3876, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(3878, 42, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0feff7b80aba4ba5b0129f1e1c011cc4", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
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
