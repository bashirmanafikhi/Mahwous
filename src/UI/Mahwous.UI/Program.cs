using Mahwous.Service.Chat;
using Mahwous.Service.Repositories;
using Mahwous.UI.Auth;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mahwous.UI
{
    public class Program
    {
        private static string url;
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            url = builder.HostEnvironment.BaseAddress;

            ConfigureServices(builder.Services);

            await builder.Build().RunAsync();
        }



        private static void ConfigureServices(IServiceCollection services)
        {
           services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(url) });

            services.AddSingleton(sp =>
                new MahwousRepositories(sp.GetRequiredService<HttpClient>())
            );

            services.AddApiAuthorization();

            services.AddScoped<IAccountsRepository, AccountsRepository>();
            services.AddScoped<IUsersRepository, UserRepository>();
            services.AddScoped<IChatService, ChatService>(x => new ChatService(url));

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
