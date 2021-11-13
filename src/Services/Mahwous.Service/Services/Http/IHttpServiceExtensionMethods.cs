using Mahwous.Core.Pagination;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Mahwous.Service.Services
{
    public static class IHttpServiceExtensionMethods
    {
        public static async Task<T> GetHelper<T>(this IHttpService httpService, string url)
        {
            var response = await httpService.Get<T>(url);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }

        public static async Task<PaginatedResponse<T>> GetHelper<T>(this IHttpService httpService, string url,
            PaginationDetails pagination)
        {
            string newURL = "";
            if (url.Contains("?"))
            {
                newURL = $"{url}&page={pagination.PageIndex}&PageSize={pagination.PageSize}";
            }
            else
            {
                newURL = $"{url}?page={pagination.PageIndex}&PageSize={pagination.PageSize}";
            }

            var httpResponse = await httpService.Get<T>(newURL);
            var totalAmountPages = int.Parse(httpResponse.HttpResponseMessage.Headers.GetValues("totalAmountPages").FirstOrDefault());
            var PageSize = int.Parse(httpResponse.HttpResponseMessage.Headers.GetValues("PageSize").FirstOrDefault());
            var currentPage = int.Parse(httpResponse.HttpResponseMessage.Headers.GetValues("currentPage").FirstOrDefault());
            var paginatedResponse = new PaginatedResponse<T>
            {
                Response = httpResponse.Response,
                TotalPages = totalAmountPages,
                Pagination = new PaginationDetails
                {
                    PageIndex = currentPage,
                    PageSize = PageSize
                }
            };
            return paginatedResponse;
        }

    }
}
