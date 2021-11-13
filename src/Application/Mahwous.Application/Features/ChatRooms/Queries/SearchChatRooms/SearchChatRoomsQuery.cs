using Mahwous.Application.Interfaces;
using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using Mahwous.Core.Pagination;

namespace Mahwous.Application.Features.ChatRooms
{
    public class SearchChatRoomsQuery : ChatRoomFilter, ISearchQuery<ChatRoomFilter, SearchChatRoomsResponse>
    {
        public PaginationDetails Pagination { get; set; } = new PaginationDetails();
        public EntitySortType SortType { get; set; } = EntitySortType.Random;
    }
}
