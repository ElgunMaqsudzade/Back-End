#pragma checksum "C:\Users\USER\Desktop\Back-End\EduHome\Areas\Admin\Views\Shared\_ProfessionPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "480fe200cccf647588d938b213f0dd82a81ffffe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Shared__ProfessionPartial), @"mvc.1.0.view", @"/Areas/Admin/Views/Shared/_ProfessionPartial.cshtml")]
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
#line 1 "C:\Users\USER\Desktop\Back-End\EduHome\Areas\Admin\Views\_ViewImports.cshtml"
using EduHome.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\USER\Desktop\Back-End\EduHome\Areas\Admin\Views\_ViewImports.cshtml"
using EduHome.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"480fe200cccf647588d938b213f0dd82a81ffffe", @"/Areas/Admin/Views/Shared/_ProfessionPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9c3afeff41c51bf38f0cd00db4ff1ed60d3bead0", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Shared__ProfessionPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Profession>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\USER\Desktop\Back-End\EduHome\Areas\Admin\Views\Shared\_ProfessionPartial.cshtml"
  
    int count = (int)ViewBag.Skip + 1;
    string url = "Profession";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\USER\Desktop\Back-End\EduHome\Areas\Admin\Views\Shared\_ProfessionPartial.cshtml"
 foreach (Profession e in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <tr class=\"text-center\">\r\n        <td>");
#nullable restore
#line 10 "C:\Users\USER\Desktop\Back-End\EduHome\Areas\Admin\Views\Shared\_ProfessionPartial.cshtml"
       Write(count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 11 "C:\Users\USER\Desktop\Back-End\EduHome\Areas\Admin\Views\Shared\_ProfessionPartial.cshtml"
       Write(e.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>\r\n            <button data-delete=\"");
#nullable restore
#line 13 "C:\Users\USER\Desktop\Back-End\EduHome\Areas\Admin\Views\Shared\_ProfessionPartial.cshtml"
                            Write(e.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-url=\"");
#nullable restore
#line 13 "C:\Users\USER\Desktop\Back-End\EduHome\Areas\Admin\Views\Shared\_ProfessionPartial.cshtml"
                                             Write(url);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"btn btn-sm btn-danger delete\">Delete</button>\r\n        </td>\r\n    </tr>\r\n");
#nullable restore
#line 16 "C:\Users\USER\Desktop\Back-End\EduHome\Areas\Admin\Views\Shared\_ProfessionPartial.cshtml"
    count++;
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Profession>> Html { get; private set; }
    }
}
#pragma warning restore 1591