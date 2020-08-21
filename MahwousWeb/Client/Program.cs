using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MahwousWeb.Shared;
using Blazor.FileReader;
using MahwousWeb.Shared.Services;
using MahwousWeb.Shared.Repositories;
using MahwousWeb.Client.Helpers;
using MahwousWeb.Shared.Repositories.Interfaces;
using System.Net.Http;

namespace MahwousWeb.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddFileReaderService(options => options.InitializeOnFirstCall = true);

            builder.Services.AddScoped<IHttpService, HttpService>();

            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IQuoteRepository, QuoteRepository>();
            builder.Services.AddScoped<IImageRepository, ImageRepository>();
            builder.Services.AddScoped<IVideoRepository, VideoRepository>();

            builder.Services.AddScoped<IAppRepository, AppRepository>();
            builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
            builder.Services.AddScoped<IPostRepository, PostRepository>();


            builder.Services.AddScoped<HttpAuthorizer>();



            //builder.Services.AddBaseAddressHttpClient();
            builder.Services.AddSingleton(new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddApiAuthorization();

            await builder.Build().RunAsync();
        }
    }
}
