#pragma checksum "D:\Mahwous\Mahwous\MahwousWeb\Client\Pages\Administration\Categories\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9e9f68151c09effe715732705eec8a3f6e6a8a12"
// <auto-generated/>
#pragma warning disable 1591
namespace MahwousWeb.Client.Pages.Administration.Categories
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\Mahwous\Mahwous\MahwousWeb\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Mahwous\Mahwous\MahwousWeb\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Mahwous\Mahwous\MahwousWeb\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Mahwous\Mahwous\MahwousWeb\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Mahwous\Mahwous\MahwousWeb\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Mahwous\Mahwous\MahwousWeb\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Mahwous\Mahwous\MahwousWeb\Client\_Imports.razor"
using MahwousWeb.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Mahwous\Mahwous\MahwousWeb\Client\_Imports.razor"
using MahwousWeb.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Mahwous\Mahwous\MahwousWeb\Client\_Imports.razor"
using MahwousWeb.Client.Shared.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Mahwous\Mahwous\MahwousWeb\Client\_Imports.razor"
using MahwousWeb.Client.Shared.Admin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\Mahwous\Mahwous\MahwousWeb\Client\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\Mahwous\Mahwous\MahwousWeb\Client\_Imports.razor"
using MahwousWeb.Shared.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\Mahwous\Mahwous\MahwousWeb\Client\_Imports.razor"
using MahwousWeb.Shared.Repositories;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\Mahwous\Mahwous\MahwousWeb\Client\_Imports.razor"
using MahwousWeb.Client.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "D:\Mahwous\Mahwous\MahwousWeb\Client\_Imports.razor"
using MahwousWeb.Shared.Pagination;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "D:\Mahwous\Mahwous\MahwousWeb\Client\_Imports.razor"
using MahwousWeb.Shared.Filters;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "D:\Mahwous\Mahwous\MahwousWeb\Client\_Imports.razor"
using MahwousWeb.Shared.Repositories.Interfaces;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "D:\Mahwous\Mahwous\MahwousWeb\Client\_Imports.razor"
using Radzen;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "D:\Mahwous\Mahwous\MahwousWeb\Client\_Imports.razor"
using Radzen.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Mahwous\Mahwous\MahwousWeb\Client\Pages\Administration\Categories\Index.razor"
           [Authorize]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(AdminLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/administration/categories")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, @"<section class=""content-header"">
    <div class=""container-fluid"">
        <div class=""row mb-2"">
            <div class=""col-sm-6"">
                <h1>حالات فيديو</h1>
            </div>
            <div class=""col-sm-6"">
                <ol class=""breadcrumb float-sm-right"">
                    <li class=""breadcrumb-item active"">حالات فيديو</li>
                    <li class=""breadcrumb-item""><a href=""administration"">الإدارة</a></li>
                    <li class=""breadcrumb-item""><a href>الصفحة الرئيسية</a></li>
                </ol>
            </div>
        </div>
    </div>
</section>


");
            __builder.OpenElement(1, "section");
            __builder.AddAttribute(2, "class", "content");
            __builder.AddMarkupContent(3, "\r\n    ");
            __builder.OpenElement(4, "div");
            __builder.AddAttribute(5, "class", "container-fluid");
            __builder.AddMarkupContent(6, "\r\n        ");
            __builder.OpenElement(7, "div");
            __builder.AddAttribute(8, "class", "row");
            __builder.AddMarkupContent(9, "\r\n            ");
            __builder.OpenElement(10, "div");
            __builder.AddAttribute(11, "class", "col-lg-9");
            __builder.AddMarkupContent(12, "\r\n\r\n\r\n                ");
            __builder.OpenElement(13, "div");
            __builder.AddAttribute(14, "class", "card");
            __builder.AddMarkupContent(15, "\r\n                    ");
            __builder.OpenElement(16, "div");
            __builder.AddAttribute(17, "class", "card-header");
            __builder.AddMarkupContent(18, "\r\n                        ");
            __builder.OpenComponent<MahwousWeb.Client.Shared.Components.Pagination>(19);
            __builder.AddAttribute(20, "CurrentPage", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 36 "D:\Mahwous\Mahwous\MahwousWeb\Client\Pages\Administration\Categories\Index.razor"
                                                  categoryFilter.Page

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(21, "TotalAmountPages", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 36 "D:\Mahwous\Mahwous\MahwousWeb\Client\Pages\Administration\Categories\Index.razor"
                                                                                         totalAmountPages

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(22, "SelectedPage", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Int32>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Int32>(this, 
#nullable restore
#line 37 "D:\Mahwous\Mahwous\MahwousWeb\Client\Pages\Administration\Categories\Index.razor"
                                                  SelectedPage

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.AddMarkupContent(23, "\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(24, "\r\n                    \r\n                    ");
            __builder.OpenElement(25, "div");
            __builder.AddAttribute(26, "class", "card-body");
            __builder.AddMarkupContent(27, "\r\n\r\n                        ");
            __builder.OpenElement(28, "div");
            __builder.AddMarkupContent(29, "\r\n\r\n");
#nullable restore
#line 44 "D:\Mahwous\Mahwous\MahwousWeb\Client\Pages\Administration\Categories\Index.razor"
                             if (categories == null)
                            {

#line default
#line hidden
#nullable disable
            __builder.AddContent(30, "                                ");
            __builder.AddMarkupContent(31, "<p>جاري تحميل التصنيفات...</p>\r\n");
#nullable restore
#line 47 "D:\Mahwous\Mahwous\MahwousWeb\Client\Pages\Administration\Categories\Index.razor"
                            }
                            else if (categories.Count == 0)
                            {

#line default
#line hidden
#nullable disable
            __builder.AddContent(32, "                                ");
            __builder.AddMarkupContent(33, "<p> لا يوجد تصنيفات! </p>\r\n");
#nullable restore
#line 51 "D:\Mahwous\Mahwous\MahwousWeb\Client\Pages\Administration\Categories\Index.razor"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            __builder.AddContent(34, "                                ");
            __builder.OpenElement(35, "div");
            __builder.AddAttribute(36, "class", "content");
            __builder.AddMarkupContent(37, "\r\n                                    ");
            __builder.OpenElement(38, "div");
            __builder.AddAttribute(39, "class", "container-fluid");
            __builder.AddMarkupContent(40, "\r\n                                        ");
            __builder.OpenElement(41, "div");
            __builder.AddAttribute(42, "class", "row");
            __builder.AddMarkupContent(43, "\r\n");
#nullable restore
#line 57 "D:\Mahwous\Mahwous\MahwousWeb\Client\Pages\Administration\Categories\Index.razor"
                                             foreach (Category category in categories)
                                            {

#line default
#line hidden
#nullable disable
            __builder.AddContent(44, "                                                ");
            __builder.OpenElement(45, "div");
            __builder.AddAttribute(46, "class", "col-md-4");
            __builder.AddMarkupContent(47, "\r\n                                                    ");
            __builder.OpenElement(48, "div");
            __builder.AddAttribute(49, "class", "card card-chart");
            __builder.AddMarkupContent(50, "\r\n                                                        ");
            __builder.OpenElement(51, "div");
            __builder.AddAttribute(52, "class", "card-header p-0");
            __builder.AddMarkupContent(53, "\r\n                                                            ");
            __builder.OpenElement(54, "img");
            __builder.AddAttribute(55, "src", 
#nullable restore
#line 62 "D:\Mahwous\Mahwous\MahwousWeb\Client\Pages\Administration\Categories\Index.razor"
                                                                       category.CoverPath

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(56, "style", "height:auto; width:100%; object-fit:cover");
            __builder.CloseElement();
            __builder.AddMarkupContent(57, "\r\n                                                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(58, "\r\n                                                        ");
            __builder.OpenElement(59, "div");
            __builder.AddAttribute(60, "class", "card-body");
            __builder.AddMarkupContent(61, "\r\n                                                            ");
            __builder.OpenElement(62, "h4");
            __builder.AddAttribute(63, "class", "card-title");
            __builder.AddContent(64, 
#nullable restore
#line 65 "D:\Mahwous\Mahwous\MahwousWeb\Client\Pages\Administration\Categories\Index.razor"
                                                                                    category.Name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(65, "\r\n                                                            ");
            __builder.AddMarkupContent(66, "<i class=\"material-icons \">categories</i>\r\n                                                            ");
            __builder.OpenElement(67, "p");
            __builder.AddAttribute(68, "class", "card-category");
            __builder.AddMarkupContent(69, "\r\n");
#nullable restore
#line 68 "D:\Mahwous\Mahwous\MahwousWeb\Client\Pages\Administration\Categories\Index.razor"
                                                                 if (category.ForImages)
                                                                {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(70, "<span class=\"text-secondary\">صور | </span>");
#nullable restore
#line 69 "D:\Mahwous\Mahwous\MahwousWeb\Client\Pages\Administration\Categories\Index.razor"
                                                                                                           }

#line default
#line hidden
#nullable disable
#nullable restore
#line 70 "D:\Mahwous\Mahwous\MahwousWeb\Client\Pages\Administration\Categories\Index.razor"
                                                                 if (category.ForQuotes)
                                                                {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(71, "<span class=\"text-secondary\">كتابية | </span>");
#nullable restore
#line 71 "D:\Mahwous\Mahwous\MahwousWeb\Client\Pages\Administration\Categories\Index.razor"
                                                                                                              }

#line default
#line hidden
#nullable disable
#nullable restore
#line 72 "D:\Mahwous\Mahwous\MahwousWeb\Client\Pages\Administration\Categories\Index.razor"
                                                                 if (category.ForVideos)
                                                                {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(72, "<span class=\"text-secondary\">فيديو </span>");
#nullable restore
#line 73 "D:\Mahwous\Mahwous\MahwousWeb\Client\Pages\Administration\Categories\Index.razor"
                                                                                                           }

#line default
#line hidden
#nullable disable
            __builder.AddContent(73, "                                                            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(74, "\r\n                                                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(75, "\r\n                                                        ");
            __builder.OpenElement(76, "div");
            __builder.AddAttribute(77, "class", "card-footer");
            __builder.AddMarkupContent(78, "\r\n                                                            ");
            __builder.OpenElement(79, "div");
            __builder.AddAttribute(80, "class", "stats");
            __builder.AddMarkupContent(81, "\r\n                                                                ");
            __builder.OpenElement(82, "button");
            __builder.AddAttribute(83, "class", "btn btn-danger");
            __builder.AddAttribute(84, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 78 "D:\Mahwous\Mahwous\MahwousWeb\Client\Pages\Administration\Categories\Index.razor"
                                                                                                           () => DeleteCategory(category.Id)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(85, "حذف");
            __builder.CloseElement();
            __builder.AddMarkupContent(86, "\r\n                                                                ");
            __builder.OpenElement(87, "a");
            __builder.AddAttribute(88, "class", "btn btn-info");
            __builder.AddAttribute(89, "href", "administration/categories/edit/" + (
#nullable restore
#line 79 "D:\Mahwous\Mahwous\MahwousWeb\Client\Pages\Administration\Categories\Index.razor"
                                                                                                                              category.Id

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(90, "تعديل");
            __builder.CloseElement();
            __builder.AddMarkupContent(91, "\r\n                                                            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(92, "\r\n                                                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(93, "\r\n                                                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(94, "\r\n                                                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(95, "\r\n");
#nullable restore
#line 84 "D:\Mahwous\Mahwous\MahwousWeb\Client\Pages\Administration\Categories\Index.razor"
                                            }

#line default
#line hidden
#nullable disable
            __builder.AddContent(96, "                                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(97, "\r\n                                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(98, "\r\n                                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(99, "\r\n");
#nullable restore
#line 88 "D:\Mahwous\Mahwous\MahwousWeb\Client\Pages\Administration\Categories\Index.razor"

                            }

#line default
#line hidden
#nullable disable
            __builder.AddContent(100, "                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(101, "\r\n\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(102, "\r\n                    \r\n                    ");
            __builder.OpenElement(103, "div");
            __builder.AddAttribute(104, "class", "card-footer");
            __builder.AddMarkupContent(105, "\r\n                        ");
            __builder.OpenComponent<MahwousWeb.Client.Shared.Components.Pagination>(106);
            __builder.AddAttribute(107, "CurrentPage", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 95 "D:\Mahwous\Mahwous\MahwousWeb\Client\Pages\Administration\Categories\Index.razor"
                                                  categoryFilter.Page

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(108, "TotalAmountPages", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 95 "D:\Mahwous\Mahwous\MahwousWeb\Client\Pages\Administration\Categories\Index.razor"
                                                                                         totalAmountPages

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(109, "SelectedPage", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Int32>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Int32>(this, 
#nullable restore
#line 96 "D:\Mahwous\Mahwous\MahwousWeb\Client\Pages\Administration\Categories\Index.razor"
                                                  SelectedPage

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.AddMarkupContent(110, "\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(111, "\r\n                    \r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(112, "\r\n                \r\n\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(113, "\r\n            ");
            __builder.OpenElement(114, "div");
            __builder.AddAttribute(115, "class", "col-lg-3");
            __builder.AddMarkupContent(116, "\r\n                ");
            __builder.AddMarkupContent(117, "<a href=\"administration/categories/create\" class=\"btn btn-primary btn-block mb-3\">اضافة تصنيف جديد</a>\r\n\r\n                ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(118);
            __builder.AddAttribute(119, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 106 "D:\Mahwous\Mahwous\MahwousWeb\Client\Pages\Administration\Categories\Index.razor"
                                 categoryFilter

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(120, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(121, "\r\n\r\n                    ");
                __builder2.OpenElement(122, "div");
                __builder2.AddAttribute(123, "class", "card collapsed-card");
                __builder2.AddMarkupContent(124, "\r\n                        ");
                __builder2.AddMarkupContent(125, @"<div class=""card-header"">
                            <h3 class=""card-title"">فلترة</h3>

                            <div class=""card-tools"">
                                <button type=""button"" class=""btn btn-tool"" data-card-widget=""collapse"">
                                    <i class=""fas fa-plus""></i>
                                </button>
                            </div>
                        </div>

                        ");
                __builder2.OpenElement(126, "div");
                __builder2.AddAttribute(127, "class", "card-body");
                __builder2.AddMarkupContent(128, "\r\n\r\n\r\n                            ");
                __builder2.OpenElement(129, "div");
                __builder2.AddAttribute(130, "class", "form-group");
                __builder2.AddMarkupContent(131, "\r\n                                ");
                __builder2.AddMarkupContent(132, "<label for=\"Content\">Name</label>\r\n                                ");
                __builder2.OpenElement(133, "input");
                __builder2.AddAttribute(134, "type", "text");
                __builder2.AddAttribute(135, "class", "form-control");
                __builder2.AddAttribute(136, "id", "Name");
                __builder2.AddAttribute(137, "placeholder", "category Name");
                __builder2.AddAttribute(138, "onkeypress", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.KeyboardEventArgs>(this, 
#nullable restore
#line 126 "D:\Mahwous\Mahwous\MahwousWeb\Client\Pages\Administration\Categories\Index.razor"
                                                      (KeyboardEventArgs e) => NameKeyPress(e)

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(139, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 125 "D:\Mahwous\Mahwous\MahwousWeb\Client\Pages\Administration\Categories\Index.razor"
                                                    categoryFilter.Name

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(140, "oninput", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => categoryFilter.Name = __value, categoryFilter.Name));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(141, "\r\n                            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(142, "\r\n\r\n\r\n                            ");
                __builder2.OpenElement(143, "div");
                __builder2.AddAttribute(144, "class", "form-check");
                __builder2.AddMarkupContent(145, "\r\n                                ");
                __builder2.OpenElement(146, "input");
                __builder2.AddAttribute(147, "type", "checkbox");
                __builder2.AddAttribute(148, "class", "form-check-input");
                __builder2.AddAttribute(149, "id", "ForImages");
                __builder2.AddAttribute(150, "checked", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 131 "D:\Mahwous\Mahwous\MahwousWeb\Client\Pages\Administration\Categories\Index.razor"
                                                                                                      categoryFilter.ForImages

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(151, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => categoryFilter.ForImages = __value, categoryFilter.ForImages));
                __builder2.SetUpdatesAttributeName("checked");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(152, "\r\n                                ");
                __builder2.AddMarkupContent(153, "<label class=\"form-check-label\" for=\"ForImages\">For Images</label>\r\n                            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(154, "\r\n\r\n                            ");
                __builder2.OpenElement(155, "div");
                __builder2.AddAttribute(156, "class", "form-check");
                __builder2.AddMarkupContent(157, "\r\n                                ");
                __builder2.OpenElement(158, "input");
                __builder2.AddAttribute(159, "type", "checkbox");
                __builder2.AddAttribute(160, "class", "form-check-input");
                __builder2.AddAttribute(161, "id", "ForQuotes");
                __builder2.AddAttribute(162, "checked", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 136 "D:\Mahwous\Mahwous\MahwousWeb\Client\Pages\Administration\Categories\Index.razor"
                                                                                                      categoryFilter.ForQuotes

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(163, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => categoryFilter.ForQuotes = __value, categoryFilter.ForQuotes));
                __builder2.SetUpdatesAttributeName("checked");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(164, "\r\n                                ");
                __builder2.AddMarkupContent(165, "<label class=\"form-check-label\" for=\"ForQuotes\">For Quotes</label>\r\n                            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(166, "\r\n\r\n                            ");
                __builder2.OpenElement(167, "div");
                __builder2.AddAttribute(168, "class", "form-check");
                __builder2.AddMarkupContent(169, "\r\n                                ");
                __builder2.OpenElement(170, "input");
                __builder2.AddAttribute(171, "type", "checkbox");
                __builder2.AddAttribute(172, "class", "form-check-input");
                __builder2.AddAttribute(173, "id", "ForVideos");
                __builder2.AddAttribute(174, "checked", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 141 "D:\Mahwous\Mahwous\MahwousWeb\Client\Pages\Administration\Categories\Index.razor"
                                                                                                      categoryFilter.ForVideos

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(175, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => categoryFilter.ForVideos = __value, categoryFilter.ForVideos));
                __builder2.SetUpdatesAttributeName("checked");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(176, "\r\n                                ");
                __builder2.AddMarkupContent(177, "<label class=\"form-check-label\" for=\"ForVideos\">For Videos</label>\r\n                            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(178, "\r\n\r\n                        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(179, "\r\n\r\n                        ");
                __builder2.OpenElement(180, "div");
                __builder2.AddAttribute(181, "class", "card-footer");
                __builder2.AddMarkupContent(182, "\r\n                            ");
                __builder2.OpenElement(183, "button");
                __builder2.AddAttribute(184, "type", "button");
                __builder2.AddAttribute(185, "class", "btn btn-primary");
                __builder2.AddAttribute(186, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 148 "D:\Mahwous\Mahwous\MahwousWeb\Client\Pages\Administration\Categories\Index.razor"
                                                                                    SearchForCategories

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddMarkupContent(187, "فلترة");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(188, "\r\n                            ");
                __builder2.OpenElement(189, "button");
                __builder2.AddAttribute(190, "type", "button");
                __builder2.AddAttribute(191, "class", "btn btn-link text-danger");
                __builder2.AddAttribute(192, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 149 "D:\Mahwous\Mahwous\MahwousWeb\Client\Pages\Administration\Categories\Index.razor"
                                                                                             Clear

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddMarkupContent(193, "حذف الفلتر <i class=\"fas fa-backspace\"></i>");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(194, "\r\n                        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(195, "\r\n                    ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(196, "\r\n\r\n                ");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(197, "\r\n\r\n\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(198, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(199, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(200, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 165 "D:\Mahwous\Mahwous\MahwousWeb\Client\Pages\Administration\Categories\Index.razor"
       
    private CategoryFilter categoryFilter = new CategoryFilter();



    List<Category> categories { get; set; }

    private int totalAmountPages;


    protected async override Task OnInitializedAsync()
    {
        await authorizer.SetAuthorizationAsync();
        await LoadCategories();
    }

    async Task LoadCategories()
    {
        try
        {
            var paginatedResponse = await categoryRepository.GetCategoriesFiltered(categoryFilter);
            categories = paginatedResponse.Response;
            totalAmountPages = paginatedResponse.TotalAmountPages;

        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    async Task DeleteCategory(int categoryId)
    {
        var category = categories.First(x => x.Id == categoryId);
        if (await js.Confirm("تأكيد", $"هل أنت متأكد أنك تريد أن تحذف {category.Name} ؟", SweetAlertMessageType.error))
        {
            await categoryRepository.Delete(categoryId);
            await LoadCategories();
        }
    }

    private async Task SelectedPage(int page)
    {
        categoryFilter.Page = page;
        await LoadCategories();
    }




    private async Task SearchForCategories()
    {

        await LoadCategories();
    }

    private async Task Clear()
    {
        categoryFilter.Name = "";
        categoryFilter.ForImages = false;
        categoryFilter.ForQuotes = false;
        categoryFilter.ForVideos = false;
        await LoadCategories();
    }

    private async Task NameKeyPress(KeyboardEventArgs e)
    {
        if (e.Key == "Enter")
        {
            await SearchForCategories();
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpAuthorizer authorizer { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ICategoryRepository categoryRepository { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager navigation { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime js { get; set; }
    }
}
#pragma warning restore 1591
