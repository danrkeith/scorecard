#pragma checksum "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\GameIndex.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3179421c600f11adda4c0e3c1f8b35c922ee0f2e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_GameIndex), @"mvc.1.0.view", @"/Views/Shared/GameIndex.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3179421c600f11adda4c0e3c1f8b35c922ee0f2e", @"/Views/Shared/GameIndex.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6414c896dd4c9cabfeec214cec4f8ed9aba4e726", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_GameIndex : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TeamsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("teamCount"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "number", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "2", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("display: none"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("playerCount"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "text", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("autocomplete", new global::Microsoft.AspNetCore.Html.HtmlString("off"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\GameIndex.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";
    ViewData["Title"] = "Create Teams";

    // No body for this layout
    IgnoreBody();

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n        // Change amount of teams\r\n        $(\"#teams\").change(function () {\r\n            $(\"#teamCount\").val($(this).val());\r\n\r\n            for (let i = 0; i < ");
#nullable restore
#line 17 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\GameIndex.cshtml"
                           Write(Model.TeamCount);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"; i++) {
                if (i > $(this).val() - 1) {
                    $(`.team${i}`).hide();
                } else {
                    $(`.team${i}`).show();
                }
            }

            CheckValid();
        });

        // Change amount of players
        $(""#players"").change(function () {
            $(""#playerCount"").val($(this).val());

            for (let i = 0; i < ");
#nullable restore
#line 32 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\GameIndex.cshtml"
                           Write(Model.PlayerCount);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"; i++) {
                if (i > $(this).val() - 1) {
                    $(`#player${i}`).hide();
                } else {
                    $(`#player${i}`).show();
                }
            }

            CheckValid();
        });

        // Hide players aren't shown by default
        for (let i = ");
#nullable restore
#line 44 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\GameIndex.cshtml"
                 Write(Model.TeamCount > Model.PlayerCount ? Model.TeamCount : Model.PlayerCount);

#line default
#line hidden
#nullable disable
                WriteLiteral(" - 1; i > 1; i--) {\r\n            $(`#player${i}, .team${i}`).hide();\r\n        }\r\n\r\n        // Select 2 players / 2 teams by default\r\n        $(\"#teams, #players\").val(2);\r\n    </script>\r\n");
            }
            );
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3179421c600f11adda4c0e3c1f8b35c922ee0f2e9202", async() => {
                WriteLiteral("\r\n    <!--Hidden values for model-->\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3179421c600f11adda4c0e3c1f8b35c922ee0f2e9502", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 55 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\GameIndex.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.TeamCount);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3179421c600f11adda4c0e3c1f8b35c922ee0f2e11605", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 56 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\GameIndex.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.PlayerCount);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n    <!--Adaptive grid of names-->\r\n    <!--Team 3 & Player 3 are disabled by default-->\r\n    <div class=\"container\">\r\n        <div id=\"teamNames\" class=\"row mb-1\">\r\n");
#nullable restore
#line 62 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\GameIndex.cshtml"
             for (int t = 0; t < Model.TeamCount; t++)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <div");
                BeginWriteAttribute("class", " class=\"", 1997, "\"", 2017, 3);
                WriteAttributeValue("", 2005, "col", 2005, 3, true);
                WriteAttributeValue(" ", 2008, "team", 2009, 5, true);
#nullable restore
#line 64 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\GameIndex.cshtml"
WriteAttributeValue("", 2013, t, 2013, 4, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Team 1</div>\r\n");
#nullable restore
#line 65 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\GameIndex.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </div>\r\n");
#nullable restore
#line 67 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\GameIndex.cshtml"
         for (int p = 0; p < Model.PlayerCount; p++)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <div");
                BeginWriteAttribute("id", " id=\"", 2145, "\"", 2160, 2);
                WriteAttributeValue("", 2150, "player", 2150, 6, true);
#nullable restore
#line 69 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\GameIndex.cshtml"
WriteAttributeValue("", 2156, p, 2156, 4, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"row mb-1\">\r\n");
#nullable restore
#line 70 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\GameIndex.cshtml"
                 for (int t = 0; t < Model.TeamCount; t++)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <div");
                BeginWriteAttribute("class", " class=\"", 2284, "\"", 2304, 3);
                WriteAttributeValue("", 2292, "col", 2292, 3, true);
                WriteAttributeValue(" ", 2295, "team", 2296, 5, true);
#nullable restore
#line 72 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\GameIndex.cshtml"
WriteAttributeValue("", 2300, t, 2300, 4, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3179421c600f11adda4c0e3c1f8b35c922ee0f2e16592", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 73 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\GameIndex.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Names[t][p]);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "placeholder", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 2407, "Player", 2407, 6, true);
#nullable restore
#line 73 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\GameIndex.cshtml"
AddHtmlAttributeValue(" ", 2413, p+1, 2414, 6, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    </div>\r\n");
#nullable restore
#line 75 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\GameIndex.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            </div>\r\n");
#nullable restore
#line 77 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\GameIndex.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"    </div>

    <br />

    <!--Options for size of teams & players/team-->
    <div class=""container"">
        <div class=""row justify-content-between mb-1"">
            <div class=""col-6"">
                <div class=""input-group mb-3"">
                    <div class=""input-group-prepend"">
                        <span class=""input-group-text"">Teams</span>
                    </div>
                    <select id=""teams"" class=""custom-select"">
");
#nullable restore
#line 91 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\GameIndex.cshtml"
                         for (int t = 1; t <= Model.TeamCount; t++)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3179421c600f11adda4c0e3c1f8b35c922ee0f2e20266", async() => {
#nullable restore
#line 93 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\GameIndex.cshtml"
                                             Write(t);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 93 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\GameIndex.cshtml"
                                WriteLiteral(t);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 94 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\GameIndex.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                    </select>
                    <div class=""input-group-prepend"">
                        <span class=""input-group-text"">Players Per Team</span>
                    </div>
                    <select id=""players"" class=""custom-select"">
");
#nullable restore
#line 100 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\GameIndex.cshtml"
                         for (int p = 1; p <= Model.PlayerCount; p++)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3179421c600f11adda4c0e3c1f8b35c922ee0f2e22988", async() => {
#nullable restore
#line 102 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\GameIndex.cshtml"
                                             Write(p);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 102 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\GameIndex.cshtml"
                                WriteLiteral(p);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 103 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\GameIndex.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                    </select>
                </div>
            </div>
            <div class=""col-2"">
                <input type=""submit"" id=""submit"" class=""form-control btn btn-primary"" value=""Create Game"" disabled />
            </div>
        </div>
    </div>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 53 "C:\Users\danrk\source\repos\CSharpDotnet\ScoreCard\ScoreCardv2\Views\Shared\GameIndex.cshtml"
          WriteLiteral(ViewData["Controller"]);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-controller", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TeamsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
