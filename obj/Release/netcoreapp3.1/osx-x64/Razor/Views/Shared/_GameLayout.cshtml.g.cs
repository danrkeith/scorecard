#pragma checksum "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\_GameLayout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f1732d4c223044920534b2459abbc5ce72da954c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__GameLayout), @"mvc.1.0.view", @"/Views/Shared/_GameLayout.cshtml")]
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
#line 1 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\_ViewImports.cshtml"
using ScoreCardv2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\_ViewImports.cshtml"
using ScoreCardv2.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1732d4c223044920534b2459abbc5ce72da954c", @"/Views/Shared/_GameLayout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6414c896dd4c9cabfeec214cec4f8ed9aba4e726", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__GameLayout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GameViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteRound", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\_GameLayout.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
#nullable restore
#line 8 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\_GameLayout.cshtml"
Write(RenderSection("Scripts", required: false));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral("\r\n");
#nullable restore
#line 11 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\_GameLayout.cshtml"
 if (Model.Completed)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"text-success text-center\">&#10003 Completed</div>\r\n");
#nullable restore
#line 14 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\_GameLayout.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!--Table for displaying all hands played-->\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f1732d4c223044920534b2459abbc5ce72da954c5104", async() => {
                WriteLiteral("\r\n    <table class=\"table\">\r\n        <thead>\r\n            <tr>\r\n                <!--Headers-->\r\n                <th scope=\"col\" class=\"col-2\">#</th>\r\n");
#nullable restore
#line 23 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\_GameLayout.cshtml"
                 for (int t = 0; t < Model.Teams.Length; t++)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <th scope=\"col\" class=\"col-2\">\r\n                        ");
#nullable restore
#line 26 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\_GameLayout.cshtml"
                   Write(Model.Teams[t].Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
#nullable restore
#line 27 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\_GameLayout.cshtml"
                         if (Model.Completed && (Model.LeadingTeam ?? -1) == t)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <span class=\"text-success\">(Winner)</span>\r\n");
#nullable restore
#line 30 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\_GameLayout.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    </th>\r\n");
#nullable restore
#line 32 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\_GameLayout.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                <!--Set column width for (x) button-->\r\n                <th class=\"col-1\"></th>\r\n            </tr>\r\n        </thead>\r\n\r\n        <tbody>\r\n            <!--Display hands-->\r\n");
#nullable restore
#line 41 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\_GameLayout.cshtml"
             if (Model.Teams[0].Rounds != null)
            {
                for (int h = 0; h < Model.Teams[0].Rounds.Length; h++)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <tr>\r\n                        <!--Hands-->\r\n                        <th>");
#nullable restore
#line 47 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\_GameLayout.cshtml"
                        Write(h + 1);

#line default
#line hidden
#nullable disable
                WriteLiteral("</th>\r\n");
#nullable restore
#line 48 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\_GameLayout.cshtml"
                         foreach (GameViewModel.Team team in Model.Teams)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <td>");
#nullable restore
#line 50 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\_GameLayout.cshtml"
                           Write(team.Rounds[h]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n");
#nullable restore
#line 51 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\_GameLayout.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        <!--(x) button-->\r\n                        <td>\r\n                            <button type=\"submit\" name=\"round\"");
                BeginWriteAttribute("value", " value=\"", 1736, "\"", 1746, 1);
#nullable restore
#line 55 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\_GameLayout.cshtml"
WriteAttributeValue("", 1744, h, 1744, 2, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"btn btn-circle btn-sm btn-outline-danger\">x</button>\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 58 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\_GameLayout.cshtml"
                }
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            <!--Display score total for each team-->\r\n            <tr>\r\n                <th>Total</th>\r\n");
#nullable restore
#line 64 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\_GameLayout.cshtml"
                 foreach (GameViewModel.Team team in Model.Teams)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <td>");
#nullable restore
#line 66 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\_GameLayout.cshtml"
                   Write(team.Score);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n");
#nullable restore
#line 67 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\_GameLayout.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("                <td></td>\r\n            </tr>\r\n        </tbody>\r\n    </table>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 17 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\_GameLayout.cshtml"
          WriteLiteral(ViewData["Controller"]);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-controller", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 74 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\_GameLayout.cshtml"
Write(RenderBody());

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GameViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
