#pragma checksum "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\ViewStatementbyAccID.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b5bad4b03239aaf06157ac9af7e39cf4de3313b9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_ViewStatementbyAccID), @"mvc.1.0.view", @"/Views/Account/ViewStatementbyAccID.cshtml")]
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
#nullable restore
#line 1 "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\_ViewImports.cshtml"
using FinalCaseStudy13;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\_ViewImports.cshtml"
using FinalCaseStudy13.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\ViewStatementbyAccID.cshtml"
using X.PagedList;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b5bad4b03239aaf06157ac9af7e39cf4de3313b9", @"/Views/Account/ViewStatementbyAccID.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b6d3a421415b2ba4f38156738522867e3ff3b7f1", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Account_ViewStatementbyAccID : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<viewmodel3>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/dist/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
#nullable restore
#line 3 "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\ViewStatementbyAccID.cshtml"
  
    ViewData["Title"] = "ViewStatementbyAccID";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"alert-danger text-danger\"><p>");
#nullable restore
#line 9 "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\ViewStatementbyAccID.cshtml"
                                    Write(ViewBag.ErrorMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p></div>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b5bad4b03239aaf06157ac9af7e39cf4de3313b94606", async() => {
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
            WriteLiteral(@"
<button id=""btnPdf"" style=""text-align:left"" class=""btn btn-info"">Download PDF</button>


<div id=""pdfContainer"" style=""text-align:center;"">
    <style>
        table {
            font-family: arial,sans-serif;
            border: 1px solid black;
            border-collapse: collapse;
            width: 100%;
        }

        th {
            background-color: green;
            color: white
        }

        td {
            text-align: center
        }
    </style>

    <h1>Statement</h1>

");
#nullable restore
#line 35 "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\ViewStatementbyAccID.cshtml"
     if (Model != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <table class=""table table-striped"" id=""pdf"">

            <tr>
                <th >Date</th>
                <th >Transaction</th>
                <th >Account(ID-1)</th>
                <th >Account(ID-2)</th>
                <th >Amount</th>
                <th >Account Balance</th>
            </tr>

");
#nullable restore
#line 48 "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\ViewStatementbyAccID.cshtml"
             foreach (viewmodel3 v in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td> ");
#nullable restore
#line 51 "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\ViewStatementbyAccID.cshtml"
                    Write(v.t.TranDate.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td> ");
#nullable restore
#line 52 "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\ViewStatementbyAccID.cshtml"
                    Write(v.t.Transaction_Type);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td> ");
#nullable restore
#line 53 "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\ViewStatementbyAccID.cshtml"
                    Write(v.t.Account_ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td> ");
#nullable restore
#line 54 "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\ViewStatementbyAccID.cshtml"
                    Write(v.t.Account_ID_2);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td> ");
#nullable restore
#line 55 "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\ViewStatementbyAccID.cshtml"
                    Write(v.t.Amount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td> ");
#nullable restore
#line 56 "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\ViewStatementbyAccID.cshtml"
                    Write(v.t.Balance);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 58 "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\ViewStatementbyAccID.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </table>\r\n");
#nullable restore
#line 60 "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\ViewStatementbyAccID.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"  
</div>

<script type=""text/javascript"">
    $(""#btnPdf"").click(function () {
        var sHtml = $(""#pdfContainer"").html();
        sHtml = sHtml.replace(/</g, ""StrTag"").replace(/>/g, ""EndTag"");
        window.open('../Account/generatePDF?html=' + sHtml, '_blank');
    });
</script>
");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<viewmodel3>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
