#pragma checksum "C:\Users\OLGA\Desktop\Semestr 5\AR OPRO\ExpenseTracker\ExpenseTracker.Web\Views\PlannedExpense\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b7b4477a363f625da8871a6aaf833d278bcd9cff"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PlannedExpense_Index), @"mvc.1.0.view", @"/Views/PlannedExpense/Index.cshtml")]
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
#line 1 "C:\Users\OLGA\Desktop\Semestr 5\AR OPRO\ExpenseTracker\ExpenseTracker.Web\Views\_ViewImports.cshtml"
using ExpenseTracker.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\OLGA\Desktop\Semestr 5\AR OPRO\ExpenseTracker\ExpenseTracker.Web\Views\_ViewImports.cshtml"
using ExpenseTracker.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b7b4477a363f625da8871a6aaf833d278bcd9cff", @"/Views/PlannedExpense/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b59da65c9c3834155e83771c130d349b9c285377", @"/Views/_ViewImports.cshtml")]
    public class Views_PlannedExpense_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ExpenseTracker.Application.ViewModels.PlannedExpense.PlannedExpensesOfAllMainCatVm>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("background-color: #565ee4; margin-top:10px; margin-bottom:10px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PlanExpensesPerMonth", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("margin-right:13px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\OLGA\Desktop\Semestr 5\AR OPRO\ExpenseTracker\ExpenseTracker.Web\Views\PlannedExpense\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1 style=\"margin-top:50px; margin-bottom:50px;\">Zestawienie budżetu i wydatków</h1>\r\n\r\n<h3>\r\n    ");
#nullable restore
#line 10 "C:\Users\OLGA\Desktop\Semestr 5\AR OPRO\ExpenseTracker\ExpenseTracker.Web\Views\PlannedExpense\Index.cshtml"
Write(Model.MonthOfYear.ToString("MMMM yyyy").ToUpper());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</h3>\r\n");
#nullable restore
#line 12 "C:\Users\OLGA\Desktop\Semestr 5\AR OPRO\ExpenseTracker\ExpenseTracker.Web\Views\PlannedExpense\Index.cshtml"
 if (Model.Count > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <table class=""table"">
        <thead style=""background-color:#d0d2d7;"">
            <tr>
                <th>
                    Kategoria
                </th>
                <th>
                    Zaplanowane wydatki
                </th>
                <th>
                    Aktualnie wydano
                </th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 29 "C:\Users\OLGA\Desktop\Semestr 5\AR OPRO\ExpenseTracker\ExpenseTracker.Web\Views\PlannedExpense\Index.cshtml"
             foreach (var item in Model.PlannedExpOfMainCat)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 33 "C:\Users\OLGA\Desktop\Semestr 5\AR OPRO\ExpenseTracker\ExpenseTracker.Web\Views\PlannedExpense\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 36 "C:\Users\OLGA\Desktop\Semestr 5\AR OPRO\ExpenseTracker\ExpenseTracker.Web\Views\PlannedExpense\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.PlannedAmount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 39 "C:\Users\OLGA\Desktop\Semestr 5\AR OPRO\ExpenseTracker\ExpenseTracker.Web\Views\PlannedExpense\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.SpentAmount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 42 "C:\Users\OLGA\Desktop\Semestr 5\AR OPRO\ExpenseTracker\ExpenseTracker.Web\Views\PlannedExpense\Index.cshtml"
                   Write(Html.ActionLink("Pokaż szczegóły", "GetPlannedExpensesOfMainCategory", new { monthOfYear=Model.MonthOfYear, mainCategoryId=item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 45 "C:\Users\OLGA\Desktop\Semestr 5\AR OPRO\ExpenseTracker\ExpenseTracker.Web\Views\PlannedExpense\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 48 "C:\Users\OLGA\Desktop\Semestr 5\AR OPRO\ExpenseTracker\ExpenseTracker.Web\Views\PlannedExpense\Index.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b7b4477a363f625da8871a6aaf833d278bcd9cff9119", async() => {
                WriteLiteral("Zaplanuj wydatki");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-monthOfYear", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 52 "C:\Users\OLGA\Desktop\Semestr 5\AR OPRO\ExpenseTracker\ExpenseTracker.Web\Views\PlannedExpense\Index.cshtml"
                                                                                                                                                     WriteLiteral(Model.MonthOfYear);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["monthOfYear"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-monthOfYear", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["monthOfYear"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </p>\r\n    <p>Brak zaplanowanych wydatków na ten miesiąc...</p>\r\n");
#nullable restore
#line 55 "C:\Users\OLGA\Desktop\Semestr 5\AR OPRO\ExpenseTracker\ExpenseTracker.Web\Views\PlannedExpense\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b7b4477a363f625da8871a6aaf833d278bcd9cff11954", async() => {
                WriteLiteral("Poprzedni miesiąc");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-monthOfYear", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 58 "C:\Users\OLGA\Desktop\Semestr 5\AR OPRO\ExpenseTracker\ExpenseTracker.Web\Views\PlannedExpense\Index.cshtml"
                                                                                       WriteLiteral(Model.MonthOfYear.AddMonths(-1));

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["monthOfYear"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-monthOfYear", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["monthOfYear"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b7b4477a363f625da8871a6aaf833d278bcd9cff14421", async() => {
                WriteLiteral("Następny miesiąc");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-monthOfYear", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 59 "C:\Users\OLGA\Desktop\Semestr 5\AR OPRO\ExpenseTracker\ExpenseTracker.Web\Views\PlannedExpense\Index.cshtml"
                                                             WriteLiteral(Model.MonthOfYear.AddMonths(1));

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["monthOfYear"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-monthOfYear", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["monthOfYear"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ExpenseTracker.Application.ViewModels.PlannedExpense.PlannedExpensesOfAllMainCatVm> Html { get; private set; }
    }
}
#pragma warning restore 1591
