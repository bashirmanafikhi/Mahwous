using MahwousWeb.Client.Helpers;
using MahwousWeb.Shared.Repositories;
using MahwousWeb.Shared.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MahwousWeb.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");



            builder.Services.AddHttpClient<NotAuthorizedRepositories>("MahwousWeb.NotAuthorizedHttp", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

            builder.Services.AddHttpClient<AuthorizedRepositories>("MahwousWeb.AuthorizedHttp", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
            .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            // Supply HttpClient instances that include access tokens when making requests to the server project
            // builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("MahwousWeb.AuthorizedHttp"));

            builder.Services.AddApiAuthorization();










            #region Delete Zone

            //builder.Services.AddSingleton(sp => new HttpClient
            //{ BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            //builder.Services.AddScoped(sp => new HttpClient
            //{ BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });



            //var httpClient = new HttpClient
            //{
            //    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
            //};


            //var repositories = new MahwousRepositories(httpClient);

            //builder.Services.AddSingleton<MahwousRepositories>(repositories);

            //builder.Services.AddScoped(sp => httpClient);

            //builder.Services.AddScoped<HttpAuthorizer>();

            //builder.Services.AddApiAuthorization();

            //builder.Services.AddOptions();
            //builder.Services.AddAuthorizationCore(); 

            #endregion

            await builder.Build().RunAsync();
        }
    }
}
