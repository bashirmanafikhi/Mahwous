using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Mahwous.Application.Features.ChatRooms
{
    public class CreateChatRoomCommand : IRequest<int>, IMapTo<ChatRoom>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public IFormFile Cover { get; set; }
    }
}
