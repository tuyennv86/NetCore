#pragma checksum "C:\Users\Welcome\source\repos\CoreApp\NetCoreApp\Areas\Admin\Views\Shared\Components\SideMenu\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fa8e98d154054c250d6a9a73bcd21abd3b521720"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa8e98d154054c250d6a9a73bcd21abd3b521720", @"/Areas/Admin/Views/Shared/Components/SideMenu/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f61628ee912ce1b7cc215b7dd679b7dac93b66c0", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Shared_Components_SideMenu_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<FunctionViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/dist/img/AdminLTELogo.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("AdminLTE Logo"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("brand-image img-circle elevation-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("opacity: .8"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n    <aside class=\"main-sidebar sidebar-dark-primary elevation-4\">       \r\n        <a href=\"#\" class=\"brand-link\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "fa8e98d154054c250d6a9a73bcd21abd3b5217205744", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            <span class=""brand-text font-weight-light"">Admin</span>
        </a>        
        <div class=""sidebar"">            
            <nav class=""mt-2"">
                <ul class=""nav nav-pills nav-sidebar flex-column"" data-widget=""treeview"" role=""menu"" data-accordion=""false"">
");
#nullable restore
#line 11 "C:\Users\Welcome\source\repos\CoreApp\NetCoreApp\Areas\Admin\Views\Shared\Components\SideMenu\Default.cshtml"
                     foreach (var item in Model)
                    {
                        if (Model.Any(x => x.ParentId == item.Id))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li class=\"nav-item menu-open\">\r\n                                <a href=\"#\" class=\"nav-link active\">\r\n                                    <i");
            BeginWriteAttribute("class", " class=\"", 920, "\"", 941, 1);
#nullable restore
#line 17 "C:\Users\Welcome\source\repos\CoreApp\NetCoreApp\Areas\Admin\Views\Shared\Components\SideMenu\Default.cshtml"
WriteAttributeValue("", 928, item.IconCss, 928, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></i>\r\n                                    <p>\r\n                                        ");
#nullable restore
#line 19 "C:\Users\Welcome\source\repos\CoreApp\NetCoreApp\Areas\Admin\Views\Shared\Components\SideMenu\Default.cshtml"
                                   Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        <i class=""fas fa-angle-left right""></i>                                       
                                    </p>
                                </a>
                                <ul class=""nav nav-treeview"">
");
#nullable restore
#line 24 "C:\Users\Welcome\source\repos\CoreApp\NetCoreApp\Areas\Admin\Views\Shared\Components\SideMenu\Default.cshtml"
                                     foreach (var itemC in Model.Where(x => x.ParentId == item.Id))
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <li class=\"nav-item\">\r\n                                            <a");
            BeginWriteAttribute("href", " href=\"", 1554, "\"", 1571, 1);
#nullable restore
#line 27 "C:\Users\Welcome\source\repos\CoreApp\NetCoreApp\Areas\Admin\Views\Shared\Components\SideMenu\Default.cshtml"
WriteAttributeValue("", 1561, itemC.URL, 1561, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"nav-link\">\r\n                                                <i");
            BeginWriteAttribute("class", " class=\"", 1642, "\"", 1664, 1);
#nullable restore
#line 28 "C:\Users\Welcome\source\repos\CoreApp\NetCoreApp\Areas\Admin\Views\Shared\Components\SideMenu\Default.cshtml"
WriteAttributeValue("", 1650, itemC.IconCss, 1650, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></i>\r\n                                                <p>");
#nullable restore
#line 29 "C:\Users\Welcome\source\repos\CoreApp\NetCoreApp\Areas\Admin\Views\Shared\Components\SideMenu\Default.cshtml"
                                              Write(itemC.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                            </a>\r\n                                        </li>\r\n");
#nullable restore
#line 32 "C:\Users\Welcome\source\repos\CoreApp\NetCoreApp\Areas\Admin\Views\Shared\Components\SideMenu\Default.cshtml"
                                    }                                       

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </ul>\r\n                            </li>\r\n");
#nullable restore
#line 35 "C:\Users\Welcome\source\repos\CoreApp\NetCoreApp\Areas\Admin\Views\Shared\Components\SideMenu\Default.cshtml"
                        }
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </ul>\r\n            </nav>            \r\n        </div>        \r\n    </aside>");
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
