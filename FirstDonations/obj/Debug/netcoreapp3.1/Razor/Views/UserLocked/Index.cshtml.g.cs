#pragma checksum "C:\Users\luan.machado\Documents\FirstDonations\FirstDonations\Views\UserLocked\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bac34a5c56f97adac4304245015fd77b86af9971"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_UserLocked_Index), @"mvc.1.0.view", @"/Views/UserLocked/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bac34a5c56f97adac4304245015fd77b86af9971", @"/Views/UserLocked/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7b0bf9a4862914a8447554051a94e7810c322597", @"/Views/_ViewImports.cshtml")]
    public class Views_UserLocked_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\luan.machado\Documents\FirstDonations\FirstDonations\Views\UserLocked\Index.cshtml"
  
    Layout = "/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <h4 class=""text-center"">Your account is temporarily locked, wait for confirmation from the administrator.</h4>
    <h4 class=""text-center"">You can contact us via email: firstdonations@gmail.com</h4>
    <center><a href=""../../Identity/Account/Login?ReturnUrl=%2F"" class=""text-center"">Back to login</a></center>");
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
