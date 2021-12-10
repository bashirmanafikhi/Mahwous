using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using Mahwous.Core.Pagination;
using Mahwous.Service.Services;
using Mahwous.Service.ViewModels.Messages;
using System;
using System.Threading.Tasks;

namespace Mahwous.Service.Repositories
{
    public class MessageRepository
    {
        private readonly IHttpService httpService;
        private readonly string url;

        public MessageRepository(IHttpService httpService, string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentException($"'{nameof(url)}' cannot be null or empty.", nameof(url));

            this.httpService = httpService ?? throw new ArgumentNullException(nameof(httpService));
            this.url = url;
        }

        public async Task<SearchMessagesResponse> Search(PaginationDetails pagination)
        {
            return await Search(pagination, null);
        }

        public async Task<SearchMessagesResponse> Search(PaginationDetails pagination, MessageFilter filter)
        {
            return await Search(pagination, filter, default);
        }

        public async Task<SearchMessagesResponse> Search(PaginationDetails pagination, MessageFilter filter, EntitySortType sortType)
        {
            SearchMessagesQuery query = new SearchMessagesQuery
            {
                Filter = filter,
                Pagination = pagination,
                SortType = sortType
            };
            return await Search(query);
        }

        public async Task<SearchMessagesResponse> Search(SearchMessagesQuery query)
        {
            string url = this.url + "?" + query.Query;

            return await httpService.GetHelper<SearchMessagesResponse>(url);
        }

        public async Task<ListMessagesResponse> List()
        {
            return await List(filter: null);
        }

        public async Task<ListMessagesResponse> List(MessageFilter filter)
        {
            return await List(filter, default);
        }

        public async Task<ListMessagesResponse> List(MessageFilter filter, EntitySortType sortType)
        {
            ListMessagesQuery query = new ListMessagesQuery
            {
                Filter = filter,
                SortType = sortType
            };
            return await List(query);
        }

        public async Task<ListMessagesResponse> List(ListMessagesQuery query)
        {
            string url = this.url + "/list?" + query.Query;
            return await httpService.GetHelper<ListMessagesResponse>(url);
        }

        public async Task<GetMessageDetailsResponse> GetDetails(int id)
        {
            return await httpService.GetHelper<GetMessageDetailsResponse>(url + $"/{id }");
        }

        public async Task<int> Create(CreateMessageCommand command)
        {
            var response = await httpService.Post<CreateMessageCommand, int>(url, command);

            if (!response.Success)
                throw new ApplicationException(await response.GetBody());

            return response.Response;
        }

        public async Task<int> Update(UpdateMessageCommand command)
        {
            var response = await httpService.Put<UpdateMessageCommand, int>(url, command);

            if (!response.Success)
                throw new ApplicationException(await response.GetBody());

            return response.Response;
        }

        public async Task Delete(int id)
        {
            var response = await httpService.Delete($"{url}/{id}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
    }
}
