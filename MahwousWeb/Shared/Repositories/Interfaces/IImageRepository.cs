using MahwousWeb.Shared.Filters;
using MahwousWeb.Shared.Models;
using MahwousWeb.Shared.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MahwousWeb.Shared.Repositories.Interfaces
{
    public interface IImageRepository : IStatusRepositoryBase
    {
        Task Add(ImageStatus image);
        Task<ImageStatus> Get(int id);
        Task<PaginatedResponse<List<ImageStatus>>> GetImages(PaginationDTO paginationDTO);
        Task Update(ImageStatus image);
        Task Delete(int Id);
        Task<PaginatedResponse<List<ImageStatus>>> GetImagesFiltered(ImageFilter imageFilter);
        Task<FilteredInformations> GetInformations(ImageFilter filter = null);
        Task<ImageStatus> GetRandomImage();
    }
}
