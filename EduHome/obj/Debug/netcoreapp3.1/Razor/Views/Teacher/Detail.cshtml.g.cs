#pragma checksum "C:\Users\USER\Desktop\Back-End\EduHome\Views\Teacher\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dc92d897ae5158d1fc46f4376b1af6b3d227937e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Teacher_Detail), @"mvc.1.0.view", @"/Views/Teacher/Detail.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dc92d897ae5158d1fc46f4376b1af6b3d227937e", @"/Views/Teacher/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"66fd4b7fd03e4826d7dc47206af90b9beb9c55b4", @"/Views/_ViewImports.cshtml")]
    public class Views_Teacher_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TeacherSimple>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("teacher"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 2 "C:\Users\USER\Desktop\Back-End\EduHome\Views\Teacher\Detail.cshtml"
  
    ViewData["Title"] = "Detail";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!-- Banner Area Start -->\r\n");
#nullable restore
#line 7 "C:\Users\USER\Desktop\Back-End\EduHome\Views\Teacher\Detail.cshtml"
Write(await Component.InvokeAsync("Banner", new { word = "teachers / details" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- Banner Area End -->
<!-- Teacher Start -->
<div class=""teacher-details-area pt-150 pb-60"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-5 col-sm-5 col-xs-12"">
                <div class=""teacher-details-img"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "dc92d897ae5158d1fc46f4376b1af6b3d227937e4547", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 462, "~/img/teacher/", 462, 14, true);
#nullable restore
#line 15 "C:\Users\USER\Desktop\Back-End\EduHome\Views\Teacher\Detail.cshtml"
AddHtmlAttributeValue("", 476, Model.Image, 476, 12, false);

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
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"col-md-7 col-sm-7 col-xs-12\">\r\n                <div class=\"teacher-details-content ml-50\">\r\n                    <h2>");
#nullable restore
#line 20 "C:\Users\USER\Desktop\Back-End\EduHome\Views\Teacher\Detail.cshtml"
                   Write(Model.Fullname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                    <h5>");
#nullable restore
#line 21 "C:\Users\USER\Desktop\Back-End\EduHome\Views\Teacher\Detail.cshtml"
                   Write(Model.Profession.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                    <h4>about me</h4>\r\n                    <p>");
#nullable restore
#line 23 "C:\Users\USER\Desktop\Back-End\EduHome\Views\Teacher\Detail.cshtml"
                  Write(Model.TeacherDetail.AboutContent);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    <ul>\r\n                        <li><span>degree: </span>");
#nullable restore
#line 25 "C:\Users\USER\Desktop\Back-End\EduHome\Views\Teacher\Detail.cshtml"
                                            Write(Model.TeacherDetail.Degree);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                        <li><span>experience: </span>");
#nullable restore
#line 26 "C:\Users\USER\Desktop\Back-End\EduHome\Views\Teacher\Detail.cshtml"
                                                Write(Model.TeacherDetail.Experience);

#line default
#line hidden
#nullable disable
            WriteLiteral(" years experience</li>\r\n                        <li><span>hobbies: </span>");
#nullable restore
#line 27 "C:\Users\USER\Desktop\Back-End\EduHome\Views\Teacher\Detail.cshtml"
                                             Write(Model.TeacherDetail.Hobbies);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                        <li><span>faculty: </span>");
#nullable restore
#line 28 "C:\Users\USER\Desktop\Back-End\EduHome\Views\Teacher\Detail.cshtml"
                                             Write(Model.TeacherDetail.Faculty);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</li>
                    </ul>
                </div>
            </div>
        </div>
        <div class=""row"">
            <div class=""col-md-3 col-sm-4"">
                <div class=""teacher-contact"">
                    <h4>contact information</h4>
                    <p><span>mail me : </span>");
#nullable restore
#line 37 "C:\Users\USER\Desktop\Back-End\EduHome\Views\Teacher\Detail.cshtml"
                                         Write(Model.TeacherDetail.Mail);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    <p><span>make a call : </span>");
#nullable restore
#line 38 "C:\Users\USER\Desktop\Back-End\EduHome\Views\Teacher\Detail.cshtml"
                                             Write(Model.TeacherDetail.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    <p><span>skype : </span>");
#nullable restore
#line 39 "C:\Users\USER\Desktop\Back-End\EduHome\Views\Teacher\Detail.cshtml"
                                       Write(Model.TeacherDetail.Skype);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    <ul>\r\n");
#nullable restore
#line 41 "C:\Users\USER\Desktop\Back-End\EduHome\Views\Teacher\Detail.cshtml"
                         foreach (SocialMedia s in Model.SocialMedias)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li><a");
            BeginWriteAttribute("href", " href=\"", 1903, "\"", 1917, 1);
#nullable restore
#line 43 "C:\Users\USER\Desktop\Back-End\EduHome\Views\Teacher\Detail.cshtml"
WriteAttributeValue("", 1910, s.Link, 1910, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 43 "C:\Users\USER\Desktop\Back-End\EduHome\Views\Teacher\Detail.cshtml"
                                             Write(Html.Raw(s.Icon));

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 44 "C:\Users\USER\Desktop\Back-End\EduHome\Views\Teacher\Detail.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </ul>
                </div>
            </div>
            <div class=""col-md-9 col-sm-8"">
                <div class=""skill-area"">
                    <h4>skills</h4>
                </div>
                <div class=""skill-wrapper"">
                    <div class=""row"">
");
#nullable restore
#line 54 "C:\Users\USER\Desktop\Back-End\EduHome\Views\Teacher\Detail.cshtml"
                         foreach (TeacherSkill t in Model.TeacherDetail.TeacherSkills)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"col-sm-4\">\r\n                                <div class=\"skill-bar-item\">\r\n                                    <span>");
#nullable restore
#line 58 "C:\Users\USER\Desktop\Back-End\EduHome\Views\Teacher\Detail.cshtml"
                                     Write(t.Skill.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                    <div class=\"progress\">\r\n                                        <div data-wow-delay=\"1.2s\" data-wow-duration=\"1.5s\"");
            BeginWriteAttribute("style", " style=\"", 2721, "\"", 2850, 11);
            WriteAttributeValue("", 2729, "width:", 2729, 6, true);
#nullable restore
#line 60 "C:\Users\USER\Desktop\Back-End\EduHome\Views\Teacher\Detail.cshtml"
WriteAttributeValue(" ", 2735, t.Skill.Value, 2736, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2750, "%;", 2750, 2, true);
            WriteAttributeValue(" ", 2752, "visibility:", 2753, 12, true);
            WriteAttributeValue(" ", 2764, "visible;", 2765, 9, true);
            WriteAttributeValue(" ", 2773, "animation-duration:", 2774, 20, true);
            WriteAttributeValue(" ", 2793, "1.5s;", 2794, 6, true);
            WriteAttributeValue(" ", 2799, "animation-delay:", 2800, 17, true);
            WriteAttributeValue(" ", 2816, "1.2s;", 2817, 6, true);
            WriteAttributeValue(" ", 2822, "animation-name:", 2823, 16, true);
            WriteAttributeValue(" ", 2838, "fadeInLeft;", 2839, 12, true);
            EndWriteAttribute();
            WriteLiteral(" data-progress=\"50%\" class=\"progress-bar wow fadeInLeft\">\r\n                                            <span class=\"text-top\">");
#nullable restore
#line 61 "C:\Users\USER\Desktop\Back-End\EduHome\Views\Teacher\Detail.cshtml"
                                                              Write(t.Skill.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("%</span>\r\n                                        </div>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n");
#nullable restore
#line 66 "C:\Users\USER\Desktop\Back-End\EduHome\Views\Teacher\Detail.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n<!-- Teacher End -->\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TeacherSimple> Html { get; private set; }
    }
}
#pragma warning restore 1591
