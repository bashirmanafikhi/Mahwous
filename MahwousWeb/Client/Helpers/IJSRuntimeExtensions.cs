using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace MahwousWeb.Client.Helpers
{
    public static class IJSRuntimeExtensions
    {

        public static ValueTask DisplayMessage(this IJSRuntime js, string message)
        {
            return js.InvokeVoidAsync("Swal.fire", message);
        }

        public static ValueTask DisplayMessage(this IJSRuntime js, string title, string message, SweetAlertMessageType sweetAlertMessageType)
        {
            return js.InvokeVoidAsync("Swal.fire", title, message, sweetAlertMessageType.ToString());
        }

        public static ValueTask<bool> Confirm(this IJSRuntime js, string title, string message, SweetAlertMessageType sweetAlertMessageType)
        {
            return js.InvokeAsync<bool>("CustomConfirm", title, message, sweetAlertMessageType.ToString());
        }

        public static ValueTask<object> SetInLocalStorage(this IJSRuntime js, string key, string content)
             => js.InvokeAsync<object>(
                    "localStorage.setItem",
                key, content
                );

        public static ValueTask<string> GetFromLocalStorage(this IJSRuntime js, string key)
            => js.InvokeAsync<string>(
                    "localStorage.getItem",
                    key
                );

        public static ValueTask<object> RemoveItem(this IJSRuntime js, string key)
            => js.InvokeAsync<object>(
                    "localStorage.removeItem",
                key);


    }

    public enum SweetAlertMessageType
    {
        question, warning, error, success, info
    }
}
