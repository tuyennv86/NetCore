#pragma checksum "E:\PROJECT\FameWeb\CoreApp\NetCoreApp\Areas\Admin\Views\Product\_AddEditProductModel.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f5fdbce731c7e4eeee5cb2f4a485128390c1ddd6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Product__AddEditProductModel), @"mvc.1.0.view", @"/Areas/Admin/Views/Product/_AddEditProductModel.cshtml")]
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
#line 1 "E:\PROJECT\FameWeb\CoreApp\NetCoreApp\Areas\Admin\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\PROJECT\FameWeb\CoreApp\NetCoreApp\Areas\Admin\Views\_ViewImports.cshtml"
using NetCoreApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\PROJECT\FameWeb\CoreApp\NetCoreApp\Areas\Admin\Views\_ViewImports.cshtml"
using NetCoreApp.Models.AccountViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\PROJECT\FameWeb\CoreApp\NetCoreApp\Areas\Admin\Views\_ViewImports.cshtml"
using NetCoreApp.Models.ManageViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\PROJECT\FameWeb\CoreApp\NetCoreApp\Areas\Admin\Views\_ViewImports.cshtml"
using NetCoreApp.Data.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\PROJECT\FameWeb\CoreApp\NetCoreApp\Areas\Admin\Views\_ViewImports.cshtml"
using NetCoreApp.Application.ViewModels.System;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f5fdbce731c7e4eeee5cb2f4a485128390c1ddd6", @"/Areas/Admin/Views/Product/_AddEditProductModel.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f61628ee912ce1b7cc215b7dd679b7dac93b66c0", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Product__AddEditProductModel : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-horizontal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("frmMaintainance"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("frmMaintainance"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"modal fade\" id=\"modalAddEdit\" data-backdrop=\"static\">\r\n    <div class=\"modal-dialog modal-xl\">\r\n        <div class=\"modal-content\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f5fdbce731c7e4eeee5cb2f4a485128390c1ddd65752", async() => {
                WriteLiteral("\r\n                ");
#nullable restore
#line 5 "E:\PROJECT\FameWeb\CoreApp\NetCoreApp\Areas\Admin\Views\Product\_AddEditProductModel.cshtml"
           Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                <div class=""modal-header"">
                    <h5 class=""modal-title"" id=""staticBackdropLabel"">Lưu cập nhật sản phẩm</h5>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>
                <div class=""modal-body"">
                    <div class=""form-group row"">
                        <label class=""col-sm-2 col-form-label"">Tên sẩn phẩm</label>
                        <div class=""col-sm-10"">
                            <input type=""hidden"" id=""hidId"" value=""0"" />
                            <input type=""text"" name=""txtName"" class=""form-control"" id=""txtName"" placeholder=""Nhập tên tour"">
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label class=""col-sm-2 col-form-label"">Danh mục</label>
                        <div class=""col-sm-10""");
                WriteLiteral(@">
                            <input type=""hidden"" id=""hidCategoryId"" value=""0"" />
                            <input type=""text"" id=""ddlCategory"" placeholder=""Nhập từ khóa"" autocomplete=""off"" />
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label class=""col-sm-2 col-form-label"">Ảnh đại diện</label>
                        <div class=""col-sm-10"">
                            <input type=""hidden"" name=""hidImage"" id=""hidImage"" />
                            <input type=""file"" name=""attachment"" id=""fuImage"" accept=""image/png, image/jpg, image/jpeg, image/gif"">
                            <div id=""image-holder""></div>

                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label class=""col-sm-2 col-form-label"">Ảnh liên quan</label>
                        <div class=""col-sm-10"">
                            <input type=""hidden"" name=""hidI");
                WriteLiteral(@"mage"" id=""hidImage"" />
                            <input type=""file"" name=""attachment"" id=""fuImageList"" multiple accept=""image/png, image/jpg, image/jpeg, image/gif"">
                        </div>

                        <!-- /.list image -->
                        <div class=""card-footer bg-white"" id=""list-image"">

                        </div>
                        <!-- /.card-footer -->

                    </div>
                    <div class=""form-group row"">
                        <label class=""col-sm-2 col-form-label"">SEO Title</label>
                        <div class=""col-sm-10"">
                            <input type=""text"" name=""txtSeoPageTitle"" class=""form-control"" id=""txtSeoPageTitle"">
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label class=""col-sm-2 col-form-label"">URL SEO</label>
                        <div class=""col-sm-10"">
                            <input type=""text"" name");
                WriteLiteral(@"=""txtSeoAlias"" class=""form-control"" id=""txtSeoAlias"">
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label class=""col-sm-2 col-form-label"">SEO Keyword</label>
                        <div class=""col-sm-10"">
                            <input type=""text"" name=""txtSeoKeyword"" class=""form-control"" id=""txtSeoKeyword"">
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label class=""col-sm-2 col-form-label"">SeoDescription</label>
                        <div class=""col-sm-10"">
                            <textarea rows=""3"" name=""txtSeoDescription"" class=""form-control"" id=""txtSeoDescription""></textarea>
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label class=""col-sm-2 col-form-label"">Thứ tự</label>
                        <div class=""col-sm-10"">
   ");
                WriteLiteral(@"                         <input type=""number"" name=""txtOrder"" class=""form-control col-md-4"" id=""txtOrder"" value=""0"">
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label class=""col-sm-2 col-form-label"">Thứ tự trang chủ</label>
                        <div class=""col-sm-10"">
                            <input type=""number"" name=""txtHomeOrder"" class=""form-control col-md-4"" id=""txtHomeOrder"" value=""0"">
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label class=""col-sm-2 col-form-label"">Giá:</label>
                        <div class=""col-sm-10"">
                            <input type=""number"" name=""txtPrice"" class=""form-control col-md-4"" id=""txtPrice"" value=""0"">
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label class=""col-sm-2 col-form-label""");
                WriteLiteral(@">Giá khuyến mại:</label>
                        <div class=""col-sm-10"">
                            <input type=""number"" name=""txtPromotionPrice"" class=""form-control col-md-4"" id=""txtPromotionPrice"" value=""0"">
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label class=""col-sm-2 col-form-label"">Giá gốc:</label>
                        <div class=""col-sm-10"">
                            <input type=""number"" name=""txtOriginalPrice"" class=""form-control col-md-4"" id=""txtOriginalPrice"" value=""0"">
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label class=""col-sm-2 col-form-label"">Đơn vị tính</label>
                        <div class=""col-sm-10"">
                            <input type=""text"" name=""txtUnit"" class=""form-control col-md-4"" id=""txtUnit"">
                        </div>
                    </div>
                    <di");
                WriteLiteral(@"v class=""form-group row"">
                        <label class=""col-sm-12 col-form-label"">Mô tả</label>
                        <div class=""col-sm-12"">
                            <textarea rows=""3"" name=""txtDescription"" class=""form-control"" id=""txtDescription""></textarea>
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label class=""col-sm-12 col-form-label"">Chi tiết:</label>
                        <div class=""col-sm-12"">
                            <textarea rows=""3"" name=""txtContent"" class=""form-control"" id=""txtContent""></textarea>
                        </div>
                    </div>   
                    <div class=""form-group row"">
                        <label class=""col-sm-2 col-form-label"">Tags</label>
                        <div class=""col-sm-10"">                            
                            <input type=""text"" name=""txtTags"" class=""form-control"" id=""txtTags"" data-role=""tagsinput"" plac");
                WriteLiteral(@"eholder=""Nhập tags"">
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label class=""col-sm-2 col-form-label"">Ngày đăng</label>
                        <div class=""col-sm-10"">
                            <input type=""text"" name=""txtCreateDate"" class=""form-control col-md-4"" id=""txtCreateDate"">
                            <input type=""hidden"" name=""hidCreateById"" id=""hidCreateById"" />
                            <input type=""hidden"" name=""hidEditById"" id=""hidEditById"" />
                            <input type=""hidden"" name=""hidViewCount"" id=""hidViewCount"" value=""0"" />
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <div class="" offset-sm-2 col-sm-10"">
                            <div class=""checkbox"">
                                <label>
                                    <input type=""checkbox"" checked=""checked"" id=""ckStatus"">
 ");
                WriteLiteral(@"                                   <span class=""text"">Hiển thị.</span>
                                </label>
                                <label>
                                    <input type=""checkbox"" id=""ckHomeFlag"">
                                    <span class=""text"">Hiện trang chủ.</span>
                                </label>
                                <label>
                                    <input type=""checkbox"" id=""ckHotFlag"">
                                    <span class=""text"">Nổi bật.</span>
                                </label>
                            </div>
                        </div>
                    </div>


                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Đóng</button>
                    <button type=""submit"" class=""btn btn-primary"">Cập nhật</button>
                </div>
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
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
        </div>
    </div>
</div>

<script id=""images-template"" type=""x-tmpl-mustache"">
    <ul class=""list-group list-group-horizontal position-relative overflow-auto w-100"">
     {{#imagesTag}}
    <li id=""li-{{id}}"">
        <span class=""mailbox-attachment-icon has-img img-size-200""><img src=""{{name}}"" alt=""""></span>
        <div class=""mailbox-attachment-info"">
        <span class=""mailbox-attachment-size clearfix mt-1"">
            <a href=""#"" data-id=""{{id}}"" id=""btnDeleteImgDetail"" class=""mailbox-attachment-name""><i class=""fas fa-trash""></i> Xóa</a>
        </span>
        </div>
    </li>
    {{/imagesTag}}
    </ul>
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