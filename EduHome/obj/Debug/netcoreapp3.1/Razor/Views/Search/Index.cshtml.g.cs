#pragma checksum "C:\Users\USER\Desktop\Back-End\EduHome\Views\Search\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9bca91ce265c62fe43a17249119c64a3ab05f891"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Search_Index), @"mvc.1.0.view", @"/Views/Search/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9bca91ce265c62fe43a17249119c64a3ab05f891", @"/Views/Search/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9f630e9031e164b705cfb34783738a29c2724d19", @"/Views/_ViewImports.cshtml")]
    public class Views_Search_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\USER\Desktop\Back-End\EduHome\Views\Search\Index.cshtml"
  
    ViewData["Title"] = "Search";

#line default
#line hidden
#nullable disable
            WriteLiteral("<!-- Banner Area Start -->\r\n");
#nullable restore
#line 6 "C:\Users\USER\Desktop\Back-End\EduHome\Views\Search\Index.cshtml"
Write(await Component.InvokeAsync("Banner", new { word = "search" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!-- Banner Area End -->\r\n<!-- search Start -->\r\n<div class=\"blog-area pt-150 pb-150\">\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n");
#nullable restore
#line 12 "C:\Users\USER\Desktop\Back-End\EduHome\Views\Search\Index.cshtml"
             if (ViewBag.Card == "Blog")
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\USER\Desktop\Back-End\EduHome\Views\Search\Index.cshtml"
           Write(await Component.InvokeAsync("Blog", new { location = "search" , keyword = (string)ViewBag.Keyword }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\USER\Desktop\Back-End\EduHome\Views\Search\Index.cshtml"
                                                                                                                     
            }
            else if (ViewBag.Card == "Teacher")
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\USER\Desktop\Back-End\EduHome\Views\Search\Index.cshtml"
           Write(await Component.InvokeAsync("Teacher", new { location = "search", keyword = (string)ViewBag.Keyword }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\USER\Desktop\Back-End\EduHome\Views\Search\Index.cshtml"
                                                                                                                       
            }
            else if (ViewBag.Card == "Event")
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Users\USER\Desktop\Back-End\EduHome\Views\Search\Index.cshtml"
           Write(await Component.InvokeAsync("Event", new { location = "search", keyword = (string)ViewBag.Keyword }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Users\USER\Desktop\Back-End\EduHome\Views\Search\Index.cshtml"
                                                                                                                     
            }
            else if (ViewBag.Card == "Course")
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "C:\Users\USER\Desktop\Back-End\EduHome\Views\Search\Index.cshtml"
           Write(await Component.InvokeAsync("Course", new { location = "search", keyword = (string)ViewBag.Keyword }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "C:\Users\USER\Desktop\Back-End\EduHome\Views\Search\Index.cshtml"
                                                                                                                      
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n        </div>\r\n    </div>\r\n</div>\r\n<!-- search End -->");
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