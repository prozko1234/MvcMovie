#pragma checksum "C:\Bogdan\VisualStudio\MvcMovie\MvcMovie\Views\Rent\MyRent.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c159680bf20808e419c67b1f005793af92515d4f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Rent_MyRent), @"mvc.1.0.view", @"/Views/Rent/MyRent.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Rent/MyRent.cshtml", typeof(AspNetCore.Views_Rent_MyRent))]
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
#line 1 "C:\Bogdan\VisualStudio\MvcMovie\MvcMovie\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "C:\Bogdan\VisualStudio\MvcMovie\MvcMovie\Views\_ViewImports.cshtml"
using MvcMovie;

#line default
#line hidden
#line 3 "C:\Bogdan\VisualStudio\MvcMovie\MvcMovie\Views\_ViewImports.cshtml"
using MvcMovie.Models;

#line default
#line hidden
#line 4 "C:\Bogdan\VisualStudio\MvcMovie\MvcMovie\Views\_ViewImports.cshtml"
using MvcMovie.Models.AccountViewModels;

#line default
#line hidden
#line 5 "C:\Bogdan\VisualStudio\MvcMovie\MvcMovie\Views\_ViewImports.cshtml"
using MvcMovie.Models.ManageViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c159680bf20808e419c67b1f005793af92515d4f", @"/Views/Rent/MyRent.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e230dfb742f77776b61ac8ddaba31f15e40b5160", @"/Views/_ViewImports.cshtml")]
    public class Views_Rent_MyRent : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MvcMovie.Models.RentViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(38, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Bogdan\VisualStudio\MvcMovie\MvcMovie\Views\Rent\MyRent.cshtml"
  
    ViewData["Title"] = "My Rents";

#line default
#line hidden
            BeginContext(84, 312, true);
            WriteLiteral(@"
<h2>My Rent</h2>

<table class=""table"">
    <thead>
        <tr>
            <th>
                Movie Title
            </th>
            <th>
                Rent Date
            </th>
            <th>
                Return Date
            </th>
        </tr>
    </thead>
    <tbody>

");
            EndContext();
#line 25 "C:\Bogdan\VisualStudio\MvcMovie\MvcMovie\Views\Rent\MyRent.cshtml"
         foreach (var item in Model.OrdersDetails)
        {

#line default
#line hidden
            BeginContext(459, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(508, 16, false);
#line 29 "C:\Bogdan\VisualStudio\MvcMovie\MvcMovie\Views\Rent\MyRent.cshtml"
           Write(item.Movie.Title);

#line default
#line hidden
            EndContext();
            BeginContext(524, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(580, 36, false);
#line 32 "C:\Bogdan\VisualStudio\MvcMovie\MvcMovie\Views\Rent\MyRent.cshtml"
           Write(item.RentDate.ToString("dd-MM-yyyy"));

#line default
#line hidden
            EndContext();
            BeginContext(616, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(672, 36, false);
#line 35 "C:\Bogdan\VisualStudio\MvcMovie\MvcMovie\Views\Rent\MyRent.cshtml"
           Write(item.RentDate.ToString("dd-MM-yyyy"));

#line default
#line hidden
            EndContext();
            BeginContext(708, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 38 "C:\Bogdan\VisualStudio\MvcMovie\MvcMovie\Views\Rent\MyRent.cshtml"
                }

#line default
#line hidden
            BeginContext(763, 48, true);
            WriteLiteral("            \r\n        </tbody>\r\n    </table>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MvcMovie.Models.RentViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
