#pragma checksum "D:\GitHubRepo\Software-University-SoftUni\ASP.NET CORE\SandBoxProjects\MyFirstWebApp\MyFirstWebApp\Views\Shared\Components\NavBar\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c729e5e4d9e5097df567b3a346e9aa7ca7ba571d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_NavBar_Default), @"mvc.1.0.view", @"/Views/Shared/Components/NavBar/Default.cshtml")]
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
#line 1 "D:\GitHubRepo\Software-University-SoftUni\ASP.NET CORE\SandBoxProjects\MyFirstWebApp\MyFirstWebApp\Views\Shared\Components\NavBar\Default.cshtml"
using MyFirstWebApp.ViewModels.NavBar;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c729e5e4d9e5097df567b3a346e9aa7ca7ba571d", @"/Views/Shared/Components/NavBar/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eef13388432877871cbc89b386fc17b3272c6df0", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_NavBar_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NavBarViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<table >\r\n    <tr>\r\n");
#nullable restore
#line 6 "D:\GitHubRepo\Software-University-SoftUni\ASP.NET CORE\SandBoxProjects\MyFirstWebApp\MyFirstWebApp\Views\Shared\Components\NavBar\Default.cshtml"
         for (int i = 1; i <= Model.Years.Count(); i++)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <th>i</th>\r\n");
#nullable restore
#line 9 "D:\GitHubRepo\Software-University-SoftUni\ASP.NET CORE\SandBoxProjects\MyFirstWebApp\MyFirstWebApp\Views\Shared\Components\NavBar\Default.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 11 "D:\GitHubRepo\Software-University-SoftUni\ASP.NET CORE\SandBoxProjects\MyFirstWebApp\MyFirstWebApp\Views\Shared\Components\NavBar\Default.cshtml"
         foreach (var year in Model.Years)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <td>");
#nullable restore
#line 13 "D:\GitHubRepo\Software-University-SoftUni\ASP.NET CORE\SandBoxProjects\MyFirstWebApp\MyFirstWebApp\Views\Shared\Components\NavBar\Default.cshtml"
           Write(year);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 14 "D:\GitHubRepo\Software-University-SoftUni\ASP.NET CORE\SandBoxProjects\MyFirstWebApp\MyFirstWebApp\Views\Shared\Components\NavBar\Default.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tr>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NavBarViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
