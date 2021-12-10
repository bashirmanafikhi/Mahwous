using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Mahwous.Application.Features.Messages
{
    public class UpdateMessageCommand : IRequest<int>, IMapTo<Message>
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }
        public int RoomId { get; set; }
    }
}
