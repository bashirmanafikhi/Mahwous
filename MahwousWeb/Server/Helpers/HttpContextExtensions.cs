using MahwousWeb.Shared.Pagination;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MahwousWeb.Server.Helpers
{
    public static class HttpContextExtensions
    {
        public async static Task InsertPaginationParametersInResponse<T>(this HttpContext httpContext,
            IQueryable<T> queryable, PaginationDetails pagination)
        {
            if (httpContext == null) { throw new ArgumentNullException(nameof(httpContext)); }

            int count = await queryable.CountAsync();
            double totalAmountPages = Math.Ceiling((double)count / pagination.RecordsPerPage);
            httpContext.Response.Headers.Add("totalAmountPages", totalAmountPages.ToString());
            httpContext.Response.Headers.Add("recordsPerPage", pagination.RecordsPerPage.ToString());
            httpContext.Response.Headers.Add("currentPage", pagination.Page.ToString());
        }
    }
}
