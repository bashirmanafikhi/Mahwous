using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahwousWeb.Server.Helpers
{
    public static class HttpContextExtensions
    {
        public async static Task InsertPaginationParametersInResponse<T>(this HttpContext httpContext,
            IQueryable<T> queryable, int recordsPerPage)
        {
            if (httpContext == null) { throw new ArgumentNullException(nameof(httpContext)); }

            int count = await queryable.CountAsync();
            double totalAmountPages = Math.Ceiling((double)count / recordsPerPage);
            httpContext.Response.Headers.Add("totalAmountPages", totalAmountPages.ToString());
        }
    }
}
