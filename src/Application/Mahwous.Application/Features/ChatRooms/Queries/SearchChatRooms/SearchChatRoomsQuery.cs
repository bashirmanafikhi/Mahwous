using Mahwous.Application.Interfaces;
using Mahwous.Core.Entities;
using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using Mahwous.Core.Pagination;

namespace Mahwous.Application.Features.ChatRooms
{
    public class SearchChatRoomsQuery : ISearchQuery<ChatRoom, ChatRoomFilter, SearchChatRoomsResponse>
    {
        public ChatRoomFilter Filter { get; set; }
        public PaginationDetails Pagination { get; set; } = new PaginationDetails();
        public EntitySortType SortType { get; set; } = EntitySortType.Random;
    }
}
