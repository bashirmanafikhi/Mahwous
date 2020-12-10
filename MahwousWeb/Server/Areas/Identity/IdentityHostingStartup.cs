using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(MahwousWeb.Server.Areas.Identity.IdentityHostingStartup))]
namespace MahwousWeb.Server.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}