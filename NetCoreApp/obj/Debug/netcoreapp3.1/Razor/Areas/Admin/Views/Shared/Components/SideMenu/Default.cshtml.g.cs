#pragma checksum "C:\Users\Welcome\source\repos\CoreApp\NetCoreApp\Areas\Admin\Views\Shared\Components\SideMenu\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "51b791d12f9077db7195bcaa95736f8d5eedeb3d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Shared_Components_SideMenu_Default), @"mvc.1.0.view", @"/Areas/Admin/Views/Shared/Components/SideMenu/Default.cshtml")]
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
#line 1 "C:\Users\Welcome\source\repos\CoreApp\NetCoreApp\Areas\Admin\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Welcome\source\repos\CoreApp\NetCoreApp\Areas\Admin\Views\_ViewImports.cshtml"
using NetCoreApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Welcome\source\repos\CoreApp\NetCoreApp\Areas\Admin\Views\_ViewImports.cshtml"
using NetCoreApp.Models.AccountViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Welcome\source\repos\CoreApp\NetCoreApp\Areas\Admin\Views\_ViewImports.cshtml"
using NetCoreApp.Models.ManageViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Welcome\source\repos\CoreApp\NetCoreApp\Areas\Admin\Views\_ViewImports.cshtml"
using NetCoreApp.Data.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Welcome\source\repos\CoreApp\NetCoreApp\Areas\Admin\Views\_ViewImports.cshtml"
using NetCoreApp.Application.ViewModels.System;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"51b791d12f9077db7195bcaa95736f8d5eedeb3d", @"/Areas/Admin/Views/Shared/Components/SideMenu/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"539dca3b6b8f1c3b675d5cf74140103c24192fbb", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Shared_Components_SideMenu_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<FunctionViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"ui fluid vertical menu\" id=\"verticalMenu\">\r\n");
#nullable restore
#line 3 "C:\Users\Welcome\source\repos\CoreApp\NetCoreApp\Areas\Admin\Views\Shared\Components\SideMenu\Default.cshtml"
     foreach (var item in Model)
    {
        if (Model.Any(x => x.ParentId == item.Id))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"item\">\r\n                <i");
            BeginWriteAttribute("class", " class=\"", 242, "\"", 263, 1);
#nullable restore
#line 8 "C:\Users\Welcome\source\repos\CoreApp\NetCoreApp\Areas\Admin\Views\Shared\Components\SideMenu\Default.cshtml"
WriteAttributeValue("", 250, item.IconCss, 250, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></i> <span>");
#nullable restore
#line 8 "C:\Users\Welcome\source\repos\CoreApp\NetCoreApp\Areas\Admin\Views\Shared\Components\SideMenu\Default.cshtml"
                                               Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                <div class=\"menu\">\r\n");
#nullable restore
#line 10 "C:\Users\Welcome\source\repos\CoreApp\NetCoreApp\Areas\Admin\Views\Shared\Components\SideMenu\Default.cshtml"
                     foreach (var itemC in Model.Where(x => x.ParentId == item.Id))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <a");
            BeginWriteAttribute("href", " href=\"", 465, "\"", 482, 1);
#nullable restore
#line 12 "C:\Users\Welcome\source\repos\CoreApp\NetCoreApp\Areas\Admin\Views\Shared\Components\SideMenu\Default.cshtml"
WriteAttributeValue("", 472, itemC.URL, 472, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"item\"><i");
            BeginWriteAttribute("class", " class=\"", 499, "\"", 521, 1);
#nullable restore
#line 12 "C:\Users\Welcome\source\repos\CoreApp\NetCoreApp\Areas\Admin\Views\Shared\Components\SideMenu\Default.cshtml"
WriteAttributeValue("", 507, itemC.IconCss, 507, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></i>");
#nullable restore
#line 12 "C:\Users\Welcome\source\repos\CoreApp\NetCoreApp\Areas\Admin\Views\Shared\Components\SideMenu\Default.cshtml"
                                                                                   Write(itemC.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 13 "C:\Users\Welcome\source\repos\CoreApp\NetCoreApp\Areas\Admin\Views\Shared\Components\SideMenu\Default.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 17 "C:\Users\Welcome\source\repos\CoreApp\NetCoreApp\Areas\Admin\Views\Shared\Components\SideMenu\Default.cshtml"
        }
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Users\Welcome\source\repos\CoreApp\NetCoreApp\Areas\Admin\Views\Shared\Components\SideMenu\Default.cshtml"
           
    }    

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<FunctionViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
