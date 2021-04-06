using MahwousWeb.Client.Auth;
using MahwousWeb.Client.Helpers;
using MahwousWeb.Service.Repositories;
using MahwousWeb.Service.Services;
using Microsoft.AspNetCore.Components.Authorization;
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


            builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


            builder.Services.AddSingleton(sp =>
                new MahwousRepositories(sp.GetRequiredService<HttpClient>())
            );


            ConfigureServices(builder.Services);


            await builder.Build().RunAsync();
        }



        private static void ConfigureServices(IServiceCollection services)
        {


            services.AddApiAuthorization();


            services.AddScoped<IAccountsRepository, AccountsRepository>();
            services.AddScoped<IUsersRepository, UserRepository>();



            services.AddAuthorizationCore();








            //services.AddScoped<AuthenticationStateProvider, DummyAuthenticationStateProvider>();



            services.AddScoped<JWTAuthenticationStateProvider>();

            services.AddScoped<AuthenticationStateProvider, JWTAuthenticationStateProvider>(
                provider => provider.GetRequiredService<JWTAuthenticationStateProvider>()
                );

            services.AddScoped<ILoginService, JWTAuthenticationStateProvider>(
                provider => provider.GetRequiredService<JWTAuthenticationStateProvider>()
                );
        }
    }
}
