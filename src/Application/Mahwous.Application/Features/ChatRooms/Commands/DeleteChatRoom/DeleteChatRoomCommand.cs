using MediatR;

namespace Mahwous.Application.Features.ChatRooms
{
    public class DeleteChatRoomCommand : IRequest
    {
        public int Id { get; set; }
    }
}
