#pragma checksum "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\DeleteAccount.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "48e811933d7c59f078eb181a2062763553f3f5da"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_DeleteAccount), @"mvc.1.0.view", @"/Views/Account/DeleteAccount.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"48e811933d7c59f078eb181a2062763553f3f5da", @"/Views/Account/DeleteAccount.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b6d3a421415b2ba4f38156738522867e3ff3b7f1", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Account_DeleteAccount : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Account>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Account", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ViewModel2", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteAccount", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\DeleteAccount.cshtml"
  
    ViewData["Title"] = "DeleteAccount";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Delete Account</h1>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "48e811933d7c59f078eb181a2062763553f3f5da5093", async() => {
                WriteLiteral(@"
    <table class=""table table-striped"">


        <tr>
            <th>ID</th>
            <th>Customer ID</th>
            <th>Account Type</th>
            <th>Status</th>
            <th>Last Updated</th>
            <th>Balance</th>
        </tr>

        <tr>

            <td>
                ");
#nullable restore
#line 24 "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\DeleteAccount.cshtml"
           Write(Model.ID);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                ");
#nullable restore
#line 25 "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\DeleteAccount.cshtml"
           Write(Html.HiddenFor(a => a.ID));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n            </td>\r\n\r\n            <td>\r\n                ");
#nullable restore
#line 30 "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\DeleteAccount.cshtml"
           Write(Model.Customer_ID);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                ");
#nullable restore
#line 31 "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\DeleteAccount.cshtml"
           Write(Html.HiddenFor(a => a.Customer_ID));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n            </td>\r\n\r\n\r\n            <td>\r\n                ");
#nullable restore
#line 37 "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\DeleteAccount.cshtml"
           Write(Model.Account_Type);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                ");
#nullable restore
#line 38 "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\DeleteAccount.cshtml"
           Write(Html.HiddenFor(a => a.Account_Type));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </td>\r\n\r\n\r\n            <td>\r\n                ");
#nullable restore
#line 43 "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\DeleteAccount.cshtml"
           Write(Model.Account_Status);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                ");
#nullable restore
#line 44 "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\DeleteAccount.cshtml"
           Write(Html.HiddenFor(a => a.Account_Status));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </td>\r\n\r\n\r\n            <td>\r\n                ");
#nullable restore
#line 49 "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\DeleteAccount.cshtml"
           Write(Model.Status_Last_Updated);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                ");
#nullable restore
#line 50 "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\DeleteAccount.cshtml"
           Write(Html.HiddenFor(a => a.Status_Last_Updated));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </td>\r\n\r\n\r\n            <td>\r\n                ");
#nullable restore
#line 55 "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\DeleteAccount.cshtml"
           Write(Model.Balance);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                ");
#nullable restore
#line 56 "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\DeleteAccount.cshtml"
           Write(Html.HiddenFor(a => a.Balance));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </td>\r\n        </tr>\r\n\r\n\r\n    </table>\r\n\r\n    <input type=\"submit\" value=\"Confirm Delete\" class=\"btn btn-info\" />\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "48e811933d7c59f078eb181a2062763553f3f5da9666", async() => {
                    WriteLiteral("Cancel");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n    <div class=\"alert-danger\"><p>");
#nullable restore
#line 66 "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\DeleteAccount.cshtml"
                            Write(ViewBag.M2);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p></div>\r\n    <div class=\"alert-dismissible text-success\"><p>");
#nullable restore
#line 67 "D:\TATA\Training sessions\Assignments\CaseStudy13\FinalCaseStudy13\FinalCaseStudy13\Views\Account\DeleteAccount.cshtml"
                                              Write(ViewBag.M3);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p></div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Account> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
