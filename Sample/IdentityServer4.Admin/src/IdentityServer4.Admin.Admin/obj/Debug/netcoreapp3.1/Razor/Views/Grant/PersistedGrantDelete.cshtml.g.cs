#pragma checksum "E:\R&D\Sample\IdentityServer4.Admin\src\IdentityServer4.Admin.Admin\Views\Grant\PersistedGrantDelete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7aeb19187b08f5723d2da391d52b2a3282671620"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Grant_PersistedGrantDelete), @"mvc.1.0.view", @"/Views/Grant/PersistedGrantDelete.cshtml")]
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
#line 1 "E:\R&D\Sample\IdentityServer4.Admin\src\IdentityServer4.Admin.Admin\Views\Grant\PersistedGrantDelete.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\R&D\Sample\IdentityServer4.Admin\src\IdentityServer4.Admin.Admin\Views\Grant\PersistedGrantDelete.cshtml"
using Skoruba.IdentityServer4.Admin.BusinessLogic.Identity.Dtos.Grant;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7aeb19187b08f5723d2da391d52b2a3282671620", @"/Views/Grant/PersistedGrantDelete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc3af6262e028ddd2793ef4d843d0dbca7f3ed3c", @"/Views/_ViewImports.cshtml")]
    public class Views_Grant_PersistedGrantDelete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PersistedGrantDto>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Grant", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PersistedGrants", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PersistedGrant", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("client-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PersistedGrantDelete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("Method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 6 "E:\R&D\Sample\IdentityServer4.Admin\src\IdentityServer4.Admin.Admin\Views\Grant\PersistedGrantDelete.cshtml"
  
	ViewBag.Title = Localizer["PageTitle"];
	Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row\">\r\n\t<div class=\"col-12\">\r\n\t\t<nav aria-label=\"breadcrumb\">\r\n\t\t\t<ol class=\"breadcrumb\">\r\n\t\t\t\t<li class=\"breadcrumb-item\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7aeb19187b08f5723d2da391d52b2a32826716206336", async() => {
#nullable restore
#line 15 "E:\R&D\Sample\IdentityServer4.Admin\src\IdentityServer4.Admin.Admin\Views\Grant\PersistedGrantDelete.cshtml"
                                                                                              Write(Localizer["NavigationPersistedGrants"]);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n\t\t\t\t<li class=\"breadcrumb-item\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7aeb19187b08f5723d2da391d52b2a32826716208030", async() => {
#nullable restore
#line 16 "E:\R&D\Sample\IdentityServer4.Admin\src\IdentityServer4.Admin.Admin\Views\Grant\PersistedGrantDelete.cshtml"
                                                                                                                             Write(Model.SubjectId);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 16 "E:\R&D\Sample\IdentityServer4.Admin\src\IdentityServer4.Admin.Admin\Views\Grant\PersistedGrantDelete.cshtml"
                                                                                                    WriteLiteral(Model.SubjectId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n\t\t\t\t<li class=\"breadcrumb-item active\" aria-current=\"page\">");
#nullable restore
#line 17 "E:\R&D\Sample\IdentityServer4.Admin\src\IdentityServer4.Admin.Admin\Views\Grant\PersistedGrantDelete.cshtml"
                                                                  Write(Localizer["PageTitle"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n\t\t\t</ol>\r\n\t\t</nav>\r\n\t</div>\r\n\r\n\t<div class=\"col-12\">\r\n\t\t<h2>");
#nullable restore
#line 23 "E:\R&D\Sample\IdentityServer4.Admin\src\IdentityServer4.Admin.Admin\Views\Grant\PersistedGrantDelete.cshtml"
       Write(Localizer["PageTitle"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n\t</div>\r\n</div>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7aeb19187b08f5723d2da391d52b2a328267162011554", async() => {
                WriteLiteral("\r\n\r\n\t");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7aeb19187b08f5723d2da391d52b2a328267162011819", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
#nullable restore
#line 29 "E:\R&D\Sample\IdentityServer4.Admin\src\IdentityServer4.Admin.Admin\Views\Grant\PersistedGrantDelete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Key);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n\t<div class=\"row table-responsive\">\r\n\t\t<div class=\"col-12\">\r\n\t\t\t<table class=\"table table-striped\">\r\n\t\t\t\t<thead>\r\n\t\t\t\t<tr>\r\n\t\t\t\t\t<th>");
#nullable restore
#line 36 "E:\R&D\Sample\IdentityServer4.Admin\src\IdentityServer4.Admin.Admin\Views\Grant\PersistedGrantDelete.cshtml"
                   Write(Localizer["TableSubjectId"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</th>\r\n\t\t\t\t\t<th>");
#nullable restore
#line 37 "E:\R&D\Sample\IdentityServer4.Admin\src\IdentityServer4.Admin.Admin\Views\Grant\PersistedGrantDelete.cshtml"
                   Write(Localizer["TableType"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</th>\r\n\t\t\t\t\t<th>");
#nullable restore
#line 38 "E:\R&D\Sample\IdentityServer4.Admin\src\IdentityServer4.Admin.Admin\Views\Grant\PersistedGrantDelete.cshtml"
                   Write(Localizer["TableExpiration"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</th>\r\n\t\t\t\t\t<th>");
#nullable restore
#line 39 "E:\R&D\Sample\IdentityServer4.Admin\src\IdentityServer4.Admin.Admin\Views\Grant\PersistedGrantDelete.cshtml"
                   Write(Localizer["TableData"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</th>\r\n\t\t\t\t\t<th>");
#nullable restore
#line 40 "E:\R&D\Sample\IdentityServer4.Admin\src\IdentityServer4.Admin.Admin\Views\Grant\PersistedGrantDelete.cshtml"
                   Write(Localizer["TableClient"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</th>\r\n\t\t\t\t</tr>\r\n\t\t\t\t</thead>\r\n\r\n\t\t\t\t<tbody>\r\n\t\t\t\t<tr>\r\n\t\t\t\t\t<td>");
#nullable restore
#line 46 "E:\R&D\Sample\IdentityServer4.Admin\src\IdentityServer4.Admin.Admin\Views\Grant\PersistedGrantDelete.cshtml"
                   Write(Model.SubjectId);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n\t\t\t\t\t<td>");
#nullable restore
#line 47 "E:\R&D\Sample\IdentityServer4.Admin\src\IdentityServer4.Admin.Admin\Views\Grant\PersistedGrantDelete.cshtml"
                   Write(Model.Type);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n\t\t\t\t\t<td>");
#nullable restore
#line 48 "E:\R&D\Sample\IdentityServer4.Admin\src\IdentityServer4.Admin.Admin\Views\Grant\PersistedGrantDelete.cshtml"
                   Write(Model.Expiration);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n\t\t\t\t\t<td>");
#nullable restore
#line 49 "E:\R&D\Sample\IdentityServer4.Admin\src\IdentityServer4.Admin.Admin\Views\Grant\PersistedGrantDelete.cshtml"
                   Write(Model.Data);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n\t\t\t\t\t<td>");
#nullable restore
#line 50 "E:\R&D\Sample\IdentityServer4.Admin\src\IdentityServer4.Admin.Admin\Views\Grant\PersistedGrantDelete.cshtml"
                   Write(Model.ClientId);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n\t\t\t\t</tr>\r\n\t\t\t\t</tbody>\r\n\t\t\t</table>\r\n\t\t</div>\r\n\t</div>\r\n\r\n\t<div class=\"row\">\r\n\t\t<div class=\"col-md-12\">\r\n\t\t\t<button type=\"submit\" class=\"btn btn-danger\">");
#nullable restore
#line 59 "E:\R&D\Sample\IdentityServer4.Admin\src\IdentityServer4.Admin.Admin\Views\Grant\PersistedGrantDelete.cshtml"
                                                    Write(Localizer["ButtonDeleteGrant"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</button>\r\n\t\t</div>\r\n\t</div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IViewLocalizer Localizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IUrlHelper UrlHelper { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PersistedGrantDto> Html { get; private set; }
    }
}
#pragma warning restore 1591
