#pragma checksum "C:\Users\luan.machado\Documents\FirstDonations\FirstDonations\Views\Home\Ranking.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2871707500d781e4eaacdfa610dea91f5b7f1f0b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Ranking), @"mvc.1.0.view", @"/Views/Home/Ranking.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2871707500d781e4eaacdfa610dea91f5b7f1f0b", @"/Views/Home/Ranking.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7b0bf9a4862914a8447554051a94e7810c322597", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Ranking : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<FirstDonations.Areas.Identity.Data.ApplicationUser>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\luan.machado\Documents\FirstDonations\FirstDonations\Views\Home\Ranking.cshtml"
  
    ViewData["Title"] = "Home Page";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <h4 class=""text-center"">See the top five donators</h4>

<div class=""container"">

    <div class=""section"">
        <div class=""row"">
            <table class=""table table-dark"">
                <thead>
                    <tr>
                        <th scope=""col"">Team name</th>
                        <th scope=""col"">Email</th>
                        <th scope=""col"">Donations</th>
                    </tr>
                </thead>
");
#nullable restore
#line 22 "C:\Users\luan.machado\Documents\FirstDonations\FirstDonations\Views\Home\Ranking.cshtml"
                 foreach (var user in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tbody>\r\n                        <tr>\r\n                            <td>");
#nullable restore
#line 26 "C:\Users\luan.machado\Documents\FirstDonations\FirstDonations\Views\Home\Ranking.cshtml"
                           Write(user.TeamName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 27 "C:\Users\luan.machado\Documents\FirstDonations\FirstDonations\Views\Home\Ranking.cshtml"
                           Write(user.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 28 "C:\Users\luan.machado\Documents\FirstDonations\FirstDonations\Views\Home\Ranking.cshtml"
                           Write(user.NumberOfSuccessDonations);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        </tr>\r\n                    </tbody>\r\n");
#nullable restore
#line 31 "C:\Users\luan.machado\Documents\FirstDonations\FirstDonations\Views\Home\Ranking.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </table>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<FirstDonations.Areas.Identity.Data.ApplicationUser>> Html { get; private set; }
    }
}
#pragma warning restore 1591
