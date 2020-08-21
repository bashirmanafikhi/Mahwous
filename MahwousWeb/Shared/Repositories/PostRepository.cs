using MahwousWeb.Shared.Models;
using MahwousWeb.Shared.Pagination;
using MahwousWeb.Shared.Services;
using MahwousWeb.Shared.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace MahwousWeb.Shared.Repositories
{
    public class PostRepository : IPostRepository
    {
        protected string url = "api/posts";

        private readonly IHttpService httpService;


        public PostRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }


        public async Task Add(Post post)
        {
            var response = await httpService.Post(url, post);
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

        public async Task<Post> Get(int id)
        {
            var response = await httpService.Get<Post>($"{url}/{id}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }

        public async Task<PaginatedResponse<List<Post>>> GetPosts(PaginationDTO paginationDTO)
        {
            return await httpService.GetHelper<List<Post>>(url, paginationDTO);
        }

        public async Task Update(Post post)
        {
            var response = await httpService.Put(url, post);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

    }
}
