#pragma checksum "C:\Projetos\Loja Virtual\LojaVirtual\Views\Pedido\ListaVendedor.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c80c7c584a2f155b53d859a5563d55f57c113c86"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pedido_ListaVendedor), @"mvc.1.0.view", @"/Views/Pedido/ListaVendedor.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Pedido/ListaVendedor.cshtml", typeof(AspNetCore.Views_Pedido_ListaVendedor))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c80c7c584a2f155b53d859a5563d55f57c113c86", @"/Views/Pedido/ListaVendedor.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"db735d035cec3189dc33b803c523a739005925cd", @"/Views/_ViewImports.cshtml")]
    public class Views_Pedido_ListaVendedor : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IPagedList<LojaVirtual.Models.Venda.ProdutoHistorico>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "10", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "25", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "50", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "100", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(62, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Pedido\ListaVendedor.cshtml"
  
    ViewData["Title"] = "Produtos em pedidos";

#line default
#line hidden
            BeginContext(119, 386, true);
            WriteLiteral(@"
<div class=""text-center"">
    <h4>Produtos em pedidos</h4>

    <div class=""row mt-3 text-right"">
        <div class=""col-9 text-left"">
            <small>
                <strong>
                    <label>Registros por página:</label>
                </strong>
            </small>
            <select class=""ml-2"" id=""quantidade"" onchange=""Pesquisa()"">
                ");
            EndContext();
            BeginContext(505, 39, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c481277cb77c447788af1091581e9499", async() => {
                BeginContext(533, 2, true);
                WriteLiteral("10");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(544, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(562, 30, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "607beebd8483462a98b3b732191db946", async() => {
                BeginContext(581, 2, true);
                WriteLiteral("25");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(592, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(610, 30, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bb130546fba64f699aa27e17f6a73da4", async() => {
                BeginContext(629, 2, true);
                WriteLiteral("50");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(640, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(658, 32, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "24cac63786fd4c9bb0eff3a5c8eeaf3b", async() => {
                BeginContext(678, 3, true);
                WriteLiteral("100");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(690, 258, true);
            WriteLiteral(@"
            </select>
        </div>
        <div class=""col-3"">
            <input class=""form-control"" type=""text"" id=""pesquisa"" name=""pesquisa""
                   placeholder=""Pesquise aqui..."" onkeyup=""Pesquisa()"" />
        </div>
    </div>

");
            EndContext();
#line 30 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Pedido\ListaVendedor.cshtml"
     if (Model.Count > 0)
    {

#line default
#line hidden
            BeginContext(982, 679, true);
            WriteLiteral(@"        <div class=""table-responsive shadow mt-4"" style=""overflow-y: scroll; height: 400px;"">
            <table id=""cabecalho"" class=""table table-hover"">
                <thead class=""cabecalho"" style=""background-color: #f7f3f3;"">
                    <tr>
                        <th scope=""col"">Número do pedido</th>
                        <th scope=""col"">Data de pedido</th>
                        <th scope=""col"">Produto</th>
                        <th scope=""col"">Quantidade</th>
                        <th scope=""col"">Valor total</th>
                        <th scope=""col""></th>
                    </tr>
                </thead>
                <tbody>
");
            EndContext();
#line 45 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Pedido\ListaVendedor.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
            BeginContext(1734, 74, true);
            WriteLiteral("                        <tr>\r\n                            <td width=\"100\">");
            EndContext();
            BeginContext(1809, 23, false);
#line 48 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Pedido\ListaVendedor.cshtml"
                                       Write(item.Pedido.IdTransacao);

#line default
#line hidden
            EndContext();
            BeginContext(1832, 1, true);
            WriteLiteral("-");
            EndContext();
            BeginContext(1834, 20, false);
#line 48 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Pedido\ListaVendedor.cshtml"
                                                                Write(item.Pedido.IdPedido);

#line default
#line hidden
            EndContext();
            BeginContext(1854, 51, true);
            WriteLiteral("</td>\r\n                            <td width=\"100\">");
            EndContext();
            BeginContext(1906, 43, false);
#line 49 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Pedido\ListaVendedor.cshtml"
                                       Write(item.Pedido.DataCriacao.ToShortDateString());

#line default
#line hidden
            EndContext();
            BeginContext(1949, 51, true);
            WriteLiteral("</td>\r\n                            <td width=\"100\">");
            EndContext();
            BeginContext(2001, 9, false);
#line 50 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Pedido\ListaVendedor.cshtml"
                                       Write(item.Nome);

#line default
#line hidden
            EndContext();
            BeginContext(2010, 51, true);
            WriteLiteral("</td>\r\n                            <td width=\"100\">");
            EndContext();
            BeginContext(2062, 15, false);
#line 51 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Pedido\ListaVendedor.cshtml"
                                       Write(item.Quantidade);

#line default
#line hidden
            EndContext();
            BeginContext(2077, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 52 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Pedido\ListaVendedor.cshtml"
                              var total = item.Valor * item.Quantidade;

#line default
#line hidden
            BeginContext(2158, 44, true);
            WriteLiteral("                            <td width=\"100\">");
            EndContext();
            BeginContext(2203, 19, false);
#line 53 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Pedido\ListaVendedor.cshtml"
                                       Write(total.ToString("C"));

#line default
#line hidden
            EndContext();
            BeginContext(2222, 86, true);
            WriteLiteral("</td>\r\n                            <td width=\"50\">\r\n                                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2308, "\"", 2387, 1);
#line 55 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Pedido\ListaVendedor.cshtml"
WriteAttributeValue("", 2315, Url.Action("Gerenciar", "Pedido", new { id = item.IdProdutoHistorico }), 2315, 72, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2388, 142, true);
            WriteLiteral(" class=\"btn btn-sm btn-outline-info\"><i class=\"fa fa-info-circle\"></i></a>\r\n                            </td>\r\n                        </tr>\r\n");
            EndContext();
#line 58 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Pedido\ListaVendedor.cshtml"
                    }

#line default
#line hidden
            BeginContext(2553, 64, true);
            WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n");
            EndContext();
#line 62 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Pedido\ListaVendedor.cshtml"
    }
    else
    {

#line default
#line hidden
            BeginContext(2641, 43, true);
            WriteLiteral("        <p>Nenhum registro encontrado</p>\r\n");
            EndContext();
#line 66 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Pedido\ListaVendedor.cshtml"
    }

#line default
#line hidden
            BeginContext(2691, 34, true);
            WriteLiteral("    <div class=\"text-left mt-3\">\r\n");
            EndContext();
#line 68 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Pedido\ListaVendedor.cshtml"
         if (Model.PageCount > 0)
        {

#line default
#line hidden
            BeginContext(2771, 183, true);
            WriteLiteral("            <div class=\"row\">\r\n                <div class=\"col\">\r\n                    <small>\r\n                        <strong>\r\n                            Página <label id=\"pagina\">");
            EndContext();
            BeginContext(2955, 16, false);
#line 74 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Pedido\ListaVendedor.cshtml"
                                                 Write(Model.PageNumber);

#line default
#line hidden
            EndContext();
            BeginContext(2971, 65, true);
            WriteLiteral("</label> de\r\n                            <label id=\"num-paginas\">");
            EndContext();
            BeginContext(3037, 15, false);
#line 75 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Pedido\ListaVendedor.cshtml"
                                               Write(Model.PageCount);

#line default
#line hidden
            EndContext();
            BeginContext(3052, 413, true);
            WriteLiteral(@"</label>
                        </strong>
                    </small>
                </div>
                <div class=""col text-right"">
                    <a href=""#cabecalho"">Topo da lista</a>
                </div>
            </div>
            <div class=""row"">
                <div class=""col"">
                    <small class=""justify-content-end"">
                        <strong>Total de ");
            EndContext();
            BeginContext(3466, 20, false);
#line 86 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Pedido\ListaVendedor.cshtml"
                                    Write(Model.TotalItemCount);

#line default
#line hidden
            EndContext();
            BeginContext(3486, 95, true);
            WriteLiteral(" registros</strong>\r\n                    </small>\r\n                </div>\r\n            </div>\r\n");
            EndContext();
#line 90 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Pedido\ListaVendedor.cshtml"
        }

#line default
#line hidden
            BeginContext(3592, 30, true);
            WriteLiteral("\r\n        <div class=\"mt-3\">\r\n");
            EndContext();
#line 93 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Pedido\ListaVendedor.cshtml"
             if (Model.PageNumber > 2)
            {

#line default
#line hidden
            BeginContext(3677, 178, true);
            WriteLiteral("                <button class=\"btn btn-sm btn-primary mr-2\" type=\"button\"\r\n                        onclick=\"AlterarPagina(1)\">\r\n                    1\r\n                </button>\r\n");
            EndContext();
#line 99 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Pedido\ListaVendedor.cshtml"
            }

#line default
#line hidden
            BeginContext(3870, 12, true);
            WriteLiteral("            ");
            EndContext();
#line 100 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Pedido\ListaVendedor.cshtml"
             if (Model.PageNumber > 1)
            {

#line default
#line hidden
            BeginContext(3925, 123, true);
            WriteLiteral("                <button class=\"btn btn-sm btn-primary\" type=\"button\"\r\n                        onclick=\"AlterarPagina(2)\">\r\n");
            EndContext();
#line 104 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Pedido\ListaVendedor.cshtml"
                       var anterior = Model.PageNumber - 1;

#line default
#line hidden
            BeginContext(4108, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(4110, 8, false);
#line 104 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Pedido\ListaVendedor.cshtml"
                                                        Write(anterior);

#line default
#line hidden
            EndContext();
            BeginContext(4118, 29, true);
            WriteLiteral("\r\n                </button>\r\n");
            EndContext();
#line 106 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Pedido\ListaVendedor.cshtml"
            }

#line default
#line hidden
            BeginContext(4162, 12, true);
            WriteLiteral("            ");
            EndContext();
#line 107 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Pedido\ListaVendedor.cshtml"
             if (Model.PageCount > 0)
            {

#line default
#line hidden
            BeginContext(4216, 101, true);
            WriteLiteral("                <button class=\"btn btn-outline-primary\" type=\"button\" disabled>\r\n                    ");
            EndContext();
            BeginContext(4318, 16, false);
#line 110 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Pedido\ListaVendedor.cshtml"
               Write(Model.PageNumber);

#line default
#line hidden
            EndContext();
            BeginContext(4334, 29, true);
            WriteLiteral("\r\n                </button>\r\n");
            EndContext();
#line 112 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Pedido\ListaVendedor.cshtml"
            }

#line default
#line hidden
            BeginContext(4378, 12, true);
            WriteLiteral("            ");
            EndContext();
#line 113 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Pedido\ListaVendedor.cshtml"
             if (Model.PageNumber < Model.PageCount)
            {

#line default
#line hidden
            BeginContext(4447, 123, true);
            WriteLiteral("                <button class=\"btn btn-sm btn-primary\" type=\"button\"\r\n                        onclick=\"AlterarPagina(3)\">\r\n");
            EndContext();
#line 117 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Pedido\ListaVendedor.cshtml"
                       var proximo = Model.PageNumber + 1;

#line default
#line hidden
            BeginContext(4629, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(4631, 7, false);
#line 117 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Pedido\ListaVendedor.cshtml"
                                                       Write(proximo);

#line default
#line hidden
            EndContext();
            BeginContext(4638, 29, true);
            WriteLiteral("\r\n                </button>\r\n");
            EndContext();
#line 119 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Pedido\ListaVendedor.cshtml"
            }

#line default
#line hidden
            BeginContext(4682, 12, true);
            WriteLiteral("            ");
            EndContext();
#line 120 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Pedido\ListaVendedor.cshtml"
             if (Model.PageNumber < Model.PageCount - 1)
            {

#line default
#line hidden
            BeginContext(4755, 148, true);
            WriteLiteral("                <button class=\"btn btn-sm btn-primary ml-2\" type=\"button\"\r\n                        onclick=\"AlterarPagina(4)\">\r\n                    ");
            EndContext();
            BeginContext(4904, 15, false);
#line 124 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Pedido\ListaVendedor.cshtml"
               Write(Model.PageCount);

#line default
#line hidden
            EndContext();
            BeginContext(4919, 29, true);
            WriteLiteral("\r\n                </button>\r\n");
            EndContext();
#line 126 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Pedido\ListaVendedor.cshtml"
            }

#line default
#line hidden
            BeginContext(4963, 34, true);
            WriteLiteral("        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IPagedList<LojaVirtual.Models.Venda.ProdutoHistorico>> Html { get; private set; }
    }
}
#pragma warning restore 1591
