#pragma checksum "D:\GitHubRepo\Software-University-SoftUni\ASP.NET CORE\SandBoxProjects\MyFirstWebApp\MyFirstWebApp\Views\Home\_FullNamePartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d416ac0b29ac32c800c9033743874b5ad95f016a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home__FullNamePartial), @"mvc.1.0.view", @"/Views/Home/_FullNamePartial.cshtml")]
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
#line 1 "D:\GitHubRepo\Software-University-SoftUni\ASP.NET CORE\SandBoxProjects\MyFirstWebApp\MyFirstWebApp\Views\_ViewImports.cshtml"
using MyFirstWebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\GitHubRepo\Software-University-SoftUni\ASP.NET CORE\SandBoxProjects\MyFirstWebApp\MyFirstWebApp\Views\_ViewImports.cshtml"
using MyFirstWebApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\GitHubRepo\Software-University-SoftUni\ASP.NET CORE\SandBoxProjects\MyFirstWebApp\MyFirstWebApp\Views\Home\_FullNamePartial.cshtml"
using MyFirstWebApp.ViewModels.Home;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d416ac0b29ac32c800c9033743874b5ad95f016a", @"/Views/Home/_FullNamePartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eef13388432877871cbc89b386fc17b3272c6df0", @"/Views/_ViewImports.cshtml")]
    public class Views_Home__FullNamePartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FullNamePartialViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\GitHubRepo\Software-University-SoftUni\ASP.NET CORE\SandBoxProjects\MyFirstWebApp\MyFirstWebApp\Views\Home\_FullNamePartial.cshtml"
  
    string fullName = Model.FirstName + Model.LastName;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>");
#nullable restore
#line 8 "D:\GitHubRepo\Software-University-SoftUni\ASP.NET CORE\SandBoxProjects\MyFirstWebApp\MyFirstWebApp\Views\Home\_FullNamePartial.cshtml"
Write(fullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FullNamePartialViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
