#pragma checksum "C:\Users\49549303837\Documents\Senai\projetos\HTML_CSS\ponto-digital-SENAI\Views\Home\Pacotes.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "95534435f1520f51c0827ce93f566401d4f77db4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Pacotes), @"mvc.1.0.view", @"/Views/Home/Pacotes.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Pacotes.cshtml", typeof(AspNetCore.Views_Home_Pacotes))]
namespace AspNetCore
{
    #line hidden
    using System;
#line 2 "C:\Users\49549303837\Documents\Senai\projetos\HTML_CSS\ponto-digital-SENAI\Views\Home\Pacotes.cshtml"
using System.Collections.Generic;

#line default
#line hidden
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\49549303837\Documents\Senai\projetos\HTML_CSS\ponto-digital-SENAI\Views\_ViewImports.cshtml"
using ponto_digital_final;

#line default
#line hidden
#line 2 "C:\Users\49549303837\Documents\Senai\projetos\HTML_CSS\ponto-digital-SENAI\Views\_ViewImports.cshtml"
using ponto_digital_final.Models;

#line default
#line hidden
#line 1 "C:\Users\49549303837\Documents\Senai\projetos\HTML_CSS\ponto-digital-SENAI\Views\Home\Pacotes.cshtml"
using ponto_digital_SENAI.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"95534435f1520f51c0827ce93f566401d4f77db4", @"/Views/Home/Pacotes.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c88f4ec5ce12793661cd7598b37bc2f4f50333e", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Pacotes : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(73, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\Users\49549303837\Documents\Senai\projetos\HTML_CSS\ponto-digital-SENAI\Views\Home\Pacotes.cshtml"
  
ViewData["TituloPag"] = "Pacotes";

#line default
#line hidden
            BeginContext(118, 640, true);
            WriteLiteral(@"<section class=""introd"">
    <h2>Pacotes</h2>
    <p> A  A empresa digital de e-commerce Ponto Digital possui diversos planos acessíveis, Lorem ipsum, dolor
                sit amet consectetur adipisicing elit. Minus laborum vero sapiente incidunt a. Iusto
                odit dolore necessitatibus.Ppellendus dicta officia nulla cum impedit iure architecto
                dolore soluta provident, fazendo com que os clientes fiquem satisfeitos!!  A empresa digital de 
                e-commerce Ponto Digital possui diversos planos acessíveis.s!</p>
</section>
<section class=""lista_pacotes"">
    <div class=""conj_box flex"">
");
            EndContext();
#line 17 "C:\Users\49549303837\Documents\Senai\projetos\HTML_CSS\ponto-digital-SENAI\Views\Home\Pacotes.cshtml"
         foreach(var item in ViewData["pacotes"] as List<Pacote>){
            


#line default
#line hidden
            BeginContext(842, 61, true);
            WriteLiteral("        <div class=\"pac_box\">\r\n            \r\n            <h3>");
            EndContext();
            BeginContext(904, 11, false);
#line 22 "C:\Users\49549303837\Documents\Senai\projetos\HTML_CSS\ponto-digital-SENAI\Views\Home\Pacotes.cshtml"
           Write(item.Titulo);

#line default
#line hidden
            EndContext();
            BeginContext(915, 21, true);
            WriteLiteral("</h3>\r\n            \r\n");
            EndContext();
#line 24 "C:\Users\49549303837\Documents\Senai\projetos\HTML_CSS\ponto-digital-SENAI\Views\Home\Pacotes.cshtml"
                 if(item.QuantFuncionarios > 500){

#line default
#line hidden
            BeginContext(988, 221, true);
            WriteLiteral("                    <ul>\r\n                    <h4>Valor a definir</h4>\r\n                    <li>\r\n                        <p>Quantidade de funcionarios a definir</p>\r\n                    </li>\r\n                    </ul>\r\n");
            EndContext();
#line 31 "C:\Users\49549303837\Documents\Senai\projetos\HTML_CSS\ponto-digital-SENAI\Views\Home\Pacotes.cshtml"
                }else{


#line default
#line hidden
            BeginContext(1235, 18, true);
            WriteLiteral("            <h4>R$");
            EndContext();
            BeginContext(1254, 10, false);
#line 33 "C:\Users\49549303837\Documents\Senai\projetos\HTML_CSS\ponto-digital-SENAI\Views\Home\Pacotes.cshtml"
             Write(item.Preco);

#line default
#line hidden
            EndContext();
            BeginContext(1264, 25, true);
            WriteLiteral("</h4>\r\n            <ul>\r\n");
            EndContext();
#line 35 "C:\Users\49549303837\Documents\Senai\projetos\HTML_CSS\ponto-digital-SENAI\Views\Home\Pacotes.cshtml"
                 if(item.ID == 0){
                

#line default
#line hidden
            BeginContext(1343, 167, true);
            WriteLiteral("                <li>\r\n                    <p>Período de teste: 1 mês</p>\r\n                </li>\r\n                <li>\r\n                    <p>-Tempo de suporte em até ");
            EndContext();
            BeginContext(1511, 17, false);
#line 41 "C:\Users\49549303837\Documents\Senai\projetos\HTML_CSS\ponto-digital-SENAI\Views\Home\Pacotes.cshtml"
                                           Write(item.TempoSuporte);

#line default
#line hidden
            EndContext();
            BeginContext(1528, 36, true);
            WriteLiteral(" horas!</p>\r\n                </li>\r\n");
            EndContext();
#line 43 "C:\Users\49549303837\Documents\Senai\projetos\HTML_CSS\ponto-digital-SENAI\Views\Home\Pacotes.cshtml"

                }else{

#line default
#line hidden
            BeginContext(1590, 190, true);
            WriteLiteral("                <li>\r\n                        <p>Quantidade de funcionarios a definir</p>\r\n                    </li>\r\n                <li>\r\n                    <p>Quantidade de funcionarios ");
            EndContext();
            BeginContext(1781, 22, false);
#line 49 "C:\Users\49549303837\Documents\Senai\projetos\HTML_CSS\ponto-digital-SENAI\Views\Home\Pacotes.cshtml"
                                             Write(item.QuantFuncionarios);

#line default
#line hidden
            EndContext();
            BeginContext(1803, 99, true);
            WriteLiteral("</p>\r\n                </li>\r\n                <li>\r\n                    <p>-Tempo de suporte em até ");
            EndContext();
            BeginContext(1903, 17, false);
#line 52 "C:\Users\49549303837\Documents\Senai\projetos\HTML_CSS\ponto-digital-SENAI\Views\Home\Pacotes.cshtml"
                                           Write(item.TempoSuporte);

#line default
#line hidden
            EndContext();
            BeginContext(1920, 36, true);
            WriteLiteral(" horas!</p>\r\n                </li>\r\n");
            EndContext();
#line 54 "C:\Users\49549303837\Documents\Senai\projetos\HTML_CSS\ponto-digital-SENAI\Views\Home\Pacotes.cshtml"
                }

#line default
#line hidden
            BeginContext(1975, 19, true);
            WriteLiteral("            </ul>\r\n");
            EndContext();
#line 56 "C:\Users\49549303837\Documents\Senai\projetos\HTML_CSS\ponto-digital-SENAI\Views\Home\Pacotes.cshtml"

                }

#line default
#line hidden
            BeginContext(2015, 119, true);
            WriteLiteral("                \r\n            <a class=\"comprar\" onclick=\'alert(\"Compra solicitada\")\'>Comprar</a>\r\n            </div>\r\n");
            EndContext();
#line 61 "C:\Users\49549303837\Documents\Senai\projetos\HTML_CSS\ponto-digital-SENAI\Views\Home\Pacotes.cshtml"
                }

#line default
#line hidden
            BeginContext(2153, 26, true);
            WriteLiteral("        </div>\r\n</section>");
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
