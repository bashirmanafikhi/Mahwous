#pragma checksum "D:\Mahwous\MahwousWeb\Client\Pages\Test.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "069610da7c80f35b004a4d8b9c80538307db66e5"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace MahwousWeb.Client.Pages
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
using MahwousWeb.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Mahwous\MahwousWeb\Client\_Imports.razor"
using MahwousWeb.Client.Shared.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Mahwous\MahwousWeb\Client\_Imports.razor"
using MahwousWeb.Client.Shared.Admin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\Mahwous\MahwousWeb\Client\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\Mahwous\MahwousWeb\Client\_Imports.razor"
using MahwousWeb.Shared.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\Mahwous\MahwousWeb\Client\_Imports.razor"
using MahwousWeb.Shared.Repositories;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\Mahwous\MahwousWeb\Client\_Imports.razor"
using MahwousWeb.Client.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "D:\Mahwous\MahwousWeb\Client\_Imports.razor"
using MahwousWeb.Shared.Pagination;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "D:\Mahwous\MahwousWeb\Client\_Imports.razor"
using MahwousWeb.Shared.Filters;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "D:\Mahwous\MahwousWeb\Client\_Imports.razor"
using MahwousWeb.Shared.Repositories.Interfaces;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "D:\Mahwous\MahwousWeb\Client\_Imports.razor"
using Radzen;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "D:\Mahwous\MahwousWeb\Client\_Imports.razor"
using Radzen.Blazor;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(MainLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/test")]
    public partial class Test : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 32 "D:\Mahwous\MahwousWeb\Client\Pages\Test.razor"
       
    Category category;

    protected override async Task OnInitializedAsync()
    {
        category = new Category();
    }

    Dictionary<DateTime, string> events = new Dictionary<DateTime, string>();

    void Change(string value)
    {
        events.Add(DateTime.Now, "fileinput value changed");

    }

    void Error(UploadErrorEventArgs args)
    {
        events.Add(DateTime.Now, $"{args.Message}");
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
