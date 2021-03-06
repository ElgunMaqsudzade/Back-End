#pragma checksum "C:\Users\USER\Desktop\Back-End\EduHome\Views\Contact\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "21b695e02a727c493d5d766e547e3dbab0d7835d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Contact_Index), @"mvc.1.0.view", @"/Views/Contact/Index.cshtml")]
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
#line 1 "C:\Users\USER\Desktop\Back-End\EduHome\Views\_ViewImports.cshtml"
using EduHome.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\USER\Desktop\Back-End\EduHome\Views\_ViewImports.cshtml"
using EduHome.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\USER\Desktop\Back-End\EduHome\Views\_ViewImports.cshtml"
using System.Globalization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\USER\Desktop\Back-End\EduHome\Views\_ViewImports.cshtml"
using Microsoft.EntityFrameworkCore;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"21b695e02a727c493d5d766e547e3dbab0d7835d", @"/Views/Contact/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"66fd4b7fd03e4826d7dc47206af90b9beb9c55b4", @"/Views/_ViewImports.cshtml")]
    public class Views_Contact_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ContactVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("contact"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("comment-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\USER\Desktop\Back-End\EduHome\Views\Contact\Index.cshtml"
  
    ViewData["Title"] = "Contact";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\Users\USER\Desktop\Back-End\EduHome\Views\Contact\Index.cshtml"
Write(await Component.InvokeAsync("Banner", new { word = "contact" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- Contact Start -->
<div class=""map-area"">
    <!-- google-map-area start -->
    <div class=""google-map-area"">
        <!--  Map Section -->
        <div id=""contacts"" class=""map-area"">
            <div id=""googleMap"" style=""width:100%;height:440px;"" class=""google-map"">
                ");
#nullable restore
#line 14 "C:\Users\USER\Desktop\Back-End\EduHome\Views\Contact\Index.cshtml"
           Write(Html.Raw(Model.MapAddress.Iframe));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </div>
        </div>
    </div>
</div>
<div class=""contact-area pt-150 pb-140"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-5 col-sm-5 col-xs-12"">
                <div class=""contact-contents text-center"">
");
#nullable restore
#line 24 "C:\Users\USER\Desktop\Back-End\EduHome\Views\Contact\Index.cshtml"
                     foreach (Contact c in Model.Contacts)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"single-contact mb-65\">\r\n                            <div class=\"contact-icon\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "21b695e02a727c493d5d766e547e3dbab0d7835d6079", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 973, "~/img/contact/", 973, 14, true);
#nullable restore
#line 28 "C:\Users\USER\Desktop\Back-End\EduHome\Views\Contact\Index.cshtml"
AddHtmlAttributeValue("", 987, c.Image, 987, 8, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n                            <div class=\"contact-add\">\r\n                                <h3>");
#nullable restore
#line 31 "C:\Users\USER\Desktop\Back-End\EduHome\Views\Contact\Index.cshtml"
                               Write(c.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                                ");
#nullable restore
#line 32 "C:\Users\USER\Desktop\Back-End\EduHome\Views\Contact\Index.cshtml"
                           Write(Html.Raw(c.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n");
#nullable restore
#line 35 "C:\Users\USER\Desktop\Back-End\EduHome\Views\Contact\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </div>
            </div>
            <div class=""col-md-7 col-sm-7 col-xs-12"">
                <div class=""reply-area"">
                    <h3>LEAVE A REPLY</h3>
                    <p>I must explain to you how all this a mistaken idea of ncing great explorer of the rut<br> the is lder of human happinescias unde omnis iste natus error sit volptatem </p>
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "21b695e02a727c493d5d766e547e3dbab0d7835d8942", async() => {
                WriteLiteral("\r\n                        <div class=\"row\">\r\n");
#nullable restore
#line 44 "C:\Users\USER\Desktop\Back-End\EduHome\Views\Contact\Index.cshtml"
                             if (!User.Identity.IsAuthenticated)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                <div class=""col-md-12"">
                                    <p>Name</p>
                                    <input type=""text"" name=""name"" id=""name"">
                                </div>
                                <div style=""margin-bottom:20px"" class=""col-md-12"">
                                    <p>Email</p>
                                    <input style=""margin-bottom:0px;"" type=""email"" name=""email"" id=""email"">
                                </div>
");
#nullable restore
#line 54 "C:\Users\USER\Desktop\Back-End\EduHome\Views\Contact\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                            <div class=""col-md-12"">
                                <p>Subject</p>
                                <input type=""text"" name=""subject"" id=""subject"">
                                <p>Message</p>
                                <textarea name=""message"" id=""message"" cols=""15"" rows=""10""></textarea>
                            </div>
                        </div>
                        <button type=""button"" data-url=""/Contact/"" class=""reply-button""><span>send message</span></button>
                        <p class=""form-message""></p>
                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "class", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 42 "C:\Users\USER\Desktop\Back-End\EduHome\Views\Contact\Index.cshtml"
AddHtmlAttributeValue("", 1731, (User.Identity.IsAuthenticated)?"authorized":"", 1731, 50, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n<!-- Contact End -->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ContactVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
