#pragma checksum "C:\Users\Коля\source\repos\IvritSchool\iiaa\IvritSchool\Views\Home\EditMessage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dcefa738943ef7476fa8896c33d42ee414fc4d8a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_EditMessage), @"mvc.1.0.view", @"/Views/Home/EditMessage.cshtml")]
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
#line 1 "C:\Users\Коля\source\repos\IvritSchool\iiaa\IvritSchool\Views\_ViewImports.cshtml"
using IvritSchool;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Коля\source\repos\IvritSchool\iiaa\IvritSchool\Views\_ViewImports.cshtml"
using IvritSchool.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dcefa738943ef7476fa8896c33d42ee414fc4d8a", @"/Views/Home/EditMessage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4667547dde8c1f015b9e5b60eb0cd85074b5f138", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_EditMessage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IvritSchool.Entities.Message>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Коля\source\repos\IvritSchool\iiaa\IvritSchool\Views\Home\EditMessage.cshtml"
  
    ViewBag.Title = "EditUser";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Редактирования сообщения</h2>\r\n\r\n");
#nullable restore
#line 9 "C:\Users\Коля\source\repos\IvritSchool\iiaa\IvritSchool\Views\Home\EditMessage.cshtml"
 using (Html.AjaxBeginForm("EditMessage", new AjaxOptions { UpdateTargetId = "Result", HttpMethod = "POST" }))
{
    

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"form-horizontal\">\r\n        <div class=\"form-group\">\r\n            <div class=\"col-md-10\">\r\n                <label for=\"formGroupExampleInput\">Текст сообщения</label>\r\n                <input type=\"text\" class=\"form-control\"");
            BeginWriteAttribute("value", " value=\"", 806, "\"", 825, 1);
#nullable restore
#line 24 "C:\Users\Коля\source\repos\IvritSchool\iiaa\IvritSchool\Views\Home\EditMessage.cshtml"
WriteAttributeValue("", 814, Model.Text, 814, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"Text\"");
            BeginWriteAttribute("placeholder", " placeholder=\"", 838, "\"", 852, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
            WriteLiteral("    <input type=\"submit\" class=\"form-control\" value=\"Изменить\" />\r\n");
#nullable restore
#line 30 "C:\Users\Коля\source\repos\IvritSchool\iiaa\IvritSchool\Views\Home\EditMessage.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<div>\r\n    <h3 id=\"Result\"></h3>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IvritSchool.Entities.Message> Html { get; private set; }
    }
}
#pragma warning restore 1591
