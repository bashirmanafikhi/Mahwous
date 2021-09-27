using Mahwous.Core.Models;
using MahwousWeb.Service.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MahwousWeb.Service.Repositories
{
    public class PostRepository : RepositoryBase<Post>
    {
        public PostRepository(IHttpService httpService, string url) : base(httpService, url)
        { }

        public async Task<int> Add(Post post, Stream imageFile)
        {
            var response = await httpService.PostMultipartContent<Post, int>(url, post,
                new KeyValuePair<string, Stream>("coverFile", imageFile));

            if (!response.Success)
                throw new ApplicationException(await response.GetBody());

            return response.Response;
        }

        public async Task Update(Post post, Stream imageFile)
        {
            var response = await httpService.PutMultipartContent(url, post,
                new KeyValuePair<string, Stream>("coverFile", imageFile));

            if (!response.Success)
                throw new ApplicationException(await response.GetBody());
        }
    }
}
