#pragma checksum "C:\Users\Usama Sial\Desktop\TashBlock\Views\Level1\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9850f8581dda05ad46ed65d02ac1df2cf6dc29cd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Level1_List), @"mvc.1.0.view", @"/Views/Level1/List.cshtml")]
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
#line 1 "C:\Users\Usama Sial\Desktop\TashBlock\Views\_ViewImports.cshtml"
using TashBlock;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Usama Sial\Desktop\TashBlock\Views\_ViewImports.cshtml"
using TashBlock.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9850f8581dda05ad46ed65d02ac1df2cf6dc29cd", @"/Views/Level1/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fef6dd8924c5d1ebef5b3dc6c2d034bc0226520f", @"/Views/_ViewImports.cshtml")]
    public class Views_Level1_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<TashBlock.Models.HeadLevel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n\r\n<h2>Level1</h2>\r\n");
            WriteLiteral("    \r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>Action</th>\r\n            <th>\r\n                ");
#nullable restore
#line 14 "C:\Users\Usama Sial\Desktop\TashBlock\Views\Level1\List.cshtml"
           Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 17 "C:\Users\Usama Sial\Desktop\TashBlock\Views\Level1\List.cshtml"
           Write(Html.DisplayNameFor(model => model.Code));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n\r\n\r\n        </tr>\r\n    </thead>\r\n\r\n\r\n");
#nullable restore
#line 25 "C:\Users\Usama Sial\Desktop\TashBlock\Views\Level1\List.cshtml"
       var i = 0;

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "C:\Users\Usama Sial\Desktop\TashBlock\Views\Level1\List.cshtml"
     foreach (var item in Model)
    {
        i++;

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n\r\n            <td>\r\n                ");
#nullable restore
#line 32 "C:\Users\Usama Sial\Desktop\TashBlock\Views\Level1\List.cshtml"
           Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 35 "C:\Users\Usama Sial\Desktop\TashBlock\Views\Level1\List.cshtml"
           Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 38 "C:\Users\Usama Sial\Desktop\TashBlock\Views\Level1\List.cshtml"
           Write(Html.DisplayFor(modelItem => item.Code));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 41 "C:\Users\Usama Sial\Desktop\TashBlock\Views\Level1\List.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new { id = item.Id, item.Name, item.Code }, new { @class = "btn btn-success" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                ");
#nullable restore
#line 42 "C:\Users\Usama Sial\Desktop\TashBlock\Views\Level1\List.cshtml"
           Write(Html.ActionLink("Delete", "DeleteStd", new { id = item.Id }, new { @class = "btn btn-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n\r\n        </tr>\r\n");
#nullable restore
#line 46 "C:\Users\Usama Sial\Desktop\TashBlock\Views\Level1\List.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("   \r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<TashBlock.Models.HeadLevel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
