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
    public class VideoRepository : StatusRepositoryBase, IVideoRepository
    {
        protected readonly string url = "api/videos";

        public VideoRepository(IHttpService httpService) : base(httpService) { }


        public async Task Add(VideoStatus video)
        {
            var response = await httpService.Post(url, video);
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

        public async Task<VideoStatus> Get(int id)
        {
            var response = await httpService.Get<VideoStatus>($"{url}/{id}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }

        public async Task<PaginatedResponse<List<VideoStatus>>> GetVideos(PaginationDTO paginationDTO)
        {
            return await httpService.GetHelper<List<VideoStatus>>(url, paginationDTO);
        }

        public async Task Update(VideoStatus video)
        {
            var response = await httpService.Put(url, video);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task<PaginatedResponse<List<VideoStatus>>> GetVideosFiltered(VideoFilter videoFilter)
        {
            var responseHTTP = await httpService.Post<VideoFilter, List<VideoStatus>>($"{url}/filter", videoFilter);
            var totalAmountPages = int.Parse(responseHTTP.HttpResponseMessage.Headers.GetValues("totalAmountPages").FirstOrDefault());
            var paginatedResponse = new PaginatedResponse<List<VideoStatus>>()
            {
                Response = responseHTTP.Response,
                TotalAmountPages = totalAmountPages
            };

            return paginatedResponse;
        }

        public async Task<FilteredInformations> GetInformations(VideoFilter filter = null)
        {
            if (filter is null)
            {
                var responseHTTP = await httpService.Get<FilteredInformations>($"{url}/count");
                return responseHTTP.Response;
            }
            else
            {
                var responseHTTP = await httpService.Post<VideoFilter, FilteredInformations>($"{url}/count", filter);
                return responseHTTP.Response;
            }
        }

        public async Task<VideoStatus> GetRandomVideo()
        {
            var filter = new VideoFilter() { RecordsPerPage = 1 };
            var responseHTTP = await GetVideosFiltered(filter);
            var video = responseHTTP.Response.First();
            return video;
        }
    }
}
