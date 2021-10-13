using Mahwous.Core.Entities;
using Mahwous.Core.Filters;
using Mahwous.Core.General;
using Mahwous.Core.Pagination;
using Mahwous.Service.Services;
using Mahwous.Service.ViewModels.Posts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Mahwous.Service.NewRepositores
{
    public class PostRepository
    {
        private readonly IHttpService httpService;
        private readonly string url;

        public PostRepository(IHttpService httpService, string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentException($"'{nameof(url)}' cannot be null or empty.", nameof(url));

            this.httpService = httpService ?? throw new ArgumentNullException(nameof(httpService));
            this.url = url;
        }

        public async Task<SearchPostsResponse> Search(SearchPostsQuery query)
        {
            string url = this.url + "?" + query.Query;
            return await httpService.GetHelper<SearchPostsResponse>(url);
        }

        public async Task<int> Add(CreatePostCommand command)
        {
            var response = await httpService.PostMultipartContent<CreatePostCommand, int>(url, command);

            if (!response.Success)
                throw new ApplicationException(await response.GetBody());

            return response.Response;
        }






        ////////////////////////////////////////////////////////////////////////////////////////////////////////



        public async Task Update(Post post, Stream imageFile)
        {
            var response = await httpService.PutMultipartContent(url, post);

            if (!response.Success)
                throw new ApplicationException(await response.GetBody());
        }

        public async Task Delete(int id)
        {
            var response = await httpService.Delete($"{url}/{id}");
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

        public async Task<Post> GetRandom()
        {
            return await httpService.GetHelper<Post>($"{url}/GetRandom");
        }

        public async Task<ICollection<Post>> GetAll()
        {
            return await httpService.GetHelper<ICollection<Post>>($"{url}/GetAll");
        }

        public async Task<PaginatedResponse<ICollection<Post>>> GetPaginated(PaginationDetails pagination)
        {
            return await httpService.GetHelper<ICollection<Post>>($"{url}/GetPaginated", pagination);
        }

        public async Task<PaginatedResponse<ICollection<Post>>> GetFiltered(IFilter<Post> filter)
        {
            var responseHTTP = await httpService.Post<IFilter<Post>, ICollection<Post>>($"{url}/GetFiltered", filter);
            var totalAmountPages = int.Parse(responseHTTP.HttpResponseMessage.Headers.GetValues("totalAmountPages").FirstOrDefault());
            var paginatedResponse = new PaginatedResponse<ICollection<Post>>()
            {
                Response = responseHTTP.Response,
                TotalPages = totalAmountPages
            };

            return paginatedResponse;
        }

        public async Task<int> GetCount()
        {
            return await httpService.GetHelper<int>($"{url}/GetCount");
        }

        public async Task<int> GetCount(IFilter<Post> filter)
        {
            var responseHTTP = await httpService.Post<IFilter<Post>, int>($"{url}/GetCountFiltered", filter);
            return responseHTTP.Response;
        }

        public async Task<Informations> GetInformations()
        {
            return await httpService.GetHelper<Informations>($"{url}/GetInformations");
        }

        public async Task<Informations> GetInformations(IFilter<Post> filter)
        {
            var responseHTTP = await httpService.Post<IFilter<Post>, Informations>($"{url}/GetInformationsFiltered", filter);
            return responseHTTP.Response;
        }

        public async Task IncrementViews(int id)
        {
            var response = await httpService.Put($"{url}/IncrementViews/{id}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task Update(Post post)
        {
            var response = await httpService.PutMultipartContent(url, post);

            if (!response.Success)
                throw new ApplicationException(await response.GetBody());
        }








    }
}
