#pragma checksum "D:\PROJECTS\Project1\MvcMovie\MvcMovie\MvcMovie\Views\Admin\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7a71f05e20a50504f51b98b6d4146e68c18540bc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Details), @"mvc.1.0.view", @"/Views/Admin/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Admin/Details.cshtml", typeof(AspNetCore.Views_Admin_Details))]
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
#line 1 "D:\PROJECTS\Project1\MvcMovie\MvcMovie\MvcMovie\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "D:\PROJECTS\Project1\MvcMovie\MvcMovie\MvcMovie\Views\_ViewImports.cshtml"
using MvcMovie;

#line default
#line hidden
#line 3 "D:\PROJECTS\Project1\MvcMovie\MvcMovie\MvcMovie\Views\_ViewImports.cshtml"
using MvcMovie.Models;

#line default
#line hidden
#line 4 "D:\PROJECTS\Project1\MvcMovie\MvcMovie\MvcMovie\Views\_ViewImports.cshtml"
using MvcMovie.Models.AccountViewModels;

#line default
#line hidden
#line 5 "D:\PROJECTS\Project1\MvcMovie\MvcMovie\MvcMovie\Views\_ViewImports.cshtml"
using MvcMovie.Models.ManageViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7a71f05e20a50504f51b98b6d4146e68c18540bc", @"/Views/Admin/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e230dfb742f77776b61ac8ddaba31f15e40b5160", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MvcMovie.Models.Movie>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(30, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\PROJECTS\Project1\MvcMovie\MvcMovie\MvcMovie\Views\Admin\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(75, 406, true);
            WriteLiteral(@"
                <div>

                    <div class=""modal-header"">
                        <button type=""button"" class=""close"" data-dismiss=""modal"" aria-hidden=""true"">×</button>
                        <h4 class=""modal-title"" id=""myModalLabel"">Film Details</h4>
                    </div>
                    <dl class=""dl-horizontal"">
                        <dt>
                            ");
            EndContext();
            BeginContext(482, 41, false);
#line 15 "D:\PROJECTS\Project1\MvcMovie\MvcMovie\MvcMovie\Views\Admin\Details.cshtml"
                       Write(Html.DisplayNameFor(model => model.Title));

#line default
#line hidden
            EndContext();
            BeginContext(523, 91, true);
            WriteLiteral("\r\n                        </dt>\r\n                        <dd>\r\n                            ");
            EndContext();
            BeginContext(615, 37, false);
#line 18 "D:\PROJECTS\Project1\MvcMovie\MvcMovie\MvcMovie\Views\Admin\Details.cshtml"
                       Write(Html.DisplayFor(model => model.Title));

#line default
#line hidden
            EndContext();
            BeginContext(652, 91, true);
            WriteLiteral("\r\n                        </dd>\r\n                        <dt>\r\n                            ");
            EndContext();
            BeginContext(744, 47, false);
#line 21 "D:\PROJECTS\Project1\MvcMovie\MvcMovie\MvcMovie\Views\Admin\Details.cshtml"
                       Write(Html.DisplayNameFor(model => model.ReleaseDate));

#line default
#line hidden
            EndContext();
            BeginContext(791, 91, true);
            WriteLiteral("\r\n                        </dt>\r\n                        <dd>\r\n                            ");
            EndContext();
            BeginContext(883, 43, false);
#line 24 "D:\PROJECTS\Project1\MvcMovie\MvcMovie\MvcMovie\Views\Admin\Details.cshtml"
                       Write(Html.DisplayFor(model => model.ReleaseDate));

#line default
#line hidden
            EndContext();
            BeginContext(926, 91, true);
            WriteLiteral("\r\n                        </dd>\r\n                        <dt>\r\n                            ");
            EndContext();
            BeginContext(1018, 41, false);
#line 27 "D:\PROJECTS\Project1\MvcMovie\MvcMovie\MvcMovie\Views\Admin\Details.cshtml"
                       Write(Html.DisplayNameFor(model => model.Genre));

#line default
#line hidden
            EndContext();
            BeginContext(1059, 91, true);
            WriteLiteral("\r\n                        </dt>\r\n                        <dd>\r\n                            ");
            EndContext();
            BeginContext(1151, 37, false);
#line 30 "D:\PROJECTS\Project1\MvcMovie\MvcMovie\MvcMovie\Views\Admin\Details.cshtml"
                       Write(Html.DisplayFor(model => model.Genre));

#line default
#line hidden
            EndContext();
            BeginContext(1188, 91, true);
            WriteLiteral("\r\n                        </dd>\r\n                        <dt>\r\n                            ");
            EndContext();
            BeginContext(1280, 41, false);
#line 33 "D:\PROJECTS\Project1\MvcMovie\MvcMovie\MvcMovie\Views\Admin\Details.cshtml"
                       Write(Html.DisplayNameFor(model => model.Price));

#line default
#line hidden
            EndContext();
            BeginContext(1321, 91, true);
            WriteLiteral("\r\n                        </dt>\r\n                        <dd>\r\n                            ");
            EndContext();
            BeginContext(1413, 37, false);
#line 36 "D:\PROJECTS\Project1\MvcMovie\MvcMovie\MvcMovie\Views\Admin\Details.cshtml"
                       Write(Html.DisplayFor(model => model.Price));

#line default
#line hidden
            EndContext();
            BeginContext(1450, 91, true);
            WriteLiteral("\r\n                        </dd>\r\n                        <dt>\r\n                            ");
            EndContext();
            BeginContext(1542, 42, false);
#line 39 "D:\PROJECTS\Project1\MvcMovie\MvcMovie\MvcMovie\Views\Admin\Details.cshtml"
                       Write(Html.DisplayNameFor(model => model.Rating));

#line default
#line hidden
            EndContext();
            BeginContext(1584, 91, true);
            WriteLiteral("\r\n                        </dt>\r\n                        <dd>\r\n                            ");
            EndContext();
            BeginContext(1676, 38, false);
#line 42 "D:\PROJECTS\Project1\MvcMovie\MvcMovie\MvcMovie\Views\Admin\Details.cshtml"
                       Write(Html.DisplayFor(model => model.Rating));

#line default
#line hidden
            EndContext();
            BeginContext(1714, 91, true);
            WriteLiteral("\r\n                        </dd>\r\n                        <dt>\r\n                            ");
            EndContext();
            BeginContext(1806, 44, false);
#line 45 "D:\PROJECTS\Project1\MvcMovie\MvcMovie\MvcMovie\Views\Admin\Details.cshtml"
                       Write(Html.DisplayNameFor(model => model.Quantity));

#line default
#line hidden
            EndContext();
            BeginContext(1850, 91, true);
            WriteLiteral("\r\n                        </dt>\r\n                        <dd>\r\n                            ");
            EndContext();
            BeginContext(1942, 40, false);
#line 48 "D:\PROJECTS\Project1\MvcMovie\MvcMovie\MvcMovie\Views\Admin\Details.cshtml"
                       Write(Html.DisplayFor(model => model.Quantity));

#line default
#line hidden
            EndContext();
            BeginContext(1982, 95, true);
            WriteLiteral("\r\n                        </dd>\r\n                    </dl>\r\n                </div>\r\n           ");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MvcMovie.Models.Movie> Html { get; private set; }
    }
}
#pragma warning restore 1591