#pragma checksum "f:\Projetos_Git\ponto-digital-SENAI\Views\Dashboard\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "021159858e02f72a878d51bc765411c7511750e5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Dashboard_Index), @"mvc.1.0.view", @"/Views/Dashboard/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Dashboard/Index.cshtml", typeof(AspNetCore.Views_Dashboard_Index))]
namespace AspNetCore
{
    #line hidden
    using System;
#line 2 "f:\Projetos_Git\ponto-digital-SENAI\Views\Dashboard\Index.cshtml"
using System.Collections.Generic;

#line default
#line hidden
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "f:\Projetos_Git\ponto-digital-SENAI\Views\_ViewImports.cshtml"
using ponto_digital_final;

#line default
#line hidden
#line 2 "f:\Projetos_Git\ponto-digital-SENAI\Views\_ViewImports.cshtml"
using ponto_digital_final.Models;

#line default
#line hidden
#line 1 "f:\Projetos_Git\ponto-digital-SENAI\Views\Dashboard\Index.cshtml"
using ponto_digital_SENAI.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"021159858e02f72a878d51bc765411c7511750e5", @"/Views/Dashboard/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c88f4ec5ce12793661cd7598b37bc2f4f50333e", @"/Views/_ViewImports.cshtml")]
    public class Views_Dashboard_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(72, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 5 "f:\Projetos_Git\ponto-digital-SENAI\Views\Dashboard\Index.cshtml"
  
ViewData["TituloPag"] = "Dashboard";
var user = (Usuario) ViewData["Usuario"];
List<Usuario> users = ViewData["usuarios"] as List<Usuario>;
List<Depoimento> depoimentos = ViewData["depoimentos"] as List<Depoimento>;
int contadorPendentes = 0;

#line default
#line hidden
            BeginContext(331, 36, true);
            WriteLiteral("\r\n                <h2>Bem vindo(a), ");
            EndContext();
            BeginContext(368, 9, false);
#line 13 "f:\Projetos_Git\ponto-digital-SENAI\Views\Dashboard\Index.cshtml"
                             Write(user.Nome);

#line default
#line hidden
            EndContext();
            BeginContext(377, 137, true);
            WriteLiteral("</h2>\r\n                <div class=\"flex divider\">\r\n                    <div class=\"unflex\">\r\n                        <p class=\"contador\">");
            EndContext();
            BeginContext(515, 11, false);
#line 16 "f:\Projetos_Git\ponto-digital-SENAI\Views\Dashboard\Index.cshtml"
                                       Write(users.Count);

#line default
#line hidden
            EndContext();
            BeginContext(526, 102, true);
            WriteLiteral("</p>\r\n                        <p class=\"titulo\">Usuarios cadastrados</p>\r\n                    </div>\r\n");
            EndContext();
#line 19 "f:\Projetos_Git\ponto-digital-SENAI\Views\Dashboard\Index.cshtml"
                     foreach(var item in depoimentos){
                    if(item.Status == 'e'){
                    contadorPendentes++;
                    }
                    }

#line default
#line hidden
            BeginContext(817, 86, true);
            WriteLiteral("                    <div class=\"unflex\">\r\n                        <p class=\"contador\">");
            EndContext();
            BeginContext(904, 17, false);
#line 25 "f:\Projetos_Git\ponto-digital-SENAI\Views\Dashboard\Index.cshtml"
                                       Write(contadorPendentes);

#line default
#line hidden
            EndContext();
            BeginContext(921, 129, true);
            WriteLiteral("</p>\r\n                        <p class=\"titulo\">Depoimentos pendentes</p>\r\n                    </div>\r\n\r\n\r\n                </div>");
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
