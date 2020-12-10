using MahwousWeb.Shared.Pagination;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MahwousWeb.Shared.Services
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
                newURL = $"{url}&page={pagination.Page}&recordsPerPage={pagination.RecordsPerPage}";
            }
            else
            {
                newURL = $"{url}?page={pagination.Page}&recordsPerPage={pagination.RecordsPerPage}";
            }

            var httpResponse = await httpService.Get<T>(newURL);
            var totalAmountPages = int.Parse(httpResponse.HttpResponseMessage.Headers.GetValues("totalAmountPages").FirstOrDefault());
            var recordsPerPage = int.Parse(httpResponse.HttpResponseMessage.Headers.GetValues("recordsPerPage").FirstOrDefault());
            var currentPage = int.Parse(httpResponse.HttpResponseMessage.Headers.GetValues("currentPage").FirstOrDefault());
            var paginatedResponse = new PaginatedResponse<T>
            {
                Response = httpResponse.Response,
                TotalAmountPages = totalAmountPages,
                Pagination = new PaginationDetails
                {
                    Page = currentPage,
                    RecordsPerPage = recordsPerPage
                }
            };
            return paginatedResponse;
        }

    }
}
