using MahwousWeb.Client.Helpers;
using MahwousWeb.Shared.Repositories;
using MahwousWeb.Shared.Services;
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


            builder.Services.AddSingleton(sp => new HttpClient
            { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddScoped(sp => new HttpClient
            { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });



            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
            };


            var repositories = new MahwousRepositories(httpClient);

            builder.Services.AddSingleton<MahwousRepositories>(repositories);

            builder.Services.AddScoped(sp => httpClient);

            builder.Services.AddScoped<HttpAuthorizer>();

            builder.Services.AddApiAuthorization();

            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();

            await builder.Build().RunAsync();
        }
    }
}
