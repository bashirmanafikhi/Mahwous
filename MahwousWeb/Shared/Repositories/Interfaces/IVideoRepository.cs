using MahwousWeb.Shared.Filters;
using MahwousWeb.Shared.Models;
using MahwousWeb.Shared.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MahwousWeb.Shared.Repositories.Interfaces
{
    public interface IVideoRepository : IStatusRepositoryBase
    {
        Task Add(VideoStatus video);
        Task<VideoStatus> Get(int id);
        Task<PaginatedResponse<List<VideoStatus>>> GetVideos(PaginationDTO paginationDTO);
        Task Update(VideoStatus video);
        Task Delete(int Id);
        Task<PaginatedResponse<List<VideoStatus>>> GetVideosFiltered(VideoFilter videoFilter);
        Task<FilteredInformations> GetInformations(VideoFilter filter = null);
        Task<VideoStatus> GetRandomVideo();
    }
}
