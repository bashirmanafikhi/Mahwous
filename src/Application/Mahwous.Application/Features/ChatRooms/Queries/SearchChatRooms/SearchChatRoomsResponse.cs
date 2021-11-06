using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using Mahwous.Core.Pagination;

namespace Mahwous.Application.Features.ChatRooms
{
    public class SearchChatRoomsResponse : PaginatedList<ChatRoom>, IMapFrom<PaginatedList<ChatRoom>>
    {

    }
}
