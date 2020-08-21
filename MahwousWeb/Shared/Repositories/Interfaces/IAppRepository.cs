using MahwousWeb.Shared.Models;
using MahwousWeb.Shared.Pagination;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MahwousWeb.Shared.Repositories.Interfaces
{
    public interface IAppRepository
    {
        Task Add(App app);
        Task<App> Get(int id);
        Task<PaginatedResponse<List<App>>> GetApps(PaginationDTO paginationDTO);
        Task Update(App app);
        Task Delete(int Id);
    }
}
