#pragma checksum "E:\PROJECT\FameWeb\CoreApp\NetCoreApp\Areas\Admin\Views\Tour\_AddEditTourModel.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c76b6b87ecd363e1a29a4a266acdc1dc8345b7f9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Tour__AddEditTourModel), @"mvc.1.0.view", @"/Areas/Admin/Views/Tour/_AddEditTourModel.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c76b6b87ecd363e1a29a4a266acdc1dc8345b7f9", @"/Areas/Admin/Views/Tour/_AddEditTourModel.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f61628ee912ce1b7cc215b7dd679b7dac93b66c0", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Tour__AddEditTourModel : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c76b6b87ecd363e1a29a4a266acdc1dc8345b7f95722", async() => {
                WriteLiteral("\r\n                ");
#nullable restore
#line 5 "E:\PROJECT\FameWeb\CoreApp\NetCoreApp\Areas\Admin\Views\Tour\_AddEditTourModel.cshtml"
           Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                <div class=""modal-header"">
                    <h5 class=""modal-title"" id=""staticBackdropLabel"">Lưu cập nhật tour</h5>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>
                <div class=""modal-body"">
                    <div class=""form-group row"">
                        <label class=""col-sm-2 col-form-label"">Tên tour</label>
                        <div class=""col-sm-10"">
                            <input type=""hidden"" id=""hidId"" value=""0"" />
                            <input type=""text"" name=""txtName"" class=""form-control"" id=""txtName"" placeholder=""Nhập tên tour"">
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label class=""col-sm-2 col-form-label"">Danh mục</label>
                        <div class=""col-sm-10"">
     ");
                WriteLiteral(@"                       <input type=""hidden"" id=""hidCategoryId"" value=""0"" />
                            <input type=""text"" id=""ddlCategory"" placeholder=""Nhập từ khóa"" autocomplete=""off"" />
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label class=""col-sm-2 col-form-label"">Ảnh đại diện</label>
                        <div class=""col-sm-10"">
                            <input type=""hidden"" name=""hidImage"" id=""hidImage"" />
                            <input type=""file"" name=""attachment"" id=""fuImage"" accept=""image/png, image/jpg, image/jpeg, image/gif"">
                            <div id=""image-holder""></div>
                            <a href=""#"" id=""hplRemoveImg""><i class=""fa fa-trash"" aria-hidden=""true""></i> xóa ảnh</a>
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label class=""col-sm-2 col-form-label"">Ảnh liên quan</label>
");
                WriteLiteral(@"                        <div class=""col-sm-10"">
                            <input type=""hidden"" name=""hidImage"" id=""hidImage"" />
                            <input type=""file"" name=""attachment"" id=""fuImageList"" multiple accept=""image/png, image/jpg, image/jpeg, image/gif"">
                            <div id=""image-holder""></div>
                            <a href=""#"" id=""hplRemoveImg""><i class=""fa fa-trash"" aria-hidden=""true""></i> xóa ảnh</a>
                        </div>

                        <!-- /.card-body -->
                        <!--<div class=""card-footer bg-white"">
                            <ul class=""list-group list-group-horizontal position-relative overflow-auto w-100"">
                                <li>
                                    <span class=""mailbox-attachment-icon has-img""><img src=""~/admin/dist/img/avatar4.png"" alt=""Attachment""></span>

                                    <div class=""mailbox-attachment-info"">
                                        <a href=""");
                WriteLiteral(@"#"" class=""mailbox-attachment-name""><i class=""fas fa-trash""></i></a>
                                    </div>
                                </li>
                                <li>
                                    <span class=""mailbox-attachment-icon has-img""><img src=""~/admin/dist/img/avatar2.png"" alt=""Attachment""></span>

                                    <div class=""mailbox-attachment-info"">
                                        <a href=""#"" class=""mailbox-attachment-name""><i class=""fas fa-trash""></i> Xóa ảnh</a>
                                    </div>
                                </li>
                                <li>
                                    <span class=""mailbox-attachment-icon has-img""><img src=""~/admin/dist/img/avatar.png"" alt=""Attachment""></span>

                                    <div class=""mailbox-attachment-info"">
                                        <a href=""#"" class=""mailbox-attachment-name""><i class=""fas fa-trash""></i> Xóa ảnh</a>
            ");
                WriteLiteral(@"                        </div>
                                </li>
                                <li>
                                    <span class=""mailbox-attachment-icon has-img""><img src=""~/admin/dist/img/avatar3.png"" alt=""Attachment""></span>
                                    <div class=""mailbox-attachment-info"">
                                        <a href=""#"" class=""mailbox-attachment-name""><i class=""fas fa-trash""></i> Xóa ảnh</a>
                                    </div>
                                </li>
                                <li>
                                    <span class=""mailbox-attachment-icon has-img""><img src=""~/admin/dist/img/avatar3.png"" alt=""Attachment""></span>
                                    <div class=""mailbox-attachment-info"">
                                        <a href=""#"" class=""mailbox-attachment-name""><i class=""fas fa-trash""></i> Xóa ảnh</a>
                                    </div>
                                </li>
             ");
                WriteLiteral(@"                   <li>
                                    <span class=""mailbox-attachment-icon has-img""><img src=""~/admin/dist/img/avatar3.png"" alt=""Attachment""></span>
                                    <div class=""mailbox-attachment-info"">
                                        <a href=""#"" class=""mailbox-attachment-name""><i class=""fas fa-trash""></i> Xóa ảnh</a>
                                    </div>
                                </li>
                                <li>
                                    <span class=""mailbox-attachment-icon has-img""><img src=""~/admin/dist/img/avatar3.png"" alt=""Attachment""></span>
                                    <div class=""mailbox-attachment-info"">
                                        <a href=""#"" class=""mailbox-attachment-name""><i class=""fas fa-trash""></i> Xóa ảnh</a>
                                    </div>
                                </li>
                                <li>
                                    <span class=""mailbox-at");
                WriteLiteral(@"tachment-icon has-img""><img src=""~/admin/dist/img/avatar4.png"" alt=""Attachment""></span>

                                    <div class=""mailbox-attachment-info"">
                                        <a href=""#"" class=""mailbox-attachment-name""><i class=""fas fa-trash""></i></a>
                                    </div>
                                </li>
                                <li>
                                    <span class=""mailbox-attachment-icon has-img""><img src=""~/admin/dist/img/avatar2.png"" alt=""Attachment""></span>

                                    <div class=""mailbox-attachment-info"">
                                        <a href=""#"" class=""mailbox-attachment-name""><i class=""fas fa-trash""></i> Xóa ảnh</a>
                                    </div>
                                </li>
                                <li>
                                    <span class=""mailbox-attachment-icon has-img""><img src=""~/admin/dist/img/avatar.png"" alt=""Attachment""></span>
");
                WriteLiteral(@"
                                    <div class=""mailbox-attachment-info"">
                                        <a href=""#"" class=""mailbox-attachment-name""><i class=""fas fa-trash""></i> Xóa ảnh</a>
                                    </div>
                                </li>
                                <li>
                                    <span class=""mailbox-attachment-icon has-img""><img src=""~/admin/dist/img/avatar3.png"" alt=""Attachment""></span>
                                    <div class=""mailbox-attachment-info"">
                                        <a href=""#"" class=""mailbox-attachment-name""><i class=""fas fa-trash""></i> Xóa ảnh</a>
                                    </div>
                                </li>
                                <li>
                                    <span class=""mailbox-attachment-icon has-img""><img src=""~/admin/dist/img/avatar3.png"" alt=""Attachment""></span>
                                    <div class=""mailbox-attachment-info"">
       ");
                WriteLiteral(@"                                 <a href=""#"" class=""mailbox-attachment-name""><i class=""fas fa-trash""></i> Xóa ảnh</a>
                                    </div>
                                </li>
                                <li>
                                    <span class=""mailbox-attachment-icon has-img""><img src=""~/admin/dist/img/avatar3.png"" alt=""Attachment""></span>
                                    <div class=""mailbox-attachment-info"">
                                        <a href=""#"" class=""mailbox-attachment-name""><i class=""fas fa-trash""></i> Xóa ảnh</a>
                                    </div>
                                </li>
                                <li>
                                    <span class=""mailbox-attachment-icon has-img""><img src=""~/admin/dist/img/avatar3.png"" alt=""Attachment""></span>
                                    <div class=""mailbox-attachment-info"">
                                        <a href=""#"" class=""mailbox-attachment-name""><i clas");
                WriteLiteral(@"s=""fas fa-trash""></i> Xóa ảnh</a>
                                    </div>
                                </li>
                                <li>
                                    <span class=""mailbox-attachment-icon has-img""><img src=""~/admin/dist/img/avatar4.png"" alt=""Attachment""></span>

                                    <div class=""mailbox-attachment-info"">
                                        <a href=""#"" class=""mailbox-attachment-name""><i class=""fas fa-trash""></i></a>
                                    </div>
                                </li>
                                <li>
                                    <span class=""mailbox-attachment-icon has-img""><img src=""~/admin/dist/img/avatar2.png"" alt=""Attachment""></span>

                                    <div class=""mailbox-attachment-info"">
                                        <a href=""#"" class=""mailbox-attachment-name""><i class=""fas fa-trash""></i> Xóa ảnh</a>
                                    </div>
         ");
                WriteLiteral(@"                       </li>
                                <li>
                                    <span class=""mailbox-attachment-icon has-img""><img src=""~/admin/dist/img/avatar.png"" alt=""Attachment""></span>

                                    <div class=""mailbox-attachment-info"">
                                        <a href=""#"" class=""mailbox-attachment-name""><i class=""fas fa-trash""></i> Xóa ảnh</a>
                                    </div>
                                </li>
                                <li>
                                    <span class=""mailbox-attachment-icon has-img""><img src=""~/admin/dist/img/avatar3.png"" alt=""Attachment""></span>
                                    <div class=""mailbox-attachment-info"">
                                        <a href=""#"" class=""mailbox-attachment-name""><i class=""fas fa-trash""></i> Xóa ảnh</a>
                                    </div>
                                </li>
                                <li>
               ");
                WriteLiteral(@"                     <span class=""mailbox-attachment-icon has-img""><img src=""~/admin/dist/img/avatar3.png"" alt=""Attachment""></span>
                                    <div class=""mailbox-attachment-info"">
                                        <a href=""#"" class=""mailbox-attachment-name""><i class=""fas fa-trash""></i> Xóa ảnh</a>
                                    </div>
                                </li>
                                <li>
                                    <span class=""mailbox-attachment-icon has-img""><img src=""~/admin/dist/img/avatar3.png"" alt=""Attachment""></span>
                                    <div class=""mailbox-attachment-info"">
                                        <a href=""#"" class=""mailbox-attachment-name""><i class=""fas fa-trash""></i> Xóa ảnh</a>
                                    </div>
                                </li>
                                <li>
                                    <span class=""mailbox-attachment-icon has-img""><img src=""~/admin");
                WriteLiteral(@"/dist/img/avatar3.png"" alt=""Attachment""></span>
                                    <div class=""mailbox-attachment-info"">
                                        <a href=""#"" class=""mailbox-attachment-name""><i class=""fas fa-trash""></i> Xóa ảnh</a>
                                    </div>
                                </li>

                            </ul>
                        </div> -->
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
      ");
                WriteLiteral(@"                      <input type=""text"" name=""txtSeoAlias"" class=""form-control"" id=""txtSeoAlias"">
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
       ");
                WriteLiteral(@"                 <div class=""col-sm-10"">
                            <input type=""number"" name=""txtOrder"" class=""form-control col-md-4"" id=""txtOrder"">
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label class=""col-sm-2 col-form-label"">Thứ tự trang chủ</label>
                        <div class=""col-sm-10"">
                            <input type=""number"" name=""txtHomeOrder"" class=""form-control col-md-4"" id=""txtHomeOrder"">
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label class=""col-sm-2 col-form-label"">Giá tour:</label>
                        <div class=""col-sm-10"">
                            <input type=""number"" name=""txtPrice"" class=""form-control col-md-4"" id=""txtPrice"">
                        </div>
                    </div>

                    <div class=""form-group row"">
                        <label class=""co");
                WriteLiteral(@"l-sm-2 col-form-label"">Khởi hành:</label>
                        <div class=""col-sm-10"">
                            <input type=""text"" name=""txtTimeTour"" class=""form-control col-md-4"" id=""txtTimeTour"">
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label class=""col-sm-2 col-form-label"">Thời gian:</label>
                        <div class=""col-sm-10"">
                            <input type=""text"" name=""txtDateStart"" class=""form-control col-md-4"" id=""txtDateStart"">
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label class=""col-sm-2 col-form-label"">Phương thức di chuyển:</label>
                        <div class=""col-sm-10"">
                            <input type=""text"" name=""txtTransPort"" class=""form-control col-md-4"" id=""txtTransPort"">
                        </div>
                    </div>
                    <div cl");
                WriteLiteral(@"ass=""form-group row"">
                        <label class=""col-sm-2 col-form-label"">Quà tặng:</label>
                        <div class=""col-sm-10"">
                            <input type=""text"" name=""txtGift"" class=""form-control col-md-4"" id=""txtGift"">
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label class=""col-sm-12 col-form-label"">Mô tả</label>
                        <div class=""col-sm-12"">
                            <textarea rows=""3"" name=""txtPreview"" class=""form-control"" id=""txtPreview""></textarea>
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label class=""col-sm-12 col-form-label"">Dịch vụ:</label>
                        <div class=""col-sm-12"">
                            <textarea rows=""3"" name=""txtService"" class=""form-control"" id=""txtService""></textarea>
                        </div>
                    </");
                WriteLiteral(@"div>

                    <div class=""form-group row"">
                        <label class=""col-sm-12 col-form-label"">Dịch vụ đi kèm:</label>
                        <div class=""col-sm-12"">
                            <textarea rows=""3"" name=""txtServiceConten"" class=""form-control"" id=""txtServiceConten""></textarea>
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label class=""col-sm-12 col-form-label"">Dịch vụ không kèm:</label>
                        <div class=""col-sm-12"">
                            <textarea rows=""3"" name=""txtServiceNotConten"" class=""form-control"" id=""txtServiceNotConten""></textarea>
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label class=""col-sm-2 col-form-label"">Ngày đăng</label>
                        <div class=""col-sm-10"">
                            <input type=""text"" name=""txtCreateDate"" class=""f");
                WriteLiteral(@"orm-control col-md-4"" id=""txtCreateDate"">
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <div class="" offset-sm-2 col-sm-10"">
                            <div class=""checkbox"">
                                <label>
                                    <input type=""checkbox"" checked=""checked"" id=""ckStatus"">
                                    <span class=""text"">Hiển thị.</span>
                                </label>
                                <label>
                                    <input type=""checkbox"" id=""ckShowHome"">
                                    <span class=""text"">Hiện trang chủ.</span>
                                </label>
                            </div>
                        </div>
                    </div>


                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Đóng</button");
                WriteLiteral(">\r\n                    <button type=\"submit\" class=\"btn btn-primary\">Cập nhật</button>\r\n                </div>\r\n            ");
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
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>");
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
