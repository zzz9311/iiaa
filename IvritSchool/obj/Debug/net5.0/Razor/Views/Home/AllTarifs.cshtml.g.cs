#pragma checksum "E:\BOTs\GitHub\iiaa\IvritSchool\Views\Home\AllTarifs.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "23007f141f17f78f8fcf48be20337a7c141dfb9c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_AllTarifs), @"mvc.1.0.view", @"/Views/Home/AllTarifs.cshtml")]
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
#line 1 "E:\BOTs\GitHub\iiaa\IvritSchool\Views\_ViewImports.cshtml"
using IvritSchool;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\BOTs\GitHub\iiaa\IvritSchool\Views\_ViewImports.cshtml"
using IvritSchool.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\BOTs\GitHub\iiaa\IvritSchool\Views\_ViewImports.cshtml"
using IvritSchool.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23007f141f17f78f8fcf48be20337a7c141dfb9c", @"/Views/Home/AllTarifs.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a75d35a98527630b80048b3b3dbde19490e16654", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_AllTarifs : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IvritSchool.Entities.Tariff[]>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\BOTs\GitHub\iiaa\IvritSchool\Views\Home\AllTarifs.cshtml"
  
    ViewBag.Title = "AdminUserPanel";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Все тарифы(");
#nullable restore
#line 6 "E:\BOTs\GitHub\iiaa\IvritSchool\Views\Home\AllTarifs.cshtml"
          Write(Model.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral(@")</h2>

<table class=""table table-bordered"">
    <thead>
        <tr>
            <th scope=""col"">Id</th>
            <th scope=""col"">Название тарифа</th>
            <th scope=""col"">VIP</th>
            <th scope=""col"">Редактировать</th>
        </tr>
    </thead>
    <tbody>

");
#nullable restore
#line 19 "E:\BOTs\GitHub\iiaa\IvritSchool\Views\Home\AllTarifs.cshtml"
         foreach (var el in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <th scope=\"row\">");
#nullable restore
#line 22 "E:\BOTs\GitHub\iiaa\IvritSchool\Views\Home\AllTarifs.cshtml"
                       Write(el.ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <td>");
#nullable restore
#line 23 "E:\BOTs\GitHub\iiaa\IvritSchool\Views\Home\AllTarifs.cshtml"
           Write(el.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 24 "E:\BOTs\GitHub\iiaa\IvritSchool\Views\Home\AllTarifs.cshtml"
            Write(el.VIP == true ? "ДА":"НЕТ");

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td><a");
            BeginWriteAttribute("href", " href=\"", 611, "\"", 669, 1);
#nullable restore
#line 25 "E:\BOTs\GitHub\iiaa\IvritSchool\Views\Home\AllTarifs.cshtml"
WriteAttributeValue("", 618, Url.Action("EditDay", "home", new { Id = @el.ID }), 618, 51, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Редактировать</a></td>\r\n        </tr>\r\n");
#nullable restore
#line 27 "E:\BOTs\GitHub\iiaa\IvritSchool\Views\Home\AllTarifs.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IvritSchool.Entities.Tariff[]> Html { get; private set; }
    }
}
#pragma warning restore 1591