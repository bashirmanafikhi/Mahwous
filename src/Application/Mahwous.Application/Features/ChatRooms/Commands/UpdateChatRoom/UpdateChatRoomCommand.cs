using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Mahwous.Application.Features.ChatRooms
{
    public class UpdateChatRoomCommand : IRequest<int>, IMapTo<ChatRoom>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IFormFile Cover { get; set; }
    }
}
