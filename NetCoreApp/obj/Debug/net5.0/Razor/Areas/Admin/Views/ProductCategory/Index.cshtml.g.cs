#pragma checksum "C:\Users\Welcome\source\repos\CoreApp\NetCoreApp\Areas\Admin\Views\ProductCategory\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dd7462f90a3d47cea4766fb47e98ac1de4c37710"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_ProductCategory_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/ProductCategory/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dd7462f90a3d47cea4766fb47e98ac1de4c37710", @"/Areas/Admin/Views/ProductCategory/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f61628ee912ce1b7cc215b7dd679b7dac93b66c0", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_ProductCategory_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/tree-grid/css/jquery.treegrid.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/tree-grid/js/jquery.treegrid.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/app/controllers/productCategories/index.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "dd7462f90a3d47cea4766fb47e98ac1de4c377106329", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dd7462f90a3d47cea4766fb47e98ac1de4c377107716", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dd7462f90a3d47cea4766fb47e98ac1de4c377108902", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <script>\r\n        var productCategory = new productCategoryController();\r\n        productCategory.initialize();\r\n    </script>\r\n");
            }
            );
            WriteLiteral(@"<!-- Content Header (Page header) -->
<section class=""content-header"">
    <div class=""container-fluid"">
        <div class=""row mb-2"">
            <div class=""col-sm-6"">
                <h1>Danh mục</h1>
            </div>
            <div class=""col-sm-6"">
                <ol class=""breadcrumb float-sm-right"">
                    <li class=""breadcrumb-item""><a href=""#"">Admin</a></li>
                    <li class=""breadcrumb-item active"">Danh mục</li>
                </ol>
            </div>
        </div>
    </div><!-- /.container-fluid -->
</section>
<!-- Main content -->
<section class=""content"">

    <!-- Default box -->
    <div class=""card"">
        <div class=""card-header"">
            <h3 class=""card-title"">
                <a class=""btn btn-primary btn-sm"" href=""#"">
                    <i class=""fas fa-plus-circle""></i>
                    Thêm mới
                </a>
                <a class=""btn btn-info btn-sm"" href=""#"">
                    <i class=""fa fa-recycle"">");
            WriteLiteral(@"</i>
                    Cập nhật
                </a>
                <a class=""btn btn-danger btn-sm"" href=""#"">
                    <i class=""fas fa-trash""></i>
                    Delete
                </a>
            </h3>

            <div class=""card-tools"">
                <button type=""button"" class=""btn btn-tool"" data-card-widget=""collapse"" title=""Collapse"">
                    <i class=""fas fa-minus""></i>
                </button>
                <button type=""button"" class=""btn btn-tool"" data-card-widget=""remove"" title=""Remove"">
                    <i class=""fas fa-times""></i>
                </button>
            </div>
        </div>
        <div class=""card-body p-0"">
            <table class=""tree table table-striped projects"">
                <thead>
                    <tr>
                        <th style=""width: 1%"">
                            <input type=""checkbox"" name=""checkAll"" id=""checkAll"">
                        </th>
                        <th>Tên danh");
            WriteLiteral(@" mục</th>
                        <th>Ảnh</th>
                        <th>Thứ tự</th>
                        <th>Trạng thái</th>
                        <th>Trang chủ</th>
                        <th>Thứ tự home</th>
                        <th>Ngày tạo</th>
                        <th>Ngày sửa</th>
                        <th>Action</th>
                    </tr>
                </thead>
                <tbody id=""tpl_content"">
                </tbody>
            </table>
        </div>
        <!-- /.card-body -->
    </div>
    <!-- /.card -->

</section>
<!-- /.content -->
<script type=""x-tmpl-mustache"" id=""mp_template"">
    {{#categoryTag}}
        {{#parentId}}
            <tr class=""treegrid-{{id}} treegrid-parent-{{parentId}}"">
        {{/parentId}}
        {{^parentId}}
            <tr class=""treegrid-{{id}}"">
        {{/parentId}}
        <td>
            <input type=""checkbox"" name=""checkItem"">
        </td>
        <td>{{name}}</td>
        <td>
            {{#");
            WriteLiteral(@"image}}
                <img  class=""product-image-thumb img-size-64"" src=""{{image}}"">
            {{/image}}
            {{^image}}
                <img  class=""product-image-thumb img-size-64"" src=""/admin/dist/img/no_image_available.jpg"">
            {{/image}}
        </td>
        <td>
              <input type=""text"" class=""form-control form-control-sm img-size-64"" value=""{{sortOrder}}"" placeholder=""số thứ tự"">
        </td>
       <td>
            {{#status}}<a href=""#"" class=""badge bg-success"" data-id=""{{id}}""><i class=""fa fa-unlock"" aria-hidden=""true""></i> Kích hoạt </a>{{/status}}
            {{^status}}<a href=""#"" class=""badge bg-danger"" data-id=""{{id}}""><i class=""fa fa-lock"" aria-hidden=""true""></i> Khóa </a>{{/status}}
        </td>
        <td>
            {{#HomeFlag}}<a href=""#"" class=""badge bg-success"" data-id=""{{id}}""><i class=""fa fa-eye"" aria-hidden=""true""></i> Trang chủ</a>{{/HomeFlag}}
            {{^HomeFlag}}<a href=""#"" class=""badge bg-info"" data-id=""{{id}}""><i class=""fa f");
            WriteLiteral(@"a-eye-slash"" aria-hidden=""true""></i> Bình thường</a>{{/HomeFlag}}
        </td>
        <td>
              <input type=""text"" class=""form-control form-control-sm img-size-64"" value=""{{HomeOrder}}"" placeholder=""số tt"">
        </td>
        <td> {{#dateFormat}}{{dateCreated }}{{/dateFormat}}</td>
        <td> {{#dateFormat}}{{dateModified }}{{/dateFormat}}</td>
        <td>
            <a class=""btn btn-info btn-sm"" href=""#""><i class=""fas fa-pencil-alt""> </i> Edit </a>
            <a class=""btn btn-danger btn-sm"" href=""#""> <i class=""fas fa-trash""> </i> Delete </a>
        </td>
    </tr>
    {{/categoryTag}}
</script>");
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
