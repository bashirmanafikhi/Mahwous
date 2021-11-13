using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahwous.DependencyInjection
{
    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseMahwousServices(this IApplicationBuilder endpoints)
        {

            return endpoints;
        }
    }
}
