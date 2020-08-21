#pragma checksum "D:\Mahwous\MahwousWeb\Client\Shared\Components\InputImage.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "29e05346a79dacfc4869dd1e3d13010eed748e3b"
// <auto-generated/>
#pragma warning disable 1591
namespace MahwousWeb.Client.Shared.Components
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
#nullable restore
#line 1 "D:\Mahwous\MahwousWeb\Client\Shared\Components\InputImage.razor"
using System.IO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Mahwous\MahwousWeb\Client\Shared\Components\InputImage.razor"
using Blazor.FileReader;

#line default
#line hidden
#nullable disable
    public partial class InputImage : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddMarkupContent(1, "\r\n    ");
            __builder.OpenElement(2, "label");
            __builder.AddContent(3, 
#nullable restore
#line 6 "D:\Mahwous\MahwousWeb\Client\Shared\Components\InputImage.razor"
            Label

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(4, "\r\n    ");
            __builder.OpenElement(5, "div");
            __builder.AddMarkupContent(6, "\r\n        ");
            __builder.OpenElement(7, "input");
            __builder.AddAttribute(8, "type", "file");
            __builder.AddAttribute(9, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 8 "D:\Mahwous\MahwousWeb\Client\Shared\Components\InputImage.razor"
                                                          ImageFileSelected

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(10, "accept", ".jpg,.jpeg,.png");
            __builder.AddElementReferenceCapture(11, (__value) => {
#nullable restore
#line 8 "D:\Mahwous\MahwousWeb\Client\Shared\Components\InputImage.razor"
                                 inputElement = __value;

#line default
#line hidden
#nullable disable
            }
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(12, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(13, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(14, "\r\n");
            __builder.OpenElement(15, "div");
            __builder.AddMarkupContent(16, "\r\n");
#nullable restore
#line 12 "D:\Mahwous\MahwousWeb\Client\Shared\Components\InputImage.razor"
     if (imageBase64 != null)
    {

#line default
#line hidden
#nullable disable
            __builder.AddContent(17, "        ");
            __builder.OpenElement(18, "div");
            __builder.AddMarkupContent(19, "\r\n            ");
            __builder.OpenElement(20, "div");
            __builder.AddAttribute(21, "style", "margin:10px");
            __builder.AddMarkupContent(22, "\r\n                ");
            __builder.OpenElement(23, "img");
            __builder.AddAttribute(24, "src", "data:image/jpeg;base64," + " " + (
#nullable restore
#line 16 "D:\Mahwous\MahwousWeb\Client\Shared\Components\InputImage.razor"
                                                   imageBase64

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(25, "style", "width: 400px;");
            __builder.CloseElement();
            __builder.AddMarkupContent(26, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(27, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(28, "\r\n");
#nullable restore
#line 19 "D:\Mahwous\MahwousWeb\Client\Shared\Components\InputImage.razor"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "D:\Mahwous\MahwousWeb\Client\Shared\Components\InputImage.razor"
     if (ImageURL != null)
    {

#line default
#line hidden
#nullable disable
            __builder.AddContent(29, "        ");
            __builder.OpenElement(30, "div");
            __builder.AddMarkupContent(31, "\r\n            ");
            __builder.OpenElement(32, "div");
            __builder.AddAttribute(33, "style", "margin:10px");
            __builder.AddMarkupContent(34, "\r\n                ");
            __builder.OpenElement(35, "img");
            __builder.AddAttribute(36, "src", 
#nullable restore
#line 24 "D:\Mahwous\MahwousWeb\Client\Shared\Components\InputImage.razor"
                           ImageURL

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(37, "style", "width: 400px;");
            __builder.CloseElement();
            __builder.AddMarkupContent(38, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(39, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(40, "\r\n");
#nullable restore
#line 27 "D:\Mahwous\MahwousWeb\Client\Shared\Components\InputImage.razor"
    }

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(41, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 31 "D:\Mahwous\MahwousWeb\Client\Shared\Components\InputImage.razor"
       
    [Parameter] public string Label { get; set; } = "Image";
    [Parameter] public string ImageURL { get; set; }
    [Parameter] public EventCallback<string> OnSelectedImage { get; set; }
    private string imageBase64;
    ElementReference inputElement;

    async Task ImageFileSelected()
    {
        foreach (var file in await fileReaderService.CreateReference(inputElement).EnumerateFilesAsync())
        {
            using (MemoryStream memoryStream = await file.CreateMemoryStreamAsync(4 * 1024))
            {
                var imageBytes = new byte[memoryStream.Length];
                memoryStream.Read(imageBytes, 0, (int)memoryStream.Length);
                imageBase64 = Convert.ToBase64String(imageBytes);
                await OnSelectedImage.InvokeAsync(imageBase64);
                ImageURL = null;
                StateHasChanged();
            }
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IFileReaderService fileReaderService { get; set; }
    }
}
#pragma warning restore 1591
