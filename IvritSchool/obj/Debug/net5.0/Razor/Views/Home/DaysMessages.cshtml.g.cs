#pragma checksum "K:\Users\nikol\source\repos\IvritSchool\IvritSchool\Views\Home\DaysMessages.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bc1fa7549c4b345c19ba5310e4fdfd45bcebad13"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_DaysMessages), @"mvc.1.0.view", @"/Views/Home/DaysMessages.cshtml")]
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
#line 1 "K:\Users\nikol\source\repos\IvritSchool\IvritSchool\Views\_ViewImports.cshtml"
using IvritSchool;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "K:\Users\nikol\source\repos\IvritSchool\IvritSchool\Views\_ViewImports.cshtml"
using IvritSchool.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "K:\Users\nikol\source\repos\IvritSchool\IvritSchool\Views\_ViewImports.cshtml"
using IvritSchool.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bc1fa7549c4b345c19ba5310e4fdfd45bcebad13", @"/Views/Home/DaysMessages.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a75d35a98527630b80048b3b3dbde19490e16654", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_DaysMessages : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IvritSchool.Entities.Message[]>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "K:\Users\nikol\source\repos\IvritSchool\IvritSchool\Views\Home\DaysMessages.cshtml"
  
    ViewBag.Title = "AdminUserPanel";

    string GetName(int messageType)
    {
        switch(messageType)
        {
            case 1: return "Текcтовое сообщение";
        }
        return "Неопознаное сообщение";
    }
    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Все дни учебного плана(");
#nullable restore
#line 15 "K:\Users\nikol\source\repos\IvritSchool\IvritSchool\Views\Home\DaysMessages.cshtml"
                      Write(Model.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral(@")</h2>

<table class=""table table-bordered"">
    <thead>
        <tr>
            <th scope=""col"">Id</th>
            <th scope=""col"">VIP</th>
            <th scope=""col"">Тип сообщения</th>
            <th scope=""col"">Редактировать</th>
        </tr>
    </thead>
    <tbody>

");
#nullable restore
#line 28 "K:\Users\nikol\source\repos\IvritSchool\IvritSchool\Views\Home\DaysMessages.cshtml"
         foreach (var el in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <th scope=\"row\">");
#nullable restore
#line 31 "K:\Users\nikol\source\repos\IvritSchool\IvritSchool\Views\Home\DaysMessages.cshtml"
                       Write(el.ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <td>");
#nullable restore
#line 32 "K:\Users\nikol\source\repos\IvritSchool\IvritSchool\Views\Home\DaysMessages.cshtml"
            Write(el.VIP == true ? "ДА":"НЕТ");

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 33 "K:\Users\nikol\source\repos\IvritSchool\IvritSchool\Views\Home\DaysMessages.cshtml"
           Write(GetName((int)el.Type));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td><a");
            BeginWriteAttribute("href", " href=\"", 836, "\"", 905, 1);
#nullable restore
#line 34 "K:\Users\nikol\source\repos\IvritSchool\IvritSchool\Views\Home\DaysMessages.cshtml"
WriteAttributeValue("", 843, Url.Action("EditMessage", "home", new { messageID = @el.ID }), 843, 62, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Редактировать</a></td>\r\n        </tr>\r\n");
#nullable restore
#line 36 "K:\Users\nikol\source\repos\IvritSchool\IvritSchool\Views\Home\DaysMessages.cshtml"

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IvritSchool.Entities.Message[]> Html { get; private set; }
    }
}
#pragma warning restore 1591
