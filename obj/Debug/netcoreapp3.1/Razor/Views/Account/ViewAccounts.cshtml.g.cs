#pragma checksum "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\ViewAccounts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "50bb6ef0973d75b0507edba0abf8e516a3308d71"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_ViewAccounts), @"mvc.1.0.view", @"/Views/Account/ViewAccounts.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"50bb6ef0973d75b0507edba0abf8e516a3308d71", @"/Views/Account/ViewAccounts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b6d3a421415b2ba4f38156738522867e3ff3b7f1", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Account_ViewAccounts : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Account>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\ViewAccounts.cshtml"
  
    ViewData["Title"] = "ViewAccounts";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>All Accounts</h1>

<div class=""text-center"">
    <table class=""table table-striped"">
        <tr>
            <th>Account ID</th>
            <th>Customer ID</th>
            <th>Account type</th>
            <th>Balance</th>
        </tr>
");
#nullable restore
#line 17 "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\ViewAccounts.cshtml"
         foreach (Account a in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>   \r\n                <td>");
#nullable restore
#line 20 "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\ViewAccounts.cshtml"
               Write(a.ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 21 "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\ViewAccounts.cshtml"
               Write(a.Customer_ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 22 "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\ViewAccounts.cshtml"
               Write(a.Account_Type);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 23 "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\ViewAccounts.cshtml"
               Write(a.Balance);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                \r\n\r\n            </tr>\r\n");
#nullable restore
#line 27 "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\ViewAccounts.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Account>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
