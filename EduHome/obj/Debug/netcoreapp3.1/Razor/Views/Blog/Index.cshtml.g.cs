#pragma checksum "C:\Users\USER\Desktop\Back-End\EduHome\Views\Blog\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ccbebf87063a56256e339ea5e37f054df5929411"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Blog_Index), @"mvc.1.0.view", @"/Views/Blog/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ccbebf87063a56256e339ea5e37f054df5929411", @"/Views/Blog/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e85d917dd075295caa7983623ba4b48c3bb4844", @"/Views/_ViewImports.cshtml")]
    public class Views_Blog_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("search"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("#"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\USER\Desktop\Back-End\EduHome\Views\Blog\Index.cshtml"
  
    ViewData["Title"] = "Blog";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\Users\USER\Desktop\Back-End\EduHome\Views\Blog\Index.cshtml"
Write(await Component.InvokeAsync("Banner", new { word = "blog / right side bar" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- Blog Start -->
<div class=""blog-area pt-150 pb-150"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-8"">
                <div class=""row"">
                    <div class=""col-md-6 col-sm-6 col-xs-12"">
                        <div class=""single-blog mb-60"">
                            <div class=""blog-img"">
                                <a href=""#""><img src=""img/blog/blog1.jpg"" alt=""blog""></a>
                                <div class=""blog-hover"">
                                    <i class=""fa fa-link""></i>
                                </div>
                            </div>
                            <div class=""blog-content"">
                                <div class=""blog-top"">
                                    <p>By Alex  /  June 20, 2017  /  <i class=""fa fa-comments-o""></i> 4</p>
                                </div>
                                <div class=""blog-bottom"">
                                    <h2><a href=""blog-");
            WriteLiteral(@"details.html"">I must explain to you how all this a mistaken idea </a></h2>
                                    <a href=""blog-details.html"">read more</a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class=""col-md-6 col-sm-6 col-xs-12"">
                        <div class=""single-blog mb-60"">
                            <div class=""blog-img"">
                                <a href=""#""><img src=""img/blog/blog2.jpg"" alt=""blog""></a>
                                <div class=""blog-hover"">
                                    <i class=""fa fa-link""></i>
                                </div>
                            </div>
                            <div class=""blog-content"">
                                <div class=""blog-top"">
                                    <p>By Alex  /  June 20, 2017  /  <i class=""fa fa-comments-o""></i> 4</p>
                                </div>
           ");
            WriteLiteral(@"                     <div class=""blog-bottom"">
                                    <h2><a href=""blog-details.html"">I must explain to you how all this a mistaken idea </a></h2>
                                    <a href=""blog-details.html"">read more</a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class=""col-md-6 col-sm-6 col-xs-12"">
                        <div class=""single-blog mb-60"">
                            <div class=""blog-img"">
                                <a href=""#""><img src=""img/blog/blog3.jpg"" alt=""blog""></a>
                                <div class=""blog-hover"">
                                    <i class=""fa fa-link""></i>
                                </div>
                            </div>
                            <div class=""blog-content"">
                                <div class=""blog-top"">
                                    <p>By Alex  /  June 20");
            WriteLiteral(@", 2017  /  <i class=""fa fa-comments-o""></i> 4</p>
                                </div>
                                <div class=""blog-bottom"">
                                    <h2><a href=""blog-details.html"">I must explain to you how all this a mistaken idea </a></h2>
                                    <a href=""blog-details.html"">read more</a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class=""col-md-6 col-sm-6 col-xs-12"">
                        <div class=""single-blog mb-60"">
                            <div class=""blog-img"">
                                <a href=""#""><img src=""img/blog/blog4.jpg"" alt=""blog""></a>
                                <div class=""blog-hover"">
                                    <i class=""fa fa-link""></i>
                                </div>
                            </div>
                            <div class=""blog-content"">
            ");
            WriteLiteral(@"                    <div class=""blog-top"">
                                    <p>By Alex  /  June 20, 2017  /  <i class=""fa fa-comments-o""></i> 4</p>
                                </div>
                                <div class=""blog-bottom"">
                                    <h2><a href=""blog-details.html"">I must explain to you how all this a mistaken idea </a></h2>
                                    <a href=""blog-details.html"">read more</a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class=""col-md-6 col-sm-6 col-xs-12"">
                        <div class=""single-blog"">
                            <div class=""blog-img"">
                                <a href=""#""><img src=""img/blog/blog5.jpg"" alt=""blog""></a>
                                <div class=""blog-hover"">
                                    <i class=""fa fa-link""></i>
                                </div>
        ");
            WriteLiteral(@"                    </div>
                            <div class=""blog-content"">
                                <div class=""blog-top"">
                                    <p>By Alex  /  June 20, 2017  /  <i class=""fa fa-comments-o""></i> 4</p>
                                </div>
                                <div class=""blog-bottom"">
                                    <h2><a href=""blog-details.html"">I must explain to you how all this a mistaken idea </a></h2>
                                    <a href=""blog-details.html"">read more</a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class=""col-md-6 col-sm-6 col-xs-12"">
                        <div class=""single-blog"">
                            <div class=""blog-img"">
                                <a href=""#""><img src=""img/blog/blog6.jpg"" alt=""blog""></a>
                                <div class=""blog-hover"">
                ");
            WriteLiteral(@"                    <i class=""fa fa-link""></i>
                                </div>
                            </div>
                            <div class=""blog-content"">
                                <div class=""blog-top"">
                                    <p>By Alex  /  June 20, 2017  /  <i class=""fa fa-comments-o""></i> 4</p>
                                </div>
                                <div class=""blog-bottom"">
                                    <h2><a href=""blog-details.html"">I must explain to you how all this a mistaken idea </a></h2>
                                    <a href=""blog-details.html"">read more</a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class=""col-md-12"">
                        <div class=""pagination"">
                            <ul>
                                <li><a href=""#"">1</a></li>
                                <li><a href=""#");
            WriteLiteral(@""">2</a></li>
                                <li><a href=""#"">3</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""col-md-4"">
                <div class=""blog-sidebar right"">
                    <div class=""single-blog-widget mb-50"">
                        <h3>search</h3>
                        <div class=""blog-search"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ccbebf87063a56256e339ea5e37f054df592941112400", async() => {
                WriteLiteral(@"
                                <input type=""search"" placeholder=""Search..."" name=""search"" />
                                <button type=""submit"">
                                    <span><i class=""fa fa-search""></i></span>
                                </button>
                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
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
                    <div class=""single-blog-widget mb-50"">
                        <h3>categories</h3>
                        <ul>
                            <li><a href=""#"">CSS Engineering (10)</a></li>
                            <li><a href=""#"">Political Science (12)</a></li>
                            <li><a href=""#"">Micro Biology (08)</a></li>
                            <li><a href=""#"">HTML5 &amp; CSS3 (15)</a></li>
                            <li><a href=""#"">Web Design (20)</a></li>
                            <li><a href=""#"">PHP (23)</a></li>
                        </ul>
                    </div>
                    <div class=""single-blog-widget mb-50"">
                        <div class=""single-blog-banner"">
                            <a href=""blog-details.html"" id=""blog""><img src=""img/blog/blog-img.jpg"" alt=""blog""></a>
                            <h2>best<br> eductaion<br> theme</h2>
                        </div>
 ");
            WriteLiteral(@"                   </div>
                    <div class=""single-blog-widget mb-50"">
                        <h3>latest post</h3>
                        <div class=""single-post mb-30"">
                            <div class=""single-post-img"">
                                <a href=""blog-details.html"">
                                    <img src=""img/post/post1.jpg"" alt=""post"">
                                    <div class=""blog-hover"">
                                        <i class=""fa fa-link""></i>
                                    </div>
                                </a>
                            </div>
                            <div class=""single-post-content"">
                                <h4><a href=""blog-details.html"">English Language Course for you</a></h4>
                                <p>By Alex  /  June 20, 2017</p>
                            </div>
                        </div>
                        <div class=""single-post mb-30"">
                          ");
            WriteLiteral(@"  <div class=""single-post-img"">
                                <a href=""blog-details.html"">
                                    <img src=""img/post/post2.jpg"" alt=""post"">
                                    <div class=""blog-hover"">
                                        <i class=""fa fa-link""></i>
                                    </div>
                                </a>
                            </div>
                            <div class=""single-post-content"">
                                <h4><a href=""blog-details.html"">Advance Web Design and Develop</a></h4>
                                <p>By Alex  /  June 20, 2017</p>
                            </div>
                        </div>
                        <div class=""single-post"">
                            <div class=""single-post-img"">
                                <a href=""blog-details.html"">
                                    <img src=""img/post/post3.jpg"" alt=""post"">
                                    <div class=""b");
            WriteLiteral(@"log-hover"">
                                        <i class=""fa fa-link""></i>
                                    </div>
                                </a>
                            </div>
                            <div class=""single-post-content"">
                                <h4><a href=""blog-details.html"">English Language Course for you</a></h4>
                                <p>By Alex  /  June 20, 2017</p>
                            </div>
                        </div>
                    </div>
                    <div class=""single-blog-widget"">
                        <h3>tags</h3>
                        <div class=""single-tag"">
                            <a href=""blog-details.html"" class=""mr-10 mb-10"">course</a>
                            <a href=""blog-details.html"" class=""mr-10 mb-10"">education</a>
                            <a href=""blog-details.html"" class=""mb-10"">teachers</a>
                            <a href=""blog-details.html"" class=""mr-10"">learning</a>
    ");
            WriteLiteral(@"                        <a href=""blog-details.html"" class=""mr-10"">university</a>
                            <a href=""blog-details.html"">events</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- Blog End -->");
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
