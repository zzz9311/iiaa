#pragma checksum "C:\Users\Коля\source\repos\IvritSchool\iiaa\IvritSchool\Views\Home\AddTariff.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "753cf74c168c6842d5b21053e7c9317cf73e6668"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_AddTariff), @"mvc.1.0.view", @"/Views/Home/AddTariff.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"753cf74c168c6842d5b21053e7c9317cf73e6668", @"/Views/Home/AddTariff.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4667547dde8c1f015b9e5b60eb0cd85074b5f138", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_AddTariff : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Коля\source\repos\IvritSchool\iiaa\IvritSchool\Views\Home\AddTariff.cshtml"
  
    ViewBag.Title = "AddDay";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Добавление дня</h2>\r\n<br />\r\n\r\n");
#nullable restore
#line 9 "C:\Users\Коля\source\repos\IvritSchool\iiaa\IvritSchool\Views\Home\AddTariff.cshtml"
 using (Html.AjaxBeginForm("AddTariff", new AjaxOptions { UpdateTargetId = "Result", HttpMethod = "POST" }))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"form-horizontal\">\r\n    <div class=\"form-group\">\r\n        <div class=\"col-md-10\">\r\n            <label for=\"formGroupExampleInput\">Название тарифа</label>\r\n            <input type=\"text\" class=\"form-control\"");
            BeginWriteAttribute("value", " value=\"", 407, "\"", 415, 0);
            EndWriteAttribute();
            WriteLiteral(" name=\"Name\"");
            BeginWriteAttribute("placeholder", " placeholder=\"", 428, "\"", 442, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n        </div>\r\n    </div>\r\n    <div class=\"form-group\">\r\n        <div class=\"col-md-10\">\r\n            <label for=\"formGroupExampleInput\">Дни тарифа(по желанию)</label>\r\n            <input type=\"text\" class=\"form-control\"");
            BeginWriteAttribute("value", " value=\"", 667, "\"", 675, 0);
            EndWriteAttribute();
            WriteLiteral(" name=\"daysPredicate\"");
            BeginWriteAttribute("placeholder", " placeholder=\"", 697, "\"", 711, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n        </div>\r\n    </div>\r\n</div>\r\n    <input type=\"submit\" class=\"form-control\" value=\"Добавить\" />\r\n");
#nullable restore
#line 26 "C:\Users\Коля\source\repos\IvritSchool\iiaa\IvritSchool\Views\Home\AddTariff.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
