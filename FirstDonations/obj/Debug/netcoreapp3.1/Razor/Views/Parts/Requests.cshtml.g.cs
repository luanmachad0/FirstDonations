#pragma checksum "C:\Users\luan.machado\Documents\FirstDonations\FirstDonations\Views\Parts\Requests.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "46189993d34a547a356615a72eb0babb115e32f3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Parts_Requests), @"mvc.1.0.view", @"/Views/Parts/Requests.cshtml")]
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
#line 1 "C:\Users\luan.machado\Documents\FirstDonations\FirstDonations\Views\_ViewImports.cshtml"
using FirstDonations;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\luan.machado\Documents\FirstDonations\FirstDonations\Views\_ViewImports.cshtml"
using FirstDonations.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"46189993d34a547a356615a72eb0babb115e32f3", @"/Views/Parts/Requests.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7b0bf9a4862914a8447554051a94e7810c322597", @"/Views/_ViewImports.cshtml")]
    public class Views_Parts_Requests : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<FirstDonations.Models.Donation>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("80"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("80"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("border-radius: 50%;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\luan.machado\Documents\FirstDonations\FirstDonations\Views\Parts\Requests.cshtml"
  
    ViewBag.Title = "Requests";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""container"">
    <div class=""modal-dialog"" style=""max-width:1000px;"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h4 class=""modal-title"">Requests</h4>
            </div>
            <div class=""modal-body"">
                <table class=""table"">
                    <thead>
                        <tr>
                            <th>
                                ");
#nullable restore
#line 16 "C:\Users\luan.machado\Documents\FirstDonations\FirstDonations\Views\Parts\Requests.cshtml"
                           Write(Html.DisplayNameFor(model => model.Part.Image));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 19 "C:\Users\luan.machado\Documents\FirstDonations\FirstDonations\Views\Parts\Requests.cshtml"
                           Write(Html.DisplayNameFor(model => model.Part.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 22 "C:\Users\luan.machado\Documents\FirstDonations\FirstDonations\Views\Parts\Requests.cshtml"
                           Write(Html.DisplayNameFor(model => model.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </th>
                            <th>
                                Interested Team
                            </th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 31 "C:\Users\luan.machado\Documents\FirstDonations\FirstDonations\Views\Parts\Requests.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "46189993d34a547a356615a72eb0babb115e32f36742", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper);
            BeginWriteTagHelperAttribute();
            WriteLiteral("~/img/");
#nullable restore
#line 35 "C:\Users\luan.machado\Documents\FirstDonations\FirstDonations\Views\Parts\Requests.cshtml"
                                    WriteLiteral(item.ImagePart);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("src", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
#nullable restore
#line 39 "C:\Users\luan.machado\Documents\FirstDonations\FirstDonations\Views\Parts\Requests.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </td>\r\n                            <td class=\"pt-4\">\r\n                                ");
#nullable restore
#line 42 "C:\Users\luan.machado\Documents\FirstDonations\FirstDonations\Views\Parts\Requests.cshtml"
                           Write(Html.DisplayFor(modelItem => item.NamePart));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td class=\"pt-4\">\r\n                                ");
#nullable restore
#line 45 "C:\Users\luan.machado\Documents\FirstDonations\FirstDonations\Views\Parts\Requests.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td class=\"pt-4\">\r\n                                ");
#nullable restore
#line 48 "C:\Users\luan.machado\Documents\FirstDonations\FirstDonations\Views\Parts\Requests.cshtml"
                           Write(Html.DisplayFor(modelItem => item.InterestedTeamName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td class=\"pt-4\">\r\n                                <a");
            BeginWriteAttribute("href", " href=\"", 2202, "\"", 2310, 1);
#nullable restore
#line 51 "C:\Users\luan.machado\Documents\FirstDonations\FirstDonations\Views\Parts\Requests.cshtml"
WriteAttributeValue("", 2209, Url.Action("AcceptRequest", "Parts", new { Id = item.Id, InterestedTeamId = item.InterestedTeamId }), 2209, 101, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\">Accept</a>\r\n                                <a");
            BeginWriteAttribute("href", " href=\"", 2382, "\"", 2493, 1);
#nullable restore
#line 52 "C:\Users\luan.machado\Documents\FirstDonations\FirstDonations\Views\Parts\Requests.cshtml"
WriteAttributeValue("", 2389, Url.Action("DeclineRequest", "Parts", new { Id = item.Id,  InterestedTeamId = item.InterestedTeamId  }), 2389, 104, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\">Decline</a>\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 55 "C:\Users\luan.machado\Documents\FirstDonations\FirstDonations\Views\Parts\Requests.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </tbody>
                </table>
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-danger"" data-dismiss=""modal"">Fechar</button>
            </div>
        </div>
    </div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<FirstDonations.Models.Donation>> Html { get; private set; }
    }
}
#pragma warning restore 1591