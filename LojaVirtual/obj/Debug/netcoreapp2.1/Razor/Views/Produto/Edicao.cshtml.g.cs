#pragma checksum "C:\Projetos\Loja Virtual\LojaVirtual\Views\Produto\Edicao.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ce67b5d6f416c41a8d05cfbdcb6feb3e3d7fbea6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Produto_Edicao), @"mvc.1.0.view", @"/Views/Produto/Edicao.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Produto/Edicao.cshtml", typeof(AspNetCore.Views_Produto_Edicao))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ce67b5d6f416c41a8d05cfbdcb6feb3e3d7fbea6", @"/Views/Produto/Edicao.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"68d2072dd14da1bd32ce19021c2028f21b13d598", @"/Views/_ViewImports.cshtml")]
    public class Views_Produto_Edicao : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LojaVirtual.Models.Produto.Produto>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("descricao"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("maxlength", new global::Microsoft.AspNetCore.Html.HtmlString("150"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onchange", new global::Microsoft.AspNetCore.Html.HtmlString("ValidaCampo(this)"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("form-cadastro"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Produto/validacao.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.TextAreaTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_TextAreaTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(43, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Produto\Edicao.cshtml"
  
    ViewData["Title"] = "Edição de produto";

#line default
#line hidden
            BeginContext(98, 67, true);
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h4>Edição de produto</h4>\r\n\r\n    ");
            EndContext();
            BeginContext(165, 7043, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0861faf7cb904276a46a4bdd0388d289", async() => {
                BeginContext(214, 46, true);
                WriteLiteral("\r\n        <input type=\"hidden\" id=\"id-produto\"");
                EndContext();
                BeginWriteAttribute("value", "  value=\"", 260, "\"", 285, 1);
#line 11 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Produto\Edicao.cshtml"
WriteAttributeValue("", 269, Model.IdProduto, 269, 16, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(286, 254, true);
                WriteLiteral(" />\r\n        <div class=\"row justify-content-center text-center text-md-left mt-4\">\r\n            <div class=\"col-10 col-md-6 col-xl-5\">\r\n                <label>Nome</label>\r\n                <input id=\"nome\" type=\"text\" class=\"form-control\" maxlength=\"30\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 540, "\"", 559, 1);
#line 15 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Produto\Edicao.cshtml"
WriteAttributeValue("", 548, Model.Nome, 548, 11, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(560, 374, true);
                WriteLiteral(@" onchange=""ValidaCampo(this)"" />
                <div id=""nome"" class=""invalid-feedback""></div>
            </div>
            <div class=""col-8 col-md-4 col-xl-3 text-center text-md-left mt-4 mt-md-0"">
                <label>Categoria</label>
                <select id=""categoria"" class=""custom-select form-control"" onchange=""ValidaCampo(this)"">
                    ");
                EndContext();
                BeginContext(934, 48, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0abea7ae131040519becebfd1290daeb", async() => {
                    BeginContext(951, 22, true);
                    WriteLiteral("Selecione uma opção...");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(982, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 22 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Produto\Edicao.cshtml"
                     foreach (var item in ViewBag.Categorias)
                    {
                        if (item.Key == Model.IdCategoria)
                        {

#line default
#line hidden
                BeginContext(1157, 28, true);
                WriteLiteral("                            ");
                EndContext();
                BeginContext(1185, 55, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6e5d838177ee4827893542d8378dc6f9", async() => {
                    BeginContext(1221, 10, false);
#line 26 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Produto\Edicao.cshtml"
                                                          Write(item.Value);

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 26 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Produto\Edicao.cshtml"
                               WriteLiteral(item.Key);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
                BeginContext(1240, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 27 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Produto\Edicao.cshtml"
                        }
                        else
                        {

#line default
#line hidden
                BeginContext(1326, 28, true);
                WriteLiteral("                            ");
                EndContext();
                BeginContext(1354, 46, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aabb6b290c0d46d6a8573dd21cfaa7cb", async() => {
                    BeginContext(1381, 10, false);
#line 30 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Produto\Edicao.cshtml"
                                                 Write(item.Value);

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 30 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Produto\Edicao.cshtml"
                               WriteLiteral(item.Key);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1400, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 31 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Produto\Edicao.cshtml"
                        }
                    }

#line default
#line hidden
                BeginContext(1452, 253, true);
                WriteLiteral("                </select>\r\n            </div>\r\n        </div>\r\n        <div class=\"row justify-content-center mt-4\">\r\n            <div class=\"col-10 col-md-6 col-xl-5 text-center text-md-left\">\r\n                <label>Descrição</label>\r\n                ");
                EndContext();
                BeginContext(1705, 122, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("textarea", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "13581195511c476cbb0665b4b19346bb", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_TextAreaTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.TextAreaTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_TextAreaTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
#line 39 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Produto\Edicao.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_TextAreaTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Descricao);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_TextAreaTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1827, 542, true);
                WriteLiteral(@"
                <div id=""descricao"" class=""invalid-feedback""></div>
            </div>
            <div class=""col-4 col-md-3 col-xl-2 text-left mt-4 mt-md-0"">
                <label>Valor</label>
                <div class=""input-group"">
                    <div class=""input-group-prepend"">
                        <div class=""input-group-text"">R$</div>
                    </div>
                    <input id=""valor"" type=""text"" class=""form-control real"" style=""text-align: center""
                           placeholder=""0,00""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2369, "\"", 2404, 1);
#line 49 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Produto\Edicao.cshtml"
WriteAttributeValue("", 2377, Model.Valor.ToString("N2"), 2377, 27, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2405, 423, true);
                WriteLiteral(@" onchange=""ValidaValor(this)"" />
                    <div id=""valor"" class=""invalid-feedback msg-valor""></div>
                </div>
            </div>
            <div class=""col-4 col-md-3 col-xl-2 text-left mt-4 mt-md-0"">
                <label>Qtd.estoque</label>
                <input id=""estoque"" type=""text"" class=""form-control quantidade""
                       placeholder=""000"" style=""text-align: center""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2828, "\"", 2850, 1);
#line 56 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Produto\Edicao.cshtml"
WriteAttributeValue("", 2836, Model.Estoque, 2836, 14, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2851, 407, true);
                WriteLiteral(@" onchange=""ValidaValor(this)"" />
                <div id=""estoque"" class=""invalid-feedback msg-valor""></div>
            </div>
        </div>
        <div class=""row mt-4 justify-content-center"">
            <div class=""col-8 col-md-4 col-xl-3 text-center text-md-left"">
                <label>Fabricante</label>
                <input id=""fabricante"" type=""text"" class=""form-control"" maxlength=""25""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 3258, "\"", 3283, 1);
#line 63 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Produto\Edicao.cshtml"
WriteAttributeValue("", 3266, Model.Fabricante, 3266, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3284, 334, true);
                WriteLiteral(@" onchange=""ValidaCampo(this)"" />
                <div id=""fabricante"" class=""invalid-feedback""></div>
            </div>
            <div class=""col-8 col-md-4 col-xl-3 text-center text-md-left mt-3 mt-md-0"">
                <label>Modelo</label>
                <input id=""modelo"" type=""text"" class=""form-control"" maxlength=""25""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 3618, "\"", 3639, 1);
#line 68 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Produto\Edicao.cshtml"
WriteAttributeValue("", 3626, Model.Modelo, 3626, 13, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3640, 324, true);
                WriteLiteral(@" onchange=""ValidaCampo(this)"" />
                <div id=""modelo"" class=""invalid-feedback""></div>
            </div>
            <div class=""col-8 col-md-4 col-xl-3 text-center text-md-left mt-3 mt-md-0"">
                <label>Cor</label>
                <input id=""cor"" type=""text"" class=""form-control"" maxlength=""20""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 3964, "\"", 3982, 1);
#line 73 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Produto\Edicao.cshtml"
WriteAttributeValue("", 3972, Model.Cor, 3972, 10, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3983, 478, true);
                WriteLiteral(@" onchange=""ValidaCampo(this)"" />
                <div id=""cor"" class=""invalid-feedback""></div>
            </div>
        </div>
        <div class=""row justify-content-center mt-4"">
            <div class=""col-4 col-md-3 col-xl-2 text-left"">
                <label>Largura</label>
                <div class=""input-group"">
                    <input id=""largura"" type=""text"" class=""form-control cm"" style=""text-align: center""
                           placeholder=""0""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 4461, "\"", 4483, 1);
#line 82 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Produto\Edicao.cshtml"
WriteAttributeValue("", 4469, Model.Largura, 4469, 14, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(4484, 594, true);
                WriteLiteral(@" onchange=""ValidaLargura()"" />
                    <div class=""input-group-prepend"">
                        <div class=""input-group-text"">cm</div>
                    </div>
                    <div id=""largura"" class=""invalid-feedback msg-largura""></div>
                </div>
            </div>
            <div class=""col-4 col-md-3 col-xl-2 text-left"">
                <label>Altura</label>
                <div class=""input-group"">
                    <input id=""altura"" type=""text"" class=""form-control cm"" style=""text-align: center""
                           placeholder=""0""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 5078, "\"", 5099, 1);
#line 93 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Produto\Edicao.cshtml"
WriteAttributeValue("", 5086, Model.Altura, 5086, 13, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(5100, 601, true);
                WriteLiteral(@" onchange=""ValidaAltura()"" />
                    <div class=""input-group-prepend"">
                        <div class=""input-group-text"">cm</div>
                    </div>
                    <div id=""altura"" class=""invalid-feedback msg-altura""></div>
                </div>
            </div>
            <div class=""col-4 col-md-3 col-xl-2 text-left"">
                <label>Comprimento</label>
                <div class=""input-group"">
                    <input id=""comprimento"" type=""text"" class=""form-control cm"" style=""text-align: center""
                           placeholder=""0""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 5701, "\"", 5727, 1);
#line 104 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Produto\Edicao.cshtml"
WriteAttributeValue("", 5709, Model.Comprimento, 5709, 18, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(5728, 637, true);
                WriteLiteral(@" onchange=""ValidaComprimento()"" />
                    <div class=""input-group-prepend"">
                        <div class=""input-group-text"">cm</div>
                    </div>
                    <div id=""comprimento"" class=""invalid-feedback msg-comprimento""></div>
                </div>
            </div>
            <div class=""col-4 col-md-3 col-xl-2 ml-xl-4 text-lg-left mt-3 mt-md-0 mt-xl-0"">
                <label>Peso</label>
                <div class=""input-group"">
                    <input id=""peso"" type=""text"" class=""form-control kg"" style=""text-align: center""
                           placeholder=""0,00""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 6365, "\"", 6399, 1);
#line 115 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Produto\Edicao.cshtml"
WriteAttributeValue("", 6373, Model.Peso.ToString("N2"), 6373, 26, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(6400, 386, true);
                WriteLiteral(@" onchange=""ValidaPeso()"" />
                    <div class=""input-group-prepend"">
                        <div class=""input-group-text"">Kg</div>
                    </div>
                    <div id=""cor"" class=""invalid-feedback msg-peso""></div>
                </div>
            </div>
        </div>
        <div class=""row justify-content-center mt-5 mb-3"">
            <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 6786, "\"", 6855, 1);
#line 124 "C:\Projetos\Loja Virtual\LojaVirtual\Views\Produto\Edicao.cshtml"
WriteAttributeValue("", 6793, Url.Action("Imagem", "Produto", new { id = Model.IdProduto }), 6793, 62, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(6856, 345, true);
                WriteLiteral(@" class=""btn btn-outline-success col-6 col-sm-5 col-md-3"" 
                    style=""border-radius: 5px 0px 0px 5px;"">Imagem</a>
            <button class=""btn btn-outline-success col-6 col-sm-5 col-md-3"" type=""button"" 
                    style=""border-radius: 0px 5px 5px 0px;"" onclick=""ValidaEdicao()"">Salvar</button>
        </div>
    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(7208, 12, true);
            WriteLiteral("\r\n</div>\r\n\r\n");
            EndContext();
            BeginContext(7220, 49, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1d5bd9042aef403597f8797a9283f0d4", async() => {
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LojaVirtual.Models.Produto.Produto> Html { get; private set; }
    }
}
#pragma warning restore 1591
