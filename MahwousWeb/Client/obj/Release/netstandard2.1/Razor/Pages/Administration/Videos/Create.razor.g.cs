#pragma checksum "D:\Mahwous\MahwousWeb\Client\Pages\Administration\Videos\Create.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "28537e57e55ef957c409565ec2e50f3f6db117a0"
// <auto-generated/>
#pragma warning disable 1591
namespace MahwousWeb.Client.Pages.Administration.Videos
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\Mahwous\MahwousWeb\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Mahwous\MahwousWeb\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Mahwous\MahwousWeb\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Mahwous\MahwousWeb\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Mahwous\MahwousWeb\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Mahwous\MahwousWeb\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Mahwous\MahwousWeb\Client\_Imports.razor"
using MahwousWeb.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Mahwous\MahwousWeb\Client\_Imports.razor"
using MahwousWeb.Client.Pages.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Mahwous\MahwousWeb\Client\_Imports.razor"
using MahwousWeb.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Mahwous\MahwousWeb\Client\_Imports.razor"
using MahwousWeb.Client.Shared.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\Mahwous\MahwousWeb\Client\_Imports.razor"
using MahwousWeb.Client.Shared.Admin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\Mahwous\MahwousWeb\Client\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\Mahwous\MahwousWeb\Client\_Imports.razor"
using MahwousWeb.Shared.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\Mahwous\MahwousWeb\Client\_Imports.razor"
using MahwousWeb.Shared.Repositories;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "D:\Mahwous\MahwousWeb\Client\_Imports.razor"
using MahwousWeb.Client.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "D:\Mahwous\MahwousWeb\Client\_Imports.razor"
using MahwousWeb.Shared.Pagination;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "D:\Mahwous\MahwousWeb\Client\_Imports.razor"
using MahwousWeb.Shared.Filters;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "D:\Mahwous\MahwousWeb\Client\_Imports.razor"
using MahwousWeb.Shared.Repositories.Interfaces;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "D:\Mahwous\MahwousWeb\Client\_Imports.razor"
using Radzen;

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "D:\Mahwous\MahwousWeb\Client\_Imports.razor"
using Radzen.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Mahwous\MahwousWeb\Client\Pages\Administration\Videos\Create.razor"
           [Authorize]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(AdminLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/administration/videos/create")]
    public partial class Create : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, @"<div class=""content-header"">
        <div class=""container-fluid"">
            <div class=""row mb-2"">
                <div class=""col-sm-6"">
                    <h1 class=""m-0 text-dark"">فيديو جديد</h1>
                </div>
                <div class=""col-sm-6"">
                    <ol class=""breadcrumb float-sm-right"">
                        <li class=""breadcrumb-item active"">اضافة فيديو</li>
                        <li class=""breadcrumb-item""><a href=""administration/videos"">الفيديوهات</a></li>
                        <li class=""breadcrumb-item""><a href=""administration"">الإدارة</a></li>
                        <li class=""breadcrumb-item""><a href>الصفحة الرئيسية</a></li>
                    </ol>
                </div>
            </div>
        </div>
    </div>

    ");
            __builder.OpenElement(1, "div");
            __builder.AddAttribute(2, "class", "content");
            __builder.AddMarkupContent(3, "\r\n        ");
            __builder.OpenElement(4, "div");
            __builder.AddAttribute(5, "class", "container-fluid");
            __builder.AddMarkupContent(6, "\r\n\r\n\r\n");
#nullable restore
#line 34 "D:\Mahwous\MahwousWeb\Client\Pages\Administration\Videos\Create.razor"
         if (NotSelectedCategories != null)
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(7, "            ");
            __builder.OpenComponent<MahwousWeb.Client.Pages.Administration.Videos.VideoForm>(8);
            __builder.AddAttribute(9, "ButtonText", "إضافة فيديو");
            __builder.AddAttribute(10, "Video", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MahwousWeb.Shared.Models.VideoStatus>(
#nullable restore
#line 36 "D:\Mahwous\MahwousWeb\Client\Pages\Administration\Videos\Create.razor"
                                                       video

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(11, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, 
#nullable restore
#line 37 "D:\Mahwous\MahwousWeb\Client\Pages\Administration\Videos\Create.razor"
                                      CreateVideo

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(12, "NotSelectedCategories", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.Generic.List<MahwousWeb.Shared.Models.Category>>(
#nullable restore
#line 37 "D:\Mahwous\MahwousWeb\Client\Pages\Administration\Videos\Create.razor"
                                                                          NotSelectedCategories

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(13, "\r\n");
#nullable restore
#line 38 "D:\Mahwous\MahwousWeb\Client\Pages\Administration\Videos\Create.razor"

        }

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(14, "\r\n\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(15, "\r\n    ");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 49 "D:\Mahwous\MahwousWeb\Client\Pages\Administration\Videos\Create.razor"
           


        VideoStatus video = new VideoStatus();


        private List<Category> NotSelectedCategories;

        protected override async Task OnInitializedAsync()
        {
            var paginatedResponse = await categoryRepository.GetCategoriesFiltered(new CategoryFilter() { ForVideos = true, RecordsPerPage = 100 });
            NotSelectedCategories = paginatedResponse.Response;


            // to give tokens to api :)
            await authorizer.SetAuthorizationAsync();
        }

        async Task CreateVideo()
        {


            try
            {
                await videoRepository.Add(video);
                navigation.NavigateTo("administration/videos");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager navigation { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ICategoryRepository categoryRepository { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IVideoRepository videoRepository { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpAuthorizer authorizer { get; set; }
    }
}
#pragma warning restore 1591
