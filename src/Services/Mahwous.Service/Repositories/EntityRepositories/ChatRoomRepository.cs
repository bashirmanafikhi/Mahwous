using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using Mahwous.Core.Pagination;
using Mahwous.Service.Services;
using Mahwous.Service.ViewModels.ChatRooms;
using System;
using System.Threading.Tasks;

namespace Mahwous.Service.Repositories
{
    public class ChatRoomRepository
    {
        private readonly IHttpService httpService;
        private readonly string url;

        public ChatRoomRepository(IHttpService httpService, string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentException($"'{nameof(url)}' cannot be null or empty.", nameof(url));

            this.httpService = httpService ?? throw new ArgumentNullException(nameof(httpService));
            this.url = url;
        }

        public async Task<SearchChatRoomsResponse> Search(PaginationDetails pagination)
        {
            return await Search(pagination, null);
        }

        public async Task<SearchChatRoomsResponse> Search(PaginationDetails pagination, ChatRoomFilter filter)
        {
            return await Search(pagination, filter, default);
        }

        public async Task<SearchChatRoomsResponse> Search(PaginationDetails pagination, ChatRoomFilter filter, EntitySortType sortType)
        {
            SearchChatRoomsQuery query = new SearchChatRoomsQuery
            {
                Filter = filter,
                Pagination = pagination,
                SortType = sortType
            };
            return await Search(query);
        }

        public async Task<SearchChatRoomsResponse> Search(SearchChatRoomsQuery query)
        {
            string url = this.url + "?" + query.Query;

            return await httpService.GetHelper<SearchChatRoomsResponse>(url);
        }

        public async Task<ListChatRoomsResponse> List()
        {
            return await List(filter: null);
        }

        public async Task<ListChatRoomsResponse> List(ChatRoomFilter filter)
        {
            return await List(filter, default);
        }

        public async Task<ListChatRoomsResponse> List(ChatRoomFilter filter, EntitySortType sortType)
        {
            ListChatRoomsQuery query = new ListChatRoomsQuery
            {
                Filter = filter,
                SortType = sortType
            };
            return await List(query);
        }

        public async Task<ListChatRoomsResponse> List(ListChatRoomsQuery query)
        {
            string url = this.url + "/list?" + query.Query;
            return await httpService.GetHelper<ListChatRoomsResponse>(url);
        }

        public async Task<GetChatRoomDetailsResponse> GetDetails(int id)
        {
            return await httpService.GetHelper<GetChatRoomDetailsResponse>(url + $"/{id }");
        }

        public async Task<GetRandomChatRoomResponse> GetRandom()
        {
            return await httpService.GetHelper<GetRandomChatRoomResponse>(url + "/random");
        }

        public async Task<int> Create(CreateChatRoomCommand command)
        {
            var response = await httpService.PostMultipartContent<CreateChatRoomCommand, int>(url, command);

            if (!response.Success)
                throw new ApplicationException(await response.GetBody());

            return response.Response;
        }

        public async Task<int> Update(UpdateChatRoomCommand command)
        {
            var response = await httpService.PutMultipartContent<UpdateChatRoomCommand, int>(url, command);

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
