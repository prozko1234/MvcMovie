#pragma checksum "D:\PROJECTS\VisualStudio\MvcMovie\MvcMovie\Views\Movies\Rent.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a9de5be9c00908d3d48d782d8b2682423d762bc9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Movies_Rent), @"mvc.1.0.view", @"/Views/Movies/Rent.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Movies/Rent.cshtml", typeof(AspNetCore.Views_Movies_Rent))]
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
#line 1 "D:\PROJECTS\VisualStudio\MvcMovie\MvcMovie\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "D:\PROJECTS\VisualStudio\MvcMovie\MvcMovie\Views\_ViewImports.cshtml"
using MvcMovie;

#line default
#line hidden
#line 3 "D:\PROJECTS\VisualStudio\MvcMovie\MvcMovie\Views\_ViewImports.cshtml"
using MvcMovie.Models;

#line default
#line hidden
#line 4 "D:\PROJECTS\VisualStudio\MvcMovie\MvcMovie\Views\_ViewImports.cshtml"
using MvcMovie.Models.AccountViewModels;

#line default
#line hidden
#line 5 "D:\PROJECTS\VisualStudio\MvcMovie\MvcMovie\Views\_ViewImports.cshtml"
using MvcMovie.Models.ManageViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9de5be9c00908d3d48d782d8b2682423d762bc9", @"/Views/Movies/Rent.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e230dfb742f77776b61ac8ddaba31f15e40b5160", @"/Views/_ViewImports.cshtml")]
    public class Views_Movies_Rent : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MvcMovie.Models.Movie>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(30, 32, true);
            WriteLiteral("\r\n<h1> Rent Details </h1>\r\n\r\n<p>");
            EndContext();
            BeginContext(63, 41, false);
#line 5 "D:\PROJECTS\VisualStudio\MvcMovie\MvcMovie\Views\Movies\Rent.cshtml"
Write(Html.DisplayNameFor(model => model.Title));

#line default
#line hidden
            EndContext();
            BeginContext(104, 4, true);
            WriteLiteral("</p>");
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