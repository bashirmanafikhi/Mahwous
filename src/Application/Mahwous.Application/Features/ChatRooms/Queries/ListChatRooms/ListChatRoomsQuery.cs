using Mahwous.Application.Interfaces;
using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using MediatR;

namespace Mahwous.Application.Features.ChatRooms
{
    public class ListChatRoomsQuery : IListQuery<ChatRoom, ChatRoomFilter, ListChatRoomsResponse>
    {
        public ChatRoomFilter Filter { get; set; }
        public EntitySortType SortType { get; set; } = EntitySortType.Random;
    }
}
