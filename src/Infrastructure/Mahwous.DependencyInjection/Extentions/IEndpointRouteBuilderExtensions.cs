using Mahwous.Chat.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahwous.DependencyInjection
{
    public static class IEndpointRouteBuilderExtensions
    {
        public static IEndpointRouteBuilder MapMahwousServices(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapHub<ChatHub>("ChatHub");
            return endpoints;
        }
    }
}
