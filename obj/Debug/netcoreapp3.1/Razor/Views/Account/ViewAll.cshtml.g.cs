#pragma checksum "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\ViewAll.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "62c7781900b86b71e3b2c13efb03141d7f162b31"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_ViewAll), @"mvc.1.0.view", @"/Views/Account/ViewAll.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"62c7781900b86b71e3b2c13efb03141d7f162b31", @"/Views/Account/ViewAll.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b6d3a421415b2ba4f38156738522867e3ff3b7f1", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Account_ViewAll : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Account>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Account", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddAccount", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\ViewAll.cshtml"
  
    ViewData["Title"] = "ViewAll";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>ViewAll</h1>\r\n\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "62c7781900b86b71e3b2c13efb03141d7f162b314119", async() => {
                WriteLiteral("Add New Account");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<table class=\"table table-striped\">\r\n    <tr>\r\n        <th>ID</th>\r\n        <th>Customer ID</th>\r\n        <th>Account Type</th>\r\n        <th>Balance</th>\r\n        <th>Actions</th>\r\n    </tr>\r\n\r\n");
#nullable restore
#line 19 "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\ViewAll.cshtml"
     foreach (Account a in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>   \r\n            <td> ");
#nullable restore
#line 22 "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\ViewAll.cshtml"
            Write(a.ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td> ");
#nullable restore
#line 23 "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\ViewAll.cshtml"
            Write(a.Customer_ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td> ");
#nullable restore
#line 24 "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\ViewAll.cshtml"
            Write(a.Account_Type);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td> ");
#nullable restore
#line 25 "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\ViewAll.cshtml"
            Write(a.Balance);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n            <td>\r\n                ");
#nullable restore
#line 28 "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\ViewAll.cshtml"
           Write(Html.ActionLink("Deposit", "Deposit  ", new { id = @a.Customer_ID}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 29 "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\ViewAll.cshtml"
           Write(Html.ActionLink("Withdraw", "Withdraw  ", new { id = @a.Customer_ID }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 30 "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\ViewAll.cshtml"
           Write(Html.ActionLink("Transfer", "Transfer  ", new { id = @a.Customer_ID }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 33 "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\ViewAll.cshtml"

    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n\r\n");
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