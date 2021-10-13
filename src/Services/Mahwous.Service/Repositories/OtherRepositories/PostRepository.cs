using Mahwous.Core.Entities;
using Mahwous.Service.Services;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Mahwous.Service.Repositories
{
    public class PostRepository : RepositoryBase<Post>
    {
        public PostRepository(IHttpService httpService, string url) : base(httpService, url)
        { }

        public async Task<int> Add(Post post, Stream imageFile)
        {
            var response = await httpService.PostMultipartContent<Post, int>(url, post);

            if (!response.Success)
                throw new ApplicationException(await response.GetBody());

            return response.Response;
        }

        public async Task Update(Post post, Stream imageFile)
        {
            var response = await httpService.PutMultipartContent(url, post);

            if (!response.Success)
                throw new ApplicationException(await response.GetBody());
        }
    }
}
