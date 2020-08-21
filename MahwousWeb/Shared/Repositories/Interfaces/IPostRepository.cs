using MahwousWeb.Shared.Models;
using MahwousWeb.Shared.Pagination;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MahwousWeb.Shared.Repositories.Interfaces
{
    public interface IPostRepository
    {
        Task Add(Post post);
        Task<Post> Get(int id);
        Task<PaginatedResponse<List<Post>>> GetPosts(PaginationDTO paginationDTO);
        Task Update(Post post);
        Task Delete(int Id);
    }
}
