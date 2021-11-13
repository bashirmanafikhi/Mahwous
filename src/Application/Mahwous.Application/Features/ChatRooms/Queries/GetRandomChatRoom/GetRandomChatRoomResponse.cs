using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;

namespace Mahwous.Application.Features.ChatRooms
{
    public class GetRandomChatRoomResponse : GetChatRoomDetailsResponse, IMapFrom<ChatRoom>
    {

    }
}
