#pragma checksum "D:\Mahwous\MahwousWeb\Client\Pages\Administration\Quotes\Create.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b0e7289f15ae7c7a5d088b8a77a935f24c6c4012"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace MahwousWeb.Client.Pages.Administration.Quotes
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
#line 3 "D:\Mahwous\MahwousWeb\Client\Pages\Administration\Quotes\Create.razor"
           [Authorize]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(AdminLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/administration/quotes/create")]
    public partial class Create : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 50 "D:\Mahwous\MahwousWeb\Client\Pages\Administration\Quotes\Create.razor"
       

    QuoteStatus quote = new QuoteStatus();


    private List<Category> NotSelectedCategories;


    protected async override Task OnInitializedAsync()
    {
        var paginatedResponse = await categoryRepository.GetCategoriesFiltered(new CategoryFilter() { ForQuotes = true, RecordsPerPage = 100 });
        NotSelectedCategories = paginatedResponse.Response;



        // to give tokens to api :)
        await authorizer.SetAuthorizationAsync();
    }

    async Task CreateQuote()
    {

        try
        {
            await quoteRepository.Add(quote);
            navigation.NavigateTo("administration/quotes");

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
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IQuoteRepository quoteRepository { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpAuthorizer authorizer { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime js { get; set; }
    }
}
#pragma warning restore 1591
