using MediatR;

namespace Mahwous.Application.Features.ChatRooms
{
    public class GetChatRoomDetailsQuery : IRequest<GetChatRoomDetailsResponse>
    {
        public int Id { get; set; }
    }
}
