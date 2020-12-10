using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MahwousWeb.Client.Helpers
{
    public class HttpAuthorizer
    {
        private readonly HttpClient http;
        private readonly IAccessTokenProvider tokenProvider;

        public HttpAuthorizer(HttpClient http, IAccessTokenProvider tokenProvider)
        {
            this.http = http;
            this.tokenProvider = tokenProvider;
        }

        public async Task<bool> SetAuthorizationAsync()
        {
            var tokenResult = await tokenProvider.RequestAccessToken();

            if (tokenResult.TryGetToken(out var token))
            {
                http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Value);

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
