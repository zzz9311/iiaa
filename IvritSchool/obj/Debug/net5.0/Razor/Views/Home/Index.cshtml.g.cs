#pragma checksum "E:\BOTs\GitHub\iiaa\IvritSchool\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9bf13f96ecf717d5275690a50d0092a41b3080bc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9bf13f96ecf717d5275690a50d0092a41b3080bc", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a75d35a98527630b80048b3b3dbde19490e16654", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IvritSchool.Entities.BotUser[]>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\BOTs\GitHub\iiaa\IvritSchool\Views\Home\Index.cshtml"
  
    ViewBag.Title = "AdminUserPanel";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Все пользователи бота(");
#nullable restore
#line 6 "E:\BOTs\GitHub\iiaa\IvritSchool\Views\Home\Index.cshtml"
                     Write(Model.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral(@")</h2>

<table class=""table table-bordered"">
    <thead>
        <tr>
            <th scope=""col"">Id</th>
            <th scope=""col"">Name</th>
            <th scope=""col"">First Date</th>
            <th scope=""col"">Telegramm Id</th>
            <th scope=""col"">Редактировать</th>
        </tr>
    </thead>
    <tbody>

");
#nullable restore
#line 20 "E:\BOTs\GitHub\iiaa\IvritSchool\Views\Home\Index.cshtml"
         foreach (var el in Model)
        {
            if (el.IsBanned)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr style=\"background:#FFCCCC\">\r\n                    <th scope=\"row\">");
#nullable restore
#line 25 "E:\BOTs\GitHub\iiaa\IvritSchool\Views\Home\Index.cshtml"
                               Write(el.ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    <td>");
#nullable restore
#line 26 "E:\BOTs\GitHub\iiaa\IvritSchool\Views\Home\Index.cshtml"
                   Write(el.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 27 "E:\BOTs\GitHub\iiaa\IvritSchool\Views\Home\Index.cshtml"
                   Write(el.FirstDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 28 "E:\BOTs\GitHub\iiaa\IvritSchool\Views\Home\Index.cshtml"
                   Write(el.TID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td><a");
            BeginWriteAttribute("href", " href=\"", 799, "\"", 858, 1);
#nullable restore
#line 29 "E:\BOTs\GitHub\iiaa\IvritSchool\Views\Home\Index.cshtml"
WriteAttributeValue("", 806, Url.Action("EditUser", "home", new { Id = @el.ID }), 806, 52, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a></td>\r\n                </tr>\r\n");
#nullable restore
#line 31 "E:\BOTs\GitHub\iiaa\IvritSchool\Views\Home\Index.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <th scope=\"row\">");
#nullable restore
#line 35 "E:\BOTs\GitHub\iiaa\IvritSchool\Views\Home\Index.cshtml"
                               Write(el.ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    <td>");
#nullable restore
#line 36 "E:\BOTs\GitHub\iiaa\IvritSchool\Views\Home\Index.cshtml"
                   Write(el.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 37 "E:\BOTs\GitHub\iiaa\IvritSchool\Views\Home\Index.cshtml"
                   Write(el.FirstDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 38 "E:\BOTs\GitHub\iiaa\IvritSchool\Views\Home\Index.cshtml"
                   Write(el.TID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td><a");
            BeginWriteAttribute("href", " href=\"", 1164, "\"", 1223, 1);
#nullable restore
#line 39 "E:\BOTs\GitHub\iiaa\IvritSchool\Views\Home\Index.cshtml"
WriteAttributeValue("", 1171, Url.Action("EditUser", "home", new { Id = @el.ID }), 1171, 52, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a></td>\r\n                </tr>\r\n");
#nullable restore
#line 41 "E:\BOTs\GitHub\iiaa\IvritSchool\Views\Home\Index.cshtml"
            }
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n<small>*Светло Красный цвет - пользователь забанен</small>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IvritSchool.Entities.BotUser[]> Html { get; private set; }
    }
}
#pragma warning restore 1591
