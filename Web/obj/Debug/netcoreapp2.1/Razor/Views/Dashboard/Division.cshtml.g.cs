#pragma checksum "D:\MII\MIICC\#14-MateriCore\ProjectCore\Web\Views\Dashboard\Division.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "74961b147b2ea1fd347317872f207e612cf203b0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Dashboard_Division), @"mvc.1.0.view", @"/Views/Dashboard/Division.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Dashboard/Division.cshtml", typeof(AspNetCore.Views_Dashboard_Division))]
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
#line 1 "D:\MII\MIICC\#14-MateriCore\ProjectCore\Web\Views\_ViewImports.cshtml"
using Web;

#line default
#line hidden
#line 2 "D:\MII\MIICC\#14-MateriCore\ProjectCore\Web\Views\_ViewImports.cshtml"
using Web.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74961b147b2ea1fd347317872f207e612cf203b0", @"/Views/Dashboard/Division.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74b0619e1a302f0598271da1847e697c39d57b88", @"/Views/_ViewImports.cshtml")]
    public class Views_Dashboard_Division : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Script/DivScript.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "D:\MII\MIICC\#14-MateriCore\ProjectCore\Web\Views\Dashboard\Division.cshtml"
  
    ViewData["Title"] = "Division";
    Layout = "~/Views/Layout/_Layout.cshtml";

#line default
#line hidden
            BeginContext(93, 1318, true);
            WriteLiteral(@"

<!-- DataTales Example -->
<div class=""card shadow mb-4"">
    <div class=""card-header py-3"">
        <div class=""d-flex flex-row align-content-between justify-content-between"">
            <h5 class=""m-0 font-weight-bold text-primary"">Table</h5>
            <div data-toggle=""modal"" data-target=""#myModal"" onclick=""ClearScreen();"">
                <button class=""btn btn-outline-success btn-circle"" data-toggle=""tooltip"" data-placement=""top"" data-animation=""false"" title=""Add"">
                    <i class=""fa fa-plus""></i>
                </button>
            </div>
        </div>
    </div>
    <div class=""card-body"">
        <!-- Modal -->
        <div class=""modal fade"" id=""myModal"" tabindex=""-1"" role=""dialog"" aria-hidden=""true"">
            <div class=""modal-dialog"" role=""document"">
                <div class=""modal-content"">
                    <div class=""modal-header no-bd"">
                        <h5 class=""modal-title""><span class=""fw-mediumbold"">Department</span></h5>
          ");
            WriteLiteral(@"              <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                            <span aria-hidden=""true"">&times;</span>
                        </button>
                    </div>
                    <div class=""modal-body"">
                        ");
            EndContext();
            BeginContext(1411, 1057, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c1c3317f28aa491a8660a6dab77105e8", async() => {
                BeginContext(1417, 1044, true);
                WriteLiteral(@"
                            <div class=""row"">
                                <input type=""text"" id=""Id"" name=""Id"" class=""form-control"" hidden>
                                <div class=""col-sm-12"">
                                    <div class=""form-group form-group-default"">
                                        <label>Division Name</label>
                                        <input type=""text"" id=""Name"" name=""Name"" class=""form-control"" placeholder=""fill Division Name"">
                                    </div>
                                </div>
                                <div class=""col-sm-12"">
                                    <div class=""form-group form-group-default"">
                                        <label>Department</label>
                                        <select class=""form-control"" id=""DepartOption"" name=""DepartOption""></select>
                                    </div>
                                </div>
                            </div>
    ");
                WriteLiteral("                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2468, 1170, true);
            WriteLiteral(@"
                    </div>
                    <div class=""modal-footer no-bd"">
                        <button type=""button"" id=""add"" class=""btn btn-outline-success"" data-dismiss=""modal"" onclick=""Save();"">Insert</button>
                        <button type=""button"" id=""update"" class=""btn btn-outline-warning"" data-dismiss=""modal"" onclick=""Update();"">Update</button>
                        <button type=""button"" class=""btn btn-outline-danger"" data-dismiss=""modal"">Close</button>
                    </div>
                </div>
            </div>
        </div>
        <!-- End Modal -->

        <div class=""table-responsive"">
            <table class=""table table-bordered"" id=""Department"" width=""100%"" cellspacing=""0"">
                <thead>
                    <tr>
                        <th>#</th>
                        <th>Division</th>
                        <th>Department Name</th>
                        <th>Created Date</th>
                        <th>Updated Date</th>
        ");
            WriteLiteral("                <th>Action</th>\r\n                    </tr>\r\n                </thead>\r\n            </table>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(3655, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(3661, 48, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "58ef0a37911d4805bd096f94b74a599a", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3709, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            BeginContext(3714, 2, true);
            WriteLiteral("\r\n");
            EndContext();
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
