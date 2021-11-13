using Mahwous.Application.Mappings;
using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using MediatR;

namespace Mahwous.Application.Features.ChatRooms
{
    public class ListChatRoomsQuery : ChatRoomFilter, IMapTo<ChatRoomFilter>, IRequest<ListChatRoomsResponse>
    {
        public EntitySortType SortType { get; set; } = EntitySortType.Random;
    }
}
