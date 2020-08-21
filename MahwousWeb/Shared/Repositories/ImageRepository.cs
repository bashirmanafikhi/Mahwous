using MahwousWeb.Shared.Models;
using MahwousWeb.Shared.Pagination;
using MahwousWeb.Shared.Services;
using MahwousWeb.Shared.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MahwousWeb.Shared.Filters;
using System.Linq;

namespace MahwousWeb.Shared.Repositories
{
    public class ImageRepository : StatusRepositoryBase, IImageRepository
    {
        protected string url = "api/images";

        public ImageRepository(IHttpService httpService) : base(httpService) { }


        public async Task Add(ImageStatus image)
        {
            var response = await httpService.Post(url, image);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task Delete(int Id)
        {
            var response = await httpService.Delete($"{url}/{Id}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task<ImageStatus> Get(int id)
        {
            var response = await httpService.Get<ImageStatus>($"{url}/{id}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }

        public async Task<PaginatedResponse<List<ImageStatus>>> GetImages(PaginationDTO paginationDTO)
        {
            return await httpService.GetHelper<List<ImageStatus>>(url, paginationDTO);
        }

        public async Task Update(ImageStatus image)
        {
            var response = await httpService.Put(url, image);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task<PaginatedResponse<List<ImageStatus>>> GetImagesFiltered(ImageFilter imageFilter)
        {
            var responseHTTP = await httpService.Post<ImageFilter, List<ImageStatus>>($"{url}/filter", imageFilter);
            var totalAmountPages = int.Parse(responseHTTP.HttpResponseMessage.Headers.GetValues("totalAmountPages").FirstOrDefault());
            var paginatedResponse = new PaginatedResponse<List<ImageStatus>>()
            {
                Response = responseHTTP.Response,
                TotalAmountPages = totalAmountPages
            };

            return paginatedResponse;
        }
    }
}
